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
using KCS.Models;
using KCS.ViewModels;
using DevExpress.Utils.MVVM.Services;
using System.IO;

namespace KCS.Views
{
    public partial class EditEmployee : DevExpress.XtraEditors.XtraUserControl
    {
        public EditEmployee()
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
            var fluentAPI = mvvmContext.OfType<EditEmployeeViewModel>();
            try
            {
                //fluentAPI.SetObjectDataSourceBinding(bindingSource,
                //  x => x.Supervisor);
            }
            catch (Exception ex)
            {
            }
        }

        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<EditEmployeeViewModel>();
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            

          
            fluentAPI.SetObjectDataSourceBinding(employeesBindingSource, x => x.EditEmployee);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceDep, x => x.DepartmentInfoDataSet);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceEmpType, x => x.EmployeesTypeInfoDataSet);

         

            mvvmContext.RegisterService(NotificationService.Create(alertControl));
           
            foreach (Control control in dataLayoutControl1.Controls)
            {
                BaseEdit edit = control as BaseEdit;
                if (edit == null || edit.DataBindings.Count == 0) continue;
                EditorHelpers.ApplyBindingSettings<Employees>(edit, dataLayoutControl1);

            }

            sbSelectPhoto.Click += (s, e) =>
            {
                //this.dataLayoutControl1.Validate();
                //fluentAPI.ViewModel.Save();
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = "";
                //dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlg.ValidateNames = true;
                //验证路径有效性
                dlg.CheckFileExists = true;
                //验证文件有效性
                dlg.CheckPathExists = true;

                dlg.Filter = "Image Files(*.JPG;*.jpeg)|*.JPG;*.jpeg|All files(*.*)|*.*";

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                if (getImageSize(dlg.FileName) > 5)
                {
                    KCS.Common.Utils.PopHintDialog.ShowMessage("The image is too large");
                    return;
                }

                Image imge = Image.FromFile(dlg.FileName);
                // Bitmap bm = new Bitmap(imge, 274, 303);
                EmpPhotoPictureEdit.Image = imge;

                fluentAPI.ViewModel.SetEmployeePhoto(dlg.FileName);


            };
        }
        private double getImageSize(string path)

        {

            FileInfo fileInfo = new FileInfo(path);

            double length = Convert.ToDouble(fileInfo.Length);

            double Size = length / 1024 / 1024;

            return Size;

        }
        void InitViewDisplay()
        {
            
            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            ItemForDepartmentID.Text = LanguageResource.GetDisplayString("DepartmentID");
            ItemForUserSID.Text = LanguageResource.GetDisplayString("SystemCode");
            ItemForUserID.Text = LanguageResource.GetDisplayString("EmployeeID");
            DepartmentIDLookUpEdit.Text = LanguageResource.GetDisplayString("Department");
            ItemForEmployeeTypeID.Text = LanguageResource.GetDisplayString("EmployeeType");
            ItemForUserName.Text = LanguageResource.GetDisplayString("EmployeeName");
            ItemForCardID.Text = LanguageResource.GetDisplayString("CardID");
            ItemForTitleName.Text = LanguageResource.GetDisplayString("TitleName");
            ItemForEmail.Text = LanguageResource.GetDisplayString("Email");
            ItemForSyncOrNot.Text = LanguageResource.GetDisplayString("SyncOrNot");
            ItemForIsTaOrNot.Text = LanguageResource.GetDisplayString("IsTaOrNot");
            SyncOrNotCheckEdit.Text = LanguageResource.GetDisplayString("DontSyncToDevices");
            IsTaOrNotCheckEdit.Text = LanguageResource.GetDisplayString("NotCheckAttendance");
           

            this.EmployeeTypeIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeTypeID", LanguageResource.GetDisplayString("EmployeeTypeId"), 124, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ListFiled", LanguageResource.GetDisplayString("Details"), 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});

            this.DepartmentIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentID", LanguageResource.GetDisplayString("DepartmentId"), 105, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ListField", LanguageResource.GetDisplayString("Details"), 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});

           

        }
       
    }
}
