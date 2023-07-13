namespace KCS.Form
{
    partial class FormSyncSet
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
            this.checkEditDisableSync = new DevExpress.XtraEditors.CheckEdit();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDisableSync.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEditDisableSync
            // 
            this.checkEditDisableSync.Location = new System.Drawing.Point(94, 90);
            this.checkEditDisableSync.Name = "checkEditDisableSync";
            this.checkEditDisableSync.Properties.Caption = "停止通信";
            this.checkEditDisableSync.Size = new System.Drawing.Size(145, 19);
            this.checkEditDisableSync.TabIndex = 20;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(105, 132);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(92, 29);
            this.buttonSave.TabIndex = 21;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormSyncSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 276);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkEditDisableSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSyncSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSyncSet";
            this.Load += new System.EventHandler(this.FormSyncSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDisableSync.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEditDisableSync;
        private System.Windows.Forms.Button buttonSave;
    }
}