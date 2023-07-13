using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class CreatCalendarViewModel
    {
        public int SelectYear {get;set;}
        public static CreatCalendarViewModel Create()
        {
            return ViewModelSource.Create(() => new CreatCalendarViewModel());
            //return ViewModelSource.Create<CreatCalendarViewModel>();
        }
        public CreatCalendarViewModel()
        {
            SelectYear = DateTime.Now.Year;
        }
    }
}