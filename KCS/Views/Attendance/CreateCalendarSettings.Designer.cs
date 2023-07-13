namespace KCS.Views
{
    partial class CreateCalendarSettings
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
            this.lblCtlHolidayOrNot = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupHolidayOrNot = new DevExpress.XtraEditors.RadioGroup();
            this.lblCtlHolidayType = new DevExpress.XtraEditors.LabelControl();
            this.radioGroupHolidayType = new DevExpress.XtraEditors.RadioGroup();
            this.comboBoxEditSelectYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblCtlSelectYear = new DevExpress.XtraEditors.LabelControl();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupHolidayOrNot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupHolidayType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSelectYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCtlHolidayOrNot
            // 
            this.lblCtlHolidayOrNot.Location = new System.Drawing.Point(65, 87);
            this.lblCtlHolidayOrNot.Name = "lblCtlHolidayOrNot";
            this.lblCtlHolidayOrNot.Size = new System.Drawing.Size(69, 14);
            this.lblCtlHolidayOrNot.TabIndex = 0;
            this.lblCtlHolidayOrNot.Text = "Hliday or not";
            // 
            // radioGroupHolidayOrNot
            // 
            this.radioGroupHolidayOrNot.Location = new System.Drawing.Point(165, 81);
            this.radioGroupHolidayOrNot.Name = "radioGroupHolidayOrNot";
            this.radioGroupHolidayOrNot.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupHolidayOrNot.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupHolidayOrNot.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupHolidayOrNot.Size = new System.Drawing.Size(180, 30);
            this.radioGroupHolidayOrNot.TabIndex = 1;
            // 
            // lblCtlHolidayType
            // 
            this.lblCtlHolidayType.Location = new System.Drawing.Point(65, 122);
            this.lblCtlHolidayType.Name = "lblCtlHolidayType";
            this.lblCtlHolidayType.Size = new System.Drawing.Size(63, 14);
            this.lblCtlHolidayType.TabIndex = 2;
            this.lblCtlHolidayType.Text = "Hliday Type";
            // 
            // radioGroupHolidayType
            // 
            this.radioGroupHolidayType.Location = new System.Drawing.Point(165, 113);
            this.radioGroupHolidayType.Name = "radioGroupHolidayType";
            this.radioGroupHolidayType.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.radioGroupHolidayType.Properties.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.radioGroupHolidayType.Properties.Appearance.Options.UseBackColor = true;
            this.radioGroupHolidayType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroupHolidayType.Size = new System.Drawing.Size(180, 62);
            this.radioGroupHolidayType.TabIndex = 3;
            // 
            // comboBoxEditSelectYear
            // 
            this.comboBoxEditSelectYear.Location = new System.Drawing.Point(165, 47);
            this.comboBoxEditSelectYear.Name = "comboBoxEditSelectYear";
            this.comboBoxEditSelectYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSelectYear.Properties.DisplayFormat.FormatString = "d";
            this.comboBoxEditSelectYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.comboBoxEditSelectYear.Properties.EditFormat.FormatString = "d";
            this.comboBoxEditSelectYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.comboBoxEditSelectYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSelectYear.Size = new System.Drawing.Size(180, 20);
            this.comboBoxEditSelectYear.TabIndex = 5;
            // 
            // lblCtlSelectYear
            // 
            this.lblCtlSelectYear.Location = new System.Drawing.Point(65, 50);
            this.lblCtlSelectYear.Name = "lblCtlSelectYear";
            this.lblCtlSelectYear.Size = new System.Drawing.Size(25, 14);
            this.lblCtlSelectYear.TabIndex = 4;
            this.lblCtlSelectYear.Text = "Year";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.CreateCalendarSettingsViewModel);
            // 
            // CreateCalendarSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxEditSelectYear);
            this.Controls.Add(this.lblCtlSelectYear);
            this.Controls.Add(this.radioGroupHolidayType);
            this.Controls.Add(this.lblCtlHolidayType);
            this.Controls.Add(this.radioGroupHolidayOrNot);
            this.Controls.Add(this.lblCtlHolidayOrNot);
            this.Name = "CreateCalendarSettings";
            this.Size = new System.Drawing.Size(411, 222);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupHolidayOrNot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupHolidayType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSelectYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.RadioGroup radioGroupHolidayOrNot;
        private DevExpress.XtraEditors.LabelControl lblCtlHolidayOrNot;
        private DevExpress.XtraEditors.RadioGroup radioGroupHolidayType;
        private DevExpress.XtraEditors.LabelControl lblCtlHolidayType;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSelectYear;
        private DevExpress.XtraEditors.LabelControl lblCtlSelectYear;
    }
}
