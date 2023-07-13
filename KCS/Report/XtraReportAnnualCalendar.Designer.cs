namespace KCS
{
    partial class XtraReportAnnualCalendar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XtraReportAnnualCalendar));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellDay = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellWeekDay = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellHoliday = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrTableCellHolidayType = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellHolidayNote = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrLabelMonth = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelPage = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabelDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfoTime = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrLabelHeader = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCellHeadDay = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellHeadWeek = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellHeadHoliday = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellHeadNote = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            resources.ApplyResources(this.Detail, "Detail");
            this.Detail.KeepTogether = true;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SnapLinePadding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CalendarDay", DevExpress.XtraReports.UI.XRColumnSortOrder.None),
            new DevExpress.XtraReports.UI.GroupField("LIST_WEEK", DevExpress.XtraReports.UI.XRColumnSortOrder.None),
            new DevExpress.XtraReports.UI.GroupField("HOLIDAY_CK", DevExpress.XtraReports.UI.XRColumnSortOrder.None),
            new DevExpress.XtraReports.UI.GroupField("HolidayType", DevExpress.XtraReports.UI.XRColumnSortOrder.None),
            new DevExpress.XtraReports.UI.GroupField("LIST_MEMO", DevExpress.XtraReports.UI.XRColumnSortOrder.None)});
            // 
            // xrTable2
            // 
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.xrTable2, "xrTable2");
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.StylePriority.UseBorders = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellDay,
            this.xrTableCellWeekDay,
            this.xrTableCellHoliday,
            this.xrTableCellHolidayType,
            this.xrTableCellHolidayNote});
            resources.ApplyResources(this.xrTableRow2, "xrTableRow2");
            this.xrTableRow2.Name = "xrTableRow2";
            // 
            // xrTableCellDay
            // 
            this.xrTableCellDay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CalendarDay", "{0}")});
            resources.ApplyResources(this.xrTableCellDay, "xrTableCellDay");
            this.xrTableCellDay.Name = "xrTableCellDay";
            this.xrTableCellDay.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCellWeekDay
            // 
            this.xrTableCellWeekDay.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCellWeekDay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LIST_WEEK")});
            resources.ApplyResources(this.xrTableCellWeekDay, "xrTableCellWeekDay");
            this.xrTableCellWeekDay.Name = "xrTableCellWeekDay";
            this.xrTableCellWeekDay.StylePriority.UseBorders = false;
            this.xrTableCellWeekDay.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCellHoliday
            // 
            this.xrTableCellHoliday.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1});
            resources.ApplyResources(this.xrTableCellHoliday, "xrTableCellHoliday");
            this.xrTableCellHoliday.Name = "xrTableCellHoliday";
            this.xrTableCellHoliday.StylePriority.UseTextAlignment = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPictureBox1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", null, "HolidayStatsImage")});
            resources.ApplyResources(this.xrPictureBox1, "xrPictureBox1");
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.StylePriority.UseBorders = false;
            // 
            // xrTableCellHolidayType
            // 
            this.xrTableCellHolidayType.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "HolidayType")});
            resources.ApplyResources(this.xrTableCellHolidayType, "xrTableCellHolidayType");
            this.xrTableCellHolidayType.Name = "xrTableCellHolidayType";
            this.xrTableCellHolidayType.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCellHolidayNote
            // 
            this.xrTableCellHolidayNote.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "LIST_MEMO")});
            resources.ApplyResources(this.xrTableCellHolidayNote, "xrTableCellHolidayNote");
            this.xrTableCellHolidayNote.Name = "xrTableCellHolidayNote";
            this.xrTableCellHolidayNote.StylePriority.UseTextAlignment = false;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabelMonth,
            this.xrLabelPage,
            this.xrLabelDate,
            this.xrPageInfoTime,
            this.xrPageInfo1,
            this.xrLabelHeader});
            resources.ApplyResources(this.TopMargin, "TopMargin");
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrLabelMonth
            // 
            this.xrLabelMonth.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "CalendarMonth")});
            resources.ApplyResources(this.xrLabelMonth, "xrLabelMonth");
            this.xrLabelMonth.Name = "xrLabelMonth";
            this.xrLabelMonth.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelMonth.StylePriority.UseFont = false;
            this.xrLabelMonth.StylePriority.UseTextAlignment = false;
            this.xrLabelMonth.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.xrLabelMonth_BeforePrint);
            // 
            // xrLabelPage
            // 
            resources.ApplyResources(this.xrLabelPage, "xrLabelPage");
            this.xrLabelPage.Name = "xrLabelPage";
            this.xrLabelPage.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelPage.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelDate
            // 
            resources.ApplyResources(this.xrLabelDate, "xrLabelDate");
            this.xrLabelDate.Name = "xrLabelDate";
            this.xrLabelDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelDate.StylePriority.UseTextAlignment = false;
            // 
            // xrPageInfoTime
            // 
            resources.ApplyResources(this.xrPageInfoTime, "xrPageInfoTime");
            this.xrPageInfoTime.Name = "xrPageInfoTime";
            this.xrPageInfoTime.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfoTime.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfoTime.StylePriority.UseTextAlignment = false;
            // 
            // xrPageInfo1
            // 
            resources.ApplyResources(this.xrPageInfo1, "xrPageInfo1");
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.StylePriority.UseTextAlignment = false;
            // 
            // xrLabelHeader
            // 
            resources.ApplyResources(this.xrLabelHeader, "xrLabelHeader");
            this.xrLabelHeader.Name = "xrLabelHeader";
            this.xrLabelHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabelHeader.StylePriority.UseFont = false;
            this.xrLabelHeader.StylePriority.UseTextAlignment = false;
            // 
            // BottomMargin
            // 
            resources.ApplyResources(this.BottomMargin, "BottomMargin");
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // xrTable1
            // 
            resources.ApplyResources(this.xrTable1, "xrTable1");
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseBorders = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCellHeadDay,
            this.xrTableCellHeadWeek,
            this.xrTableCellHeadHoliday,
            this.xrTableCellHeadNote});
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            this.xrTableRow1.Name = "xrTableRow1";
            // 
            // xrTableCellHeadDay
            // 
            resources.ApplyResources(this.xrTableCellHeadDay, "xrTableCellHeadDay");
            this.xrTableCellHeadDay.Name = "xrTableCellHeadDay";
            this.xrTableCellHeadDay.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCellHeadWeek
            // 
            resources.ApplyResources(this.xrTableCellHeadWeek, "xrTableCellHeadWeek");
            this.xrTableCellHeadWeek.Name = "xrTableCellHeadWeek";
            this.xrTableCellHeadWeek.StylePriority.UseBorders = false;
            this.xrTableCellHeadWeek.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCellHeadHoliday
            // 
            resources.ApplyResources(this.xrTableCellHeadHoliday, "xrTableCellHeadHoliday");
            this.xrTableCellHeadHoliday.Name = "xrTableCellHeadHoliday";
            this.xrTableCellHeadHoliday.StylePriority.UseTextAlignment = false;
            // 
            // xrTableCellHeadNote
            // 
            resources.ApplyResources(this.xrTableCellHeadNote, "xrTableCellHeadNote");
            this.xrTableCellHeadNote.Name = "xrTableCellHeadNote";
            this.xrTableCellHeadNote.StylePriority.UseTextAlignment = false;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.Name = "PageHeader";
            // 
            // GroupHeader1
            // 
            resources.ApplyResources(this.GroupHeader1, "GroupHeader1");
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("CalendarMonth", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.GroupUnion = DevExpress.XtraReports.UI.GroupUnion.WholePage;
            this.GroupHeader1.Name = "GroupHeader1";
            this.GroupHeader1.StylePriority.UseFont = false;
            this.GroupHeader1.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.GroupHeader1_BeforePrint_1);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.AnnulaCalendar);
            // 
            // XtraReportAnnualCalendar
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.GroupHeader1});
            this.DataSource = this.bindingSource;
            resources.ApplyResources(this, "$this");
            this.Version = "16.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraReports.UI.XRLabel xrLabelHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabelDate;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfoTime;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellHeadDay;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellHeadWeek;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellHeadHoliday;
        private DevExpress.XtraReports.UI.XRLabel xrLabelPage;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellHeadNote;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellDay;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellHolidayType;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellHolidayNote;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellHoliday;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellWeekDay;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLabelMonth;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
    }
}
