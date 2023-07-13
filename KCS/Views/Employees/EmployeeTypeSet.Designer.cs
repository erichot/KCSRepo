namespace KCS.Views
{
    partial class EmployeeTypeSet
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
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnLoaded = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSave = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupEdit = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar2 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.hiItemsCount = new DevExpress.XtraBars.BarHeaderItem();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceList = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTypeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.TypeIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TypeNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.InActiveCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForTypeId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTypeName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForInActive = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEmployeeType = new DevExpress.XtraLayout.LayoutControlItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InActiveCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTypeId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTypeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmployeeType)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.EmployeeTypeSetViewModel);
            // 
            // ribbonControl
            // 
            this.ribbonControl.AllowMinimizeRibbon = false;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.ExpandCollapseItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveLayout,
            this.bbiResetLayout,
            this.bbiOnLoaded,
            this.bbiDelete,
            this.bbiClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiNew});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ribbonControl.MaxItemId = 13;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowQatLocationSelector = false;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(878, 150);
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
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "SaveAndClose";
            this.bbiSaveAndClose.Id = 2;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
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
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "SaveAndNew";
            this.bbiSaveAndNew.Id = 10;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
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
            this.ribbonPageGroupSave,
            this.ribbonPageGroupEdit,
            this.ribbonPageGroupClose});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroupSave
            // 
            this.ribbonPageGroupSave.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroupSave.ItemLinks.Add(this.bbiSaveAndClose);
            this.ribbonPageGroupSave.ItemLinks.Add(this.bbiSaveAndNew);
            this.ribbonPageGroupSave.Name = "ribbonPageGroupSave";
            this.ribbonPageGroupSave.ShowCaptionButton = false;
            this.ribbonPageGroupSave.Text = "Save";
            // 
            // ribbonPageGroupEdit
            // 
            this.ribbonPageGroupEdit.ItemLinks.Add(this.bbiReset);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroupEdit.ItemLinks.Add(this.bbiNew);
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
            this.ribbonStatusBar2.Location = new System.Drawing.Point(0, 719);
            this.ribbonStatusBar2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonStatusBar2.Name = "ribbonStatusBar2";
            this.ribbonStatusBar2.Ribbon = this.ribbonControl;
            this.ribbonStatusBar2.Size = new System.Drawing.Size(878, 35);
            // 
            // hiItemsCount
            // 
            this.hiItemsCount.Caption = "RECORDS: 0";
            this.hiItemsCount.Id = 3;
            this.hiItemsCount.Name = "hiItemsCount";
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.EmployeesType);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.gridControl);
            this.dataLayoutControl1.Controls.Add(this.TypeIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TypeNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.InActiveCheckEdit);
            this.dataLayoutControl1.DataSource = this.bindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 150);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(878, 569);
            this.dataLayoutControl1.TabIndex = 1;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSourceList;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(128, 101);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(16, 16, 16, 16);
            this.gridControl.Name = "gridControl";
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(734, 452);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // bindingSourceList
            // 
            this.bindingSourceList.DataSource = typeof(KCS.Models.EmployeesType);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTypeId,
            this.colTypeName,
            this.colInActive});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
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
            // colTypeId
            // 
            this.colTypeId.FieldName = "EmployeeTypeID";
            this.colTypeId.Name = "colTypeId";
            this.colTypeId.Visible = true;
            this.colTypeId.VisibleIndex = 0;
            // 
            // colTypeName
            // 
            this.colTypeName.FieldName = "EmployeeTypeName";
            this.colTypeName.Name = "colTypeName";
            this.colTypeName.Visible = true;
            this.colTypeName.VisibleIndex = 1;
            // 
            // colInActive
            // 
            this.colInActive.FieldName = "InActive";
            this.colInActive.Name = "colInActive";
            this.colInActive.Visible = true;
            this.colInActive.VisibleIndex = 2;
            // 
            // layoutView
            // 
            this.layoutView.CardCaptionFormat = "{3}";
            this.layoutView.CardMinSize = new System.Drawing.Size(390, 254);
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
            // TypeIdTextEdit
            // 
            this.TypeIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "EmployeeTypeID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TypeIdTextEdit.Location = new System.Drawing.Point(128, 16);
            this.TypeIdTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TypeIdTextEdit.MenuManager = this.ribbonControl;
            this.TypeIdTextEdit.Name = "TypeIdTextEdit";
            this.TypeIdTextEdit.Properties.ReadOnly = true;
            this.TypeIdTextEdit.Size = new System.Drawing.Size(734, 24);
            this.TypeIdTextEdit.StyleController = this.dataLayoutControl1;
            this.TypeIdTextEdit.TabIndex = 4;
            // 
            // TypeNameTextEdit
            // 
            this.TypeNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "EmployeeTypeName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TypeNameTextEdit.Location = new System.Drawing.Point(128, 46);
            this.TypeNameTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TypeNameTextEdit.MenuManager = this.ribbonControl;
            this.TypeNameTextEdit.Name = "TypeNameTextEdit";
            this.TypeNameTextEdit.Size = new System.Drawing.Size(734, 24);
            this.TypeNameTextEdit.StyleController = this.dataLayoutControl1;
            this.TypeNameTextEdit.TabIndex = 5;
            // 
            // InActiveCheckEdit
            // 
            this.InActiveCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "InActive", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.InActiveCheckEdit.Location = new System.Drawing.Point(128, 76);
            this.InActiveCheckEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InActiveCheckEdit.MenuManager = this.ribbonControl;
            this.InActiveCheckEdit.Name = "InActiveCheckEdit";
            this.InActiveCheckEdit.Properties.Caption = "";
            this.InActiveCheckEdit.Size = new System.Drawing.Size(734, 19);
            this.InActiveCheckEdit.StyleController = this.dataLayoutControl1;
            this.InActiveCheckEdit.TabIndex = 6;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(878, 569);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForTypeId,
            this.ItemForTypeName,
            this.ItemForInActive,
            this.ItemForEmployeeType});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(852, 543);
            // 
            // ItemForTypeId
            // 
            this.ItemForTypeId.Control = this.TypeIdTextEdit;
            this.ItemForTypeId.Location = new System.Drawing.Point(0, 0);
            this.ItemForTypeId.Name = "ItemForTypeId";
            this.ItemForTypeId.Size = new System.Drawing.Size(852, 30);
            this.ItemForTypeId.Text = "Type Id";
            this.ItemForTypeId.TextSize = new System.Drawing.Size(109, 18);
            // 
            // ItemForTypeName
            // 
            this.ItemForTypeName.Control = this.TypeNameTextEdit;
            this.ItemForTypeName.Location = new System.Drawing.Point(0, 30);
            this.ItemForTypeName.Name = "ItemForTypeName";
            this.ItemForTypeName.Size = new System.Drawing.Size(852, 30);
            this.ItemForTypeName.Text = "Type Name";
            this.ItemForTypeName.TextSize = new System.Drawing.Size(109, 18);
            // 
            // ItemForInActive
            // 
            this.ItemForInActive.Control = this.InActiveCheckEdit;
            this.ItemForInActive.Location = new System.Drawing.Point(0, 60);
            this.ItemForInActive.Name = "ItemForInActive";
            this.ItemForInActive.Size = new System.Drawing.Size(852, 25);
            this.ItemForInActive.Text = "In Active";
            this.ItemForInActive.TextSize = new System.Drawing.Size(109, 18);
            // 
            // ItemForEmployeeType
            // 
            this.ItemForEmployeeType.Control = this.gridControl;
            this.ItemForEmployeeType.CustomizationFormText = "Employees Type";
            this.ItemForEmployeeType.Location = new System.Drawing.Point(0, 85);
            this.ItemForEmployeeType.Name = "ItemForEmployeeType";
            this.ItemForEmployeeType.Size = new System.Drawing.Size(852, 458);
            this.ItemForEmployeeType.Text = "Employees Type";
            this.ItemForEmployeeType.TextSize = new System.Drawing.Size(109, 18);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Id = 11;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // EmployeeTypeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl);
            this.Controls.Add(this.ribbonStatusBar2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EmployeeTypeSet";
            this.Size = new System.Drawing.Size(878, 754);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InActiveCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTypeId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTypeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForInActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmployeeType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private DevExpress.XtraBars.BarButtonItem bbiOnLoaded;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupEdit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupClose;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit TypeIdTextEdit;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.TextEdit TypeNameTextEdit;
        private DevExpress.XtraEditors.CheckEdit InActiveCheckEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTypeId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTypeName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForInActive;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEmployeeType;
        private System.Windows.Forms.BindingSource bindingSourceList;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeId;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colInActive;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar2;
        private DevExpress.XtraBars.BarHeaderItem hiItemsCount;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
    }
}
