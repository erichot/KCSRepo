namespace KCS.Views
{
    partial class ElevatorEdit
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnLoaded = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSave = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceDevice = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dataLayoutControl2 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.SlaveSIDTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.EleavatorNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EleavatorDesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForEleavatorID = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForSlaveSID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEleavatorName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEleavatorDes = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlaveSIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EleavatorNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EleavatorDesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSlaveSID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorDes)).BeginInit();
            this.SuspendLayout();
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
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ribbonControl1.MaxItemId = 11;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(689, 150);
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
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.ElevatorEditViewModel);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.Elevator);
            // 
            // bindingSourceDevice
            // 
            this.bindingSourceDevice.DataSource = typeof(KCS.Models.DeviceBase);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(26, 26);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Location = new System.Drawing.Point(474, 583);
            this.dataLayoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataLayoutControl2.Name = "dataLayoutControl2";
            this.dataLayoutControl2.Root = this.layoutControlGroup2;
            this.dataLayoutControl2.Size = new System.Drawing.Size(8, 7);
            this.dataLayoutControl2.TabIndex = 3;
            this.dataLayoutControl2.Text = "dataLayoutControl2";
            // 
            // SlaveSIDTextEdit
            // 
            this.SlaveSIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "SlaveSID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SlaveSIDTextEdit.Location = new System.Drawing.Point(124, 16);
            this.SlaveSIDTextEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SlaveSIDTextEdit.MenuManager = this.ribbonControl1;
            this.SlaveSIDTextEdit.Name = "SlaveSIDTextEdit";
            this.SlaveSIDTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.SlaveSIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.SlaveSIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SlaveSIDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SlaveSIDTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SlaveSID", "Slave SID", 24, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IP", "IP", 86, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SlaveName", "Slave Name", 88, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SlaveDescription", "Slave Description", 119, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.SlaveSIDTextEdit.Properties.DataSource = this.bindingSourceDevice;
            this.SlaveSIDTextEdit.Properties.DisplayMember = "Details";
            this.SlaveSIDTextEdit.Properties.NullText = "";
            this.SlaveSIDTextEdit.Properties.ValueMember = "SlaveSID";
            this.SlaveSIDTextEdit.Size = new System.Drawing.Size(553, 24);
            this.SlaveSIDTextEdit.StyleController = this.dataLayoutControl1;
            this.SlaveSIDTextEdit.TabIndex = 5;
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.EleavatorNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.EleavatorDesTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SlaveSIDTextEdit);
            this.dataLayoutControl1.DataSource = this.bindingSource;
            this.dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForEleavatorID});
            this.dataLayoutControl1.Location = new System.Drawing.Point(-5, 155);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(693, 124);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // EleavatorNameTextEdit
            // 
            this.EleavatorNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "EleavatorName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EleavatorNameTextEdit.Location = new System.Drawing.Point(123, 47);
            this.EleavatorNameTextEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EleavatorNameTextEdit.MenuManager = this.ribbonControl1;
            this.EleavatorNameTextEdit.Name = "EleavatorNameTextEdit";
            this.EleavatorNameTextEdit.Size = new System.Drawing.Size(552, 24);
            this.EleavatorNameTextEdit.StyleController = this.dataLayoutControl1;
            this.EleavatorNameTextEdit.TabIndex = 6;
            // 
            // EleavatorDesTextEdit
            // 
            this.EleavatorDesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "EleavatorDes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EleavatorDesTextEdit.Location = new System.Drawing.Point(123, 76);
            this.EleavatorDesTextEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EleavatorDesTextEdit.MenuManager = this.ribbonControl1;
            this.EleavatorDesTextEdit.Name = "EleavatorDesTextEdit";
            this.EleavatorDesTextEdit.Size = new System.Drawing.Size(552, 24);
            this.EleavatorDesTextEdit.StyleController = this.dataLayoutControl1;
            this.EleavatorDesTextEdit.TabIndex = 7;
            // 
            // ItemForEleavatorID
            // 
            this.ItemForEleavatorID.Location = new System.Drawing.Point(0, 0);
            this.ItemForEleavatorID.Name = "ItemForEleavatorID";
            this.ItemForEleavatorID.Size = new System.Drawing.Size(666, 30);
            this.ItemForEleavatorID.Text = "Eleavator ID";
            this.ItemForEleavatorID.TextSize = new System.Drawing.Size(104, 18);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(693, 124);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AllowDrawBackground = false;
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForSlaveSID,
            this.ItemForEleavatorName,
            this.ItemForEleavatorDes});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "autoGeneratedGroup0";
            this.layoutControlGroup3.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup3.Size = new System.Drawing.Size(667, 98);
            // 
            // ItemForSlaveSID
            // 
            this.ItemForSlaveSID.Control = this.SlaveSIDTextEdit;
            this.ItemForSlaveSID.Location = new System.Drawing.Point(0, 0);
            this.ItemForSlaveSID.Name = "ItemForSlaveSID";
            this.ItemForSlaveSID.Size = new System.Drawing.Size(667, 30);
            this.ItemForSlaveSID.Text = "Slave SID";
            this.ItemForSlaveSID.TextSize = new System.Drawing.Size(104, 18);
            // 
            // ItemForEleavatorName
            // 
            this.ItemForEleavatorName.Location = new System.Drawing.Point(0, 30);
            this.ItemForEleavatorName.Name = "ItemForEleavatorName";
            this.ItemForEleavatorName.Size = new System.Drawing.Size(667, 34);
            this.ItemForEleavatorName.Text = "Eleavator Name";
            this.ItemForEleavatorName.TextSize = new System.Drawing.Size(104, 18);
            // 
            // ItemForEleavatorDes
            // 
            this.ItemForEleavatorDes.Location = new System.Drawing.Point(0, 64);
            this.ItemForEleavatorDes.Name = "ItemForEleavatorDes";
            this.ItemForEleavatorDes.Size = new System.Drawing.Size(667, 34);
            this.ItemForEleavatorDes.Text = "Eleavator Des";
            this.ItemForEleavatorDes.TextSize = new System.Drawing.Size(104, 18);
            // 
            // ElevatorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl2);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ElevatorEdit";
            this.Size = new System.Drawing.Size(689, 394);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlaveSIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EleavatorNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EleavatorDesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSlaveSID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorDes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private DevExpress.XtraBars.BarButtonItem bbiOnLoaded;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupClose;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingSource bindingSourceDevice;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit EleavatorNameTextEdit;
        private DevExpress.XtraEditors.TextEdit EleavatorDesTextEdit;
        private DevExpress.XtraEditors.LookUpEdit SlaveSIDTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEleavatorID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSlaveSID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEleavatorName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEleavatorDes;
    }
}
