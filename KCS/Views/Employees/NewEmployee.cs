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
using DevExpress.Utils.MVVM.Services;
using System.IO;

namespace KCS.Views
{
    public partial class NewEmployee : DevExpress.XtraEditors.XtraUserControl
    {
        public NewEmployee()
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
            var fluentAPI = mvvmContext.OfType<NewEmployeeViewModel>();
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
            var fluentAPI = mvvmContext.OfType<NewEmployeeViewModel>();
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiSaveAndClose, x => x.SaveAndClose());
            fluentAPI.BindCommand(bbiSaveAndNew, x => x.SaveAndNew());
           // fluentAPI.BindCommand(sbSelectPhoto, x => x.SelectPhoto());


            fluentAPI.SetBinding(radioGroupSync, x => x.EditValue, x => x.SyncSetting);

            fluentAPI.SetObjectDataSourceBinding(bindingSourceDevices, x => x.DeviceInfoDataSet);
            fluentAPI.SetObjectDataSourceBinding(employeesBindingSource, x => x.NewEmployee);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceDep, x => x.DepartmentInfoDataSet);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceEmpType, x => x.EmployeesTypeInfoDataSet);

            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.SelectionDevices, e => GetSelectedDevices());

            // Date:    2024/12/03
            // Ver:     1.1.6.4            
            fluentAPI.SetBinding(rdoAllowTimeByDefault, x => x.EditValue, x => x.DefaultAllowTimeSelection);
            

            mvvmContext.RegisterService(NotificationService.Create(alertControl));
            SyncOrNotCheckEdit.EditValueChanged += (s, e) =>
                {
                    if (((CheckEdit)s).Checked)
                    {
                        ItemForSyncDevices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        ItemForBtnSelectDevices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;  
                    }
                    else
                    {
                        ItemForSyncDevices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        if(radioGroupSync.SelectedIndex == 0 )
                        {
                            ItemForBtnSelectDevices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        }
                        else
                        {
                            ItemForBtnSelectDevices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                        }
                    }
                };
            radioGroupSync.EditValueChanged += (s, e) =>
            {
                if (((RadioGroup)s).SelectedIndex == 0)
                {
                    ItemForBtnSelectDevices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;                    
                }
                else
                {
                    ItemForBtnSelectDevices.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;          
                }
            };
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
              
                if(getImageSize(dlg.FileName)>5)
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
            this.gridView.BestFitColumns();
            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiSaveAndClose.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndClose");
            bbiSaveAndNew.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndNew");
            bbiReset.Caption = LanguageResource.GetDisplayString("ToolBarReset");
            bbiDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            ItemForUserID.Text = LanguageResource.GetDisplayString("EmployeeID");
            DepartmentIDLookUpEdit.Text = LanguageResource.GetDisplayString("Department");
            ItemForDepartmentID.Text = LanguageResource.GetDisplayString("DepartmentID");
            ItemForEmployeeTypeID.Text = LanguageResource.GetDisplayString("EmployeeType");
            ItemForUserName.Text = LanguageResource.GetDisplayString("EmployeeName");
            ItemForCardID.Text = LanguageResource.GetDisplayString("CardID");
            ItemForTitleName.Text = LanguageResource.GetDisplayString("TitleName");
            ItemForEmail.Text = LanguageResource.GetDisplayString("Email");
            ItemForSyncOrNot.Text = LanguageResource.GetDisplayString("SyncOrNot");
            SyncOrNotCheckEdit.Text = LanguageResource.GetDisplayString("DontSyncToDevices");
            ItemForSyncDevices.Text = LanguageResource.GetDisplayString("SyncSetting");

            // Date:    2024/12/03
            // Ver:     1.1.6.4
            ItemForAllowedTime.Text = LanguageResource.GetDisplayString("DefaultAllowTime");
            rdoAllowTimeByDefault.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
                new DevExpress.XtraEditors.Controls.RadioGroupItem(0,  "00:00 ~ 23:59"),
                new DevExpress.XtraEditors.Controls.RadioGroupItem(1,  "00:00 ~ 00:00")});
            rdoAllowTimeByDefault.SelectedIndex = 0;
            //rdoAllowTimeByDefault.Properties.Items[1].Value = true;
            //rdoAllowTimeByDefault.SelectedIndex = 1;
            //rdoAllowTimeByDefault.Properties.Items[0].Value = true;
            //rdoAllowTimeByDefault.Properties.Items[1].Value = true;


            this.radioGroupSync.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0,  LanguageResource.GetDisplayString("SyncToAll")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1,  LanguageResource.GetDisplayString("SynToSelectedDevice"))});

            this.EmployeeTypeIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployeeTypeID", LanguageResource.GetDisplayString("EmployeeTypeId"), 124, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ListFiled", LanguageResource.GetDisplayString("Details"), 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});

            this.DepartmentIDLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepartmentID", LanguageResource.GetDisplayString("DepartmentId"), 105, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ListField", LanguageResource.GetDisplayString("Details"), 56, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});

            colID.Caption = LanguageResource.GetDisplayString("DeviceID");
            colIP.Caption = LanguageResource.GetDisplayString("DeviceIP");
            colSlaveName.Caption = LanguageResource.GetDisplayString("DeviceName");
            colSlaveDescription.Caption = LanguageResource.GetDisplayString("DeviceDescription");

            drBtnSelectDevices.Text = LanguageResource.GetDisplayString("SelectDevices");
            
        }
        IEnumerable<DeviceInfo> GetSelectedDevices()
        {
            
            return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as DeviceInfo);
        }
    }
}
