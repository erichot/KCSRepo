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
            this.dataLayoutControl1.Location = new System.Drawing.Point(34, 34);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(445, 164);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // UserIDTextEdit
            // 
            this.UserIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceEmployee, "UserID", true));
            this.UserIDTextEdit.Location = new System.Drawing.Point(104, 16);
            this.UserIDTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserIDTextEdit.Name = "UserIDTextEdit";
            this.UserIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.UserIDTextEdit.Properties.ReadOnly = true;
            this.UserIDTextEdit.Size = new System.Drawing.Size(325, 24);
            this.UserIDTextEdit.StyleController = this.dataLayoutControl1;
            this.UserIDTextEdit.TabIndex = 4;
            // 
            // UserNameTextEdit
            // 
            this.UserNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceEmployee, "UserName", true));
            this.UserNameTextEdit.Location = new System.Drawing.Point(104, 46);
            this.UserNameTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserNameTextEdit.Name = "UserNameTextEdit";
            this.UserNameTextEdit.Properties.ReadOnly = true;
            this.UserNameTextEdit.Size = new System.Drawing.Size(325, 24);
            this.UserNameTextEdit.StyleController = this.dataLayoutControl1;
            this.UserNameTextEdit.TabIndex = 5;
            // 
            // CardIDTextEdit
            // 
            this.CardIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceEmployee, "CardID", true));
            this.CardIDTextEdit.Location = new System.Drawing.Point(104, 76);
            this.CardIDTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CardIDTextEdit.Name = "CardIDTextEdit";
            this.CardIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.CardIDTextEdit.Properties.ReadOnly = true;
            this.CardIDTextEdit.Size = new System.Drawing.Size(325, 24);
            this.CardIDTextEdit.StyleController = this.dataLayoutControl1;
            this.CardIDTextEdit.TabIndex = 6;
            // 
            // DepListFieldTextEdit
            // 
            this.DepListFieldTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSourceEmployee, "DepListField", true));
            this.DepListFieldTextEdit.Location = new System.Drawing.Point(104, 106);
            this.DepListFieldTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DepListFieldTextEdit.Name = "DepListFieldTextEdit";
            this.DepListFieldTextEdit.Properties.ReadOnly = true;
            this.DepListFieldTextEdit.Size = new System.Drawing.Size(325, 24);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(445, 164);
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
            this.layoutControlGroup2.Size = new System.Drawing.Size(419, 138);
            // 
            // ItemForUserID
            // 
            this.ItemForUserID.Control = this.UserIDTextEdit;
            this.ItemForUserID.Location = new System.Drawing.Point(0, 0);
            this.ItemForUserID.Name = "ItemForUserID";
            this.ItemForUserID.Size = new System.Drawing.Size(419, 30);
            this.ItemForUserID.TextSize = new System.Drawing.Size(85, 18);
            // 
            // ItemForUserName
            // 
            this.ItemForUserName.Control = this.UserNameTextEdit;
            this.ItemForUserName.Location = new System.Drawing.Point(0, 30);
            this.ItemForUserName.Name = "ItemForUserName";
            this.ItemForUserName.Size = new System.Drawing.Size(419, 30);
            this.ItemForUserName.Text = "User Name";
            this.ItemForUserName.TextSize = new System.Drawing.Size(85, 18);
            // 
            // ItemForCardID
            // 
            this.ItemForCardID.Control = this.CardIDTextEdit;
            this.ItemForCardID.Location = new System.Drawing.Point(0, 60);
            this.ItemForCardID.Name = "ItemForCardID";
            this.ItemForCardID.Size = new System.Drawing.Size(419, 30);
            this.ItemForCardID.TextSize = new System.Drawing.Size(85, 18);
            // 
            // ItemForDepListField
            // 
            this.ItemForDepListField.Control = this.DepListFieldTextEdit;
            this.ItemForDepListField.Location = new System.Drawing.Point(0, 90);
            this.ItemForDepListField.Name = "ItemForDepListField";
            this.ItemForDepListField.Size = new System.Drawing.Size(419, 48);
            this.ItemForDepListField.Text = "Dep List Field";
            this.ItemForDepListField.TextSize = new System.Drawing.Size(85, 18);
            // 
            // lblCtlNewCardId
            // 
            this.lblCtlNewCardId.Location = new System.Drawing.Point(49, 216);
            this.lblCtlNewCardId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCtlNewCardId.Name = "lblCtlNewCardId";
            this.lblCtlNewCardId.Size = new System.Drawing.Size(84, 18);
            this.lblCtlNewCardId.TabIndex = 1;
            this.lblCtlNewCardId.Text = "New Card ID";
            // 
            // textEditNewCardId
            // 
            this.textEditNewCardId.Location = new System.Drawing.Point(135, 212);
            this.textEditNewCardId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEditNewCardId.Name = "textEditNewCardId";
            this.textEditNewCardId.Size = new System.Drawing.Size(329, 24);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textEditNewCardId);
            this.Controls.Add(this.lblCtlNewCardId);
            this.Controls.Add(this.dataLayoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChangeCardID";
            this.Size = new System.Drawing.Size(510, 281);
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
