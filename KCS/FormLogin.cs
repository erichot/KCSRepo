using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.Form;
using KCS.Common.Utils;
using KCS.ViewModels;

namespace KCS
{
    public partial class FormLogin : FormComman
    {
        public FormLogin()
        {
            InitializeComponent();
            InitLanguageResource();
            BindCommands();

            


            
        }
        private void InitLanguageResource()
        {
            this.Text = LanguageResource.GetDisplayString("LoginFormTitle");
            this.lblCtlWelcome.Text = "   " + LanguageResource.GetDisplayString("LoginViewWelcome");
            this.lblCtlUserId.Text = LanguageResource.GetDisplayString("LoginViewUserId");
            this.lblCtlUserPwd.Text = LanguageResource.GetDisplayString("LoginViewUserPin");
            this.checkEditRemember.Text = LanguageResource.GetDisplayString("LoginViewRemember");
            this.btnLogin.Text = LanguageResource.GetDisplayString("LoginViewLogin");
        }
        private void BindCommands()
        {
            var fluentAPI = mvvmContext.OfType<LoginViewModel>();
            fluentAPI.SetObjectDataSourceBinding(userBindingSource,
                x => x.CurrentUser, x => x.Update());
            fluentAPI.BindCommand(btnLogin, x => x.OnLogin());
            fluentAPI.SetTrigger(x => x.State, (state) =>
            {
                if (state == AppState.Authorized)
                    this.DialogResult = DialogResult.OK; /*Show Main Form*/

                
                /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                * Add:  2023/08/09
                * Ver:  1.1.5.11
                */
                if (state == AppState.AuthorizedButRequirePasswordChange)
                {
                    KCS.Common.DAL.SystemConfigure.IsForceToChangePassword = true;
                    this.DialogResult = DialogResult.Retry;
                }
                if (state == AppState.NotAuthorizedDueToLockout)
                {
                    this.DialogResult = DialogResult.Ignore;
                }
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                //else
                //  Close(); // exit the app;
            });
           
            foreach (string item in mvvmContext.GetViewModel<LoginViewModel>().LookUpUsers)
                comboBoxUserId.Properties.Items.Add(item);
            comboBoxUserId.SelectedIndex = 0;
            fluentAPI.ViewModel.Init();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            // Add: 2024/08/11
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(KCS.Models.AppRegistryModel.REG_KEY_SW_CU_KCS);
            if (regKey != null)
            {
                bool isAutoLogon = false;
                string isAutoLogonText = regKey.GetValue(KCS.Models.AppRegistryModel.REG_ITEM_IsAutoLogon).ToString();
                if (string.IsNullOrEmpty(isAutoLogonText) == false
                    && Boolean.TryParse(isAutoLogonText, out bool _isAutoLogon) == true
                    )
                {
                    isAutoLogon = _isAutoLogon;
                }

                if (isAutoLogon == true)
                {
                    string userID = string.Empty;
                    string pwdDec = string.Empty;
                    userID = regKey.GetValue(KCS.Models.AppRegistryModel.REG_ITEM_UserID).ToString();

                    string pwdEnc = regKey.GetValue(KCS.Models.AppRegistryModel.REG_ITEM_Password).ToString();
                    if (string.IsNullOrEmpty(pwdEnc) == false)
                    {
                        pwdDec = LoginPwdCryption.DeCode(pwdEnc);
                    }

                    if (string.IsNullOrEmpty(userID) == false)
                    {
                        var fluentAPI = mvvmContext.OfType<LoginViewModel>();
                        fluentAPI.ViewModel.Init();
                        fluentAPI.ViewModel.CurrentUser.UserNo = userID;
                        fluentAPI.ViewModel.CurrentUser.UserPwd = pwdDec;
                        fluentAPI.ViewModel.OnLogin();
                    }
                }
            }

        }
    }
}