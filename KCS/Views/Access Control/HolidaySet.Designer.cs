namespace KCS.Views
{
    partial class HolidaySet
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
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dateNavigator = new DevExpress.XtraScheduler.DateNavigator();
            this.schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblCtlType8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlType7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlType6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlType5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlType4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlType3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlType2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlType1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.dateNavigator);
            this.panelControl1.Controls.Add(this.schedulerControl);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1514, 814);
            this.panelControl1.TabIndex = 4;
            // 
            // dateNavigator
            // 
            this.dateNavigator.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.dateNavigator.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
            this.dateNavigator.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator.CellPadding = new System.Windows.Forms.Padding(2);
            this.dateNavigator.ColumnCount = 1;
            this.dateNavigator.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateNavigator.Dock = System.Windows.Forms.DockStyle.Left;
            this.dateNavigator.FirstDayOfWeek = System.DayOfWeek.Sunday;
            this.dateNavigator.Location = new System.Drawing.Point(3, 3);
            this.dateNavigator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateNavigator.Name = "dateNavigator";
            this.dateNavigator.Padding = new System.Windows.Forms.Padding(0);
            this.dateNavigator.RowCount = 2;
            this.dateNavigator.SchedulerControl = this.schedulerControl;
            this.dateNavigator.SelectionMode = DevExpress.XtraEditors.Repository.CalendarSelectionMode.Single;
            this.dateNavigator.Size = new System.Drawing.Size(426, 808);
            this.dateNavigator.TabIndex = 1;
            // 
            // schedulerControl
            // 
            this.schedulerControl.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schedulerControl.DataStorage = this.schedulerStorage;
            this.schedulerControl.Location = new System.Drawing.Point(438, 2);
            this.schedulerControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.schedulerControl.Name = "schedulerControl";
            this.schedulerControl.OptionsBehavior.SelectOnRightClick = true;
            this.schedulerControl.OptionsCustomization.AllowAppointmentCopy = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl.OptionsCustomization.AllowAppointmentMultiSelect = false;
            this.schedulerControl.Size = new System.Drawing.Size(1058, 808);
            this.schedulerControl.Start = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.schedulerControl.TabIndex = 0;
            this.schedulerControl.Views.AgendaView.Enabled = false;
            this.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl.Views.GanttView.Enabled = false;
            this.schedulerControl.Views.MonthView.NavigationButtonVisibility = DevExpress.XtraScheduler.NavigationButtonVisibility.Never;
            this.schedulerControl.Views.TimelineView.Enabled = false;
            this.schedulerControl.Views.WorkWeekView.Enabled = false;
            this.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schedulerControl.CustomDrawDayHeader += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl_CustomDrawDayHeader);
            this.schedulerControl.DoubleClick += new System.EventHandler(this.schedulerControl_DoubleClick);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblCtlType8);
            this.panelControl2.Controls.Add(this.labelControl16);
            this.panelControl2.Controls.Add(this.lblCtlType7);
            this.panelControl2.Controls.Add(this.labelControl14);
            this.panelControl2.Controls.Add(this.lblCtlType6);
            this.panelControl2.Controls.Add(this.labelControl12);
            this.panelControl2.Controls.Add(this.lblCtlType5);
            this.panelControl2.Controls.Add(this.labelControl10);
            this.panelControl2.Controls.Add(this.lblCtlType4);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.lblCtlType3);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.lblCtlType2);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.lblCtlType1);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(1523, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(291, 814);
            this.panelControl2.TabIndex = 5;
            // 
            // lblCtlType8
            // 
            this.lblCtlType8.Location = new System.Drawing.Point(160, 566);
            this.lblCtlType8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlType8.Name = "lblCtlType8";
            this.lblCtlType8.Size = new System.Drawing.Size(55, 22);
            this.lblCtlType8.TabIndex = 15;
            this.lblCtlType8.Text = "Type 8";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.BackColor = System.Drawing.Color.Indigo;
            this.labelControl16.Appearance.Options.UseBackColor = true;
            this.labelControl16.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl16.Location = new System.Drawing.Point(72, 563);
            this.labelControl16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(79, 24);
            this.labelControl16.TabIndex = 14;
            // 
            // lblCtlType7
            // 
            this.lblCtlType7.Location = new System.Drawing.Point(160, 500);
            this.lblCtlType7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlType7.Name = "lblCtlType7";
            this.lblCtlType7.Size = new System.Drawing.Size(55, 22);
            this.lblCtlType7.TabIndex = 13;
            this.lblCtlType7.Text = "Type 7";
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.BackColor = System.Drawing.Color.MidnightBlue;
            this.labelControl14.Appearance.Options.UseBackColor = true;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.Location = new System.Drawing.Point(72, 497);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(79, 24);
            this.labelControl14.TabIndex = 12;
            // 
            // lblCtlType6
            // 
            this.lblCtlType6.Location = new System.Drawing.Point(160, 434);
            this.lblCtlType6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlType6.Name = "lblCtlType6";
            this.lblCtlType6.Size = new System.Drawing.Size(55, 22);
            this.lblCtlType6.TabIndex = 11;
            this.lblCtlType6.Text = "Type 6";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.BackColor = System.Drawing.Color.Aqua;
            this.labelControl12.Appearance.Options.UseBackColor = true;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.Location = new System.Drawing.Point(72, 431);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(79, 24);
            this.labelControl12.TabIndex = 10;
            // 
            // lblCtlType5
            // 
            this.lblCtlType5.Location = new System.Drawing.Point(160, 374);
            this.lblCtlType5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlType5.Name = "lblCtlType5";
            this.lblCtlType5.Size = new System.Drawing.Size(55, 22);
            this.lblCtlType5.TabIndex = 9;
            this.lblCtlType5.Text = "Type 5";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.BackColor = System.Drawing.Color.DarkGreen;
            this.labelControl10.Appearance.Options.UseBackColor = true;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.Location = new System.Drawing.Point(72, 372);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(79, 24);
            this.labelControl10.TabIndex = 8;
            // 
            // lblCtlType4
            // 
            this.lblCtlType4.Location = new System.Drawing.Point(160, 310);
            this.lblCtlType4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlType4.Name = "lblCtlType4";
            this.lblCtlType4.Size = new System.Drawing.Size(55, 22);
            this.lblCtlType4.TabIndex = 7;
            this.lblCtlType4.Text = "Type 4";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.BackColor = System.Drawing.Color.YellowGreen;
            this.labelControl8.Appearance.Options.UseBackColor = true;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(72, 310);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(79, 24);
            this.labelControl8.TabIndex = 6;
            // 
            // lblCtlType3
            // 
            this.lblCtlType3.Location = new System.Drawing.Point(160, 251);
            this.lblCtlType3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlType3.Name = "lblCtlType3";
            this.lblCtlType3.Size = new System.Drawing.Size(55, 22);
            this.lblCtlType3.TabIndex = 5;
            this.lblCtlType3.Text = "Type 3";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.BackColor = System.Drawing.Color.Chartreuse;
            this.labelControl6.Appearance.Options.UseBackColor = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(72, 251);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(79, 24);
            this.labelControl6.TabIndex = 4;
            // 
            // lblCtlType2
            // 
            this.lblCtlType2.Location = new System.Drawing.Point(160, 196);
            this.lblCtlType2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlType2.Name = "lblCtlType2";
            this.lblCtlType2.Size = new System.Drawing.Size(55, 22);
            this.lblCtlType2.TabIndex = 3;
            this.lblCtlType2.Text = "Type 2";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.OrangeRed;
            this.labelControl4.Appearance.Options.UseBackColor = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(72, 193);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(79, 24);
            this.labelControl4.TabIndex = 2;
            // 
            // lblCtlType1
            // 
            this.lblCtlType1.Location = new System.Drawing.Point(160, 138);
            this.lblCtlType1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlType1.Name = "lblCtlType1";
            this.lblCtlType1.Size = new System.Drawing.Size(55, 22);
            this.lblCtlType1.TabIndex = 1;
            this.lblCtlType1.Text = "Type 1";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.LightCoral;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(72, 137);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 24);
            this.labelControl1.TabIndex = 0;
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.HolidaySetViewModel);
            // 
            // HolidaySet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HolidaySet";
            this.Size = new System.Drawing.Size(1814, 814);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblCtlType1;
        private DevExpress.XtraEditors.LabelControl lblCtlType8;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl lblCtlType7;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl lblCtlType6;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl lblCtlType5;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl lblCtlType4;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl lblCtlType3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblCtlType2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator;
    }
}
