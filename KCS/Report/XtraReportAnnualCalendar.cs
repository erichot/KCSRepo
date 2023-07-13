using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Globalization;
using KCS.Common.Utils;
using KCS.Common.DAL;

namespace KCS
{
    public partial class XtraReportAnnualCalendar : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportAnnualCalendar(object source,int year )
        {
            InitializeComponent();
            if (SystemConfigure.LanguageSelect == "zh_TW" || SystemConfigure.LanguageSelect == "zh_CN")
            {
                this.Font = new Font("宋体", AppHelper.GetDefaultChSize());
                this.xrLabelHeader.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
                this.xrLabelMonth.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold);
            }
            this.DataSource = source;
            xrLabelHeader.Text = LanguageResource.GetDisplayString("CalendarText") + "  " + year.ToString();
            xrLabelDate.Text = LanguageResource.GetDisplayString("DateText") + ":";
            xrLabelPage.Text = LanguageResource.GetDisplayString("PageText") + ":";
            xrTableCellHeadDay.Text  = LanguageResource.GetDisplayString("DayText");
            xrTableCellHeadWeek.Text = LanguageResource.GetDisplayString("WeekdayName");
            xrTableCellHeadHoliday.Text = LanguageResource.GetDisplayString("HolidaySetText");
            xrTableCellHeadNote.Text = LanguageResource.GetDisplayString("RemarkText");
        }
        
        private int month = 0;
        private DateTimeFormatInfo formatInfo = DateTimeFormatInfo.CurrentInfo;

        
        
        private void GroupHeader1_BeforePrint_1(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            e.Cancel = month == Convert.ToInt32(GetCurrentColumnValue("CalendarMonth"));
        }

        private void xrLabelMonth_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            month = Convert.ToInt32(GetCurrentColumnValue("CalendarMonth"));
            ((XRLabel)sender).Text = formatInfo.MonthNames[month - 1];
        }
    }
}
