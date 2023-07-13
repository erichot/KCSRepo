using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using KCS.Models;
using DevExpress.Mvvm.POCO;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class SupervisorRestPinViewModel
    {
        private EmployeeSupervisor _Supervisor;


        public virtual EmployeeSupervisor Supervisor
        {
            get
            {
                return _Supervisor;
            }
            set
            {
                _Supervisor = value;

            }
        }
        protected SupervisorRestPinViewModel()
        {
            
        }
        protected SupervisorRestPinViewModel(EmployeeSupervisor supervisor)
        {
            _Supervisor =  supervisor;
           
            
        }
        public static SupervisorRestPinViewModel Create(EmployeeSupervisor supervisor)
        {

            return ViewModelSource.Create(() => new SupervisorRestPinViewModel(supervisor));
        }
        public static SupervisorRestPinViewModel Create()
        {

            return ViewModelSource.Create(() => new SupervisorRestPinViewModel());
        }
    }
}