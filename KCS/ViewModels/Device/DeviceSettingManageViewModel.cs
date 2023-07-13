using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using KCS.Sync;
using KCS.Common.Utils;
using KCS.Common;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using KCS.Views;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class DeviceSettingManageViewModel
    {
        private Devices _Device = new Devices();
        public static DeviceSettingManageViewModel Create()
        {

            return ViewModelSource.Create(() => new DeviceSettingManageViewModel());
        }
        protected IDialogService DialogService
        {
            get { return this.GetService<IDialogService>(); }
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }
        public object TransactionssDataSet
        {
            get
            {
                return SyncManage.TransactionsLists();
            }
        }
        
        public object DevicesDataSet
        {
            get
            {
                return SyncManage.GetDeviceLists();
            }
        }
        public virtual Devices SelectedDevice
        {
            get
            {

                return _Device;
            }

            set
            {
                _Device = value;
            }
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<DeviceSettingManageViewModel>(this));
        }
        public void Edit(object deviceObject)
        {
            var deviceEditViewModel = DeviceEditViewModel.Create(deviceObject as Devices);
            deviceEditViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("DeviceEdit", deviceEditViewModel);
            document.Show();
        }
        public void ResyncAcParameters(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsResetDevice"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var device = deviceObject as Devices;
            if (DevicesDataSource.ResetAccessParameters(device.SlaveSID))
            {
                //SyncManage.(device);
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ResyncAcParasOk"));
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ResyncAcParasFailed"));
            }
        }
        public void RebootIDF211(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var device = deviceObject as Devices;
            device.RebootDeviceFlag = true;
         }
        public void RebootDevice(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var device = deviceObject as Devices;
            FileStream fs = new FileStream(".\\SYSConfiguration.txt", FileMode.Create);
            byte[] data = System.Text.Encoding.Default.GetBytes("DWONLOAD"); 
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
            FtpHelper.Instance.Upload("AIDCzhangyungang", "zyg810228", ".\\SYSConfiguration.txt", string.Format("ftp://{0}//FlashDisk//", device.IP));
            Thread.Sleep(2000);
            FtpHelper.Instance.Delete("AIDCzhangyungang", "zyg810228", string.Format("ftp://{0}//FlashDisk//", device.IP), "SYSConfiguration.txt");
        }
        public void NewDevice()
        {
            var deviceNewViewModel = NewDeviceViewModel.Create();
            deviceNewViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("NewDevice", deviceNewViewModel);
            document.Show();
        }
        public void DeleteDevice(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsDeleteItems"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var device = deviceObject as Devices;
            if (DevicesDataSource.DeleteDevice(device))
            {
                SyncManage.DeleteDevice(device);
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteDeviceFailed"));
            }
        }
        public void EnableDevice(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsEnableDevice"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var device = deviceObject as Devices;
            if (DevicesDataSource.EnableDevice(device.SlaveSID))
            {
                SyncManage.EnableDevice(device);
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("EnableDeviceFailed"));
            }
        }
        public void DisableDevice(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsDisableDevice"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var device = deviceObject as Devices;
            if (DevicesDataSource.DisableDevice(device.SlaveSID))
            {
                SyncManage.DisableDevice(device);
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DisableDeviceFailed"));
            }
        }
        public void ResetDevice(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsResetDevice"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var device = deviceObject as Devices;
            if (DevicesDataSource.ResetDevice(device.SlaveSID))
            {
                //SyncManage.(device);
                device.ResetToDefault = true;
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DisableDeviceFailed"));
            }
        }
        public void DeviceSyncSetting(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var device = deviceObject as Devices;
            var deviceSyncSettingViewModel = DeviceSyncSettingViewModel.Create(device);
            deviceSyncSettingViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("DeviceSyncSetting", deviceSyncSettingViewModel);
            document.Show();
        }
        public void DeviceCategorySet()
        {
            var document = DocumentManagerService.CreateDocument("DeviceCategory", DeviceCategoryViewModel.Create());
            document.Show();
        }
        public void SearchDevice()
        {
            NetSockets.NetUtility.BroadCastToAllDevices();
            var searDeviceViewModel = FindDeviceViewModel.Create();
            searDeviceViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("FindDevice", searDeviceViewModel);
            document.Show();
        }
        public void SetOpenDoorPin(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var selDevice = deviceObject as Devices;
            var setOpenDoorPinViewModel = SetOpenDoorPinViewModel.Create(selDevice.SlaveSID);
            setOpenDoorPinViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("SetOpenDoorPin", setOpenDoorPinViewModel);
            document.Show();
           

        }
        public void OpenDoor(object deviceObject)
        {
            var DevicesList = DevicesDataSet as List<Devices>;
            if (DevicesList == null || DevicesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (deviceObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            //if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsResetDevice"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
             //   return;
            var device = deviceObject as Devices;
            SyncManage.OpenDoor(device.SlaveSID);
        }
        public void SetDevice()
        {
            var document = DocumentManagerService.CreateDocument("SetDeviceParameters", SetDeviceParametersViewModel.Create());
            document.Show();
        }
        public void ReReadTransactions()
        {
            ReadTransAgainViewModel ReReadTransViewModel = ReadTransAgainViewModel.Create();
            if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("ReReadTransactions"), "ReadTransAgain", ReReadTransViewModel))
            {
                if (ReReadTransViewModel.SelectionDevices == null)
                    return;

               
                foreach (var SelDevice in ReReadTransViewModel.SelectionDevices)
                {
                    if (SelDevice != null)
                    {
                        SyncManage.ReReadDeviceTrans(SelDevice.SlaveSID, ReReadTransViewModel.StartDate, ReReadTransViewModel.EndDate, ReReadTransViewModel.StartTime, ReReadTransViewModel.EndTime);
                    }
                }
            }
        }
        
    }
}