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
    public partial class SetAdmin : BaseViewControl
    {
        public SetAdmin()
            : base(typeof(SetAdminViewModel))
        {
            InitializeComponent();
            InitBindings();
        }
        void InitBindings()
        {
            layoutControlAdminNo.Text = LanguageResource.GetDisplayString("AdministratorsId");
            layoutControlAdminName.Text = LanguageResource.GetDisplayString("AdministratorsName");
            layoutControlNewPin.Text = LanguageResource.GetDisplayString("InputNewPassword");
            layoutControlNewPinAgain.Text = LanguageResource.GetDisplayString("NewPasswordAgain");
            layoutControlCurPin.Text = LanguageResource.GetDisplayString("Password");

            var fluentAPI = mvvmContext.OfType<SetAdminViewModel>();
            fluentAPI.ViewModel.Init();
            fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.CurrentAdmin, x => x.Update());
            
        }
    }
}
