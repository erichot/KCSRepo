using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Data;
using KCS.Models;
using System.Collections.Generic;
using System.ComponentModel;
using KCS.ViewModels;
using KCS.Common.Utils;
using DevExpress.Utils.MVVM.Services;

namespace KCS.Views
{
    [POCOViewModel]
    public class SupervisorViewModel
    {
        

        private EmployeeSupervisor _Supervisor ;
        private EmployeeSupervisor _OldSupervisor;
        private EmployeeSupervisor _EditSupervisor;

        public static SupervisorViewModel Create()
        {
           
            return ViewModelSource.Create<SupervisorViewModel>();
        }
        
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
       
        protected IDialogService DialogService
        {
            get { return this.GetService<IDialogService>(); }
        }
        public virtual bool DisplayDeparment
        {
            get;
            set;
        }

        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }
        public virtual EmployeeSupervisor SelectedSupervisor { 
            get 
            {
                return _Supervisor;
            }
            set
            {
                _Supervisor = value;
               
                DisplayDeparment = false;
                if ((UserPermissionTypeValue)_Supervisor.UserPermissionTypeID == UserPermissionTypeValue.SupervisorsDepartment)
                {
                    DisplayDeparment = true;
                }
            }
        } 
        public virtual int RecordCount { get; set; }
        public object SuperVisorDataSet
        {
            get {
                IList<EmployeeSupervisor> superList = SupervisorDataSource.GetSupervisorList();
                RecordCount = superList.Count;
                return superList;
            }

        }
        void RebindDataSource()
        {

            Messenger.Default.Send(new RebindMessage<SupervisorViewModel>(this));
        }
        //void OnNewSupervisor(MessageResult result)
        //{
        //    if (result == MessageResult.OK)
        //    {
        //        if (!string.IsNullOrEmpty(_EditSupervisor.UserID) && !string.IsNullOrEmpty(_EditSupervisor.UserName))
        //        {
        //            if (!SupervisorDataSource.NewSupervisor(_EditSupervisor))
        //            {
        //                MessageService.ShowMessage(LanguageResource.GetDisplayString("AddItemFailed"));
        //            }
        //            else
        //            {
        //                RebindDataSource();
        //            }
        //        }
        //    }
        //}
        public void NewSupervisor()
        {

            var superEditViewModel = SupervisorEditViewModel.Create();
            superEditViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("SupervisorNew", superEditViewModel);
            document.Show();
            //_EditSupervisor = new EmployeeSupervisor();
           // OnNewSupervisor(DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("NewSupervisorView"), "SupervisorNew", SupervisorNewViewModel.Create(_EditSupervisor)));
           
        }
        public void Delete(object supervisorObjec)
        {

            if (supervisorObjec == null)
                return;
            var SupervisorObj = supervisorObjec as EmployeeSupervisor;
            if (SupervisorObj.UserID.Equals("ADMIN"))
            {
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsDeleteItem"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;

            if (!SupervisorDataSource.DeleteSupervisor(SupervisorObj.UserSID))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteItemFailed"));
            }
            else
            {
                RebindDataSource();
            }
        }
        public void SetPassword(object supervisorObjec)
        {
            var Supervisor = supervisorObjec as EmployeeSupervisor;
            
            _EditSupervisor = new EmployeeSupervisor(Supervisor);
            if( !Supervisor.UserID.Equals("ADMIN"))
            OnSetPassword(DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("ResetSupervisorPin"), "SupervisorRestPin", SupervisorRestPinViewModel.Create(_EditSupervisor)));
            
        }
        void OnEditSupervisor(MessageResult result)
        {
            
            if (result == MessageResult.OK)
            {
                if (_OldSupervisor != _EditSupervisor)
                {
                    if (!SupervisorDataSource.UpdateSupervisor(_EditSupervisor))
                    {
                        MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
                    }
                    else
                    {
                        RebindDataSource();
                    }
                }
            }
            
        }
        void OnSetPassword(MessageResult result)
        {
            if (result == MessageResult.OK)
            {
                if (_EditSupervisor.NewUserPwd == _EditSupervisor.NewUserPwdAgain)
                {
                    if (!SupervisorDataSource.UpdateSupervisorPin(_EditSupervisor.UserID, _EditSupervisor.NewUserPwd))
                    {
                        MessageService.ShowMessage(LanguageResource.GetDisplayString("ModifyPinFailed"));
                    }
                }
                else
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("TwoInputNotConsistent"));
                    SetPassword(_EditSupervisor);
                }
            }
        }
        public void Edit(object supervisorObjec)
        {

            var Supervisor = supervisorObjec as EmployeeSupervisor;
            //var document = DocumentManagerService.CreateDocument("SupervisorEdit", SupervisorEditViewModel.Create(Supervisor));
            _EditSupervisor = new EmployeeSupervisor(Supervisor);
            _OldSupervisor = new EmployeeSupervisor(Supervisor);
            //document.Show();
            OnEditSupervisor(DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("EditSupervisor"), "SupervisorEdit", SupervisorEditViewModel.Create(_EditSupervisor)));
            
        }
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<SupervisorViewModel>(this,RecordCount));
        }

        
    }
}