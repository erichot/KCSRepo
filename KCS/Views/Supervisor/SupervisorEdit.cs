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
using KCS.Models;

namespace KCS.Views
{
    public partial class SupervisorEdit : XtraUserControl
    {
        public SupervisorEdit()
        {
            InitializeComponent();
           
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<SupervisorEditViewModel>();
            
            fluentAPI.SetObjectDataSourceBinding(bindingSourceDep,
                x => x.DepartmentDataSet);

            fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.Supervisor);
            foreach (Control control in layoutControlMain.Controls)
            {
                BaseEdit edit = control as BaseEdit;
                if (edit == null || edit.DataBindings.Count == 0) continue;
                EditorHelpers.ApplyBindingSettings<EmployeeSupervisor>(edit, layoutControlMain);
                //edit.Validating += (s, e) =>
                //{
                //    if (string.IsNullOrEmpty(((TextEdit)s).Text))
                //        e.Cancel = false;
                //};
            }
           
        }
        void InitViewDisplay()
        {
            ItemDepartment.Text = LanguageResource.GetDisplayString("Department");
            ItemForUserNO.Text = LanguageResource.GetDisplayString("SupervisorViewId");
            ItemUserName.Text = LanguageResource.GetDisplayString("SupervisorViewName");
            
            ItemEmail.Text = LanguageResource.GetDisplayString("Email");
            ItemMobilePhone.Text = LanguageResource.GetDisplayString("SupervisorViewPhone");
            ItemAdminType.Text = LanguageResource.GetDisplayString("SupervisorViewAdminType");
            readOnlyAuthority.Text = LanguageResource.GetDisplayString("SupervisorViewAuth");
           
            ItemRemarks.Text = LanguageResource.GetDisplayString("RemarkText");
            comboBoxEditAdminType.Properties.Items.Add(LanguageResource.GetDisplayString("UserPermissionTypeSupervisorsAllDepartments"));
            comboBoxEditAdminType.Properties.Items.Add(LanguageResource.GetDisplayString("UserPermissionTypeSupervisorsDepartment"));

        }
    }
}
