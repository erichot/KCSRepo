using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using KCS.Common.Utils;
using KCS.Common.DAL;

namespace KCS.Report
{
    public partial class XtraReportAttendanceDetails : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportAttendanceDetails(string startDate,string endDate,object source)
        {
            InitializeComponent();

            if (SystemConfigure.LanguageSelect == "zh_TW" || SystemConfigure.LanguageSelect == "zh_CN")
            {//xrLblOverTime
               
               this.Font = new Font("宋体", AppHelper.GetDefaultChSize());
               this.xrLabelHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
               this.xrLabelHeader1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);

            }
         // this.Report.ReportPrintOptions.
            xrLabelHeader.Text = KCS.Common.DAL.SystemConfigure.CompanyName;
            xrLabelDate.Text = LanguageResource.GetDisplayString("DateText") + ":";
            xrLabelPage.Text = LanguageResource.GetDisplayString("PageText") + ":";
            xrLabelDepartment.Text = LanguageResource.GetDisplayString("DepartmentName") + ":";
            xrLabelEmpId.Text = LanguageResource.GetDisplayString("EmployeeID") + ":";
            xrLabelEmpName.Text = LanguageResource.GetDisplayString("EmployeeName") + ":";

            xrLblDay.Text = LanguageResource.GetDisplayString("DateText");
            xrLblListType.Text = LanguageResource.GetDisplayString("AccessControlHoliType");
            xrLblOnDutyTime.Text = LanguageResource.GetDisplayString("OndutyTime");
            xrLblOffDuty.Text = LanguageResource.GetDisplayString("OffdtuyTime");
            xrLblRestStart.Text = LanguageResource.GetDisplayString("RestStartTime");
            xrLblRestEnd.Text = LanguageResource.GetDisplayString("RestEndTime");
            xrLblLateMins.Text = LanguageResource.GetDisplayString("LateMinutes");
            xrLblLeaveEarlyMin.Text = LanguageResource.GetDisplayString("LeavEarlyMinutes");
            xrLblTrunTime.Text = LanguageResource.GetDisplayString("Attendancehours");
            xrLblAbsentHours.Text = LanguageResource.GetDisplayString("Absenthours");
            xrLblLeaveType.Text = LanguageResource.GetDisplayString("LeaveCategoryText");
            xrLblLeaveTime.Text = LanguageResource.GetDisplayString("LeaveHours");
            xrLblOverTime.Text = LanguageResource.GetDisplayString("OverTimehours");
            xrLblSum.Text = LanguageResource.GetDisplayString("TotalText") + ":";
            xrLabelHeader1.Text = startDate + " ~ " + endDate + " " + LanguageResource.GetDisplayString("ReportDetails");
           
            this.DataSource = source;
        }

    }
}
