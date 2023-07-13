namespace KCS.Views
{
    partial class SetAdmin
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.textEditNewPinAgain = new DevExpress.XtraEditors.TextEdit();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textEditNewPin = new DevExpress.XtraEditors.TextEdit();
            this.textEditCurPin = new DevExpress.XtraEditors.TextEdit();
            this.textEditAdminName = new DevExpress.XtraEditors.TextEdit();
            this.textEditAdminNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlAdminNo = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlCurPin = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlNewPinAgain = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlNewPin = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlAdminName = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewPinAgain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewPin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCurPin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAdminName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAdminNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlAdminNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCurPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlNewPinAgain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlNewPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlAdminName)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.SetAdminViewModel);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textEditNewPinAgain);
            this.layoutControl1.Controls.Add(this.textEditNewPin);
            this.layoutControl1.Controls.Add(this.textEditCurPin);
            this.layoutControl1.Controls.Add(this.textEditAdminName);
            this.layoutControl1.Controls.Add(this.textEditAdminNo);
            this.layoutControl1.Location = new System.Drawing.Point(3, 7);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(656, 107, 547, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(405, 295);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // textEditNewPinAgain
            // 
            this.textEditNewPinAgain.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "NewUserPwdAgain", true));
            this.textEditNewPinAgain.EditValue = "";
            this.textEditNewPinAgain.Location = new System.Drawing.Point(93, 129);
            this.textEditNewPinAgain.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textEditNewPinAgain.Name = "textEditNewPinAgain";
            this.textEditNewPinAgain.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textEditNewPinAgain.Properties.Appearance.Options.UseFont = true;
            this.textEditNewPinAgain.Properties.PasswordChar = '*';
            this.textEditNewPinAgain.Size = new System.Drawing.Size(297, 32);
            this.textEditNewPinAgain.StyleController = this.layoutControl1;
            this.textEditNewPinAgain.TabIndex = 8;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.Administrator);
            // 
            // textEditNewPin
            // 
            this.textEditNewPin.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "NewUserPwd", true));
            this.textEditNewPin.Location = new System.Drawing.Point(93, 91);
            this.textEditNewPin.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textEditNewPin.Name = "textEditNewPin";
            this.textEditNewPin.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textEditNewPin.Properties.Appearance.Options.UseFont = true;
            this.textEditNewPin.Properties.PasswordChar = '*';
            this.textEditNewPin.Size = new System.Drawing.Size(297, 32);
            this.textEditNewPin.StyleController = this.layoutControl1;
            this.textEditNewPin.TabIndex = 7;
            // 
            // textEditCurPin
            // 
            this.textEditCurPin.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "UserPwd", true));
            this.textEditCurPin.Location = new System.Drawing.Point(93, 164);
            this.textEditCurPin.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textEditCurPin.Name = "textEditCurPin";
            this.textEditCurPin.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textEditCurPin.Properties.Appearance.Options.UseFont = true;
            this.textEditCurPin.Properties.PasswordChar = '*';
            this.textEditCurPin.Size = new System.Drawing.Size(297, 32);
            this.textEditCurPin.StyleController = this.layoutControl1;
            this.textEditCurPin.TabIndex = 6;
            // 
            // textEditAdminName
            // 
            this.textEditAdminName.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "UserName", true));
            this.textEditAdminName.Location = new System.Drawing.Point(93, 53);
            this.textEditAdminName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textEditAdminName.Name = "textEditAdminName";
            this.textEditAdminName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textEditAdminName.Properties.Appearance.Options.UseFont = true;
            this.textEditAdminName.Properties.ReadOnly = true;
            this.textEditAdminName.Size = new System.Drawing.Size(297, 32);
            this.textEditAdminName.StyleController = this.layoutControl1;
            this.textEditAdminName.TabIndex = 5;
            // 
            // textEditAdminNo
            // 
            this.textEditAdminNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "UserNo", true));
            this.textEditAdminNo.Location = new System.Drawing.Point(93, 15);
            this.textEditAdminNo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textEditAdminNo.Name = "textEditAdminNo";
            this.textEditAdminNo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.textEditAdminNo.Properties.Appearance.Options.UseFont = true;
            this.textEditAdminNo.Properties.ReadOnly = true;
            this.textEditAdminNo.Size = new System.Drawing.Size(297, 32);
            this.textEditAdminNo.StyleController = this.layoutControl1;
            this.textEditAdminNo.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.ContentImageAlignment = System.Drawing.ContentAlignment.TopRight;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlAdminNo,
            this.layoutControlCurPin,
            this.layoutControlNewPinAgain,
            this.layoutControlNewPin,
            this.layoutControlAdminName});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(405, 295);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlAdminNo
            // 
            this.layoutControlAdminNo.Control = this.textEditAdminNo;
            this.layoutControlAdminNo.FillControlToClientArea = false;
            this.layoutControlAdminNo.Location = new System.Drawing.Point(0, 0);
            this.layoutControlAdminNo.MaxSize = new System.Drawing.Size(0, 38);
            this.layoutControlAdminNo.MinSize = new System.Drawing.Size(134, 38);
            this.layoutControlAdminNo.Name = "layoutControlAdminNo";
            this.layoutControlAdminNo.Size = new System.Drawing.Size(381, 38);
            this.layoutControlAdminNo.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlAdminNo.Text = "管理员编号";
            this.layoutControlAdminNo.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlCurPin
            // 
            this.layoutControlCurPin.Control = this.textEditCurPin;
            this.layoutControlCurPin.FillControlToClientArea = false;
            this.layoutControlCurPin.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.layoutControlCurPin.Location = new System.Drawing.Point(0, 149);
            this.layoutControlCurPin.MaxSize = new System.Drawing.Size(0, 38);
            this.layoutControlCurPin.MinSize = new System.Drawing.Size(134, 38);
            this.layoutControlCurPin.Name = "layoutControlCurPin";
            this.layoutControlCurPin.Size = new System.Drawing.Size(381, 122);
            this.layoutControlCurPin.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlCurPin.Text = "当前密码";
            this.layoutControlCurPin.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlNewPinAgain
            // 
            this.layoutControlNewPinAgain.Control = this.textEditNewPinAgain;
            this.layoutControlNewPinAgain.FillControlToClientArea = false;
            this.layoutControlNewPinAgain.Location = new System.Drawing.Point(0, 114);
            this.layoutControlNewPinAgain.MaxSize = new System.Drawing.Size(0, 35);
            this.layoutControlNewPinAgain.MinSize = new System.Drawing.Size(134, 35);
            this.layoutControlNewPinAgain.Name = "layoutControlNewPinAgain";
            this.layoutControlNewPinAgain.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 0);
            this.layoutControlNewPinAgain.Size = new System.Drawing.Size(381, 35);
            this.layoutControlNewPinAgain.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlNewPinAgain.Text = "确认密码";
            this.layoutControlNewPinAgain.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlNewPin
            // 
            this.layoutControlNewPin.Control = this.textEditNewPin;
            this.layoutControlNewPin.FillControlToClientArea = false;
            this.layoutControlNewPin.Location = new System.Drawing.Point(0, 76);
            this.layoutControlNewPin.MaxSize = new System.Drawing.Size(0, 38);
            this.layoutControlNewPin.MinSize = new System.Drawing.Size(134, 38);
            this.layoutControlNewPin.Name = "layoutControlNewPin";
            this.layoutControlNewPin.Size = new System.Drawing.Size(381, 38);
            this.layoutControlNewPin.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlNewPin.Text = "输入新密码";
            this.layoutControlNewPin.TextSize = new System.Drawing.Size(75, 18);
            // 
            // layoutControlAdminName
            // 
            this.layoutControlAdminName.Control = this.textEditAdminName;
            this.layoutControlAdminName.FillControlToClientArea = false;
            this.layoutControlAdminName.Location = new System.Drawing.Point(0, 38);
            this.layoutControlAdminName.MaxSize = new System.Drawing.Size(0, 38);
            this.layoutControlAdminName.MinSize = new System.Drawing.Size(134, 38);
            this.layoutControlAdminName.Name = "layoutControlAdminName";
            this.layoutControlAdminName.Size = new System.Drawing.Size(381, 38);
            this.layoutControlAdminName.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlAdminName.Text = "管理员姓名";
            this.layoutControlAdminName.TextSize = new System.Drawing.Size(75, 18);
            // 
            // SetAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SetAdmin";
            this.Size = new System.Drawing.Size(411, 313);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewPinAgain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewPin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCurPin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAdminName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditAdminNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlAdminNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlCurPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlNewPinAgain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlNewPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlAdminName)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit textEditNewPinAgain;
        private DevExpress.XtraEditors.TextEdit textEditNewPin;
        private DevExpress.XtraEditors.TextEdit textEditCurPin;
        private DevExpress.XtraEditors.TextEdit textEditAdminName;
        private DevExpress.XtraEditors.TextEdit textEditAdminNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlAdminNo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlNewPinAgain;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlNewPin;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlAdminName;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlCurPin;
    }
}
