using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.ComponentModel;
using KCS.Common.Utils;
using KCS.Sync;
using System.ComponentModel.DataAnnotations;

namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class NewDeviceViewModel : KcsDocument
    {
        public virtual Devices NewDevices { get; set; }

        

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public static NewDeviceViewModel Create()
        {

            return ViewModelSource.Create(() => new NewDeviceViewModel());
        }
        public static NewDeviceViewModel Create(int id, string ip)
        {

            return ViewModelSource.Create(() => new NewDeviceViewModel(id,ip));
        }
        protected NewDeviceViewModel()
        {
            NewDevices = new Devices();
            NewDevices.SlaveSID = DevicesDataSource.GetSalveSID();
            
        }
        protected NewDeviceViewModel(int id,string ip)
        {
            NewDevices = new Devices();

            NewDevices.SlaveSID = id != 0? id:DevicesDataSource.GetSalveSID();
            NewDevices.IP = ip;

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
            IDataErrorInfo dataErrorInfo = NewDevices as IDataErrorInfo;
            
            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<DeviceSettingManageViewModel>(this.GetParentViewModel<DeviceSettingManageViewModel>()));
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
        private bool SaveDevice()
        {
            
            
            if (!HasValidationErrors())
            {
                if (NewDevices.IsServerMode)
                {
                    if (!IsRightIP(NewDevices.IP))
                    {
                        MessageService.ShowMessage(LanguageResource.GetDisplayString("IPIsNecessary"));
                        return false;
                    }
                }
                
               
                string ErrorText = "";
                int iRet = DevicesDataSource.NewDevice(NewDevices);
                if (iRet == 0)
                {
                    ShowNotification(LanguageResource.GetDisplayString("NewDeviceOk"));
                    SyncManage.AddDevice(NewDevices);
                    RebindDataSource();
                    return true;
                }
                else if (iRet == -1)
                {
                    ErrorText = LanguageResource.GetDisplayString("ExisitedSlaveId");
                }
                else if (iRet == -2)
                {
                    ErrorText = LanguageResource.GetDisplayString("ExisitedSlaveIP");
                }
                else
                {
                    ErrorText = LanguageResource.GetDisplayString("NewDeviceFailed");
                }
                MessageService.ShowMessage(ErrorText);
            }
            return false;
        }
        public void Save()
        {

            SaveDevice();
        }

        public void SaveAndClose()
        {
            if (SaveDevice())
            {
                Close();
            }
            

        }
        public void SaveAndNew()
        {

            if (SaveDevice())
            {
                NewDevices = new Devices();
                NewDevices.SlaveSID = DevicesDataSource.GetSalveSID();
            }
        }
        protected INotificationService INotificationService
        {
            // using the GetService<> extension method for obtaining service instance
            get { return this.GetService<INotificationService>(); }
        }
        public virtual INotification Notification
        {
            get;
            set;
        }
        protected virtual void OnNotificationChanged()
        {
            this.RaiseCanExecuteChanged(x => x.HideNotification());
        }

        public void ShowNotification(string strTip)
        {
            // using the INotificationService.CreatePredefinedNotification method
            Notification = INotificationService.CreatePredefinedNotification(strTip, "", "");

            // using the INotification.ShowAsync method
            Notification.ShowAsync();
        }
        public void HideNotification()
        {
            // using the INotification.Hide method
            Notification.Hide();

        }
        public bool CanHideNotification()
        {
            return Notification != null;
        }
    }
}