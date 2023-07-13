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
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace KCS.Views
{
    public partial class FindDevice : DevExpress.XtraEditors.XtraUserControl
    {
        public FindDevice()
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
            try
            {
                var fluentAPI = mvvmContext.OfType<FindDeviceViewModel>();
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                   x => x.RegDevicesDataSet);
               
            }
            catch { }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<FindDeviceViewModel>();

           // Messenger.Default.Register<RebindMessage<FindDeviceViewModel>>(this, x => RebindDataSource());
            Messenger.Default.Register<UpdateCountMessage<FindDeviceViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));
           
            fluentAPI.BindCommand(bbiRefresh, x => x.Refresh());
            fluentAPI.BindCommand(bbiEdit, x => x.Edit(null),  x => x.SelectedRegDevice);
            fluentAPI.BindCommand(bbiClose, x => x.Close());

            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.RegDevicesDataSet);
               
            }
            catch { }
            barHeaderItem1.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), fluentAPI.ViewModel.RecordCount);
                
           
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedRegDevice,
                    args => args.Row as KCS.Models.RegDevice,
                    (gView, employee) => gView.FocusedRowHandle = gView.FindRow(employee));
           
            
            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                        .EventToCommand(
                            x => x.Edit(null), x => x.SelectedRegDevice,
                            args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));
            
        }
        void InitViewDisplay()
        {
            //ribbonPageGroupRefresh.Text = LanguageResource.GetDisplayString("RefreshText");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiRefresh.Caption = LanguageResource.GetDisplayString("RefreshText");
            ribbonPageGroupEdit.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            bbiEdit.Caption = LanguageResource.GetDisplayString("ToolBarEdit");
            colSlaveSID.Caption = LanguageResource.GetDisplayString("DeviceID");
            colIP.Caption = LanguageResource.GetDisplayString("ItemForIP");

            colDeviceType.Caption = LanguageResource.GetDisplayString("DeviceType");
            colDeviceVersion.Caption = LanguageResource.GetDisplayString("FirmwareVersion");
            

         }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<FindDeviceViewModel> message)
        {
            barHeaderItem1.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
            
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
             RebindDataSource();
        }
    }
}
