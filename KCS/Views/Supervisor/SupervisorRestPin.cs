using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.ViewModels;
using KCS.Common.Utils;

namespace KCS.Views
{
    public partial class SupervisorRestPin : DevExpress.XtraEditors.XtraUserControl
    {
        public SupervisorRestPin()
        {
            InitializeComponent();
        }
       
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<SupervisorRestPinViewModel>();
            

            fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.Supervisor);

            textEditNewPinAgain.Validated += (s, e) =>
            {
                if (!(((TextEdit)s).Text).Equals(textEditNewPin.Text))
                    textEditNewPinAgain.ErrorText = "密码不一致";
                else
                {
                    textEditNewPin.ErrorText = "";
                    textEditNewPinAgain.ErrorText = "";
                }
            };
            textEditNewPin.Validated += (s, e) =>
            {
                if (!(((TextEdit)s).Text).Equals(textEditNewPinAgain.Text))
                {
                    textEditNewPin.ErrorText = "密码不一致";

                }
                else
                {
                    textEditNewPin.ErrorText = "";
                    textEditNewPinAgain.ErrorText = "";
                }
            };
            textEditNewPin.Validated += (s, e) =>
            {
                var retMsg = string.Empty;
                if (KCS.Helpers.PasswordPolicyHelper.IsPasswordValid(textEditNewPin.Text, out retMsg))
                {
                    textEditNewPin.ErrorText = retMsg;

                }
                else
                {
                    textEditNewPin.ErrorText = "";
                    textEditNewPinAgain.ErrorText = "";
                }
            };
        }
        void InitViewDisplay()
        {

            layoutControlAdminNo.Text = LanguageResource.GetDisplayString("SupervisorViewId");
            layoutControlAdminName.Text = LanguageResource.GetDisplayString("SupervisorViewName");
            layoutControlNewPin.Text = LanguageResource.GetDisplayString("InputNewPassword");
            layoutControlNewPinAgain.Text = LanguageResource.GetDisplayString("NewPasswordAgain");
        }
    }
}
