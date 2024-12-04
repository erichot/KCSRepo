using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.ComponentModel;
using KCS.Common.Utils;
using KCS.Common.DAL.Constants;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace KCS.ViewModels
{
   [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class NewEmployeeViewModel : KcsDocument
    {
       List<DeviceInfo> DeviceList = new List<DeviceInfo>();
        public static NewEmployeeViewModel Create()
        {

            return ViewModelSource.Create(() => new NewEmployeeViewModel());
        }
        protected NewEmployeeViewModel()
        {
            NewEmployee = new Employees();
        }

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
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
        public virtual Employees NewEmployee { get; set; }
        public virtual int SyncSetting { get; set; }
        public virtual IEnumerable<DeviceInfo> SelectionDevices
        {
            get
            {
                return DeviceList;
            }
            set
            {
                
                DeviceList.Clear();
                foreach (DeviceInfo device in value)
                    DeviceList.Add(new DeviceInfo(device));
            }
        }
        public object DeviceInfoDataSet {
            get 
            {
                return DevicesDataSource.GetDevicesInofList();
            }
        }
        public object DepartmentInfoDataSet
        {
            get
            {
                return DepartmentListSource.GetDepartmentListField();
            }
        }
        public object EmployeesTypeInfoDataSet
        {
            get
            {
                return EmployeesTypeDataSource.GetEmployeesTypeInfoList();
            }
        }

        // Date:    2024/12/03
        // Ver:     1.1.6.4
        public virtual int DefaultAllowTimeSelection { get; set; }


        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<EmployeeViewModel>(this.GetParentViewModel<EmployeeViewModel>()));
        }
        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = NewEmployee as IDataErrorInfo;
            //bool bRet = IDataErrorInfoHelper.HasErrors(dataErrorInfo);
            //string errorText = dataErrorInfo["UserSID"];
            //errorText = dataErrorInfo["UserID"];
            //errorText = dataErrorInfo["DepartmentID"];
            //errorText = dataErrorInfo["DepartmentName"];
            //errorText = dataErrorInfo["UserName"];
            //errorText = dataErrorInfo["CardID"];
            //errorText = dataErrorInfo["TitleName"];
            //errorText = dataErrorInfo["Email"];
            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }
        public void SetEmployeePhoto(string photo)
        {
            NewEmployee.RegPhoto = photo;
        }
        private bool SaveEmployee()
        {
            // Date:    2024/12/03
            // Ver:     1.1.6.4
            bool? IsDisallowFullTime = false;
            if (DefaultAllowTimeSelection == 1)
                IsDisallowFullTime = true;


            if (!HasValidationErrors())
            {
                string ErrorText = "";
                
                DataBaseAccessErrorCode iRet = EmployeesDataSource.NewEmployee(NewEmployee, SyncSetting == 0, DeviceList, IsDisallowFullTime);
                if (iRet == DataBaseAccessErrorCode.Success)
                {
                    ShowNotification(LanguageResource.GetDisplayString("NewEmployeeOk"));
                    RebindDataSource();
                    return true;
                }
                else if (iRet == DataBaseAccessErrorCode.ExisitedCardId)
                {
                    ErrorText = LanguageResource.GetDisplayString("ExisitedCardId");
                }
                else if (iRet == DataBaseAccessErrorCode.ExisitedUserId)
                {
                    ErrorText = LanguageResource.GetDisplayString("ExisitedUserId");
                }
                else
                {
                    ErrorText = LanguageResource.GetDisplayString("NewEmployeeFailed");
                }
                MessageService.ShowMessage(ErrorText);
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NewEmployeeFailedInput"));
            }
            return false;
        }
        public void Save()
        {
            SaveEmployee();
        }
       
        public void SaveAndClose()
        {

            if (SaveEmployee())
            {
                Close();
            }
            
        }
        public void SaveAndNew()
        {
            if (SaveEmployee())
            {
                NewEmployee = new Employees();
            }
            
        }

        public void SelectPhoto()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            //dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.ValidateNames = true;
            //验证路径有效性
            dlg.CheckFileExists = true;
            //验证文件有效性
            dlg.CheckPathExists = true;

            dlg.Filter = "Image Files(*.JPG;*.jpeg)|*.JPG;*.jpeg|All files(*.*)|*.*";

            if (dlg.ShowDialog() != DialogResult.OK)
            {
               return;
            }
            NewEmployee.RegPhoto = dlg.FileName;
            Image imge = Image.FromFile(NewEmployee.RegPhoto);
            Bitmap bm = new Bitmap(imge, 274, 303);
            NewEmployee.EmpPhoto = bm;


         }


    }
}