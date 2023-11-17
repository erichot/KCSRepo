using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;
using KCS.Controls;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class EmployeesAuthorityViewModel: KcsDocument
    {

        IEnumerable<Employees> EmployeesList;
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public static EmployeesAuthorityViewModel Create()
        {

            return ViewModelSource.Create(() => new EmployeesAuthorityViewModel());
        }
        public static EmployeesAuthorityViewModel Create(IEnumerable<Employees> employeesList)
        {

            return ViewModelSource.Create(() => new EmployeesAuthorityViewModel(employeesList));
        }

        protected EmployeesAuthorityViewModel(IEnumerable<Employees> employeesList)
        {
            bUseAdvAccessControlSet = false;
            SelectUserGroup = new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 1", 1);
            StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);
            EmployeesList = employeesList;
        }
        public EmployeesAuthorityViewModel()
        {
            
            bUseAdvAccessControlSet = false;
            SelectUserGroup = new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 1", 1);
            StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);
        }
        public object DeviceInfoDataSet
        {
            get
            {
                return DevicesDataSource.GetDevicesInofList();
            }
        }
        public object AutoritySyncStatusDataSet
        {
            get
            {
                if (EmployeesList == null)
                    return null;
                return EmployeesDataSource.GetEmployeesAuthoritySyncList(EmployeesList);
            }
        }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual object SelectUserGroup { get; set; }
        public virtual bool bUseAdvAccessControlSet { get; set; }
        public virtual IEnumerable<DeviceInfo> SelectionDevices { get; set; }
        public void Save()
        {

            if (SelectionDevices == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedDevicesFirst"));
                return;
            }
            if (EmployeesList == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedEmployeesFirst"));
                return;
            }
            int UserGroupNo = 0;
            DateTime dtStart = StartTime;
            DateTime dtEndTime = EndTime;
            if (bUseAdvAccessControlSet)
            {//高级
                ComboxData curUserGroup = SelectUserGroup as ComboxData;
                UserGroupNo = curUserGroup.Value;
            }
            else
            {
                UserGroupNo = 0;
                
            }

            AcAuthority UserAuthority = new AcAuthority
                {
                     CardID ="",
                     SlaveID =0,
                     AllowTimeStartHour = (byte)dtStart.Hour,
                     AllowTimeStartMinute = (byte)dtStart.Minute,
                     AllowTimeEndHour = (byte)dtEndTime.Hour,
                     AllowTimeEndMinute = (byte)dtEndTime.Minute,
                     GroupID = (byte)UserGroupNo
                };

            if (EmployeesDataSource.UpdateEmployeeAuthority(SelectionDevices, EmployeesList, UserAuthority))
            {
                Messenger.Default.Send(new RebindMessage<EmployeesAuthorityViewModel>(this));
                //MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedEmployeesFirst"));
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
            }
            
        }




        public void AllowTimeReport()
        {
            MessageService.ShowMessage("asdd");
        }


    }
}