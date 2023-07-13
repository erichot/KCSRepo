namespace KCS.Form
{
    partial class FormDatabaseMaintenance
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
            this.tabPaneDBM = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage2 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.sbRestore = new DevExpress.XtraEditors.SimpleButton();
            this.sbRestorePath = new DevExpress.XtraEditors.SimpleButton();
            this.textEditRestorePath = new DevExpress.XtraEditors.TextEdit();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.sBBackUp = new DevExpress.XtraEditors.SimpleButton();
            this.sbBackUpPath = new DevExpress.XtraEditors.SimpleButton();
            this.textEditBackUpPath = new DevExpress.XtraEditors.TextEdit();
            this.tabNavigationPage3 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.sbDeleteRecords = new DevExpress.XtraEditors.SimpleButton();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblCtlTo = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.lblCtlFrom = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneDBM)).BeginInit();
            this.tabPaneDBM.SuspendLayout();
            this.tabNavigationPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditRestorePath.Properties)).BeginInit();
            this.tabNavigationPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackUpPath.Properties)).BeginInit();
            this.tabNavigationPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPaneDBM
            // 
            this.tabPaneDBM.Controls.Add(this.tabNavigationPage2);
            this.tabPaneDBM.Controls.Add(this.tabNavigationPage1);
            this.tabPaneDBM.Controls.Add(this.tabNavigationPage3);
            this.tabPaneDBM.Location = new System.Drawing.Point(17, 19);
            this.tabPaneDBM.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPaneDBM.Name = "tabPaneDBM";
            this.tabPaneDBM.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1,
            this.tabNavigationPage2,
            this.tabNavigationPage3});
            this.tabPaneDBM.RegularSize = new System.Drawing.Size(1131, 586);
            this.tabPaneDBM.SelectedPage = this.tabNavigationPage1;
            this.tabPaneDBM.Size = new System.Drawing.Size(1131, 586);
            this.tabPaneDBM.TabIndex = 0;
            this.tabPaneDBM.Text = "tabPaneDBM";
            // 
            // tabNavigationPage2
            // 
            this.tabNavigationPage2.Caption = "Database restore";
            this.tabNavigationPage2.Controls.Add(this.sbRestore);
            this.tabNavigationPage2.Controls.Add(this.sbRestorePath);
            this.tabNavigationPage2.Controls.Add(this.textEditRestorePath);
            this.tabNavigationPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabNavigationPage2.Name = "tabNavigationPage2";
            this.tabNavigationPage2.Size = new System.Drawing.Size(1106, 514);
            // 
            // sbRestore
            // 
            this.sbRestore.Location = new System.Drawing.Point(84, 127);
            this.sbRestore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbRestore.Name = "sbRestore";
            this.sbRestore.Size = new System.Drawing.Size(176, 83);
            this.sbRestore.TabIndex = 2;
            this.sbRestore.Text = "Retore Database";
            this.sbRestore.Click += new System.EventHandler(this.sbRestore_Click);
            // 
            // sbRestorePath
            // 
            this.sbRestorePath.Location = new System.Drawing.Point(547, 55);
            this.sbRestorePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbRestorePath.Name = "sbRestorePath";
            this.sbRestorePath.Size = new System.Drawing.Size(64, 52);
            this.sbRestorePath.TabIndex = 1;
            this.sbRestorePath.Text = "...";
            this.sbRestorePath.Click += new System.EventHandler(this.sbRestorePath_Click);
            // 
            // textEditRestorePath
            // 
            this.textEditRestorePath.Location = new System.Drawing.Point(84, 60);
            this.textEditRestorePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEditRestorePath.Name = "textEditRestorePath";
            this.textEditRestorePath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditRestorePath.Properties.Appearance.Options.UseFont = true;
            this.textEditRestorePath.Size = new System.Drawing.Size(454, 32);
            this.textEditRestorePath.TabIndex = 0;
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "Database backup";
            this.tabNavigationPage1.Controls.Add(this.sBBackUp);
            this.tabNavigationPage1.Controls.Add(this.sbBackUpPath);
            this.tabNavigationPage1.Controls.Add(this.textEditBackUpPath);
            this.tabNavigationPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(1094, 475);
            // 
            // sBBackUp
            // 
            this.sBBackUp.Location = new System.Drawing.Point(73, 129);
            this.sBBackUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sBBackUp.Name = "sBBackUp";
            this.sBBackUp.Size = new System.Drawing.Size(176, 83);
            this.sBBackUp.TabIndex = 2;
            this.sBBackUp.Text = "...";
            this.sBBackUp.Click += new System.EventHandler(this.sBBackUp_Click);
            // 
            // sbBackUpPath
            // 
            this.sbBackUpPath.Location = new System.Drawing.Point(564, 63);
            this.sbBackUpPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbBackUpPath.Name = "sbBackUpPath";
            this.sbBackUpPath.Size = new System.Drawing.Size(61, 50);
            this.sbBackUpPath.TabIndex = 1;
            this.sbBackUpPath.Text = "...";
            this.sbBackUpPath.Click += new System.EventHandler(this.sbBackUpPath_Click);
            // 
            // textEditBackUpPath
            // 
            this.textEditBackUpPath.Location = new System.Drawing.Point(73, 68);
            this.textEditBackUpPath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEditBackUpPath.Name = "textEditBackUpPath";
            this.textEditBackUpPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditBackUpPath.Properties.Appearance.Options.UseFont = true;
            this.textEditBackUpPath.Size = new System.Drawing.Size(483, 32);
            this.textEditBackUpPath.TabIndex = 0;
            // 
            // tabNavigationPage3
            // 
            this.tabNavigationPage3.Caption = "Delete attendance records";
            this.tabNavigationPage3.Controls.Add(this.sbDeleteRecords);
            this.tabNavigationPage3.Controls.Add(this.dateEditEnd);
            this.tabNavigationPage3.Controls.Add(this.lblCtlTo);
            this.tabNavigationPage3.Controls.Add(this.dateEditStart);
            this.tabNavigationPage3.Controls.Add(this.lblCtlFrom);
            this.tabNavigationPage3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabNavigationPage3.Name = "tabNavigationPage3";
            this.tabNavigationPage3.Size = new System.Drawing.Size(1106, 514);
            // 
            // sbDeleteRecords
            // 
            this.sbDeleteRecords.Location = new System.Drawing.Point(191, 157);
            this.sbDeleteRecords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbDeleteRecords.Name = "sbDeleteRecords";
            this.sbDeleteRecords.Size = new System.Drawing.Size(214, 71);
            this.sbDeleteRecords.TabIndex = 8;
            this.sbDeleteRecords.Text = "Delete Records";
            this.sbDeleteRecords.Click += new System.EventHandler(this.sbDeleteRecords_Click);
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(577, 74);
            this.dateEditEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditEnd.Properties.Appearance.Options.UseFont = true;
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Size = new System.Drawing.Size(206, 36);
            this.dateEditEnd.TabIndex = 7;
            // 
            // lblCtlTo
            // 
            this.lblCtlTo.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtlTo.Appearance.Options.UseFont = true;
            this.lblCtlTo.Location = new System.Drawing.Point(507, 79);
            this.lblCtlTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlTo.Name = "lblCtlTo";
            this.lblCtlTo.Size = new System.Drawing.Size(27, 29);
            this.lblCtlTo.TabIndex = 6;
            this.lblCtlTo.Text = "To";
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(254, 74);
            this.dateEditStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEditStart.Properties.Appearance.Options.UseFont = true;
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Size = new System.Drawing.Size(206, 36);
            this.dateEditStart.TabIndex = 5;
            // 
            // lblCtlFrom
            // 
            this.lblCtlFrom.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtlFrom.Appearance.Options.UseFont = true;
            this.lblCtlFrom.Location = new System.Drawing.Point(191, 79);
            this.lblCtlFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlFrom.Name = "lblCtlFrom";
            this.lblCtlFrom.Size = new System.Drawing.Size(55, 29);
            this.lblCtlFrom.TabIndex = 4;
            this.lblCtlFrom.Text = "From";
            // 
            // FormDatabaseMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 624);
            this.Controls.Add(this.tabPaneDBM);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDatabaseMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDatabaseMaintenance";
            ((System.ComponentModel.ISupportInitialize)(this.tabPaneDBM)).EndInit();
            this.tabPaneDBM.ResumeLayout(false);
            this.tabNavigationPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditRestorePath.Properties)).EndInit();
            this.tabNavigationPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEditBackUpPath.Properties)).EndInit();
            this.tabNavigationPage3.ResumeLayout(false);
            this.tabNavigationPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabPaneDBM;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage2;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage3;
        private DevExpress.XtraEditors.SimpleButton sbBackUpPath;
        private DevExpress.XtraEditors.TextEdit textEditBackUpPath;
        private DevExpress.XtraEditors.SimpleButton sBBackUp;
        private DevExpress.XtraEditors.SimpleButton sbRestorePath;
        private DevExpress.XtraEditors.TextEdit textEditRestorePath;
        private DevExpress.XtraEditors.SimpleButton sbRestore;
        private DevExpress.XtraEditors.SimpleButton sbDeleteRecords;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.LabelControl lblCtlTo;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.LabelControl lblCtlFrom;
    }
}