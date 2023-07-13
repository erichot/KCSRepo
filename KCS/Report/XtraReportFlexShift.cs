using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KCS.Common.DAL;
using KCS.Common.Utils;

namespace KCS.Report
{
    public partial class XtraReportFlexShift : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportFlexShift(string startDate, string endDate, object source)
        {
            InitializeComponent();

            if (SystemConfigure.LanguageSelect == "zh_TW" || SystemConfigure.LanguageSelect == "zh_CN")
            {//xrLblOverTime
               
               this.Font = new Font("宋体", AppHelper.GetDefaultChSize());
               this.xrLabelHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
               //this.xrLabelHeader1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);

            }
         // this.Report.ReportPrintOptions.
            xrLabelHeader.Text = KCS.Common.DAL.SystemConfigure.CompanyName;
            //xrLabelDate.Text = LanguageResource.GetDisplayString("DateText") + ":";
            xrLabelPage.Text = LanguageResource.GetDisplayString("PageText") + ":";
            //xrLabelDepartment.Text = LanguageResource.GetDisplayString("DepartmentName") + ":";


            //xrLblWeekdayName.Text = LanguageResource.GetDisplayString("OverTimehours");

            //xrLblWorkingDate.Text = LanguageResource.GetDisplayString("OndutyTime");
            //xrLblOffDuty2.Text = LanguageResource.GetDisplayString("OffdtuyTime");
            //xrLblOverTime2.Text = LanguageResource.GetDisplayString("OverTimehours");

            //xrLblOnDutyTime3.Text = LanguageResource.GetDisplayString("OndutyTime");
            //xrLblOffDuty3.Text = LanguageResource.GetDisplayString("OffdtuyTime");
            //xrLblOverTime3.Text = LanguageResource.GetDisplayString("OverTimehours");

            // xrLblOnDutyTime4.Text = LanguageResource.GetDisplayString("OndutyTime");
            //xrLblOffDuty4.Text = LanguageResource.GetDisplayString("OffdtuyTime");
            //xrLblOverTime4.Text = LanguageResource.GetDisplayString("OverTimehours");


            //xrLblDay.Text = LanguageResource.GetDisplayString("DateText");

            //xrLabelHeader1.Text = startDate + " ~ " + endDate + " " + LanguageResource.GetDisplayString("ReportDetails");

            xrLblDateBetweenTitle.Text = LanguageResource.GetDisplayString("DateText");
            xrLblWorkingDateBetween.Text = startDate + "～" + endDate;

            xrLblUserID.Text = LanguageResource.GetDisplayString("LoginViewUserId");
            xrLblUserName.Text = LanguageResource.GetDisplayString("EmployeeName");
            xrLblWorkingDate.Text = LanguageResource.GetDisplayString("DateText");
            xrLblWeekdayName.Text = LanguageResource.GetDisplayString("WeekdayName");
            xrLblOnDutyTime.Text = LanguageResource.GetDisplayString("OndutyTime");
            xrLblOffDuty.Text = LanguageResource.GetDisplayString("OffdtuyTime");
            xrLblWorkingHours.Text = LanguageResource.GetDisplayString("WorkingHours");

            this.DataSource = source;
        }
        


    }
}
