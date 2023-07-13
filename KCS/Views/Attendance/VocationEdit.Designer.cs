namespace KCS.Views
{
    partial class VocationEdit
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
            this.lblCtlSelEmployee = new DevExpress.XtraEditors.LabelControl();
            this.textEditEmployeeMsg = new DevExpress.XtraEditors.TextEdit();
            this.textEditLeave3Hour = new DevExpress.XtraEditors.TextEdit();
            this.textEditLeave2Hour = new DevExpress.XtraEditors.TextEdit();
            this.textEditLeave1Hour = new DevExpress.XtraEditors.TextEdit();
            this.memoEditReason = new DevExpress.XtraEditors.MemoEdit();
            this.lblCtlReason = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditVocation3 = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourceLeaveType = new System.Windows.Forms.BindingSource(this.components);
            this.lblCtlVocation3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditVocation2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCtlVocation2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEditVocation1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lblCtlVocation1 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlDate = new DevExpress.XtraEditors.LabelControl();
            this.dateEditSel = new DevExpress.XtraEditors.DateEdit();
            this.lblCtlHour3 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlHour2 = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlHour1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmployeeMsg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLeave3Hour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLeave2Hour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLeave1Hour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVocation3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLeaveType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVocation2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVocation1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSel.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSel.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.VocationEditViewModel);
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
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1006, 184);
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
            // lblCtlSelEmployee
            // 
            this.lblCtlSelEmployee.Location = new System.Drawing.Point(261, 244);
            this.lblCtlSelEmployee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlSelEmployee.Name = "lblCtlSelEmployee";
            this.lblCtlSelEmployee.Size = new System.Drawing.Size(147, 22);
            this.lblCtlSelEmployee.TabIndex = 33;
            this.lblCtlSelEmployee.Text = "Selected Employee";
            // 
            // textEditEmployeeMsg
            // 
            this.textEditEmployeeMsg.Location = new System.Drawing.Point(437, 236);
            this.textEditEmployeeMsg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEditEmployeeMsg.MenuManager = this.ribbonControl1;
            this.textEditEmployeeMsg.Name = "textEditEmployeeMsg";
            this.textEditEmployeeMsg.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEditEmployeeMsg.Properties.Appearance.Options.UseFont = true;
            this.textEditEmployeeMsg.Properties.Mask.EditMask = "n0";
            this.textEditEmployeeMsg.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditEmployeeMsg.Properties.ReadOnly = true;
            this.textEditEmployeeMsg.Size = new System.Drawing.Size(277, 32);
            this.textEditEmployeeMsg.TabIndex = 32;
            // 
            // textEditLeave3Hour
            // 
            this.textEditLeave3Hour.Location = new System.Drawing.Point(724, 401);
            this.textEditLeave3Hour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEditLeave3Hour.MenuManager = this.ribbonControl1;
            this.textEditLeave3Hour.Name = "textEditLeave3Hour";
            this.textEditLeave3Hour.Properties.Mask.EditMask = "n0";
            this.textEditLeave3Hour.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditLeave3Hour.Size = new System.Drawing.Size(120, 28);
            this.textEditLeave3Hour.TabIndex = 31;
            // 
            // textEditLeave2Hour
            // 
            this.textEditLeave2Hour.Location = new System.Drawing.Point(724, 357);
            this.textEditLeave2Hour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEditLeave2Hour.MenuManager = this.ribbonControl1;
            this.textEditLeave2Hour.Name = "textEditLeave2Hour";
            this.textEditLeave2Hour.Properties.Mask.EditMask = "n0";
            this.textEditLeave2Hour.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditLeave2Hour.Size = new System.Drawing.Size(120, 28);
            this.textEditLeave2Hour.TabIndex = 30;
            // 
            // textEditLeave1Hour
            // 
            this.textEditLeave1Hour.Location = new System.Drawing.Point(724, 314);
            this.textEditLeave1Hour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEditLeave1Hour.MenuManager = this.ribbonControl1;
            this.textEditLeave1Hour.Name = "textEditLeave1Hour";
            this.textEditLeave1Hour.Properties.Mask.EditMask = "n0";
            this.textEditLeave1Hour.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditLeave1Hour.Size = new System.Drawing.Size(120, 28);
            this.textEditLeave1Hour.TabIndex = 29;
            // 
            // memoEditReason
            // 
            this.memoEditReason.Location = new System.Drawing.Point(107, 360);
            this.memoEditReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.memoEditReason.MenuManager = this.ribbonControl1;
            this.memoEditReason.Name = "memoEditReason";
            this.memoEditReason.Size = new System.Drawing.Size(269, 79);
            this.memoEditReason.TabIndex = 28;
            // 
            // lblCtlReason
            // 
            this.lblCtlReason.Location = new System.Drawing.Point(33, 382);
            this.lblCtlReason.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlReason.Name = "lblCtlReason";
            this.lblCtlReason.Size = new System.Drawing.Size(57, 22);
            this.lblCtlReason.TabIndex = 27;
            this.lblCtlReason.Text = "Reason";
            // 
            // lookUpEditVocation3
            // 
            this.lookUpEditVocation3.Location = new System.Drawing.Point(521, 399);
            this.lookUpEditVocation3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditVocation3.MenuManager = this.ribbonControl1;
            this.lookUpEditVocation3.Name = "lookUpEditVocation3";
            this.lookUpEditVocation3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditVocation3.Properties.DataSource = this.bindingSourceLeaveType;
            this.lookUpEditVocation3.Properties.DisplayMember = "LeaveTypeName";
            this.lookUpEditVocation3.Properties.ShowHeader = false;
            this.lookUpEditVocation3.Properties.ValueMember = "LeaveTypeID";
            this.lookUpEditVocation3.Size = new System.Drawing.Size(194, 28);
            this.lookUpEditVocation3.TabIndex = 26;
            // 
            // bindingSourceLeaveType
            // 
            this.bindingSourceLeaveType.DataSource = typeof(KCS.Models.TaLeaveType);
            // 
            // lblCtlVocation3
            // 
            this.lblCtlVocation3.Location = new System.Drawing.Point(419, 404);
            this.lblCtlVocation3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlVocation3.Name = "lblCtlVocation3";
            this.lblCtlVocation3.Size = new System.Drawing.Size(61, 22);
            this.lblCtlVocation3.TabIndex = 25;
            this.lblCtlVocation3.Text = "Leave 3";
            // 
            // lookUpEditVocation2
            // 
            this.lookUpEditVocation2.Location = new System.Drawing.Point(521, 357);
            this.lookUpEditVocation2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditVocation2.MenuManager = this.ribbonControl1;
            this.lookUpEditVocation2.Name = "lookUpEditVocation2";
            this.lookUpEditVocation2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditVocation2.Properties.DataSource = this.bindingSourceLeaveType;
            this.lookUpEditVocation2.Properties.DisplayMember = "LeaveTypeName";
            this.lookUpEditVocation2.Properties.ShowHeader = false;
            this.lookUpEditVocation2.Properties.ValueMember = "LeaveTypeID";
            this.lookUpEditVocation2.Size = new System.Drawing.Size(194, 28);
            this.lookUpEditVocation2.TabIndex = 24;
            // 
            // lblCtlVocation2
            // 
            this.lblCtlVocation2.Location = new System.Drawing.Point(419, 363);
            this.lblCtlVocation2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlVocation2.Name = "lblCtlVocation2";
            this.lblCtlVocation2.Size = new System.Drawing.Size(61, 22);
            this.lblCtlVocation2.TabIndex = 23;
            this.lblCtlVocation2.Text = "Leave 2";
            // 
            // lookUpEditVocation1
            // 
            this.lookUpEditVocation1.Location = new System.Drawing.Point(521, 314);
            this.lookUpEditVocation1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lookUpEditVocation1.MenuManager = this.ribbonControl1;
            this.lookUpEditVocation1.Name = "lookUpEditVocation1";
            this.lookUpEditVocation1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEditVocation1.Properties.DataSource = this.bindingSourceLeaveType;
            this.lookUpEditVocation1.Properties.DisplayMember = "LeaveTypeName";
            this.lookUpEditVocation1.Properties.ShowHeader = false;
            this.lookUpEditVocation1.Properties.ValueMember = "LeaveTypeID";
            this.lookUpEditVocation1.Size = new System.Drawing.Size(194, 28);
            this.lookUpEditVocation1.TabIndex = 22;
            // 
            // lblCtlVocation1
            // 
            this.lblCtlVocation1.Location = new System.Drawing.Point(419, 321);
            this.lblCtlVocation1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlVocation1.Name = "lblCtlVocation1";
            this.lblCtlVocation1.Size = new System.Drawing.Size(61, 22);
            this.lblCtlVocation1.TabIndex = 21;
            this.lblCtlVocation1.Text = "Leave 1";
            // 
            // lblCtlDate
            // 
            this.lblCtlDate.Location = new System.Drawing.Point(51, 321);
            this.lblCtlDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlDate.Name = "lblCtlDate";
            this.lblCtlDate.Size = new System.Drawing.Size(36, 22);
            this.lblCtlDate.TabIndex = 20;
            this.lblCtlDate.Text = "Date";
            // 
            // dateEditSel
            // 
            this.dateEditSel.EditValue = null;
            this.dateEditSel.Location = new System.Drawing.Point(107, 316);
            this.dateEditSel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateEditSel.MenuManager = this.ribbonControl1;
            this.dateEditSel.Name = "dateEditSel";
            this.dateEditSel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditSel.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditSel.Properties.ReadOnly = true;
            this.dateEditSel.Size = new System.Drawing.Size(269, 28);
            this.dateEditSel.TabIndex = 19;
            // 
            // lblCtlHour3
            // 
            this.lblCtlHour3.Location = new System.Drawing.Point(853, 405);
            this.lblCtlHour3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlHour3.Name = "lblCtlHour3";
            this.lblCtlHour3.Size = new System.Drawing.Size(58, 22);
            this.lblCtlHour3.TabIndex = 36;
            this.lblCtlHour3.Text = "(hours)";
            // 
            // lblCtlHour2
            // 
            this.lblCtlHour2.Location = new System.Drawing.Point(853, 361);
            this.lblCtlHour2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlHour2.Name = "lblCtlHour2";
            this.lblCtlHour2.Size = new System.Drawing.Size(58, 22);
            this.lblCtlHour2.TabIndex = 35;
            this.lblCtlHour2.Text = "(hours)";
            // 
            // lblCtlHour1
            // 
            this.lblCtlHour1.Location = new System.Drawing.Point(853, 319);
            this.lblCtlHour1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlHour1.Name = "lblCtlHour1";
            this.lblCtlHour1.Size = new System.Drawing.Size(58, 22);
            this.lblCtlHour1.TabIndex = 34;
            this.lblCtlHour1.Text = "(hours)";
            // 
            // VocationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblCtlHour3);
            this.Controls.Add(this.lblCtlHour2);
            this.Controls.Add(this.lblCtlHour1);
            this.Controls.Add(this.lblCtlSelEmployee);
            this.Controls.Add(this.textEditEmployeeMsg);
            this.Controls.Add(this.textEditLeave3Hour);
            this.Controls.Add(this.textEditLeave2Hour);
            this.Controls.Add(this.textEditLeave1Hour);
            this.Controls.Add(this.memoEditReason);
            this.Controls.Add(this.lblCtlReason);
            this.Controls.Add(this.lookUpEditVocation3);
            this.Controls.Add(this.lblCtlVocation3);
            this.Controls.Add(this.lookUpEditVocation2);
            this.Controls.Add(this.lblCtlVocation2);
            this.Controls.Add(this.lookUpEditVocation1);
            this.Controls.Add(this.lblCtlVocation1);
            this.Controls.Add(this.lblCtlDate);
            this.Controls.Add(this.dateEditSel);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "VocationEdit";
            this.Size = new System.Drawing.Size(1006, 530);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditEmployeeMsg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLeave3Hour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLeave2Hour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditLeave1Hour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEditReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVocation3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceLeaveType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVocation2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEditVocation1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSel.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditSel.Properties)).EndInit();
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
        private DevExpress.XtraEditors.LabelControl lblCtlSelEmployee;
        private DevExpress.XtraEditors.TextEdit textEditEmployeeMsg;
        private DevExpress.XtraEditors.TextEdit textEditLeave3Hour;
        private DevExpress.XtraEditors.TextEdit textEditLeave2Hour;
        private DevExpress.XtraEditors.TextEdit textEditLeave1Hour;
        private DevExpress.XtraEditors.MemoEdit memoEditReason;
        private DevExpress.XtraEditors.LabelControl lblCtlReason;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditVocation3;
        private DevExpress.XtraEditors.LabelControl lblCtlVocation3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditVocation2;
        private DevExpress.XtraEditors.LabelControl lblCtlVocation2;
        private DevExpress.XtraEditors.LookUpEdit lookUpEditVocation1;
        private DevExpress.XtraEditors.LabelControl lblCtlVocation1;
        private DevExpress.XtraEditors.LabelControl lblCtlDate;
        private DevExpress.XtraEditors.DateEdit dateEditSel;
        private System.Windows.Forms.BindingSource bindingSourceLeaveType;
        private DevExpress.XtraEditors.LabelControl lblCtlHour3;
        private DevExpress.XtraEditors.LabelControl lblCtlHour2;
        private DevExpress.XtraEditors.LabelControl lblCtlHour1;
    }
}
