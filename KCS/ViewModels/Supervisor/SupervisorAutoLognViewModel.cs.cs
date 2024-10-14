using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;

using System.ComponentModel;
using Microsoft.Win32;


namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class SupervisorAutoLognViewModel: KcsDocument
    {
        object title = " ";
        private EmployeeSupervisor _Supervisor;


        protected virtual bool TryClose()
        {

            return true;
        }
        public object Title { get { return title; } }
   
        protected virtual void OnDestroy()
        {
            Messenger.Default.Unregister(this);
        }

        

        #region IDocumentContent
     

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
        protected SupervisorAutoLognViewModel()
        {
            
        }
        protected SupervisorAutoLognViewModel(EmployeeSupervisor supervisor)
        {
            _Supervisor =  supervisor;
        }


    

        public static SupervisorAutoLognViewModel Create(EmployeeSupervisor supervisor)
        {

            return ViewModelSource.Create(() => new SupervisorAutoLognViewModel(supervisor));
        }
        public static SupervisorAutoLognViewModel Create()
        {

            return ViewModelSource.Create(() => new SupervisorAutoLognViewModel());
        }
        #endregion








        




    }
}