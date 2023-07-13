using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class EmployeeWorkCalendarMonthlyViewModel
    {
        public static EmployeeWorkCalendarMonthlyViewModel Create()
        {
            return ViewModelSource.Create(() => new EmployeeWorkCalendarMonthlyViewModel());
        }
        protected EmployeeWorkCalendarMonthlyViewModel()
        {            
            SelectYear = DateTime.Now.Year;
        }
        public virtual int SelectYear { get; set; }
        public object EmployeesMonthlyShiftDataSet
        {
            get
            {
                return UserWorkShiftDataSource.GetWorkCalendarMonthlyList(SelectYear);
            }
        }
        public object WorkShiftDataSet
        {
            get
            {
                return WorkShiftDataSource.GetWorkShifItemstList();
            }

        }
        public virtual WorkCalendar SelectedUserWorkMonthlyShift { get; set; }
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }

        protected void OnSelectYearChanged()
        {
            RebindDataSource();
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<EmployeeWorkCalendarMonthlyViewModel>(this));
        }
        public void Save(object selValue)
        {
            var selectMonthlyShift = Convert.ToString(selValue);
            SelectedUserWorkMonthlyShift.ShiftCode = selectMonthlyShift;
            WorkShiftDataSource.UpdateMonthlyWorkShift(SelectedUserWorkMonthlyShift);
            RebindDataSource();
        }
        public void CreateEmployeesMonthlyShift()
        {
            var createMonthlyShiftViewModel = CreateMonthlyShiftViewModel.Create();
            createMonthlyShiftViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("CreateMonthlyShift", createMonthlyShiftViewModel);
            document.Show();
        }
    }
}