using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class LoginViewModel
    {
        public IEnumerable<string> LookUpUsers
        {
            get { return CredentialsSource.GetUserIds(); }
        }
      
        public virtual LoginAdmin CurrentUser { get; set; }
        public bool IsCurrentUserCredentialsValid { get; private set; }
        //
        [DevExpress.Mvvm.DataAnnotations.Command(false)]
        public void Init()
        {            
            this.CurrentUser = new LoginAdmin();
            this.CurrentUser.UserPwd = "";
            this.CurrentUser.UserNo = "";
        }
        public virtual AppState State { get; set; }
        public void OnLogin()
        {
            IsCurrentUserCredentialsValid = CredentialsSource.Check(CurrentUser.UserNo, CurrentUser.UserPwd, CurrentUser.IsCacheOrNot);
            if (IsCurrentUserCredentialsValid)
            {
                State = AppState.Authorized;
            }
            else
            {
                State = AppState.NotAuthorized;
                MessageService.ShowMessage(LanguageResource.GetDisplayString("LoginViewLoginFailed"), LanguageResource.GetDisplayString("KCSTitle"));

            }
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetService<IMessageBoxService>(); }
        }
        public void Update()
        {
           
        }
        public static LoginViewModel Create()
        {
            return ViewModelSource.Create<LoginViewModel>();
        }
    }
    public enum AppState
    {
        NotAuthorized,
        Authorized
    }
}