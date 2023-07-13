using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class SetAdminViewModel
    {
        public static SetAdminViewModel Create()
        {
            return ViewModelSource.Create<SetAdminViewModel>();
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetService<IMessageBoxService>(); }
        }
        public void Init() {
            this.CurrentAdmin = new Administrator();
            
            this.CurrentAdmin.UserNo = CredentialsSource.LoginAdministrator.UserNo;
            this.CurrentAdmin.UserName = CredentialsSource.LoginAdministrator.UserName;
            this.CurrentAdmin.OldUserPwd = CredentialsSource.LoginAdministrator.OldUserPwd;
            this.CurrentAdmin.NewUserPwd = "";
            this.CurrentAdmin.NewUserPwdAgain = "";
            this.CurrentAdmin.UserPwd = "";
            CredentialsSource.LoginAdministrator.NewUserPwd = "";
            CredentialsSource.LoginAdministrator.NewUserPwdAgain = "";
            CredentialsSource.LoginAdministrator.UserPwd = "";
            
        }
        public void Update()
        {
            CredentialsSource.LoginAdministrator.NewUserPwd = this.CurrentAdmin.NewUserPwd;
            CredentialsSource.LoginAdministrator.NewUserPwdAgain = this.CurrentAdmin.NewUserPwdAgain;
            CredentialsSource.LoginAdministrator.UserPwd = this.CurrentAdmin.UserPwd;
        }
        public virtual Administrator CurrentAdmin {get;set;} 
        public void SetAdministratorPIN()
        {
            if (!CredentialsSource.LoginAdministrator.NewUserPwd.Equals(CredentialsSource.LoginAdministrator.NewUserPwdAgain))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("TwoInputNotConsistent"));
                return;
            }
            if (!CredentialsSource.LoginAdministrator.OldUserPwd.Equals(CredentialsSource.LoginAdministrator.UserPwd))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("PasswordValidateFailed"));
                return;
            }
            if (!CredentialsSource.UpdateAdminPin())
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ModifyPinFailed"));
                return;
            }
        }
    }
}