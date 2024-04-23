namespace KCS.Views
{
    partial class ChangeCardID
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.UserIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UserNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CardIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.DepListFieldTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForUserID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCardID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDepListField = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblCtlNewCardId = new DevExpress.XtraEditors.LabelControl();
            this.textEditNewCardId = new DevExpress.XtraEditors.TextEdit();
            this.bindingSourceEmployee = new System.Windows.Forms.BindingSource(this.components);
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepListFieldTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCardID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepListField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewCardId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmployee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.UserIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.UserNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CardIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.DepListFieldTextEdit);
            this.dataLayoutControl1.DataSource = this.bindingSourceEmployee;
            this.dataLayoutControl1.Location = new System.Drawing.Point(42, 42);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(556, 200);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // UserIDTextEdit
            // 
            this.UserIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceEmployee, "UserID", true));
            this.UserIDTextEdit.Location = new System.Drawing.Point(127, 18);
            this.UserIDTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserIDTextEdit.Name = "UserIDTextEdit";
            this.UserIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.UserIDTextEdit.Properties.ReadOnly = true;
            this.UserIDTextEdit.Size = new System.Drawing.Size(411, 28);
            this.UserIDTextEdit.StyleController = this.dataLayoutControl1;
            this.UserIDTextEdit.TabIndex = 4;
            // 
            // UserNameTextEdit
            // 
            this.UserNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceEmployee, "UserName", true));
            this.UserNameTextEdit.Location = new System.Drawing.Point(127, 52);
            this.UserNameTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UserNameTextEdit.Name = "UserNameTextEdit";
            this.UserNameTextEdit.Properties.ReadOnly = true;
            this.UserNameTextEdit.Size = new System.Drawing.Size(411, 28);
            this.UserNameTextEdit.StyleController = this.dataLayoutControl1;
            this.UserNameTextEdit.TabIndex = 5;
            // 
            // CardIDTextEdit
            // 
            this.CardIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceEmployee, "CardID", true));
            this.CardIDTextEdit.Location = new System.Drawing.Point(127, 86);
            this.CardIDTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CardIDTextEdit.Name = "CardIDTextEdit";
            this.CardIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.CardIDTextEdit.Properties.ReadOnly = true;
            this.CardIDTextEdit.Size = new System.Drawing.Size(411, 28);
            this.CardIDTextEdit.StyleController = this.dataLayoutControl1;
            this.CardIDTextEdit.TabIndex = 6;
            // 
            // DepListFieldTextEdit
            // 
            this.DepListFieldTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceEmployee, "DepListField", true));
            this.DepListFieldTextEdit.Location = new System.Drawing.Point(127, 120);
            this.DepListFieldTextEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DepListFieldTextEdit.Name = "DepListFieldTextEdit";
            this.DepListFieldTextEdit.Properties.ReadOnly = true;
            this.DepListFieldTextEdit.Size = new System.Drawing.Size(411, 28);
            this.DepListFieldTextEdit.StyleController = this.dataLayoutControl1;
            this.DepListFieldTextEdit.TabIndex = 7;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(556, 200);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForUserID,
            this.ItemForUserName,
            this.ItemForCardID,
            this.ItemForDepListField});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(526, 170);
            // 
            // ItemForUserID
            // 
            this.ItemForUserID.Control = this.UserIDTextEdit;
            this.ItemForUserID.Location = new System.Drawing.Point(0, 0);
            this.ItemForUserID.Name = "ItemForUserID";
            this.ItemForUserID.Size = new System.Drawing.Size(526, 34);
            this.ItemForUserID.TextSize = new System.Drawing.Size(106, 22);
            // 
            // ItemForUserName
            // 
            this.ItemForUserName.Control = this.UserNameTextEdit;
            this.ItemForUserName.Location = new System.Drawing.Point(0, 34);
            this.ItemForUserName.Name = "ItemForUserName";
            this.ItemForUserName.Size = new System.Drawing.Size(526, 34);
            this.ItemForUserName.Text = "User Name";
            this.ItemForUserName.TextSize = new System.Drawing.Size(106, 22);
            // 
            // ItemForCardID
            // 
            this.ItemForCardID.Control = this.CardIDTextEdit;
            this.ItemForCardID.Location = new System.Drawing.Point(0, 68);
            this.ItemForCardID.Name = "ItemForCardID";
            this.ItemForCardID.Size = new System.Drawing.Size(526, 34);
            this.ItemForCardID.TextSize = new System.Drawing.Size(106, 22);
            // 
            // ItemForDepListField
            // 
            this.ItemForDepListField.Control = this.DepListFieldTextEdit;
            this.ItemForDepListField.Location = new System.Drawing.Point(0, 102);
            this.ItemForDepListField.Name = "ItemForDepListField";
            this.ItemForDepListField.Size = new System.Drawing.Size(526, 68);
            this.ItemForDepListField.Text = "Dep List Field";
            this.ItemForDepListField.TextSize = new System.Drawing.Size(106, 22);
            // 
            // lblCtlNewCardId
            // 
            this.lblCtlNewCardId.Location = new System.Drawing.Point(61, 264);
            this.lblCtlNewCardId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlNewCardId.Name = "lblCtlNewCardId";
            this.lblCtlNewCardId.Size = new System.Drawing.Size(101, 22);
            this.lblCtlNewCardId.TabIndex = 1;
            this.lblCtlNewCardId.Text = "New Card ID";
            // 
            // textEditNewCardId
            // 
            this.textEditNewCardId.Location = new System.Drawing.Point(169, 259);
            this.textEditNewCardId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEditNewCardId.Name = "textEditNewCardId";
            this.textEditNewCardId.Size = new System.Drawing.Size(411, 28);
            this.textEditNewCardId.TabIndex = 2;
            // 
            // bindingSourceEmployee
            // 
            this.bindingSourceEmployee.DataSource = typeof(KCS.Models.Employees);
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.ChangeCardIDViewModel);
            // 
            // ChangeCardID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditNewCardId);
            this.Controls.Add(this.lblCtlNewCardId);
            this.Controls.Add(this.dataLayoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChangeCardID";
            this.Size = new System.Drawing.Size(638, 343);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CardIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepListFieldTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCardID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDepListField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewCardId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceEmployee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource bindingSourceEmployee;
        private DevExpress.XtraEditors.TextEdit textEditNewCardId;
        private DevExpress.XtraEditors.LabelControl lblCtlNewCardId;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit UserIDTextEdit;
        private DevExpress.XtraEditors.TextEdit UserNameTextEdit;
        private DevExpress.XtraEditors.TextEdit CardIDTextEdit;
        private DevExpress.XtraEditors.TextEdit DepListFieldTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCardID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDepListField;
    }
}
