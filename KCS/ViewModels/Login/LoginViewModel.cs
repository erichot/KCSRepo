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

                // Add: 2023/09/19
                // Ver: 1.1.5.11
                CurrentUser.UserPermissionTypeID = CredentialsSource.GetLoginSupervisorUserPermissionTypeID();
            }
            else
            {
                State = AppState.NotAuthorized;
                MessageService.ShowMessage(LanguageResource.GetDisplayString("LoginViewLoginFailed"), LanguageResource.GetDisplayString("KCSTitle"));
            }

            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             * Add:     2023/07/27
             * Ver:     1.1.5.11
             */
            if (KCS.Common.DAL.SystemConfigure.IsEnablePasswordPolicy == true)
            {
                var loginID = CurrentUser.UserNo;
                var loginPassword = KCS.Helpers.HashHelper.ComputeStringToSha256Hash(CurrentUser.UserPwd);
                var isSuccessLogin = (State == AppState.Authorized) ? true : false;
                int? userSID = null;
                if (isSuccessLogin)
                {
                    userSID = CurrentUser.UserSID;
                    
                    if (CredentialsSource.GetLoginSupervisorIsLocked())
                    {
                        var lockoutTime = CredentialsSource.GetLoginSupervisorTimeLockout();
                        if (lockoutTime.Value.AddHours(24) > DateTime.Now)
                        {
                            State = AppState.NotAuthorizedDueToLockout;
                            var sMsg = "You've entered incorrect password too many times. Please try again after 24 hours later.";
                            MessageService.ShowMessage(sMsg);
                        }
                    }

                    var passwordExpirationDate = CredentialsSource.GetLoginSupervisorExpirationDate();
                    if (passwordExpirationDate != null && passwordExpirationDate <= DateTime.Now)
                    {
                        State = AppState.AuthorizedButRequirePasswordChange;
                    }

                    if (State == AppState.Authorized)
                    {
                        KCS.Common.DAL.KCSDatabaseHelper.Instance.SP_UPDATE_BF_Supervisor_IsLocked(0, loginID, false);
                    }
                }
                else
                {
                    var loginHistoryList = KCS.Common.DAL.KCSDatabaseHelper.Instance.GetUserLoginHistoryLogList(loginID);
                    var invalidCount = default(int);
                    foreach (System.Data.DataRow row in loginHistoryList.Rows)
                    {
                        if (Convert.ToBoolean(row["IsSuccessLogon"]) == true)
                        {
                            break;
                        }
                        else
                        {
                            invalidCount++;
                            if (invalidCount >= 3 )
                            {
                                KCS.Common.DAL.KCSDatabaseHelper.Instance.SP_UPDATE_BF_Supervisor_IsLocked(0, loginID.ToUpper(), true);
                                var sMsg = "You've entered incorrect password too many times. Please try again after 24 hours later.";
                                MessageService.ShowMessage(sMsg);
                                break;
                            }
                        }
                    }
                }


                KCS.Common.DAL.KCSDatabaseHelper.Instance.SP_INSERT_S_UserLoginHistoryLog(loginID, loginPassword, isSuccessLogin, userSID);
            }
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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
        Authorized,

        NotAuthorizedDueToLockout,
        AuthorizedButRequirePasswordChange
    }
}