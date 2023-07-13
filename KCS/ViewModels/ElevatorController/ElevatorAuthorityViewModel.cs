using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using KCS.Common.Utils;
using KCS.Models;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ElevatorAuthorityViewModel : KcsDocument
    {
        IList<EmployeeBrief> employeesBriefList = null;
        public virtual IEnumerable<EmployeeBrief> SelectionEmployees { get; set; }
        public virtual IEnumerable<ElevatorController> SelectionDevices { get; set; }

        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }        
        public virtual bool AuthorityB1 { get; set; }
        public virtual bool AuthorityF1 { get; set; }
        public virtual bool AuthorityF2 { get; set; }
        public virtual bool AuthorityF3 { get; set; }
        public virtual bool AuthorityF4 { get; set; }
        public virtual bool AuthorityF5 { get; set; }


        private EmployeeBrief _Employee;

        public virtual EmployeeBrief SelectedEmployee
        {
            get
            {
                return _Employee;
            }
            set
            {
                _Employee = value;


            }
        }

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public static ElevatorAuthorityViewModel Create()
        {

            return ViewModelSource.Create(() => new ElevatorAuthorityViewModel());
        }
        protected ElevatorAuthorityViewModel()
        {
            StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            EndTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 0);

            AuthorityB1 = false;
            AuthorityF1 = false;
            AuthorityF2 = false;
            AuthorityF3 = false;
            AuthorityF4 = false;
            AuthorityF5 = false;

        }
        public void ShowAuthority(object employeesObject)
        {
            var employee = employeesObject as EmployeeBrief;
        }
            public void SetEmployeesElevatorAuthority()
        {
            Byte UserGroupNo = 0x80;

            if (SelectionDevices == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedDevicesFirst"));
                return;
            }
            if (SelectionEmployees == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedEmployeesFirst"));
                return;
            }


            DateTime dtStart = StartTime;
            DateTime dtEndTime = EndTime;

            if (AuthorityB1)
                UserGroupNo += 1;
            if (AuthorityF1)
                UserGroupNo += 2;
            if (AuthorityF2)
                UserGroupNo += 4;
            if (AuthorityF3)
                UserGroupNo += 8;
            if (AuthorityF4)
                UserGroupNo += 0x10;
            if (AuthorityF5)
                UserGroupNo += 0x20;

            AcAuthority UserAuthority = new AcAuthority
            {
                CardID = "",
                SlaveID = 0,
                AllowTimeStartHour = (byte)dtStart.Hour,
                AllowTimeStartMinute = (byte)dtStart.Minute,
                AllowTimeEndHour = (byte)dtEndTime.Hour,
                AllowTimeEndMinute = (byte)dtEndTime.Minute,
                GroupID = (byte)UserGroupNo
            };

            if (EmployeesDataSource.UpdateEmployeeAuthority(SelectionDevices, SelectionEmployees, UserAuthority))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SetElevatorControlAuthorityOk"));
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SetElevatorControlAuthorityFailed"));
            }

        }
        public object ElevatorControllerDataSet
        {
            get
            {
                IList<ElevatorController> superList = ElevatorControlDataSource.GetElevatorControllerList();
                return superList;
            }

        }
        public object EmployeesBriefDataSet
        {
            get
            {
                employeesBriefList = EmployeesDataSource.GetEmployeesBriefList();
                return employeesBriefList;
            }

        }

    }
}
