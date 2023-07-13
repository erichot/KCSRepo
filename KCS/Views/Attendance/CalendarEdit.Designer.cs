namespace KCS.Views
{
    partial class CalendarEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarEdit));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.comboBoxEditYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLIST_YEAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalendarMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_WEEK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHOLIDAY_CK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHolidayType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_MEMO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_GRP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.repositoryItemComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.CalendarEditViewModel);
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
            this.ribbonControl.Size = new System.Drawing.Size(950, 120);
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboBoxEditYear);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 120);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(950, 61);
            this.panelControl1.TabIndex = 2;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.AnnulaCalendar);
            // 
            // panelControl2
            // 
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 516);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(950, 26);
            this.panelControl2.TabIndex = 9;
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
            this.repositoryItemComboBox});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(950, 335);
            this.gridControl.TabIndex = 15;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLIST_YEAR,
            this.colCalendarMonth,
            this.colLIST_DATE,
            this.colLIST_WEEK,
            this.colHOLIDAY_CK,
            this.colHolidayType,
            this.colLIST_MEMO,
            this.colCREATE_NAME,
            this.colCREATE_TIME,
            this.colBUILD_NAME,
            this.colBUILD_TIME,
            this.colLIST_GRP});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 1;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCalendarMonth, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colLIST_YEAR
            // 
            this.colLIST_YEAR.FieldName = "LIST_YEAR";
            this.colLIST_YEAR.Name = "colLIST_YEAR";
            this.colLIST_YEAR.OptionsColumn.AllowEdit = false;
            this.colLIST_YEAR.OptionsColumn.ReadOnly = true;
            this.colLIST_YEAR.Visible = true;
            this.colLIST_YEAR.VisibleIndex = 0;
            // 
            // colCalendarMonth
            // 
            this.colCalendarMonth.FieldName = "CalendarMonth";
            this.colCalendarMonth.Name = "colCalendarMonth";
            this.colCalendarMonth.OptionsColumn.AllowEdit = false;
            this.colCalendarMonth.OptionsColumn.ReadOnly = true;
            this.colCalendarMonth.Visible = true;
            this.colCalendarMonth.VisibleIndex = 1;
            // 
            // colLIST_DATE
            // 
            this.colLIST_DATE.FieldName = "LIST_DATE";
            this.colLIST_DATE.Name = "colLIST_DATE";
            this.colLIST_DATE.OptionsColumn.AllowEdit = false;
            this.colLIST_DATE.OptionsColumn.ReadOnly = true;
            this.colLIST_DATE.Visible = true;
            this.colLIST_DATE.VisibleIndex = 1;
            // 
            // colLIST_WEEK
            // 
            this.colLIST_WEEK.FieldName = "LIST_WEEK";
            this.colLIST_WEEK.Name = "colLIST_WEEK";
            this.colLIST_WEEK.OptionsColumn.AllowEdit = false;
            this.colLIST_WEEK.OptionsColumn.ReadOnly = true;
            this.colLIST_WEEK.Visible = true;
            this.colLIST_WEEK.VisibleIndex = 2;
            // 
            // colHOLIDAY_CK
            // 
            this.colHOLIDAY_CK.FieldName = "HOLIDAY_CK";
            this.colHOLIDAY_CK.Name = "colHOLIDAY_CK";
            this.colHOLIDAY_CK.Visible = true;
            this.colHOLIDAY_CK.VisibleIndex = 3;
            // 
            // colHolidayType
            // 
            this.colHolidayType.Caption = "HolidayType";
            this.colHolidayType.ColumnEdit = this.repositoryItemComboBox;
            this.colHolidayType.FieldName = "HolidayType";
            this.colHolidayType.Name = "colHolidayType";
            this.colHolidayType.Visible = true;
            this.colHolidayType.VisibleIndex = 4;
            // 
            // colLIST_MEMO
            // 
            this.colLIST_MEMO.FieldName = "LIST_MEMO";
            this.colLIST_MEMO.Name = "colLIST_MEMO";
            this.colLIST_MEMO.Visible = true;
            this.colLIST_MEMO.VisibleIndex = 5;
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
            // repositoryItemComboBox
            // 
            this.repositoryItemComboBox.AutoHeight = false;
            this.repositoryItemComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox.Name = "repositoryItemComboBox";
            // 
            // CalendarEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl);
            this.Name = "CalendarEdit";
            this.Size = new System.Drawing.Size(950, 542);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupActions;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditYear;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_YEAR;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_WEEK;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_MEMO;
        private DevExpress.XtraGrid.Columns.GridColumn colHOLIDAY_CK;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_GRP;
        private DevExpress.XtraGrid.Columns.GridColumn colCalendarMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colHolidayType;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox;
    }
}
