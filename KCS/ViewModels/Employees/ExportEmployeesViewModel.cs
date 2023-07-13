using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;

namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class ExportEmployeesViewModel : KcsDocument 
    {
        public static ExportEmployeesViewModel Create()
        {
            return ViewModelSource.Create(() => new ExportEmployeesViewModel());
        }

        public object EmployeesDataSet
        {
            get
            {
                IList<Employees> employeesList = EmployeesDataSource.GetEmployeesList();
                
                return employeesList;
            }

        }
    }
}