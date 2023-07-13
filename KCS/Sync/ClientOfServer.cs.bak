using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KCS.Models;
using NetSockets;

namespace KCS.Sync
{
    public class ClientOfServer : BridgeUtility,IDisposable
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Terminal _terminal = null;
        private NetBaseStream<byte []> _stream = null;
        private delegate void OnAsyncCallback3();
        private OnAsyncCallback3 onAsyncCallback3 = null;
        private ManualResetEvent ResetDeviceEvent = new ManualResetEvent(false);
        private int DistributeFlag;
        private ManualResetEvent SyncEvent = new ManualResetEvent(true);
        private ManualResetEvent GetDataEvent = new ManualResetEvent(false);
        private int NotGetDataTickCount = 0;

        public Terminal terminal { 
            get
            {
                return _terminal;
             }
        }
        public ClientOfServer(Terminal terminal, NetBaseStream<byte[]> stream)
        {
            DistributeFlag = 0;
            _terminal = terminal;
            _stream = stream;
            onAsyncCallback3 = new OnAsyncCallback3(CreateRequestAndSendTerminal);
            AddWorkMessage("Connect in");
            SyncClientRun();
        }
        public void ClentsDataReceived(byte[] rcvData)
        {
            RequestCommand receive_type = (RequestCommand)rcvData[4];
            
            switch (receive_type)
            {
                case RequestCommand.RequestTime:
                    AddWorkMessage("Write Device time");
                    _stream.Send(_terminal.CreateWriteTimeMessage(CommandMode.TcpServer));
                    //Thread.Sleep(500);
                    break;
                case RequestCommand.ResetDeviceReturn:
                    if (rcvData[9] == 1)
                    {
                        _terminal.deviceContext.ResetToDefault = false;
                        ResetDeviceEvent.Set();
                        _terminal.syncDataBaseHelper.ResetDeviceOK(_terminal.deviceContext.SlaveSID);
                        _terminal.RefreshSyncStasus();
                        if (_terminal.deviceContext.DeviceStatusEvent != null)
                            _terminal.deviceContext.DeviceStatusEvent();
                        AddResultMessage("Reset Device OK");
                    }
                    else
                    {
                        AddResultMessage("Reset Device Failed");
                    }
                    break;
                case RequestCommand.RequestData:
                    _stream.Send(_terminal.DeleteReplicatedTransAndFingerMessage(0, 0, 0));
                    //CreateRequestAndSendTerminal();                   
                    break;
                case  RequestCommand.WriteTimeSetReturn:
                    AnalysWriteTimeSetResult(ref rcvData);
                    //CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteTimeZoneReturn:
                    AnalysWriteTimeZoneResult(ref rcvData);
                   // CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteUserGroupReturn:
                    AnalysWriteUserGroupResult(ref rcvData);
                    //CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteHolidaySetReturn:
                    AnalysWriteHolidaySetResult(ref rcvData);
                    //CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteAcParaReturn:
                    AnalysWriteAcParaResult(ref rcvData);
                   // CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteUserInfoReturn:
                    AnalysSyncUsersResult(ref rcvData);
                   // CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.EnrollFingerReturn:
                    AnalysWriteUserFingerResult(ref rcvData);
                    //CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.DeleteFingerReturn:
                    AnalysDeleteUserFingerResult(ref rcvData);
                   // CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.PushDeviceData:
                    AnalysReadDeviceResult(ref rcvData);
                    //Thread.Sleep(500);
                    break;
                default:
                    //CreateRequestAndSendTerminal();
                    break;
            }
            SyncEvent.Set();
        }
        private void CreateRequestAndSendTerminal()
        {
            
            if (_terminal.deviceContext.ResetToDefault)
            {//初始化终端                   

                AddWorkMessage("Reaset Device,Please Wait ...");
                _stream.Send(_terminal.ResetDeviceMessage(CommandMode.TcpServer));
                ResetDeviceEvent.Reset();
                ResetDeviceEvent.WaitOne(10000);
                return;
            }
            SyncEvent.WaitOne(2000);
            SyncEvent.Reset();
            //同步时间段
            try
            {
                AcTimeSet acTimeSet = null;
                if (_terminal.ListAcTimeSet.Count > 0)
                {
                    acTimeSet = _terminal.ListAcTimeSet[0];
                    AddWorkMessage("Sync Time set with Id:" + acTimeSet.TimeSetID.ToString());
                    _stream.Send(_terminal.CreateSyncTimeSetMessage(CommandMode.TcpServer, acTimeSet));
                    return;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write Time Set to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }
            //同步时间区
            try
            {
                AcTimeZone acTimeZone = null;
                if (_terminal.ListAcTimeZone.Count > 0)
                {
                    acTimeZone = _terminal.ListAcTimeZone[0];
                    AddWorkMessage("Sync Time Zone with Id:" + acTimeZone.TimeZoneID.ToString());
                    _stream.Send(_terminal.CreateSyncTimeZoneMessage(CommandMode.TcpServer, acTimeZone));
                    return;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write Time Zone to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }
            //同步Group
            try
            {
                AcUserGroupSet acUserGroupSet = null;
                if (_terminal.ListAcUserGroupSet.Count > 0)
                {
                    acUserGroupSet = _terminal.ListAcUserGroupSet[0];
                    AddWorkMessage("Sync User Group with Id:" + acUserGroupSet.GroupID.ToString());
                    _stream.Send(_terminal.CreateSyncUserGroupMessage(CommandMode.TcpServer, acUserGroupSet));
                    return;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write User Group to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }
            //同步Holiday设置
            try
            {
                AcHolidaySet acHolidaySet = null;
                if (_terminal.ListAcHolidaySet.Count > 0)
                {
                    acHolidaySet = _terminal.ListAcHolidaySet[0];
                    AddWorkMessage("Sync Holidy set with Id:" + acHolidaySet.DoorHoliID.ToString());
                    _stream.Send(_terminal.CreateSyncHolidaySetMessage(CommandMode.TcpServer, acHolidaySet));
                    return;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write Holidy set to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
            }
            if (DistributeFlag == 0)
            {
                DistributeFlag = 1;
                UserInfoAdd userAdd = null;
                UserInfoDel userDelete = null;
                try
                {
                    if (_terminal.ListUserInfoAdd.Count > 0)
                    {
                        userAdd = _terminal.ListUserInfoAdd[0];

                    }
                    if (_terminal.ListUserInfoDelete.Count > 0)
                    {
                        userDelete = _terminal.ListUserInfoDelete[0];

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
                            strTraceMessage += "Delete Employe:" + userDelete.CardID.PadLeft(10, '0');
                        }
                        AddWorkMessage(strTraceMessage);
                        _stream.Send(_terminal.CreateSyncUserMessage(CommandMode.TcpServer, userAdd, userDelete));

                        return;
                    }
                }
                catch (Exception ex)
                {


                    AddErrorMessage("Sync user to device Exception:" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);


                }
            }
            if (DistributeFlag == 1)
            {
                DistributeFlag = 2;
                UserFingerDel userFingerDelete = null;
                try
                {
                    if (_terminal.ListUserFingersDelete.Count > 0)
                    {
                        userFingerDelete = _terminal.ListUserFingersDelete[0];

                    }
                    if ((object)userFingerDelete != null)
                    {
                        AddWorkMessage("Delete Employees " + userFingerDelete.CardID + " Finger:" + userFingerDelete.FPNo.ToString() + "from device");
                        _stream.Send(_terminal.CreateDeleteUserFingerMessage(CommandMode.TcpServer, userFingerDelete));
                        return;
                    }
                }
                catch (Exception ex)
                {


                    AddErrorMessage("Delete finger to device Exception:" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);


                }
            }
            if (DistributeFlag == 2)
            {
                DistributeFlag = 3;
                UserFingerAdd userFingerAdd = null;
                try
                {
                    if (_terminal.ListUserFingersAdd.Count > 0)
                    {
                        userFingerAdd = _terminal.ListUserFingersAdd[0];

                    }
                    if ((object)userFingerAdd != null)
                    {
                        AddWorkMessage("Wrtie Employees " + userFingerAdd.CardID + " Finger:" + userFingerAdd.FPNo.ToString() + "To device");
                        _stream.Send(_terminal.CreateAddUserFingerMessage(CommandMode.TcpServer, userFingerAdd));
                        return;
                    }
                }
                catch (Exception ex)
                {


                    AddErrorMessage("Write finger to device Exception: " + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);


                }
            }
            if (DistributeFlag == 3)
            {
                DistributeFlag = 4;
                AcAuthority userAcAuthority = null;
                try
                {
                    if (_terminal.ListAcAuthority.Count > 0)
                    {
                        DistributeFlag = 0;
                        userAcAuthority = _terminal.ListAcAuthority[0];
                        AddWorkMessage("Write Employees " + userAcAuthority.CardID + " Authority " + "to device");
                        _stream.Send(_terminal.CreateSyncUserAuthorityMessage(CommandMode.TcpServer, userAcAuthority));
                        return;

                    }

                }
                catch (Exception ex)
                {


                    AddErrorMessage("Delete finger to device Exception:" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);


                }
            }
            if (DistributeFlag > 3)
            {

                if (GetDataEvent.WaitOne(0))
                {
                    return;
                }
                else
                {
                    NotGetDataTickCount++;
                    if (NotGetDataTickCount > 60)
                    {
                        NotGetDataTickCount = 0;
                        _stream.Send(_terminal.CreateHeartbeatMessage());
                    }
                }
                DistributeFlag = 0;
            }
        }
        #region Result
        public void AnalysWriteTimeSetResult(ref byte[] response, AsyncCallback callback = null)
        {
            if (response[9] != 0x06)
                return;
            if ((byte)0x20 == response[10])
            {
                int rcvDoorId, rcvFrameNo;
                rcvDoorId = response[11];
                rcvFrameNo = response[12];
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_TimeSet_SlaveSID(_terminal.deviceContext.SlaveSID, rcvDoorId, rcvFrameNo))
                {
                    _terminal.RemoveFromListAcTimeSet(response[2], response[3]);
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
            if (response[9] != 0x07)
                return;
            if ((byte)0x20 == response[10])
            {
                int rcvDoorId, rcvTimeZone;
                rcvDoorId = response[11];
                rcvTimeZone = response[12];
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_TimeZone_SlaveSID(_terminal.deviceContext.SlaveSID, rcvDoorId, rcvTimeZone))
                {
                    _terminal.RemoveFromListAcTimeZone(response[2], response[3]);
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
            if (response[9] != 0x08)
                return;
            if ((byte)0x20 == response[10])
            {
                int rcvDoorId, rcvUserGroupNo;
                rcvDoorId = response[11];
                rcvUserGroupNo = response[12];
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_UserGroup_SlaveSID(_terminal.deviceContext.SlaveSID, rcvDoorId, rcvUserGroupNo))
                {
                    _terminal.RemoveFromListAcUserGroupSet(response[2], response[3]);
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
            if (response[9] != 0x09)
                return;
            if ((byte)0x20 == response[10])
            {
                int rcvDoorId, rcvHolidayId;
                rcvDoorId = response[11];
                rcvHolidayId = response[12] * 256 + response[13];
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_Holiday_SlaveSID(_terminal.deviceContext.SlaveSID, rcvDoorId, rcvHolidayId))
                {
                    _terminal.RemoveFromListAcHolidaySet(response[2], rcvHolidayId);
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
        public void AnalysWriteAcParaResult(ref byte[] response, AsyncCallback callback = null)
        {
            byte[] intCardId = new byte[4];

            if (response[9] != 0x05)
                return;

            Array.Copy(response, 11, intCardId, 0, 4);
            UInt32 CardId = System.BitConverter.ToUInt32(intCardId, 0);

            if ((byte)0x20 == response[10])
            {
                if (_terminal.syncDataBaseHelper.UPDATE_BFX_UserSlaveAllowTime(_terminal.deviceContext.SlaveSID, CardId.ToString().PadLeft(10, '0')))
                {
                    _terminal.RemoveFromListAcAuthority(CardId);
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

            if (0x02 != response[9])
                return;

            Array.Copy(response, 10, intCardId, 0, 4);
            UInt32 AddCardId = System.BitConverter.ToUInt32(intCardId, 0);
            Array.Copy(response, 14, intCardId, 0, 4);
            Int32 FingerNo = System.BitConverter.ToInt32(intCardId, 0);
            if (1 == response[18])
            {
                AddResultMessage("Write Employee:" + AddCardId.ToString().PadLeft(10, '0') + " Finger:" + FingerNo.ToString() + "OK");
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_FP_Add(AddCardId, _terminal.deviceContext.SlaveSID))
                {
                    _terminal.RemoveUserFingerFromAddList(AddCardId);
                    _terminal.deviceContext.FingersReplicatedCounts++;
                    //_terminal.RefreshSyncStasus();
                    if (_terminal.deviceContext.DeviceStatusEvent != null)
                        _terminal.deviceContext.DeviceStatusEvent();
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

            if (0x03 != response[9])
                return;
            Array.Copy(response, 10, intCardId, 0, 4);
            UInt32 AddCardId = System.BitConverter.ToUInt32(intCardId, 0);
            Array.Copy(response, 14, intCardId, 0, 4);
            Int32 FingerNo = System.BitConverter.ToInt32(intCardId, 0);
            if (1 == response[18])
            {
                AddResultMessage("Delete Employee:" + AddCardId.ToString().PadLeft(10, '0') + " Finger:" + FingerNo.ToString() + "OK");
                _terminal.syncDataBaseHelper.UPDATE_DS_BF_FP_Delete(AddCardId, _terminal.deviceContext.SlaveSID);
                _terminal.RemoveUserFingerFromDeleteList(AddCardId);
               

            }
            else
            {
                AddErrorMessage("Delete Employee:" + AddCardId.ToString().PadLeft(10, '0') + " Finger:" + FingerNo.ToString() + "Failed");
            }

        }
        public void AnalysSyncUsersResult(ref byte[] response, AsyncCallback callback = null)
        {
            byte bUpdateFlag = response[10];
            int rcvDataLen = 11;

            if (0x01 != response[9])
                return;
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
                        if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_User_Add(AddCardId, _terminal.deviceContext.SlaveSID))
                        {
                            _terminal.deviceContext.UserReplicatedCount++;
                            _terminal.RemoveUserFromAddList(AddCardId);
                            _terminal.RefreshSyncStasus();

                            if (_terminal.deviceContext.DeviceStatusEvent != null)
                                _terminal.deviceContext.DeviceStatusEvent();
                        }
                        rcvDataLen += 4;
                        AddResultMessage("Write Employee:" + AddCardId.ToString().PadLeft(10, '0') + " OK");

                    }
                    if (0x10 == (bUpdateFlag & 0xf0))
                    {
                        Array.Copy(response, rcvDataLen, intCardId, 0, 4);
                        UInt32 AddCardId = System.BitConverter.ToUInt32(intCardId, 0);
                        _terminal.syncDataBaseHelper.UPDATE_DS_BF_User_Delete(AddCardId, _terminal.deviceContext.SlaveSID);

                        _terminal.RemoveUserFromDeleteList(AddCardId);
                        AddResultMessage("Delete Employee:" + AddCardId.ToString().PadLeft(10, '0') + " OK");
                    }
                    //SyncUsersEvent.Set();
                }
                catch (Exception ex)
                {
                    AddErrorMessage("AnalysSyncUsersResult  : Error - " + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
                }

            }
        }
        public void AnalysReadDeviceResult(ref byte[] response, AsyncCallback callback = null)
        {
            if (0x04 != response[9])
                return;

            int deleteRecordId = 0;
             UInt32 FingerCardId = 0;
            int FingerNo = 0;
            int rcvDataLen = 10;
            int iTypePos = rcvDataLen;
            bool bHaveTransaction = false;
            byte[] CardId = new byte[11];
            byte[] TransactionTime = new byte[32];
            byte[] TransactionDevIp = new byte[15];
            byte[] tempIntBuf = new byte[4];

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

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                deleteRecordId = System.BitConverter.ToInt32(tempIntBuf, 0);
                rcvDataLen += 4;
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
                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                deleteRecordId = System.BitConverter.ToInt32(tempIntBuf, 0);
                rcvDataLen += 4;
                transaction.TransactionCardId = Encoding.UTF8.GetString(CardId);
                transaction.TransactionDateTime = Encoding.UTF8.GetString(TransactionTime);
                bHaveTransaction = true;
                //transaction.DeviceIP = Encoding.UTF8.GetString(TransactionDevIp);
            }
            if (bHaveTransaction)
            {
                bool bRet = _terminal.syncDataBaseHelper.InsertToOR_Transactions(transaction);
                Employees employee = _terminal.syncDataBaseHelper.GetEmployeeByCardId(transaction.TransactionCardId);
                if ((object)employee != null)
                {
                    transaction.UserId = employee.UserID;
                    transaction.UserName = employee.UserName;
                }
                AddResultMessage("Read Transaction OK");
                if (bRet)
                {
                   

                   // SendViaTcpAsSync(_terminal.CreateDleteTransactioMessage());

                    UpdateReadTransList(transaction);
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
               
                int FingerDataLen;
                
                byte[] FingerDataBuf = new byte[512];

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                rcvDataLen += 4;
                FingerCardId = System.BitConverter.ToUInt32(tempIntBuf, 0);

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                rcvDataLen += 4;
                FingerNo = System.BitConverter.ToInt32(tempIntBuf, 0);

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                rcvDataLen += 4;
                FingerDataLen = System.BitConverter.ToInt32(tempIntBuf, 0);
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
                   // SendViaTcpAsSync(_terminal.CreateDeleteReadFingerMessage(FingerCardId, FingerNo));
                }
                else
                {
                    AddErrorMessage("Get Registered finger CardID:" + FingerCardId.ToString() + " Finger No:" + FingerNo.ToString() + " Failed");
                }

            }
            GetDataEvent.Set();
             _stream.Send(_terminal.DeleteReplicatedTransAndFingerMessage(deleteRecordId,FingerCardId,FingerNo));

            //transactionHandleEvent.BeginInvoke(transaction, callback, transactionHandleEvent);
        }
        private void UpdateReadTransList(Transactions transaction)
        {
            lock (insertTransLocker)
            {
                if (ReadTransList.Count >= 2000)
                    ReadTransList.RemoveAt(ReadTransList.Count - 1);
                ReadTransList.Insert(0, transaction);
                if (_terminal.deviceContext.AddTransactionEvent != null)
                    _terminal.deviceContext.AddTransactionEvent();
            }
        }
        #endregion
       
        private void SyncClientRun()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                try
                {
                    while (!this.cts.Token.IsCancellationRequested)
                    {
                        onAsyncCallback3.Invoke();
                        Thread.Sleep(50);
                    }
                }
                catch (Exception ex)
                {
                    
                } // suppress any exceptions
            });
        }
        public void Dispose()
        {
            AddTraceMessage("Disconnect with server");
            cts.Cancel();
        }
        public void UpdateTerminalSatus(bool bOnline, string ip)
        {
            _terminal.deviceContext.IP = ip;
            _terminal.UpdateDeviceStatus(bOnline);
        }
        private void AddTraceMessage(string message)
        {
            if (_terminal.deviceContext.DeviceTraceEvent != null)
                _terminal.deviceContext.DeviceTraceEvent(_terminal.deviceContext.SlaveSID, "Device ID:" + _terminal.deviceContext.SlaveSID.ToString() + "-" + message + "-" + DateTime.Now.ToString());
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
    }
}
