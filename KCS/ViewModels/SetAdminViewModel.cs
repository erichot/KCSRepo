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

            /*
            * Modified:    2023/07/20
            * Ver:         1.1.5.11
            * Note:        所有從DB讀出的密碼皆為Hashed/Encrypted
            if (!CredentialsSource.LoginAdministrator.OldUserPwd.Equals(CredentialsSource.LoginAdministrator.UserPwd))
            */
            if (KCS.Common.DAL.SystemConfigure.IsEnablePasswordPolicy == true)
            {
                var passwordHistoryList = KCS.Common.DAL.KCSDatabaseHelper.Instance.GetUserPasswordHistoryList(CredentialsSource.LoginAdministrator.UserNo);
                if (passwordHistoryList != null && passwordHistoryList.Rows.Count>0)
                {
                    if (DateTime.TryParse(passwordHistoryList.Rows[0]["TimeAddNew"].ToString(), out DateTime _lastModified))
                    {
                        if (_lastModified.AddMinutes(1440) > DateTime.Now)
                        {
                            var sMsg = "Unable to change new password due to the Minimum Password Age policy (1 day)";
                            MessageService.ShowMessage(sMsg);
                            return;
                        }
                    }


                    var sNewPassword = KCS.Helpers.HashHelper.ComputeStringToSha256Hash(CredentialsSource.LoginAdministrator.NewUserPwd);
                    foreach (System.Data.DataRow row in passwordHistoryList.Rows)
                    {
                        if (row["PasswordHash"].ToString() == sNewPassword)
                        {
                            var sMsg = "The new password cannot be re-used last 5 history passwords";
                            MessageService.ShowMessage(sMsg);
                            return;
                        }
                    }
                }



                //if (!CredentialsSource.LoginAdministrator.OldUserPwd.Equals(KCS.Helpers.HashHelper.ComputeStringToSha256Hash(CredentialsSource.LoginAdministrator.UserPwd)))
                if (CredentialsSource.LoginAdministrator.OldUserPwd.Equals(KCS.Helpers.HashHelper.ComputeStringToSha256Hash(CredentialsSource.LoginAdministrator.UserPwd)) == false
                    && !(CredentialsSource.LoginAdministrator.OldUserPwd == "" && CredentialsSource.LoginAdministrator.UserPwd == "")
                    )
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("PasswordValidateFailed"));
                    return;
                }

                var msg = string.Empty;
                if (!KCS.Helpers.PasswordPolicyHelper.IsPasswordValid(CredentialsSource.LoginAdministrator.NewUserPwd, out msg))
                {
                    MessageService.ShowMessage(msg);
                    return;
                }
            }
            else
            {
                if (!CredentialsSource.LoginAdministrator.OldUserPwd.Equals(CredentialsSource.LoginAdministrator.UserPwd))
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("PasswordValidateFailed"));
                    return;
                }
            }
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            if (!CredentialsSource.UpdateAdminPin())
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ModifyPinFailed"));
                return;
            }


            /*
            * Add:      2023/07/28
            * Ver:      1.1.5.11
            */
            if (KCS.Common.DAL.SystemConfigure.IsEnablePasswordPolicy == true)
            {
                var userSID = CredentialsSource.GetLoginSupervisorSID();
                var passwordHash = KCS.Helpers.HashHelper.ComputeStringToSha256Hash(CredentialsSource.LoginAdministrator.UserPwd);
                KCS.Common.DAL.KCSDatabaseHelper.Instance.SP_INSERT_S_UserPasswordHistory(userSID, passwordHash);
            }

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        }
    }
}