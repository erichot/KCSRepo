namespace KCS.Views
{
    partial class ExportDatas
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.timeEditEnd = new DevExpress.XtraEditors.TimeEdit();
            this.lblCtlEndTime = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlEndDate = new DevExpress.XtraEditors.LabelControl();
            this.dateEditEnd = new DevExpress.XtraEditors.DateEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblCtlStartTime = new DevExpress.XtraEditors.LabelControl();
            this.timeEditStart = new DevExpress.XtraEditors.TimeEdit();
            this.lblCtlStartDate = new DevExpress.XtraEditors.LabelControl();
            this.dateEditStart = new DevExpress.XtraEditors.DateEdit();
            this.sbExportDatas = new DevExpress.XtraEditors.SimpleButton();
            this.progressBarControl = new DevExpress.XtraEditors.ProgressBarControl();
            this.checkEditExportAll = new DevExpress.XtraEditors.CheckEdit();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditExportAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.timeEditEnd);
            this.groupControl2.Controls.Add(this.lblCtlEndTime);
            this.groupControl2.Controls.Add(this.lblCtlEndDate);
            this.groupControl2.Controls.Add(this.dateEditEnd);
            this.groupControl2.Location = new System.Drawing.Point(504, 36);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(466, 229);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "To";
            // 
            // timeEditEnd
            // 
            this.timeEditEnd.EditValue = new System.DateTime(2017, 7, 27, 0, 0, 0, 0);
            this.timeEditEnd.Location = new System.Drawing.Point(136, 137);
            this.timeEditEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timeEditEnd.Name = "timeEditEnd";
            this.timeEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditEnd.Properties.DisplayFormat.FormatString = "t";
            this.timeEditEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEnd.Properties.EditFormat.FormatString = "t";
            this.timeEditEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEnd.Properties.Mask.EditMask = "t";
            this.timeEditEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.timeEditEnd.Size = new System.Drawing.Size(276, 28);
            this.timeEditEnd.TabIndex = 4;
            // 
            // lblCtlEndTime
            // 
            this.lblCtlEndTime.Location = new System.Drawing.Point(17, 141);
            this.lblCtlEndTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlEndTime.Name = "lblCtlEndTime";
            this.lblCtlEndTime.Size = new System.Drawing.Size(69, 22);
            this.lblCtlEndTime.TabIndex = 5;
            this.lblCtlEndTime.Text = "EndTime";
            // 
            // lblCtlEndDate
            // 
            this.lblCtlEndDate.Location = new System.Drawing.Point(17, 80);
            this.lblCtlEndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlEndDate.Name = "lblCtlEndDate";
            this.lblCtlEndDate.Size = new System.Drawing.Size(72, 22);
            this.lblCtlEndDate.TabIndex = 3;
            this.lblCtlEndDate.Text = "End Date";
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(134, 75);
            this.dateEditEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Size = new System.Drawing.Size(277, 28);
            this.dateEditEnd.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblCtlStartTime);
            this.groupControl1.Controls.Add(this.timeEditStart);
            this.groupControl1.Controls.Add(this.lblCtlStartDate);
            this.groupControl1.Controls.Add(this.dateEditStart);
            this.groupControl1.Location = new System.Drawing.Point(13, 36);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(466, 229);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "From";
            // 
            // lblCtlStartTime
            // 
            this.lblCtlStartTime.Location = new System.Drawing.Point(23, 141);
            this.lblCtlStartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlStartTime.Name = "lblCtlStartTime";
            this.lblCtlStartTime.Size = new System.Drawing.Size(82, 22);
            this.lblCtlStartTime.TabIndex = 3;
            this.lblCtlStartTime.Text = "Start Time";
            // 
            // timeEditStart
            // 
            this.timeEditStart.EditValue = new System.DateTime(2017, 7, 27, 0, 0, 0, 0);
            this.timeEditStart.Location = new System.Drawing.Point(140, 137);
            this.timeEditStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.timeEditStart.Name = "timeEditStart";
            this.timeEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditStart.Properties.DisplayFormat.FormatString = "t";
            this.timeEditStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditStart.Properties.EditFormat.FormatString = "t";
            this.timeEditStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditStart.Properties.Mask.EditMask = "t";
            this.timeEditStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.timeEditStart.Size = new System.Drawing.Size(276, 28);
            this.timeEditStart.TabIndex = 2;
            // 
            // lblCtlStartDate
            // 
            this.lblCtlStartDate.Location = new System.Drawing.Point(23, 85);
            this.lblCtlStartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlStartDate.Name = "lblCtlStartDate";
            this.lblCtlStartDate.Size = new System.Drawing.Size(79, 22);
            this.lblCtlStartDate.TabIndex = 1;
            this.lblCtlStartDate.Text = "Start Date";
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(140, 80);
            this.dateEditStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Size = new System.Drawing.Size(277, 28);
            this.dateEditStart.TabIndex = 0;
            // 
            // sbExportDatas
            // 
            this.sbExportDatas.Location = new System.Drawing.Point(391, 344);
            this.sbExportDatas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbExportDatas.Name = "sbExportDatas";
            this.sbExportDatas.Size = new System.Drawing.Size(197, 72);
            this.sbExportDatas.TabIndex = 4;
            this.sbExportDatas.Text = "Export datas";
            // 
            // progressBarControl
            // 
            this.progressBarControl.Location = new System.Drawing.Point(13, 432);
            this.progressBarControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBarControl.Name = "progressBarControl";
            this.progressBarControl.Size = new System.Drawing.Size(957, 42);
            this.progressBarControl.TabIndex = 5;
            this.progressBarControl.Visible = false;
            // 
            // checkEditExportAll
            // 
            this.checkEditExportAll.Location = new System.Drawing.Point(377, 292);
            this.checkEditExportAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkEditExportAll.Name = "checkEditExportAll";
            this.checkEditExportAll.Properties.Caption = "Export all datas";
            this.checkEditExportAll.Size = new System.Drawing.Size(281, 26);
            this.checkEditExportAll.TabIndex = 6;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.ExportDatasViewModel);
            // 
            // ExportDatas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkEditExportAll);
            this.Controls.Add(this.progressBarControl);
            this.Controls.Add(this.sbExportDatas);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ExportDatas";
            this.Size = new System.Drawing.Size(987, 508);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditEnd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditExportAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TimeEdit timeEditEnd;
        private DevExpress.XtraEditors.LabelControl lblCtlEndTime;
        private DevExpress.XtraEditors.LabelControl lblCtlEndDate;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl lblCtlStartTime;
        private DevExpress.XtraEditors.TimeEdit timeEditStart;
        private DevExpress.XtraEditors.LabelControl lblCtlStartDate;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.SimpleButton sbExportDatas;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl;
        private DevExpress.XtraEditors.CheckEdit checkEditExportAll;
    }
}
