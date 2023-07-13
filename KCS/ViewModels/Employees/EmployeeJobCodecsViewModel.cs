using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class EmployeeJobCodecsViewModel : KcsDocument
    {
        public static EmployeeJobCodecsViewModel Create()
        {

            return ViewModelSource.Create(() => new EmployeeJobCodecsViewModel());
        }

        public object JobCodeDataSet
        {
            get
            {
                return EmployeesDataSource.GetJobCodeList();
            }
        }
        public EmployeeJobCode SelectedJobCode { get; set; }
        public void Save(object objectJobCode)
        {
            var jobcode = objectJobCode as EmployeeJobCode;
            EmployeesDataSource.AddJobCode(jobcode);

            Messenger.Default.Send(new RebindMessage<EmployeeJobCodecsViewModel>(this));

        }
        public void Delete(object objectJobCode)
        {
            var jobcode = objectJobCode as EmployeeJobCode;
            if (jobcode == null)
                return;
            EmployeesDataSource.DeleteJobCode(jobcode);

            Messenger.Default.Send(new RebindMessage<EmployeeJobCodecsViewModel>(this));
        }
    }
}