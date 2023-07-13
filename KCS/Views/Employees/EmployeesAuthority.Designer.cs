namespace KCS.Views
{
    partial class EmployeesAuthority
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnLoaded = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSave = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupControl = new DevExpress.XtraEditors.GroupControl();
            this.cmbBoxUserGroup = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSimpleTile = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlAdvTile = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlStartTime = new DevExpress.XtraEditors.LabelControl();
            this.timeEditEnd = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditStart = new DevExpress.XtraEditors.TimeEdit();
            this.lblCtlEndTime = new DevExpress.XtraEditors.LabelControl();
            this.groupControlDevice = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceSyncStatus = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowTimeStartHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowTimeStartMinute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowTimeEndHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowTimeEndMinute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveSID1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsReplicated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTimeStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTimeStr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSlaveSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxUserGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDevice)).BeginInit();
            this.groupControlDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSyncStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.EmployeesAuthorityViewModel);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveLayout,
            this.bbiResetLayout,
            this.bbiOnLoaded,
            this.bbiClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1691, 184);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
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
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 9;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
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
            // ribbonPageGroupClose
            // 
            this.ribbonPageGroupClose.AllowTextClipping = false;
            this.ribbonPageGroupClose.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroupClose.Name = "ribbonPageGroupClose";
            this.ribbonPageGroupClose.ShowCaptionButton = false;
            this.ribbonPageGroupClose.Text = "Close";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 184);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupControl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControlDevice);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1691, 658);
            this.splitContainerControl1.SplitterPosition = 563;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupControl
            // 
            this.groupControl.Controls.Add(this.cmbBoxUserGroup);
            this.groupControl.Controls.Add(this.lblSimpleTile);
            this.groupControl.Controls.Add(this.lblCtlAdvTile);
            this.groupControl.Controls.Add(this.lblCtlStartTime);
            this.groupControl.Controls.Add(this.timeEditEnd);
            this.groupControl.Controls.Add(this.timeEditStart);
            this.groupControl.Controls.Add(this.lblCtlEndTime);
            this.groupControl.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Use Advanced Access Control", true, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.CheckButton, "", -1, true, null, true, false, true, null, -1)});
            this.groupControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl.Location = new System.Drawing.Point(0, 0);
            this.groupControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(563, 658);
            this.groupControl.TabIndex = 0;
            // 
            // cmbBoxUserGroup
            // 
            this.cmbBoxUserGroup.Location = new System.Drawing.Point(120, 242);
            this.cmbBoxUserGroup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbBoxUserGroup.MenuManager = this.ribbonControl1;
            this.cmbBoxUserGroup.Name = "cmbBoxUserGroup";
            this.cmbBoxUserGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbBoxUserGroup.Properties.DropDownRows = 18;
            this.cmbBoxUserGroup.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbBoxUserGroup.Size = new System.Drawing.Size(273, 28);
            this.cmbBoxUserGroup.TabIndex = 7;
            // 
            // lblSimpleTile
            // 
            this.lblSimpleTile.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSimpleTile.Appearance.Options.UseFont = true;
            this.lblSimpleTile.Location = new System.Drawing.Point(120, 149);
            this.lblSimpleTile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblSimpleTile.Name = "lblSimpleTile";
            this.lblSimpleTile.Size = new System.Drawing.Size(259, 35);
            this.lblSimpleTile.TabIndex = 4;
            this.lblSimpleTile.Text = "Access Granted time";
            // 
            // lblCtlAdvTile
            // 
            this.lblCtlAdvTile.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtlAdvTile.Appearance.Options.UseFont = true;
            this.lblCtlAdvTile.Location = new System.Drawing.Point(120, 149);
            this.lblCtlAdvTile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlAdvTile.Name = "lblCtlAdvTile";
            this.lblCtlAdvTile.Size = new System.Drawing.Size(280, 35);
            this.lblCtlAdvTile.TabIndex = 6;
            this.lblCtlAdvTile.Text = "Access Granted Group";
            // 
            // lblCtlStartTime
            // 
            this.lblCtlStartTime.Location = new System.Drawing.Point(120, 242);
            this.lblCtlStartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlStartTime.Name = "lblCtlStartTime";
            this.lblCtlStartTime.Size = new System.Drawing.Size(82, 22);
            this.lblCtlStartTime.TabIndex = 2;
            this.lblCtlStartTime.Text = "Start Time";
            // 
            // timeEditEnd
            // 
            this.timeEditEnd.EditValue = new System.DateTime(2017, 1, 5, 23, 59, 0, 0);
            this.timeEditEnd.Location = new System.Drawing.Point(233, 316);
            this.timeEditEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timeEditEnd.MenuManager = this.ribbonControl1;
            this.timeEditEnd.Name = "timeEditEnd";
            this.timeEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditEnd.Properties.Mask.EditMask = "HH:mm";
            this.timeEditEnd.Size = new System.Drawing.Size(143, 28);
            this.timeEditEnd.TabIndex = 1;
            // 
            // timeEditStart
            // 
            this.timeEditStart.EditValue = new System.DateTime(2017, 1, 5, 0, 0, 0, 0);
            this.timeEditStart.Location = new System.Drawing.Point(233, 237);
            this.timeEditStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timeEditStart.MenuManager = this.ribbonControl1;
            this.timeEditStart.Name = "timeEditStart";
            this.timeEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditStart.Properties.Mask.EditMask = "HH:mm";
            this.timeEditStart.Size = new System.Drawing.Size(143, 28);
            this.timeEditStart.TabIndex = 0;
            // 
            // lblCtlEndTime
            // 
            this.lblCtlEndTime.Location = new System.Drawing.Point(129, 321);
            this.lblCtlEndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlEndTime.Name = "lblCtlEndTime";
            this.lblCtlEndTime.Size = new System.Drawing.Size(75, 22);
            this.lblCtlEndTime.TabIndex = 3;
            this.lblCtlEndTime.Text = "End Time";
            // 
            // groupControlDevice
            // 
            this.groupControlDevice.Controls.Add(this.panelControl1);
            this.groupControlDevice.Controls.Add(this.gridControl1);
            this.groupControlDevice.Controls.Add(this.gridControl);
            this.groupControlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDevice.Location = new System.Drawing.Point(0, 0);
            this.groupControlDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupControlDevice.Name = "groupControlDevice";
            this.groupControlDevice.Size = new System.Drawing.Size(1120, 658);
            this.groupControlDevice.TabIndex = 0;
            this.groupControlDevice.Text = "Selected devices";
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(1, 355);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1120, 16);
            this.panelControl1.TabIndex = 9;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bindingSourceSyncStatus;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Location = new System.Drawing.Point(3, 396);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1114, 259);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // bindingSourceSyncStatus
            // 
            this.bindingSourceSyncStatus.DataSource = typeof(KCS.Models.EmployeeAuthritySync);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colUserName,
            this.colCardID,
            this.colAllowTimeStartHour,
            this.colAllowTimeStartMinute,
            this.colAllowTimeEndHour,
            this.colAllowTimeEndMinute,
            this.colGroupID,
            this.colSlaveSID1,
            this.colIsReplicated,
            this.colStartTimeStr,
            this.colEndTimeStr});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFind.FindNullPrompt = "";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 0;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            // 
            // colCardID
            // 
            this.colCardID.FieldName = "CardID";
            this.colCardID.Name = "colCardID";
            this.colCardID.Visible = true;
            this.colCardID.VisibleIndex = 2;
            // 
            // colAllowTimeStartHour
            // 
            this.colAllowTimeStartHour.FieldName = "AllowTimeStartHour";
            this.colAllowTimeStartHour.Name = "colAllowTimeStartHour";
            // 
            // colAllowTimeStartMinute
            // 
            this.colAllowTimeStartMinute.FieldName = "AllowTimeStartMinute";
            this.colAllowTimeStartMinute.Name = "colAllowTimeStartMinute";
            // 
            // colAllowTimeEndHour
            // 
            this.colAllowTimeEndHour.FieldName = "AllowTimeEndHour";
            this.colAllowTimeEndHour.Name = "colAllowTimeEndHour";
            // 
            // colAllowTimeEndMinute
            // 
            this.colAllowTimeEndMinute.FieldName = "AllowTimeEndMinute";
            this.colAllowTimeEndMinute.Name = "colAllowTimeEndMinute";
            // 
            // colGroupID
            // 
            this.colGroupID.FieldName = "GroupIDStr";
            this.colGroupID.Name = "colGroupID";
            this.colGroupID.Visible = true;
            this.colGroupID.VisibleIndex = 3;
            // 
            // colSlaveSID1
            // 
            this.colSlaveSID1.FieldName = "SlaveSID";
            this.colSlaveSID1.Name = "colSlaveSID1";
            this.colSlaveSID1.Visible = true;
            this.colSlaveSID1.VisibleIndex = 7;
            // 
            // colIsReplicated
            // 
            this.colIsReplicated.FieldName = "IsReplicated";
            this.colIsReplicated.Name = "colIsReplicated";
            this.colIsReplicated.Visible = true;
            this.colIsReplicated.VisibleIndex = 6;
            // 
            // colStartTimeStr
            // 
            this.colStartTimeStr.FieldName = "StartTimeStr";
            this.colStartTimeStr.Name = "colStartTimeStr";
            this.colStartTimeStr.OptionsColumn.ReadOnly = true;
            this.colStartTimeStr.Visible = true;
            this.colStartTimeStr.VisibleIndex = 4;
            // 
            // colEndTimeStr
            // 
            this.colEndTimeStr.FieldName = "EndTimeStr";
            this.colEndTimeStr.Name = "colEndTimeStr";
            this.colEndTimeStr.OptionsColumn.ReadOnly = true;
            this.colEndTimeStr.Visible = true;
            this.colEndTimeStr.VisibleIndex = 5;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl.Location = new System.Drawing.Point(3, 33);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1114, 314);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.DeviceInfo);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSlaveSID,
            this.colIP,
            this.colSlaveName,
            this.colSlaveDescription});
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
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
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
            this.colSlaveSID.Visible = true;
            this.colSlaveSID.VisibleIndex = 1;
            // 
            // colIP
            // 
            this.colIP.FieldName = "IP";
            this.colIP.Name = "colIP";
            this.colIP.Visible = true;
            this.colIP.VisibleIndex = 2;
            // 
            // colSlaveName
            // 
            this.colSlaveName.FieldName = "SlaveName";
            this.colSlaveName.Name = "colSlaveName";
            this.colSlaveName.Visible = true;
            this.colSlaveName.VisibleIndex = 3;
            // 
            // colSlaveDescription
            // 
            this.colSlaveDescription.FieldName = "SlaveDescription";
            this.colSlaveDescription.Name = "colSlaveDescription";
            this.colSlaveDescription.Visible = true;
            this.colSlaveDescription.VisibleIndex = 4;
            // 
            // EmployeesAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EmployeesAuthority";
            this.Size = new System.Drawing.Size(1691, 842);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbBoxUserGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDevice)).EndInit();
            this.groupControlDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSyncStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private DevExpress.XtraBars.BarButtonItem bbiOnLoaded;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupClose;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl;
        private DevExpress.XtraEditors.GroupControl groupControlDevice;
        private DevExpress.XtraEditors.LabelControl lblCtlStartTime;
        private DevExpress.XtraEditors.TimeEdit timeEditEnd;
        private DevExpress.XtraEditors.TimeEdit timeEditStart;
        private DevExpress.XtraEditors.LabelControl lblCtlEndTime;
        private DevExpress.XtraEditors.LabelControl lblSimpleTile;
        private DevExpress.XtraEditors.LabelControl lblCtlAdvTile;
        private DevExpress.XtraEditors.ComboBoxEdit cmbBoxUserGroup;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveSID;
        private DevExpress.XtraGrid.Columns.GridColumn colIP;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveName;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveDescription;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource bindingSourceSyncStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCardID;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowTimeStartHour;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowTimeStartMinute;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowTimeEndHour;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowTimeEndMinute;
        private DevExpress.XtraGrid.Columns.GridColumn colGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveSID1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReplicated;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTimeStr;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTimeStr;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
