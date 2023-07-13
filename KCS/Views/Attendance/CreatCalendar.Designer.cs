namespace KCS.Views
{
    partial class CreatCalendar
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
            this.lblCtlSelectYear = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditSelectYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSelectYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCtlSelectYear
            // 
            this.lblCtlSelectYear.Location = new System.Drawing.Point(101, 90);
            this.lblCtlSelectYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlSelectYear.Name = "lblCtlSelectYear";
            this.lblCtlSelectYear.Size = new System.Drawing.Size(34, 22);
            this.lblCtlSelectYear.TabIndex = 0;
            this.lblCtlSelectYear.Text = "Year";
            // 
            // comboBoxEditSelectYear
            // 
            this.comboBoxEditSelectYear.Location = new System.Drawing.Point(161, 83);
            this.comboBoxEditSelectYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxEditSelectYear.Name = "comboBoxEditSelectYear";
            this.comboBoxEditSelectYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSelectYear.Properties.DisplayFormat.FormatString = "d";
            this.comboBoxEditSelectYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.comboBoxEditSelectYear.Properties.EditFormat.FormatString = "d";
            this.comboBoxEditSelectYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.comboBoxEditSelectYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSelectYear.Size = new System.Drawing.Size(274, 28);
            this.comboBoxEditSelectYear.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.comboBoxEditSelectYear);
            this.panelControl1.Controls.Add(this.lblCtlSelectYear);
            this.panelControl1.Location = new System.Drawing.Point(40, 47);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(546, 222);
            this.panelControl1.TabIndex = 2;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.CreatCalendarViewModel);
            // 
            // CreatCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CreatCalendar";
            this.Size = new System.Drawing.Size(631, 324);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSelectYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.LabelControl lblCtlSelectYear;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSelectYear;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
