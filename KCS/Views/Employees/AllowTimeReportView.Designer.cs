namespace KCS.Views
{
    partial class AllowTimeReportView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllowTimeReportView));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSourceAllowTime = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSlaveID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserTimeAddNew = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.biEdit = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToPDF = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToExcel = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupReport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmbEndHour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStartHour = new System.Windows.Forms.ComboBox();
            this.simpleButtonQuery = new DevExpress.XtraEditors.SimpleButton();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.bindingSourceDepartment = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSlave = new System.Windows.Forms.ComboBox();
            this.bindingSourceDevice = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAllowTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSourceAllowTime;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(2, 2);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(16);
            this.gridControl.Name = "gridControl";
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1303, 426);
            this.gridControl.TabIndex = 24;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // bindingSourceAllowTime
            // 
            this.bindingSourceAllowTime.DataSource = typeof(KCS.Models.UserSlaveAllowTimeSetting);
            // 
            // gridView
            // 
            this.gridView.Appearance.Row.Options.UseTextOptions = true;
            this.gridView.Appearance.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.gridView.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView.AppearancePrint.Row.Font = new System.Drawing.Font("Tahoma", 6.25F);
            this.gridView.AppearancePrint.Row.Options.UseFont = true;
            this.gridView.AppearancePrint.Row.Options.UseTextOptions = true;
            this.gridView.AppearancePrint.Row.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.gridView.AppearancePrint.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSlaveID,
            this.colUserSID,
            this.colCardID,
            this.colUserID,
            this.colUserName,
            this.colDepartmentID,
            this.colDepartmentName,
            this.colAllowTime,
            this.colUserTimeAddNew});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView.OptionsBehavior.CacheValuesOnRowUpdating = DevExpress.Data.CacheRowValuesMode.Disabled;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.gridView.OptionsCustomization.AllowGroup = false;
            this.gridView.OptionsFind.AlwaysVisible = true;
            this.gridView.OptionsFind.FindNullPrompt = "Search Employees (Ctrl + F)";
            this.gridView.OptionsFind.ShowClearButton = false;
            this.gridView.OptionsFind.ShowFindButton = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colSlaveID
            // 
            this.colSlaveID.AppearanceCell.Options.UseTextOptions = true;
            this.colSlaveID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSlaveID.Caption = "ID";
            this.colSlaveID.FieldName = "SlaveID";
            this.colSlaveID.Name = "colSlaveID";
            this.colSlaveID.Visible = true;
            this.colSlaveID.VisibleIndex = 0;
            this.colSlaveID.Width = 67;
            // 
            // colUserSID
            // 
            this.colUserSID.AppearanceCell.Options.UseTextOptions = true;
            this.colUserSID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserSID.Caption = "UserSID";
            this.colUserSID.FieldName = "UserSID";
            this.colUserSID.Name = "colUserSID";
            this.colUserSID.OptionsColumn.AllowEdit = false;
            this.colUserSID.OptionsColumn.ReadOnly = true;
            this.colUserSID.Width = 60;
            // 
            // colCardID
            // 
            this.colCardID.AppearanceCell.Options.UseTextOptions = true;
            this.colCardID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCardID.Caption = "Card ID";
            this.colCardID.FieldName = "CardID";
            this.colCardID.Name = "colCardID";
            this.colCardID.OptionsColumn.AllowEdit = false;
            this.colCardID.OptionsColumn.ReadOnly = true;
            this.colCardID.Visible = true;
            this.colCardID.VisibleIndex = 5;
            this.colCardID.Width = 126;
            // 
            // colUserID
            // 
            this.colUserID.AppearanceCell.Options.UseTextOptions = true;
            this.colUserID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserID.Caption = "Emp ID";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.OptionsColumn.AllowEdit = false;
            this.colUserID.OptionsColumn.ReadOnly = true;
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 1;
            this.colUserID.Width = 110;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserName.Caption = "Employee Name";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.OptionsColumn.ReadOnly = true;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 4;
            this.colUserName.Width = 317;
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.AppearanceCell.Options.UseTextOptions = true;
            this.colDepartmentID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepartmentID.Caption = "DepartID";
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.OptionsColumn.AllowEdit = false;
            this.colDepartmentID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colDepartmentID.OptionsColumn.ReadOnly = true;
            this.colDepartmentID.Visible = true;
            this.colDepartmentID.VisibleIndex = 2;
            this.colDepartmentID.Width = 125;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.AppearanceCell.Options.UseTextOptions = true;
            this.colDepartmentName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDepartmentName.Caption = "Department Name";
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.OptionsColumn.AllowEdit = false;
            this.colDepartmentName.OptionsColumn.ReadOnly = true;
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 3;
            this.colDepartmentName.Width = 288;
            // 
            // colAllowTime
            // 
            this.colAllowTime.AppearanceCell.Options.UseTextOptions = true;
            this.colAllowTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAllowTime.Caption = "Allow Time";
            this.colAllowTime.FieldName = "AllowTimeStartToEnd";
            this.colAllowTime.Name = "colAllowTime";
            this.colAllowTime.Visible = true;
            this.colAllowTime.VisibleIndex = 6;
            this.colAllowTime.Width = 143;
            // 
            // colUserTimeAddNew
            // 
            this.colUserTimeAddNew.AppearanceCell.Options.UseTextOptions = true;
            this.colUserTimeAddNew.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserTimeAddNew.Caption = "Card Active";
            this.colUserTimeAddNew.FieldName = "TimeAddNew";
            this.colUserTimeAddNew.Name = "colUserTimeAddNew";
            this.colUserTimeAddNew.Visible = true;
            this.colUserTimeAddNew.VisibleIndex = 7;
            this.colUserTimeAddNew.Width = 125;
            // 
            // layoutView
            // 
            this.layoutView.ActiveFilterEnabled = false;
            this.layoutView.CardCaptionFormat = "{3}";
            this.layoutView.CardMinSize = new System.Drawing.Size(390, 254);
            this.layoutView.FieldCaptionFormat = "{0}";
            this.layoutView.GridControl = this.gridControl;
            this.layoutView.Name = "layoutView";
            this.layoutView.OptionsBehavior.AllowExpandCollapse = false;
            this.layoutView.OptionsBehavior.AllowRuntimeCustomization = false;
            this.layoutView.OptionsBehavior.Editable = false;
            this.layoutView.OptionsBehavior.ReadOnly = true;
            this.layoutView.OptionsCustomization.AllowFilter = false;
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
            this.layoutView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.layoutView.OptionsView.ShowHeaderPanel = false;
            this.layoutView.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.MultiRow;
            this.layoutView.TemplateCard = this.layoutViewCard1;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 4;
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.biEdit,
            this.biDelete,
            this.bbiExportToPDF,
            this.bbiClose,
            this.bbiExportToExcel});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl.MaxItemId = 1;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1307, 150);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // biEdit
            // 
            this.biEdit.Caption = "Edit";
            this.biEdit.Id = 1;
            this.biEdit.ImageOptions.Image = global::KCS.Properties.Resources.icon_edit_16;
            this.biEdit.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_edit_32;
            this.biEdit.Name = "biEdit";
            // 
            // biDelete
            // 
            this.biDelete.Caption = "Delete";
            this.biDelete.Id = 2;
            this.biDelete.ImageOptions.Image = global::KCS.Properties.Resources.icon_delete_16;
            this.biDelete.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_delete_32;
            this.biDelete.Name = "biDelete";
            // 
            // bbiExportToPDF
            // 
            this.bbiExportToPDF.Caption = "Export To PDF";
            this.bbiExportToPDF.Id = 4;
            this.bbiExportToPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportToPDF.ImageOptions.Image")));
            this.bbiExportToPDF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportToPDF.ImageOptions.LargeImage")));
            this.bbiExportToPDF.Name = "bbiExportToPDF";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 7;
            this.bbiClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
            this.bbiClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.LargeImage")));
            this.bbiClose.Name = "bbiClose";
            // 
            // bbiExportToExcel
            // 
            this.bbiExportToExcel.Caption = "Export To Excel";
            this.bbiExportToExcel.Id = 2;
            this.bbiExportToExcel.ImageOptions.Image = global::KCS.Properties.Resources.chart_32;
            this.bbiExportToExcel.ImageOptions.LargeImage = global::KCS.Properties.Resources.chart_32;
            this.bbiExportToExcel.Name = "bbiExportToExcel";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupActions,
            this.ribbonPageGroupReport});
            this.ribbonPage2.Name = "ribbonPage2";
            // 
            // ribbonPageGroupActions
            // 
            this.ribbonPageGroupActions.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroupActions.Name = "ribbonPageGroupActions";
            this.ribbonPageGroupActions.ShowCaptionButton = false;
            this.ribbonPageGroupActions.Text = "Actions";
            // 
            // ribbonPageGroupReport
            // 
            this.ribbonPageGroupReport.ItemLinks.Add(this.bbiExportToExcel);
            this.ribbonPageGroupReport.ItemLinks.Add(this.bbiExportToPDF);
            this.ribbonPageGroupReport.Name = "ribbonPageGroupReport";
            this.ribbonPageGroupReport.ShowCaptionButton = false;
            this.ribbonPageGroupReport.Text = "Report";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cmbEndHour);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.cmbStartHour);
            this.panelControl2.Controls.Add(this.simpleButtonQuery);
            this.panelControl2.Controls.Add(this.cmbDepartment);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.cmbSlave);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 150);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1307, 117);
            this.panelControl2.TabIndex = 27;
            // 
            // cmbEndHour
            // 
            this.cmbEndHour.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEndHour.FormattingEnabled = true;
            this.cmbEndHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbEndHour.Location = new System.Drawing.Point(691, 61);
            this.cmbEndHour.Name = "cmbEndHour";
            this.cmbEndHour.Size = new System.Drawing.Size(121, 28);
            this.cmbEndHour.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(603, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "End Hour";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Start Hour";
            // 
            // cmbStartHour
            // 
            this.cmbStartHour.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStartHour.FormattingEnabled = true;
            this.cmbStartHour.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbStartHour.Location = new System.Drawing.Point(691, 14);
            this.cmbStartHour.Name = "cmbStartHour";
            this.cmbStartHour.Size = new System.Drawing.Size(121, 28);
            this.cmbStartHour.TabIndex = 15;
            // 
            // simpleButtonQuery
            // 
            this.simpleButtonQuery.ImageOptions.Image = global::KCS.Properties.Resources.search_02;
            this.simpleButtonQuery.Location = new System.Drawing.Point(888, 19);
            this.simpleButtonQuery.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonQuery.Name = "simpleButtonQuery";
            this.simpleButtonQuery.Size = new System.Drawing.Size(152, 68);
            this.simpleButtonQuery.TabIndex = 14;
            this.simpleButtonQuery.Text = "Query";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DataSource = this.bindingSourceDepartment;
            this.cmbDepartment.DisplayMember = "ListField";
            this.cmbDepartment.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(113, 14);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(398, 28);
            this.cmbDepartment.TabIndex = 13;
            this.cmbDepartment.ValueMember = "DepartmentID";
            // 
            // bindingSourceDepartment
            // 
            this.bindingSourceDepartment.DataSource = typeof(KCS.Models.Department);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Department";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Device";
            // 
            // cmbSlave
            // 
            this.cmbSlave.DataSource = this.bindingSourceDevice;
            this.cmbSlave.DisplayMember = "ListField";
            this.cmbSlave.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSlave.FormattingEnabled = true;
            this.cmbSlave.Location = new System.Drawing.Point(115, 64);
            this.cmbSlave.Name = "cmbSlave";
            this.cmbSlave.Size = new System.Drawing.Size(396, 30);
            this.cmbSlave.TabIndex = 10;
            this.cmbSlave.ValueMember = "SlaveSID";
            this.cmbSlave.SelectedIndexChanged += new System.EventHandler(this.cmbSlave_SelectedIndexChanged);
            // 
            // bindingSourceDevice
            // 
            this.bindingSourceDevice.DataSource = typeof(KCS.Models.DeviceBrief);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 267);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1307, 430);
            this.panelControl1.TabIndex = 28;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.AllowTimeReportViewModel);
            // 
            // AllowTimeReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AllowTimeReportView";
            this.Size = new System.Drawing.Size(1307, 697);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAllowTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colUserSID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCardID;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private System.Windows.Forms.BindingSource bindingSourceAllowTime;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem biEdit;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraBars.BarButtonItem bbiExportToPDF;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupActions;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupReport;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.ComboBox cmbSlave;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private System.Windows.Forms.BindingSource bindingSourceDevice;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveID;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUserTimeAddNew;
        private DevExpress.XtraBars.BarButtonItem bbiExportToExcel;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSourceDepartment;
        private DevExpress.XtraEditors.SimpleButton simpleButtonQuery;
        private System.Windows.Forms.ComboBox cmbEndHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbStartHour;
    }
}
