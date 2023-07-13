namespace KCS.Views
{
    partial class EditWorkShift
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnLoaded = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSave = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ShiftCodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ShiftNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StartTimeHourComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.StartTimeMinuteComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.EndTimeHourComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.EndTimeMinuteComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.DeductBreakMinuteTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.IsDefaultCheckEdit = new DevExpress.XtraEditors.CheckEdit();
            this.TotalTimeStringTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForShiftCode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForShiftName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStartTimeHour = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEndTimeHour = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDeductBreakMinute = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForIsDefault = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStartTimeMinute = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEndTimeMinute = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForByMin = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTotalTimeString = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftCodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeHourComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeMinuteComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndTimeHourComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndTimeMinuteComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeductBreakMinuteTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsDefaultCheckEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalTimeStringTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForShiftCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForShiftName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStartTimeHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEndTimeHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeductBreakMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStartTimeMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEndTimeMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForByMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalTimeString)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.EditWorkShiftViewModel);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveLayout,
            this.bbiResetLayout,
            this.bbiOnLoaded,
            this.bbiClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(471, 120);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            // 
            // bbiSaveLayout
            // 
            this.bbiSaveLayout.Caption = "SaveLayout";
            this.bbiSaveLayout.Id = 5;
            this.bbiSaveLayout.ImageOptions.ImageUri.Uri = "SaveLayout";
            this.bbiSaveLayout.Name = "bbiSaveLayout";
            // 
            // bbiResetLayout
            // 
            this.bbiResetLayout.Caption = "ResetLayout";
            this.bbiResetLayout.Id = 6;
            this.bbiResetLayout.ImageOptions.ImageUri.Uri = "ResetLayout";
            this.bbiResetLayout.Name = "bbiResetLayout";
            // 
            // bbiOnLoaded
            // 
            this.bbiOnLoaded.Caption = "OnLoaded";
            this.bbiOnLoaded.Id = 7;
            this.bbiOnLoaded.ImageOptions.ImageUri.Uri = "OnLoaded";
            this.bbiOnLoaded.Name = "bbiOnLoaded";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 9;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupSave,
            this.ribbonPageGroupClose});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroupSave
            // 
            this.ribbonPageGroupSave.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroupSave.Name = "ribbonPageGroupSave";
            this.ribbonPageGroupSave.ShowCaptionButton = false;
            this.ribbonPageGroupSave.Text = "Save";
            // 
            // ribbonPageGroupClose
            // 
            this.ribbonPageGroupClose.AllowTextClipping = false;
            this.ribbonPageGroupClose.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroupClose.Name = "ribbonPageGroupClose";
            this.ribbonPageGroupClose.ShowCaptionButton = false;
            this.ribbonPageGroupClose.Text = "Close";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.labelControl1);
            this.dataLayoutControl1.Controls.Add(this.ShiftCodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ShiftNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StartTimeHourComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.StartTimeMinuteComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.EndTimeHourComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.EndTimeMinuteComboBoxEdit);
            this.dataLayoutControl1.Controls.Add(this.DeductBreakMinuteTextEdit);
            this.dataLayoutControl1.Controls.Add(this.IsDefaultCheckEdit);
            this.dataLayoutControl1.Controls.Add(this.TotalTimeStringTextEdit);
            this.dataLayoutControl1.DataSource = this.bindingSource;
            this.dataLayoutControl1.Location = new System.Drawing.Point(5, 118);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(462, 230);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(385, 108);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 14);
            this.labelControl1.StyleController = this.dataLayoutControl1;
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "(By minute)";
            // 
            // ShiftCodeTextEdit
            // 
            this.ShiftCodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "ShiftCode", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShiftCodeTextEdit.Location = new System.Drawing.Point(130, 12);
            this.ShiftCodeTextEdit.MenuManager = this.ribbonControl1;
            this.ShiftCodeTextEdit.Name = "ShiftCodeTextEdit";
            this.ShiftCodeTextEdit.Size = new System.Drawing.Size(320, 20);
            this.ShiftCodeTextEdit.StyleController = this.dataLayoutControl1;
            this.ShiftCodeTextEdit.TabIndex = 4;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.WorkShift);
            // 
            // ShiftNameTextEdit
            // 
            this.ShiftNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "ShiftName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ShiftNameTextEdit.Location = new System.Drawing.Point(130, 36);
            this.ShiftNameTextEdit.MenuManager = this.ribbonControl1;
            this.ShiftNameTextEdit.Name = "ShiftNameTextEdit";
            this.ShiftNameTextEdit.Size = new System.Drawing.Size(320, 20);
            this.ShiftNameTextEdit.StyleController = this.dataLayoutControl1;
            this.ShiftNameTextEdit.TabIndex = 5;
            // 
            // StartTimeHourComboBoxEdit
            // 
            this.StartTimeHourComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "StartTimeHour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.StartTimeHourComboBoxEdit.Location = new System.Drawing.Point(130, 60);
            this.StartTimeHourComboBoxEdit.MenuManager = this.ribbonControl1;
            this.StartTimeHourComboBoxEdit.Name = "StartTimeHourComboBoxEdit";
            this.StartTimeHourComboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.StartTimeHourComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.StartTimeHourComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StartTimeHourComboBoxEdit.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.StartTimeHourComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.StartTimeHourComboBoxEdit.Size = new System.Drawing.Size(157, 20);
            this.StartTimeHourComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.StartTimeHourComboBoxEdit.TabIndex = 6;
            // 
            // StartTimeMinuteComboBoxEdit
            // 
            this.StartTimeMinuteComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "StartTimeMinute", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.StartTimeMinuteComboBoxEdit.Location = new System.Drawing.Point(300, 60);
            this.StartTimeMinuteComboBoxEdit.MenuManager = this.ribbonControl1;
            this.StartTimeMinuteComboBoxEdit.Name = "StartTimeMinuteComboBoxEdit";
            this.StartTimeMinuteComboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.StartTimeMinuteComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.StartTimeMinuteComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StartTimeMinuteComboBoxEdit.Properties.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.StartTimeMinuteComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.StartTimeMinuteComboBoxEdit.Size = new System.Drawing.Size(150, 20);
            this.StartTimeMinuteComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.StartTimeMinuteComboBoxEdit.TabIndex = 7;
            // 
            // EndTimeHourComboBoxEdit
            // 
            this.EndTimeHourComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "EndTimeHour", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EndTimeHourComboBoxEdit.Location = new System.Drawing.Point(130, 84);
            this.EndTimeHourComboBoxEdit.MenuManager = this.ribbonControl1;
            this.EndTimeHourComboBoxEdit.Name = "EndTimeHourComboBoxEdit";
            this.EndTimeHourComboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.EndTimeHourComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.EndTimeHourComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EndTimeHourComboBoxEdit.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.EndTimeHourComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.EndTimeHourComboBoxEdit.Size = new System.Drawing.Size(157, 20);
            this.EndTimeHourComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.EndTimeHourComboBoxEdit.TabIndex = 8;
            // 
            // EndTimeMinuteComboBoxEdit
            // 
            this.EndTimeMinuteComboBoxEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "EndTimeMinute", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EndTimeMinuteComboBoxEdit.Location = new System.Drawing.Point(300, 84);
            this.EndTimeMinuteComboBoxEdit.MenuManager = this.ribbonControl1;
            this.EndTimeMinuteComboBoxEdit.Name = "EndTimeMinuteComboBoxEdit";
            this.EndTimeMinuteComboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.EndTimeMinuteComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.EndTimeMinuteComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EndTimeMinuteComboBoxEdit.Properties.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.EndTimeMinuteComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.EndTimeMinuteComboBoxEdit.Size = new System.Drawing.Size(150, 20);
            this.EndTimeMinuteComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.EndTimeMinuteComboBoxEdit.TabIndex = 9;
            // 
            // DeductBreakMinuteTextEdit
            // 
            this.DeductBreakMinuteTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "DeductBreakMinute", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DeductBreakMinuteTextEdit.Location = new System.Drawing.Point(130, 108);
            this.DeductBreakMinuteTextEdit.MenuManager = this.ribbonControl1;
            this.DeductBreakMinuteTextEdit.Name = "DeductBreakMinuteTextEdit";
            this.DeductBreakMinuteTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.DeductBreakMinuteTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.DeductBreakMinuteTextEdit.Properties.Mask.EditMask = "d";
            this.DeductBreakMinuteTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.DeductBreakMinuteTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.DeductBreakMinuteTextEdit.Properties.MaxLength = 3;
            this.DeductBreakMinuteTextEdit.Size = new System.Drawing.Size(251, 20);
            this.DeductBreakMinuteTextEdit.StyleController = this.dataLayoutControl1;
            this.DeductBreakMinuteTextEdit.TabIndex = 10;
            // 
            // IsDefaultCheckEdit
            // 
            this.IsDefaultCheckEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "IsDefault", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.IsDefaultCheckEdit.Location = new System.Drawing.Point(130, 132);
            this.IsDefaultCheckEdit.MenuManager = this.ribbonControl1;
            this.IsDefaultCheckEdit.Name = "IsDefaultCheckEdit";
            this.IsDefaultCheckEdit.Properties.Caption = "";
            this.IsDefaultCheckEdit.Size = new System.Drawing.Size(320, 19);
            this.IsDefaultCheckEdit.StyleController = this.dataLayoutControl1;
            this.IsDefaultCheckEdit.TabIndex = 11;
            // 
            // TotalTimeStringTextEdit
            // 
            this.TotalTimeStringTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "TotalTimeString", true));
            this.TotalTimeStringTextEdit.Location = new System.Drawing.Point(130, 155);
            this.TotalTimeStringTextEdit.MenuManager = this.ribbonControl1;
            this.TotalTimeStringTextEdit.Name = "TotalTimeStringTextEdit";
            this.TotalTimeStringTextEdit.Properties.ReadOnly = true;
            this.TotalTimeStringTextEdit.Size = new System.Drawing.Size(320, 20);
            this.TotalTimeStringTextEdit.StyleController = this.dataLayoutControl1;
            this.TotalTimeStringTextEdit.TabIndex = 13;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(462, 230);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForShiftCode,
            this.ItemForShiftName,
            this.ItemForStartTimeHour,
            this.ItemForEndTimeHour,
            this.ItemForDeductBreakMinute,
            this.ItemForIsDefault,
            this.ItemForStartTimeMinute,
            this.ItemForEndTimeMinute,
            this.ItemForByMin,
            this.ItemForTotalTimeString});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(442, 210);
            // 
            // ItemForShiftCode
            // 
            this.ItemForShiftCode.Control = this.ShiftCodeTextEdit;
            this.ItemForShiftCode.Location = new System.Drawing.Point(0, 0);
            this.ItemForShiftCode.Name = "ItemForShiftCode";
            this.ItemForShiftCode.Size = new System.Drawing.Size(442, 24);
            this.ItemForShiftCode.Text = "Shift Code";
            this.ItemForShiftCode.TextSize = new System.Drawing.Size(115, 14);
            // 
            // ItemForShiftName
            // 
            this.ItemForShiftName.Control = this.ShiftNameTextEdit;
            this.ItemForShiftName.Location = new System.Drawing.Point(0, 24);
            this.ItemForShiftName.Name = "ItemForShiftName";
            this.ItemForShiftName.Size = new System.Drawing.Size(442, 24);
            this.ItemForShiftName.Text = "Shift Name";
            this.ItemForShiftName.TextSize = new System.Drawing.Size(115, 14);
            // 
            // ItemForStartTimeHour
            // 
            this.ItemForStartTimeHour.Control = this.StartTimeHourComboBoxEdit;
            this.ItemForStartTimeHour.Location = new System.Drawing.Point(0, 48);
            this.ItemForStartTimeHour.Name = "ItemForStartTimeHour";
            this.ItemForStartTimeHour.Size = new System.Drawing.Size(279, 24);
            this.ItemForStartTimeHour.Text = "Start Time Hour";
            this.ItemForStartTimeHour.TextSize = new System.Drawing.Size(115, 14);
            // 
            // ItemForEndTimeHour
            // 
            this.ItemForEndTimeHour.Control = this.EndTimeHourComboBoxEdit;
            this.ItemForEndTimeHour.Location = new System.Drawing.Point(0, 72);
            this.ItemForEndTimeHour.Name = "ItemForEndTimeHour";
            this.ItemForEndTimeHour.Size = new System.Drawing.Size(279, 24);
            this.ItemForEndTimeHour.Text = "End Time Hour";
            this.ItemForEndTimeHour.TextSize = new System.Drawing.Size(115, 14);
            // 
            // ItemForDeductBreakMinute
            // 
            this.ItemForDeductBreakMinute.Control = this.DeductBreakMinuteTextEdit;
            this.ItemForDeductBreakMinute.Location = new System.Drawing.Point(0, 96);
            this.ItemForDeductBreakMinute.Name = "ItemForDeductBreakMinute";
            this.ItemForDeductBreakMinute.Size = new System.Drawing.Size(373, 24);
            this.ItemForDeductBreakMinute.Text = "Deduct Break Minute";
            this.ItemForDeductBreakMinute.TextSize = new System.Drawing.Size(115, 14);
            // 
            // ItemForIsDefault
            // 
            this.ItemForIsDefault.Control = this.IsDefaultCheckEdit;
            this.ItemForIsDefault.Location = new System.Drawing.Point(0, 120);
            this.ItemForIsDefault.Name = "ItemForIsDefault";
            this.ItemForIsDefault.Size = new System.Drawing.Size(442, 23);
            this.ItemForIsDefault.Text = "Is Default";
            this.ItemForIsDefault.TextSize = new System.Drawing.Size(115, 14);
            // 
            // ItemForStartTimeMinute
            // 
            this.ItemForStartTimeMinute.Control = this.StartTimeMinuteComboBoxEdit;
            this.ItemForStartTimeMinute.Location = new System.Drawing.Point(279, 48);
            this.ItemForStartTimeMinute.Name = "ItemForStartTimeMinute";
            this.ItemForStartTimeMinute.Size = new System.Drawing.Size(163, 24);
            this.ItemForStartTimeMinute.Text = ":";
            this.ItemForStartTimeMinute.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForStartTimeMinute.TextSize = new System.Drawing.Size(4, 14);
            this.ItemForStartTimeMinute.TextToControlDistance = 5;
            // 
            // ItemForEndTimeMinute
            // 
            this.ItemForEndTimeMinute.Control = this.EndTimeMinuteComboBoxEdit;
            this.ItemForEndTimeMinute.Location = new System.Drawing.Point(279, 72);
            this.ItemForEndTimeMinute.Name = "ItemForEndTimeMinute";
            this.ItemForEndTimeMinute.Size = new System.Drawing.Size(163, 24);
            this.ItemForEndTimeMinute.Text = ":";
            this.ItemForEndTimeMinute.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.ItemForEndTimeMinute.TextLocation = DevExpress.Utils.Locations.Left;
            this.ItemForEndTimeMinute.TextSize = new System.Drawing.Size(4, 14);
            this.ItemForEndTimeMinute.TextToControlDistance = 5;
            // 
            // ItemForByMin
            // 
            this.ItemForByMin.Control = this.labelControl1;
            this.ItemForByMin.Location = new System.Drawing.Point(373, 96);
            this.ItemForByMin.Name = "ItemForByMin";
            this.ItemForByMin.Size = new System.Drawing.Size(69, 24);
            this.ItemForByMin.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForByMin.TextVisible = false;
            // 
            // ItemForTotalTimeString
            // 
            this.ItemForTotalTimeString.Control = this.TotalTimeStringTextEdit;
            this.ItemForTotalTimeString.Location = new System.Drawing.Point(0, 143);
            this.ItemForTotalTimeString.Name = "ItemForTotalTimeString";
            this.ItemForTotalTimeString.Size = new System.Drawing.Size(442, 67);
            this.ItemForTotalTimeString.Text = "Total Time String";
            this.ItemForTotalTimeString.TextSize = new System.Drawing.Size(115, 14);
            // 
            // EditWorkShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "EditWorkShift";
            this.Size = new System.Drawing.Size(471, 355);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ShiftCodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShiftNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeHourComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartTimeMinuteComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndTimeHourComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndTimeMinuteComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeductBreakMinuteTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsDefaultCheckEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalTimeStringTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForShiftCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForShiftName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStartTimeHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEndTimeHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDeductBreakMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForIsDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStartTimeMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEndTimeMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForByMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTotalTimeString)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private DevExpress.XtraBars.BarButtonItem bbiOnLoaded;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupClose;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit ShiftCodeTextEdit;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.TextEdit ShiftNameTextEdit;
        private DevExpress.XtraEditors.ComboBoxEdit StartTimeHourComboBoxEdit;
        private DevExpress.XtraEditors.ComboBoxEdit StartTimeMinuteComboBoxEdit;
        private DevExpress.XtraEditors.ComboBoxEdit EndTimeHourComboBoxEdit;
        private DevExpress.XtraEditors.ComboBoxEdit EndTimeMinuteComboBoxEdit;
        private DevExpress.XtraEditors.TextEdit DeductBreakMinuteTextEdit;
        private DevExpress.XtraEditors.CheckEdit IsDefaultCheckEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForShiftCode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForShiftName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStartTimeHour;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEndTimeHour;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDeductBreakMinute;
        private DevExpress.XtraLayout.LayoutControlItem ItemForIsDefault;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStartTimeMinute;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEndTimeMinute;
        private DevExpress.XtraLayout.LayoutControlItem ItemForByMin;
        private DevExpress.XtraEditors.TextEdit TotalTimeStringTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTotalTimeString;
    }
}
