using KCS.Common;
using KCS.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KCS.Sync
{
    public class Terminal : MessageFactory, IDisposable
    {
        public bool m_disposed;
        public NetSockets.NetClient Client { get; set; }

        public int DeviceConnectStatus { get; set; }
        public Devices deviceContext { get; set; }
        public int TerminalPort { get; set; }
        public int? TerminalReceiveTimeout { get; set; }
        public int? TerminalRequestTimeout { get; set; }
        public Guid TerminalUniqueID { get; set; }
        public SyncClient syncClient { get; set; }
        public SyncDatabaseHelper syncDataBaseHelper { get; set; }
        public IList<UserInfoAdd> listUserAdd;
        public IList<UserInfoDel> listUserDelete;
        public IList<UserFingerAdd> listUserFingerAdd;
        public IList<UserFingerDel> listUserFingerDelete;
        //TimeSet
        public IList<AcTimeSet> listAcTimeSet;
        //TimZone
        public IList<AcTimeZone> listAcTimeZone;
        //UserGroup
        public IList<AcUserGroupSet> listAcUserGroupSet;
        //HolidaySet
        public IList<AcHolidaySet> listAcHolidaySet;
        //Access Control
        public IList<AcAuthority> listAcAuthority;
        //Change Card ID
        public IList<ChangeCardIDCls> listChangeCardID;
        //Open door password
        public DoorPIN doorPinContext;


        public bool OpenDoorFlag { get; set; }
        public ReReadTransPara reReadTransSet { get; set; }
        #region LOCKERS
        public readonly object AddUserLocker = new object();
        public readonly object DeleteUserLocker = new object();
        public readonly object AddUserFingerLocker = new object();
        public readonly object DeleteUserFingerLocker = new object();
        public readonly object SyncUserAuthLocker = new object();

        public readonly object SyncTimeSetLocker = new object();
        public readonly object SyncTimeZoneLocker = new object();
        public readonly object SyncUserGroupLocker = new object();
        public readonly object SyncHolidayLocker = new object();
        public readonly object SyncChangeCardIDLocker = new object();

        public readonly object SyncDevParaLocker = new object();
        #endregion
        public Terminal(Devices deviceContext)
        {
            this.TerminalUniqueID = Guid.NewGuid();
            this.TerminalPort = 1868;
            this.deviceContext = deviceContext;
            this.deviceContext.InitDevice();
            if (!deviceContext.IsServerMode)//Client模式
                this.syncClient = new SyncClient(this);
            else
                this.syncClient = null;
            this.Client = null;
            this.syncDataBaseHelper = new SyncDatabaseHelper();
            this.listUserAdd = new List<UserInfoAdd>();
            this.listUserDelete = new List<UserInfoDel>();
            this.listUserFingerAdd = new List<UserFingerAdd>();
            this.listUserFingerDelete = new List<UserFingerDel>();
            this.listChangeCardID = new List<ChangeCardIDCls>();

            this.listAcTimeSet = new List<AcTimeSet>();
            this.listAcTimeZone = new List<AcTimeZone>();
            this.listAcUserGroupSet = new List<AcUserGroupSet>();
            this.listAcHolidaySet = new List<AcHolidaySet>();
            this.listAcAuthority = new List<AcAuthority>();
            this.DeviceConnectStatus = -1;
            this.reReadTransSet =  new ReReadTransPara();
            this.OpenDoorFlag = false;
            this.doorPinContext = null;

            IList<DoorPIN> listDoorPin = syncDataBaseHelper.GetOpenDoorPinList(deviceContext.SlaveSID);
            if (listDoorPin != null && listDoorPin.Count > 0)
                doorPinContext = listDoorPin[0];
            if (string.IsNullOrEmpty(deviceContext.MenuPwd))
                SetCommunicationPin(0);
            else
            {
                if(!string.IsNullOrEmpty(deviceContext.MenuPwd))
                SetCommunicationPin(Convert.ToInt32(deviceContext.MenuPwd));
            }
        }
        public void OpenDoor()
        {
            this.OpenDoorFlag = true;
        }
        public void ClearOpenDoor()
        {
            this.OpenDoorFlag = false;
        }
        public DoorPIN GetOpenDoorPin()
        {
            return this.doorPinContext == null ? new DoorPIN() : this.doorPinContext;
        }
        public bool UpdateDoorPIN(DoorPIN pin)
        {
            
            this.doorPinContext = new DoorPIN(pin);
            return syncDataBaseHelper.UpdateDoorPin(pin, deviceContext.SlaveSID);
        }
        public void SetDoorPINOk()
        {
            syncDataBaseHelper.SetDoorPinOK(deviceContext.SlaveSID);
            this.doorPinContext = null;
        }
        public void ReReadTransactions(DateTime dateStart,DateTime dateEnd,DateTime timeStart,DateTime timeEnd)
        {
            this.reReadTransSet.ReReadFlag = true;
            this.reReadTransSet.dateStart = dateStart;
            this.reReadTransSet.dateEnd = dateEnd;
            this.reReadTransSet.timeStart = timeStart;
            this.reReadTransSet.timeEnd = timeEnd;
        }
        public void ClearReReadFlag()
        {
            this.reReadTransSet.ReReadFlag = false ;
        }
        public void SwitchToServerMode()
        {
            try
            {
                if (this.syncClient != null)
                {
                    
                    this.syncClient.Dispose();
                    this.syncClient = null;
                }
            }
            catch
            {
            }
        }
        public void SwitchToClientMode()
        {
            try
            {
                if (this.syncClient != null)
                {
                    this.syncClient.Dispose();
                    this.syncClient = null;
                }
                this.syncClient = new SyncClient(this);
            }
            catch
            {
            }
        }
        public string GetRegisterUserPhoto(string cardid)
        {
            return syncDataBaseHelper.GetRegisterPhotoPath(cardid);

        }
        //Remove Change CardID
        public void RemoveChangeCardIdFromAddList(UInt32 CardId)
        {
            lock (SyncChangeCardIDLocker)
             {
                 listChangeCardID.RemoveAt(0);
             }
        }
        public IList<ChangeCardIDCls> ListChangeCardID
        {
            get
            {
                if (listChangeCardID.Count == 0)
                {

                    listChangeCardID = syncDataBaseHelper.GetChageCardIdList(this.deviceContext.SlaveSID);
                }
                return listChangeCardID;
            }
        }
        public void RemoveUserFromAddList(UInt32 CardId)
        {
            lock (AddUserLocker)
            {
                listUserAdd.RemoveAt(0);
                //foreach (var user in ListUserInfoAdd)
                //for (int i = 0; i < listUserAdd.Count - 1; i++)
                //{
                //    if (UInt32.Parse(listUserAdd[i].CardID) == CardId)
                //    {
                //        //listUserAdd.Remove(listUserAdd[i]);


                //        break;
                //    }
                //}
            }
        }
        public void RemoveUserFromDeleteList(UInt32 CardId)
        {
            lock (DeleteUserLocker)
            {
                listUserDelete.RemoveAt(0);
                //foreach (var user in ListUserInfoDelete)
                //for (int i = 0; i < listUserDelete.Count - 1; i++)
                //{
                //    if (UInt32.Parse(listUserDelete[i].CardID) == CardId)
                //    {
                //        //listUserDelete.Remove(listUserDelete[i]);

                //        break;
                //    }
                //}
            }
        }
        public void RemoveUserFingerFromAddList(UInt32 CardId)
        {
            lock (AddUserFingerLocker)
            {
                listUserFingerAdd.RemoveAt(0);
                //foreach (var user in ListUserFingersAdd)
                //for (int i = 0; i < listUserFingerAdd.Count - 1; i++)
                //{
                //    if (UInt32.Parse(listUserFingerAdd[i].CardID) == CardId)
                //    {
                //        //listUserFingerAdd.Remove(listUserFingerAdd[i]);

                //        break;
                //    }
                //}
            }
        }
        public void RemoveUserFingerFromDeleteList(UInt32 CardId)
        {
            lock (DeleteUserFingerLocker)
            {
                listUserFingerDelete.RemoveAt(0);
                //foreach (var user in ListUserFingersDelete)
                //for (int i = 0; i < listUserFingerDelete.Count - 1; i++)
                //{
                //    if (UInt32.Parse(listUserFingerDelete[i].CardID) == CardId)
                //    {
                //        //listUserFingerDelete.Remove(listUserFingerDelete[i]);

                //        break;
                //    }
                //}
            }
        }
        //TimeSet
        public IList<AcTimeSet> ListAcTimeSet
        {
            get
            {
                //if (listAcTimeSet.Count == 0)
                {
                    listAcTimeSet = syncDataBaseHelper.GetTimeSetList(this.deviceContext.SlaveSID);
                }
                return listAcTimeSet;
            }
        }
        public AcTimeSet GetListAcTimeSet()
        {
            lock (SyncTimeSetLocker)
            {
                if (ListAcTimeSet == null)
                    return null;
                if (ListAcTimeSet.Count > 0)
                {
                    return ListAcTimeSet[0];
                }
                return null;
            }
        }
        public void RemoveFromListAcTimeSet(byte DoorID, byte TimeSetID)
        {
            lock (SyncTimeSetLocker)
            {
                listAcTimeSet.RemoveAt(0);
                //foreach (var item in ListAcTimeSet)
                //for (int i = 0; i < listAcTimeSet.Count - 1; i++)
                //{
                //    if (listAcTimeSet[i].DoorID == DoorID && listAcTimeSet[i].TimeSetID == TimeSetID)
                //    {
                //        //listAcTimeSet.Remove(listAcTimeSet[i]);

                //        break;
                //    }
                //}
            }
        }
        //TimZone
        public AcTimeZone GetListAcTimeZone()
        {
            lock (SyncTimeZoneLocker)
            {
                if (ListAcTimeZone == null)
                    return null;
                if (ListAcTimeZone.Count > 0)
                {
                    return ListAcTimeZone[0];
                }
                return null;
            }
        }
        public IList<AcTimeZone> ListAcTimeZone
        {
            get
            {
                // if (listAcTimeZone.Count == 0)
                {
                    listAcTimeZone = syncDataBaseHelper.GetTimeZoneList(this.deviceContext.SlaveSID);
                }
                return listAcTimeZone;
            }
        }
        public void RemoveFromListAcTimeZone(byte DoorID, byte TimeZoneID)
        {
            lock (SyncTimeZoneLocker)
            {
                //foreach (var item in ListAcTimeZone)
                listAcTimeSet.RemoveAt(0);
                //for (int i = 0; i < listAcTimeZone.Count - 1; i++)
                //{
                //    if (listAcTimeZone[i].DoorID == DoorID && listAcTimeZone[i].TimeZoneID == TimeZoneID)
                //    {
                //        listAcTimeZone.Remove(listAcTimeZone[i]);
                //        break;
                //    }
                //}
            }
        }
        //UserGroup
        public AcUserGroupSet GetListAcUserGroupSet()
        {

            lock (SyncUserGroupLocker)
            {
                if (ListAcUserGroupSet == null)
                    return null;
                if (ListAcUserGroupSet.Count > 0)
                {
                    return ListAcUserGroupSet[0];
                }
                return null;
            }
        }
        public IList<AcUserGroupSet> ListAcUserGroupSet
        {
            get
            {
                //if (listAcUserGroupSet.Count == 0)
                {
                    listAcUserGroupSet = syncDataBaseHelper.GetUserGroupSetList(this.deviceContext.SlaveSID);
                }
                return listAcUserGroupSet;
            }
        }
        public void RemoveFromListAcUserGroupSet(byte DoorID, byte GroupID)
        {
            lock (SyncUserGroupLocker)
            {
                listAcUserGroupSet.RemoveAt(0);
                //foreach (var item in ListAcUserGroupSet)
                //for (int i = 0; i < listAcUserGroupSet.Count - 1; i++)
                //{
                //    if (listAcUserGroupSet[i].DoorID == DoorID && listAcUserGroupSet[i].GroupID == GroupID)
                //    {
                //        listAcUserGroupSet.Remove(listAcUserGroupSet[i]);
                //        break;
                //    }
                //}
            }
        }
        //HolidaySet
        public AcHolidaySet GetListAcHolidaySet()
        {
            lock (listAcHolidaySet)
            {
                if (listAcHolidaySet == null)
                    return null;
                if (ListAcHolidaySet.Count > 0)
                {
                    return ListAcHolidaySet[0];
                }
                return null;
            }
        }
        public IList<AcHolidaySet> ListAcHolidaySet
        {
            get
            {
                //if (listAcHolidaySet.Count == 0)
                {
                    listAcHolidaySet = syncDataBaseHelper.GetHolidaySetList(this.deviceContext.SlaveSID);
                }
                return listAcHolidaySet;
            }
        }
        public void RemoveFromListAcHolidaySet(byte DoorID, int DoorHoliID)
        {
            lock (listAcHolidaySet)
            {
                listAcHolidaySet.RemoveAt(0);
                //foreach (var item in ListAcHolidaySet)               
                //for (int i = 0; i < listAcHolidaySet.Count - 1; i++)
                //{
                //    if (listAcHolidaySet[i].DoorID == DoorID && listAcHolidaySet[i].DoorHoliID == DoorHoliID)
                //    {

                //        listAcHolidaySet.Remove(listAcHolidaySet[i]);
                //        break;
                //    }
                //}
            }
        }
        public SyncParameter GetSyncDevicePara()
        {
            lock (SyncDevParaLocker)
            {
                return syncDataBaseHelper.GetDeviceParameters(this.deviceContext.SlaveSID);
            }
        }
        //Access Control
        public AcAuthority GetListAcAuthority()
        {
            lock (SyncUserAuthLocker)
            {
                if (ListAcAuthority == null)
                    return null;
                if (ListAcAuthority.Count > 0)
                {

                    return ListAcAuthority[0];
                }

                return null;
            }
        }
        public IList<AcAuthority> ListAcAuthority
        {
            get
            {
                if (listAcAuthority.Count == 0)
                {

                    listAcAuthority = syncDataBaseHelper.GetAuthorityList(this.deviceContext.SlaveSID);
                }
                return listAcAuthority;
            }
        }
        public void RemoveFromListAcAuthority(UInt32 CardID)
        {
            lock (SyncUserAuthLocker)
            {
                listAcAuthority.RemoveAt(0);
                //foreach (var item in ListAcAuthority)
                //for (int i = 0; i < listAcAuthority.Count - 1; i++)
                //{
                //    if (UInt32.Parse(listAcAuthority[i].CardID) == CardID)
                //    {
                //        listAcAuthority.Remove(listAcAuthority[i]);
                //        break;
                //    }
                //}
            }
        }
        public UserInfoAdd GetListUserInfoAdd()
        {
            lock (AddUserLocker)
            {
                if (ListUserInfoAdd == null)
                    return null;
                if (ListUserInfoAdd.Count > 0)
                {
                    return ListUserInfoAdd[0];

                }
                return null;
            }
        }
        public IList<UserInfoAdd> ListUserInfoAdd
        {
            get
            {
                if (listUserAdd.Count == 0)
                {
                    listUserAdd = syncDataBaseHelper.GetUserAddList(this.deviceContext.SlaveSID);
                }
                return listUserAdd;
            }
        }
        public UserInfoDel GetListUserInfoDelete()
        {
            lock (DeleteUserLocker)
            {
                if (ListUserInfoDelete == null)
                    return null;
                if (ListUserInfoDelete.Count > 0)
                {
                    return ListUserInfoDelete[0];

                }
                return null;
            }
        }
        public IList<UserInfoDel> ListUserInfoDelete
        {
            get
            {
                if (listUserDelete.Count == 0)
                {
                    listUserDelete = syncDataBaseHelper.GetUserDeleteList(this.deviceContext.SlaveSID);
                }
                return listUserDelete;
            }
        }

        public UserFingerAdd GetListUserFingersAdd()
        {
            lock (AddUserFingerLocker)
            {
                if (ListUserFingersAdd == null)
                    return null;
                if (ListUserFingersAdd.Count > 0)
                {
                    return ListUserFingersAdd[0];

                }
                return null;
            }
        }
        public IList<UserFingerAdd> ListUserFingersAdd
        {
            get
            {
                if (listUserFingerAdd.Count == 0)
                {
                    listUserFingerAdd = syncDataBaseHelper.GetUserFingerAddList(this.deviceContext.SlaveSID);
                }
                return listUserFingerAdd;
            }
        }
        public UserFingerDel GetListUserFingersDelete()
        {
            lock (DeleteUserFingerLocker)
            {
                if (ListUserFingersDelete == null)
                    return null;
                if (ListUserFingersDelete.Count > 0)
                {
                    return ListUserFingersDelete[0];

                }
                return null;
            }
        }
        public IList<UserFingerDel> ListUserFingersDelete
        {
            get
            {
                if (listUserFingerDelete.Count == 0)
                {
                    listUserFingerDelete = syncDataBaseHelper.GetFingerDeleteList(this.deviceContext.SlaveSID);
                }
                return listUserFingerDelete;
            }
        }
        public void RefreshFingerStatus()
        {
            int UserCount = 0, UserReplicatedCount = 0, UserFingerCount = 0, UserFingerReplicatedCount = 0;
            if (syncDataBaseHelper.GetDeviceReplicatedDetials(this.deviceContext.SlaveSID, ref UserCount, ref UserReplicatedCount, ref UserFingerCount, ref UserFingerReplicatedCount))
            {
                this.deviceContext.FingersCounts = UserFingerCount;
                this.deviceContext.FingersReplicatedCounts = UserFingerReplicatedCount;

            }
        }
        public void RefreshSyncStasus()
        {
            int UserCount = 0, UserReplicatedCount = 0, UserFingerCount = 0, UserFingerReplicatedCount = 0;
            if (syncDataBaseHelper.GetDeviceReplicatedDetials(this.deviceContext.SlaveSID, ref UserCount, ref UserReplicatedCount, ref UserFingerCount, ref UserFingerReplicatedCount))
            {
                this.deviceContext.UserCounts = UserCount;
                this.deviceContext.UserReplicatedCount = UserReplicatedCount;
                this.deviceContext.FingersCounts = UserFingerCount;
                this.deviceContext.FingersReplicatedCounts = UserFingerReplicatedCount;

            }
        }
        public void UpdateDeviceStatus(bool status)
        {
            if (this.deviceContext.OnlineOrNot == status)
                return;
            this.deviceContext.OnlineOrNot = status;
            if (this.deviceContext.DeviceStatusEvent != null)
            {
                if (this.DeviceConnectStatus != (status ? 1 : 0))
                {
                    this.DeviceConnectStatus = (status ? 1 : 0);
                    this.deviceContext.DeviceStatusEvent();
                }
            }


        }
        //public void AddTraceMessage(string message)
        //{
        //    this.deviceContext.PushTraceMessage(message);
        //}
        protected void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Release managed resources

                    try
                    {
                        if (syncClient != null)
                        {
                            syncClient.Dispose();
                            syncDataBaseHelper.Dispose();
                        }
                        if (Client != null && Client.IsConnected)
                        {
                            Client.Disconnect(); /// All Error state Contolled by itshelf Client Object 
                            Client = null;
                        }
                    }
                    catch
                    {
                    }
                }
                // Release unmanaged resources
                m_disposed = true;
            }
        }
        ~Terminal()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            //.NET Framework 类库
            // GC..::.SuppressFinalize 方法
            //请求系统不要调用指定对象的终结器。
            GC.SuppressFinalize(this);
        }
    }
    
#region struct 
    //public struct UserInfoAdd
    //{
    //    char  CardSnLen;
    //    char[] CardSn;  //15
    //    int   CardSn;
    //    int UserSID;
    //    Byte Group12;
    //    Byte Group34;
    //    char[] Valid_Data;   //7
    //    char[] UserPwd; //7   	
    //    char[] UserName;  //65 
    //    char[] UserNo;   //13           
    //    char[] DepartmentId;
    //    int FingerPrint1;
    //    int FingerPrint2;
    //    int StartTime;
    //    int EndTime;
    //}
    //public struct UserInfoDel
    //{
    //    char CardSnLen { get; set; }
    //    char[] CardSn { get; set; } //15
    //    int CardSn { get; set; }    
    //}
    //public struct UserFingerAdd
    //{
    //}
#endregion

}
