namespace KCS
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DevExpress.Utils.Animation.Transition transition1 = new DevExpress.Utils.Animation.Transition();
            DevExpress.Utils.Animation.SlideFadeTransition slideFadeTransition1 = new DevExpress.Utils.Animation.SlideFadeTransition();
            this.modulesContainer = new DevExpress.XtraEditors.XtraUserControl();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.biNewDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.biSystemSetting = new DevExpress.XtraBars.BarButtonItem();
            this.biSetAdminPin = new DevExpress.XtraBars.BarButtonItem();
            this.biNewWorkShift = new DevExpress.XtraBars.BarButtonItem();
            this.biEmployeesType = new DevExpress.XtraBars.BarButtonItem();
            this.bbiJobCode = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportSetting = new DevExpress.XtraBars.BarButtonItem();
            this.biAbout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiCompanyDataSetting = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportMannual = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChangeLang = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSyncSet = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDatabaseMaintenance = new DevExpress.XtraBars.BarButtonItem();
            this.bbiLiftControl = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.transitionManager = new DevExpress.Utils.Animation.TransitionManager(this.components);
            this.dockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.officeNavigationBar = new DevExpress.XtraBars.Navigation.OfficeNavigationBar();
            this.navBar = new DevExpress.XtraNavBar.NavBarControl();
            this.UserLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // modulesContainer
            // 
            this.modulesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modulesContainer.Location = new System.Drawing.Point(301, 2);
            this.modulesContainer.Margin = new System.Windows.Forms.Padding(27, 30, 27, 4);
            this.modulesContainer.Name = "modulesContainer";
            this.modulesContainer.Size = new System.Drawing.Size(731, 431);
            this.modulesContainer.TabIndex = 2;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 663);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1034, 40);
            // 
            // ribbonControl
            // 
            this.ribbonControl.AllowMinimizeRibbon = false;
            this.ribbonControl.ApplicationIcon = global::KCS.Properties.Resources.AppIcon;
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.biNewDepartment,
            this.biSystemSetting,
            this.biSetAdminPin,
            this.biNewWorkShift,
            this.biEmployeesType,
            this.bbiJobCode,
            this.bbiExportSetting,
            this.biAbout,
            this.bbiCompanyDataSetting,
            this.bbiExportMannual,
            this.bbiChangeLang,
            this.bbiSyncSet,
            this.bbiDatabaseMaintenance,
            this.bbiLiftControl});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl.MaxItemId = 1;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1034, 184);
            this.ribbonControl.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // biNewDepartment
            // 
            this.biNewDepartment.Caption = "New  Department";
            this.biNewDepartment.Id = 3;
            this.biNewDepartment.ImageOptions.Image = global::KCS.Properties.Resources.icon_new_group_16;
            this.biNewDepartment.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_new_group_32;
            this.biNewDepartment.Name = "biNewDepartment";
            // 
            // biSystemSetting
            // 
            this.biSystemSetting.Caption = "System Setting";
            this.biSystemSetting.Id = 6;
            this.biSystemSetting.ImageOptions.Image = global::KCS.Properties.Resources.icon_setting_16;
            this.biSystemSetting.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_setting_32;
            this.biSystemSetting.Name = "biSystemSetting";
            // 
            // biSetAdminPin
            // 
            this.biSetAdminPin.Caption = "Set Administrators PIN";
            this.biSetAdminPin.Id = 7;
            this.biSetAdminPin.ImageOptions.Image = global::KCS.Properties.Resources.ResetKey_16;
            this.biSetAdminPin.ImageOptions.LargeImage = global::KCS.Properties.Resources.ResetKey_32;
            this.biSetAdminPin.Name = "biSetAdminPin";
            // 
            // biNewWorkShift
            // 
            this.biNewWorkShift.Caption = "New Work shift";
            this.biNewWorkShift.Id = 8;
            this.biNewWorkShift.ImageOptions.Image = global::KCS.Properties.Resources.icon_shift_16_;
            this.biNewWorkShift.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_shift_32;
            this.biNewWorkShift.Name = "biNewWorkShift";
            // 
            // biEmployeesType
            // 
            this.biEmployeesType.Caption = "Employee Type";
            this.biEmployeesType.Id = 9;
            this.biEmployeesType.ImageOptions.Image = global::KCS.Properties.Resources.icon_new_group_16;
            this.biEmployeesType.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_new_group_32;
            this.biEmployeesType.Name = "biEmployeesType";
            // 
            // bbiJobCode
            // 
            this.bbiJobCode.Caption = "Job Code";
            this.bbiJobCode.Id = 10;
            this.bbiJobCode.ImageOptions.Image = global::KCS.Properties.Resources.JobCode_16;
            this.bbiJobCode.ImageOptions.LargeImage = global::KCS.Properties.Resources.JobCode_32;
            this.bbiJobCode.Name = "bbiJobCode";
            // 
            // bbiExportSetting
            // 
            this.bbiExportSetting.Caption = "Export Text Setting";
            this.bbiExportSetting.Id = 11;
            this.bbiExportSetting.ImageOptions.Image = global::KCS.Properties.Resources.export_TXT_16;
            this.bbiExportSetting.ImageOptions.LargeImage = global::KCS.Properties.Resources.export_TXT_32;
            this.bbiExportSetting.Name = "bbiExportSetting";
            // 
            // biAbout
            // 
            this.biAbout.Caption = "About";
            this.biAbout.Id = 12;
            this.biAbout.ImageOptions.Image = global::KCS.Properties.Resources.icon_about_16;
            this.biAbout.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_about_32;
            this.biAbout.Name = "biAbout";
            // 
            // bbiCompanyDataSetting
            // 
            this.bbiCompanyDataSetting.Caption = "Company basic data";
            this.bbiCompanyDataSetting.Id = 14;
            this.bbiCompanyDataSetting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCompanyDataSetting.ImageOptions.Image")));
            this.bbiCompanyDataSetting.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiCompanyDataSetting.ImageOptions.LargeImage")));
            this.bbiCompanyDataSetting.Name = "bbiCompanyDataSetting";
            // 
            // bbiExportMannual
            // 
            this.bbiExportMannual.Caption = "Manual export";
            this.bbiExportMannual.Id = 15;
            this.bbiExportMannual.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportMannual.ImageOptions.Image")));
            this.bbiExportMannual.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportMannual.ImageOptions.LargeImage")));
            this.bbiExportMannual.Name = "bbiExportMannual";
            // 
            // bbiChangeLang
            // 
            this.bbiChangeLang.Caption = "Change Language";
            this.bbiChangeLang.Id = 16;
            this.bbiChangeLang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiChangeLang.ImageOptions.Image")));
            this.bbiChangeLang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiChangeLang.ImageOptions.LargeImage")));
            this.bbiChangeLang.Name = "bbiChangeLang";
            // 
            // bbiSyncSet
            // 
            this.bbiSyncSet.Caption = "Sync Setup";
            this.bbiSyncSet.Id = 17;
            this.bbiSyncSet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSyncSet.ImageOptions.Image")));
            this.bbiSyncSet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSyncSet.ImageOptions.LargeImage")));
            this.bbiSyncSet.Name = "bbiSyncSet";
            // 
            // bbiDatabaseMaintenance
            // 
            this.bbiDatabaseMaintenance.Caption = "Database DatabaseMaintenance";
            this.bbiDatabaseMaintenance.Id = 18;
            this.bbiDatabaseMaintenance.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDatabaseMaintenance.ImageOptions.Image")));
            this.bbiDatabaseMaintenance.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDatabaseMaintenance.ImageOptions.LargeImage")));
            this.bbiDatabaseMaintenance.Name = "bbiDatabaseMaintenance";
            // 
            // bbiLiftControl
            // 
            this.bbiLiftControl.Caption = "Elevator control";
            this.bbiLiftControl.Id = 19;
            this.bbiLiftControl.ImageOptions.Image = global::KCS.Properties.Resources.Elevator_control_32;
            this.bbiLiftControl.ImageOptions.LargeImage = global::KCS.Properties.Resources.Elevator_control_64;
            this.bbiLiftControl.Name = "bbiLiftControl";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupSystem});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroupSystem
            // 
            this.ribbonPageGroupSystem.Glyph = global::KCS.Properties.Resources.icon_shift_16_;
            this.ribbonPageGroupSystem.ItemLinks.Add(this.biSystemSetting);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.biSetAdminPin);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.biEmployeesType);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.bbiExportSetting);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.biAbout);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.bbiCompanyDataSetting);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.bbiExportMannual);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.bbiChangeLang);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.bbiSyncSet);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.bbiDatabaseMaintenance);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.bbiLiftControl);
            this.ribbonPageGroupSystem.Name = "ribbonPageGroupSystem";
            this.ribbonPageGroupSystem.ShowCaptionButton = false;
            this.ribbonPageGroupSystem.Text = "System";
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.MainViewModel);
            // 
            // transitionManager
            // 
            this.transitionManager.ShowWaitingIndicator = false;
            transition1.Control = this.modulesContainer;
            slideFadeTransition1.Parameters.EffectOptions = DevExpress.Utils.Animation.PushEffectOptions.FromRight;
            slideFadeTransition1.Parameters.FrameInterval = 5000;
            transition1.TransitionType = slideFadeTransition1;
            this.transitionManager.Transitions.Add(transition1);
            // 
            // dockManager
            // 
            this.dockManager.DockingOptions.FloatOnDblClick = false;
            this.dockManager.DockingOptions.ShowMaximizeButton = false;
            this.dockManager.Form = this.modulesContainer;
            this.dockManager.MenuManager = this.ribbonControl;
            this.dockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // officeNavigationBar
            // 
            this.officeNavigationBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(208)))), ((int)(((byte)(232)))));
            this.officeNavigationBar.CustomizationButtonVisibility = DevExpress.XtraBars.Navigation.CustomizationButtonVisibility.Hidden;
            this.officeNavigationBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.officeNavigationBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.officeNavigationBar.Location = new System.Drawing.Point(0, 619);
            this.officeNavigationBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.officeNavigationBar.Name = "officeNavigationBar";
            this.officeNavigationBar.Size = new System.Drawing.Size(1034, 44);
            this.officeNavigationBar.TabIndex = 11;
            this.officeNavigationBar.Text = "officeNavigationBar1";
            // 
            // navBar
            // 
            this.navBar.ActiveGroup = null;
            this.navBar.AllowHorizontalResizing = DevExpress.Utils.DefaultBoolean.True;
            this.navBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.navBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.navBar.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl;
            this.navBar.Location = new System.Drawing.Point(2, 2);
            this.navBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.navBar.Name = "navBar";
            this.navBar.OptionsNavPane.ExpandedWidth = 299;
            this.navBar.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBar.Size = new System.Drawing.Size(299, 431);
            this.navBar.TabIndex = 12;
            this.navBar.Text = "navBarControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.modulesContainer);
            this.panelControl1.Controls.Add(this.navBar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 184);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1034, 435);
            this.panelControl1.TabIndex = 1;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "New";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Employee Type";
            this.barButtonItem2.Id = 9;
            this.barButtonItem2.ImageOptions.Image = global::KCS.Properties.Resources.icon_new_group_16;
            this.barButtonItem2.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_new_group_32;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 703);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.officeNavigationBar);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "KCS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.officeNavigationBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraEditors.XtraUserControl modulesContainer;
        private DevExpress.Utils.Animation.TransitionManager transitionManager;
        private DevExpress.XtraBars.Docking.DockManager dockManager;
        private DevExpress.XtraNavBar.NavBarControl navBar;
        private DevExpress.XtraBars.Navigation.OfficeNavigationBar officeNavigationBar;
        private DevExpress.LookAndFeel.DefaultLookAndFeel UserLookAndFeel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem biNewDepartment;
        private DevExpress.XtraBars.BarButtonItem biSystemSetting;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSystem;
        private DevExpress.XtraBars.BarButtonItem biSetAdminPin;
        private DevExpress.XtraBars.BarButtonItem biNewWorkShift;
        private DevExpress.XtraBars.BarButtonItem biEmployeesType;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem bbiJobCode;
        private DevExpress.XtraBars.BarButtonItem bbiExportSetting;
        private DevExpress.XtraBars.BarButtonItem biAbout;
        private DevExpress.XtraBars.BarButtonItem bbiCompanyDataSetting;
        private DevExpress.XtraBars.BarButtonItem bbiExportMannual;
        private DevExpress.XtraBars.BarButtonItem bbiChangeLang;
        private DevExpress.XtraBars.BarButtonItem bbiSyncSet;
        private DevExpress.XtraBars.BarButtonItem bbiDatabaseMaintenance;
        private DevExpress.XtraBars.BarButtonItem bbiLiftControl;
    }
}

