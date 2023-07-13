namespace KCS
{
    partial class XtraFormCompanyData
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
            this.textEditCompany = new DevExpress.XtraEditors.TextEdit();
            this.lblCtlCompanyName = new DevExpress.XtraEditors.LabelControl();
            this.sbSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCompany.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEditCompany
            // 
            this.textEditCompany.Location = new System.Drawing.Point(114, 70);
            this.textEditCompany.Name = "textEditCompany";
            this.textEditCompany.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditCompany.Properties.Appearance.Options.UseFont = true;
            this.textEditCompany.Size = new System.Drawing.Size(216, 24);
            this.textEditCompany.TabIndex = 0;
            // 
            // lblCtlCompanyName
            // 
            this.lblCtlCompanyName.Location = new System.Drawing.Point(13, 75);
            this.lblCtlCompanyName.Name = "lblCtlCompanyName";
            this.lblCtlCompanyName.Size = new System.Drawing.Size(85, 14);
            this.lblCtlCompanyName.TabIndex = 1;
            this.lblCtlCompanyName.Text = "Company Name";
            // 
            // sbSave
            // 
            this.sbSave.Location = new System.Drawing.Point(145, 128);
            this.sbSave.Name = "sbSave";
            this.sbSave.Size = new System.Drawing.Size(95, 38);
            this.sbSave.TabIndex = 2;
            this.sbSave.Text = "Save";
            this.sbSave.Click += new System.EventHandler(this.sbSave_Click);
            // 
            // XtraFormCompanyData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 262);
            this.Controls.Add(this.sbSave);
            this.Controls.Add(this.lblCtlCompanyName);
            this.Controls.Add(this.textEditCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormCompanyData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "XtraFormCompanyData";
            ((System.ComponentModel.ISupportInitialize)(this.textEditCompany.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEditCompany;
        private DevExpress.XtraEditors.LabelControl lblCtlCompanyName;
        private DevExpress.XtraEditors.SimpleButton sbSave;
    }
}