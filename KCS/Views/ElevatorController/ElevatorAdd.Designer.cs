namespace KCS.Views
{
    partial class ElevatorAdd
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
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnLoaded = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSave = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.dataLayoutControl2 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.EleavatorNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EleavatorDesTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SlaveSIDTextEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSourceDevice = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForEleavatorDes = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEleavatorName = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSlaveSID = new DevExpress.XtraLayout.LayoutControlItem();
            this.alertControl = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EleavatorNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EleavatorDesTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlaveSIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDevice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorDes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSlaveSID)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.ElevatorAddViewModel);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowMinimizeRibbon = false;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiReset,
            this.bbiSaveLayout,
            this.bbiResetLayout,
            this.bbiOnLoaded,
            this.bbiDelete,
            this.bbiClose,
            this.bbiSaveAndNew});
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
            this.ribbonControl1.Size = new System.Drawing.Size(637, 150);
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
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "SaveAndClose";
            this.bbiSaveAndClose.Id = 2;
            this.bbiSaveAndClose.ImageOptions.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "Reset Changes";
            this.bbiReset.Id = 4;
            this.bbiReset.ImageOptions.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
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
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 8;
            this.bbiDelete.ImageOptions.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 9;
            this.bbiClose.ImageOptions.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "SaveAndNew";
            this.bbiSaveAndNew.Id = 3;
            this.bbiSaveAndNew.ImageOptions.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
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
            this.ribbonPageGroupSave.ItemLinks.Add(this.bbiSaveAndClose);
            this.ribbonPageGroupSave.ItemLinks.Add(this.bbiSaveAndNew);
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
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.Elevator);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.dataLayoutControl2);
            this.dataLayoutControl1.Controls.Add(this.EleavatorNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.EleavatorDesTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SlaveSIDTextEdit);
            this.dataLayoutControl1.DataSource = this.bindingSource;
            this.dataLayoutControl1.Location = new System.Drawing.Point(27, 160);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(593, 353);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // dataLayoutControl2
            // 
            this.dataLayoutControl2.Location = new System.Drawing.Point(16, 106);
            this.dataLayoutControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataLayoutControl2.Name = "dataLayoutControl2";
            this.dataLayoutControl2.Root = this.Root;
            this.dataLayoutControl2.Size = new System.Drawing.Size(561, 231);
            this.dataLayoutControl2.TabIndex = 7;
            this.dataLayoutControl2.Text = "dataLayoutControl2";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Location = new System.Drawing.Point(0, 0);
            this.Root.Name = "Root";
            this.Root.OptionsItemText.TextToControlDistance = 4;
            this.Root.Size = new System.Drawing.Size(561, 231);
            this.Root.TextVisible = false;
            // 
            // EleavatorNameTextEdit
            // 
            this.EleavatorNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "EleavatorName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EleavatorNameTextEdit.Location = new System.Drawing.Point(124, 16);
            this.EleavatorNameTextEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EleavatorNameTextEdit.MenuManager = this.ribbonControl1;
            this.EleavatorNameTextEdit.Name = "EleavatorNameTextEdit";
            this.EleavatorNameTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.EleavatorNameTextEdit.Size = new System.Drawing.Size(453, 24);
            this.EleavatorNameTextEdit.StyleController = this.dataLayoutControl1;
            this.EleavatorNameTextEdit.TabIndex = 5;
            // 
            // EleavatorDesTextEdit
            // 
            this.EleavatorDesTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "EleavatorDes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EleavatorDesTextEdit.Location = new System.Drawing.Point(124, 46);
            this.EleavatorDesTextEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EleavatorDesTextEdit.MenuManager = this.ribbonControl1;
            this.EleavatorDesTextEdit.Name = "EleavatorDesTextEdit";
            this.EleavatorDesTextEdit.Size = new System.Drawing.Size(453, 24);
            this.EleavatorDesTextEdit.StyleController = this.dataLayoutControl1;
            this.EleavatorDesTextEdit.TabIndex = 6;
            // 
            // SlaveSIDTextEdit
            // 
            this.SlaveSIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "SlaveSID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.SlaveSIDTextEdit.Location = new System.Drawing.Point(124, 76);
            this.SlaveSIDTextEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SlaveSIDTextEdit.MenuManager = this.ribbonControl1;
            this.SlaveSIDTextEdit.Name = "SlaveSIDTextEdit";
            this.SlaveSIDTextEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.SlaveSIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SlaveSIDTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SlaveSIDTextEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SlaveSID", "Slave SID", 22, DevExpress.Utils.FormatType.Numeric, "", true, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IP", "IP", 86, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SlaveName", "Slave Name", 88, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SlaveDescription", "Slave Description", 119, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.SlaveSIDTextEdit.Properties.DataSource = this.bindingSourceDevice;
            this.SlaveSIDTextEdit.Properties.DisplayMember = "Details";
            this.SlaveSIDTextEdit.Properties.NullText = "";
            this.SlaveSIDTextEdit.Properties.ValueMember = "SlaveSID";
            this.SlaveSIDTextEdit.Size = new System.Drawing.Size(453, 24);
            this.SlaveSIDTextEdit.StyleController = this.dataLayoutControl1;
            this.SlaveSIDTextEdit.TabIndex = 4;
            // 
            // bindingSourceDevice
            // 
            this.bindingSourceDevice.DataSource = typeof(KCS.Models.DeviceBase);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlItem1,
            this.ItemForSlaveSID});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup1.Size = new System.Drawing.Size(593, 353);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForEleavatorDes,
            this.ItemForEleavatorName});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 4;
            this.layoutControlGroup2.Size = new System.Drawing.Size(567, 60);
            // 
            // ItemForEleavatorDes
            // 
            this.ItemForEleavatorDes.Control = this.EleavatorDesTextEdit;
            this.ItemForEleavatorDes.Location = new System.Drawing.Point(0, 30);
            this.ItemForEleavatorDes.Name = "ItemForEleavatorDes";
            this.ItemForEleavatorDes.Size = new System.Drawing.Size(567, 30);
            this.ItemForEleavatorDes.Text = "Eleavator Des";
            this.ItemForEleavatorDes.TextSize = new System.Drawing.Size(104, 18);
            // 
            // ItemForEleavatorName
            // 
            this.ItemForEleavatorName.Control = this.EleavatorNameTextEdit;
            this.ItemForEleavatorName.Location = new System.Drawing.Point(0, 0);
            this.ItemForEleavatorName.Name = "ItemForEleavatorName";
            this.ItemForEleavatorName.Size = new System.Drawing.Size(567, 30);
            this.ItemForEleavatorName.Text = "Eleavator Name";
            this.ItemForEleavatorName.TextSize = new System.Drawing.Size(104, 18);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataLayoutControl2;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(567, 237);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ItemForSlaveSID
            // 
            this.ItemForSlaveSID.Control = this.SlaveSIDTextEdit;
            this.ItemForSlaveSID.Location = new System.Drawing.Point(0, 60);
            this.ItemForSlaveSID.Name = "ItemForSlaveSID";
            this.ItemForSlaveSID.Size = new System.Drawing.Size(567, 30);
            this.ItemForSlaveSID.Text = "Slave SID";
            this.ItemForSlaveSID.TextSize = new System.Drawing.Size(104, 18);
            // 
            // alertControl
            // 
            this.alertControl.AllowHotTrack = false;
            this.alertControl.AutoFormDelay = 1000;
            this.alertControl.FormDisplaySpeed = DevExpress.XtraBars.Alerter.AlertFormDisplaySpeed.Fast;
            this.alertControl.FormLocation = DevExpress.XtraBars.Alerter.AlertFormLocation.TopRight;
            this.alertControl.ShowToolTips = false;
            // 
            // ElevatorAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "ElevatorAdd";
            this.Size = new System.Drawing.Size(637, 520);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EleavatorNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EleavatorDesTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlaveSIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDevice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorDes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEleavatorName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSlaveSID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private DevExpress.XtraBars.BarButtonItem bbiOnLoaded;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSave;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupClose;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl2;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit EleavatorNameTextEdit;
        private DevExpress.XtraEditors.TextEdit EleavatorDesTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEleavatorDes;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEleavatorName;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSlaveSID;
        private DevExpress.XtraEditors.LookUpEdit SlaveSIDTextEdit;
        private DevExpress.XtraBars.Alerter.AlertControl alertControl;
        private System.Windows.Forms.BindingSource bindingSourceDevice;
    }
}
