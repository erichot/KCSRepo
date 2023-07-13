namespace KCS.Views
{
    partial class EmployeeWorkCalendarMonthly
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
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCreateMonthWorkShift = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWeekdayName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colShiftCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditShiftCode = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bindingSourceShift = new System.Windows.Forms.BindingSource(this.components);
            this.colShiftName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTimeHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTimeMinute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTimeHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTimeMinute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeductBreakMinute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTimeString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTimeString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditShiftCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.biDelete,
            this.bbiCreateMonthWorkShift});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 4;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1100, 120);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // biDelete
            // 
            this.biDelete.Caption = "Delete";
            this.biDelete.Id = 2;
            this.biDelete.ImageOptions.Image = global::KCS.Properties.Resources.icon_delete_16;
            this.biDelete.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_delete_32;
            this.biDelete.Name = "biDelete";
            // 
            // bbiCreateMonthWorkShift
            // 
            this.bbiCreateMonthWorkShift.Caption = "Create employees MonthlyShift";
            this.bbiCreateMonthWorkShift.Id = 3;
            this.bbiCreateMonthWorkShift.ImageOptions.Image = global::KCS.Properties.Resources.create_monthly_shift_16;
            this.bbiCreateMonthWorkShift.ImageOptions.LargeImage = global::KCS.Properties.Resources.create_monthly_shift_32;
            this.bbiCreateMonthWorkShift.Name = "bbiCreateMonthWorkShift";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupActions});
            this.ribbonPage2.Name = "ribbonPage2";
            // 
            // ribbonPageGroupActions
            // 
            this.ribbonPageGroupActions.ItemLinks.Add(this.bbiCreateMonthWorkShift);
            this.ribbonPageGroupActions.Name = "ribbonPageGroupActions";
            this.ribbonPageGroupActions.ShowCaptionButton = false;
            this.ribbonPageGroupActions.Text = "Actions";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboBoxEditYear);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 120);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1100, 61);
            this.panelControl1.TabIndex = 1;
            // 
            // comboBoxEditYear
            // 
            this.comboBoxEditYear.Location = new System.Drawing.Point(22, 20);
            this.comboBoxEditYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxEditYear.MenuManager = this.ribbonControl;
            this.comboBoxEditYear.Name = "comboBoxEditYear";
            this.comboBoxEditYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditYear.Size = new System.Drawing.Size(186, 20);
            this.comboBoxEditYear.TabIndex = 6;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.WorkCalendar);
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 181);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(14, 13, 14, 13);
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditShiftCode});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1100, 298);
            this.gridControl.TabIndex = 6;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserSID,
            this.colDepartmentID,
            this.colDepartmentName,
            this.colUserID,
            this.colUserName,
            this.colYear,
            this.colMonth,
            this.colDay,
            this.colWeekdayName,
            this.colShiftCode,
            this.colShiftName,
            this.colStartTimeHour,
            this.colStartTimeMinute,
            this.colEndTimeHour,
            this.colEndTimeMinute,
            this.colDeductBreakMinute,
            this.colNote,
            this.colStartTimeString,
            this.colEndTimeString});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 4;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindNullPrompt = "Search Employee (Ctrl + F)";
            this.gridView.OptionsFind.ShowClearButton = false;
            this.gridView.OptionsFind.ShowFindButton = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMonth, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colUserSID
            // 
            this.colUserSID.FieldName = "UserSID";
            this.colUserSID.Name = "colUserSID";
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.OptionsColumn.AllowEdit = false;
            this.colDepartmentID.Visible = true;
            this.colDepartmentID.VisibleIndex = 0;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.OptionsColumn.AllowEdit = false;
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 0;
            this.colDepartmentName.Width = 181;
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.OptionsColumn.AllowEdit = false;
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 1;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            this.colUserName.Width = 130;
            // 
            // colYear
            // 
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            // 
            // colMonth
            // 
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.OptionsColumn.AllowEdit = false;
            this.colMonth.Visible = true;
            this.colMonth.VisibleIndex = 2;
            // 
            // colDay
            // 
            this.colDay.FieldName = "Day";
            this.colDay.Name = "colDay";
            this.colDay.OptionsColumn.AllowEdit = false;
            this.colDay.Visible = true;
            this.colDay.VisibleIndex = 2;
            this.colDay.Width = 130;
            // 
            // colWeekdayName
            // 
            this.colWeekdayName.FieldName = "WeekdayName";
            this.colWeekdayName.Name = "colWeekdayName";
            this.colWeekdayName.OptionsColumn.AllowEdit = false;
            this.colWeekdayName.Visible = true;
            this.colWeekdayName.VisibleIndex = 3;
            this.colWeekdayName.Width = 130;
            // 
            // colShiftCode
            // 
            this.colShiftCode.ColumnEdit = this.repositoryItemLookUpEditShiftCode;
            this.colShiftCode.FieldName = "ShiftCode";
            this.colShiftCode.Name = "colShiftCode";
            this.colShiftCode.Visible = true;
            this.colShiftCode.VisibleIndex = 4;
            this.colShiftCode.Width = 130;
            // 
            // repositoryItemLookUpEditShiftCode
            // 
            this.repositoryItemLookUpEditShiftCode.AutoHeight = false;
            this.repositoryItemLookUpEditShiftCode.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditShiftCode.DataSource = this.bindingSourceShift;
            this.repositoryItemLookUpEditShiftCode.DisplayMember = "ListField";
            this.repositoryItemLookUpEditShiftCode.Name = "repositoryItemLookUpEditShiftCode";
            this.repositoryItemLookUpEditShiftCode.ShowHeader = false;
            this.repositoryItemLookUpEditShiftCode.ValueMember = "ShiftCode";
            // 
            // bindingSourceShift
            // 
            this.bindingSourceShift.DataSource = typeof(KCS.Models.WorkShiftItem);
            // 
            // colShiftName
            // 
            this.colShiftName.FieldName = "ShiftName";
            this.colShiftName.Name = "colShiftName";
            // 
            // colStartTimeHour
            // 
            this.colStartTimeHour.FieldName = "StartTimeHour";
            this.colStartTimeHour.Name = "colStartTimeHour";
            // 
            // colStartTimeMinute
            // 
            this.colStartTimeMinute.FieldName = "StartTimeMinute";
            this.colStartTimeMinute.Name = "colStartTimeMinute";
            // 
            // colEndTimeHour
            // 
            this.colEndTimeHour.FieldName = "EndTimeHour";
            this.colEndTimeHour.Name = "colEndTimeHour";
            // 
            // colEndTimeMinute
            // 
            this.colEndTimeMinute.FieldName = "EndTimeMinute";
            this.colEndTimeMinute.Name = "colEndTimeMinute";
            // 
            // colDeductBreakMinute
            // 
            this.colDeductBreakMinute.FieldName = "DeductBreakMinute";
            this.colDeductBreakMinute.Name = "colDeductBreakMinute";
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 7;
            this.colNote.Width = 156;
            // 
            // colStartTimeString
            // 
            this.colStartTimeString.FieldName = "StartTimeString";
            this.colStartTimeString.Name = "colStartTimeString";
            this.colStartTimeString.OptionsColumn.AllowEdit = false;
            this.colStartTimeString.OptionsColumn.ReadOnly = true;
            this.colStartTimeString.Visible = true;
            this.colStartTimeString.VisibleIndex = 5;
            this.colStartTimeString.Width = 130;
            // 
            // colEndTimeString
            // 
            this.colEndTimeString.FieldName = "EndTimeString";
            this.colEndTimeString.Name = "colEndTimeString";
            this.colEndTimeString.OptionsColumn.AllowEdit = false;
            this.colEndTimeString.OptionsColumn.ReadOnly = true;
            this.colEndTimeString.Visible = true;
            this.colEndTimeString.VisibleIndex = 6;
            this.colEndTimeString.Width = 111;
            // 
            // layoutView
            // 
            this.layoutView.CardCaptionFormat = "{3}";
            this.layoutView.CardMinSize = new System.Drawing.Size(341, 197);
            this.layoutView.FieldCaptionFormat = "{0}";
            this.layoutView.GridControl = this.gridControl;
            this.layoutView.Name = "layoutView";
            this.layoutView.OptionsBehavior.AllowExpandCollapse = false;
            this.layoutView.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutView.OptionsBehavior.Editable = false;
            this.layoutView.OptionsBehavior.ReadOnly = true;
            this.layoutView.OptionsFind.AlwaysVisible = true;
            this.layoutView.OptionsFind.FindNullPrompt = "Search Supervisor (Ctrl + F)";
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
            // EmployeeWorkCalendarMonthly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "EmployeeWorkCalendarMonthly";
            this.Size = new System.Drawing.Size(1100, 479);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditShiftCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupActions;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditShiftCode;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditYear;
        private DevExpress.XtraBars.BarButtonItem bbiCreateMonthWorkShift;
        private DevExpress.XtraGrid.Columns.GridColumn colUserSID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colDay;
        private DevExpress.XtraGrid.Columns.GridColumn colWeekdayName;
        private DevExpress.XtraGrid.Columns.GridColumn colShiftCode;
        private DevExpress.XtraGrid.Columns.GridColumn colShiftName;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTimeHour;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTimeMinute;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTimeHour;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTimeMinute;
        private DevExpress.XtraGrid.Columns.GridColumn colDeductBreakMinute;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTimeString;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTimeString;
        private System.Windows.Forms.BindingSource bindingSourceShift;
    }
}
