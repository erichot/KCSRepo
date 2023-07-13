using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KCS.Models;
using NetSockets;

namespace KCS.Sync
{
    public class ClientOfServer : BridgeUtility, IDisposable
    {
        private const int SyncTimeOut = 3000;//3s
        private const int SyncFingerTimeOut = 5000;//3s
        private CancellationTokenSource cts = new CancellationTokenSource();
        private Terminal _terminal = null;
        private NetBaseStream<byte[]> _stream = null;
        private delegate void OnAsyncCallback3();
        private OnAsyncCallback3 onAsyncCallback3 = null;
        private ManualResetEvent ResetDeviceEvent = new ManualResetEvent(true);
        private int DistributeFlag = 0;
        private ManualResetEvent SyncEvent = new ManualResetEvent(true);
        private long SyncUserTick = 0;
        private long SyncAcParaTick = 0;
        private long SyncAddFingerTick = 0;
        private long SyncDelFingerTick = 0;
        private long SyncUserAuthTick = 0;
        private bool bDiposed = false;
        private Thread threadSyscToDevice = null;
        //private Semaphore semaphore = new Semaphore(1,1);
        // private int SyncNoCommandCount = 0;
        #region LOCKERS
        private readonly object SyncDataLocker = new object();
        #endregion




        const string m_ClassID = "CLIENTOFSERVER";
        KCS.Services.ApplicationLogService m_ApplicationLogService = new KCS.Services.ApplicationLogService();



        public Terminal terminal
        {
            get
            {
                return _terminal;
            }
        }
        public ClientOfServer(Terminal terminal, NetBaseStream<byte[]> stream)
        {
            DistributeFlag = 0;
            //SyncNoCommandCount = 0;
            _terminal = terminal;
            _stream = stream;
            onAsyncCallback3 = new OnAsyncCallback3(CreateRequestAndSendTerminal);
            AddWorkMessage("Connect in");
            SyncClientRun();
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
                            if (String.IsNullOrEmpty(strRegPhoto))
                            {
                                strRegPhoto = string.Format("{0}\\Staff photos\\{1}.jpg", System.Windows.Forms.Application.StartupPath, userAdd.UserID);
                                AddWorkMessage("Read employee photo at " + strRegPhoto);
                            }


                            bool isRealImage = IsRealImage(strRegPhoto);
                            if (isRealImage)
                            {
                                _stream.Send(_terminal.CreateEnrollUserWithFaceMessage(userAdd, strRegPhoto));
                                //Thread.Sleep(3000);
                            }


                        }
                        if ((object)userDelete != null)
                        {
                            _stream.Send(_terminal.CreateDeleteUserWithFaceMessage(CommandMode.TcpServer, userDelete));

                        }
                    }
                    else
                    {
                        _stream.Send(_terminal.CreateSyncUserMessage(CommandMode.TcpServer, userAdd, userDelete));
                    }
                       

                    return true;
                }
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
                    _stream.Send(_terminal.CreateAddUserFingerMessage(CommandMode.TcpServer, userFingerAdd));
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
                    _stream.Send(_terminal.CreateDeleteUserFingerMessage(CommandMode.TcpServer, userFingerDelete));
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
                AddWorkMessage("Sync parameters to Device");
                _stream.Send(_terminal.CreateSyncDeviceParaMessage(CommandMode.TcpServer, syncDev));
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
                    _stream.Send(_terminal.CreateSyncTimeSetMessage(CommandMode.TcpServer, acTimeSet));
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
                    _stream.Send(_terminal.CreateSyncTimeZoneMessage(CommandMode.TcpServer, acTimeZone));
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
                    _stream.Send(_terminal.CreateSyncUserGroupMessage(CommandMode.TcpServer, acUserGroupSet));
                    return true;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write User Group to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
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
                    _stream.Send(_terminal.CreateSyncChangeCardIdMessage(CommandMode.TcpServer, changeCardIDCls));
                    return true;
                }

            }
            catch (Exception ex)
            {
                AddErrorMessage("Sync change card id to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
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
                    _stream.Send(_terminal.CreateSyncHolidaySetMessage(CommandMode.TcpServer, acHolidaySet));
                    return true;
                }
            }
            catch (Exception ex)
            {
                AddErrorMessage("Write Holidy set to device Exception :" + ex.Message + "\nErrorStackTrace : " + ex.StackTrace);
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
                    DistributeFlag = 0;
                    userAcAuthority = _terminal.ListAcAuthority[0];
                    _terminal.ListAcAuthority.RemoveAt(0);
                    AddWorkMessage("Write Employees " + userAcAuthority.CardID + " Authority " + "to device");
                    _stream.Send(_terminal.CreateSyncUserAuthorityMessage(CommandMode.TcpServer, userAcAuthority));
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
            //
            NEXT_GAIN:
                if (_terminal.OpenDoorFlag)
                {//开门
                    _stream.Send(_terminal.CreateOpenDoorMessage(CommandMode.TcpServer));
                        _terminal.ClearOpenDoor();
                }
                if (_terminal.reReadTransSet.ReReadFlag)
                {
                    _stream.Send(_terminal.CreateReadTransAgainMessage(CommandMode.TcpServer, _terminal.reReadTransSet.dateStart, _terminal.reReadTransSet.dateEnd, _terminal.reReadTransSet.timeStart, _terminal.reReadTransSet.timeEnd));
                        _terminal.ClearReReadFlag();
                }
                //设置开门密码
                if (_terminal.doorPinContext != null)
                {
                    _stream.Send(_terminal.CreateSetDoorPinMessage(CommandMode.TcpServer, _terminal.doorPinContext));
                    Thread.Sleep(300);
                }
              
                //设置设备参数
                SyncParameter syncDevicePara = new SyncParameter();
                syncDevicePara = _terminal.GetSyncDevicePara();
                if (syncDevicePara.SyncLanguageFlag || syncDevicePara.SyncMenuPwdFlag || syncDevicePara.SyncWorkModeFlag)
                {
                    SyncParaToDevice(syncDevicePara);
                    Thread.Sleep(300);
                }
                if (currentTick - SyncAcParaTick >= SyncTimeOut)
                {
                    

                    //同步时间段
                    if (SyncTimeFrameToDevice())
                    {
                        SyncAcParaTick = currentTick;
                        return true;
                    }
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

                if (DistributeFlag == 0)
                {

                    DistributeFlag = 1;

                    if (currentTick - SyncUserTick >= SyncTimeOut)
                    {
                        //AddWorkMessage(" Send user 3 to device...");
                        if (SyncUserToDevice())
                        {
                            SyncUserTick = currentTick;
                            return true;
                        }
                    }

                }
                if (DistributeFlag == 1)
                {
                    DistributeFlag = 2;
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
                if (DistributeFlag == 2)
                {
                    DistributeFlag = 3;
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
                if (DistributeFlag == 3)
                {

                    DistributeFlag = 4;
                    if (currentTick - SyncUserAuthTick >= SyncTimeOut)
                    {

                        if (SyncUserAuthorityToDevice())
                        {
                            SyncUserAuthTick = currentTick;
                            DistributeFlag = 0;
                            return true;
                        }
                    }
                }
                tryTimes++;
                if (tryTimes >= 2)
                //if (DistributeFlag >= 4)
                {
                    _stream.Send(_terminal.CreateHeartbeatMessage());
                    AddWorkMessage("Send live package");
                    DistributeFlag = 0;
                }
                else
                {
                    goto NEXT_GAIN;
                }
                return false;
            }

        }
        public void ClentsDataReceived(byte[] rcvData)
        {

            AddWorkMessage(" Get Reponse from device:" + rcvData[0].ToString("X2") + rcvData[4].ToString("X2"));
            //semaphore.WaitOne();
            if (!this._terminal.deviceContext.IsEnabled)
            {
                //semaphore.Release();
                return;
            }


            RequestCommand receive_type = (RequestCommand)rcvData[4];
            if (!ResetDeviceEvent.WaitOne(0))
            {//复位命令
                if (receive_type != RequestCommand.ResetDeviceReturn)
                {
                    //semaphore.Release();
                    return;
                }
            }

            switch (receive_type)
            {
                case RequestCommand.TransFaceImage:
                    AddWorkMessage("Trans face image OK");
                    break;
               
                case RequestCommand.RequestTime:
                    AddWorkMessage("Write Device time");
                    _stream.Send(_terminal.CreateWriteTimeMessage(CommandMode.TcpServer));
                    //Thread.Sleep(500);
                    Thread.Sleep(100);
                    _stream.Send(_terminal.CreateWriteTimeMessageOld(CommandMode.TcpServer));
                    break;
                case RequestCommand.ResetDeviceReturn:
                    if (rcvData[9] == 1)
                    {
                        _terminal.deviceContext.ResetToDefault = false;
                        ResetDeviceEvent.Set();
                        _terminal.syncDataBaseHelper.ResetDeviceOK(_terminal.deviceContext.SlaveSID);
                        _terminal.RefreshSyncStasus();
                        //if (_terminal.deviceContext.DeviceStatusEvent != null)
                        //   _terminal.deviceContext.DeviceStatusEvent();
                        AddResultMessage("Reset Device OK");
                    }
                    else
                    {
                        AddResultMessage("Reset Device Failed");
                    }
                    break;
                case RequestCommand.RequestData:
                    // _stream.Send(_terminal.DeleteReplicatedTransAndFingerMessage(0, 0, 0));

                    SyncEvent.Set();
                    //AddWorkMessage("SyncDataToDevice 11.......");
                    SyncDataToDevice();
                    break;
                case RequestCommand.WriteTimeSetReturn:
                    SyncEvent.Set();
                    AnalysWriteTimeSetResult(ref rcvData);
                    SyncTimeFrameToDevice();
                    SyncAcParaTick = DateTime.Now.Ticks / 10000;
                    //CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteTimeZoneReturn:
                    SyncEvent.Set();
                    AnalysWriteTimeZoneResult(ref rcvData);
                    SyncTimeZoneToDevice();
                    SyncAcParaTick = DateTime.Now.Ticks / 10000;
                    // CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteUserGroupReturn:
                    SyncEvent.Set();
                    AnalysWriteUserGroupResult(ref rcvData);
                    SyncUserGroupToDevice();
                    SyncAcParaTick = DateTime.Now.Ticks / 10000;
                    //CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteHolidaySetReturn:
                    SyncEvent.Set();
                    AnalysWriteHolidaySetResult(ref rcvData);
                    SyncHolidaySetToDevice();
                    SyncAcParaTick = DateTime.Now.Ticks / 10000;
                    //CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteAcParaReturn:
                    SyncEvent.Set();
                    AnalysWriteAcParaResult(ref rcvData);
                    SyncUserAuthorityToDevice();
                    SyncUserAuthTick = DateTime.Now.Ticks / 10000;
                    // CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.WriteUserInfoReturn:
                    SyncEvent.Set();
                    AnalysSyncUsersResult(ref rcvData);


                    // CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.EnrollFingerReturn:
                    SyncEvent.Set();
                    AnalysWriteUserFingerResult(ref rcvData);
                    SyncAddFingerToDevice();
                    SyncAddFingerTick = DateTime.Now.Ticks / 10000;
                    //CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.DeleteFingerReturn:
                    SyncEvent.Set();
                    AnalysDeleteUserFingerResult(ref rcvData);
                    SyncDelFingerToDevice();
                    SyncDelFingerTick = DateTime.Now.Ticks / 10000;
                    // CreateRequestAndSendTerminal();
                    break;
                case RequestCommand.PushDeviceData:
                    SyncEvent.Set();
                    AnalysReadDeviceResult(ref rcvData);
                    //Thread.Sleep(500);
                    break;
                case RequestCommand.PushDeviceDataByChar:
                    SyncEvent.Set();
                    AnalysReadDeviceByCharResult(ref rcvData);
                    //Thread.Sleep(500);
                    break;
                case  RequestCommand.ChangeCardIdReturn:
                    SyncEvent.Set();
                    AnalysChangeCardIDResult(ref rcvData);
                    break;
                case RequestCommand.WriteBellParaReturn:
                    SyncEvent.Set();
                    break;
                case RequestCommand.WriteDeviceReturn:
                    AnalysWriteDeviceParaResult(ref rcvData);
                    SyncEvent.Set();
                    break;
                case RequestCommand.OpenDoorReturn:
                    
                    SyncEvent.Set();
                    break;
                case RequestCommand.DoorPinReturn:
                    AnalysWriteDoorPinResult(ref rcvData);
                    SyncEvent.Set();
                    break;
                default:
                    //CreateRequestAndSendTerminal();

                    break;
            }
            // semaphore.Release();

        }
        private void CreateRequestAndSendTerminal()
        {
            if(_terminal.deviceContext.RebootDeviceFlag)
            {
                _terminal.deviceContext.RebootDeviceFlag = false;//
                AddWorkMessage("Reboot device ...");
                _stream.Send(_terminal.RebootDeviceMessage(CommandMode.TcpServer));
                return;
            }

            if (_terminal.deviceContext.ResetToDefault)
            {//初始化终端                   

                AddWorkMessage("Reaset Device,Please Wait ...");
                _stream.Send(_terminal.ResetDeviceMessage(CommandMode.TcpServer));
                ResetDeviceEvent.Reset();
                ResetDeviceEvent.WaitOne(12000);
                return;
            }


            bool bReturn = SyncEvent.WaitOne(2000, false);
            SyncEvent.Reset();

            if (this.cts.Token.IsCancellationRequested)
            {
                return;
            }

            if (!bReturn)
            {
                //AddWorkMessage("SyncDataToDevice 22.......");
                if (!SyncDataToDevice())
                {
                    //
                }

            }

            //else
            //{
            //    SyncDataToDevice();
            //}
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
                    // _terminal.RemoveFromListAcTimeSet(response[2], response[3]);
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
                    // _terminal.RemoveFromListAcTimeZone(response[2], response[3]);
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
                    //_terminal.RemoveFromListAcUserGroupSet(response[2], response[3]);
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
                    //_terminal.RemoveFromListAcHolidaySet(response[2], rcvHolidayId);
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
                    //_terminal.RemoveFromListAcAuthority(CardId);
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
                if (_terminal.syncDataBaseHelper.UPDATE_DS_BF_FP_Add(AddCardId,FingerNo, _terminal.deviceContext.SlaveSID))
                {
                    //_terminal.RemoveUserFingerFromAddList(AddCardId);
                    _terminal.deviceContext.FingersReplicatedCounts++;
                    //_terminal.RefreshSyncStasus();
                    // if (_terminal.deviceContext.DeviceStatusEvent != null)
                    //  _terminal.deviceContext.DeviceStatusEvent();
                }
                //WriteUserFingerEvent.Set();
            }
            else
            {
                AddErrorMessage("Write Employee:" + AddCardId.ToString().PadLeft(10, '0') + " Finger:" + FingerNo.ToString() + "Failed");
            }

        }
        public void AnalysWriteDoorPinResult(ref byte[] response, AsyncCallback callback = null)
        {
            if (0x0E != response[9])
                return;
            if (0 != response[10])
            {
                AddResultMessage("Write Door PIN OK");

                _terminal.SetDoorPINOk();

            }
            else
            {
                AddErrorMessage("Write Door PIN  " + "Failed");
            }
        }
        public void AnalysWriteDeviceParaResult(ref byte[] response, AsyncCallback callback = null)
        {
            if (0x0D != response[9])
                return;
            if (0 != response[10])
            {
                AddResultMessage("Write device parameters OK");

                _terminal.syncDataBaseHelper.UPDATE_DevicePara(_terminal.deviceContext.SlaveSID);

            }
            else
            {
                AddErrorMessage("Write device parameters  " + "Failed");
            }
        }
        public void AnalysChangeCardIDResult(ref byte[] response, AsyncCallback callback = null)
        {
            byte[] intCardId = new byte[4];

            if (0x0C != response[9])
                return;

            Array.Copy(response, 11, intCardId, 0, 4);
            UInt32 ChangeId = System.BitConverter.ToUInt32(intCardId, 0);

            if (0 != response[10])
            {
                AddResultMessage("Change Card Id OK");
                _terminal.syncDataBaseHelper.UPDATE_ChangeCardID(_terminal.deviceContext.SlaveSID, ChangeId);
               
            }
            else
            {
                AddErrorMessage("Change Card Id " +  "Failed");
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
                _terminal.syncDataBaseHelper.UPDATE_DS_BF_FP_Delete(AddCardId, FingerNo, _terminal.deviceContext.SlaveSID);
                //_terminal.RemoveUserFingerFromDeleteList(AddCardId);


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
            //AddResultMessage("Sync User:" + bUpdateFlag.ToString("X2"));
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

                            // if (_terminal.deviceContext.DeviceStatusEvent != null)
                            //    _terminal.deviceContext.DeviceStatusEvent();
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
                    // SyncUsersEvent.Set();
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
            if (0x14 != response[9])
                return;

            int deleteRecordId = 0;
            UInt32 FingerCardId = 0;
            int FingerNo = 0;
            int rcvDataLen = 10;
            int iTypePos = rcvDataLen;
            bool bHaveTransaction = false;
            byte[] CardId = new byte[15];
            byte[] TransactionTime = new byte[32];
            byte[] TransactionDevIp = new byte[15];
            byte[] tempIntBuf = new byte[4];

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

                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                deleteRecordId = System.BitConverter.ToInt32(tempIntBuf, 0);
                rcvDataLen += 4;
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
                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                deleteRecordId = System.BitConverter.ToInt32(tempIntBuf, 0);
                rcvDataLen += 4;
                CardId[10] = 0;
                transaction.TransactionCardId = Encoding.UTF8.GetString(CardId);
                transaction.TransactionDateTime = Encoding.UTF8.GetString(TransactionTime);
                bHaveTransaction = true;
                //transaction.DeviceIP = Encoding.UTF8.GetString(TransactionDevIp);
            }
            if (bHaveTransaction)
            {
                //bool bRet = _terminal.syncDataBaseHelper.InsertToOR_Transactions(transaction);
                int iRet = _terminal.syncDataBaseHelper.InsertToOR_TransactionsWithTransId(transaction, deleteRecordId);
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
                        // SendViaTcpAsSync(_terminal.CreateDleteTransactioMessage());

                        UpdateReadTransList(transaction);
                    }
                }
                else
                {
                    deleteRecordId = 0;
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

               // byte[] FingerDataBuf = new byte[900];

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
                    // SendViaTcpAsSync(_terminal.CreateDeleteReadFingerMessage(FingerCardId, FingerNo));
                }
                else
                {
                    AddErrorMessage("Get Registered finger CardID:" + FingerCardId.ToString() + " Finger No:" + FingerNo.ToString() + " Failed");
                }

            }
            if (0 != deleteRecordId || 0 != FingerCardId)
            {

                _stream.Send(_terminal.DeleteReplicatedTransAndFingerMessage(deleteRecordId, FingerCardId, FingerNo));
            }

            //transactionHandleEvent.BeginInvoke(transaction, callback, transactionHandleEvent);
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
                Array.Copy(response, rcvDataLen, tempIntBuf, 0, 4);
                deleteRecordId = System.BitConverter.ToInt32(tempIntBuf, 0);
                rcvDataLen += 4;
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
                //bool bRet = _terminal.syncDataBaseHelper.InsertToOR_Transactions(transaction);
                int iRet = _terminal.syncDataBaseHelper.InsertToOR_TransactionsWithTransId(transaction, deleteRecordId);
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
                        // SendViaTcpAsSync(_terminal.CreateDleteTransactioMessage());

                        UpdateReadTransList(transaction);
                    }
                }
                else
                {
                    deleteRecordId = 0;
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
                    // SendViaTcpAsSync(_terminal.CreateDeleteReadFingerMessage(FingerCardId, FingerNo));
                }
                else
                {
                    AddErrorMessage("Get Registered finger CardID:" + FingerCardId.ToString() + " Finger No:" + FingerNo.ToString() + " Failed");
                }

            }
            if (0x20 == (response[iTypePos] & 0x20))
            {
                var _log = new ApplicationLogEntity()
                {
                    ClassID = m_ClassID,
                    ProcedureID = "AnalysReadDeviceResult"
                    ,
                    ProcedureDetail = $"SlaveSID={_terminal.deviceContext.SlaveSID};TransactionCardId={transaction.TransactionCardId};response.Length={response.Length};rcvDataLen={rcvDataLen}"
                };
                m_ApplicationLogService.WriteLog(_log);


                byte[] photoBuf = new byte[response.Length - rcvDataLen];
                Array.Copy(response, rcvDataLen, photoBuf, 0, response.Length - rcvDataLen);
                _terminal.syncDataBaseHelper.InsertUserRecordPhoto(_terminal.deviceContext.SlaveSID, transaction.TransactionCardId, transaction.TransactionDateTime, photoBuf);
            }
            if (0 != deleteRecordId || 0 != FingerCardId)
            {

                _stream.Send(_terminal.DeleteReplicatedTransAndFingerMessage(deleteRecordId, FingerCardId, FingerNo));
            }

            //transactionHandleEvent.BeginInvoke(transaction, callback, transactionHandleEvent);
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="str"></param>
        private void WriteDuplicteTransaction(Transactions transaction)
        {
            string szConfigPath = string.Format("{0}\\DiscardedTrans", System.Windows.Forms.Application.StartupPath);
            if (!System.IO.Directory.Exists(szConfigPath))
            {
                System.IO.Directory.CreateDirectory(szConfigPath);
            }
            string szConfigFile = string.Format("{0}\\DiscardedTrans\\Trans.txt", System.Windows.Forms.Application.StartupPath);
            using (var sw = new StreamWriter(szConfigFile, true))
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
        private void UpdateReadTransList(Transactions transaction,bool bDis=true)
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
        #endregion

        protected void SyncDeviceThread()
        {
            try
            {
                while (!this.cts.Token.IsCancellationRequested)
                {
                    try
                    {
                        if (bDiposed)
                            break;
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
        private void SyncClientRun()
        {
            if (threadSyscToDevice != null)
                threadSyscToDevice.Abort();
            threadSyscToDevice = new Thread(new ThreadStart(SyncDeviceThread));
            threadSyscToDevice.Priority = ThreadPriority.AboveNormal;
            threadSyscToDevice.Start();
            //ThreadPool.QueueUserWorkItem((o) =>
            //{
            //    try
            //    {
            //        while (!this.cts.Token.IsCancellationRequested)
            //        {
            //            try
            //            {
            //                if (bDiposed)
            //                    break;
            //                if (this._terminal.deviceContext.IsEnabled)
            //                    onAsyncCallback3.Invoke();
            //                Thread.Sleep(50);
            //            }
            //            catch (Exception ex)
            //            {
            //                break;
            //            }
            //        }
            //        AddErrorMessage("Exist SyncClientRun...");
            //    }
            //    catch (Exception ex)
            //    {
            //        Program.WriteLog(ex.Message+ "-------SyncClientRun");
            //    } // suppress any exceptions
            //});
        }
        public void Dispose()
        {
            AddTraceMessage("Disconnect with server");
            bDiposed = true;
            cts.Cancel();
            ResetDeviceEvent.Set();
            SyncEvent.Set();

        }
        public void UpdateTerminalSatus(bool bOnline, string ip)
        {
            _terminal.deviceContext.IP = ip;
            _terminal.UpdateDeviceStatus(bOnline);
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
    }
}
