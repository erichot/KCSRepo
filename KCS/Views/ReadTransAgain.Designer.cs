namespace KCS.Views
{
    partial class ReadTransAgain
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
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
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
            this.groupControlDevice = new DevExpress.XtraEditors.GroupControl();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSlaveSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDevice)).BeginInit();
            this.groupControlDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.ReadTransAgainViewModel);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.groupControl2);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(786, 214);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.timeEditEnd);
            this.groupControl2.Controls.Add(this.lblCtlEndTime);
            this.groupControl2.Controls.Add(this.lblCtlEndDate);
            this.groupControl2.Controls.Add(this.dateEditEnd);
            this.groupControl2.Location = new System.Drawing.Point(402, 9);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(373, 187);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "To";
            // 
            // timeEditEnd
            // 
            this.timeEditEnd.EditValue = new System.DateTime(2017, 7, 27, 0, 0, 0, 0);
            this.timeEditEnd.Location = new System.Drawing.Point(109, 112);
            this.timeEditEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timeEditEnd.Name = "timeEditEnd";
            this.timeEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditEnd.Properties.DisplayFormat.FormatString = "t";
            this.timeEditEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEnd.Properties.EditFormat.FormatString = "t";
            this.timeEditEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditEnd.Properties.Mask.EditMask = "t";
            this.timeEditEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.timeEditEnd.Size = new System.Drawing.Size(221, 24);
            this.timeEditEnd.TabIndex = 4;
            // 
            // lblCtlEndTime
            // 
            this.lblCtlEndTime.Location = new System.Drawing.Point(14, 115);
            this.lblCtlEndTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCtlEndTime.Name = "lblCtlEndTime";
            this.lblCtlEndTime.Size = new System.Drawing.Size(57, 18);
            this.lblCtlEndTime.TabIndex = 5;
            this.lblCtlEndTime.Text = "EndTime";
            // 
            // lblCtlEndDate
            // 
            this.lblCtlEndDate.Location = new System.Drawing.Point(14, 65);
            this.lblCtlEndDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCtlEndDate.Name = "lblCtlEndDate";
            this.lblCtlEndDate.Size = new System.Drawing.Size(60, 18);
            this.lblCtlEndDate.TabIndex = 3;
            this.lblCtlEndDate.Text = "End Date";
            // 
            // dateEditEnd
            // 
            this.dateEditEnd.EditValue = null;
            this.dateEditEnd.Location = new System.Drawing.Point(107, 61);
            this.dateEditEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditEnd.Name = "dateEditEnd";
            this.dateEditEnd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditEnd.Size = new System.Drawing.Size(222, 24);
            this.dateEditEnd.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblCtlStartTime);
            this.groupControl1.Controls.Add(this.timeEditStart);
            this.groupControl1.Controls.Add(this.lblCtlStartDate);
            this.groupControl1.Controls.Add(this.dateEditStart);
            this.groupControl1.Location = new System.Drawing.Point(9, 9);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(373, 187);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "From";
            // 
            // lblCtlStartTime
            // 
            this.lblCtlStartTime.Location = new System.Drawing.Point(18, 115);
            this.lblCtlStartTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCtlStartTime.Name = "lblCtlStartTime";
            this.lblCtlStartTime.Size = new System.Drawing.Size(69, 18);
            this.lblCtlStartTime.TabIndex = 3;
            this.lblCtlStartTime.Text = "Start Time";
            // 
            // timeEditStart
            // 
            this.timeEditStart.EditValue = new System.DateTime(2017, 7, 27, 0, 0, 0, 0);
            this.timeEditStart.Location = new System.Drawing.Point(112, 112);
            this.timeEditStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.timeEditStart.Name = "timeEditStart";
            this.timeEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEditStart.Properties.DisplayFormat.FormatString = "t";
            this.timeEditStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditStart.Properties.EditFormat.FormatString = "t";
            this.timeEditStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.timeEditStart.Properties.Mask.EditMask = "t";
            this.timeEditStart.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.timeEditStart.Size = new System.Drawing.Size(221, 24);
            this.timeEditStart.TabIndex = 2;
            // 
            // lblCtlStartDate
            // 
            this.lblCtlStartDate.Location = new System.Drawing.Point(18, 70);
            this.lblCtlStartDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCtlStartDate.Name = "lblCtlStartDate";
            this.lblCtlStartDate.Size = new System.Drawing.Size(67, 18);
            this.lblCtlStartDate.TabIndex = 1;
            this.lblCtlStartDate.Text = "Start Date";
            // 
            // dateEditStart
            // 
            this.dateEditStart.EditValue = null;
            this.dateEditStart.Location = new System.Drawing.Point(112, 65);
            this.dateEditStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateEditStart.Name = "dateEditStart";
            this.dateEditStart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditStart.Size = new System.Drawing.Size(222, 24);
            this.dateEditStart.TabIndex = 0;
            // 
            // groupControlDevice
            // 
            this.groupControlDevice.Controls.Add(this.gridControl);
            this.groupControlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlDevice.Location = new System.Drawing.Point(0, 214);
            this.groupControlDevice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControlDevice.Name = "groupControlDevice";
            this.groupControlDevice.Size = new System.Drawing.Size(786, 378);
            this.groupControlDevice.TabIndex = 1;
            this.groupControlDevice.Text = "Selected devices";
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Location = new System.Drawing.Point(2, 56);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(782, 320);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.DeviceInfo);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSlaveSID,
            this.colIP,
            this.colSlaveName,
            this.colSlaveDescription});
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView.OptionsCustomization.AllowFilter = false;
            this.gridView.OptionsFind.FindNullPrompt = "";
            this.gridView.OptionsFind.ShowClearButton = false;
            this.gridView.OptionsFind.ShowFindButton = false;
            this.gridView.OptionsMenu.EnableColumnMenu = false;
            this.gridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colSlaveSID
            // 
            this.colSlaveSID.FieldName = "SlaveSID";
            this.colSlaveSID.Name = "colSlaveSID";
            this.colSlaveSID.Visible = true;
            this.colSlaveSID.VisibleIndex = 1;
            // 
            // colIP
            // 
            this.colIP.FieldName = "IP";
            this.colIP.Name = "colIP";
            this.colIP.Visible = true;
            this.colIP.VisibleIndex = 2;
            // 
            // colSlaveName
            // 
            this.colSlaveName.FieldName = "SlaveName";
            this.colSlaveName.Name = "colSlaveName";
            this.colSlaveName.Visible = true;
            this.colSlaveName.VisibleIndex = 3;
            // 
            // colSlaveDescription
            // 
            this.colSlaveDescription.FieldName = "SlaveDescription";
            this.colSlaveDescription.Name = "colSlaveDescription";
            this.colSlaveDescription.Visible = true;
            this.colSlaveDescription.VisibleIndex = 4;
            // 
            // ReadTransAgain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControlDevice);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ReadTransAgain";
            this.Size = new System.Drawing.Size(786, 592);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControlDevice)).EndInit();
            this.groupControlDevice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControlDevice;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveSID;
        private DevExpress.XtraGrid.Columns.GridColumn colIP;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveName;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveDescription;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.LabelControl lblCtlEndDate;
        private DevExpress.XtraEditors.DateEdit dateEditEnd;
        private DevExpress.XtraEditors.LabelControl lblCtlStartDate;
        private DevExpress.XtraEditors.DateEdit dateEditStart;
        private DevExpress.XtraEditors.LabelControl lblCtlEndTime;
        private DevExpress.XtraEditors.LabelControl lblCtlStartTime;
        private DevExpress.XtraEditors.TimeEdit timeEditStart;
        private DevExpress.XtraEditors.TimeEdit timeEditEnd;
    }
}
