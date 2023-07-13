namespace KCS.Form
{
    partial class FormLangSelect
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
            this.comboBoxEditLang = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblCtlLanguage = new DevExpress.XtraEditors.LabelControl();
            this.buttonSaveLang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLang.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEditLang
            // 
            this.comboBoxEditLang.Location = new System.Drawing.Point(209, 141);
            this.comboBoxEditLang.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.comboBoxEditLang.Name = "comboBoxEditLang";
            this.comboBoxEditLang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLang.Size = new System.Drawing.Size(196, 28);
            this.comboBoxEditLang.TabIndex = 19;
            // 
            // lblCtlLanguage
            // 
            this.lblCtlLanguage.Location = new System.Drawing.Point(50, 141);
            this.lblCtlLanguage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.lblCtlLanguage.Name = "lblCtlLanguage";
            this.lblCtlLanguage.Size = new System.Drawing.Size(138, 22);
            this.lblCtlLanguage.TabIndex = 18;
            this.lblCtlLanguage.Text = "Default Language";
            // 
            // buttonSaveLang
            // 
            this.buttonSaveLang.Location = new System.Drawing.Point(179, 226);
            this.buttonSaveLang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSaveLang.Name = "buttonSaveLang";
            this.buttonSaveLang.Size = new System.Drawing.Size(131, 46);
            this.buttonSaveLang.TabIndex = 20;
            this.buttonSaveLang.Text = "Save";
            this.buttonSaveLang.UseVisualStyleBackColor = true;
            this.buttonSaveLang.Click += new System.EventHandler(this.buttonSaveLang_Click);
            // 
            // FormLangSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 412);
            this.Controls.Add(this.buttonSaveLang);
            this.Controls.Add(this.comboBoxEditLang);
            this.Controls.Add(this.lblCtlLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLangSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLangSelect";
            this.Load += new System.EventHandler(this.FormLangSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLang.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLang;
        private DevExpress.XtraEditors.LabelControl lblCtlLanguage;
        private System.Windows.Forms.Button buttonSaveLang;
    }
}