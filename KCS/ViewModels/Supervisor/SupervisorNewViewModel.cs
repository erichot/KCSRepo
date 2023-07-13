using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using KCS.Models;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using System.ComponentModel;
using KCS.Views;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class SupervisorNewViewModel : KcsDocument
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
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
       
        
        static PropertyMetadataBuilder<SupervisorNewViewModel, string> AddPasswordCheck(PropertyMetadataBuilder<SupervisorNewViewModel, string> builder)
        {
            return builder.MatchesInstanceRule((name, vm) => vm.Password == vm.ConfirmPassword, () => "The passwords don't match.");
        }
        public static void BuildMetadata(MetadataBuilder<SupervisorNewViewModel> builder)
        {
            //builder.Property(x => x.FirstName)
            //    .Required(() => "Please enter the first name.");
            //builder.Property(x => x.LastName)
            //    .Required(() => "Please enter the last name.");
            //builder.Property(x => x.Email)
            //    .EmailAddressDataType(() => "Please enter a correct email address.");
            AddPasswordCheck(builder.Property(x => x.Password))
                .Required(() => "Please enter the password.");
            AddPasswordCheck(builder.Property(x => x.ConfirmPassword))
                .Required(() => "Please confirm the password.");
        }
        public virtual string Password { get; set; }
        public virtual string ConfirmPassword { get; set; }
        protected virtual void OnPasswordChanged()
        {
            this.RaisePropertyChanged(x => x.ConfirmPassword);
        }
        protected virtual void OnConfirmPasswordChanged()
        {
            this.RaisePropertyChanged(x => x.Password);
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<SupervisorViewModel>(this.GetParentViewModel<SupervisorViewModel>()));
            
        }
        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = Supervisor as IDataErrorInfo;
           
            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }
        protected SupervisorNewViewModel()
        {
            _Supervisor = new EmployeeSupervisor();
            _Supervisor.UserPermissionTypeID = (int)UserPermissionTypeValue.SupervisorsAllDepartments;
        }
        private bool SaveSupervisor()
        {
            if (!HasValidationErrors())
            {
                if (!SupervisorDataSource.NewSupervisor(Supervisor))
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("AddItemFailed"));
                }
                else
                {
                    RebindDataSource();
                    return true;
                }

            }

            return false;
        }
        public void Save()
        {
            SaveSupervisor();
           
        }
       
        public void SaveAndClose()
        {
            
            if (SaveSupervisor())
            {
                Close();
            }
            
        }
        public void SaveAndNew()
        {
             
            if (SaveSupervisor())
            {
                _Supervisor = new EmployeeSupervisor();
                _Supervisor.UserPermissionTypeID = (int)UserPermissionTypeValue.SupervisorsAllDepartments;
                Messenger.Default.Send(new RebindMessage<SupervisorNewViewModel>(this));
            }
            
        }
        protected SupervisorNewViewModel(EmployeeSupervisor supervisor)
        {
            _Supervisor =  supervisor;
            _Supervisor.UserPermissionTypeID = (int)UserPermissionTypeValue.SupervisorsAllDepartments;
           
            
        }
        public static SupervisorNewViewModel Create(EmployeeSupervisor supervisor)
        {

            return ViewModelSource.Create(() => new SupervisorNewViewModel(supervisor));
        }
        public static SupervisorNewViewModel Create()
        {

            return ViewModelSource.Create(() => new SupervisorNewViewModel());
        }
    }
}