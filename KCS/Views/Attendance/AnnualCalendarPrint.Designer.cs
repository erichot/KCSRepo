namespace KCS.Views
{
    partial class AnnualCalendarPrint
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblSelectMonth = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.monthEditEnd = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.lblCtlEnd = new DevExpress.XtraEditors.LabelControl();
            this.monthEditStart = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.lblCtlFrom = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditSelectYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblCtlSelectYear = new DevExpress.XtraEditors.LabelControl();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSelectYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblSelectMonth);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.monthEditEnd);
            this.panelControl1.Controls.Add(this.lblCtlEnd);
            this.panelControl1.Controls.Add(this.monthEditStart);
            this.panelControl1.Controls.Add(this.lblCtlFrom);
            this.panelControl1.Controls.Add(this.comboBoxEditSelectYear);
            this.panelControl1.Controls.Add(this.lblCtlSelectYear);
            this.panelControl1.Location = new System.Drawing.Point(50, 46);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(521, 195);
            this.panelControl1.TabIndex = 3;
            // 
            // lblSelectMonth
            // 
            this.lblSelectMonth.Location = new System.Drawing.Point(51, 121);
            this.lblSelectMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblSelectMonth.Name = "lblSelectMonth";
            this.lblSelectMonth.Size = new System.Drawing.Size(50, 22);
            this.lblSelectMonth.TabIndex = 7;
            this.lblSelectMonth.Text = "Month";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(294, 121);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(13, 22);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "~";
            // 
            // monthEditEnd
            // 
            this.monthEditEnd.EditValue = 1;
            this.monthEditEnd.Location = new System.Drawing.Point(313, 116);
            this.monthEditEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.monthEditEnd.Name = "monthEditEnd";
            this.monthEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.monthEditEnd.Size = new System.Drawing.Size(111, 28);
            this.monthEditEnd.TabIndex = 5;
            // 
            // lblCtlEnd
            // 
            this.lblCtlEnd.Location = new System.Drawing.Point(433, 121);
            this.lblCtlEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlEnd.Name = "lblCtlEnd";
            this.lblCtlEnd.Size = new System.Drawing.Size(44, 22);
            this.lblCtlEnd.TabIndex = 4;
            this.lblCtlEnd.Text = "(End)";
            // 
            // monthEditStart
            // 
            this.monthEditStart.EditValue = 1;
            this.monthEditStart.Location = new System.Drawing.Point(110, 116);
            this.monthEditStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.monthEditStart.Name = "monthEditStart";
            this.monthEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.monthEditStart.Size = new System.Drawing.Size(116, 28);
            this.monthEditStart.TabIndex = 3;
            // 
            // lblCtlFrom
            // 
            this.lblCtlFrom.Location = new System.Drawing.Point(234, 121);
            this.lblCtlFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlFrom.Name = "lblCtlFrom";
            this.lblCtlFrom.Size = new System.Drawing.Size(54, 22);
            this.lblCtlFrom.TabIndex = 2;
            this.lblCtlFrom.Text = "(From)";
            // 
            // comboBoxEditSelectYear
            // 
            this.comboBoxEditSelectYear.Location = new System.Drawing.Point(110, 38);
            this.comboBoxEditSelectYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxEditSelectYear.Name = "comboBoxEditSelectYear";
            this.comboBoxEditSelectYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSelectYear.Properties.DisplayFormat.FormatString = "d";
            this.comboBoxEditSelectYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.comboBoxEditSelectYear.Properties.EditFormat.FormatString = "d";
            this.comboBoxEditSelectYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.comboBoxEditSelectYear.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSelectYear.Size = new System.Drawing.Size(367, 28);
            this.comboBoxEditSelectYear.TabIndex = 1;
            // 
            // lblCtlSelectYear
            // 
            this.lblCtlSelectYear.Location = new System.Drawing.Point(66, 42);
            this.lblCtlSelectYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlSelectYear.Name = "lblCtlSelectYear";
            this.lblCtlSelectYear.Size = new System.Drawing.Size(34, 22);
            this.lblCtlSelectYear.TabIndex = 0;
            this.lblCtlSelectYear.Text = "Year";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.AnnualCalendarPrintViewModel);
            // 
            // AnnualCalendarPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AnnualCalendarPrint";
            this.Size = new System.Drawing.Size(610, 281);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSelectYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSelectYear;
        private DevExpress.XtraEditors.LabelControl lblCtlSelectYear;
        private DevExpress.XtraEditors.LabelControl lblCtlFrom;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraScheduler.UI.MonthEdit monthEditEnd;
        private DevExpress.XtraEditors.LabelControl lblCtlEnd;
        private DevExpress.XtraScheduler.UI.MonthEdit monthEditStart;
        private DevExpress.XtraEditors.LabelControl lblSelectMonth;
    }
}
