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
using KCS.Models;
using KCS.Common.Utils;

namespace KCS.Views
{
    public partial class ReadTransAgain : DevExpress.XtraEditors.XtraUserControl
    {
        public ReadTransAgain()
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
            var fluentAPI = mvvmContext.OfType<ReadTransAgainViewModel>();


            

            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.DeviceInfoDataSet);
            }
            catch { }

            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.SelectionDevices, e => GetSelectedDevices());
            fluentAPI.SetBinding(dateEditStart,x => x.EditValue, x => x.StartDate);
            fluentAPI.SetBinding(dateEditEnd, x => x.EditValue, x => x.EndDate);
            fluentAPI.SetBinding(timeEditStart, x => x.EditValue, x => x.StartTime);
            fluentAPI.SetBinding(timeEditEnd, x => x.EditValue, x => x.EndTime);
        }
        void InitViewDisplay()
        {
            //ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            groupControlDevice.Text = LanguageResource.GetDisplayString("SelectDevices");
            groupControl1.Text = LanguageResource.GetDisplayString("FromText");
            groupControl2.Text = LanguageResource.GetDisplayString("ToText");
            lblCtlStartDate.Text = LanguageResource.GetDisplayString("StartDate");
            lblCtlEndDate.Text = LanguageResource.GetDisplayString("EndDate");
            lblCtlStartTime.Text = LanguageResource.GetDisplayString("StartTime");
            lblCtlEndTime.Text = LanguageResource.GetDisplayString("EndTime");
            colSlaveSID.Caption = LanguageResource.GetDisplayString("DeviceID");
            colIP.Caption = LanguageResource.GetDisplayString("DeviceIP");
            colSlaveName.Caption = LanguageResource.GetDisplayString("DeviceName");
            colSlaveDescription.Caption = LanguageResource.GetDisplayString("DeviceDescription");

        }
        IEnumerable<DeviceInfo> GetSelectedDevices()
        {
            return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as DeviceInfo);
        }
    }
}
