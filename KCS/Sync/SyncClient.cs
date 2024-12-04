using KCS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace KCS.Sync
{
    public class SyncClient : BridgeUtility, IDisposable
    {
        #region ASYNC EVENTS



        private delegate void OnAsyncCallback3();
        private OnAsyncCallback3 onAsyncCallback3 = null;
        //private ClientResultFactory clientResultFactory = null;


        private delegate void OnClientReponseReceived(byte[] response);
        private OnClientReponseReceived onClientResponseReceived;


        #endregion
        private const int WriteTimeFrequency = 20000;//30s
        private const int SyncTimeOut = 3000;//3s
        private const int SyncFingerTimeOut = 5000;//3s
        private const int SyncFaceUserTimeOut = 8000;
        private const int ReadDevoceTimeOut = 40;//3s

        private int CommandToken = 0;



        private Terminal _terminal = null;
        private CancellationTokenSource cts = new CancellationTokenSource();
        private ManualResetEvent ResetDeviceEvent = new ManualResetEvent(true);
        private ManualResetEvent SyncEvent = new ManualResetEvent(true);


        private volatile int NoReponseCount = 0;
        private volatile int WaitResetOkCount = 0;
        private long WriteTimeTick = 0;//s
        private long ReadEventTick = 0;
		private long ReadTimeOut = 8000;
		private long ReadTransOkFlag = 0;
        private long SyncUserTick = 0;
        private long SyncAddFingerTick = 0;
        private long SyncDelFingerTick = 0;
        private long SyncUserAuthTick = 0;
        private long SyncAcParaTick = 0;

        private Thread threadSyscToDevice = null;
        private bool haveSendOpenDoorCommand = false;
        #region LOCKERS
        private readonly object SyncDataLocker = new object();
        #endregion

        private SyncParameter syncDevicePara = new SyncParameter();




        const byte m_ProjectSourceNo = 1;
        const string m_ClassID = "SYNCCLIENT";
        KCS.Services.ApplicationLogService m_ApplicationLogService = new KCS.Services.ApplicationLogService();


        public SyncClient(Terminal terminal)
        {
            _terminal = terminal;
            //clientResultFactory = new ClientResultFactory(_terminal.deviceContext.IP_Internal, _terminal.deviceContext.IP, _terminal.deviceContext.SlaveSID);
            //clientResultFactory.transactionHandleEvent += Client_transactionHandleEventRest;
            onClientResponseReceived = new OnClientReponseReceived(OnClientResponseReceived);
            onAsyncCallback3 = new OnAsyncCallback3(CreateRequestAndSendTerminal);

            SyncClientRun();
            //AsyncCreateRequestAndSendTerminal();
        }

        private void AddTraceMessage(string message)
        {
            if (_terminal.deviceContext.DeviceTraceEvent != null)
                _terminal.deviceContext.DeviceTraceEvent(_terminal.deviceContext.SlaveSID, "Device ID:" + _terminal.deviceContext.SlaveSID.ToString() + "-" + message + "-" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        private void AddErrorMessage(string message)
        {
            AddTraceMessage("<color=Red>" + message + "</color>");
        }
        private void AddWorkMessage(string message)
        {
            AddTraceMessage("<color=Blue>" + message + "</color>");
        }
        private void AddResultMessage(string message)
        {
            AddTraceMessage("<color=Green>" + message + "</color>");
        }
        private void Client_OnDisconnected(object sender, NetSockets.NetDisconnectedEventArgs e)
        {
            //_logger.Write("Broker Client Disconnected From Terminal");
            _terminal.UpdateDeviceStatus(false);
            AddErrorMessage("Disconnected with Terminal");

        }
        private void Client_OnConnected(object sender, NetSockets.NetConnectedEventArgs e)
        {
            //_logger.Write("Broker Client Connected To Terminal");
            AddErrorMessage("Connected with Terminal");
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="str"></param>
        private void WriteDuplicteTransaction(Transactions transaction)
        {
            if (!System.IO.Directory.Exists("DiscardedTrans"))
            {
                System.IO.Directory.CreateDirectory("DiscardedTrans");
            }

            using (var sw = new StreamWriter(@"DiscardedTrans\Trans.txt", true))
            {
                sw.WriteLine(transaction.TransactionType.ToString() + " ");
                sw.WriteLine(transaction.SlaveId.ToString() + " ");
                sw.WriteLine(transaction.DeviceIP + " ");
                sw.WriteLine(transaction.TransactionCardId + " ");
                sw.WriteLine(transaction.TransactionDateTime + " ");
                sw.WriteLine(transaction.TransSIDInDevice.ToString() + "\r\n");

                sw.Close();
            }
        }
        private void UpdateReadTransList(Transactions transaction, bool bDis = true)
        {
            lock (insertTransLocker)
            {
                SyncManage.ExportTransToTxT(transaction);
                if (ReadTransList.Count >= 2000)
                    ReadTransList.RemoveAt(ReadTransList.Count - 1);
                ReadTransList.Insert(0, transaction);
                if (_terminal.deviceContext.AddTransactionEvent != null)
                    _terminal.deviceContext.AddTransactionEvent();
            }
        }
        private bool Client_transactionHandleEventRest(Transactions transData)
        {
            bool bRet = _terminal.syncDataBaseHelper.InsertToOR_Transactions(transData);
            Employees employee = _terminal.syncDataBaseHelper.GetEmployeeByCardId(transData.TransactionCardId);
            if (employee != null)
            {
                transData.UserId = employee.UserID;
                transData.UserName = employee.UserName;
            }
            transData.DeviceName = _terminal.deviceContext.SlaveName;
            AddResultMessage("Read Transaction OK");
            if (bRet)
            {
                UpdateReadTransList(transData);
            }
            else
            {
                AddErrorMessage("Save Data to database error!");
            }
            return bRet;
        }
        private void Client_transactionHandleEventFinished(IAsyncResult ar)
        {
            ar.AsyncWaitHandle.WaitOne();
            ClientResultFactory.TransactionHandle transDelegate = (ClientResultFactory.TransactionHandle)ar.AsyncState;
            bool bResult = transDelegate.EndInvoke(ar);
            try
            {

                if (bResult)
                {
                    SendViaTcpAsSync(_terminal.CreateDleteTransactioMessage());
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Save trans Exception  : Error - " + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }
        }
        private void Client_OnReceived(object sender, NetSockets.NetReceivedEventArgs<byte[]> e)
        {
            if (e.Data.Length > 0)
            {
                SyncEvent.Set();

                /// Process Received Messsager in sparate thread
                //onClientResponseReceived.BeginInvoke(response, f => onClientResponseReceived.EndInvoke(f), null);
                try
                {
                    onClientResponseReceived.Invoke(e.Data);
                    // Task.Run(() =>
                    //{
                    //    onClientResponseReceived.Invoke(e.Data);
                    //});
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void OnClientResponseReceived(byte[] response)
        {
            ReturnCode returnCode = (ReturnCode)response[0];
            try
            {
                
                if (response.Length == 1)
                {
                    if (returnCode == ReturnCode.WriteTimeOrReSetDeviceOk)
                    {
                        if (_terminal.deviceContext.ResetToDefault)
                        {
                            _terminal.deviceContext.ResetToDefault = false;
                            ResetDeviceEvent.Set();
                            _terminal.syncDataBaseHelper.ResetDeviceOK(_terminal.deviceContext.SlaveSID);
                            _terminal.RefreshSyncStasus();
                            // if (_terminal.deviceContext.DeviceStatusEvent != null)
                            //    _terminal.deviceContext.DeviceStatusEvent();
                            AddResultMessage("Reset Device OK");
                            Thread.Sleep(2000);

                        }
                        else

                        {
                            if(haveSendOpenDoorCommand)
                                KCS.Common.Utils.PopHintDialog.ShowMessage("開門成功");
                            AddResultMessage("Write Device Time OK");
                        }
                    }
                    else if (returnCode == ReturnCode.RCV_FACE_PHOTO )
                    {//人脸回复
                        SyncUserTick = DateTime.Now.Ticks / 10000;
                        return;
                    }

                    else if (returnCode == ReturnCode.ReadSlaveOkException)
                    {
                        // Add: 2024/03/29      若KCS 執行 "Open Door" 之後，且relay順利啟動。 OR_Transaction 有收到 !SOFTOPEN!紀錄然後就開始持續收到 returnCode 0xF5 
                        //                      刚查了一下，如果数据通信错误或者设备收到未识别的指令 就好返回F5。这个回传11 应该没事，可能是粘包了 或者啥的
                        //                      这个应该是记录类型的问题 datasync 和 OR_Tans 不匹配 那kcs把这个错误屏蔽, 这个主要是调试用的
                    }
                    else
                    {
                        int ErrorResult = (int)response[0];
                        if (ErrorResult > 128)
                        {
                            ErrorResult = -1 * (256 - ErrorResult);
                        }
                        AddErrorMessage("Command Error - " + ErrorResult.ToString());
                    }
                }
                else
                {
                    //if (!ResetDeviceEvent.WaitOne(0))
                    //{//复位命令
                    //    return;
                    //}
                    switch (returnCode)
                    {
                       
                        case ReturnCode.ReadSalveOk:
                            AnalysReadDeviceResult(ref response, null);
                            //ReadEventTick = DateTime.Now.Ticks / 10000;
							ReadTransOkFlag = 1;
                            break;
                        case ReturnCode.ReadSalveOkByChar:
                            AnalysReadDeviceByCharResult(ref response, null);
                            //ReadEventTick = DateTime.Now.Ticks / 10000;
							ReadTransOkFlag = 1;
                            break;
                        case ReturnCode.WriteUserOk:
							if(response.Length == 2 && response[1] == 0x22)
                            {
                                ReadTimeOut = 1500;
                            }
                            else
                            AnalysSyncUsersResult(ref response, null);

                            break;
                        case ReturnCode.WriteUserFingerOk:
                            AnalysWriteUserFingerResult(ref response, null);
                            SyncAddFingerToDevice();
                            SyncAddFingerTick = DateTime.Now.Ticks / 10000;
                            break;
                        case ReturnCode.DeleteUserFingerOk:
                            AnalysDeleteUserFingerResult(ref response, null);
                            SyncDelFingerToDevice();
                            SyncDelFingerTick = DateTime.Now.Ticks / 10000;
                            break;
                        case ReturnCode.WriteTimeSetOk:
                            AnalysWriteTimeSetResult(ref response, null);
                            SyncTimeFrameToDevice();
                            SyncAcParaTick = DateTime.Now.Ticks / 10000;
                            break;
                        case ReturnCode.WriteTimeZoneOk:
                            AnalysWriteTimeZoneResult(ref response, null);
                            SyncTimeZoneToDevice();
                            SyncAcParaTick = DateTime.Now.Ticks / 10000;
                            break;
                        case ReturnCode.WriteUserGroupOk:
                            AnalysWriteUserGroupResult(ref response, null);
                            SyncUserGroupToDevice();
                            SyncAcParaTick = DateTime.Now.Ticks / 10000;
                            break;
                        case ReturnCode.WriteHolidayOk:
                            AnalysWriteHolidaySetResult(ref response, null);
                            SyncHolidaySetToDevice();
                            SyncAcParaTick = DateTime.Now.Ticks / 10000;
                            break;
                        case ReturnCode.WriteUserAuthorityOk:
                            AnalysWriteAcParaResult(ref response, null);
                            SyncUserAuthorityToDevice();
                            SyncUserAuthTick = DateTime.Now.Ticks / 10000;
                            break;
                        case  ReturnCode.ChangeCardIdOk:
                            AnalysChangeCardIDResult(ref response, null);
                            SyncChangeCardIdToDevice();
                            SyncAcParaTick = DateTime.Now.Ticks / 10000;
                            break;
                        case ReturnCode.WriteDeviceParaOk:
                            AnalysWriteDeviceParaResult(ref response, null);
                            break;
                        case ReturnCode.WriteDoorPINOk:
                            AnalysWriteDoorPinResult(ref response, null);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Exception  : Error - " + returnCode.ToString() + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }
        }
        #region Result
        public void AnalysWriteTimeSetResult(ref byte[] response, AsyncCallback callback = null)
        {
            if ((byte)0x20 == response[1])
            {
                int rcvDoorId, rcvFrameNo;
                rcvDoorId = response[2];
                rcvFrameNo = response[3];
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_TimeSet_SlaveSID(_terminal.deviceContext.SlaveSID, rcvDoorId, rcvFrameNo))
                {
                    //_terminal.RemoveFromListAcTimeSet(response[2], response[3]);
                    AddResultMessage("Write TimeSet OK");
                }
                else
                {
                    AddErrorMessage("Update TimeSet Failed ");
                }
            }
            else
            {
                AddErrorMessage("Write TimeSet Failed ");
            }
        }
        public void AnalysWriteTimeZoneResult(ref byte[] response, AsyncCallback callback = null)
        {
            if ((byte)0x20 == response[1])
            {
                int rcvDoorId, rcvTimeZone;
                rcvDoorId = response[2];
                rcvTimeZone = response[3];
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_TimeZone_SlaveSID(_terminal.deviceContext.SlaveSID, rcvDoorId, rcvTimeZone))
                {
                    //_terminal.RemoveFromListAcTimeZone(response[2], response[3]);
                    AddResultMessage("Write TimeZone OK");
                }
                else
                {
                    AddErrorMessage("Update TimeZone Failed ");
                }
            }
            else
            {
                AddErrorMessage("Write TimeZone Failed ");
            }
        }
        public void AnalysWriteUserGroupResult(ref byte[] response, AsyncCallback callback = null)
        {
            if ((byte)0x20 == response[1])
            {
                int rcvDoorId, rcvUserGroupNo;
                rcvDoorId = response[2];
                rcvUserGroupNo = response[3];
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_UserGroup_SlaveSID(_terminal.deviceContext.SlaveSID, rcvDoorId, rcvUserGroupNo))
                {
                    // _terminal.RemoveFromListAcUserGroupSet(response[2], response[3]);
                    AddResultMessage("Write User Group OK");
                }
                else
                {
                    AddErrorMessage("Update User Group Failed ");
                }
            }
            else
            {
                AddErrorMessage("Write User Group Failed ");
            }
        }
        public void AnalysWriteHolidaySetResult(ref byte[] response, AsyncCallback callback = null)
        {
            if ((byte)0x20 == response[1])
            {
                int rcvDoorId, rcvHolidayId;
                rcvDoorId = response[2];
                rcvHolidayId = response[3] * 256 + response[4];
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_Holiday_SlaveSID(_terminal.deviceContext.SlaveSID, rcvDoorId, rcvHolidayId))
                {
                    // _terminal.RemoveFromListAcHolidaySet(response[2], rcvHolidayId);
                    AddResultMessage("Write Holiday Set OK");
                }
                else
                {
                    AddErrorMessage("Update Holiday Failed ");
                }
            }
            else
            {
                AddErrorMessage("Write Holiday Failed ");
            }
        }
        public void AnalysWriteDeviceParaResult(ref byte[] response, AsyncCallback callback = null)
        {
            if (0 != response[1])
            {
                if (syncDevicePara.SyncMenuPwdFlag && !string.IsNullOrEmpty(_terminal.deviceContext.MenuPwd))
                    _terminal.SetCommunicationPin(Convert.ToInt32(_terminal.deviceContext.MenuPwd));
                AddResultMessage("Write device parameters OK");
                _terminal.syncDataBaseHelper.UPDATE_DevicePara(_terminal.deviceContext.SlaveSID);

            }
            else
            {
                AddErrorMessage("Write device parameters  " + "Failed");
            }
        }
        public void AnalysWriteDoorPinResult(ref byte[] response, AsyncCallback callback = null)
        {
            if (0 != response[1])
            {
                
                AddResultMessage("Write Door PIN OK");
                _terminal.SetDoorPINOk();

            }
            else
            {
                AddErrorMessage("Write Door PIN  " + "Failed");
            }
        }
        public void AnalysChangeCardIDResult(ref byte[] response, AsyncCallback callback = null)
        {
            byte[] intCardId = new byte[4];


            Array.Copy(response, 2, intCardId, 0, 4);
            UInt32 ChangeId = System.BitConverter.ToUInt32(intCardId, 0);

            if (0 != response[1])
            {
                AddResultMessage("Change Card Id OK");
                _terminal.syncDataBaseHelper.UPDATE_ChangeCardID(_terminal.deviceContext.SlaveSID, ChangeId);

            }
            else
            {
                AddErrorMessage("Change Card Id " + "Failed");
            }
        }
        public void AnalysWriteAcParaResult(ref byte[] response, AsyncCallback callback = null)
        {
            byte[] intCardId = new byte[4];
            Array.Copy(response, 2, intCardId, 0, 4);
            UInt32 CardId = System.BitConverter.ToUInt32(intCardId, 0);

            if ((byte)0x20 == response[1])
            {
                if (_terminal.syncDataBaseHelper.UPDATE_BFX_UserSlaveAllowTime(_terminal.deviceContext.SlaveSID, CardId.ToString().PadLeft(10, '0')))
                {
                    // _terminal.RemoveFromListAcAuthority(CardId);
                    AddResultMessage("Write Employee:" + CardId.ToString() + " Authority OK ");
                }
            }
            else
            {
                AddErrorMessage("Write Employee:" + CardId.ToString() + " Authority Failed ");
            }
        }
        public void AnalysWriteUserFingerResult(ref byte[] response, AsyncCallback callback = null)
        {
            byte[] intCardId = new byte[4];
            Array.Copy(response, 1, intCardId, 0, 4);
            UInt32 AddCardId = System.BitConverter.ToUInt32(intCardId, 0);
            Array.Copy(response, 5, intCardId, 0, 4);
            Int32 FingerNo = System.BitConverter.ToInt32(intCardId, 0);
            if (1 == response[9])
            {
                AddResultMessage("Write Employee:" + AddCardId.ToString().PadLeft(10, '0') + " Finger:" + FingerNo.ToString() + "OK");
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_FP_Add(AddCardId,FingerNo, _terminal.deviceContext.SlaveSID))
                {
                    // _terminal.RemoveUserFingerFromAddList(AddCardId);
                    _terminal.deviceContext.FingersReplicatedCounts++;
                    //_terminal.RefreshSyncStasus();
                    // if (_terminal.deviceContext.DeviceStatusEvent != null)
                    //   _terminal.deviceContext.DeviceStatusEvent();
                }
                //WriteUserFingerEvent.Set();
            }
            else
            {
                AddErrorMessage("Write Employee:" + AddCardId.ToString().PadLeft(10, '0') + " Finger:" + FingerNo.ToString() + "Failed");
            }

        }
        public void AnalysDeleteUserFingerResult(ref byte[] response, AsyncCallback callback = null)
        {
            byte[] intCardId = new byte[4];
            Array.Copy(response, 1, intCardId, 0, 4);
            UInt32 AddCardId = System.BitConverter.ToUInt32(intCardId, 0);
            Array.Copy(response, 5, intCardId, 0, 4);
            Int32 FingerNo = System.BitConverter.ToInt32(intCardId, 0);
            if (1 == response[9])
            {
                AddResultMessage("Delete Employee:" + AddCardId.ToString().PadLeft(10, '0') + " Finger:" + FingerNo.ToString() + "OK");
                _terminal.syncDataBaseHelper.UPDATE_DS_BF_FP_Delete(AddCardId, FingerNo, _terminal.deviceContext.SlaveSID);
                // _terminal.RemoveUserFingerFromDeleteList(AddCardId);


            }
            else
            {
                AddErrorMessage("Delete Employee:" + AddCardId.ToString().PadLeft(10, '0') + " Finger:" + FingerNo.ToString() + "Failed");
            }

        }
        public void AnalysSyncUsersResult(ref byte[] response, AsyncCallback callback = null)
        {
            byte bUpdateFlag = response[1];
            int rcvDataLen = 2;

            // AddResultMessage("Sync User:" + bUpdateFlag.ToString("X2"));
            if (bUpdateFlag > 0)
            {
                try
                {
                    byte[] intCardId = new byte[4];
                    if (0x1 == (bUpdateFlag & 0xf))
                    {//增加用户成功
                        Array.Copy(response, rcvDataLen, intCardId, 0, 4);
                        UInt32 AddCardId = System.BitConverter.ToUInt32(intCardId, 0);
                        if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_User_Add(AddCardId, _terminal.deviceContext.SlaveSID) || _terminal.syncDataBaseHelper.UPDATE_DS_BF_User_Add_CardId_Int(AddCardId, _terminal.deviceContext.SlaveSID))
                        {
                            _terminal.deviceContext.UserReplicatedCount++;
                            //_terminal.RemoveUserFromAddList(AddCardId);
                            _terminal.RefreshSyncStasus();

                            //if (_terminal.deviceContext.DeviceStatusEvent != null)
                            //  _terminal.deviceContext.DeviceStatusEvent();
                        }
                        rcvDataLen += 4;
                        AddResultMessage("Write Employee:" + AddCardId.ToString().PadLeft(10, '0') + " OK");

                    }
                    if (0x10 == (bUpdateFlag & 0xf0))
                    {
                        Array.Copy(response, rcvDataLen, intCardId, 0, 4);
                        UInt32 AddCardId = System.BitConverter.ToUInt32(intCardId, 0);
                        _terminal.syncDataBaseHelper.UPDATE_DS_BF_User_Delete(AddCardId, _terminal.deviceContext.SlaveSID);

                        //_terminal.RemoveUserFromDeleteList(AddCardId);
                        AddResultMessage("Delete Employee:" + AddCardId.ToString().PadLeft(10, '0') + " OK");
                    }
                    SyncUserToDevice();
                    SyncUserTick = DateTime.Now.Ticks / 10000;
                }
                catch (Exception ex)
                {
                    AddErrorMessage("AnalysSyncUsersResult  : Error - " + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
                }

            }
        }
        public void AnalysReadDeviceByCharResult(ref byte[] response, AsyncCallback callback = null)
        {
            int rcvDataLen = 1;
            int iTypePos = rcvDataLen;
            bool bHaveTransaction = false;
            bool bHaveFinger = false;
            byte[] CardId = new byte[15];
            byte[] TransactionTime = new byte[32];
            byte[] TransactionDevIp = new byte[15];
            rcvDataLen++;
            Transactions transaction = new Transactions(_terminal.deviceContext.IP_Internal, _terminal.deviceContext.IP, _terminal.deviceContext.SlaveSID, true);

            if (0x01 == (response[iTypePos] & 0x01))
            {
                transaction.TransactionType = response[rcvDataLen];
                rcvDataLen++;
                Array.Copy(response, rcvDataLen, CardId, 0, 15);
                rcvDataLen += 15;
                Array.Copy(response, rcvDataLen, TransactionTime, 0, 32);
                rcvDataLen += 32;
                Array.Copy(response, rcvDataLen, TransactionDevIp, 0, 15);
                rcvDataLen += 15;
                CardId[10] = 0;
                transaction.TransactionCardId = Encoding.UTF8.GetString(CardId);
                transaction.TransactionDateTime = Encoding.UTF8.GetString(TransactionTime);
                bHaveTransaction = true;
                //transaction.DeviceIP = Encoding.UTF8.GetString(TransactionDevIp);
            }
            if (0x08 == (response[iTypePos] & 0x08))
            {
                transaction.IsByTranType = false;
                transaction.TransactionType = response[rcvDataLen];
                rcvDataLen++;
                Array.Copy(response, rcvDataLen, CardId, 0, 15);
                rcvDataLen += 15;
                Array.Copy(response, rcvDataLen, TransactionTime, 0, 32);
                rcvDataLen += 32;
                Array.Copy(response, rcvDataLen, TransactionDevIp, 0, 15);
                rcvDataLen += 15;
                transaction.DataType = response[rcvDataLen];
                rcvDataLen++;
                CardId[10] = 0;
                transaction.TransactionCardId = Encoding.UTF8.GetString(CardId);
                transaction.TransactionDateTime = Encoding.UTF8.GetString(TransactionTime);
                bHaveTransaction = true;
                //transaction.DeviceIP = Encoding.UTF8.GetString(TransactionDevIp);
            }

           

            if (bHaveTransaction)
            {
				ReadTimeOut = 8000;
                //bool bRet = _terminal.syncDataBaseHelper.InsertToOR_Transactions(transaction);

                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                // Add: 2024/08/09
                // Ver: 1.1.5.24
                try
                {
                    Log.Information($"SyncClient,AnalysReadDeviceByCharResult,{transaction.TransactionCardId},{transaction.TransactionDateTime},{transaction.DeviceIP},{transaction.DevicePublicIP},{transaction.BodyTemp.ToString()}");
                }
                catch (Exception ex)
                {
                    Log.Error($"SyncClient,AnalysReadDeviceByCharResult,{ex.Message}");
                }
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                int iRet = _terminal.syncDataBaseHelper.InsertToOR_TransactionsWithTransId(transaction, 0);
                Employees employee = _terminal.syncDataBaseHelper.GetEmployeeByCardId(transaction.TransactionCardId);
                if ((object)employee != null)
                {
                    transaction.UserId = employee.UserID;
                    transaction.UserName = employee.UserName;
                }
                transaction.DeviceName = _terminal.deviceContext.SlaveName;
                AddResultMessage("Read Transaction OK");
                if (iRet > 0)
                {

                    if (iRet == 2)
                    {
                        WriteDuplicteTransaction(transaction);
                    }
                    //else
                    {
                        UpdateReadTransList(transaction);
                    }
                    SendViaTcpAsSync(_terminal.CreateDleteTransactioMessage());


                }
                else
                {
                    AddErrorMessage("Save Data to database error!");
                }
            }
            else
            {
                AddResultMessage("No Transactions");
            }
            if (0x02 == (response[iTypePos] & 0x02))
            {
                rcvDataLen += 132;
            }
            if (0x04 == (response[iTypePos] & 0x04))
            {
                UInt32 FingerCardId;
                int FingerNo;
                int FingerDataLen;
                byte[] tempIntBuf = new byte[4];
               

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                rcvDataLen += 4;
                FingerCardId = System.BitConverter.ToUInt32(tempIntBuf, 0);

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                rcvDataLen += 4;
                FingerNo = System.BitConverter.ToInt32(tempIntBuf, 0);

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                rcvDataLen += 4;
                FingerDataLen = System.BitConverter.ToInt32(tempIntBuf, 0);
                byte[] FingerDataBuf = new byte[FingerDataLen];
                if (FingerDataLen > FingerDataBuf.Length)
                {
                    AddErrorMessage("Invalid finger data len!");
                    return;
                }
                Array.Copy(response, rcvDataLen, FingerDataBuf, 0, FingerDataLen);
                if (_terminal.syncDataBaseHelper.InsertUserFingerData(_terminal.deviceContext.SlaveSID, FingerCardId.ToString().PadLeft(10, '0'), FingerNo, FingerDataBuf))
                {
                    AddResultMessage("Get Registered finger CardID:" + FingerCardId.ToString() + " Finger No:" + FingerNo.ToString() + " OK");

                    if (_terminal.deviceContext.DeviceGetFingerEvent != null)
                        _terminal.deviceContext.DeviceGetFingerEvent();
                    SendViaTcpAsSync(_terminal.CreateDeleteReadFingerMessage(FingerCardId, FingerNo));
                }
                else
                {
                    AddErrorMessage("Get Registered finger CardID:" + FingerCardId.ToString() + " Finger No:" + FingerNo.ToString() + " Failed");
                }

            }
            if (bHaveFinger || bHaveTransaction)
            {
                Thread.Sleep(200);
                SendViaTcpAsSync(_terminal.CreateReadDeviceMessage());
            }
        }
        public void AnalysReadDeviceResult(ref byte[] response, AsyncCallback callback = null)
        {
            int rcvDataLen = 1;
            int iTypePos = rcvDataLen;
            bool bHaveTransaction = false;
            bool bHaveFinger = false;
            byte[] CardId = new byte[11];
            byte[] TransactionTime = new byte[32];
            byte[] TransactionDevIp = new byte[15];
            byte[] DelTransId = new byte[4];
            int deleteTransType = 0;
            rcvDataLen++;
            Transactions transaction = new Transactions(_terminal.deviceContext.IP_Internal, _terminal.deviceContext.IP, _terminal.deviceContext.SlaveSID, true);

            if (0x01 == (response[iTypePos] & 0x01))
            {
                transaction.TransactionType = response[rcvDataLen];
                rcvDataLen++;
                Array.Copy(response, rcvDataLen, CardId, 0, 11);
                rcvDataLen += 11;
                Array.Copy(response, rcvDataLen, TransactionTime, 0, 32);
                rcvDataLen += 32;
                Array.Copy(response, rcvDataLen, TransactionDevIp, 0, 15);
                rcvDataLen += 15;

                CardId[10] = 0;
                transaction.TransactionCardId = Encoding.UTF8.GetString(CardId);
                transaction.TransactionDateTime = Encoding.UTF8.GetString(TransactionTime);
                bHaveTransaction = true;
                //transaction.DeviceIP = Encoding.UTF8.GetString(TransactionDevIp);
            }
            if (0x08 == (response[iTypePos] & 0x08))
            {
                transaction.IsByTranType = false;
                transaction.TransactionType = response[rcvDataLen];
                rcvDataLen++;
                Array.Copy(response, rcvDataLen, CardId, 0, 11);
                rcvDataLen += 11;
                Array.Copy(response, rcvDataLen, TransactionTime, 0, 32);
                rcvDataLen += 32;
                Array.Copy(response, rcvDataLen, TransactionDevIp, 0, 15);
                rcvDataLen += 15;
                transaction.DataType = response[rcvDataLen];
                rcvDataLen++;
                Array.Copy(response, rcvDataLen, DelTransId, 0, 4);
				rcvDataLen += 4;
                deleteTransType = 1;
                CardId[10] = 0;
                transaction.TransactionCardId = Encoding.UTF8.GetString(CardId);
                transaction.TransactionDateTime = Encoding.UTF8.GetString(TransactionTime);
                bHaveTransaction = true;
                //transaction.DeviceIP = Encoding.UTF8.GetString(TransactionDevIp);
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Add:     2022/05/10
            // By:      YG協助
            if (0x40 == (response[iTypePos] & 0x40))
            {
                byte[] tempBodyIntBuf = new byte[4];
                Array.Copy(response, rcvDataLen, tempBodyIntBuf, 0, 4);
                float fBodyTemp = System.BitConverter.ToInt32(tempBodyIntBuf, 0);
                fBodyTemp = fBodyTemp / 10;
                transaction.BodyTemp = fBodyTemp;
                rcvDataLen += 4;
            }
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            if (bHaveTransaction)
            {
				ReadTimeOut = 8000;
                //bool bRet = _terminal.syncDataBaseHelper.InsertToOR_Transactions(transaction);
                int iRet = _terminal.syncDataBaseHelper.InsertToOR_TransactionsWithTransId(transaction, 0);

                // Add: 2024/08/09
                // Ver: 1.1.5.24
                try
                {
                    Log.Information($"SyncClient,AnalysReadDeviceResult,{transaction.TransactionCardId},{transaction.TransactionDateTime},{transaction.DeviceIP},{transaction.DevicePublicIP},{transaction.BodyTemp.ToString()}");
                }
                catch  (Exception ex)
                {
                    Log.Error($"SyncClient,AnalysReadDeviceResult,{ex.Message}");
                }


                Employees employee = _terminal.syncDataBaseHelper.GetEmployeeByCardId(transaction.TransactionCardId);
                if ((object)employee != null)
                {
                    transaction.UserId = employee.UserID;
                    transaction.UserName = employee.UserName;
                }
                transaction.DeviceName = _terminal.deviceContext.SlaveName;
                
                if (iRet > 0)
                {

                    if (iRet == 2)
                    {
                        WriteDuplicteTransaction(transaction);
                    }
                    //else
                    {
                        UpdateReadTransList(transaction);
                    }
                    
                    if(deleteTransType == 1)
					{
						AddResultMessage("Read Transaction OK NEW");
						SendViaTcpAsSync(_terminal.CreateDleteTransactioWithIdMessage(DelTransId));
					}
                    else
					{
						AddResultMessage("Read Transaction OK");
                        SendViaTcpAsSync(_terminal.CreateDleteTransactioMessage());
					}


                }
                else
                {
                    AddErrorMessage("Save Data to database error!");
                }
            }
            else
            {
                AddResultMessage("No Transactions");
            }
            if (0x02 == (response[iTypePos] & 0x02))
            {
                rcvDataLen += 132;
            }
            if (0x04 == (response[iTypePos] & 0x04))
            {
                UInt32 FingerCardId;
                int FingerNo;
                int FingerDataLen;
                byte[] tempIntBuf = new byte[4];
               

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                rcvDataLen += 4;
                FingerCardId = System.BitConverter.ToUInt32(tempIntBuf, 0);

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                rcvDataLen += 4;
                FingerNo = System.BitConverter.ToInt32(tempIntBuf, 0);

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                rcvDataLen += 4;
                FingerDataLen = System.BitConverter.ToInt32(tempIntBuf, 0);
                byte[] FingerDataBuf = new byte[FingerDataLen];
                if (FingerDataLen > FingerDataBuf.Length)
                {
                    AddErrorMessage("Invalid finger data len!");
                    return;
                }
                Array.Copy(response, rcvDataLen, FingerDataBuf, 0, FingerDataLen);
                if (_terminal.syncDataBaseHelper.InsertUserFingerData(_terminal.deviceContext.SlaveSID, FingerCardId.ToString().PadLeft(10, '0'), FingerNo, FingerDataBuf))
                {
                    AddResultMessage("Get Registered finger CardID:" + FingerCardId.ToString() + " Finger No:" + FingerNo.ToString() + " OK");

                    if (_terminal.deviceContext.DeviceGetFingerEvent != null)
                        _terminal.deviceContext.DeviceGetFingerEvent();
                    SendViaTcpAsSync(_terminal.CreateDeleteReadFingerMessage(FingerCardId, FingerNo));
                }
                else
                {
                    AddErrorMessage("Get Registered finger CardID:" + FingerCardId.ToString() + " Finger No:" + FingerNo.ToString() + " Failed");
                }
                rcvDataLen += FingerDataLen;

            }
            if (0x20 == (response[iTypePos] & 0x20))
            {
                var _log = new ApplicationLogEntity() {
                    ClassID = m_ClassID, ProcedureID = "AnalysReadDeviceResult"
                    , ProcedureDetail = $"SlaveSID={_terminal.deviceContext.SlaveSID};TransactionCardId={transaction.TransactionCardId};response.Length={response.Length};rcvDataLen={rcvDataLen}" 
                    };
                m_ApplicationLogService.WriteLog(_log);


                byte[] photoBuf = new byte[response.Length - rcvDataLen];
                Array.Copy(response, rcvDataLen, photoBuf, 0, response.Length - rcvDataLen);
                _terminal.syncDataBaseHelper.InsertUserRecordPhoto(_terminal.deviceContext.SlaveSID, transaction.TransactionCardId, transaction.TransactionDateTime, photoBuf);
            }
            if (bHaveFinger || bHaveTransaction)
            {
                Thread.Sleep(200);
                SendViaTcpAsSync(_terminal.CreateReadDeviceMessage());
            }
            //transactionHandleEvent.BeginInvoke(transaction, callback, transactionHandleEvent);
        }
        #endregion
        private bool ConnectWithTerminal()
        {
            bool isConnected = false;
            bool isErrorOccurd = false;
            try
            {
                if (_terminal.Client == null || !_terminal.Client.IsConnected)
                {
                    if (_terminal.Client == null)
                    {
                        _terminal.Client = new NetSockets.NetClient();
                        _terminal.Client.OnConnected += Client_OnConnected;
                        _terminal.Client.OnDisconnected += Client_OnDisconnected;
                        _terminal.Client.OnReceived += Client_OnReceived;
                    }

                    isConnected = _terminal.Client.TryConnect(_terminal.deviceContext.IP, _terminal.TerminalPort);

                    SyncEvent.Set();
                    CommandToken = 0;

                    //if (isConnected)
                    {
                        if (_terminal.deviceContext.DeviceStatusEvent != null)
                            _terminal.deviceContext.DeviceStatusEvent();
                    }
                    _terminal.UpdateDeviceStatus(isConnected);
                }
                else
                {
                    isConnected = _terminal.Client.IsConnected;

                }

                return isConnected;
            }
            catch (Exception ex)
            {
                if (_terminal.deviceContext.DeviceStatusEvent != null)
                    _terminal.deviceContext.DeviceStatusEvent();

                _terminal.UpdateDeviceStatus(false);
                //    brokerCurrentStateSenderToService.BeginInvoke(U.OpType, -1, U.ModelGuid, "Terminal Bağlantı Hatası", f => brokerCurrentStateSenderToService.EndInvoke(f), null);
                AddErrorMessage("Can't connect with device Exception  : Error - " + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);

                isErrorOccurd = true;
            }
            return false;
        }

        public static bool IsRealImage(string path)
        {
            try
            {
                Image img = Image.FromFile(path);
                //Console.WriteLine("\nIt is a real image");
                return true;
            }
            catch (Exception e)
            {
                //Console.WriteLine("\nIt is a fate image");
                return false;
            }
        }

        private bool SyncUserToDevice()
        {
            UserInfoAdd userAdd = null;
            UserInfoDel userDelete = null;
            try
            {
                if (_terminal.ListUserInfoAdd.Count > 0)
                {
                    userAdd = _terminal.ListUserInfoAdd[0];
                    _terminal.ListUserInfoAdd.RemoveAt(0);

                }
                if (_terminal.ListUserInfoDelete.Count > 0)
                {
                    userDelete = _terminal.ListUserInfoDelete[0];
                    _terminal.ListUserInfoDelete.RemoveAt(0);

                }
                if ((object)userAdd != null || (object)userDelete != null)
                {
                    string strTraceMessage = "";
                    if ((object)userAdd != null)
                    {
                        strTraceMessage += "Write Employe:" + userAdd.CardID.PadLeft(10, '0');
                    }
                    if ((object)userDelete != null)
                    {
                        strTraceMessage += " Delete Employe:" + userDelete.CardID.PadLeft(10, '0');
                    }
                    AddWorkMessage(strTraceMessage);
                   
                    if (_terminal.deviceContext.DeviceType.Equals("Face"))
                    {
                       
                        if ((object)userAdd != null)
                        {
                            string strRegPhoto = userAdd.RegPhoto;
                            if(String.IsNullOrEmpty(strRegPhoto))
                            {
                                strRegPhoto = string.Format("{0}\\Staff photos\\{1}.jpg", System.Windows.Forms.Application.StartupPath, userAdd.UserID);
                                AddWorkMessage("Read employee photo at " + strRegPhoto);
                            }


                            bool isRealImage = IsRealImage(strRegPhoto);
                            if (isRealImage)
                            {
                                SendViaTcpAsSync(_terminal.CreateEnrollUserWithFaceMessage(userAdd, strRegPhoto));
                                //Thread.Sleep(3000);
                            }


                        }
                        if ((object)userDelete != null)
                        {
                            SendViaTcpAsSync(_terminal.CreateDeleteUserWithFaceMessage(CommandMode.TcpClient,userDelete));
                           
                        }
                    }
                        
                    else
                        SendViaTcpAsSync(_terminal.CreateSyncUserMessage(CommandMode.TcpClient, userAdd, userDelete));

                    
                }
                return true;
                //else
                //{
                //    AddWorkMessage("No data need to sync");
                //}
            }
            catch (Exception ex)
            {


                AddErrorMessage("Sync user to device Exception:" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);


            }

            return false;
        }
        private bool SyncAddFingerToDevice()
        {
            UserFingerAdd userFingerAdd = null;
            try
            {
                if (_terminal.ListUserFingersAdd.Count > 0)
                {
                    userFingerAdd = _terminal.ListUserFingersAdd[0];
                    _terminal.ListUserFingersAdd.RemoveAt(0);

                }
                if ((object)userFingerAdd != null)
                {
                    AddWorkMessage("Wrtie Employees " + userFingerAdd.CardID + " Finger:" + userFingerAdd.FPNo.ToString() + "To device");
                    SendViaTcpAsSync(_terminal.CreateAddUserFingerMessage(CommandMode.TcpClient, userFingerAdd));
                    return true;
                }
            }
            catch (Exception ex)
            {


                AddErrorMessage("Write finger to device Exception: " + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);


            }

            return false;
        }
        private bool SyncDelFingerToDevice()
        {
            UserFingerDel userFingerDelete = null;
            try
            {
                if (_terminal.ListUserFingersDelete.Count > 0)
                {
                    userFingerDelete = _terminal.ListUserFingersDelete[0];
                    _terminal.ListUserFingersDelete.RemoveAt(0);

                }
                if ((object)userFingerDelete != null)
                {
                    AddWorkMessage("Delete Employees " + userFingerDelete.CardID + " Finger:" + userFingerDelete.FPNo.ToString() + "from device");
                    SendViaTcpAsSync(_terminal.CreateDeleteUserFingerMessage(CommandMode.TcpClient, userFingerDelete));
                    return true;
                }
            }
            catch (Exception ex)
            {


                AddErrorMessage("Delete finger to device Exception:" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);


            }
            return false;
        }
        private void SyncParaToDevice(SyncParameter syncDev)
        {
            try
            {
                AddWorkMessage("Sync parameters to Device" );
                SendViaTcpAsSync(_terminal.CreateSyncDeviceParaMessage(CommandMode.TcpClient, syncDev));
            }
            catch (Exception ex)
            {
                AddErrorMessage("Sync parameters to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }
        }
        private bool SyncTimeFrameToDevice()
        {
            try
            {
                AcTimeSet acTimeSet = null;
                if (_terminal.ListAcTimeSet.Count > 0)
                {
                    acTimeSet = _terminal.ListAcTimeSet[0];
                    _terminal.ListAcTimeSet.RemoveAt(0);
                    AddWorkMessage("Sync Time set with Id:" + acTimeSet.TimeSetID.ToString());
                    SendViaTcpAsSync(_terminal.CreateSyncTimeSetMessage(CommandMode.TcpClient, acTimeSet));
                    return true;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write Time Set to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }

            return false;
        }
        private bool SyncTimeZoneToDevice()
        {
            try
            {
                AcTimeZone acTimeZone = null;
                if (_terminal.ListAcTimeZone.Count > 0)
                {
                    acTimeZone = _terminal.ListAcTimeZone[0];
                    _terminal.ListAcTimeZone.RemoveAt(0);
                    AddWorkMessage("Sync Time Zone with Id:" + acTimeZone.TimeZoneID.ToString());
                    SendViaTcpAsSync(_terminal.CreateSyncTimeZoneMessage(CommandMode.TcpClient, acTimeZone));
                    return true;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write Time Zone to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }
            return false;
        }
        private bool SyncUserGroupToDevice()
        {
            try
            {
                AcUserGroupSet acUserGroupSet = null;
                if (_terminal.ListAcUserGroupSet.Count > 0)
                {
                    acUserGroupSet = _terminal.ListAcUserGroupSet[0];
                    _terminal.ListAcUserGroupSet.RemoveAt(0);
                    AddWorkMessage("Sync User Group with Id:" + acUserGroupSet.GroupID.ToString());
                    SendViaTcpAsSync(_terminal.CreateSyncUserGroupMessage(CommandMode.TcpClient, acUserGroupSet));
                    return true;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write User Group to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }

            return false;
        }
        private bool SyncHolidaySetToDevice()
        {
            try
            {
                AcHolidaySet acHolidaySet = null;
                if (_terminal.ListAcHolidaySet.Count > 0)
                {
                    acHolidaySet = _terminal.ListAcHolidaySet[0];
                    _terminal.ListAcHolidaySet.RemoveAt(0);
                    AddWorkMessage("Sync Holidy set with Id:" + acHolidaySet.DoorHoliID.ToString());
                    SendViaTcpAsSync(_terminal.CreateSyncHolidaySetMessage(CommandMode.TcpClient, acHolidaySet));
                    return true;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write Holidy set to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }

            return false;

        }
        private bool SyncChangeCardIdToDevice()
        {
            try
            {
                ChangeCardIDCls changeCardIDCls = null;
                if (_terminal.ListChangeCardID.Count > 0)
                {
                    changeCardIDCls = _terminal.ListChangeCardID[0];
                    _terminal.ListChangeCardID.RemoveAt(0);
                    AddWorkMessage("Sync Change Id " + changeCardIDCls.OldCardID + "To " + changeCardIDCls.NewCardID);
                    SendViaTcpAsSync(_terminal.CreateSyncChangeCardIdMessage(CommandMode.TcpClient, changeCardIDCls));
                    return true;
                }

            }
            catch (Exception ex)
            {
                AddErrorMessage("Sync change card id to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }

            return false;
        }
        private bool SyncUserAuthorityToDevice()
        {
            AcAuthority userAcAuthority = null;
            try
            {
                if (_terminal.ListAcAuthority.Count > 0)
                {
                    CommandToken = 0;
                    userAcAuthority = _terminal.ListAcAuthority[0];
                    _terminal.ListAcAuthority.RemoveAt(0);
                    AddWorkMessage("Write Employees " + userAcAuthority.CardID + " Authority " + "to device");
                    SendViaTcpAsSync(_terminal.CreateSyncUserAuthorityMessage(CommandMode.TcpClient, userAcAuthority));
                    return true;

                }

            }
            catch (Exception ex)
            {


                AddErrorMessage("Delete finger to device Exception:" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);


            }
            return false;
        }
        private bool SyncDataToDevice()
        {
            //lock (SyncDataLocker)
            {
                long currentTick = DateTime.Now.Ticks / 10000;

                int tryTimes = 0;
                
            NEXT_GAIN1:
                if (_terminal.OpenDoorFlag)
                {//开门
                    if (SendViaTcpAsSync(_terminal.CreateOpenDoorMessage(CommandMode.TcpClient)))
                    {
                        haveSendOpenDoorCommand = true;
                        Thread.Sleep(300);
                        _terminal.ClearOpenDoor();
                        haveSendOpenDoorCommand = false;
                    }
                    else
                    {
                        KCS.Common.Utils.PopHintDialog.ShowMessage("开门失败");
                    }
                }
                if (_terminal.reReadTransSet.ReReadFlag)
                {
                    if (SendViaTcpAsSync(_terminal.CreateReadTransAgainMessage(CommandMode.TcpClient, _terminal.reReadTransSet.dateStart, _terminal.reReadTransSet.dateEnd, _terminal.reReadTransSet.timeStart, _terminal.reReadTransSet.timeEnd)))
                        _terminal.ClearReReadFlag();
                }
                //设置开门密码
                if (_terminal.doorPinContext != null)
                {
                    SendViaTcpAsSync(_terminal.CreateSetDoorPinMessage(CommandMode.TcpClient, _terminal.doorPinContext));
                    AddWorkMessage("Write Device Door PIN");
                    Thread.Sleep(500);
                    return true;
                }
                //设置设备参数
                
                syncDevicePara = _terminal.GetSyncDevicePara();
                if (syncDevicePara.SyncLanguageFlag  || syncDevicePara.SyncMenuPwdFlag  || syncDevicePara.SyncWorkModeFlag )
                {
                    SyncParaToDevice(syncDevicePara);
                   
                    Thread.Sleep(300);
                }
                if (currentTick - SyncAcParaTick >= SyncTimeOut)
                {
                    SyncAcParaTick = currentTick;
                    //同步时间段
                    if (SyncTimeFrameToDevice())
                        return true;
                    //同步时间区
                    if (SyncTimeZoneToDevice())
                        return true;
                    //同步Group
                    if (SyncUserGroupToDevice())
                        return true;
                    //同步Holiday设置
                    if (SyncHolidaySetToDevice())
                        return true;
                    //同步Change Card Id
                    if (SyncChangeCardIdToDevice())
                        return true;
                }

                if (currentTick - WriteTimeTick >= WriteTimeFrequency)
                {
                    WriteTimeTick = currentTick;
                    AddWorkMessage("Write Device time");
                    SendViaTcpAsSync(_terminal.CreateWriteTimeMessage(CommandMode.TcpClient));
                    Thread.Sleep(100);
                   // SendViaTcpAsSync(_terminal.CreateWriteTimeMessageOld(CommandMode.TcpClient));
                    return true;
                }


                if (currentTick - ReadEventTick >= ReadTimeOut || ReadTransOkFlag == 1)//8s
                {
                    AddWorkMessage("Read Transations");
                    ReadEventTick = currentTick;
					ReadTransOkFlag = 0;
					

                    SendViaTcpAsSync(_terminal.CreateReadDeviceMessage());
                    return true;
                }


                if (CommandToken == 0)
                {

                    CommandToken = 1;
                    int tick_cout = SyncTimeOut;
                    if (_terminal.deviceContext.DeviceType.Equals("Face"))
                        tick_cout = SyncFaceUserTimeOut;
                    if (currentTick - SyncUserTick >= tick_cout)
                    {

                        if (SyncUserToDevice())
                        {
                            SyncUserTick = currentTick;
                            return true;
                        }
                    }

                }
                if (CommandToken == 1)
                {
                    CommandToken = 2;
                    if (currentTick - SyncDelFingerTick >= SyncTimeOut)
                    {
                        if (!_terminal.deviceContext.DeviceType.Equals("Face"))
                        {
                            if (SyncDelFingerToDevice())
                            {
                                SyncDelFingerTick = currentTick;
                                return true;
                            }
                        }
                            
                    }

                }
                if (CommandToken == 2)
                {
                    CommandToken = 3;
                    if (currentTick - SyncAddFingerTick >= SyncFingerTimeOut)
                    {
                        if (!_terminal.deviceContext.DeviceType.Equals("Face"))
                        {
                            if (SyncAddFingerToDevice())
                            {
                                SyncAddFingerTick = currentTick;
                                return true;
                            }
                        }
                            
                    }

                }
                if (CommandToken == 3)
                {

                    CommandToken = 4;
                    if (currentTick - SyncUserAuthTick >= SyncTimeOut)
                    {

                        if (SyncUserAuthorityToDevice())
                        {
                            SyncUserAuthTick = currentTick;
                            CommandToken = 0;
                            return true;
                        }
                    }
                }
                tryTimes++;
                if (tryTimes >= 2)
                //if (CommandToken >= 4)
                {
                    CommandToken = 0;
                }
                else
                {
                    goto NEXT_GAIN1;
                }
                return false;
            }

        }
        private void CreateRequestAndSendTerminal()
        {

            if (ConnectWithTerminal())
            {
                if (_terminal.deviceContext.RebootDeviceFlag)
                {
                    _terminal.deviceContext.RebootDeviceFlag = false;//
                    AddWorkMessage("Reboot device ...");
                    SendViaTcpAsSync(_terminal.RebootDeviceMessage(CommandMode.TcpClient));
                    return;
                }

                if (_terminal.deviceContext.ResetToDefault)
                {//初始化终端                   
                    
                    if (ResetDeviceEvent.WaitOne(0))
                    {
                        AddWorkMessage("Reaset Device,Please Wait ...");
                        SendViaTcpAsSync(_terminal.ResetDeviceMessage(CommandMode.TcpClient));
                        ResetDeviceEvent.Reset();
                        WaitResetOkCount = 0;
                        //ResetDeviceEvent.WaitOne(1000);
                        return;
                    }
                    else
                    {
                        SendViaTcpAsSync(_terminal.CreateWriteTimeMessage(CommandMode.TcpClient));
                        Thread.Sleep(100);
                        SendViaTcpAsSync(_terminal.CreateWriteTimeMessageOld(CommandMode.TcpClient));
                        Thread.Sleep(1000);

                        WaitResetOkCount++;
                        if (WaitResetOkCount >= 15)
                        {
                            WaitResetOkCount = 0;
                            ResetDeviceEvent.Set();
                        }
                    }
                }
                if (SyncEvent.WaitOne(1500))
                {
                    NoReponseCount = 0;
                    SyncDataToDevice();
                }
                else
                {
                    //; SyncEvent.Reset();
                    NoReponseCount++;
                    if (NoReponseCount >= 2)
                    {
                        NoReponseCount = 0;
                        SyncDataToDevice();
                    }
                }


            }
        }
        private bool SendViaTcpAsSync(byte[] message)
        {



            bool result = true;

            try
            {
                
                if (_terminal.Client.IsConnected)
                {
                    _terminal.UpdateDeviceStatus(true);
                    SyncEvent.Reset();
                    _terminal.Client.Send(message);

                }
                else
                {
                    _terminal.UpdateDeviceStatus(false);
                    AddErrorMessage("Disconnect with device");
                }
            }
            catch (Exception ex)
            {
                //_______________ ON ANY EXCEPTION 


                AddErrorMessage("Cannot send resquest to connected Terminal Server : " + ex.Message);
                result = false;
            }

            return result;
        }
        protected void SyncDeviceThread()
        {
            try
            {
                while (!this.cts.Token.IsCancellationRequested)
                {
                    try
                    {

                        if (this._terminal.deviceContext.IsEnabled)
                            onAsyncCallback3.Invoke();
                        Thread.Sleep(50);
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
                AddErrorMessage("Exist SyncClientRun...");
            }
            catch (Exception ex)
            {
                Program.WriteLog(ex.Message + "-------SyncClientRun");
            } // suppress any exceptions

            threadSyscToDevice = null;
        }
        public void SyncClientRun()
        {
            if (threadSyscToDevice != null)
                threadSyscToDevice.Abort();
            threadSyscToDevice = new Thread(new ThreadStart(SyncDeviceThread));
            threadSyscToDevice.Start();

            //ThreadPool.QueueUserWorkItem((o) =>
            //{
            //    try
            //    {
            //        while (!this.cts.Token.IsCancellationRequested)
            //        {
            //          if(this._terminal.deviceContext.IsEnabled )
            //              onAsyncCallback3.Invoke();
            //            Thread.Sleep(50);
            //        }
            //    }
            //    catch (Exception ex) {
            //        Program.WriteLog("Sync Thread Exception : " + ex.Message);
            //    } // suppress any exceptions
            //});
        }
        private void AsyncCreateRequestAndSendTerminal()
        {

            Task.Run(() =>
            {
                onAsyncCallback3.Invoke();
            });
        }
        public void Dispose()
        {
            cts.Cancel();
        }
    }
}
