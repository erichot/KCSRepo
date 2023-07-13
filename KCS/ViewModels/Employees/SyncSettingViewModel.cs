using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class SyncSettingViewModel : KcsDocument 
    {
        private Employees SettingEmployee;
        private IList<DeviceInfo> DeviceSyncStatusBack;
        private IList<DeviceInfo> DeviceSyncStatus;
        private DeviceInfo _SelectDevice = new DeviceInfo();
        private object bDeviceSelect = false;
        public static SyncSettingViewModel Create()
        {
            return ViewModelSource.Create(() => new SyncSettingViewModel());
        }
        public static SyncSettingViewModel Create(Employees employee)
        {
            
            return ViewModelSource.Create(() => new SyncSettingViewModel(employee));
        }
        protected SyncSettingViewModel()
        {
            DeviceSyncStatus = new List<DeviceInfo>();
            SettingEmployee = new Employees();
        }
        protected SyncSettingViewModel(Employees employee)
        {
            DeviceSyncStatus = new List<DeviceInfo>();
            SettingEmployee = new Employees(employee);
            IList<DeviceInfo> deviceSyncStatusList = DevicesDataSource.GetDevicesSyncStatus(SettingEmployee.CardID);
            RecordCount = deviceSyncStatusList.Count;
            DeviceSyncStatusBack = new List<DeviceInfo>();
            foreach (var deviceInfo in deviceSyncStatusList)
                DeviceSyncStatusBack.Add(new DeviceInfo(deviceInfo));
            DeviceSyncStatus = new List<DeviceInfo>(deviceSyncStatusList);
            DeviceSyncStatusDataSet = DeviceSyncStatus;
            if (DeviceSyncStatus.Count > 0)
            {
                SelectedDevice = DeviceSyncStatus[0];
                bDeviceSelect = DeviceSyncStatus[0].IsSyncOrNot;
            }
            
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }

        public virtual int RecordCount { get; set; }
        public IList<DeviceInfo> DeviceSyncStatusDataSet { get; set; }
        //{
        //    get
        //    {
        //        IList<DeviceInfo> deviceSyncStatusList = DevicesDataSource.GetDevicesSyncStatus(SettingEmployee.CardID);
        //        RecordCount = deviceSyncStatusList.Count;
        //        DeviceSyncStatusBack = new List<DeviceInfo>(deviceSyncStatusList);
        //        DeviceSyncStatus = new List<DeviceInfo>(deviceSyncStatusList);
              
        //        return deviceSyncStatusList;
        //    }
        //}
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<SyncSettingViewModel>(this, RecordCount));
        }
        public virtual object  SyncOrNot { 
            get{
                return bDeviceSelect;
            }
            
            set{
                bDeviceSelect = value ;
                foreach (DeviceInfo device in DeviceSyncStatus)
                {
                    if (device != null && SelectedDevice != null)
                    {
                        if (device.SlaveSID == SelectedDevice.SlaveSID)
                        {
                            device.IsSyncOrNot = Convert.ToBoolean(value);
                            break;
                        }
                    }
                }
            }
        }
        public virtual DeviceInfo SelectedDevice { get; set; }
        //{
        //    get
        //    {
        //        return _SelectDevice;
        //    }
            
        //    set
        //    {
        //        _SelectDevice = value;
        //        foreach (DeviceInfo device in DeviceSyncStatus)
        //        {
        //            if (device != null)
        //            {
        //                if (device.SlaveSID == value.SlaveSID)
        //                {
        //                    device.IsSyncOrNot = value.IsSyncOrNot;
        //                    break;
        //                }
        //            }
        //        }


        //    }
        //}
        public void Save()
        {
            if (DeviceSyncStatus.Count <= 0)
            {
                Close();
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("SyncSettingForSelectedEmployee"), "", MessageButton.YesNo) != MessageResult.Yes)
                return;
            if (EmployeesDataSource.UpdateSyncSetting(SettingEmployee, DeviceSyncStatusBack, DeviceSyncStatus))
            {
                Close();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SyncSettingForSelectedEmployeeFailed"));
            }
        }
    }
}