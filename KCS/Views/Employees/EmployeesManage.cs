using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.ViewModels;
using KCS.Common.Utils;
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using KCS.Models;
using DevExpress.Data;
using DevExpress.Utils.MVVM;
using DevExpress.Utils.MVVM.Services;

namespace KCS.Views
{
    public partial class EmployeesManage : BaseViewControl, IRibbonModule
    {
        public EmployeesManage()
            : base(typeof(EmployeeViewModel))
        {
            InitializeComponent();
        }
        public EmployeeViewModel ViewModel
        {
            get { return GetViewModel<EmployeeViewModel>(); }
        }
       
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);           
           
        }
        protected override void OnLoad(System.EventArgs e)
        {
            
            base.OnLoad(e);
            gridControl.Load += gridControl_Load;
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();
            
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<EmployeeViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }
        void InitViewDisplay()
        {
            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
            ribbonPageGroupFinger.Text = LanguageResource.GetDisplayString("ToolBarGroupFinger");
            ribbonPageGroupSync.Text = LanguageResource.GetDisplayString("ToolBarGroupSync");

            biEdit.Caption = LanguageResource.GetDisplayString("ToolBarEdit");
            biDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");            
            biNew.Caption = LanguageResource.GetDisplayString("ToolBarNewEmployee");
            //biEmployeesType.Caption = LanguageResource.GetDisplayString("ToolBarEmployeesType");
            //bbiJobCode.Caption = LanguageResource.GetDisplayString("ToolBarJobCode");
            bbiDisableUser.Caption = LanguageResource.GetDisplayString("ToolBarDisableEmployee");
            bbiEnableEmployees.Caption = LanguageResource.GetDisplayString("ToolBarEnableEmployee");
            bbiSetAcPara.Caption = LanguageResource.GetDisplayString("ToolBarSetAcPara");
            bbiImportEmployees.Caption = LanguageResource.GetDisplayString("ToolBarImportEmployee");
            bbiExportUser.Caption = LanguageResource.GetDisplayString("ToolBarExportEmployee");
            bbiDelFinger1.Caption = LanguageResource.GetDisplayString("ToolBarDeleteFinger1");
            bbiDelFinger2.Caption = LanguageResource.GetDisplayString("ToolBarDeleteFinger2");
            bbiDelFinger12.Caption = LanguageResource.GetDisplayString("ToolBarDeleteFinger12");
            bbiSyncReSync.Caption = LanguageResource.GetDisplayString("ToolBarReSyncAll");
            bbiReSyncSelect.Caption = LanguageResource.GetDisplayString("ToolBarReSyncSelectd");
            bbiSyncSetting.Caption = LanguageResource.GetDisplayString("ToolBarSyncSetting");
            bbiForceDelete.Caption = LanguageResource.GetDisplayString("ToolBarForceDelete");
            bbiChangeCardId.Caption = LanguageResource.GetDisplayString("ToolBarChangeCardId");
            //bbiImportUserPhotos.Caption = LanguageResource.GetDisplayString("ToolBarImportEmployeesPhotos");

            this.ItemForUserSID.Text = this.colUserSID.Caption = LanguageResource.GetDisplayString("SystemCode");
            this.ItemForUserID.Text = this.colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            this.ItemForDepListField.Text = this.colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");
            this.ItemForUserName.Text = this.colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            this.ItemForCardID.Text = this.colCardID.Caption = LanguageResource.GetDisplayString("CardID");
            this.ItemForTitleName.Text = this.colTitleName.Caption = LanguageResource.GetDisplayString("TitleName");
            this.ItemForInActive.Text = this.colInActive.Caption = LanguageResource.GetDisplayString("InActive");
            this.ItemForEmail.Text = this.colEmail.Caption = LanguageResource.GetDisplayString("Email");
            this.ItemForSyncOrNot.Text = this.colSyncOrNot.Caption = LanguageResource.GetDisplayString("SyncOrNot");
            this.ItemForEmpTypeListField.Text = colEmployeeTypeName.Caption = LanguageResource.GetDisplayString("ToolBarEmployeesType");
            this.colFinger1Status.Caption = LanguageResource.GetDisplayString("Finger1Status");
            this.colFinger2Status.Caption = LanguageResource.GetDisplayString("Finger2Status");
            


        }
        void RebindDataSource()
        {
            

            var fluentAPI = mvvmContext.OfType<EmployeeViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                   x => x.EmployeesDataSet);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KCS Error");
            }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<EmployeeViewModel>();
            MVVMContext.RegisterFlyoutMessageBoxService();
            Messenger.Default.Register<UpdateCountMessage<EmployeeViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));
            Messenger.Default.Register<RebindMessage<EmployeeViewModel>>(this, x => RebindDataSource());
            fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.EmployeesDataSet);

            mvvmContext.RegisterService(NotificationService.Create(alertControl));
            //
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEmployee,
                    args => args.Row as Employees,
                    (gView, employee) => gView.FocusedRowHandle = gView.FindRow(employee));
           
            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.Selection, e => GetSelectedEmployees());
            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                        .EventToCommand(
                            x => x.Edit(null), x => x.SelectedEmployee,
                            args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));

            gridView.RowClick += (s, e) =>
            {
                if (e.Clicks == 1 && e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    popupMenu.ShowPopup(gridControl.PointToScreen(e.Location), s);
                }
            };

            //fluentAPI.BindCommand(biEmployeesType,x => x.EmployeesTypeView());
            fluentAPI.BindCommand(biDelete, x => x.Delete(null), x => x.SelectedEmployee);
            fluentAPI.BindCommand(biEdit, x => x.Edit(null), x => x.SelectedEmployee);
            fluentAPI.BindCommand(biNew, x => x.New());
            fluentAPI.BindCommand(bbiForceDelete, x => x.ForceDelete(null), x => x.Selection);
            fluentAPI.BindCommand(bbiDelFinger1, x => x.DeleteFinger1(null), x => x.SelectedEmployee);
            fluentAPI.BindCommand(bbiDelFinger2, x => x.DeleteFinger2(null), x => x.SelectedEmployee);
            fluentAPI.BindCommand(bbiDelFinger12, x => x.DeleteFinger12(null), x => x.SelectedEmployee);

            fluentAPI.BindCommand(bbiDisableUser, x => x.DisableEmployees(null), x => x.Selection);
            fluentAPI.BindCommand(bbiEnableEmployees, x => x.EnableEmployees(null), x => x.Selection);

            fluentAPI.BindCommand(bbiSyncReSync, x => x.ReSyncAll());
            fluentAPI.BindCommand(bbiReSyncSelect, x => x.ReSyncSelect(null), x => x.SelectedEmployee);
            fluentAPI.BindCommand(bbiSyncSetting, x => x.SyncSetting(null), x => x.SelectedEmployee);

            fluentAPI.BindCommand(bbiExportUser, x => x.ExportEmployees());
            fluentAPI.BindCommand(bbiImportEmployees, x => x.ImportEmployees());

            //fluentAPI.BindCommand(bbiJobCode, x => x.JobCodeSet());
            fluentAPI.BindCommand(bbiSetAcPara, x => x.EmployeesAuthoritySet(null), x => x.Selection);
            fluentAPI.BindCommand(bbiAllowTimeReport, x => x.AllowTimeReport());

            fluentAPI.BindCommand(bbiChangeCardId, x => x.ChangeCardId(null), x => x.SelectedEmployee);
            //fluentAPI.BindCommand(bbiImportUserPhotos, x => x.ImportEmployeesPhotos());
            





        }
        IEnumerable<Employees> GetSelectedEmployees()
        {
            return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as Employees);
        }
        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion

       
    }
}
