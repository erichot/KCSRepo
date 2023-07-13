namespace KCS.Views
{
    partial class EditPersonalShiftTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPersonalShiftTable));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCheckYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMP_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerShiftTableMonthName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerShiftTableMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHK_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerShiftTableWeekName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLASS_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bindingSourceWorkShift = new System.Windows.Forms.BindingSource(this.components);
            this.colCLASS_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidayType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colCLOCK_CK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLEAVE_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_GRP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWORK_TIME_START = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWORK_TIME_END = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWORK_TIME_LATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWORK_TIME_OVERTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTURN_OVERTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRELAX_TIME1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRELAX_TIME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRELAX_TIME3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRELAX_TIME4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerShiftTableWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::KCS.Views.Attendance.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWorkShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditYear.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.EditPersonalShiftTableViewModel);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiClose});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 6;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1141, 120);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 4;
            this.bbiClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
            this.bbiClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.LargeImage")));
            this.bbiClose.Name = "bbiClose";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupActions});
            this.ribbonPage2.Name = "ribbonPage2";
            // 
            // ribbonPageGroupActions
            // 
            this.ribbonPageGroupActions.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroupActions.Name = "ribbonPageGroupActions";
            this.ribbonPageGroupActions.ShowCaptionButton = false;
            this.ribbonPageGroupActions.Text = "Actions";
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
            this.repositoryItemComboBox,
            this.repositoryItemLookUpEdit1});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1141, 301);
            this.gridControl.TabIndex = 17;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.PerShiftTable);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheckYear,
            this.colDepartmentID,
            this.colDepartmentName,
            this.colDepartmentNote,
            this.colEMP_CODE,
            this.colUserName,
            this.colEmployeeNote,
            this.colPerShiftTableMonthName,
            this.colPerShiftTableMonth,
            this.colCardID,
            this.colCHK_DATE,
            this.colPerShiftTableWeekName,
            this.colCLASS_CODE,
            this.colCLASS_DESC,
            this.colHolidayType,
            this.colCLOCK_CK,
            this.colLEAVE_CODE,
            this.colCHK,
            this.colCREATE_NAME,
            this.colCREATE_TIME,
            this.colBUILD_NAME,
            this.colBUILD_TIME,
            this.colLIST_GRP,
            this.colWORK_TIME_START,
            this.colWORK_TIME_END,
            this.colWORK_TIME_LATE,
            this.colWORK_TIME_OVERTIME,
            this.colTURN_OVERTIME,
            this.colRELAX_TIME1,
            this.colRELAX_TIME2,
            this.colRELAX_TIME3,
            this.colRELAX_TIME4,
            this.colPerShiftTableWeek});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 3;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentNote, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colEmployeeNote, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPerShiftTableMonth, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPerShiftTableMonthName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colEMP_CODE, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colCheckYear
            // 
            this.colCheckYear.FieldName = "CheckYear";
            this.colCheckYear.Name = "colCheckYear";
            this.colCheckYear.Width = 104;
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.Width = 83;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Width = 83;
            // 
            // colDepartmentNote
            // 
            this.colDepartmentNote.AppearanceCell.Options.UseTextOptions = true;
            this.colDepartmentNote.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepartmentNote.FieldName = "DepartmentNote";
            this.colDepartmentNote.Name = "colDepartmentNote";
            this.colDepartmentNote.OptionsColumn.AllowEdit = false;
            this.colDepartmentNote.OptionsColumn.ReadOnly = true;
            this.colDepartmentNote.Visible = true;
            this.colDepartmentNote.VisibleIndex = 3;
            this.colDepartmentNote.Width = 141;
            // 
            // colEMP_CODE
            // 
            this.colEMP_CODE.FieldName = "EMP_CODE";
            this.colEMP_CODE.Name = "colEMP_CODE";
            this.colEMP_CODE.Width = 83;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Width = 83;
            // 
            // colEmployeeNote
            // 
            this.colEmployeeNote.AppearanceCell.Options.UseTextOptions = true;
            this.colEmployeeNote.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmployeeNote.FieldName = "EmployeeNote";
            this.colEmployeeNote.Name = "colEmployeeNote";
            this.colEmployeeNote.OptionsColumn.AllowEdit = false;
            this.colEmployeeNote.OptionsColumn.ReadOnly = true;
            this.colEmployeeNote.Visible = true;
            this.colEmployeeNote.VisibleIndex = 6;
            this.colEmployeeNote.Width = 61;
            // 
            // colPerShiftTableMonthName
            // 
            this.colPerShiftTableMonthName.FieldName = "PerShiftTableMonthName";
            this.colPerShiftTableMonthName.Name = "colPerShiftTableMonthName";
            this.colPerShiftTableMonthName.OptionsColumn.ReadOnly = true;
            this.colPerShiftTableMonthName.Width = 83;
            // 
            // colPerShiftTableMonth
            // 
            this.colPerShiftTableMonth.AppearanceCell.Options.UseTextOptions = true;
            this.colPerShiftTableMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPerShiftTableMonth.FieldName = "PerShiftTableMonth";
            this.colPerShiftTableMonth.Name = "colPerShiftTableMonth";
            this.colPerShiftTableMonth.OptionsColumn.AllowEdit = false;
            this.colPerShiftTableMonth.OptionsColumn.ReadOnly = true;
            this.colPerShiftTableMonth.Visible = true;
            this.colPerShiftTableMonth.VisibleIndex = 8;
            this.colPerShiftTableMonth.Width = 77;
            // 
            // colCardID
            // 
            this.colCardID.FieldName = "CardID";
            this.colCardID.Name = "colCardID";
            this.colCardID.Width = 83;
            // 
            // colCHK_DATE
            // 
            this.colCHK_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.colCHK_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCHK_DATE.FieldName = "CHK_DATE";
            this.colCHK_DATE.Name = "colCHK_DATE";
            this.colCHK_DATE.OptionsColumn.AllowEdit = false;
            this.colCHK_DATE.OptionsColumn.ReadOnly = true;
            this.colCHK_DATE.Visible = true;
            this.colCHK_DATE.VisibleIndex = 0;
            this.colCHK_DATE.Width = 83;
            // 
            // colPerShiftTableWeekName
            // 
            this.colPerShiftTableWeekName.AppearanceCell.Options.UseTextOptions = true;
            this.colPerShiftTableWeekName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPerShiftTableWeekName.FieldName = "PerShiftTableWeekName";
            this.colPerShiftTableWeekName.Name = "colPerShiftTableWeekName";
            this.colPerShiftTableWeekName.OptionsColumn.AllowEdit = false;
            this.colPerShiftTableWeekName.OptionsColumn.ReadOnly = true;
            this.colPerShiftTableWeekName.Visible = true;
            this.colPerShiftTableWeekName.VisibleIndex = 1;
            this.colPerShiftTableWeekName.Width = 52;
            // 
            // colCLASS_CODE
            // 
            this.colCLASS_CODE.AppearanceCell.Options.UseTextOptions = true;
            this.colCLASS_CODE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCLASS_CODE.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colCLASS_CODE.FieldName = "CLASS_CODE";
            this.colCLASS_CODE.Name = "colCLASS_CODE";
            this.colCLASS_CODE.Visible = true;
            this.colCLASS_CODE.VisibleIndex = 2;
            this.colCLASS_CODE.Width = 52;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DataSource = this.bindingSourceWorkShift;
            this.repositoryItemLookUpEdit1.DisplayMember = "CLASS_CODE";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            this.repositoryItemLookUpEdit1.ValueMember = "CLASS_CODE";
            // 
            // bindingSourceWorkShift
            // 
            this.bindingSourceWorkShift.DataSource = typeof(KCS.Models.WorkShiftItem);
            // 
            // colCLASS_DESC
            // 
            this.colCLASS_DESC.AppearanceCell.Options.UseTextOptions = true;
            this.colCLASS_DESC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCLASS_DESC.FieldName = "CLASS_DESC";
            this.colCLASS_DESC.Name = "colCLASS_DESC";
            this.colCLASS_DESC.OptionsColumn.AllowEdit = false;
            this.colCLASS_DESC.OptionsColumn.ReadOnly = true;
            this.colCLASS_DESC.Visible = true;
            this.colCLASS_DESC.VisibleIndex = 3;
            this.colCLASS_DESC.Width = 52;
            // 
            // colHolidayType
            // 
            this.colHolidayType.AppearanceCell.Options.UseTextOptions = true;
            this.colHolidayType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHolidayType.ColumnEdit = this.repositoryItemComboBox;
            this.colHolidayType.FieldName = "HolidayType";
            this.colHolidayType.Name = "colHolidayType";
            this.colHolidayType.Visible = true;
            this.colHolidayType.VisibleIndex = 4;
            this.colHolidayType.Width = 52;
            // 
            // repositoryItemComboBox
            // 
            this.repositoryItemComboBox.AutoHeight = false;
            this.repositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox.Name = "repositoryItemComboBox";
            // 
            // colCLOCK_CK
            // 
            this.colCLOCK_CK.AppearanceCell.Options.UseTextOptions = true;
            this.colCLOCK_CK.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCLOCK_CK.FieldName = "CLOCK_CK";
            this.colCLOCK_CK.Name = "colCLOCK_CK";
            this.colCLOCK_CK.Visible = true;
            this.colCLOCK_CK.VisibleIndex = 5;
            this.colCLOCK_CK.Width = 52;
            // 
            // colLEAVE_CODE
            // 
            this.colLEAVE_CODE.FieldName = "LEAVE_CODE";
            this.colLEAVE_CODE.Name = "colLEAVE_CODE";
            // 
            // colCHK
            // 
            this.colCHK.FieldName = "CHK";
            this.colCHK.Name = "colCHK";
            // 
            // colCREATE_NAME
            // 
            this.colCREATE_NAME.FieldName = "CREATE_NAME";
            this.colCREATE_NAME.Name = "colCREATE_NAME";
            // 
            // colCREATE_TIME
            // 
            this.colCREATE_TIME.FieldName = "CREATE_TIME";
            this.colCREATE_TIME.Name = "colCREATE_TIME";
            // 
            // colBUILD_NAME
            // 
            this.colBUILD_NAME.FieldName = "BUILD_NAME";
            this.colBUILD_NAME.Name = "colBUILD_NAME";
            // 
            // colBUILD_TIME
            // 
            this.colBUILD_TIME.FieldName = "BUILD_TIME";
            this.colBUILD_TIME.Name = "colBUILD_TIME";
            // 
            // colLIST_GRP
            // 
            this.colLIST_GRP.FieldName = "LIST_GRP";
            this.colLIST_GRP.Name = "colLIST_GRP";
            // 
            // colWORK_TIME_START
            // 
            this.colWORK_TIME_START.AppearanceCell.Options.UseTextOptions = true;
            this.colWORK_TIME_START.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWORK_TIME_START.FieldName = "WORK_TIME_START";
            this.colWORK_TIME_START.Name = "colWORK_TIME_START";
            this.colWORK_TIME_START.OptionsColumn.AllowEdit = false;
            this.colWORK_TIME_START.OptionsColumn.ReadOnly = true;
            this.colWORK_TIME_START.Visible = true;
            this.colWORK_TIME_START.VisibleIndex = 6;
            this.colWORK_TIME_START.Width = 52;
            // 
            // colWORK_TIME_END
            // 
            this.colWORK_TIME_END.AppearanceCell.Options.UseTextOptions = true;
            this.colWORK_TIME_END.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWORK_TIME_END.FieldName = "WORK_TIME_END";
            this.colWORK_TIME_END.Name = "colWORK_TIME_END";
            this.colWORK_TIME_END.OptionsColumn.AllowEdit = false;
            this.colWORK_TIME_END.OptionsColumn.ReadOnly = true;
            this.colWORK_TIME_END.Visible = true;
            this.colWORK_TIME_END.VisibleIndex = 7;
            this.colWORK_TIME_END.Width = 52;
            // 
            // colWORK_TIME_LATE
            // 
            this.colWORK_TIME_LATE.AppearanceCell.Options.UseTextOptions = true;
            this.colWORK_TIME_LATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWORK_TIME_LATE.FieldName = "WORK_TIME_LATE";
            this.colWORK_TIME_LATE.Name = "colWORK_TIME_LATE";
            this.colWORK_TIME_LATE.OptionsColumn.AllowEdit = false;
            this.colWORK_TIME_LATE.OptionsColumn.ReadOnly = true;
            this.colWORK_TIME_LATE.Visible = true;
            this.colWORK_TIME_LATE.VisibleIndex = 8;
            this.colWORK_TIME_LATE.Width = 52;
            // 
            // colWORK_TIME_OVERTIME
            // 
            this.colWORK_TIME_OVERTIME.AppearanceCell.Options.UseTextOptions = true;
            this.colWORK_TIME_OVERTIME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWORK_TIME_OVERTIME.FieldName = "WORK_TIME_OVERTIME";
            this.colWORK_TIME_OVERTIME.Name = "colWORK_TIME_OVERTIME";
            this.colWORK_TIME_OVERTIME.OptionsColumn.AllowEdit = false;
            this.colWORK_TIME_OVERTIME.OptionsColumn.ReadOnly = true;
            this.colWORK_TIME_OVERTIME.Visible = true;
            this.colWORK_TIME_OVERTIME.VisibleIndex = 9;
            this.colWORK_TIME_OVERTIME.Width = 52;
            // 
            // colTURN_OVERTIME
            // 
            this.colTURN_OVERTIME.AppearanceCell.Options.UseTextOptions = true;
            this.colTURN_OVERTIME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTURN_OVERTIME.FieldName = "TURN_OVERTIME";
            this.colTURN_OVERTIME.Name = "colTURN_OVERTIME";
            this.colTURN_OVERTIME.OptionsColumn.AllowEdit = false;
            this.colTURN_OVERTIME.OptionsColumn.ReadOnly = true;
            this.colTURN_OVERTIME.Visible = true;
            this.colTURN_OVERTIME.VisibleIndex = 10;
            this.colTURN_OVERTIME.Width = 52;
            // 
            // colRELAX_TIME1
            // 
            this.colRELAX_TIME1.AppearanceCell.Options.UseTextOptions = true;
            this.colRELAX_TIME1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRELAX_TIME1.FieldName = "RELAX_TIME1";
            this.colRELAX_TIME1.Name = "colRELAX_TIME1";
            this.colRELAX_TIME1.OptionsColumn.AllowEdit = false;
            this.colRELAX_TIME1.OptionsColumn.ReadOnly = true;
            this.colRELAX_TIME1.Visible = true;
            this.colRELAX_TIME1.VisibleIndex = 11;
            this.colRELAX_TIME1.Width = 52;
            // 
            // colRELAX_TIME2
            // 
            this.colRELAX_TIME2.AppearanceCell.Options.UseTextOptions = true;
            this.colRELAX_TIME2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRELAX_TIME2.FieldName = "RELAX_TIME2";
            this.colRELAX_TIME2.Name = "colRELAX_TIME2";
            this.colRELAX_TIME2.OptionsColumn.AllowEdit = false;
            this.colRELAX_TIME2.OptionsColumn.ReadOnly = true;
            this.colRELAX_TIME2.Visible = true;
            this.colRELAX_TIME2.VisibleIndex = 12;
            this.colRELAX_TIME2.Width = 52;
            // 
            // colRELAX_TIME3
            // 
            this.colRELAX_TIME3.AppearanceCell.Options.UseTextOptions = true;
            this.colRELAX_TIME3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRELAX_TIME3.FieldName = "RELAX_TIME3";
            this.colRELAX_TIME3.Name = "colRELAX_TIME3";
            this.colRELAX_TIME3.OptionsColumn.AllowEdit = false;
            this.colRELAX_TIME3.OptionsColumn.ReadOnly = true;
            this.colRELAX_TIME3.Visible = true;
            this.colRELAX_TIME3.VisibleIndex = 13;
            this.colRELAX_TIME3.Width = 52;
            // 
            // colRELAX_TIME4
            // 
            this.colRELAX_TIME4.AppearanceCell.Options.UseTextOptions = true;
            this.colRELAX_TIME4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRELAX_TIME4.FieldName = "RELAX_TIME4";
            this.colRELAX_TIME4.Name = "colRELAX_TIME4";
            this.colRELAX_TIME4.OptionsColumn.AllowEdit = false;
            this.colRELAX_TIME4.OptionsColumn.ReadOnly = true;
            this.colRELAX_TIME4.Visible = true;
            this.colRELAX_TIME4.VisibleIndex = 14;
            this.colRELAX_TIME4.Width = 52;
            // 
            // colPerShiftTableWeek
            // 
            this.colPerShiftTableWeek.FieldName = "PerShiftTableWeek";
            this.colPerShiftTableWeek.Name = "colPerShiftTableWeek";
            this.colPerShiftTableWeek.OptionsColumn.ReadOnly = true;
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
            this.layoutView.OptionsFind.FindNullPrompt = "Search WorkShift (Ctrl + F)";
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboBoxEditYear);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 120);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1141, 61);
            this.panelControl1.TabIndex = 16;
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
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // EditPersonalShiftTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 482);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "EditPersonalShiftTable";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWorkShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditYear.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupActions;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditYear;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colCheckYear;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentNote;
        private DevExpress.XtraGrid.Columns.GridColumn colEMP_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNote;
        private DevExpress.XtraGrid.Columns.GridColumn colPerShiftTableMonthName;
        private DevExpress.XtraGrid.Columns.GridColumn colPerShiftTableMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colCardID;
        private DevExpress.XtraGrid.Columns.GridColumn colCHK_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colPerShiftTableWeekName;
        private DevExpress.XtraGrid.Columns.GridColumn colCLASS_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colCLASS_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidayType;
        private DevExpress.XtraGrid.Columns.GridColumn colCLOCK_CK;
        private DevExpress.XtraGrid.Columns.GridColumn colLEAVE_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colCHK;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_GRP;
        private DevExpress.XtraGrid.Columns.GridColumn colWORK_TIME_START;
        private DevExpress.XtraGrid.Columns.GridColumn colWORK_TIME_END;
        private DevExpress.XtraGrid.Columns.GridColumn colWORK_TIME_LATE;
        private DevExpress.XtraGrid.Columns.GridColumn colWORK_TIME_OVERTIME;
        private DevExpress.XtraGrid.Columns.GridColumn colTURN_OVERTIME;
        private DevExpress.XtraGrid.Columns.GridColumn colRELAX_TIME1;
        private DevExpress.XtraGrid.Columns.GridColumn colRELAX_TIME2;
        private DevExpress.XtraGrid.Columns.GridColumn colRELAX_TIME3;
        private DevExpress.XtraGrid.Columns.GridColumn colRELAX_TIME4;
        private DevExpress.XtraGrid.Columns.GridColumn colPerShiftTableWeek;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource bindingSourceWorkShift;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}
