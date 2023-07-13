namespace KCS.Views
{
    partial class TaHolidaySetting
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
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnLoaded = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupEdit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar2 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.hiItemsCount = new DevExpress.XtraBars.BarHeaderItem();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHOLIDAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colHOLIDAY_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.TaHolidaySettingViewModel);
            // 
            // ribbonControl
            // 
            this.ribbonControl.AllowMinimizeRibbon = false;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.ExpandCollapseItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveLayout,
            this.bbiResetLayout,
            this.bbiOnLoaded,
            this.bbiDelete,
            this.bbiClose,
            this.bbiReset,
            this.bbiNew});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ribbonControl.MaxItemId = 13;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowQatLocationSelector = false;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1379, 184);
            this.ribbonControl.StatusBar = this.ribbonStatusBar2;
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            // 
            // bbiSaveLayout
            // 
            this.bbiSaveLayout.Caption = "SaveLayout";
            this.bbiSaveLayout.Id = 5;
            this.bbiSaveLayout.ImageOptions.ImageUri.Uri = "SaveLayout";
            this.bbiSaveLayout.Name = "bbiSaveLayout";
            // 
            // bbiResetLayout
            // 
            this.bbiResetLayout.Caption = "ResetLayout";
            this.bbiResetLayout.Id = 6;
            this.bbiResetLayout.ImageOptions.ImageUri.Uri = "ResetLayout";
            this.bbiResetLayout.Name = "bbiResetLayout";
            // 
            // bbiOnLoaded
            // 
            this.bbiOnLoaded.Caption = "OnLoaded";
            this.bbiOnLoaded.Id = 7;
            this.bbiOnLoaded.ImageOptions.ImageUri.Uri = "OnLoaded";
            this.bbiOnLoaded.Name = "bbiOnLoaded";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 8;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 9;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "Reset Changes";
            this.bbiReset.Id = 11;
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "New";
            this.bbiNew.Id = 12;
            this.bbiNew.ImageOptions.ImageUri.Uri = "New";
            this.bbiNew.Name = "bbiNew";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupEdit,
            this.ribbonPageGroupClose});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroupEdit
            // 
            this.ribbonPageGroupEdit.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroupEdit.Name = "ribbonPageGroupEdit";
            this.ribbonPageGroupEdit.ShowCaptionButton = false;
            this.ribbonPageGroupEdit.Text = "Edit";
            // 
            // ribbonPageGroupClose
            // 
            this.ribbonPageGroupClose.AllowTextClipping = false;
            this.ribbonPageGroupClose.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroupClose.Name = "ribbonPageGroupClose";
            this.ribbonPageGroupClose.ShowCaptionButton = false;
            this.ribbonPageGroupClose.Text = "Close";
            // 
            // ribbonStatusBar2
            // 
            this.ribbonStatusBar2.ItemLinks.Add(this.hiItemsCount);
            this.ribbonStatusBar2.Location = new System.Drawing.Point(0, 847);
            this.ribbonStatusBar2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbonStatusBar2.Name = "ribbonStatusBar2";
            this.ribbonStatusBar2.Ribbon = this.ribbonControl;
            this.ribbonStatusBar2.Size = new System.Drawing.Size(1379, 42);
            // 
            // hiItemsCount
            // 
            this.hiItemsCount.Caption = "barHeaderItem1";
            this.hiItemsCount.Id = 10;
            this.hiItemsCount.Name = "hiItemsCount";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 189);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemDateEdit1});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1379, 651);
            this.gridControl.TabIndex = 13;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.TaHolidays);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHOLIDAY,
            this.colHOLIDAY_DESC,
            this.colCREATE_NAME,
            this.colCREATE_TIME,
            this.colBUILD_NAME,
            this.colBUILD_TIME});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsFind.FindNullPrompt = "";
            this.gridView.OptionsFind.ShowClearButton = false;
            this.gridView.OptionsFind.ShowFindButton = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colHOLIDAY
            // 
            this.colHOLIDAY.ColumnEdit = this.repositoryItemDateEdit1;
            this.colHOLIDAY.FieldName = "HOLIDAY_DT";
            this.colHOLIDAY.Name = "colHOLIDAY";
            this.colHOLIDAY.Visible = true;
            this.colHOLIDAY.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.DisplayFormat.FormatString = "m";
            this.repositoryItemDateEdit1.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.CalendarTimeProperties.Mask.EditMask = "m";
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "m";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "m";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "m";
            this.repositoryItemDateEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.ReadOnly = true;
            // 
            // colHOLIDAY_DESC
            // 
            this.colHOLIDAY_DESC.FieldName = "HOLIDAY_DESC";
            this.colHOLIDAY_DESC.Name = "colHOLIDAY_DESC";
            this.colHOLIDAY_DESC.Visible = true;
            this.colHOLIDAY_DESC.VisibleIndex = 1;
            // 
            // colCREATE_NAME
            // 
            this.colCREATE_NAME.FieldName = "CREATE_NAME";
            this.colCREATE_NAME.Name = "colCREATE_NAME";
            this.colCREATE_NAME.OptionsColumn.AllowEdit = false;
            this.colCREATE_NAME.OptionsColumn.ReadOnly = true;
            this.colCREATE_NAME.Visible = true;
            this.colCREATE_NAME.VisibleIndex = 2;
            // 
            // colCREATE_TIME
            // 
            this.colCREATE_TIME.FieldName = "CREATE_TIME";
            this.colCREATE_TIME.Name = "colCREATE_TIME";
            this.colCREATE_TIME.OptionsColumn.AllowEdit = false;
            this.colCREATE_TIME.OptionsColumn.ReadOnly = true;
            this.colCREATE_TIME.Visible = true;
            this.colCREATE_TIME.VisibleIndex = 3;
            // 
            // colBUILD_NAME
            // 
            this.colBUILD_NAME.FieldName = "BUILD_NAME";
            this.colBUILD_NAME.Name = "colBUILD_NAME";
            this.colBUILD_NAME.OptionsColumn.AllowEdit = false;
            this.colBUILD_NAME.OptionsColumn.ReadOnly = true;
            this.colBUILD_NAME.Visible = true;
            this.colBUILD_NAME.VisibleIndex = 4;
            // 
            // colBUILD_TIME
            // 
            this.colBUILD_TIME.FieldName = "BUILD_TIME";
            this.colBUILD_TIME.Name = "colBUILD_TIME";
            this.colBUILD_TIME.OptionsColumn.AllowEdit = false;
            this.colBUILD_TIME.OptionsColumn.ReadOnly = true;
            this.colBUILD_TIME.Visible = true;
            this.colBUILD_TIME.VisibleIndex = 5;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "161",
            "162"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
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
            // TaHolidaySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar2);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TaHolidaySetting";
            this.Size = new System.Drawing.Size(1379, 889);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private DevExpress.XtraBars.BarButtonItem bbiOnLoaded;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupClose;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colHOLIDAY;
        private DevExpress.XtraGrid.Columns.GridColumn colHOLIDAY_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_TIME;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar2;
        private DevExpress.XtraBars.BarHeaderItem hiItemsCount;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}
