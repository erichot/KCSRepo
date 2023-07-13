using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ImportEmployeesViewModel
    {
        public static ImportEmployeesViewModel Create()
        {
            return ViewModelSource.Create(() => new ImportEmployeesViewModel());
        }
        public void RefreshEmployees()
        {
            Messenger.Default.Send(new RebindMessage<EmployeeViewModel>(this.GetParentViewModel<EmployeeViewModel>()));
        }
    }
}