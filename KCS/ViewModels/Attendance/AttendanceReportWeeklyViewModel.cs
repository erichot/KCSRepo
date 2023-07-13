using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class AttendanceReportWeeklyViewModel
    {
        public static AttendanceReportWeeklyViewModel Create()
        {

            return ViewModelSource.Create(() => new AttendanceReportWeeklyViewModel());
        }
    }
}