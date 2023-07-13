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
using DevExpress.Mvvm;
using KCS.Common.Utils;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;

namespace KCS.Views
{
    public partial class DeviceSyncSetting : DevExpress.XtraEditors.XtraUserControl
    {
        public DeviceSyncSetting()
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
            var fluentAPI = mvvmContext.OfType<DeviceSyncSettingViewModel>();
            Messenger.Default.Register<UpdateCountMessage<DeviceSyncSettingViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));

            //fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EmployeesSyncStatusDataSet);
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
               .SetBinding(x => x.SelectedEmployee,
                   args => args.Row as EmployeeSync,
                   (gView, DeviceInfo) => gView.FocusedRowHandle = gView.FindRow(DeviceInfo));

            fluentAPI.WithEvent<ColumnView, CellValueChangedEventArgs>(gridView, "CellValueChanging")
               .SetBinding(x => x.IsActive,
                  args => args.Value,
                   (gView, EmployeeInfo) => gView.FocusedRowHandle = gView.FindRow(EmployeeInfo));

            bbiSave.ItemClick += (s, e) =>
            {
                this.gridView.CloseEditor();
                this.gridView.UpdateCurrentRow();
                //this.gridView.RefreshRow(gridView.FocusedRowHandle);
                fluentAPI.ViewModel.Save();
            };
            
        }
        void InitViewDisplay()
        {
            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            colCardID.Caption = LanguageResource.GetDisplayString("CardID");
            colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");
            colIsReplicated.Caption = LanguageResource.GetDisplayString("IsReplicated");
            colTimeReplicated.Caption = LanguageResource.GetDisplayString("TimeReplicated");
            colInActive.Caption = LanguageResource.GetDisplayString("AllowSync");

            ribbonPageGroupSave.Text = bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            ribbonPageGroupClose.Text = bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
           
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<DeviceSyncSettingViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }
    }
}
