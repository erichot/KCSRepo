namespace KCS.Views
{
    partial class SupervisorEdit
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControlMain = new DevExpress.XtraLayout.LayoutControl();
            this.lookUpEditDepartment = new DevExpress.XtraEditors.LookUpEdit();
            this.memoEditRemarks = new DevExpress.XtraEditors.MemoEdit();
            this.comboBoxEditAdminType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.readOnlyAuthority = new DevExpress.XtraEditors.CheckEdit();
            this.textEditMobilePhone = new DevExpress.XtraEditors.TextEdit();
            this.textEditEmail = new DevExpress.XtraEditors.TextEdit();
            this.textEditUserName = new DevExpress.XtraEditors.TextEdit();
            this.textEditUserId = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForUserNO = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemMobilePhone = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemAdminType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemRemarks = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemDepartment = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDep = new System.Windows.Forms.BindingSource(this.components);
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).BeginInit();
            this.layoutControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditRemarks.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditAdminType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.readOnlyAuthority.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMobilePhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemMobilePhone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAdminType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRemarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Location = new System.Drawing.Point(18, 16);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(547, 486);
            this.panelControl1.TabIndex = 5;
            // 
            // layoutControlMain
            // 
            this.layoutControlMain.Controls.Add(this.lookUpEditDepartment);
            this.layoutControlMain.Controls.Add(this.memoEditRemarks);
            this.layoutControlMain.Controls.Add(this.comboBoxEditAdminType);
            this.layoutControlMain.Controls.Add(this.readOnlyAuthority);
            this.layoutControlMain.Controls.Add(this.textEditMobilePhone);
            this.layoutControlMain.Controls.Add(this.textEditEmail);
            this.layoutControlMain.Controls.Add(this.textEditUserName);
            this.layoutControlMain.Controls.Add(this.textEditUserId);
            this.layoutControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControlMain.Location = new System.Drawing.Point(0, 0);
            this.layoutControlMain.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControlMain.Name = "layoutControlMain";
            this.layoutControlMain.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1351, 239, 448, 521);
            this.layoutControlMain.Root = this.layoutControlGroup2;
            this.layoutControlMain.Size = new System.Drawing.Size(669, 511);
            this.layoutControlMain.TabIndex = 6;
            this.layoutControlMain.Text = "layoutControl2";
            // 
            // lookUpEditDepartment
            // 
            this.lookUpEditDepartment.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "DepartmentID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpEditDepartment.Location = new System.Drawing.Point(143, 194);
            this.lookUpEditDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lookUpEditDepartment.Name = "lookUpEditDepartment";
            this.lookUpEditDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditDepartment.Properties.DataSource = this.bindingSourceDep;
            this.lookUpEditDepartment.Properties.DisplayMember = "ListField";
            this.lookUpEditDepartment.Properties.ValueMember = "DepartmentID";
            this.lookUpEditDepartment.Size = new System.Drawing.Size(510, 24);
            this.lookUpEditDepartment.StyleController = this.layoutControlMain;
            this.lookUpEditDepartment.TabIndex = 13;
            // 
            // memoEditRemarks
            // 
            this.memoEditRemarks.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Note", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.memoEditRemarks.Location = new System.Drawing.Point(143, 224);
            this.memoEditRemarks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.memoEditRemarks.Name = "memoEditRemarks";
            this.memoEditRemarks.Size = new System.Drawing.Size(510, 271);
            this.memoEditRemarks.StyleController = this.layoutControlMain;
            this.memoEditRemarks.TabIndex = 12;
            // 
            // comboBoxEditAdminType
            // 
            this.comboBoxEditAdminType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "UserPermissionTypeBindable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.comboBoxEditAdminType.Location = new System.Drawing.Point(143, 164);
            this.comboBoxEditAdminType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxEditAdminType.Name = "comboBoxEditAdminType";
            this.comboBoxEditAdminType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditAdminType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditAdminType.Size = new System.Drawing.Size(510, 24);
            this.comboBoxEditAdminType.StyleController = this.layoutControlMain;
            this.comboBoxEditAdminType.TabIndex = 9;
            // 
            // readOnlyAuthority
            // 
            this.readOnlyAuthority.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "EmployeeAuthority", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.readOnlyAuthority.Location = new System.Drawing.Point(16, 136);
            this.readOnlyAuthority.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.readOnlyAuthority.Name = "readOnlyAuthority";
            this.readOnlyAuthority.Properties.Caption = "Read Only";
            this.readOnlyAuthority.Size = new System.Drawing.Size(637, 22);
            this.readOnlyAuthority.StyleController = this.layoutControlMain;
            this.readOnlyAuthority.TabIndex = 8;
            // 
            // textEditMobilePhone
            // 
            this.textEditMobilePhone.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "PhoneMobile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditMobilePhone.EnterMoveNextControl = true;
            this.textEditMobilePhone.Location = new System.Drawing.Point(143, 106);
            this.textEditMobilePhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditMobilePhone.Name = "textEditMobilePhone";
            this.textEditMobilePhone.Properties.ValidateOnEnterKey = true;
            this.textEditMobilePhone.Size = new System.Drawing.Size(510, 24);
            this.textEditMobilePhone.StyleController = this.layoutControlMain;
            this.textEditMobilePhone.TabIndex = 7;
            // 
            // textEditEmail
            // 
            this.textEditEmail.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Email", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditEmail.EnterMoveNextControl = true;
            this.textEditEmail.Location = new System.Drawing.Point(143, 76);
            this.textEditEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditEmail.Name = "textEditEmail";
            this.textEditEmail.Properties.ValidateOnEnterKey = true;
            this.textEditEmail.Size = new System.Drawing.Size(510, 24);
            this.textEditEmail.StyleController = this.layoutControlMain;
            this.textEditEmail.TabIndex = 6;
            // 
            // textEditUserName
            // 
            this.textEditUserName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "UserName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditUserName.EnterMoveNextControl = true;
            this.textEditUserName.Location = new System.Drawing.Point(143, 46);
            this.textEditUserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditUserName.Name = "textEditUserName";
            this.textEditUserName.Properties.ValidateOnEnterKey = true;
            this.textEditUserName.Size = new System.Drawing.Size(510, 24);
            this.textEditUserName.StyleController = this.layoutControlMain;
            this.textEditUserName.TabIndex = 5;
            // 
            // textEditUserId
            // 
            this.textEditUserId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "UserID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textEditUserId.Location = new System.Drawing.Point(143, 16);
            this.textEditUserId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditUserId.Name = "textEditUserId";
            this.textEditUserId.Properties.ReadOnly = true;
            this.textEditUserId.Size = new System.Drawing.Size(510, 24);
            this.textEditUserId.StyleController = this.layoutControlMain;
            this.textEditUserId.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForUserNO,
            this.ItemUserName,
            this.ItemEmail,
            this.ItemMobilePhone,
            this.layoutControlItem3,
            this.ItemAdminType,
            this.ItemRemarks,
            this.ItemDepartment});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "Root";
            this.layoutControlGroup2.Size = new System.Drawing.Size(669, 511);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // ItemForUserNO
            // 
            this.ItemForUserNO.Control = this.textEditUserId;
            this.ItemForUserNO.Location = new System.Drawing.Point(0, 0);
            this.ItemForUserNO.Name = "ItemForUserNO";
            this.ItemForUserNO.Size = new System.Drawing.Size(643, 30);
            this.ItemForUserNO.Text = "Supervisor ID";
            this.ItemForUserNO.TextSize = new System.Drawing.Size(124, 18);
            // 
            // ItemUserName
            // 
            this.ItemUserName.Control = this.textEditUserName;
            this.ItemUserName.Location = new System.Drawing.Point(0, 30);
            this.ItemUserName.Name = "ItemUserName";
            this.ItemUserName.Size = new System.Drawing.Size(643, 30);
            this.ItemUserName.Text = "Supervisor Name";
            this.ItemUserName.TextSize = new System.Drawing.Size(124, 18);
            // 
            // ItemEmail
            // 
            this.ItemEmail.Control = this.textEditEmail;
            this.ItemEmail.Location = new System.Drawing.Point(0, 60);
            this.ItemEmail.Name = "ItemEmail";
            this.ItemEmail.Size = new System.Drawing.Size(643, 30);
            this.ItemEmail.Text = "Email";
            this.ItemEmail.TextSize = new System.Drawing.Size(124, 18);
            // 
            // ItemMobilePhone
            // 
            this.ItemMobilePhone.Control = this.textEditMobilePhone;
            this.ItemMobilePhone.Location = new System.Drawing.Point(0, 90);
            this.ItemMobilePhone.Name = "ItemMobilePhone";
            this.ItemMobilePhone.Size = new System.Drawing.Size(643, 30);
            this.ItemMobilePhone.Text = "Mobile phone";
            this.ItemMobilePhone.TextSize = new System.Drawing.Size(124, 18);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.readOnlyAuthority;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(643, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // ItemAdminType
            // 
            this.ItemAdminType.Control = this.comboBoxEditAdminType;
            this.ItemAdminType.CustomizationFormText = "Admin Type";
            this.ItemAdminType.Location = new System.Drawing.Point(0, 148);
            this.ItemAdminType.Name = "ItemAdminType";
            this.ItemAdminType.Size = new System.Drawing.Size(643, 30);
            this.ItemAdminType.Text = "Administrator Type";
            this.ItemAdminType.TextSize = new System.Drawing.Size(124, 18);
            // 
            // ItemRemarks
            // 
            this.ItemRemarks.Control = this.memoEditRemarks;
            this.ItemRemarks.Location = new System.Drawing.Point(0, 208);
            this.ItemRemarks.MinSize = new System.Drawing.Size(121, 20);
            this.ItemRemarks.Name = "ItemRemarks";
            this.ItemRemarks.Size = new System.Drawing.Size(643, 277);
            this.ItemRemarks.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemRemarks.Text = "Remarks";
            this.ItemRemarks.TextSize = new System.Drawing.Size(124, 18);
            // 
            // ItemDepartment
            // 
            this.ItemDepartment.Control = this.lookUpEditDepartment;
            this.ItemDepartment.Location = new System.Drawing.Point(0, 178);
            this.ItemDepartment.Name = "ItemDepartment";
            this.ItemDepartment.Size = new System.Drawing.Size(643, 30);
            this.ItemDepartment.Text = "Department";
            this.ItemDepartment.TextSize = new System.Drawing.Size(124, 18);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.EmployeeSupervisor);
            // 
            // bindingSourceDep
            // 
            this.bindingSourceDep.DataSource = typeof(KCS.Models.DepartmentList);
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.SupervisorEditViewModel);
            // 
            // SupervisorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControlMain);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SupervisorEdit";
            this.Size = new System.Drawing.Size(669, 511);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlMain)).EndInit();
            this.layoutControlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditRemarks.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditAdminType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.readOnlyAuthority.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditMobilePhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemMobilePhone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemAdminType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemRemarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraLayout.LayoutControl layoutControlMain;
        private DevExpress.XtraEditors.MemoEdit memoEditRemarks;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditAdminType;
        private DevExpress.XtraEditors.CheckEdit readOnlyAuthority;
        private DevExpress.XtraEditors.TextEdit textEditMobilePhone;
        private DevExpress.XtraEditors.TextEdit textEditEmail;
        private DevExpress.XtraEditors.TextEdit textEditUserName;
        private DevExpress.XtraEditors.TextEdit textEditUserId;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserNO;
        private DevExpress.XtraLayout.LayoutControlItem ItemUserName;
        private DevExpress.XtraLayout.LayoutControlItem ItemEmail;
        private DevExpress.XtraLayout.LayoutControlItem ItemMobilePhone;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem ItemAdminType;
        private DevExpress.XtraLayout.LayoutControlItem ItemRemarks;
        private System.Windows.Forms.BindingSource bindingSourceDep;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditDepartment;
        private DevExpress.XtraLayout.LayoutControlItem ItemDepartment;
        private System.Windows.Forms.BindingSource bindingSource;

    }
}
