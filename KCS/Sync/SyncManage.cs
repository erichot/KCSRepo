using KCS.Common.DAL;
using KCS.Common.Utils;
using KCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Sync
{
    public class SyncManage
    {
        static IList<Devices> deviceList = new List<Devices>();
        public static IList<AcTimeZone> TimeZoneList = new List<AcTimeZone>();
        public static IList<AcTimeSet> TimeFrameList = new List<AcTimeSet>();
        public static IList<AcUserGroupSet> UserGroupList = new List<AcUserGroupSet>();
        public static IList<AcUserGroupSet> UserGroupListBack = new List<AcUserGroupSet>();
        protected static Dictionary<int, Terminal> TerminalList = new Dictionary<int, Terminal>();
        public static SyncServer SyncServerTask = new SyncServer();
        private static IList<RegDevice> regDeviceList = new List<RegDevice>();
        public static IList<EmployeeJobCode> JobCodeList = new List<EmployeeJobCode>();
        protected static Dictionary<int, string> JobCodeDic = new Dictionary<int, string>();
        //public static AddTratnsactionDelegate AddTransactionEvent;
        //public static DeviceStatusDelegate DeviceStatusEvent;
        //public static DeviceGetFingerDelegate DeviceGetFingerEvent;

        public static void RegisterDevice(string devicetype,string deviceversion,int id, string ip)
        {
            RegDevice regDevice = new RegDevice(devicetype, deviceversion,id, ip);
            if (!regDeviceList.Contains(regDevice))
            {
                regDeviceList.Add(regDevice);
            }
        }
        public static IList<RegDevice> GetRegisterDevices()
        {
            return regDeviceList;
        }
        public static void InitAccessParameters()
        {
            InitTimeFrame();
            InitTimeZone();
            InitUserGroup();
        }
        public static void InitDataSync()
        {
            JobCodeList = EmployeesDataSource.GetJobCodeList();
            try
            {
                foreach (EmployeeJobCode jobCode in JobCodeList)
                {
                    JobCodeDic.Add(jobCode.TranType, jobCode.JobName);

                }
            }
            catch
            {
            }
            deviceList =  DevicesDataSource.GetDevicesList();
            if (deviceList == null)
                return;
            foreach (Devices device in deviceList)
            {
                Terminal teminal = new Terminal(device);
                BridgeUtility.AddTerminalToList(teminal);
                TerminalList.Add(device.SlaveSID,teminal);
            }
            
            SyncServerTask.StartServerApplication();
        }
        public static string GetJobCodeName(int JobCode)
        {
            try
            {
                return JobCodeDic[JobCode];

            }
            catch
            {
                return "";
            }
        }
        public static void ExportTransToTxT(Transactions transaction)
        {
            if (SystemConfigure.ExportToTxtOrNot == 1)
            {//导出文件
                try
                {
                    if (SystemConfigure.slavesList.Contains(transaction.SlaveId))
                    {
                        ExportData exportData = new ExportData();
                        exportData.ExportDataToTxt(transaction);
                    }
                }
                catch
                {
                }

            }
        }
        public static void StopServerApplication()
        {
            BridgeUtility.ReleaseAllDevice();
            SyncServerTask.Dispose();
        }
        public static Terminal GetTerminalByID(int slaveId)
        {
            try{
                if (!TerminalList[slaveId].deviceContext.IsServerMode)
                    return null;
                
                return TerminalList[slaveId];
            }
            catch{
                return null;
            }
        }
        
        public static Terminal GetTerminalByIP(string slaveIp)
        {
            return TerminalList.FirstOrDefault(f => f.Value.deviceContext.IP == slaveIp).Value;
        }
        public static void RefreshDeviceSyncStatus()
        {
            BridgeUtility.RefreshTerminalSyncStasus();
        }
        public static void RefreshDeviceFingerStatus()
        {
            BridgeUtility.RefreshDeviceFingerStatus();
        }
        //public static void RefreshTimeFrameSet()
        //{
        //    BridgeUtility.RefreshTimeFrameSet();
        //}
        //public static void RefreshTimeZoneSet()
        //{
        //    BridgeUtility.RefreshTimeZoneSet();
        //}
        //public static void RefreshHolidaySet()
        //{
        //    BridgeUtility.RefreshHolidaySet();
        //}
        //public static void RefreshUserGroupSet()
        //{
        //    BridgeUtility.RefreshUserGroupSet();
        //}
        
        public static IList<Transactions> TransactionsLists()
        {
            return BridgeUtility.GetReadTransactionsLists();
        }
        public static void AddDevice(Devices device)
        {
            //if (AddTransactionEvent != null)
            //{
            //    device.AddTransactionEvent += AddTransactionEvent;
            //}
            //if (DeviceStatusEvent != null)
            //{
            //    device.DeviceStatusEvent += DeviceStatusEvent;
            //}
            //if (DeviceGetFingerEvent != null)
            //{
            //    device.DeviceGetFingerEvent += DeviceGetFingerEvent;
            //}
            Terminal newTerminal = new Terminal(device);
            newTerminal.RefreshFingerStatus();
            newTerminal.RefreshSyncStasus();
            deviceList.Add(device);
            BridgeUtility.AddTerminalToList(newTerminal);
            TerminalList.Add(device.SlaveSID, newTerminal);
            //if (newTerminal.deviceContext.DeviceStatusEvent != null)
            //    newTerminal.deviceContext.DeviceStatusEvent();
        }
        public static void UpdateDevice(Devices device)
        {
            BridgeUtility.UpdateTerminal(device);
        }
        public static void DeleteDevice(Devices device )
        {
            TerminalList.Remove(device.SlaveSID);
            deviceList.Remove(device);
            BridgeUtility.DeleteTerminal(device);
        }
        public static void EnableDevice(Devices device)
        {
            device.IsEnabled = true;
            BridgeUtility.RefreshTerminal(device);
        }
        public static void DisableDevice(Devices device)
        {
            device.IsEnabled = false;
            BridgeUtility.RefreshTerminal(device);
        }
        public static DoorPIN GetOpenDoorPin(int deviceSid)
        {
            return BridgeUtility.GetOpenDoorPin(deviceSid);
        }
        public static bool SetOpenDoorPin(int deviceSid,DoorPIN pin)
        {
            return BridgeUtility.SetOpenDoorPin(deviceSid, pin);
        }
        public static void SetOpenDoorPinOk(int deviceSid)
        {
            BridgeUtility.SetOpenDoorPinOk(deviceSid);
        }
        public static void OpenDoor(int deviceSid)
        {
            BridgeUtility.OpenDoor(deviceSid);
        }
        public static void ReReadDeviceTrans(int deviceSid, DateTime dateStart, DateTime dateEnd, DateTime timeStart, DateTime timeEnd)
        {
            BridgeUtility.ReReadDeviceTrans(deviceSid, dateStart, dateEnd, timeStart, timeEnd);
        }
        public static IList<Devices> GetDeviceLists()
        {
            return deviceList;
        }
        private static void InitUserGroup()
        {
            UserGroupList.Add(new AcUserGroupSet(1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
            UserGroupList.Add(new AcUserGroupSet(1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
            for (byte i = 2; i < 16; i++)
            {
                UserGroupList.Add(new AcUserGroupSet(1, i, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63));
            }
            IList<AcUserGroupSet> userGroupListDB = AccessControlDataSource.GetUserGroupList();
            foreach (AcUserGroupSet UserGroupSet in UserGroupList)
            {
                foreach (AcUserGroupSet UserGroupSetDb in userGroupListDB)
                {
                    if (UserGroupSet.GroupID == UserGroupSetDb.GroupID)
                    {
                        UserGroupSet.Sun = UserGroupSetDb.Sun;
                        UserGroupSet.Mon = UserGroupSetDb.Mon;
                        UserGroupSet.Tue = UserGroupSetDb.Tue;
                        UserGroupSet.Wed = UserGroupSetDb.Wed;
                        UserGroupSet.Thu = UserGroupSetDb.Thu;

                        UserGroupSet.Fri = UserGroupSetDb.Fri;
                        UserGroupSet.Sat = UserGroupSetDb.Sat;
                        UserGroupSet.Holi1Group = UserGroupSetDb.Holi1Group;
                        UserGroupSet.Holi2Group = UserGroupSetDb.Holi2Group;
                        UserGroupSet.Holi3Group = UserGroupSetDb.Holi3Group;

                        UserGroupSet.Holi4Group = UserGroupSetDb.Holi4Group;
                        UserGroupSet.Holi5Group = UserGroupSetDb.Holi5Group;
                        UserGroupSet.Holi6Group = UserGroupSetDb.Holi6Group;
                        UserGroupSet.Holi7Group = UserGroupSetDb.Holi7Group;
                        UserGroupSet.Holi8Group = UserGroupSetDb.Holi8Group;
                    }
                }

                UserGroupListBack.Add(new AcUserGroupSet(UserGroupSet));
            }
        }
        public static void RefreshUserGroupListBack()
        {
            UserGroupListBack.Clear();
            foreach (AcUserGroupSet UserGroupSet in UserGroupList)
            {
                UserGroupListBack.Add(new AcUserGroupSet(UserGroupSet));
            }
        }
        private static void InitTimeFrame()
        {


            TimeFrameList.Add(new AcTimeSet(1, 0, 0, 0, 0, 0, LanguageResource.GetDisplayString("TimeSetNoPassing")));
            for (byte i = 1; i < 31; i++)
            {
                TimeFrameList.Add(new AcTimeSet(1, i, 0, 0, 0, 0, ""));
            }
            TimeFrameList.Add(new AcTimeSet(1, 31, 0, 0, 23, 59, LanguageResource.GetDisplayString("TimeSet24HoursPassing")));

            IList<AcTimeSet> timeFrameList = AccessControlDataSource.GetTimeFrameList();
            foreach (AcTimeSet TimeSet in TimeFrameList)
            {
                foreach (AcTimeSet TimeSetDb in timeFrameList)
                {
                    if (TimeSet.TimeSetID == TimeSetDb.TimeSetID)
                    {
                        TimeSet.StartHour = TimeSetDb.StartHour;
                        TimeSet.StartMin = TimeSetDb.StartMin;
                        TimeSet.EndHour = TimeSetDb.EndHour;
                        TimeSet.EndMin = TimeSetDb.EndMin;
                        TimeSet.Description = TimeSetDb.Description;
                    }
                }
            }
        }
        private static void InitTimeZone()
        {
            for (byte i = 0; i < 63; i++)
            {
                TimeZoneList.Add(new AcTimeZone(1, i, 31, 0, 0, 0, ""));
            }
            TimeZoneList.Add(new AcTimeZone(1, 63, 0, 0, 0, 0, ""));
            IList<AcTimeZone> timeZoneList = AccessControlDataSource.GetTimeZoneList();
            foreach (AcTimeZone TimeZone in TimeZoneList)
            {
                foreach (AcTimeZone TimeZoneDb in timeZoneList)
                {
                    if (TimeZone.TimeZoneID == TimeZoneDb.TimeZoneID)
                    {
                        TimeZone.Frame01 = TimeZoneDb.Frame01;
                        TimeZone.Frame02 = TimeZoneDb.Frame02;
                        TimeZone.Frame03 = TimeZoneDb.Frame03;
                        TimeZone.Frame04 = TimeZoneDb.Frame04;
                        TimeZone.Description = TimeZoneDb.Description;
                    }
                }
            }

        }

    }
}
