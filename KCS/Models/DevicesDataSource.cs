using KCS.Common.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    class DevicesDataSource
    {
        static public IList<DeviceBrief> GetDeviceBriefList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetDeviceBriefList();
            return KCS.Common.Utils.ModelConvertHelper<DeviceBrief>.ConvertToModel(dt);

        }
        static public IList<DeviceBase> GetDeviceBaseList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetDeviceBaseList();
            return KCS.Common.Utils.ModelConvertHelper<DeviceBase>.ConvertToModel(dt);

        }
        
        static public IList<DeviceBrief> GetDeviceBriefDataList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetDeviceBriefDataList();
            return KCS.Common.Utils.ModelConvertHelper<DeviceBrief>.ConvertToModel(dt);

        }
        
        static public IList<Devices> GetDevicesList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetDevicesList();
            return KCS.Common.Utils.ModelConvertHelper<Devices>.ConvertToModel(dt);

        }
        static public IList<DeviceInfo> GetDevicesInofList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetDevicesInfoList();
            return KCS.Common.Utils.ModelConvertHelper<DeviceInfo>.ConvertToModel(dt);

        }
        static public IList<DeviceInfo> GetDevicesSyncStatus(string CardID)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetEmployeesSyncStatus(CardID);
            return KCS.Common.Utils.ModelConvertHelper<DeviceInfo>.ConvertToModel(dt);

        }
        static public IList<EmployeeSync> GetDevicesSyncStatus(int SlaveSID)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetDevicesSyncStatus(SlaveSID);
            return KCS.Common.Utils.ModelConvertHelper<EmployeeSync>.ConvertToModel(dt);

        }
        static public IList<SlaveCategory> GetDeviceCategoryList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetDeviceCategoryList();
            return KCS.Common.Utils.ModelConvertHelper<SlaveCategory>.ConvertToModel(dt);
        }
        static public bool AddDeviceCategory(ISlaveCategory slaveCategory)
        {
            return KCSDatabaseHelper.Instance.AddDeviceCategory(slaveCategory);
        }
        static public bool DeleteDeviceCategory(ISlaveCategory slaveCategory)
        {
            return KCSDatabaseHelper.Instance.DeleteDeviceCategory(slaveCategory);
        }
        static public int GetSalveSID()
        {
            return KCSDatabaseHelper.Instance.GetSalveSID();
        }
        static public bool ResetAccessParameters(int SlaveSID)
        {
            return KCSDatabaseHelper.Instance.ResetAccessParameters(SlaveSID);
        }
        static public bool DeleteDevice(Devices device)
        {
            return KCSDatabaseHelper.Instance.DeleteDevice(device);
        }
        static public bool EnableDevice(int SlaveSID)
        {
            return KCSDatabaseHelper.Instance.EnableDevice(SlaveSID);
        }
        static public bool DisableDevice(int SlaveSID)
        {
            return KCSDatabaseHelper.Instance.DisableDevice(SlaveSID);
        }
        static public bool ResetDevice(int SlaveSID)
        {
            return KCSDatabaseHelper.Instance.ResetDevice(SlaveSID);
        }
        
        static public int UpdateDevice(Devices device)
        {
            return KCSDatabaseHelper.Instance.UpdateDevice(device);
        }
        static public int NewDevice(Devices device)
        {
            return KCSDatabaseHelper.Instance.AddDevice(device);
        }
        static public bool UpdateDeviceSyncSetting(int SlaveId, IList<EmployeeSync> backSyncList, IList<EmployeeSync> SyncList)
        {
            return KCSDatabaseHelper.Instance.UpdateDeviceSyncSetting(SlaveId, backSyncList, SyncList);
        }

        static public bool UpdateDeviceParameters(IEnumerable<DeviceBrief> deviceList, string menuPwd,int workMode,int language)
        {
            return KCSDatabaseHelper.Instance.UpdateDeviceParameters(deviceList, menuPwd, workMode, language);
        }
    }
}
