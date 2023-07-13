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
using DevExpress.Mvvm;
using KCS.Common.Utils;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;

namespace KCS.Views
{
    public partial class SyncSetting : DevExpress.XtraEditors.XtraUserControl
    {
        public SyncSetting()
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
            var fluentAPI = mvvmContext.OfType<SyncSettingViewModel>();
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());

            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.DeviceSyncStatusDataSet);
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
               .SetBinding(x => x.SelectedDevice,
                   args => args.Row as DeviceInfo,
                   (gView, DeviceInfo) => gView.FocusedRowHandle = gView.FindRow(DeviceInfo));

            fluentAPI.WithEvent<ColumnView, CellValueChangedEventArgs>(gridView, "CellValueChanging")
               .SetBinding(x => x.SyncOrNot,
                  args => args.Value ,
                   (gView, DeviceInfo) => gView.FocusedRowHandle = gView.FindRow(DeviceInfo));

            Messenger.Default.Register<UpdateCountMessage<SyncSettingViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));
        }
        void InitViewDisplay()
        {
            colID.Caption = LanguageResource.GetDisplayString("DeviceID");
            colIP.Caption = LanguageResource.GetDisplayString("DeviceIP");
            colSlaveName.Caption = LanguageResource.GetDisplayString("DeviceName");
            colSlaveDescription.Caption = LanguageResource.GetDisplayString("DeviceDescription");
            colIsSyncOrNot.Caption = LanguageResource.GetDisplayString("SetToSync");
            colUserIsReplicatiedOrNot.Caption = LanguageResource.GetDisplayString("EmployeeDataReplicated");
            colFinger1IsReplicatiedOrNot.Caption = LanguageResource.GetDisplayString("Finger1Replicated");
            colFinger2IsReplicatiedOrNot.Caption = LanguageResource.GetDisplayString("Finger2Replicated");
            ribbonPageGroupSave.Text = bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            ribbonPageGroupClose.Text = bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            gridView.Columns[4].OptionsColumn.AllowEdit = true;
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<SyncSettingViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }
    }
}
