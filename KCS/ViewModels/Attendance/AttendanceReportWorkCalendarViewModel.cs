using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class AttendanceReportWorkCalendarViewModel
    {
        public static AttendanceReportWorkCalendarViewModel Create()
        {

            return ViewModelSource.Create(() => new AttendanceReportWorkCalendarViewModel());
        }
    }
}