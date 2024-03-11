namespace KCS.Views
{
    partial class ExportEmployees
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
            this.barHeaderItem2 = new DevExpress.XtraBars.BarHeaderItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbExport = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControlExport = new DevExpress.XtraEditors.LabelControl();
            this.sbExport = new DevExpress.XtraEditors.SimpleButton();
            this.hiItemsCount = new DevExpress.XtraBars.BarHeaderItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCardID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserPWD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSyncOrNot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserPIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowTimeStartHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowTimeStartMinute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowTimeEndHour = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowTimeEndMinute = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsTaOrNot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValidDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserSIDString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepListField = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpTypeListField = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneMobile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutView = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.barHeaderItem3 = new DevExpress.XtraBars.BarHeaderItem();
            this.lblSupervisorDepartmentID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbExport.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.ExportEmployeesViewModel);
            // 
            // barHeaderItem2
            // 
            this.barHeaderItem2.Caption = "RECORDS: 0";
            this.barHeaderItem2.Id = 3;
            this.barHeaderItem2.Name = "barHeaderItem2";
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbExport);
            this.panelControl1.Controls.Add(this.labelControlExport);
            this.panelControl1.Controls.Add(this.sbExport);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1147, 70);
            this.panelControl1.TabIndex = 4;
            // 
            // cbExport
            // 
            this.cbExport.Location = new System.Drawing.Point(99, 20);
            this.cbExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbExport.Name = "cbExport";
            this.cbExport.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.cbExport.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbExport.Properties.DropDownRows = 10;
            this.cbExport.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbExport.Size = new System.Drawing.Size(213, 24);
            this.cbExport.TabIndex = 2;
            // 
            // labelControlExport
            // 
            this.labelControlExport.AllowHtmlString = true;
            this.labelControlExport.Location = new System.Drawing.Point(7, 25);
            this.labelControlExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControlExport.Name = "labelControlExport";
            this.labelControlExport.Size = new System.Drawing.Size(72, 18);
            this.labelControlExport.TabIndex = 3;
            this.labelControlExport.Text = "<b>Export</b> to:";
            // 
            // sbExport
            // 
            this.sbExport.Location = new System.Drawing.Point(337, 16);
            this.sbExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sbExport.Name = "sbExport";
            this.sbExport.Size = new System.Drawing.Size(155, 32);
            this.sbExport.TabIndex = 4;
            this.sbExport.Text = "Export...";
            // 
            // hiItemsCount
            // 
            this.hiItemsCount.Caption = "RECORDS: 0";
            this.hiItemsCount.Id = 11;
            this.hiItemsCount.Name = "hiItemsCount";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "RECORDS: 0";
            this.barHeaderItem1.Id = 11;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 70);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1147, 13);
            this.panelControl2.TabIndex = 6;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl.Location = new System.Drawing.Point(0, 83);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(16, 16, 16, 16);
            this.gridControl.Name = "gridControl";
            this.gridControl.ShowOnlyPredefinedDetails = true;
            this.gridControl.Size = new System.Drawing.Size(1147, 545);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView,
            this.layoutView});
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.Employees);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserSID,
            this.colUserID,
            this.colDepartmentID,
            this.colDepartmentName,
            this.colUserName,
            this.colCardID,
            this.colTitleName,
            this.colInActive,
            this.colUserPWD,
            this.colEmail,
            this.colSyncOrNot,
            this.colUserPIN,
            this.colAllowTimeStartHour,
            this.colAllowTimeStartMinute,
            this.colAllowTimeEndHour,
            this.colAllowTimeEndMinute,
            this.colIsTaOrNot,
            this.colEmployeeTypeID,
            this.colEmployeeTypeName,
            this.colValidDate,
            this.colUserSIDString,
            this.colDepListField,
            this.colEmpTypeListField,
            this.colPhoneMobile});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
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
            // 
            // colUserSID
            // 
            this.colUserSID.FieldName = "UserSID";
            this.colUserSID.Name = "colUserSID";
            // 
            // colUserID
            // 
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 0;
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.Visible = true;
            this.colDepartmentID.VisibleIndex = 2;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.FieldName = "DepartmentName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 3;
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
            this.colCardID.VisibleIndex = 4;
            // 
            // colTitleName
            // 
            this.colTitleName.FieldName = "TitleName";
            this.colTitleName.Name = "colTitleName";
            // 
            // colInActive
            // 
            this.colInActive.FieldName = "InActive";
            this.colInActive.Name = "colInActive";
            // 
            // colUserPWD
            // 
            this.colUserPWD.FieldName = "UserPWD";
            this.colUserPWD.Name = "colUserPWD";
            // 
            // colEmail
            // 
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 10;
            // 
            // colSyncOrNot
            // 
            this.colSyncOrNot.FieldName = "SyncOrNot";
            this.colSyncOrNot.Name = "colSyncOrNot";
            // 
            // colUserPIN
            // 
            this.colUserPIN.FieldName = "UserPIN";
            this.colUserPIN.Name = "colUserPIN";
            // 
            // colAllowTimeStartHour
            // 
            this.colAllowTimeStartHour.FieldName = "AllowTimeStartHour";
            this.colAllowTimeStartHour.Name = "colAllowTimeStartHour";
            this.colAllowTimeStartHour.Visible = true;
            this.colAllowTimeStartHour.VisibleIndex = 6;
            // 
            // colAllowTimeStartMinute
            // 
            this.colAllowTimeStartMinute.FieldName = "AllowTimeStartMinute";
            this.colAllowTimeStartMinute.Name = "colAllowTimeStartMinute";
            this.colAllowTimeStartMinute.Visible = true;
            this.colAllowTimeStartMinute.VisibleIndex = 7;
            // 
            // colAllowTimeEndHour
            // 
            this.colAllowTimeEndHour.FieldName = "AllowTimeEndHour";
            this.colAllowTimeEndHour.Name = "colAllowTimeEndHour";
            this.colAllowTimeEndHour.Visible = true;
            this.colAllowTimeEndHour.VisibleIndex = 8;
            // 
            // colAllowTimeEndMinute
            // 
            this.colAllowTimeEndMinute.FieldName = "AllowTimeEndMinute";
            this.colAllowTimeEndMinute.Name = "colAllowTimeEndMinute";
            this.colAllowTimeEndMinute.Visible = true;
            this.colAllowTimeEndMinute.VisibleIndex = 9;
            // 
            // colIsTaOrNot
            // 
            this.colIsTaOrNot.FieldName = "IsTaOrNot";
            this.colIsTaOrNot.Name = "colIsTaOrNot";
            // 
            // colEmployeeTypeID
            // 
            this.colEmployeeTypeID.FieldName = "EmployeeTypeID";
            this.colEmployeeTypeID.Name = "colEmployeeTypeID";
            // 
            // colEmployeeTypeName
            // 
            this.colEmployeeTypeName.FieldName = "EmployeeTypeName";
            this.colEmployeeTypeName.Name = "colEmployeeTypeName";
            // 
            // colValidDate
            // 
            this.colValidDate.FieldName = "ValidDate";
            this.colValidDate.Name = "colValidDate";
            this.colValidDate.Visible = true;
            this.colValidDate.VisibleIndex = 5;
            // 
            // colUserSIDString
            // 
            this.colUserSIDString.FieldName = "UserSIDString";
            this.colUserSIDString.Name = "colUserSIDString";
            this.colUserSIDString.OptionsColumn.ReadOnly = true;
            // 
            // colDepListField
            // 
            this.colDepListField.FieldName = "DepListField";
            this.colDepListField.Name = "colDepListField";
            this.colDepListField.OptionsColumn.ReadOnly = true;
            // 
            // colEmpTypeListField
            // 
            this.colEmpTypeListField.FieldName = "EmpTypeListField";
            this.colEmpTypeListField.Name = "colEmpTypeListField";
            this.colEmpTypeListField.OptionsColumn.ReadOnly = true;
            // 
            // colPhoneMobile
            // 
            this.colPhoneMobile.Caption = "PhoneMobile";
            this.colPhoneMobile.FieldName = "PhoneMobile";
            this.colPhoneMobile.Name = "colPhoneMobile";
            this.colPhoneMobile.Visible = true;
            this.colPhoneMobile.VisibleIndex = 11;
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
            // barHeaderItem3
            // 
            this.barHeaderItem3.Caption = "RECORDS: 0";
            this.barHeaderItem3.Id = 11;
            this.barHeaderItem3.Name = "barHeaderItem3";
            // 
            // lblSupervisorDepartmentID
            // 
            this.lblSupervisorDepartmentID.AutoSize = true;
            this.lblSupervisorDepartmentID.Location = new System.Drawing.Point(611, 575);
            this.lblSupervisorDepartmentID.Name = "lblSupervisorDepartmentID";
            this.lblSupervisorDepartmentID.Size = new System.Drawing.Size(181, 18);
            this.lblSupervisorDepartmentID.TabIndex = 8;
            this.lblSupervisorDepartmentID.Text = "lblSupervisorDepartmentID";
            this.lblSupervisorDepartmentID.Visible = false;
            // 
            // ExportEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSupervisorDepartmentID);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ExportEmployees";
            this.Size = new System.Drawing.Size(1147, 628);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbExport.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarHeaderItem hiItemsCount;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem2;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem3;
        private DevExpress.XtraEditors.ComboBoxEdit cbExport;
        private DevExpress.XtraEditors.LabelControl labelControlExport;
        private DevExpress.XtraEditors.SimpleButton sbExport;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colUserSID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCardID;
        private DevExpress.XtraGrid.Columns.GridColumn colTitleName;
        private DevExpress.XtraGrid.Columns.GridColumn colInActive;
        private DevExpress.XtraGrid.Columns.GridColumn colUserPWD;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colSyncOrNot;
        private DevExpress.XtraGrid.Columns.GridColumn colUserPIN;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowTimeStartHour;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowTimeStartMinute;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowTimeEndHour;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowTimeEndMinute;
        private DevExpress.XtraGrid.Columns.GridColumn colIsTaOrNot;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colValidDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUserSIDString;
        private DevExpress.XtraGrid.Columns.GridColumn colDepListField;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpTypeListField;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneMobile;
        private System.Windows.Forms.Label lblSupervisorDepartmentID;
    }
}
