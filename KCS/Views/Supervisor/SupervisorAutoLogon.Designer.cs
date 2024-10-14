namespace KCS.Views.Supervisor
{
    partial class SupervisorAutoLogon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkIsAutoLogon = new System.Windows.Forms.CheckBox();
            this.txtUserID = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblCtlUserPwd = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlUserId = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkIsAutoLogon);
            this.panel1.Controls.Add(this.txtUserID);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.lblCtlUserPwd);
            this.panel1.Controls.Add(this.lblCtlUserId);
            this.panel1.Location = new System.Drawing.Point(14, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 192);
            this.panel1.TabIndex = 1;
            // 
            // chkIsAutoLogon
            // 
            this.chkIsAutoLogon.AutoSize = true;
            this.chkIsAutoLogon.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsAutoLogon.Location = new System.Drawing.Point(115, 122);
            this.chkIsAutoLogon.Name = "chkIsAutoLogon";
            this.chkIsAutoLogon.Size = new System.Drawing.Size(133, 28);
            this.chkIsAutoLogon.TabIndex = 30;
            this.chkIsAutoLogon.Text = "Auto Logon";
            this.chkIsAutoLogon.UseVisualStyleBackColor = true;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(115, 12);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserID.Properties.Appearance.Options.UseFont = true;
            this.txtUserID.Size = new System.Drawing.Size(267, 30);
            this.txtUserID.TabIndex = 28;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(115, 67);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(267, 30);
            this.txtPassword.TabIndex = 27;
            // 
            // lblCtlUserPwd
            // 
            this.lblCtlUserPwd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtlUserPwd.Appearance.Options.UseFont = true;
            this.lblCtlUserPwd.Location = new System.Drawing.Point(5, 70);
            this.lblCtlUserPwd.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lblCtlUserPwd.Name = "lblCtlUserPwd";
            this.lblCtlUserPwd.Size = new System.Drawing.Size(84, 24);
            this.lblCtlUserPwd.TabIndex = 26;
            this.lblCtlUserPwd.Text = "Password";
            // 
            // lblCtlUserId
            // 
            this.lblCtlUserId.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtlUserId.Appearance.Options.UseFont = true;
            this.lblCtlUserId.Location = new System.Drawing.Point(5, 15);
            this.lblCtlUserId.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lblCtlUserId.Name = "lblCtlUserId";
            this.lblCtlUserId.Size = new System.Drawing.Size(67, 24);
            this.lblCtlUserId.TabIndex = 24;
            this.lblCtlUserId.Text = "User ID";
            // 
            // btnOk
            // 
            this.btnOk.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Appearance.Options.UseBackColor = true;
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Appearance.Options.UseForeColor = true;
            this.btnOk.Location = new System.Drawing.Point(21, 234);
            this.btnOk.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(135, 54);
            this.btnOk.TabIndex = 28;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Location = new System.Drawing.Point(321, 234);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 54);
            this.btnCancel.TabIndex = 28;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.SupervisorAutoLognViewModel);
            // 
            // SupervisorAutoLogon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panel1);
            this.Name = "SupervisorAutoLogon";
            this.Size = new System.Drawing.Size(473, 316);
            this.Load += new System.EventHandler(this.SupervisorAutoLogon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public DevExpress.XtraEditors.LabelControl lblCtlUserId;
        public DevExpress.XtraEditors.LabelControl lblCtlUserPwd;
        private System.Windows.Forms.CheckBox chkIsAutoLogon;
        private DevExpress.XtraEditors.TextEdit txtUserID;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        public DevExpress.XtraEditors.SimpleButton btnOk;
        public DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
    }
}
