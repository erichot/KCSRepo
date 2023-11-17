namespace KCS.Views
{
    partial class SetDeviceParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetDeviceParameters));
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnLoaded = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupClose = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButtonSetAll = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDevLanguage = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonWorkMode = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonSetPwd = new DevExpress.XtraEditors.SimpleButton();
            this.lblCtlLanguage = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlWorkMode = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlMenuPwd = new DevExpress.XtraEditors.LabelControl();
            this.MenuPwdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LanguageTextComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.WorkModeTextComboBoxEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSlaveSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlaveDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMenuPwd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLanguageText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkModeText = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPwdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LanguageTextComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkModeTextComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.Views.SetDeviceParametersViewModel);
            // 
            // ribbonControl
            // 
            this.ribbonControl.AllowMinimizeRibbon = false;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.ExpandCollapseItem.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveLayout,
            this.bbiResetLayout,
            this.bbiOnLoaded,
            this.bbiClose,
            this.bbiEdit,
            this.bbiRefresh});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.ribbonControl.MaxItemId = 13;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowQatLocationSelector = false;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(999, 150);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
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
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Edit";
            this.bbiEdit.Id = 11;
            this.bbiEdit.ImageOptions.Image = global::KCS.Properties.Resources.icon_edit_16;
            this.bbiEdit.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_edit_32;
            this.bbiEdit.Name = "bbiEdit";
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Refresh";
            this.bbiRefresh.Id = 12;
            this.bbiRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiRefresh.ImageOptions.Image")));
            this.bbiRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiRefresh.ImageOptions.LargeImage")));
            this.bbiRefresh.Name = "bbiRefresh";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupClose});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroupClose
            // 
            this.ribbonPageGroupClose.AllowTextClipping = false;
            this.ribbonPageGroupClose.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroupClose.Name = "ribbonPageGroupClose";
            this.ribbonPageGroupClose.ShowCaptionButton = false;
            this.ribbonPageGroupClose.Text = "Close";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButtonSetAll);
            this.panelControl1.Controls.Add(this.simpleButtonDevLanguage);
            this.panelControl1.Controls.Add(this.simpleButtonWorkMode);
            this.panelControl1.Controls.Add(this.simpleButtonSetPwd);
            this.panelControl1.Controls.Add(this.lblCtlLanguage);
            this.panelControl1.Controls.Add(this.lblCtlWorkMode);
            this.panelControl1.Controls.Add(this.lblCtlMenuPwd);
            this.panelControl1.Controls.Add(this.MenuPwdTextEdit);
            this.panelControl1.Controls.Add(this.LanguageTextComboBoxEdit);
            this.panelControl1.Controls.Add(this.WorkModeTextComboBoxEdit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 150);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(999, 175);
            this.panelControl1.TabIndex = 1;
            // 
            // simpleButtonSetAll
            // 
            this.simpleButtonSetAll.Location = new System.Drawing.Point(401, 124);
            this.simpleButtonSetAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonSetAll.Name = "simpleButtonSetAll";
            this.simpleButtonSetAll.Size = new System.Drawing.Size(139, 38);
            this.simpleButtonSetAll.TabIndex = 26;
            this.simpleButtonSetAll.Text = "Set All";
            // 
            // simpleButtonDevLanguage
            // 
            this.simpleButtonDevLanguage.Location = new System.Drawing.Point(819, 47);
            this.simpleButtonDevLanguage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonDevLanguage.Name = "simpleButtonDevLanguage";
            this.simpleButtonDevLanguage.Size = new System.Drawing.Size(64, 32);
            this.simpleButtonDevLanguage.TabIndex = 25;
            this.simpleButtonDevLanguage.Text = "Set";
            // 
            // simpleButtonWorkMode
            // 
            this.simpleButtonWorkMode.Location = new System.Drawing.Point(819, 86);
            this.simpleButtonWorkMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonWorkMode.Name = "simpleButtonWorkMode";
            this.simpleButtonWorkMode.Size = new System.Drawing.Size(64, 32);
            this.simpleButtonWorkMode.TabIndex = 24;
            this.simpleButtonWorkMode.Text = "Set";
            // 
            // simpleButtonSetPwd
            // 
            this.simpleButtonSetPwd.Location = new System.Drawing.Point(819, 9);
            this.simpleButtonSetPwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButtonSetPwd.Name = "simpleButtonSetPwd";
            this.simpleButtonSetPwd.Size = new System.Drawing.Size(64, 32);
            this.simpleButtonSetPwd.TabIndex = 23;
            this.simpleButtonSetPwd.Text = "Set";
            // 
            // lblCtlLanguage
            // 
            this.lblCtlLanguage.Location = new System.Drawing.Point(75, 56);
            this.lblCtlLanguage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCtlLanguage.Name = "lblCtlLanguage";
            this.lblCtlLanguage.Size = new System.Drawing.Size(111, 18);
            this.lblCtlLanguage.TabIndex = 22;
            this.lblCtlLanguage.Text = "Device Language";
            // 
            // lblCtlWorkMode
            // 
            this.lblCtlWorkMode.Location = new System.Drawing.Point(75, 94);
            this.lblCtlWorkMode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCtlWorkMode.Name = "lblCtlWorkMode";
            this.lblCtlWorkMode.Size = new System.Drawing.Size(123, 18);
            this.lblCtlWorkMode.TabIndex = 21;
            this.lblCtlWorkMode.Text = "Device Work Mode";
            // 
            // lblCtlMenuPwd
            // 
            this.lblCtlMenuPwd.Location = new System.Drawing.Point(75, 20);
            this.lblCtlMenuPwd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCtlMenuPwd.Name = "lblCtlMenuPwd";
            this.lblCtlMenuPwd.Size = new System.Drawing.Size(102, 18);
            this.lblCtlMenuPwd.TabIndex = 20;
            this.lblCtlMenuPwd.Text = "Menu Password";
            // 
            // MenuPwdTextEdit
            // 
            this.MenuPwdTextEdit.Location = new System.Drawing.Point(208, 16);
            this.MenuPwdTextEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MenuPwdTextEdit.Name = "MenuPwdTextEdit";
            this.MenuPwdTextEdit.Properties.Mask.EditMask = "[0-9]{6}";
            this.MenuPwdTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.MenuPwdTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.MenuPwdTextEdit.Properties.ValidateOnEnterKey = true;
            this.MenuPwdTextEdit.Size = new System.Drawing.Size(598, 24);
            this.MenuPwdTextEdit.TabIndex = 17;
            // 
            // LanguageTextComboBoxEdit
            // 
            this.LanguageTextComboBoxEdit.Location = new System.Drawing.Point(208, 52);
            this.LanguageTextComboBoxEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LanguageTextComboBoxEdit.Name = "LanguageTextComboBoxEdit";
            this.LanguageTextComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LanguageTextComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.LanguageTextComboBoxEdit.Size = new System.Drawing.Size(598, 24);
            this.LanguageTextComboBoxEdit.TabIndex = 18;
            // 
            // WorkModeTextComboBoxEdit
            // 
            this.WorkModeTextComboBoxEdit.Location = new System.Drawing.Point(208, 88);
            this.WorkModeTextComboBoxEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WorkModeTextComboBoxEdit.Name = "WorkModeTextComboBoxEdit";
            this.WorkModeTextComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.WorkModeTextComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.WorkModeTextComboBoxEdit.Size = new System.Drawing.Size(598, 24);
            this.WorkModeTextComboBoxEdit.TabIndex = 19;
            // 
            // gridControl
            // 
            this.gridControl.DataSource = this.bindingSource;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Location = new System.Drawing.Point(0, 325);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(999, 363);
            this.gridControl.TabIndex = 2;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(KCS.Models.DeviceBrief);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSlaveSID,
            this.colIP,
            this.colSlaveName,
            this.colSlaveDescription,
            this.colMenuPwd,
            this.colLanguageText,
            this.colWorkModeText});
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
            this.colSlaveSID.AppearanceCell.Options.UseTextOptions = true;
            this.colSlaveSID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
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
            // colMenuPwd
            // 
            this.colMenuPwd.FieldName = "MenuPwd";
            this.colMenuPwd.Name = "colMenuPwd";
            this.colMenuPwd.Visible = true;
            this.colMenuPwd.VisibleIndex = 5;
            // 
            // colLanguageText
            // 
            this.colLanguageText.FieldName = "LanguageText";
            this.colLanguageText.Name = "colLanguageText";
            this.colLanguageText.Visible = true;
            this.colLanguageText.VisibleIndex = 6;
            // 
            // colWorkModeText
            // 
            this.colWorkModeText.FieldName = "WorkModeText";
            this.colWorkModeText.Name = "colWorkModeText";
            this.colWorkModeText.Visible = true;
            this.colWorkModeText.VisibleIndex = 7;
            // 
            // SetDeviceParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SetDeviceParameters";
            this.Size = new System.Drawing.Size(999, 688);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPwdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LanguageTextComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkModeTextComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private DevExpress.XtraBars.BarButtonItem bbiOnLoaded;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupClose;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblCtlLanguage;
        private DevExpress.XtraEditors.LabelControl lblCtlWorkMode;
        private DevExpress.XtraEditors.LabelControl lblCtlMenuPwd;
        private DevExpress.XtraEditors.TextEdit MenuPwdTextEdit;
        private DevExpress.XtraEditors.ComboBoxEdit LanguageTextComboBoxEdit;
        private DevExpress.XtraEditors.ComboBoxEdit WorkModeTextComboBoxEdit;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSetPwd;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraEditors.SimpleButton simpleButtonSetAll;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDevLanguage;
        private DevExpress.XtraEditors.SimpleButton simpleButtonWorkMode;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveSID;
        private DevExpress.XtraGrid.Columns.GridColumn colIP;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveName;
        private DevExpress.XtraGrid.Columns.GridColumn colSlaveDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colMenuPwd;
        private DevExpress.XtraGrid.Columns.GridColumn colLanguageText;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkModeText;
    }
}
