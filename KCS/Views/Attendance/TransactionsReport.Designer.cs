namespace KCS.Views
{
    partial class TransactionsReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionsReport));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.colCardID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radioGroupCondition = new DevExpress.XtraEditors.RadioGroup();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiHolidaySetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLeaveCategory = new DevExpress.XtraBars.BarButtonItem();
            this.bbiVocationSetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiModifyTrans = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAddTrans = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem = new DevExpress.XtraBars.BarHeaderItem();
            this.bbiExportToTxt = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportXLSX = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExprtToPDF = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.lookUpEditDevice = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourceDevice = new System.Windows.Forms.BindingSource(this.components);
            this.lblCtlDevice = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblCtlTo = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTranDateTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTranDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTranTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTranType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJobName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTranSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblCtlFrom = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCondition.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDevice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(KCS.ViewModels.TransactionsReportViewModel);
            // 
            // ribbonPageGroupActions
            // 
            this.ribbonPageGroupActions.Name = "ribbonPageGroupActions";
            this.ribbonPageGroupActions.ShowCaptionButton = false;
            this.ribbonPageGroupActions.Text = "Actions";
            // 
            // colCardID
            // 
            this.colCardID.FieldName = "CardID";
            this.colCardID.Name = "colCardID";
            this.colCardID.Visible = true;
            this.colCardID.VisibleIndex = 1;
            // 
            // colUserName
            // 
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 2;
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.Visible = true;
            this.colDepartmentID.VisibleIndex = 4;
            // 
            // radioGroupCondition
            // 
            this.radioGroupCondition.Location = new System.Drawing.Point(578, 16);
            this.radioGroupCondition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioGroupCondition.MenuManager = this.ribbonControl;
            this.radioGroupCondition.Name = "radioGroupCondition";
            this.radioGroupCondition.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupCondition.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupCondition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupCondition.Size = new System.Drawing.Size(280, 112);
            this.radioGroupCondition.TabIndex = 7;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiHolidaySetting,
            this.bbiLeaveCategory,
            this.bbiVocationSetting,
            this.bbiModifyTrans,
            this.bbiAddTrans,
            this.barHeaderItem,
            this.bbiExportToTxt,
            this.bbiExportXLSX,
            this.bbiExprtToPDF});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ribbonControl.MaxItemId = 14;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1648, 184);
            this.ribbonControl.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiHolidaySetting
            // 
            this.bbiHolidaySetting.Caption = "Holiday Setting";
            this.bbiHolidaySetting.Id = 4;
            this.bbiHolidaySetting.ImageOptions.Image = global::KCS.Properties.Resources.Holiday_set_16;
            this.bbiHolidaySetting.ImageOptions.LargeImage = global::KCS.Properties.Resources.Holiday_set_32;
            this.bbiHolidaySetting.Name = "bbiHolidaySetting";
            // 
            // bbiLeaveCategory
            // 
            this.bbiLeaveCategory.Caption = "Leave category";
            this.bbiLeaveCategory.Id = 5;
            this.bbiLeaveCategory.ImageOptions.Image = global::KCS.Properties.Resources.Leave_category_16;
            this.bbiLeaveCategory.ImageOptions.LargeImage = global::KCS.Properties.Resources.Leave_category_32;
            this.bbiLeaveCategory.Name = "bbiLeaveCategory";
            // 
            // bbiVocationSetting
            // 
            this.bbiVocationSetting.Caption = "Vacation setting";
            this.bbiVocationSetting.Id = 6;
            this.bbiVocationSetting.ImageOptions.Image = global::KCS.Properties.Resources.Vacation_setting_16;
            this.bbiVocationSetting.ImageOptions.LargeImage = global::KCS.Properties.Resources.Vacation_setting_32;
            this.bbiVocationSetting.Name = "bbiVocationSetting";
            // 
            // bbiModifyTrans
            // 
            this.bbiModifyTrans.Caption = "Modify Transaction";
            this.bbiModifyTrans.Id = 7;
            this.bbiModifyTrans.ImageOptions.Image = global::KCS.Properties.Resources.Modify_Trans_16;
            this.bbiModifyTrans.ImageOptions.LargeImage = global::KCS.Properties.Resources.Modify_Trans_32;
            this.bbiModifyTrans.Name = "bbiModifyTrans";
            // 
            // bbiAddTrans
            // 
            this.bbiAddTrans.Caption = "Add Transaction";
            this.bbiAddTrans.Id = 8;
            this.bbiAddTrans.ImageOptions.Image = global::KCS.Properties.Resources.Add_Trans_16;
            this.bbiAddTrans.ImageOptions.LargeImage = global::KCS.Properties.Resources.Add_Trans_32;
            this.bbiAddTrans.Name = "bbiAddTrans";
            // 
            // barHeaderItem
            // 
            this.barHeaderItem.Caption = "barHeaderItem1";
            this.barHeaderItem.Id = 10;
            this.barHeaderItem.Name = "barHeaderItem";
            // 
            // bbiExportToTxt
            // 
            this.bbiExportToTxt.Caption = "Export to Txt";
            this.bbiExportToTxt.Id = 11;
            this.bbiExportToTxt.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportToTxt.ImageOptions.Image")));
            this.bbiExportToTxt.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportToTxt.ImageOptions.LargeImage")));
            this.bbiExportToTxt.Name = "bbiExportToTxt";
            // 
            // bbiExportXLSX
            // 
            this.bbiExportXLSX.Caption = "Export to XLSX";
            this.bbiExportXLSX.Id = 12;
            this.bbiExportXLSX.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportXLSX.ImageOptions.Image")));
            this.bbiExportXLSX.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportXLSX.ImageOptions.LargeImage")));
            this.bbiExportXLSX.Name = "bbiExportXLSX";
            this.bbiExportXLSX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExportXLSX_ItemClick);
            // 
            // bbiExprtToPDF
            // 
            this.bbiExprtToPDF.Caption = "Export to PDF";
            this.bbiExprtToPDF.Id = 13;
            this.bbiExprtToPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExprtToPDF.ImageOptions.Image")));
            this.bbiExprtToPDF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExprtToPDF.ImageOptions.LargeImage")));
            this.bbiExprtToPDF.Name = "bbiExprtToPDF";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage2.Name = "ribbonPage2";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiHolidaySetting);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiLeaveCategory);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiVocationSetting);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiModifyTrans);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiAddTrans);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiExportToTxt);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiExportXLSX);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiExprtToPDF);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Actions";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barHeaderItem);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 726);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1648, 42);
            // 
            // lookUpEditDevice
            // 
            this.lookUpEditDevice.Location = new System.Drawing.Point(96, 24);
            this.lookUpEditDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditDevice.MenuManager = this.ribbonControl;
            this.lookUpEditDevice.Name = "lookUpEditDevice";
            this.lookUpEditDevice.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDevice.Properties.DataSource = this.bindingSourceDevice;
            this.lookUpEditDevice.Properties.DisplayMember = "IP";
            this.lookUpEditDevice.Properties.ShowHeader = false;
            this.lookUpEditDevice.Properties.ValueMember = "SlaveSID";
            this.lookUpEditDevice.Size = new System.Drawing.Size(464, 28);
            this.lookUpEditDevice.TabIndex = 6;
            // 
            // bindingSourceDevice
            // 
            this.bindingSourceDevice.DataSource = typeof(KCS.Models.DeviceBrief);
            // 
            // lblCtlDevice
            // 
            this.lblCtlDevice.Location = new System.Drawing.Point(31, 31);
            this.lblCtlDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlDevice.Name = "lblCtlDevice";
            this.lblCtlDevice.Size = new System.Drawing.Size(51, 22);
            this.lblCtlDevice.TabIndex = 5;
            this.lblCtlDevice.Text = "Device";
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.ImageOptions.Image = global::KCS.Properties.Resources.search_02;
            this.simpleButtonQuery.Location = new System.Drawing.Point(869, 31);
            this.simpleButtonQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(190, 83);
            this.simpleButtonQuery.TabIndex = 4;
            this.simpleButtonQuery.Text = "Query";
            this.simpleButtonQuery.Click += new System.EventHandler(this.simpleButtonQuery_Click);
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(354, 82);
            this.dateEditEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEditEnd.MenuManager = this.ribbonControl;
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Size = new System.Drawing.Size(206, 28);
            this.dateEditEnd.TabIndex = 3;
            // 
            // lblCtlTo
            // 
            this.lblCtlTo.Location = new System.Drawing.Point(311, 86);
            this.lblCtlTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlTo.Name = "lblCtlTo";
            this.lblCtlTo.Size = new System.Drawing.Size(21, 22);
            this.lblCtlTo.TabIndex = 2;
            this.lblCtlTo.Text = "To";
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(96, 82);
            this.dateEditStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEditStart.MenuManager = this.ribbonControl;
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Size = new System.Drawing.Size(206, 28);
            this.dateEditStart.TabIndex = 1;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 3;
            // 
            // colTranDateTime
            // 
            this.colTranDateTime.FieldName = "TranDateTimeString";
            this.colTranDateTime.Name = "colTranDateTime";
            this.colTranDateTime.Visible = true;
            this.colTranDateTime.VisibleIndex = 4;
            // 
            // colTranDate
            // 
            this.colTranDate.FieldName = "TranDate";
            this.colTranDate.Name = "colTranDate";
            // 
            // colTranTime
            // 
            this.colTranTime.FieldName = "TranTime";
            this.colTranTime.Name = "colTranTime";
            // 
            // colTranType
            // 
            this.colTranType.AppearanceCell.Options.UseTextOptions = true;
            this.colTranType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTranType.FieldName = "TranType";
            this.colTranType.Name = "colTranType";
            this.colTranType.Visible = true;
            this.colTranType.VisibleIndex = 5;
            // 
            // colJobName
            // 
            this.colJobName.FieldName = "JobName";
            this.colJobName.Name = "colJobName";
            this.colJobName.Visible = true;
            this.colJobName.VisibleIndex = 6;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 7;
            // 
            // colSlaveIP
            // 
            this.colSlaveIP.FieldName = "SlaveIP";
            this.colSlaveIP.Name = "colSlaveIP";
            this.colSlaveIP.Visible = true;
            this.colSlaveIP.VisibleIndex = 8;
            // 
            // colSlaveDescription
            // 
            this.colSlaveDescription.FieldName = "SlaveDescription";
            this.colSlaveDescription.Name = "colSlaveDescription";
            this.colSlaveDescription.Visible = true;
            this.colSlaveDescription.VisibleIndex = 9;
            // 
            // colInActive
            // 
            this.colInActive.AppearanceCell.Options.UseTextOptions = true;
            this.colInActive.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colInActive.Caption = "InActive";
            this.colInActive.FieldName = "InActive";
            this.colInActive.Name = "colInActive";
            this.colInActive.Visible = true;
            this.colInActive.VisibleIndex = 10;
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 2;
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
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            gridLevelNode2.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridControl.Location = new System.Drawing.Point(0, 329);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(20, 20, 20, 20);
            this.gridControl.MenuManager = this.ribbonControl;
            this.gridControl.Name = "gridControl";
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1648, 439);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.TaTransaction);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTranSID,
            this.colCardID,
            this.colUserID,
            this.colUserName,
            this.colDepartmentID,
            this.colDepartmentName,
            this.colTranDateTime,
            this.colTranDate,
            this.colTranTime,
            this.colTranType,
            this.colJobName,
            this.colID,
            this.colSlaveIP,
            this.colSlaveDescription,
            this.colInActive,
            this.colNote});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.GroupCount = 2;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindNullPrompt = "Search Transaction (Ctrl + F)";
            this.gridView.OptionsFind.ShowClearButton = false;
            this.gridView.OptionsFind.ShowFindButton = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsPrint.PrintGroupFooter = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentID, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colUserID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colTranSID
            // 
            this.colTranSID.AppearanceCell.Options.UseTextOptions = true;
            this.colTranSID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colTranSID.FieldName = "TranSID";
            this.colTranSID.Name = "colTranSID";
            this.colTranSID.Visible = true;
            this.colTranSID.VisibleIndex = 0;
            // 
            // colNote
            // 
            this.colNote.Caption = "Note";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            // 
            // lblCtlFrom
            // 
            this.lblCtlFrom.Location = new System.Drawing.Point(32, 86);
            this.lblCtlFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlFrom.Name = "lblCtlFrom";
            this.lblCtlFrom.Size = new System.Drawing.Size(40, 22);
            this.lblCtlFrom.TabIndex = 0;
            this.lblCtlFrom.Text = "From";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.radioGroupCondition);
            this.panelControl1.Controls.Add(this.lookUpEditDevice);
            this.panelControl1.Controls.Add(this.lblCtlDevice);
            this.panelControl1.Controls.Add(this.simpleButtonQuery);
            this.panelControl1.Controls.Add(this.dateEditEnd);
            this.panelControl1.Controls.Add(this.lblCtlTo);
            this.panelControl1.Controls.Add(this.dateEditStart);
            this.panelControl1.Controls.Add(this.lblCtlFrom);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 184);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1648, 145);
            this.panelControl1.TabIndex = 6;
            // 
            // TransactionsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TransactionsReport";
            this.Size = new System.Drawing.Size(1648, 768);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupCondition.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDevice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupActions;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colTranSID;
        private DevExpress.XtraGrid.Columns.GridColumn colCardID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colTranDateTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTranDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTranTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTranType;
        private DevExpress.XtraGrid.Columns.GridColumn colJobName;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveIP;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colInActive;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiHolidaySetting;
        private DevExpress.XtraBars.BarButtonItem bbiLeaveCategory;
        private DevExpress.XtraBars.BarButtonItem bbiVocationSetting;
        private DevExpress.XtraBars.BarButtonItem bbiModifyTrans;
        private DevExpress.XtraBars.BarButtonItem bbiAddTrans;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroupCondition;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDevice;
        private DevExpress.XtraEditors.LabelControl lblCtlDevice;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQuery;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.LabelControl lblCtlTo;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.LabelControl lblCtlFrom;
        private System.Windows.Forms.BindingSource bindingSourceDevice;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem;
        private DevExpress.XtraBars.BarButtonItem bbiExportToTxt;
        private DevExpress.XtraBars.BarButtonItem bbiExportXLSX;
        private DevExpress.XtraBars.BarButtonItem bbiExprtToPDF;
    }
}
