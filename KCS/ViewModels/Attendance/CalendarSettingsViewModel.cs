using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class CreateCalendarSettingsViewModel
    {
        public int SelectYear { get; set; }
        public int HaveHolidayOrNot { get; set; }
        public int HolidayTypeOnWeekend { get; set; }
        public static CreateCalendarSettingsViewModel Create()
        {
             return ViewModelSource.Create(() => new CreateCalendarSettingsViewModel());
            //return ViewModelSource.Create<CalendarSettingsViewModel>();
        }
        public CreateCalendarSettingsViewModel()
        {
            SelectYear = DateTime.Now.Year;
            HaveHolidayOrNot = 0;
            HolidayTypeOnWeekend = 0;
        }
    }
}