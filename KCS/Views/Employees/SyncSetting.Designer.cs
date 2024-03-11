namespace KCS.Views
{
    partial class SyncSetting
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
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSave = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroupClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnLoaded = new DevExpress.XtraBars.BarButtonItem();
            this.hiItemsCount = new DevExpress.XtraBars.BarHeaderItem();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSlaveSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIP_Internal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSyncOrNot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserIsReplicatiedOrNot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinger1IsReplicatiedOrNot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinger2IsReplicatiedOrNot = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.SyncSettingViewModel);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.DeviceInfo);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupSave,
            this.ribbonPageGroupClose});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroupSave
            // 
            this.ribbonPageGroupSave.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroupSave.Name = "ribbonPageGroupSave";
            this.ribbonPageGroupSave.ShowCaptionButton = false;
            this.ribbonPageGroupSave.Text = "Save";
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            // 
            // ribbonPageGroupClose
            // 
            this.ribbonPageGroupClose.AllowTextClipping = false;
            this.ribbonPageGroupClose.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroupClose.Name = "ribbonPageGroupClose";
            this.ribbonPageGroupClose.ShowCaptionButton = false;
            this.ribbonPageGroupClose.Text = "Close";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 9;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
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
            // hiItemsCount
            // 
            this.hiItemsCount.Caption = "RECORDS: 0";
            this.hiItemsCount.Id = 11;
            this.hiItemsCount.Name = "hiItemsCount";
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
            this.bbiClose,
            this.hiItemsCount});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ribbonControl.MaxItemId = 12;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowQatLocationSelector = false;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1216, 150);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 150);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1216, 584);
            this.panelControl1.TabIndex = 2;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1212, 580);
            this.gridControl.TabIndex = 1;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSlaveSID,
            this.colID,
            this.colIP,
            this.colIP_Internal,
            this.colSlaveName,
            this.colSlaveDescription,
            this.colIsSyncOrNot,
            this.colUserIsReplicatiedOrNot,
            this.colFinger1IsReplicatiedOrNot,
            this.colFinger2IsReplicatiedOrNot});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsFind.FindNullPrompt = "";
            this.gridView.OptionsFind.ShowClearButton = false;
            this.gridView.OptionsFind.ShowFindButton = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colSlaveSID
            // 
            this.colSlaveSID.FieldName = "SlaveSID";
            this.colSlaveSID.Name = "colSlaveSID";
            this.colSlaveSID.OptionsColumn.AllowEdit = false;
            this.colSlaveSID.OptionsColumn.ReadOnly = true;
            this.colSlaveSID.Width = 88;
            // 
            // colID
            // 
            this.colID.FieldName = "SlaveSID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 66;
            // 
            // colIP
            // 
            this.colIP.FieldName = "IP";
            this.colIP.Name = "colIP";
            this.colIP.OptionsColumn.AllowEdit = false;
            this.colIP.OptionsColumn.ReadOnly = true;
            this.colIP.Visible = true;
            this.colIP.VisibleIndex = 1;
            this.colIP.Width = 131;
            // 
            // colIP_Internal
            // 
            this.colIP_Internal.FieldName = "IP_Internal";
            this.colIP_Internal.Name = "colIP_Internal";
            this.colIP_Internal.OptionsColumn.AllowEdit = false;
            this.colIP_Internal.OptionsColumn.ReadOnly = true;
            this.colIP_Internal.Width = 129;
            // 
            // colSlaveName
            // 
            this.colSlaveName.FieldName = "SlaveName";
            this.colSlaveName.Name = "colSlaveName";
            this.colSlaveName.OptionsColumn.AllowEdit = false;
            this.colSlaveName.OptionsColumn.ReadOnly = true;
            this.colSlaveName.Visible = true;
            this.colSlaveName.VisibleIndex = 2;
            this.colSlaveName.Width = 139;
            // 
            // colSlaveDescription
            // 
            this.colSlaveDescription.FieldName = "SlaveDescription";
            this.colSlaveDescription.Name = "colSlaveDescription";
            this.colSlaveDescription.OptionsColumn.AllowEdit = false;
            this.colSlaveDescription.OptionsColumn.ReadOnly = true;
            this.colSlaveDescription.Visible = true;
            this.colSlaveDescription.VisibleIndex = 3;
            this.colSlaveDescription.Width = 139;
            // 
            // colIsSyncOrNot
            // 
            this.colIsSyncOrNot.FieldName = "IsSyncOrNot";
            this.colIsSyncOrNot.Name = "colIsSyncOrNot";
            this.colIsSyncOrNot.Visible = true;
            this.colIsSyncOrNot.VisibleIndex = 4;
            this.colIsSyncOrNot.Width = 139;
            // 
            // colUserIsReplicatiedOrNot
            // 
            this.colUserIsReplicatiedOrNot.FieldName = "UserIsReplicated";
            this.colUserIsReplicatiedOrNot.Name = "colUserIsReplicatiedOrNot";
            this.colUserIsReplicatiedOrNot.OptionsColumn.AllowEdit = false;
            this.colUserIsReplicatiedOrNot.OptionsColumn.ReadOnly = true;
            this.colUserIsReplicatiedOrNot.Visible = true;
            this.colUserIsReplicatiedOrNot.VisibleIndex = 5;
            this.colUserIsReplicatiedOrNot.Width = 139;
            // 
            // colFinger1IsReplicatiedOrNot
            // 
            this.colFinger1IsReplicatiedOrNot.FieldName = "Finger1IsReplicated";
            this.colFinger1IsReplicatiedOrNot.Name = "colFinger1IsReplicatiedOrNot";
            this.colFinger1IsReplicatiedOrNot.OptionsColumn.AllowEdit = false;
            this.colFinger1IsReplicatiedOrNot.OptionsColumn.ReadOnly = true;
            this.colFinger1IsReplicatiedOrNot.Visible = true;
            this.colFinger1IsReplicatiedOrNot.VisibleIndex = 6;
            this.colFinger1IsReplicatiedOrNot.Width = 139;
            // 
            // colFinger2IsReplicatiedOrNot
            // 
            this.colFinger2IsReplicatiedOrNot.FieldName = "Finger2IsReplicated";
            this.colFinger2IsReplicatiedOrNot.Name = "colFinger2IsReplicatiedOrNot";
            this.colFinger2IsReplicatiedOrNot.OptionsColumn.AllowEdit = false;
            this.colFinger2IsReplicatiedOrNot.OptionsColumn.ReadOnly = true;
            this.colFinger2IsReplicatiedOrNot.Visible = true;
            this.colFinger2IsReplicatiedOrNot.VisibleIndex = 7;
            this.colFinger2IsReplicatiedOrNot.Width = 166;
            // 
            // SyncSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SyncSetting";
            this.Size = new System.Drawing.Size(1216, 734);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarHeaderItem hiItemsCount;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private DevExpress.XtraBars.BarButtonItem bbiOnLoaded;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupClose;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveSID;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colIP;
        private DevExpress.XtraGrid.Columns.GridColumn colIP_Internal;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveName;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSyncOrNot;
        private DevExpress.XtraGrid.Columns.GridColumn colUserIsReplicatiedOrNot;
        private DevExpress.XtraGrid.Columns.GridColumn colFinger1IsReplicatiedOrNot;
        private DevExpress.XtraGrid.Columns.GridColumn colFinger2IsReplicatiedOrNot;
    }
}
