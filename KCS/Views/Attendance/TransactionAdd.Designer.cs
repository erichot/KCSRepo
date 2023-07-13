namespace KCS.Views
{
    partial class TransactionAdd
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.CardIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.UserIDTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UserNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TranDateTimeDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.TranTypeComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForCardID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUserID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTranDateTime = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForTranType = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CardIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserIDTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TranDateTimeDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TranDateTimeDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TranTypeComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCardID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTranDateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTranType)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.TransactionAddViewModel);
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
            this.ribbonControl1.Size = new System.Drawing.Size(519, 150);
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
            this.ribbonPageGroupSave});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroupSave
            // 
            this.ribbonPageGroupSave.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroupSave.Name = "ribbonPageGroupSave";
            this.ribbonPageGroupSave.ShowCaptionButton = false;
            this.ribbonPageGroupSave.Text = "Save";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.CardIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.UserIDTextEdit);
            this.dataLayoutControl1.Controls.Add(this.UserNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.TranDateTimeDateEdit);
            this.dataLayoutControl1.Controls.Add(this.TranTypeComboBoxEdit);
            this.dataLayoutControl1.DataSource = this.bindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 150);
            this.dataLayoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(519, 233);
            this.dataLayoutControl1.TabIndex = 9;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // CardIDTextEdit
            // 
            this.CardIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "CardID", true));
            this.CardIDTextEdit.Location = new System.Drawing.Point(124, 16);
            this.CardIDTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CardIDTextEdit.MenuManager = this.ribbonControl1;
            this.CardIDTextEdit.Name = "CardIDTextEdit";
            this.CardIDTextEdit.Size = new System.Drawing.Size(379, 24);
            this.CardIDTextEdit.StyleController = this.dataLayoutControl1;
            this.CardIDTextEdit.TabIndex = 4;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.TaTransaction);
            // 
            // UserIDTextEdit
            // 
            this.UserIDTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "UserID", true));
            this.UserIDTextEdit.Location = new System.Drawing.Point(124, 46);
            this.UserIDTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserIDTextEdit.MenuManager = this.ribbonControl1;
            this.UserIDTextEdit.Name = "UserIDTextEdit";
            this.UserIDTextEdit.Size = new System.Drawing.Size(379, 24);
            this.UserIDTextEdit.StyleController = this.dataLayoutControl1;
            this.UserIDTextEdit.TabIndex = 5;
            // 
            // UserNameTextEdit
            // 
            this.UserNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "UserName", true));
            this.UserNameTextEdit.Location = new System.Drawing.Point(124, 76);
            this.UserNameTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UserNameTextEdit.MenuManager = this.ribbonControl1;
            this.UserNameTextEdit.Name = "UserNameTextEdit";
            this.UserNameTextEdit.Size = new System.Drawing.Size(379, 24);
            this.UserNameTextEdit.StyleController = this.dataLayoutControl1;
            this.UserNameTextEdit.TabIndex = 6;
            // 
            // TranDateTimeDateEdit
            // 
            this.TranDateTimeDateEdit.EditValue = null;
            this.TranDateTimeDateEdit.Location = new System.Drawing.Point(124, 106);
            this.TranDateTimeDateEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TranDateTimeDateEdit.MenuManager = this.ribbonControl1;
            this.TranDateTimeDateEdit.Name = "TranDateTimeDateEdit";
            this.TranDateTimeDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TranDateTimeDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TranDateTimeDateEdit.Properties.DisplayFormat.FormatString = "F";
            this.TranDateTimeDateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TranDateTimeDateEdit.Properties.EditFormat.FormatString = "F";
            this.TranDateTimeDateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.TranDateTimeDateEdit.Properties.Mask.EditMask = "F";
            this.TranDateTimeDateEdit.Size = new System.Drawing.Size(379, 24);
            this.TranDateTimeDateEdit.StyleController = this.dataLayoutControl1;
            this.TranDateTimeDateEdit.TabIndex = 7;
            // 
            // TranTypeComboBoxEdit
            // 
            this.TranTypeComboBoxEdit.Location = new System.Drawing.Point(124, 136);
            this.TranTypeComboBoxEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TranTypeComboBoxEdit.MenuManager = this.ribbonControl1;
            this.TranTypeComboBoxEdit.Name = "TranTypeComboBoxEdit";
            this.TranTypeComboBoxEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.TranTypeComboBoxEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.TranTypeComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TranTypeComboBoxEdit.Properties.Items.AddRange(new object[] {
            "1",
            "2",
            "161",
            "162"});
            this.TranTypeComboBoxEdit.Size = new System.Drawing.Size(379, 24);
            this.TranTypeComboBoxEdit.StyleController = this.dataLayoutControl1;
            this.TranTypeComboBoxEdit.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(519, 233);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForCardID,
            this.ItemForUserID,
            this.ItemForUserName,
            this.ItemForTranDateTime,
            this.ItemForTranType});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(493, 207);
            // 
            // ItemForCardID
            // 
            this.ItemForCardID.Control = this.CardIDTextEdit;
            this.ItemForCardID.Location = new System.Drawing.Point(0, 0);
            this.ItemForCardID.Name = "ItemForCardID";
            this.ItemForCardID.Size = new System.Drawing.Size(493, 30);
            this.ItemForCardID.Text = "Card ID";
            this.ItemForCardID.TextSize = new System.Drawing.Size(105, 18);
            // 
            // ItemForUserID
            // 
            this.ItemForUserID.Control = this.UserIDTextEdit;
            this.ItemForUserID.Location = new System.Drawing.Point(0, 30);
            this.ItemForUserID.Name = "ItemForUserID";
            this.ItemForUserID.Size = new System.Drawing.Size(493, 30);
            this.ItemForUserID.Text = "User ID";
            this.ItemForUserID.TextSize = new System.Drawing.Size(105, 18);
            // 
            // ItemForUserName
            // 
            this.ItemForUserName.Control = this.UserNameTextEdit;
            this.ItemForUserName.Location = new System.Drawing.Point(0, 60);
            this.ItemForUserName.Name = "ItemForUserName";
            this.ItemForUserName.Size = new System.Drawing.Size(493, 30);
            this.ItemForUserName.Text = "User Name";
            this.ItemForUserName.TextSize = new System.Drawing.Size(105, 18);
            // 
            // ItemForTranDateTime
            // 
            this.ItemForTranDateTime.Control = this.TranDateTimeDateEdit;
            this.ItemForTranDateTime.Location = new System.Drawing.Point(0, 90);
            this.ItemForTranDateTime.Name = "ItemForTranDateTime";
            this.ItemForTranDateTime.Size = new System.Drawing.Size(493, 30);
            this.ItemForTranDateTime.Text = "Tran Date Time";
            this.ItemForTranDateTime.TextSize = new System.Drawing.Size(105, 18);
            // 
            // ItemForTranType
            // 
            this.ItemForTranType.Control = this.TranTypeComboBoxEdit;
            this.ItemForTranType.Location = new System.Drawing.Point(0, 120);
            this.ItemForTranType.Name = "ItemForTranType";
            this.ItemForTranType.Size = new System.Drawing.Size(493, 87);
            this.ItemForTranType.Text = "Tran Type";
            this.ItemForTranType.TextSize = new System.Drawing.Size(105, 18);
            // 
            // TransactionAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TransactionAdd";
            this.Size = new System.Drawing.Size(519, 383);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CardIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserIDTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TranDateTimeDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TranDateTimeDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TranTypeComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCardID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTranDateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForTranType)).EndInit();
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
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit CardIDTextEdit;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraEditors.TextEdit UserIDTextEdit;
        private DevExpress.XtraEditors.TextEdit UserNameTextEdit;
        private DevExpress.XtraEditors.DateEdit TranDateTimeDateEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCardID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUserName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTranDateTime;
        private DevExpress.XtraEditors.ComboBoxEdit TranTypeComboBoxEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForTranType;
    }
}
