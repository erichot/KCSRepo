namespace KCS.Views
{
    partial class ShiftTableEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShiftTableEdit));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWORK_YEAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTURNWORK_GRP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkMonthName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWORK_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWORK_WEEK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLASS_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLASS_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bindingSourceWorkShift = new System.Windows.Forms.BindingSource(this.components);
            this.colCREATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_GRP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWORK_TIME_START = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWORK_TIME_END = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidayType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblCtlYear = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditYear = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWorkShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
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
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.ShiftTableEditViewModel);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiClose});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonControl.MaxItemId = 6;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1644, 184);
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
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.WorkList);
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 280);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox,
            this.repositoryItemLookUpEdit1,
            this.repositoryItemComboBox1});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1644, 842);
            this.gridControl.TabIndex = 19;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWORK_YEAR,
            this.colTURNWORK_GRP,
            this.colWorkMonthName,
            this.colWorkMonth,
            this.colWORK_DATE,
            this.colWORK_WEEK,
            this.colCLASS_DESC,
            this.colCLASS_CODE,
            this.colCREATE_NAME,
            this.colCREATE_TIME,
            this.colBUILD_NAME,
            this.colBUILD_TIME,
            this.colLIST_GRP,
            this.colWORK_TIME_START,
            this.colWORK_TIME_END,
            this.colHolidayType});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 2;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView.OptionsFind.FindNullPrompt = "Search WorkShift (Ctrl + F)";
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTURNWORK_GRP, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWorkMonth, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWorkMonthName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colWORK_DATE, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colWORK_YEAR
            // 
            this.colWORK_YEAR.FieldName = "WORK_YEAR";
            this.colWORK_YEAR.Name = "colWORK_YEAR";
            this.colWORK_YEAR.OptionsColumn.AllowEdit = false;
            this.colWORK_YEAR.OptionsColumn.ReadOnly = true;
            this.colWORK_YEAR.Visible = true;
            this.colWORK_YEAR.VisibleIndex = 0;
            // 
            // colTURNWORK_GRP
            // 
            this.colTURNWORK_GRP.FieldName = "TURNWORK_GRP";
            this.colTURNWORK_GRP.Name = "colTURNWORK_GRP";
            this.colTURNWORK_GRP.OptionsColumn.AllowEdit = false;
            this.colTURNWORK_GRP.OptionsColumn.ReadOnly = true;
            this.colTURNWORK_GRP.Visible = true;
            this.colTURNWORK_GRP.VisibleIndex = 1;
            // 
            // colWorkMonthName
            // 
            this.colWorkMonthName.FieldName = "WorkMonthName";
            this.colWorkMonthName.Name = "colWorkMonthName";
            this.colWorkMonthName.OptionsColumn.ReadOnly = true;
            // 
            // colWorkMonth
            // 
            this.colWorkMonth.FieldName = "WorkMonth";
            this.colWorkMonth.Name = "colWorkMonth";
            this.colWorkMonth.OptionsColumn.AllowEdit = false;
            this.colWorkMonth.OptionsColumn.ReadOnly = true;
            this.colWorkMonth.Visible = true;
            this.colWorkMonth.VisibleIndex = 9;
            // 
            // colWORK_DATE
            // 
            this.colWORK_DATE.FieldName = "WORK_DATE_Dis";
            this.colWORK_DATE.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.DateMonth;
            this.colWORK_DATE.Name = "colWORK_DATE";
            this.colWORK_DATE.OptionsColumn.AllowEdit = false;
            this.colWORK_DATE.OptionsColumn.ReadOnly = true;
            this.colWORK_DATE.Visible = true;
            this.colWORK_DATE.VisibleIndex = 1;
            // 
            // colWORK_WEEK
            // 
            this.colWORK_WEEK.FieldName = "WORK_WEEK";
            this.colWORK_WEEK.Name = "colWORK_WEEK";
            this.colWORK_WEEK.OptionsColumn.AllowEdit = false;
            this.colWORK_WEEK.OptionsColumn.ReadOnly = true;
            this.colWORK_WEEK.Visible = true;
            this.colWORK_WEEK.VisibleIndex = 2;
            // 
            // colCLASS_DESC
            // 
            this.colCLASS_DESC.FieldName = "CLASS_DESC";
            this.colCLASS_DESC.Name = "colCLASS_DESC";
            this.colCLASS_DESC.OptionsColumn.AllowEdit = false;
            this.colCLASS_DESC.OptionsColumn.ReadOnly = true;
            this.colCLASS_DESC.Visible = true;
            this.colCLASS_DESC.VisibleIndex = 4;
            // 
            // colCLASS_CODE
            // 
            this.colCLASS_CODE.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colCLASS_CODE.FieldName = "CLASS_CODE";
            this.colCLASS_CODE.Name = "colCLASS_CODE";
            this.colCLASS_CODE.Visible = true;
            this.colCLASS_CODE.VisibleIndex = 3;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
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
            this.colWORK_TIME_START.FieldName = "WORK_TIME_START";
            this.colWORK_TIME_START.Name = "colWORK_TIME_START";
            this.colWORK_TIME_START.OptionsColumn.AllowEdit = false;
            this.colWORK_TIME_START.OptionsColumn.ReadOnly = true;
            this.colWORK_TIME_START.Visible = true;
            this.colWORK_TIME_START.VisibleIndex = 5;
            // 
            // colWORK_TIME_END
            // 
            this.colWORK_TIME_END.FieldName = "WORK_TIME_END";
            this.colWORK_TIME_END.Name = "colWORK_TIME_END";
            this.colWORK_TIME_END.OptionsColumn.AllowEdit = false;
            this.colWORK_TIME_END.OptionsColumn.ReadOnly = true;
            this.colWORK_TIME_END.Visible = true;
            this.colWORK_TIME_END.VisibleIndex = 6;
            // 
            // colHolidayType
            // 
            this.colHolidayType.ColumnEdit = this.repositoryItemComboBox1;
            this.colHolidayType.FieldName = "HolidayType";
            this.colHolidayType.Name = "colHolidayType";
            this.colHolidayType.Visible = true;
            this.colHolidayType.VisibleIndex = 7;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemComboBox
            // 
            this.repositoryItemComboBox.AutoHeight = false;
            this.repositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox.Name = "repositoryItemComboBox";
            // 
            // layoutView
            // 
            this.layoutView.CardCaptionFormat = "{3}";
            this.layoutView.CardMinSize = new System.Drawing.Size(487, 310);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblCtlYear);
            this.panelControl1.Controls.Add(this.comboBoxEditYear);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 184);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1644, 96);
            this.panelControl1.TabIndex = 18;
            // 
            // lblCtlYear
            // 
            this.lblCtlYear.Location = new System.Drawing.Point(16, 35);
            this.lblCtlYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlYear.Name = "lblCtlYear";
            this.lblCtlYear.Size = new System.Drawing.Size(34, 22);
            this.lblCtlYear.TabIndex = 7;
            this.lblCtlYear.Text = "Year";
            // 
            // comboBoxEditYear
            // 
            this.comboBoxEditYear.Location = new System.Drawing.Point(87, 30);
            this.comboBoxEditYear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBoxEditYear.MenuManager = this.ribbonControl;
            this.comboBoxEditYear.Name = "comboBoxEditYear";
            this.comboBoxEditYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditYear.Size = new System.Drawing.Size(266, 28);
            this.comboBoxEditYear.TabIndex = 6;
            // 
            // ShiftTableEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ShiftTableEdit";
            this.Size = new System.Drawing.Size(1644, 1122);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceWorkShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
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
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditYear;
        private DevExpress.XtraEditors.LabelControl lblCtlYear;
        private DevExpress.XtraGrid.Columns.GridColumn colWORK_YEAR;
        private DevExpress.XtraGrid.Columns.GridColumn colTURNWORK_GRP;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkMonthName;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colWORK_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colWORK_WEEK;
        private DevExpress.XtraGrid.Columns.GridColumn colCLASS_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colCLASS_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_GRP;
        private DevExpress.XtraGrid.Columns.GridColumn colWORK_TIME_START;
        private DevExpress.XtraGrid.Columns.GridColumn colWORK_TIME_END;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidayType;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource bindingSourceWorkShift;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}
