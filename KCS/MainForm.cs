using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Taskbar;
using DevExpress.Utils.Taskbar.Core;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraNavBar;
using KCS.ViewModels;
using KCS.Views;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using KCS.Common.Utils;
using KCS.Common.DAL;
using System.Reflection;
using KCS.Sync;
using KCS.Form;

namespace KCS
{
    public partial class MainForm : RibbonForm, IMainModule, ISupportViewModel
    {

        ModuleType moduleType = ModuleType.Supervisor;
        public MainForm()
        {
            
            TaskbarHelper.InitDemoJumpList(TaskbarAssistant.Default, this);
            DevExpressLocalizerHelper.DevExpressLocalizer();
            AppHelper.MainForm = this;
            //LanguageResource lag = new LanguageResource();
            //lag.CreateLanuageFile();
            //StartUpProcess.OnStart("When Only the Best Will Do");
            
            
            new LanguageResource(SystemConfigure.LanguageSelect);
            if (!SystemConfigure.DataBaseConfigureIsValidOrNot())
            {
                FormDbServerSet frmServerSet = new FormDbServerSet();
                frmServerSet.ShowDialog();
                if (!SystemConfigure.DataBaseConfigureIsValidOrNot())
                {
                    System.Environment.Exit(0);
                }
            }
            int try_times = 0;
        NEXT_TRY:
            try
            {
                bool bRet = SQLDataProvider.CheckDatabaseIsValidOrNot();
                if (!bRet)
                {
                    PopHintDialog.ShowMessage("Invalid Database,please configure it first!");
                }
            }
            catch (Exception ex)
            {
                PopHintDialog.ShowErrorMessage(ex.Message);
                try_times++;
                if (try_times >= 2)
                {
                    System.Environment.Exit(0);
                }
                FormDbServerSet frmServerSet = new FormDbServerSet();
                frmServerSet.ShowDialog();

                goto NEXT_TRY;

            }
            FormLogin formLogin = new FormLogin();
            formLogin.ShowDialog();//显示登陆窗体  
            if (formLogin.DialogResult != DialogResult.OK)
            {
                /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                * Modified: 2023/08/09
                * Ver:      1.1.5.11
                * System.Environment.Exit(0);
                */
                
                if (formLogin.DialogResult == DialogResult.Retry)
                {
                    KCS.Common.DAL.SystemConfigure.IsForceToChangePassword = true;                    
                }
                else
                {
                    System.Environment.Exit(0);
                }
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
            InitializeComponent();
            StartUpProcess.OnRunning(LanguageResource.GetDisplayString("ProcessBarInit"));
            //Icon = AppHelper.AppIcon;
            mvvmContext.ViewModelConstructorParameter = this;
           ViewModel.ModuleAdded += viewModel_ModuleAdded;
            ViewModel.ModuleRemoved += viewModel_ModuleRemoved;
           // ViewModel.SelectedModuleTypeChanged += viewModel_SelectedModuleTypeChanged;
            
            ribbonControl.MinimizedChanged += Ribbon_MinimizedChanged;
            ribbonControl.ForceInitialize();
             officeNavigationBar.SynchronizeNavigationClientSelectedItem += officeNavigationBar_SynchronizeNavigationClientSelectedItem;
           
            //navBar.ActiveGroupChanged += navBar_ActiveGroupChanged;
           
            BindFiltersVisibility();
            BindCommands();
            UserLookAndFeel.LookAndFeel.SetSkinStyle("Office 2010 Blue");
           DevExpress.Utils.About.UAlgo.Default.DoEventObject(DevExpress.Utils.About.UAlgo.kDemo, DevExpress.Utils.About.UAlgo.pWinForms, this);
           this.outlookBehavior = new OutlookReadingModeBehavior(navBar, officeNavigationBar);
            
        }
        protected override DevExpress.XtraEditors.FormShowMode ShowMode
        {
            get { return DevExpress.XtraEditors.FormShowMode.AfterInitialization; }
        }
        void BindCommands()
        {
            // 影響Command_Click
            //biSetAdminPin.BindCommand(() => ViewModel.SetAdminPin(), ViewModel);
            mvvmContext.BindCommand<MainViewModel>(biSetAdminPin, x => x.SetAdminPin());           
            mvvmContext.BindCommand<MainViewModel>(biEmployeesType, x => x.EmployeesTypeView());            
            mvvmContext.BindCommand<MainViewModel>(biAbout, x => x.About());
            mvvmContext.BindCommand<MainViewModel>(bbiExportMannual, x => x.ExportDatasMannual());
            mvvmContext.BindCommand<MainViewModel>(bbiLiftControl, x => x.ElevatorControl());
            
            //mvvmContext.BindCommand<MainViewModel>(biSystemSetting, x => x.SystemSetting());
            biSystemSetting.ItemClick += (s, e) =>
                {
                    FormDbServerSet frmServerSet = new FormDbServerSet();
                    frmServerSet.ShowDialog();
                    if (frmServerSet.DialogResult == DialogResult.OK)
                    {
                        if (SystemConfigure.DataBaseConfigureIsValidOrNot())
                        {
                            try
                            {
                                Application.Restart();
                            }
                            catch { }
                        }
                    }
                };
            bbiCompanyDataSetting.ItemClick += (s, e) =>
            {
                XtraFormCompanyData frmExportTextSet = new XtraFormCompanyData();
                frmExportTextSet.ShowDialog();
            };
            bbiExportSetting.ItemClick += (s, e) =>
                {
                    ExportTextSet frmExportTextSet = new ExportTextSet();
                    frmExportTextSet.ShowDialog();
                };
            bbiChangeLang.ItemClick += (s, e) =>
            {
                FormLangSelect frmFormLangSelect = new FormLangSelect();
                frmFormLangSelect.ShowDialog();
            };
            bbiSyncSet.ItemClick += (s, e) =>
            {
                FormSyncSet frmFormSyncSet = new FormSyncSet();
                frmFormSyncSet.ShowDialog();
            };
            bbiDatabaseMaintenance.ItemClick += (s, e) =>
            {
                FormDatabaseMaintenance frmDbMaintenance = new FormDatabaseMaintenance();
                frmDbMaintenance.ShowDialog();
            };
           
        }  
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            
            //ViewModel.SelectedModuleType = ModuleType.SupervisorManage;
            //var types = new ModuleType[] { ModuleType.Supervisor, ModuleType.DeviceSetting, ModuleType.Employees, ModuleType.AccessControl, ModuleType.TimeAttendance };

            // Modified:  2023/10/16
            // Ver:     1.1.5.12
            var userPermissionTypeID = KCS.Models.CredentialsSource.GetLoginSupervisorUserPermissionTypeID();
            ModuleType[] types;
            if (userPermissionTypeID == 99)
            {
                ViewModel.SelectedModuleType = ModuleType.SupervisorManage;
                types = new ModuleType[] { ModuleType.Supervisor, ModuleType.DeviceSetting, ModuleType.Employees, ModuleType.AccessControl, ModuleType.TimeAttendance };
                
            }
            else
            {
                //ViewModel.SelectedModuleType = ModuleType.Employees;
                //types = new ModuleType[] { ModuleType.Employees, ModuleType.AccessControl, ModuleType.TimeAttendance };
                //ViewModel.SelectedModuleType = ModuleType.SupervisorManage;
                types = new ModuleType[] {  ModuleType.DeviceSetting, ModuleType.Employees, ModuleType.AccessControl, ModuleType.TimeAttendance };
            }


            RegisterNavPanes(navBar, types);

            //ribbonPageGroupNew.Text = LanguageResource.GetDisplayString("ToolBarGroupNew");
            KCS.Models.CreateTaDataBase.CreateTimeAttendanceDataBase();
            SyncManage.InitAccessParameters();
            if( SystemConfigure.IsDisSyncDataOrNot != 1 )
            SyncManage.InitDataSync();

            // ----------------------------------------------
            // 可設定 UI Toolbar屬性
            // Ex:biSetAdminPin.Enabled = false;

            biEmployeesType.Caption = LanguageResource.GetDisplayString("ToolBarEmployeesType");
            
            ribbonPageGroupSystem.Text = LanguageResource.GetDisplayString("ToolBarGroupSystem");
            biSystemSetting.Caption = LanguageResource.GetDisplayString("ToolBarSystemSetting");
            biSetAdminPin.Caption = LanguageResource.GetDisplayString("ToolBarSetAdminPin");
            bbiExportSetting.Caption = LanguageResource.GetDisplayString("ToolBarExportSetting");
            biAbout.Caption = LanguageResource.GetDisplayString("AboutText");
            bbiCompanyDataSetting.Caption = LanguageResource.GetDisplayString("CompanyBasicData");
            bbiExportMannual.Caption = LanguageResource.GetDisplayString("ExportDataMannual");
            bbiSyncSet.Caption = LanguageResource.GetDisplayString("SyncSettings");
            bbiChangeLang.Caption = LanguageResource.GetDisplayString("ChangeLanguage");
            bbiDatabaseMaintenance.Caption = LanguageResource.GetDisplayString("ToolBarDatabaseMaintenance");
            bbiLiftControl.Caption = LanguageResource.GetDisplayString("LiftController");

            StartUpProcess.OnRunning(LanguageResource.GetDisplayString("ProcessBarFinish"));

            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            * Add:  2023/08/09
            * Ver:  1.1.5.11
            */
            if (KCS.Common.DAL.SystemConfigure.IsForceToChangePassword == true)
            {
                var sMsg = "You password has reached its age limit (250 days) and expired. Please change the password and log in again";
                DevExpress.XtraEditors.XtraMessageBox.Show(sMsg, "Password expiration policy");
                biSetAdminPin.PerformClick();
            }
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            StartUpProcess.OnComplete();
        }
        protected override void OnClosed(EventArgs e)
        {
            ViewModel.SelectedModuleType = ModuleType.Unknown;
            SyncManage.StopServerApplication();
            base.OnClosed(e);
        }
        
        OutlookReadingModeBehavior outlookBehavior;
        void viewModel_IsReadingModeChanged(object sender, EventArgs e)
        {
            this.outlookBehavior.ReadingMode = ViewModel.IsReadingMode;
        }
        void Ribbon_MinimizedChanged(object sender, EventArgs e)
        {
            UpdateCompactLayout(!ribbonControl.Minimized);
        }
        void UpdateCompactLayout(bool compact)
        {
            if (ViewModel.SelectedNavPaneModuleType != ModuleType.Unknown)
                UpdateCompactLayout(GetNavPaneModule(ViewModel.SelectedNavPaneModuleType) as ISupportCompactLayout, compact);
            if (ViewModel.SelectedNavPaneHeaderModuleType != ModuleType.Unknown)
                UpdateCompactLayout(GetNavPaneModule(ViewModel.SelectedNavPaneHeaderModuleType) as ISupportCompactLayout, compact);
        }
        void UpdateCompactLayout(ISupportCompactLayout module, bool compact)
        {
            if (module != null) module.Compact = compact;
        }
        
        public MainViewModel ViewModel
        {
            get { return mvvmContext.GetViewModel<MainViewModel>(); }
        }
        void viewModel_ModuleAdded(object sender, EventArgs e)
        {
            var moduleControl = sender as Control;
            moduleControl.Dock = DockStyle.Fill;
            moduleControl.Parent = modulesContainer;
            navBar.SendToBack();
            Text = string.Format("{1} - {0}", ViewModel.GetModuleCaption(ViewModel.SelectedModuleType), LanguageResource.GetDisplayString("KCSTitle"));
            IRibbonModule ribbonModuleControl = moduleControl as IRibbonModule;
            if (ribbonModuleControl != null)
            {
                Ribbon.MergeRibbon(ribbonModuleControl.Ribbon);
                Ribbon.StatusBar.MergeStatusBar(ribbonModuleControl.Ribbon.StatusBar);
            }
            else
            {
                Ribbon.UnMergeRibbon();
                Ribbon.StatusBar.UnMergeStatusBar();
            }
        }
        void viewModel_SelectedModuleTypeChanged(object sender, EventArgs e)
        {
            if (ViewModel.SelectedNavPaneModuleType != ModuleType.Unknown)
                navBar.ActiveGroup = GetNavBarGroup(ViewModel.SelectedNavPaneModuleType);
            UpdateCompactLayout(!ribbonControl.Minimized);
        }
        void viewModel_ModuleRemoved(object sender, EventArgs e)
        {
            var moduleControl = sender as Control;
            GridHelper.HideCustomization(moduleControl);
            moduleControl.Parent = null;
        }
        NavBarGroup  GetNavBarGroup(ModuleType navPaneModuleType) {
            return navBar.Groups
                .FirstOrDefault(g => object.Equals(g.Tag, navPaneModuleType));
        }
        NavBarGroup nGetNavBarGroup(ModuleType navPaneModuleType)
        {
            return navBar.Groups
                .FirstOrDefault(g => object.Equals(g.Tag, navPaneModuleType));
        }
        Control GetModule(ModuleType moduleType)
        {
            Control moduleControl = ViewModel.GetModule(moduleType) as Control;
            ViewModelHelper.EnsureModuleViewModel(moduleControl, ViewModel);
            return moduleControl;
        }
        Control GetNavPaneModule(ModuleType navPaneModuleType)
        {
            Control moduleControl = ViewModel.GetModule(navPaneModuleType, ViewModel.SelectedModuleViewModel) as Control;
            ViewModelHelper.EnsureModuleViewModel(moduleControl, ViewModel);
            return moduleControl;
        }
        #region ISupportViewModel
        object ISupportViewModel.ViewModel { get { return ViewModel; } }
        void ISupportViewModel.ParentViewModelAttached() { }
        #endregion
        #region Filters Visibility
        void BindFiltersVisibility()
        {
            navBar.NavPaneStateChanged += navBar_NavPaneStateChanged;
            ViewModel.ViewFiltersVisibilityChanged += ViewModel_ViewFiltersVisibilityChanged;
           
        }
        void navBar_NavPaneStateChanged(object sender, EventArgs e)
        {
            if (navBar.OptionsNavPane.NavPaneState == NavPaneState.Collapsed)
                ViewModel.FiltersVisibility = CollectionViewFiltersVisibility.Minimized;
            else
                ViewModel.FiltersVisibility = CollectionViewFiltersVisibility.Visible;
        }
        void ViewModel_ViewFiltersVisibilityChanged(object sender, System.EventArgs e)
        {
            switch (ViewModel.FiltersVisibility)
            {
                case CollectionViewFiltersVisibility.Visible:
                    navBar.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Expanded;
                    navBar.Visible = true;
                    break;
                case CollectionViewFiltersVisibility.Minimized:
                    navBar.OptionsNavPane.NavPaneState = DevExpress.XtraNavBar.NavPaneState.Collapsed;
                    navBar.Visible = true;
                    break;
                case CollectionViewFiltersVisibility.Hidden:
                    navBar.Visible = false;
                    break;
            }
        }
        #endregion
        #region Services
        #region Navigation Bar
        void RegisterNavPanes(NavBarControl navBar, ModuleType[] types)
        {

            var userPermissionTypeID = KCS.Models.CredentialsSource.GetLoginSupervisorUserPermissionTypeID();

            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            * Add:  2023/08/09
            * Ver:  1.1.5.11
            */
            var m_SupervisorIsReadOnly = KCS.Models.CredentialsSource.GetLoginSupervisorIsReadOnly();
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // 下方主選單功能表
            for (int i = 0; i < types.Length; i++)
            {

                var moduleType = ViewModel.GetNavPaneModuleType(types[i]);

                // Add: 2023/09/19  
                // Ver: 1.1.5.11
                if (
                    userPermissionTypeID == 99      // Admin
                    ||
                        (
                        moduleType != ModuleType.DeviceSetting
                        && moduleType != ModuleType.SupervisorManage
                        && moduleType != ModuleType.Supervisor
                        )
                    )
                {
                    RegisterNavPane(navBar, ViewModel.GetNavPaneModuleType(types[i]));
                }

            }


            if (userPermissionTypeID < 99)
            {
                //ribbonPage1.Visible = false;
                biSystemSetting.Visibility = BarItemVisibility.Never;
                bbiSyncSet.Visibility = BarItemVisibility.Never;
                biNewDepartment.Visibility = BarItemVisibility.Never;
                bbiExportMannual.Visibility = BarItemVisibility.Never;
                bbiExportSetting.Visibility = BarItemVisibility.Never;
                bbiChangeLang.Visibility = BarItemVisibility.Never;

                biSetAdminPin.Visibility = BarItemVisibility.Never;
                bbiSyncSet.Visibility = BarItemVisibility.Never;
                biSystemSetting.Visibility = BarItemVisibility.Never;
            }

            // Add:    2024/02/19
            // Ver:    1.1.5.17
            if (m_SupervisorIsReadOnly == true)
            {
                biSystemSetting.Enabled = false;
                bbiSyncSet.Enabled = false;
                biNewDepartment.Enabled = false;

                biSetAdminPin.Enabled = false;
                bbiSyncSet.Enabled = false;
                biSystemSetting.Enabled = false;

                bbiCompanyDataSetting.Enabled = false;
                bbiDatabaseMaintenance.Enabled = false;
                bbiLiftControl.Enabled = false;

                biEmployeesType.Enabled = false;
            }

            officeNavigationBar.RegisterItem += officeNavigationBar_RegisterItem;
            officeNavigationBar.NavigationClient = navBar;
        }
        void RegisterNavPane(NavBarControl navBar, ModuleType type)
        {
            NavBarGroup navGroup = new NavBarGroup();
            navGroup.Tag = type;
            navGroup.Name = "navGroup" + ViewModel.GetModuleName(type);
            navGroup.Caption = ViewModel.GetModuleCaption(type);
            //navGroup.SmallImage = (System.Drawing.Image)ViewModel.GetModuleSmallImage(type);
           // navGroup.GroupStyle = NavBarGroupStyle.ControlContainer;
            //navGroup.ControlContainer = new NavBarGroupControlContainer();
           // navBar.Controls.Add(navGroup.ControlContainer);
            navBar.Groups.Add(navGroup);
           
        }
        void RegisterNavItems(NavBarGroup navGroup, ModuleType type)
        {
           
            
            var fields = typeof(ModuleType).GetFields(BindingFlags.Static | BindingFlags.Public);
            navBar.BeginUpdate();
            foreach (var fi in fields)
            {
                ModuleType module = (ModuleType)Enum.Parse(typeof(ModuleType), fi.Name);
                if (module.GetGroupName() == ViewModel.GetModuleName(type))
                {
                    NavBarItem navItem = new NavBarItem();
                    navItem.Name = "navItem" + ViewModel.GetModuleName(module);
                    navItem.Caption = ViewModel.GetModuleCaption(module);
                    //navItem.Text = ViewModel.GetModuleCaption(module);

                    navGroup.ItemLinks.Add(navItem);
                    navItem.BindCommand((t) => ViewModel.SelectModule(t), ViewModel, () => module);
                }
            }
            navBar.EndUpdate();
        }
        void officeNavigationBar_RegisterItem(object sender, NavigationBarNavigationClientItemEventArgs e)
        {

            NavBarGroup navGroup = (NavBarGroup)e.NavigationItem;
            var type = ViewModel.GetMainModuleType((ModuleType)navGroup.Tag);
            e.Item.Tag = ViewModel.GetPeekModuleType(type);
            e.Item.Text = ViewModel.GetModuleCaption(type);
            e.Item.Name = "navItem" + ViewModel.GetModuleName(type);
            RegisterNavItems(navGroup, type);
            ////    e.Item.ShowPeekFormOnItemHover = DevExpress.Utils.DefaultBoolean.False;
            //e.Item.BindCommand((t) => ViewModel.SelectModule(t), ViewModel, () => type);
        }
        
        
        
        void officeNavigationBar_SynchronizeNavigationClientSelectedItem(object sender, NavigationBarNavigationClientSynchronizeItemEventArgs e)
        {
            //var peekModuleType = (ModuleType)e.Item.Tag;
            //if (ViewModel.SelectedPeekModuleType != peekModuleType)
            NavBarGroup navGroup = (NavBarGroup)e.NavigationItem;
            var type = ViewModel.GetMainModuleType((ModuleType)navGroup.Tag);

            if (type == ModuleType.DeviceSetting && moduleType == ModuleType.Employees)
            {
                //SyncManage.RefreshDeviceSyncStatus();
            }

            moduleType = type;
            var peekModuleType = (ModuleType)Enum.Parse(typeof(ModuleType), ViewModel.GetModuleName(type) + "Manage");
                ViewModel.SelectedModuleType = ViewModel.GetMainModuleType(peekModuleType);
               
        }
        void navBar_ActiveGroupChanged(object sender, NavBarGroupEventArgs e)
        {
            var navPaneModuleType = (ModuleType)e.Group.Tag;
            Control moduleControl = GetNavPaneModule(navPaneModuleType);
            moduleControl.Dock = DockStyle.Fill;
            e.Group.ControlContainer.Controls.Add(moduleControl);

            var collapsedGroupModuleType = ViewModel.GetNavPaneModuleType(navPaneModuleType, true);
            e.Group.CollapsedNavPaneContentControl = GetNavPaneModule(collapsedGroupModuleType);
        }
        #endregion Navigation Bar
        void ISupportTransitions.StartTransition(bool forward, object waitParameter)
        {
            var transition = transitionManager.Transitions[modulesContainer];
            var animator = transition.TransitionType as DevExpress.Utils.Animation.SlideFadeTransition;
            animator.Parameters.EffectOptions = forward ? DevExpress.Utils.Animation.PushEffectOptions.FromRight : DevExpress.Utils.Animation.PushEffectOptions.FromLeft;
            if (waitParameter == null)
                transition.ShowWaitingIndicator = DevExpress.Utils.DefaultBoolean.False;
            else
            {
                transition.ShowWaitingIndicator = DevExpress.Utils.DefaultBoolean.True;
                transition.WaitingIndicatorProperties.Caption = LanguageResource.GetDisplayString("PleaseWait");//DevExpress.XtraEditors.EnumDisplayTextHelper.GetDisplayText(waitParameter);
                transition.WaitingIndicatorProperties.Description = LanguageResource.GetDisplayString("Loading") + "...";
                transition.WaitingIndicatorProperties.ContentMinSize = new System.Drawing.Size(160, 0);
            }
            transitionManager.StartTransition(modulesContainer);
        }
        void ISupportTransitions.EndTransition()
        {
            transitionManager.EndTransition();
        }
        void ISupportModuleLayout.SaveLayoutToStream(MemoryStream ms)
        {
            dockManager.SaveLayoutToStream(ms);
        }
        void ISupportModuleLayout.RestoreLayoutFromStream(MemoryStream ms)
        {
            dockManager.RestoreLayoutFromStream(ms);
        }


        #endregion Services

      
    }

    
}
