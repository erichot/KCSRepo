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
    public class DeviceSyncSettingViewModel : KcsDocument 
    {
        private Devices SettingDevice;
        public virtual int RecordCount { get; set; }
        public IList<EmployeeSync> EmployeesSyncStatusDataSet { get; set; }
        private IList<EmployeeSync> EmployeesSyncStatusBack;
        private IList<EmployeeSync> EmployeesSyncStatus;
        public virtual EmployeeSync SelectedEmployee { get; set; }
        private object bEmployeeSelect = false;

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public virtual object IsActive
        {
            get
            {
                return bEmployeeSelect;
            }
        }

        public static DeviceSyncSettingViewModel Create()
        {
            return ViewModelSource.Create(() => new DeviceSyncSettingViewModel());
        }
        public static DeviceSyncSettingViewModel Create(Devices device)
        {

            return ViewModelSource.Create(() => new DeviceSyncSettingViewModel(device));
        }
         protected DeviceSyncSettingViewModel()
        {
            EmployeesSyncStatus = new List<EmployeeSync>();
            SettingDevice = new Devices();
        }
         protected DeviceSyncSettingViewModel(Devices device)
        {
            EmployeesSyncStatus = new List<EmployeeSync>();
            SettingDevice = new Devices(device);
            EmployeesSyncStatus = DevicesDataSource.GetDevicesSyncStatus(SettingDevice.SlaveSID);
            RecordCount = EmployeesSyncStatus.Count;
            EmployeesSyncStatusBack = new List<EmployeeSync>();
            foreach (var employee in EmployeesSyncStatus)
                EmployeesSyncStatusBack.Add(new EmployeeSync(employee));
            EmployeesSyncStatusDataSet = EmployeesSyncStatus;
        }
         protected void OnRecordCountChanged()
         {
             Messenger.Default.Send(new UpdateCountMessage<DeviceSyncSettingViewModel>(this, RecordCount));
             
         }
         public void Save()
         {
             if (MessageService.ShowMessage(LanguageResource.GetDisplayString("SyncSettingForSelectedDevice"), "", MessageButton.YesNo) != MessageResult.Yes)
                 return;
             if (DevicesDataSource.UpdateDeviceSyncSetting(SettingDevice.SlaveSID,EmployeesSyncStatusBack, EmployeesSyncStatus))
             {
                 Close();
             }
             else
             {
                 MessageService.ShowMessage(LanguageResource.GetDisplayString("SyncSettingForSelectedDeviceFailed"));
                 EmployeesSyncStatus = DevicesDataSource.GetDevicesSyncStatus(SettingDevice.SlaveSID);
                 EmployeesSyncStatusDataSet = EmployeesSyncStatus;
             }
         }
    }
}