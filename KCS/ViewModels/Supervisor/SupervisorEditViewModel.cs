using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;


namespace KCS.ViewModels
{
    [POCOViewModel]
    public class SupervisorEditViewModel
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
        public object DepartmentDataSet
        {
            get
            {
                IList<DepartmentList> departmentList = DepartmentListSource.GetDepartmentListField();

                return departmentList;
            }
        }
        protected SupervisorEditViewModel()
        {
            
        }
        protected SupervisorEditViewModel(EmployeeSupervisor supervisor)
        {
            _Supervisor =  supervisor;
           
            
        }
        public static SupervisorEditViewModel Create(EmployeeSupervisor supervisor)
        {

            return ViewModelSource.Create(() => new SupervisorEditViewModel(supervisor));
        }
        public static SupervisorEditViewModel Create()
        {

            return ViewModelSource.Create(() => new SupervisorEditViewModel());
        }
    }
}