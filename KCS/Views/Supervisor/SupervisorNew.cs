using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.Common.Utils;
using KCS.ViewModels;
using KCS.Models;
using DevExpress.Mvvm;

namespace KCS.Views
{
    public partial class SupervisorNew : DevExpress.XtraEditors.XtraUserControl
    {
        public SupervisorNew()
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
        void RebindDataSource()
        {
            var fluentAPI = mvvmContext.OfType<SupervisorNewViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                   x => x.Supervisor);
            }
            catch (Exception ex)
            {
            }
        }
        
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<SupervisorNewViewModel>();

            fluentAPI.SetObjectDataSourceBinding(bindingSourceDep,
                x => x.DepartmentDataSet);

            fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.Supervisor);
            Messenger.Default.Register<RebindMessage<SupervisorNewViewModel>>(this, x => RebindDataSource());
            //fluentAPI.SetBinding(NewUserPwdTextEdit,x => x.EditValue,x => x.Password);
           // fluentAPI.SetBinding(NewUserPwdAgainTextEdit, x => x.EditValue, x => x.ConfirmPassword);
            UserPermissionTypeBindableComboBoxEdit.EditValueChanged += (s, e) =>
                {
                    if (((ComboBoxEdit)s).Text == LanguageResource.GetDisplayString("UserPermissionTypeSupervisorsDepartment"))
                    {
                        ItemForDepartmentID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        DepartmentIDLookUpEdit.ItemIndex = 0;
                    }
                    else
                    {
                        ItemForDepartmentID.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                };
            foreach (Control control in layoutControlMain.Controls)
            {
                BaseEdit edit = control as BaseEdit;
                if (edit == null || edit.DataBindings.Count == 0) continue;
                EditorHelpers.ApplyBindingSettings<EmployeeSupervisor>(edit, layoutControlMain);
                //edit.Validated += (s, e) =>
                //{
                //    if (string.IsNullOrEmpty(((TextEdit)s).Text))
                //        ((TextEdit)s).ErrorText = ""; 
                //};
            }
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiSaveAndClose, x => x.SaveAndClose());
            fluentAPI.BindCommand(bbiSaveAndNew, x => x.SaveAndNew());
            //EmailTextEdit.Validating += (s, e) =>
            //{
            //    if (string.IsNullOrEmpty(((TextEdit)s).Text))
            //        e.Cancel = false;
            //};
            NewUserPwdAgainTextEdit.Validated += (s, e) =>
            {
                if (!(((TextEdit)s).Text).Equals(NewUserPwdTextEdit.Text))
                    NewUserPwdAgainTextEdit.ErrorText = "密码不一致";
                else
                {
                    NewUserPwdTextEdit.ErrorText = "";
                    NewUserPwdAgainTextEdit.ErrorText = "";
                }
            };
            NewUserPwdTextEdit.Validated += (s, e) =>
            {
                if (!(((TextEdit)s).Text).Equals(NewUserPwdAgainTextEdit.Text))
                {
                    NewUserPwdTextEdit.ErrorText = "密码不一致";
                    
                }
                else
                {
                    NewUserPwdTextEdit.ErrorText = "";
                    NewUserPwdAgainTextEdit.ErrorText = "";
                }
            };
            DepartmentIDLookUpEdit.Validating += (s, e) =>
            {
                if (string.IsNullOrEmpty(DepartmentIDLookUpEdit.Text))
                {
                    DepartmentIDLookUpEdit.ErrorText = "不能为空";
                    e.Cancel = true;
                }
               
            };
        }
        void InitViewDisplay()
        {

            UserPermissionTypeBindableComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("UserGroupText") + "1");
            UserPermissionTypeBindableComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("UserPermissionTypeSupervisorsDepartment"));
            ribbonPageGroup1.Text = LanguageResource.GetDisplayString("ToolBarSave");
            ribbonPageGroup2.Text = bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiSaveAndClose.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndClose");
            bbiSaveAndNew.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndNew");

            ItemForUserID.Text = LanguageResource.GetDisplayString("SupervisorViewId");
            ItemForUserName.Text = LanguageResource.GetDisplayString("SupervisorViewName");
            ItemForNewUserPwd.Text = LanguageResource.GetDisplayString("InputNewPassword");
            ItemForNewUserPwdAgain.Text = LanguageResource.GetDisplayString("NewPasswordAgain");
            ItemForEmail.Text = LanguageResource.GetDisplayString("Email");
            ItemForPhoneMobile.Text = LanguageResource.GetDisplayString("SupervisorViewPhone");
            ItemForUserPermissionTypeBindable.Text = LanguageResource.GetDisplayString("SupervisorViewAdminType");
            ItemForEmployeeAuthority.Text = LanguageResource.GetDisplayString("SupervisorViewAuth");
            ItemForDepartmentID.Text = LanguageResource.GetDisplayString("DepartmentID");
            ItemForNote.Text = LanguageResource.GetDisplayString("RemarkText");
            
        }
    }
}
