namespace KCS.Views
{
    partial class EmployeeJobCodecs
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTranType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colJobCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colListField = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
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
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.EmployeeJobCodecsViewModel);
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            gridLevelNode2.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControl.Location = new System.Drawing.Point(0, 184);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1009, 394);
            this.gridControl.TabIndex = 11;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.EmployeeJobCode);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTranType,
            this.colJobCode,
            this.colJobName,
            this.colRemark,
            this.colListField});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplaceHideCurrentRow;
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
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colTranType
            // 
            this.colTranType.ColumnEdit = this.repositoryItemComboBox1;
            this.colTranType.FieldName = "TranType";
            this.colTranType.Name = "colTranType";
            this.colTranType.Visible = true;
            this.colTranType.VisibleIndex = 0;
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
            // colJobCode
            // 
            this.colJobCode.FieldName = "JobCode";
            this.colJobCode.Name = "colJobCode";
            // 
            // colJobName
            // 
            this.colJobName.FieldName = "JobName";
            this.colJobName.Name = "colJobName";
            this.colJobName.Visible = true;
            this.colJobName.VisibleIndex = 1;
            // 
            // colRemark
            // 
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 2;
            // 
            // colListField
            // 
            this.colListField.FieldName = "ListField";
            this.colListField.Name = "colListField";
            this.colListField.Visible = true;
            this.colListField.VisibleIndex = 3;
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
            this.ribbonControl.Size = new System.Drawing.Size(1009, 184);
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
            // EmployeeJobCodecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EmployeeJobCodecs";
            this.Size = new System.Drawing.Size(1009, 578);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
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
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTranType;
        private DevExpress.XtraGrid.Columns.GridColumn colJobCode;
        private DevExpress.XtraGrid.Columns.GridColumn colJobName;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colListField;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    }
}
