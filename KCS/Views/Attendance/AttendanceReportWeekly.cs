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

namespace KCS.Views
{
    public partial class AttendanceReportWeekly : DevExpress.XtraEditors.XtraUserControl
    {
        public AttendanceReportWeekly()
        {
            InitializeComponent();
            //this.Size = new Size(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
            
        }
        protected override void OnLoad(System.EventArgs e)
        {

            base.OnLoad(e);
            //gridControl.Load += gridControl_Load;
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();

        }
        void InitViewDisplay()
        {
            //lblCtlReportType.Text = LanguageResource.GetDisplayString("ReportTypeText");
            //this.radioGroupRecordType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            // new DevExpress.XtraEditors.Controls.RadioGroupItem(0,  LanguageResource.GetDisplayString("TotalText")),
            // new DevExpress.XtraEditors.Controls.RadioGroupItem(1,  LanguageResource.GetDisplayString("DetailText"))
            //});
            //lblCtlJobCodeDisplay.Text = LanguageResource.GetDisplayString("JobCodeDisplayText");
            //checkEditIncloudJobCode.Text = LanguageResource.GetDisplayString("IncludeJobCodeText");
           
        }
        void InitBindings()
        {
        }
        
    }
}
