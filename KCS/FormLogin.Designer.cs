namespace KCS
{
    partial class FormLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.comboBoxUserId = new DevExpress.XtraEditors.ComboBoxEdit();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.checkEditRemember = new DevExpress.XtraEditors.CheckEdit();
            this.textUserPwd = new DevExpress.XtraEditors.TextEdit();
            this.lblCtlUserPwd = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlUserId = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlWelcome = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxUserId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRemember.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUserPwd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.LoginViewModel);
            // 
            // comboBoxUserId
            // 
            this.comboBoxUserId.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "UserNo", true));
            this.comboBoxUserId.Location = new System.Drawing.Point(266, 147);
            this.comboBoxUserId.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.comboBoxUserId.Name = "comboBoxUserId";
            this.comboBoxUserId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUserId.Properties.Appearance.Options.UseFont = true;
            this.comboBoxUserId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxUserId.Properties.CaseSensitiveSearch = true;
            this.comboBoxUserId.Size = new System.Drawing.Size(339, 36);
            this.comboBoxUserId.TabIndex = 28;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(KCS.Models.LoginAdmin);
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Appearance.Options.UseBackColor = true;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Appearance.Options.UseForeColor = true;
            this.btnLogin.Location = new System.Drawing.Point(436, 280);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(169, 66);
            this.btnLogin.TabIndex = 27;
            // 
            // checkEditRemember
            // 
            this.checkEditRemember.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "IsCacheOrNot", true));
            this.checkEditRemember.Location = new System.Drawing.Point(118, 298);
            this.checkEditRemember.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.checkEditRemember.Name = "checkEditRemember";
            this.checkEditRemember.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEditRemember.Properties.Appearance.Options.UseFont = true;
            this.checkEditRemember.Properties.Caption = "Remember me?";
            this.checkEditRemember.Size = new System.Drawing.Size(231, 29);
            this.checkEditRemember.TabIndex = 26;
            // 
            // textUserPwd
            // 
            this.textUserPwd.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "UserPwd", true));
            this.textUserPwd.Location = new System.Drawing.Point(266, 208);
            this.textUserPwd.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.textUserPwd.Name = "textUserPwd";
            this.textUserPwd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUserPwd.Properties.Appearance.Options.UseFont = true;
            this.textUserPwd.Properties.PasswordChar = '*';
            this.textUserPwd.Size = new System.Drawing.Size(339, 36);
            this.textUserPwd.TabIndex = 25;
            // 
            // lblCtlUserPwd
            // 
            this.lblCtlUserPwd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtlUserPwd.Appearance.Options.UseFont = true;
            this.lblCtlUserPwd.Location = new System.Drawing.Point(118, 215);
            this.lblCtlUserPwd.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.lblCtlUserPwd.Name = "lblCtlUserPwd";
            this.lblCtlUserPwd.Size = new System.Drawing.Size(101, 29);
            this.lblCtlUserPwd.TabIndex = 24;
            this.lblCtlUserPwd.Text = "Password";
            // 
            // lblCtlUserId
            // 
            this.lblCtlUserId.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtlUserId.Appearance.Options.UseFont = true;
            this.lblCtlUserId.Location = new System.Drawing.Point(118, 153);
            this.lblCtlUserId.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.lblCtlUserId.Name = "lblCtlUserId";
            this.lblCtlUserId.Size = new System.Drawing.Size(82, 29);
            this.lblCtlUserId.TabIndex = 23;
            this.lblCtlUserId.Text = "User ID";
            // 
            // lblCtlWelcome
            // 
            this.lblCtlWelcome.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(190)))), ((int)(((byte)(221)))));
            this.lblCtlWelcome.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtlWelcome.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblCtlWelcome.Appearance.Options.UseBackColor = true;
            this.lblCtlWelcome.Appearance.Options.UseFont = true;
            this.lblCtlWelcome.Appearance.Options.UseForeColor = true;
            this.lblCtlWelcome.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCtlWelcome.Location = new System.Drawing.Point(12, 33);
            this.lblCtlWelcome.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.lblCtlWelcome.Name = "lblCtlWelcome";
            this.lblCtlWelcome.Size = new System.Drawing.Size(674, 81);
            this.lblCtlWelcome.TabIndex = 22;
            this.lblCtlWelcome.Text = "   Welcome";
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 378);
            this.Controls.Add(this.comboBoxUserId);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.checkEditRemember);
            this.Controls.Add(this.textUserPwd);
            this.Controls.Add(this.lblCtlUserPwd);
            this.Controls.Add(this.lblCtlUserId);
            this.Controls.Add(this.lblCtlWelcome);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FormLogin";
            this.Text = "Login Attendance Management";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxUserId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditRemember.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUserPwd.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxUserId;
        public DevExpress.XtraEditors.SimpleButton btnLogin;
        public DevExpress.XtraEditors.CheckEdit checkEditRemember;
        private DevExpress.XtraEditors.TextEdit textUserPwd;
        public DevExpress.XtraEditors.LabelControl lblCtlUserPwd;
        public DevExpress.XtraEditors.LabelControl lblCtlUserId;
        public DevExpress.XtraEditors.LabelControl lblCtlWelcome;
        private System.Windows.Forms.BindingSource userBindingSource;
    }
}