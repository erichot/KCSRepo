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

namespace KCS.Views
{
    public partial class ExportDatas : DevExpress.XtraEditors.XtraUserControl
    {
        public ExportDatas()
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
        void UpdateProcessBar()
        {
            var fluentAPI = mvvmContext.OfType<ExportDatasViewModel>();
            fluentAPI.SetBinding(progressBarControl, x => x.Visible, x => x.proBarVisible);
            fluentAPI.SetBinding(progressBarControl, x => x.Position, x => x.proBarValue);
            System.Windows.Forms.Application.DoEvents();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ExportDatasViewModel>();

            Messenger.Default.Register<RebindMessage<ExportDatasViewModel>>(this, x => UpdateProcessBar());
            fluentAPI.SetBinding(dateEditStart, x => x.EditValue, x => x.StartDate);
            fluentAPI.SetBinding(dateEditEnd, x => x.EditValue, x => x.EndDate);
            fluentAPI.SetBinding(timeEditStart, x => x.EditValue, x => x.StartTime);
            fluentAPI.SetBinding(timeEditEnd, x => x.EditValue, x => x.EndTime);
            fluentAPI.SetBinding(progressBarControl, x => x.Visible, x => x.proBarVisible); 
            fluentAPI.SetBinding(checkEditExportAll, x => x.Checked, x => x.checkExportAllDatas);

            fluentAPI.SetBinding(progressBarControl, x => x.Position, x => x.proBarValue);
            fluentAPI.BindCommand(sbExportDatas,x => x.ExportDatas());
        }
        void InitViewDisplay()
        {
            //ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
           
            groupControl1.Text = LanguageResource.GetDisplayString("FromText");
            groupControl2.Text = LanguageResource.GetDisplayString("ToText");

            lblCtlStartDate.Text = LanguageResource.GetDisplayString("StartDate");
            lblCtlEndDate.Text = LanguageResource.GetDisplayString("EndDate");
            lblCtlStartTime.Text = LanguageResource.GetDisplayString("StartTime");
            lblCtlEndTime.Text = LanguageResource.GetDisplayString("EndTime");

            progressBarControl.Properties.Minimum = 0;
            progressBarControl.Properties.Maximum = 100;
            progressBarControl.Properties.Step = 1;
            progressBarControl.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            progressBarControl.Position = 0;
            progressBarControl.Properties.ShowTitle = true;
            progressBarControl.Properties.PercentView = true;
            progressBarControl.Properties.ProgressKind = DevExpress.XtraEditors.Controls.ProgressKind.Horizontal;

            sbExportDatas.Text = LanguageResource.GetDisplayString("ExportDataMannual");
        }
    }
}
