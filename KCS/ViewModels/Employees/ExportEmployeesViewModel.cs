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
        // Add:     2024/03/04
        // Ver:     1.1.5.17
        public virtual string m_SupervisorDepartmentID { get; set; }

        public static ExportEmployeesViewModel Create()
        {
            return ViewModelSource.Create(() => new ExportEmployeesViewModel());
        }

        public object EmployeesDataSet
        {
            get
            {

                // Modified:     2024/03/04
                // Ver:     1.1.5.17
                //IList<Employees> employeesList = EmployeesDataSource.GetEmployeesList();
                IList<Employees> employeesList = EmployeesDataSource.GetEmployeesList(m_SupervisorDepartmentID);

                return employeesList;
            }

        }
    }
}