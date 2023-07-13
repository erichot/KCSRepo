namespace KCS.Views
{
    partial class ImportEmployees
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
            this.radioGroupImportPara = new DevExpress.XtraEditors.RadioGroup();
            this.checkEditOverwrite = new DevExpress.XtraEditors.CheckEdit();
            this.sbImport = new DevExpress.XtraEditors.SimpleButton();
            this.lblCtlHint = new DevExpress.XtraEditors.LabelControl();
            this.checkEditSyncOrNot = new DevExpress.XtraEditors.CheckEdit();
            this.sbImportPhotos = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupImportPara.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditOverwrite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSyncOrNot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroupImportPara
            // 
            this.radioGroupImportPara.Location = new System.Drawing.Point(76, 49);
            this.radioGroupImportPara.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.radioGroupImportPara.Name = "radioGroupImportPara";
            this.radioGroupImportPara.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupImportPara.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupImportPara.Size = new System.Drawing.Size(350, 137);
            this.radioGroupImportPara.TabIndex = 0;
            // 
            // checkEditOverwrite
            // 
            this.checkEditOverwrite.Location = new System.Drawing.Point(467, 46);
            this.checkEditOverwrite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkEditOverwrite.Name = "checkEditOverwrite";
            this.checkEditOverwrite.Properties.Caption = "Import && Overwrite";
            this.checkEditOverwrite.Size = new System.Drawing.Size(233, 26);
            this.checkEditOverwrite.TabIndex = 1;
            // 
            // sbImport
            // 
            this.sbImport.Location = new System.Drawing.Point(467, 129);
            this.sbImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbImport.Name = "sbImport";
            this.sbImport.Size = new System.Drawing.Size(233, 57);
            this.sbImport.TabIndex = 2;
            this.sbImport.Text = "Import employees";
            this.sbImport.Click += new System.EventHandler(this.sbImport_Click);
            // 
            // lblCtlHint
            // 
            this.lblCtlHint.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtlHint.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblCtlHint.Appearance.Options.UseFont = true;
            this.lblCtlHint.Appearance.Options.UseForeColor = true;
            this.lblCtlHint.Location = new System.Drawing.Point(350, 214);
            this.lblCtlHint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlHint.Name = "lblCtlHint";
            this.lblCtlHint.Size = new System.Drawing.Size(0, 25);
            this.lblCtlHint.TabIndex = 3;
            // 
            // checkEditSyncOrNot
            // 
            this.checkEditSyncOrNot.Location = new System.Drawing.Point(467, 85);
            this.checkEditSyncOrNot.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkEditSyncOrNot.Name = "checkEditSyncOrNot";
            this.checkEditSyncOrNot.Properties.Caption = "Sync to devices after import";
            this.checkEditSyncOrNot.Size = new System.Drawing.Size(281, 26);
            this.checkEditSyncOrNot.TabIndex = 4;
            // 
            // sbImportPhotos
            // 
            this.sbImportPhotos.Location = new System.Drawing.Point(467, 214);
            this.sbImportPhotos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbImportPhotos.Name = "sbImportPhotos";
            this.sbImportPhotos.Size = new System.Drawing.Size(233, 57);
            this.sbImportPhotos.TabIndex = 5;
            this.sbImportPhotos.Text = "Import employees photos";
            this.sbImportPhotos.Click += new System.EventHandler(this.sbImportPhotos_Click);
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(76, 214);
            this.progressBarControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(350, 57);
            this.progressBarControl1.TabIndex = 6;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.ImportEmployeesViewModel);
            // 
            // ImportEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.sbImportPhotos);
            this.Controls.Add(this.checkEditSyncOrNot);
            this.Controls.Add(this.lblCtlHint);
            this.Controls.Add(this.sbImport);
            this.Controls.Add(this.checkEditOverwrite);
            this.Controls.Add(this.radioGroupImportPara);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ImportEmployees";
            this.Size = new System.Drawing.Size(753, 308);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupImportPara.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditOverwrite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditSyncOrNot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.SimpleButton sbImport;
        private DevExpress.XtraEditors.CheckEdit checkEditOverwrite;
        private DevExpress.XtraEditors.RadioGroup radioGroupImportPara;
        private DevExpress.XtraEditors.LabelControl lblCtlHint;
        private DevExpress.XtraEditors.CheckEdit checkEditSyncOrNot;
        private DevExpress.XtraEditors.SimpleButton sbImportPhotos;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
    }
}
