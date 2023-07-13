using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.ComponentModel;
using KCS.Common.Utils;
using KCS.Sync;

namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class DeviceEditViewModel : KcsDocument
    {
        private Devices backupEditDevice;
        public virtual Devices EditDevice { get; set; }
        public static DeviceEditViewModel Create()
        {

            return ViewModelSource.Create(() => new DeviceEditViewModel());
        }
        public static DeviceEditViewModel Create(Devices device)
        {

            return ViewModelSource.Create(() => new DeviceEditViewModel(device));
        }
        protected DeviceEditViewModel()
        {
                        
        }
        protected DeviceEditViewModel(Devices device)
        {
            backupEditDevice = new Devices(device);
            EditDevice = device;// new Devices(device);
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public object DeviceCategoryDataSet
        {
            get
            {
                return DevicesDataSource.GetDeviceCategoryList();
            }
        }
        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = EditDevice as IDataErrorInfo;

            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }
        bool IsRightIP(string ip)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(ip, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
            {
                string[] ips = ip.Split('.');
                if (ips.Length == 4 || ips.Length == 6)
                {
                    if (System.Int32.Parse(ips[0]) < 256 && System.Int32.Parse(ips[1]) < 256 & System.Int32.Parse(ips[2]) < 256 & System.Int32.Parse(ips[3]) < 256)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
        public void Save()
        {
            if (!HasValidationErrors())
            {
                if (EditDevice.IsServerMode)
                {
                    if (!IsRightIP(EditDevice.IP))
                    {
                        MessageService.ShowMessage(LanguageResource.GetDisplayString("IPIsNecessary"));
                        return ;
                    }
                }
                int iRet = DevicesDataSource.UpdateDevice(EditDevice);
                if (iRet == 1)
                {
                    SyncManage.UpdateDevice(EditDevice);
                    RebindDataSource();
                    Close();
                }
                else if (iRet == -2)
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("ExisitedSlaveIP"));
                }
                else
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateDeviceFailed"));
                }
            }
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<DeviceSettingManageViewModel>(this.GetParentViewModel<DeviceSettingManageViewModel>()));
        }
    }
}