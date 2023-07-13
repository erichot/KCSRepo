using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using System.Collections.Generic;
using KCS.Models;
using DevExpress.Mvvm.POCO;
using System.ComponentModel;
using KCS.Common.DAL.Constants;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class EditEmployeeViewModel : KcsDocument
    {
        private Employees backupEditEmployee;
        public static EditEmployeeViewModel Create()
        {

            return ViewModelSource.Create(() => new EditEmployeeViewModel());
        }
        public static EditEmployeeViewModel Create(Employees employee)
        {

            return ViewModelSource.Create(() => new EditEmployeeViewModel(employee));
        }
        public void SetEmployeePhoto(string photo)
        {
            EditEmployee.RegPhoto = photo;
        }
        protected EditEmployeeViewModel()
        {
            EditEmployee = new Employees();
        }
        protected EditEmployeeViewModel(Employees employee)
        {
            backupEditEmployee = new Employees(employee);
            EditEmployee = new Employees(employee);
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
        public virtual Employees EditEmployee { get; set; }
        public virtual int SyncSetting { get; set; }

       

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
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<EmployeeViewModel>(this.GetParentViewModel<EmployeeViewModel>()));
        }
        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = EditEmployee as IDataErrorInfo;
           
            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }
        private bool SaveEmployee()
        {
            if (backupEditEmployee == EditEmployee)
            {
                return true;
            }
            if (!HasValidationErrors())
            {
                string ErrorText = "";

               
                if (EmployeesDataSource.UpdateEmployee(EditEmployee, backupEditEmployee.RegPhoto != EditEmployee.RegPhoto))
                {
                    ShowNotification(LanguageResource.GetDisplayString("EditEmployeeOk"));
                    RebindDataSource();
                    return true;
                }
                
                else
                {
                    ErrorText = LanguageResource.GetDisplayString("EditEmployeeFailed");
                }
                MessageService.ShowMessage(ErrorText);
            }

            return false;
        }
        public void Save()
        {

            SaveEmployee();
        }       
        
    }
}