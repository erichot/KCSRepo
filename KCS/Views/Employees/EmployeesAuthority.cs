using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.ViewModels;
using KCS.Common.Utils;
using KCS.Controls;
using KCS.Models;
using DevExpress.Mvvm;

namespace KCS.Views
{
    public partial class EmployeesAuthority : DevExpress.XtraEditors.XtraUserControl
    {
        public EmployeesAuthority()
        {
            InitializeComponent();
        }//CustomButtonChecked
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }

        void RebindDataSource()
        {


            var fluentAPI = mvvmContext.OfType<EmployeesAuthorityViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSourceSyncStatus, x => x.AutoritySyncStatusDataSet);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KCS Error");
            }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<EmployeesAuthorityViewModel>();
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());

            // Add: 2023/10/13
            // Ver:
            fluentAPI.BindCommand(bbiReport, x => x.AllowTimeReport());

            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.DeviceInfoDataSet);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceSyncStatus, x => x.AutoritySyncStatusDataSet);

            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.SelectionDevices, e => GetSelectedDevices());

            Messenger.Default.Register<RebindMessage<EmployeesAuthorityViewModel>>(this, x => RebindDataSource());
            fluentAPI.SetBinding(cmbBoxUserGroup, c => c.EditValue, x => x.SelectUserGroup);
            fluentAPI.SetBinding(timeEditStart, c => c.EditValue, x => x.StartTime);
            fluentAPI.SetBinding(timeEditEnd, c => c.EditValue, x => x.EndTime);
            
            groupControl.CustomButtonChecked += (s, e) =>
                {
                   
                    lblSimpleTile.Visible = false;
                    lblCtlStartTime.Visible = false;
                    timeEditStart.Visible = false;
                    lblCtlEndTime.Visible = false;
                    timeEditEnd.Visible = false;

                    lblCtlAdvTile.Visible = true;
                    cmbBoxUserGroup.Visible = true;
                    fluentAPI.ViewModel.bUseAdvAccessControlSet = true;
                    
                    
                };
            groupControl.CustomButtonUnchecked += (s, e) =>
            {
                
                lblSimpleTile.Visible = true;
                lblCtlStartTime.Visible = true;
                timeEditStart.Visible = true;
                lblCtlEndTime.Visible = true;
                timeEditEnd.Visible = true;

                lblCtlAdvTile.Visible = false;
                cmbBoxUserGroup.Visible = false;
                fluentAPI.ViewModel.bUseAdvAccessControlSet = false;
                
            };
          
            
        }
        void InitViewDisplay()
        {
            lblCtlAdvTile.Visible = false;
            cmbBoxUserGroup.Visible = false;

            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            colSlaveSID.Caption = LanguageResource.GetDisplayString("DeviceID");
            colIP.Caption = LanguageResource.GetDisplayString("DeviceIP");
            colSlaveName.Caption = LanguageResource.GetDisplayString("DeviceName");
            colSlaveDescription.Caption = LanguageResource.GetDisplayString("DeviceDescription");

            groupControlDevice.Text = LanguageResource.GetDisplayString("SelectDevices");
            groupControl.CustomHeaderButtons[0].Properties.Caption = LanguageResource.GetDisplayString("UseAdvancedAccessControlSetting");

            lblSimpleTile.Text = LanguageResource.GetDisplayString("AccessGrantedTime");
            lblCtlAdvTile.Text = LanguageResource.GetDisplayString("AccessGrantedGroup");
            lblCtlStartTime.Text = LanguageResource.GetDisplayString("StartTime");
            lblCtlEndTime.Text = LanguageResource.GetDisplayString("EndTime");

            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 1", 1));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 2", 2));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 3", 3));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 4", 4));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 5", 5));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 6", 6));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 7", 7));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 8", 8));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 9", 9));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 10", 10));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 11", 11));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 12", 12));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 13(VIP)", 13));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("BlackList"), 14));
            cmbBoxUserGroup.Properties.Items.Add(new ComboxData(LanguageResource.GetDisplayString("UserGroupText") + " 15", 15));
            cmbBoxUserGroup.SelectedIndex = 0;

            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            colCardID.Caption = LanguageResource.GetDisplayString("CardID");
            colGroupID.Caption = LanguageResource.GetDisplayString("GroupIDText");
            colStartTimeStr.Caption = LanguageResource.GetDisplayString("StartTime");
            colEndTimeStr.Caption = LanguageResource.GetDisplayString("EndTime");
            colIsReplicated.Caption = LanguageResource.GetDisplayString("IsReplicated");
            colSlaveSID1.Caption = LanguageResource.GetDisplayString("DeviceID");
            gridView.BestFitColumns();
            gridView1.BestFitColumns();
        }
        IEnumerable<DeviceInfo> GetSelectedDevices()
        {
            return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as DeviceInfo);
        }
    }
}
