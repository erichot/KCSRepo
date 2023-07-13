using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class CreateMonthlyShiftViewModel
    {
        public static CreateMonthlyShiftViewModel Create()
        {
            return ViewModelSource.Create(() => new CreateMonthlyShiftViewModel());
        }
        protected CreateMonthlyShiftViewModel()
        {
            SelectAllEmployees = true;
            SelectYear = DateTime.Now.Year;
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }

        public int SelectYear { get; set; }
        public bool SelectAllEmployees { get; set; }
        public virtual IEnumerable<EmployeeBrief> Selection { get; set; }


        public object EmployeesBriefDataSet
        {
            get
            {
                IList<EmployeeBrief> employeesBriefList = EmployeesDataSource.GetEmployeesBriefList();
                return employeesBriefList;
            }

        }
        public void CreateMonthlyShift()
        {
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsCreateMonthlyShift"), LanguageResource.GetDisplayString("CreateMonthlyShift"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            int iSelectYear;
            try
            {
                Messenger.Default.Send(new WaitingMessage<CreateMonthlyShiftViewModel>(this, true));
                iSelectYear = Convert.ToInt32(SelectYear);
                if (SelectAllEmployees)
                {
                    var EmployeesBriefList = EmployeesBriefDataSet as IList<EmployeeBrief>;
                    EmployeesDataSource.CreateEmployeesMonthlyShift(EmployeesBriefList, iSelectYear);
                }
                else
                {
                    EmployeesDataSource.CreateEmployeesMonthlyShift(Selection, iSelectYear);
                }
                Messenger.Default.Send(new WaitingMessage<CreateMonthlyShiftViewModel>(this, false));
                Messenger.Default.Send(new RebindMessage<EmployeeWorkCalendarMonthlyViewModel>(this.GetParentViewModel<EmployeeWorkCalendarMonthlyViewModel>()));
            }
            catch
            {
            }

            
        }
    }
}