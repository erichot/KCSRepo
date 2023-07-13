namespace KCS.Views
{
    partial class AttendanceReportSetView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceReportSetView));
            this.checkByAttendanceRecords = new DevExpress.XtraEditors.CheckEdit();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblCtlTo = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.lblCtlFrom = new DevExpress.XtraEditors.LabelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceEmBrief = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.biEdit = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToPDF = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDailyReport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMonthlyReport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiMonthlySimplifiedReport = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFlexShiftReport = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupReport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.checkByAttendanceRecords.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmBrief)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // checkByAttendanceRecords
            // 
            this.checkByAttendanceRecords.Location = new System.Drawing.Point(604, 79);
            this.checkByAttendanceRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkByAttendanceRecords.Name = "checkByAttendanceRecords";
            this.checkByAttendanceRecords.Properties.Caption = "Calculate attendance record only";
            this.checkByAttendanceRecords.Size = new System.Drawing.Size(392, 26);
            this.checkByAttendanceRecords.TabIndex = 8;
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(858, 28);
            this.dateEditEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateEditEnd.Size = new System.Drawing.Size(206, 28);
            this.dateEditEnd.TabIndex = 7;
            // 
            // lblCtlTo
            // 
            this.lblCtlTo.Location = new System.Drawing.Point(814, 33);
            this.lblCtlTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlTo.Name = "lblCtlTo";
            this.lblCtlTo.Size = new System.Drawing.Size(21, 22);
            this.lblCtlTo.TabIndex = 6;
            this.lblCtlTo.Text = "To";
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(599, 28);
            this.dateEditStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dateEditStart.Size = new System.Drawing.Size(206, 28);
            this.dateEditStart.TabIndex = 5;
            // 
            // lblCtlFrom
            // 
            this.lblCtlFrom.Location = new System.Drawing.Point(536, 33);
            this.lblCtlFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlFrom.Name = "lblCtlFrom";
            this.lblCtlFrom.Size = new System.Drawing.Size(40, 22);
            this.lblCtlFrom.TabIndex = 4;
            this.lblCtlFrom.Text = "From";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSourceEmBrief;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(20);
            this.gridControl.Name = "gridControl";
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1628, 519);
            this.gridControl.TabIndex = 24;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // bindingSourceEmBrief
            // 
            this.bindingSourceEmBrief.DataSource = typeof(KCS.Models.EmployeeBrief);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserSID,
            this.colUserID,
            this.colDepartmentID,
            this.colDepartmentName,
            this.colUserName,
            this.colCardID});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 1;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindNullPrompt = "Search Employees (Ctrl + F)";
            this.gridView.OptionsFind.ShowClearButton = false;
            this.gridView.OptionsFind.ShowFindButton = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colUserSID
            // 
            this.colUserSID.FieldName = "UserSID";
            this.colUserSID.Name = "colUserSID";
            this.colUserSID.OptionsColumn.AllowEdit = false;
            this.colUserSID.OptionsColumn.ReadOnly = true;
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.OptionsColumn.AllowEdit = false;
            this.colUserID.OptionsColumn.ReadOnly = true;
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 1;
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.OptionsColumn.AllowEdit = false;
            this.colDepartmentID.OptionsColumn.ReadOnly = true;
            this.colDepartmentID.Visible = true;
            this.colDepartmentID.VisibleIndex = 2;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.OptionsColumn.AllowEdit = false;
            this.colDepartmentName.OptionsColumn.ReadOnly = true;
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 2;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.ReadOnly = true;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 3;
            // 
            // colCardID
            // 
            this.colCardID.FieldName = "CardID";
            this.colCardID.Name = "colCardID";
            this.colCardID.OptionsColumn.AllowEdit = false;
            this.colCardID.OptionsColumn.ReadOnly = true;
            this.colCardID.Visible = true;
            this.colCardID.VisibleIndex = 4;
            // 
            // layoutView
            // 
            this.layoutView.CardCaptionFormat = "{3}";
            this.layoutView.CardMinSize = new System.Drawing.Size(488, 310);
            this.layoutView.FieldCaptionFormat = "{0}";
            this.layoutView.GridControl = this.gridControl;
            this.layoutView.Name = "layoutView";
            this.layoutView.OptionsBehavior.AllowExpandCollapse = false;
            this.layoutView.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutView.OptionsBehavior.Editable = false;
            this.layoutView.OptionsBehavior.ReadOnly = true;
            this.layoutView.OptionsFind.AlwaysVisible = true;
            this.layoutView.OptionsFind.FindNullPrompt = "Search Shift Table (Ctrl + F)";
            this.layoutView.OptionsFind.ShowClearButton = false;
            this.layoutView.OptionsFind.ShowCloseButton = false;
            this.layoutView.OptionsFind.ShowFindButton = false;
            this.layoutView.OptionsItemText.TextToControlDistance = 2;
            this.layoutView.OptionsMultiRecordMode.MultiRowScrollBarOrientation = DevExpress.XtraGrid.Views.Layout.ScrollBarOrientation.Vertical;
            this.layoutView.OptionsSelection.MultiSelect = true;
            this.layoutView.OptionsView.AllowHotTrackFields = false;
            this.layoutView.OptionsView.FocusRectStyle = DevExpress.XtraGrid.Views.Layout.FocusRectStyle.None;
            this.layoutView.OptionsView.ShowHeaderPanel = false;
            this.layoutView.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.layoutView.TemplateCard = null;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.biEdit,
            this.biDelete,
            this.bbiExportToXlsx,
            this.bbiExportToPDF,
            this.bbiClose,
            this.bbiDailyReport,
            this.bbiMonthlyReport,
            this.bbiMonthlySimplifiedReport,
            this.bbiFlexShiftReport});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonControl.MaxItemId = 2;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1634, 184);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // biEdit
            // 
            this.biEdit.Caption = "Edit";
            this.biEdit.Id = 1;
            this.biEdit.ImageOptions.Image = global::KCS.Properties.Resources.icon_edit_16;
            this.biEdit.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_edit_32;
            this.biEdit.Name = "biEdit";
            // 
            // biDelete
            // 
            this.biDelete.Caption = "Delete";
            this.biDelete.Id = 2;
            this.biDelete.ImageOptions.Image = global::KCS.Properties.Resources.icon_delete_16;
            this.biDelete.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_delete_32;
            this.biDelete.Name = "biDelete";
            // 
            // bbiExportToXlsx
            // 
            this.bbiExportToXlsx.Caption = "Export To XLSX";
            this.bbiExportToXlsx.Id = 3;
            this.bbiExportToXlsx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportToXlsx.ImageOptions.Image")));
            this.bbiExportToXlsx.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportToXlsx.ImageOptions.LargeImage")));
            this.bbiExportToXlsx.Name = "bbiExportToXlsx";
            // 
            // bbiExportToPDF
            // 
            this.bbiExportToPDF.Caption = "Export To PDF";
            this.bbiExportToPDF.Id = 4;
            this.bbiExportToPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportToPDF.ImageOptions.Image")));
            this.bbiExportToPDF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportToPDF.ImageOptions.LargeImage")));
            this.bbiExportToPDF.Name = "bbiExportToPDF";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
            this.bbiClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.LargeImage")));
            this.bbiClose.Name = "bbiClose";
            // 
            // bbiDailyReport
            // 
            this.bbiDailyReport.Caption = "Daily Report";
            this.bbiDailyReport.Id = 8;
            this.bbiDailyReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDailyReport.ImageOptions.Image")));
            this.bbiDailyReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDailyReport.ImageOptions.LargeImage")));
            this.bbiDailyReport.Name = "bbiDailyReport";
            // 
            // bbiMonthlyReport
            // 
            this.bbiMonthlyReport.Caption = "Mothly Report";
            this.bbiMonthlyReport.Id = 9;
            this.bbiMonthlyReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiMonthlyReport.ImageOptions.Image")));
            this.bbiMonthlyReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiMonthlyReport.ImageOptions.LargeImage")));
            this.bbiMonthlyReport.Name = "bbiMonthlyReport";
            this.bbiMonthlyReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMonthlyReport_ItemClick);
            // 
            // bbiMonthlySimplifiedReport
            // 
            this.bbiMonthlySimplifiedReport.Caption = "Simplified Report";
            this.bbiMonthlySimplifiedReport.Id = 10;
            this.bbiMonthlySimplifiedReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiMonthlySimplifiedReport.ImageOptions.Image")));
            this.bbiMonthlySimplifiedReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiMonthlySimplifiedReport.ImageOptions.LargeImage")));
            this.bbiMonthlySimplifiedReport.Name = "bbiMonthlySimplifiedReport";
            this.bbiMonthlySimplifiedReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiMonthlySimplifiedReport_ItemClick);
            // 
            // bbiFlexShiftReport
            // 
            this.bbiFlexShiftReport.Caption = "Flex Report";
            this.bbiFlexShiftReport.Id = 1;
            this.bbiFlexShiftReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiFlexShiftReport.ImageOptions.Image")));
            this.bbiFlexShiftReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiFlexShiftReport.ImageOptions.LargeImage")));
            this.bbiFlexShiftReport.Name = "bbiFlexShiftReport";
            this.bbiFlexShiftReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFlexShiftReport_ItemClick);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupActions,
            this.ribbonPageGroupReport});
            this.ribbonPage2.Name = "ribbonPage2";
            // 
            // ribbonPageGroupActions
            // 
            this.ribbonPageGroupActions.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroupActions.Name = "ribbonPageGroupActions";
            this.ribbonPageGroupActions.ShowCaptionButton = false;
            this.ribbonPageGroupActions.Text = "Actions";
            // 
            // ribbonPageGroupReport
            // 
            this.ribbonPageGroupReport.ItemLinks.Add(this.bbiDailyReport);
            this.ribbonPageGroupReport.ItemLinks.Add(this.bbiMonthlyReport);
            this.ribbonPageGroupReport.ItemLinks.Add(this.bbiMonthlySimplifiedReport);
            this.ribbonPageGroupReport.ItemLinks.Add(this.bbiFlexShiftReport);
            this.ribbonPageGroupReport.Name = "ribbonPageGroupReport";
            this.ribbonPageGroupReport.ShowCaptionButton = false;
            this.ribbonPageGroupReport.Text = "Attendance Report";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.checkByAttendanceRecords);
            this.panelControl2.Controls.Add(this.dateEditStart);
            this.panelControl2.Controls.Add(this.dateEditEnd);
            this.panelControl2.Controls.Add(this.lblCtlFrom);
            this.panelControl2.Controls.Add(this.lblCtlTo);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 184);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1634, 143);
            this.panelControl2.TabIndex = 27;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 327);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1634, 525);
            this.panelControl1.TabIndex = 28;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.AttendanceReportSetViewModel);
            // 
            // AttendanceReportSetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AttendanceReportSetView";
            this.Size = new System.Drawing.Size(1634, 852);
            ((System.ComponentModel.ISupportInitialize)(this.checkByAttendanceRecords.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmBrief)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

       
        private DevExpress.XtraEditors.CheckEdit checkByAttendanceRecords;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.LabelControl lblCtlTo;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.LabelControl lblCtlFrom;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colUserSID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCardID;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private System.Windows.Forms.BindingSource bindingSourceEmBrief;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem biEdit;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraBars.BarButtonItem bbiExportToXlsx;
        private DevExpress.XtraBars.BarButtonItem bbiExportToPDF;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupActions;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupReport;
        private DevExpress.XtraBars.BarButtonItem bbiDailyReport;
        private DevExpress.XtraBars.BarButtonItem bbiMonthlyReport;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.BarButtonItem bbiMonthlySimplifiedReport;
        private DevExpress.XtraBars.BarButtonItem bbiFlexShiftReport;
    }
}
