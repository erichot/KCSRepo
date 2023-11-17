using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.DevAV;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using KCS.Services;
using KCS.Common.Utils;
using System.ComponentModel;
using KCS.Models;

namespace KCS.ViewModels
{



    public class MainViewModel 
    {
        SetAdminViewModel setAdminViewModel;
        #region static
        static MainViewModel()
        {
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new Services.ModuleResourceProvider());
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new Services.ModuleTypesResolver());
        }
        #endregion static
        protected MainViewModel(IMainModule mainModule)
        {
            RegisterServices(mainModule);
            setAdminViewModel = SetAdminViewModel.Create();
            setAdminViewModel.SetParentViewModel(this);
        }
        void RegisterServices(IMainModule mainModule)
        {
            var mainModuleType = mainModule.GetType();
            ISupportServices localServices = (ISupportServices)this;
            localServices.ServiceContainer.RegisterService(new Services.WaitingService());
            localServices.ServiceContainer.RegisterService(new Services.ModuleActivator(mainModuleType.Assembly, mainModuleType.Namespace + ".Views"));
            localServices.ServiceContainer.RegisterService(new Services.ReportActivator());
            localServices.ServiceContainer.RegisterService(new Services.ModuleLocator(localServices.ServiceContainer));
            localServices.ServiceContainer.RegisterService(new Services.ReportLocator(localServices.ServiceContainer));
            localServices.ServiceContainer.RegisterService(new Services.TransitionService(mainModule));
            localServices.ServiceContainer.RegisterService(new Services.WorkspaceService(mainModule));
        }
        protected IDialogService DialogService
        {
            get { return this.GetService<IDialogService>(); }
        }
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }
        //private void UpdateAdminPinMethod()
        //{
        //}
        void OnSetAdmin(MessageResult result)
        {
            if (result == MessageResult.OK)
            {
                setAdminViewModel.SetAdministratorPIN();
            }

            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            * Add:  2023/08/09
            * Ver:  1.1.5.11
            */
            if (KCS.Common.DAL.SystemConfigure.IsForceToChangePassword == true)
            {
                System.Environment.Exit(0);
            }
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
        #region Properties
        public virtual ModuleType SelectedModuleType
        {
            get;
            set;
        }
        public virtual object SelectedModule
        {
            get;
            set;
        }
        public ModuleType SelectedNavPaneModuleType
        {
            get { return GetNavPaneModuleType(SelectedModuleType); }
        }
        public ModuleType SelectedPeekModuleType
        {
            get { return GetPeekModuleType(SelectedModuleType); }
        }
        public ModuleType SelectedNavPaneHeaderModuleType
        {
            get { return GetNavPaneModuleType(SelectedModuleType, true); }
        }
        public ModuleType SelectedExportModuleType
        {
            get { return GetExportModuleType(SelectedModuleType); }
        }
        public ModuleType SelectedPrintModuleType
        {
            get { return GetPrintModuleType(SelectedModuleType); }
        }
        public object SelectedModuleViewModel
        {
            get { return ((Views.ISupportViewModel)SelectedModule).ViewModel; }
        }
        
        #endregion Properties
        #region Commands
        public bool CanSelectModule(ModuleType moduleType)
        {
            return SelectedModuleType != moduleType;
        }
        [Command]
        public void SelectModule(ModuleType moduleType)
        {
            SelectedModuleType = moduleType;
        }
        [Command]
        public void SystemSetting()
        {
        }
        
        public void EmployeesTypeView()
        {
            //DialogService.ShowDialog(MessageButton.OK, "Employees Type Setting", "EmployeedTypeSet", EmployeedTypeSetViewModel.Create());

            var document = DocumentManagerService.CreateDocument("EmployeeTypeSet", EmployeeTypeSetViewModel.Create());
            document.Show();
        }
        public void ElevatorControl()
        {
            var document = DocumentManagerService.CreateDocument("ElevatorControl", ElevatorControlViewModel.Create());
            document.Show();
        }
        public void ExportDatasMannual()
        {
            
            var document = DocumentManagerService.CreateDocument("ExportDatas", ExportDatasViewModel.Create());
            document.Show();
            //ExportDatasViewModel exportDatasSet = ExportDatasViewModel.Create();
            //if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("ExportDataMannual"), "ExportDatas", exportDatasSet))
            //{
            //    IList<TaTransaction>  readTrans = KCS.Models.TransactionDataSource.GetTaTransactionsList(KCS.Common.DAL.SystemConfigure.slavesList, string.Format("{0} {1}", exportDatasSet.StartDate.ToShortDateString(), exportDatasSet.StartTime.ToString("HH:mm")), string.Format("{0} {1}", exportDatasSet.EndDate.ToShortDateString(), exportDatasSet.EndTime.ToString("HH:mm")));
            //}
        }
        public void About()
        {
            PopHintDialog.ShowMessage(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }
        [Command]
        public void SetAdminPin()
        {


            //UICommand OkCommand = new UICommand()
            //{
            //    Id = MessageResult.OK,
            //    Caption = "确定",
            //    IsCancel = false,
            //    IsDefault = false,

            //};
            //UICommand cancelCommand = new UICommand()
            //{
            //    Id = MessageResult.Cancel,
            //    Caption = "Cancel",
            //    IsCancel = true,
            //    IsDefault = false,
            //};
            
            OnSetAdmin(DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("SetAdminPinCapiton"), "SetAdmin", setAdminViewModel));
        }
        
        #endregion
        #region FiltersVisibility
        public virtual bool IsReadingMode { get; set; }
        [Command]
        public void TurnOnReadingMode()
        {
            IsReadingMode = true;
        }
        public bool CanTurnOnReadingMode()
        {
            return !IsReadingMode;
        }
        [Command]
        public void TurnOffReadingMode()
        {
            IsReadingMode = false;
        }
        public bool CanTurnOffReadingMode()
        {
            return IsReadingMode;
        }
        public virtual CollectionViewFiltersVisibility FiltersVisibility { get; set; }
        [Command]
        public void ShowFilters()
        {
            FiltersVisibility = CollectionViewFiltersVisibility.Visible;
        }
        public bool CanShowFilters()
        {
            return FiltersVisibility != CollectionViewFiltersVisibility.Visible;
        }
        [Command]
        public void MinimizeFilters()
        {
            FiltersVisibility = CollectionViewFiltersVisibility.Minimized;
        }
        public bool CanMinimizeFilters()
        {
            return FiltersVisibility != CollectionViewFiltersVisibility.Minimized;
        }
        [Command]
        public void HideFilters()
        {
            FiltersVisibility = CollectionViewFiltersVisibility.Hidden;
        }
        public bool CanHideFilters()
        {
            return FiltersVisibility != CollectionViewFiltersVisibility.Hidden;
        }
        public event EventHandler IsReadingModeChanged;
        protected virtual void OnIsReadingModeChanged()
        {
            this.RaiseCanExecuteChanged(x => x.TurnOnReadingMode());
            this.RaiseCanExecuteChanged(x => x.TurnOffReadingMode());
            RaiseIsReadingModeChanged();
        }
        void RaiseIsReadingModeChanged()
        {
            EventHandler handler = IsReadingModeChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        public event EventHandler ViewFiltersVisibilityChanged;
        protected virtual void OnFiltersVisibilityChanged()
        {
            this.RaiseCanExecuteChanged(x => x.ShowFilters());
            this.RaiseCanExecuteChanged(x => x.MinimizeFilters());
            this.RaiseCanExecuteChanged(x => x.HideFilters());
            RaiseFiltersVisibilityChanged();
        }
        void RaiseFiltersVisibilityChanged()
        {
            EventHandler handler = ViewFiltersVisibilityChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion
        bool IsModuleLoaded(ModuleType type)
        {
            return this.GetService<Services.IModuleLocator>().IsModuleLoaded(type);
        }
        public object GetModule(ModuleType type)
        {
            return this.GetService<Services.IModuleLocator>().GetModule(type);
        }
        
        public object GetModule(ModuleType type, object viewModel)
        {
            return this.GetService<Services.IModuleLocator>().GetModule(type, viewModel);
        }
        public string GetModuleName(ModuleType type)
        {
            return this.GetService<Services.IModuleTypesResolver>().GetName(type);
        }
        public System.Guid GetModuleID(ModuleType type)
        {
            return this.GetService<Services.IModuleTypesResolver>().GetId(type);
        }
        public string GetModuleCaption(ModuleType type)
        {
            return this.GetService<Services.IModuleResourceProvider>().GetCaption(type);
        }
        public object GetModuleSmallImage(ModuleType type)
        {
            return this.GetService<Services.IModuleResourceProvider>().GetModuleImage(type, true);
        }
        public object GetModuleImage(ModuleType type)
        {
            return this.GetService<Services.IModuleResourceProvider>().GetModuleImage(type);
        }
        public ModuleType GetMainModuleType(ModuleType type)
        {
            return this.GetService<Services.IModuleTypesResolver>().GetMainModuleType(type);
        }
        public ModuleType GetNavPaneModuleType(ModuleType type, bool collapsed = false)
        {
            var resolver = this.GetService<Services.IModuleTypesResolver>();
            return collapsed ? resolver.GetNavPaneHeaderModuleType(type) : resolver.GetNavPaneModuleType(type);
        }
        public ModuleType GetPeekModuleType(ModuleType type)
        {
            return this.GetService<Services.IModuleTypesResolver>().GetPeekModuleType(type);
        }
        public ModuleType GetExportModuleType(ModuleType type)
        {
            return this.GetService<Services.IModuleTypesResolver>().GetExportModuleType(type);
        }
        public ModuleType GetPrintModuleType(ModuleType type)
        {
            return this.GetService<Services.IModuleTypesResolver>().GetPrintModuleType(type);
        }
        
        #region Selected Module
        protected virtual void OnSelectedModuleTypeChanged(ModuleType oldType)
        {
            var transitionService = this.GetService<Services.ITransitionService>();
            bool effective = (SelectedModuleType != ModuleType.Unknown) && (oldType != ModuleType.Unknown);
            object waitParameter = !IsModuleLoaded(SelectedModuleType) ? (object)SelectedModuleType : null;
            using (transitionService.EnterTransition(effective, ((int)SelectedModuleType > (int)oldType), waitParameter))
            {
                var workspaceService = this.GetService<Services.IWorkspaceService>();
                var resolver = this.GetService<IModuleTypesResolver>();
                if (oldType != ModuleType.Unknown)
                    workspaceService.SaveWorkspace(resolver.GetName(oldType));
                else
                    workspaceService.SetupDefaultWorkspace();
                try
                {
                    SelectedModule = GetModule(SelectedModuleType);
                    RaiseSelectedModuleTypeChanged();
                }
                catch (Exception e)
                {
                    var entryAsm = System.Reflection.Assembly.GetEntryAssembly();
                    string msg = "Navigation Error: [" + oldType.ToString() + "=>" + SelectedModuleType.ToString() + Environment.NewLine +
                        (entryAsm != null ? "StartUp:" + entryAsm.Location : string.Empty);
                    throw new ApplicationException(msg, e);
                }
                if (SelectedModuleType != ModuleType.Unknown)
                    workspaceService.RestoreWorkspace(resolver.GetName(SelectedModuleType));
            }
        }
        protected virtual void OnSelectedModuleChanged(object oldModule)
        {
            if (oldModule != null)
            {
                if (ModuleRemoved != null)
                    ModuleRemoved(oldModule, EventArgs.Empty);
            }
            if (SelectedModuleChanged != null)
                SelectedModuleChanged(this, EventArgs.Empty);
            if (SelectedModule != null)
            {
                ViewModelHelper.EnsureModuleViewModel(SelectedModule, this);
                if (ModuleAdded != null)
                    ModuleAdded(SelectedModule, EventArgs.Empty);
            }
        }
        protected virtual void RaiseSelectedModuleTypeChanged()
        {
            this.RaiseCanExecuteChanged(x => x.SelectModule(ModuleType.Unknown));
            this.RaisePropertyChanged(x => SelectedNavPaneModuleType);
            this.RaisePropertyChanged(x => SelectedNavPaneHeaderModuleType);
            if (SelectedModuleTypeChanged != null)
                SelectedModuleTypeChanged(this, EventArgs.Empty);
        }
        public event EventHandler ModuleAdded;
        public event EventHandler ModuleRemoved;
        public event EventHandler SelectedModuleChanged;
        public event EventHandler SelectedModuleTypeChanged;
        #endregion Selected Module
        #region Print & Reports
        public event EventHandler<PrintEventArgs> Print;
        public object ReportParameter { get; private set; }
        ModuleType currentReportModule;
        internal void BeforeReportShown(ModuleType moduleType)
        {
            if (ReportParameter != null)
                return;
            //switch (moduleType)
            //{
            //        break;
            //}
        }
        internal void AfterReportShown(ModuleType moduleType)
        {
            //if (currentReportModule != moduleType)
            //{
            //    bool reportChanged = currentReportModule != ModuleType.Unknown;
            //    this.currentReportModule = moduleType;
            //    if (reportChanged && moduleType != ModuleType.Unknown)
            //    {
            //        var reportViewModel = ((Views.ISupportViewModel)GetModule(moduleType)).ViewModel as ReportViewModelBase;
            //        if (reportViewModel != null)
            //            reportViewModel.OnReload();
            //    }
            //}
        }
        internal void AfterReportHidden()
        {
            this.currentReportModule = ModuleType.Unknown;
            ReportParameter = null;
        }
        internal void RaisePrint(object parameter)
        {
            ReportParameter = parameter;
            EventHandler<PrintEventArgs> handler = Print;
            if (handler != null)
                handler(this, new PrintEventArgs(parameter));
        }
        #endregion Print & Reports
        public event EventHandler ShowAllFolders;
        internal void RaiseShowAllFolders()
        {
            EventHandler handler = ShowAllFolders;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        
    }
    public class PrintEventArgs : EventArgs
    {
        public PrintEventArgs(object parameter)
        {
            this.Parameter = parameter;
        }
        public object Parameter { get; private set; }
    }
}
