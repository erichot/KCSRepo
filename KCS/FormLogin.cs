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
                //else
                  //  Close(); // exit the app;
            });
           
            foreach (string item in mvvmContext.GetViewModel<LoginViewModel>().LookUpUsers)
                comboBoxUserId.Properties.Items.Add(item);
            comboBoxUserId.SelectedIndex = 0;
            fluentAPI.ViewModel.Init();
        }

    }
}