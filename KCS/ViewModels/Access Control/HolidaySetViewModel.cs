using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class HolidaySetViewModel
    {
        public static HolidaySetViewModel Create()
        {
            return ViewModelSource.Create(() => new HolidaySetViewModel());
        }
    }
}