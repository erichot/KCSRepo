using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class AnnualCalendarPrintViewModel : KcsDocument
    {
        public int SelectYear { get; set; }
        public int SelectMonthStart { get; set; }
        public int SelectMonthEnd { get; set; }
        public static AnnualCalendarPrintViewModel Create()
        {
            return ViewModelSource.Create(() => new AnnualCalendarPrintViewModel());
        }
        protected AnnualCalendarPrintViewModel()
        {
            SelectYear = DateTime.Now.Year;
            SelectMonthStart = 1;
            SelectMonthEnd = 12;
        }
    }
}