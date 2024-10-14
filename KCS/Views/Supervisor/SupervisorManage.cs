using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.Views;
using KCS.Common.Utils;
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;
using DevExpress.XtraGrid.Views.Grid;
using KCS.Controls;
using DevExpress.XtraBars;
using KCS.ViewModels;
using DevExpress.Utils.MVVM;

namespace KCS.Views
{
    public partial class SupervisorManage : BaseViewControl, IRibbonModule
    {
        
        public SupervisorManage()
            : base(typeof(SupervisorViewModel))
        {
            InitializeComponent();
            
            
           
        }
       
        public SupervisorViewModel ViewModel
        {
            get { return GetViewModel<SupervisorViewModel>(); }
        }
        
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);           
           
        }
        protected override void OnLoad(System.EventArgs e)
        {
            
            base.OnLoad(e);
            gridControl.Load += gridControl_Load;
           // ViewModel.Reload += ViewModel_Reload;
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();
            
        }
        
        void InitViewDisplay()
        {
            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
            biEdit.Caption = LanguageResource.GetDisplayString("ToolBarEdit");
            biDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            biSetPassword.Caption = LanguageResource.GetDisplayString("ToolBarSetPassword");
            biNew.Caption = LanguageResource.GetDisplayString("ToolBarNewSupervisor");
            
            ItemForUserNO.Text = this.colUserID.Caption = LanguageResource.GetDisplayString("SupervisorViewId");
            ItemUserName.Text = this.colUserName.Caption = LanguageResource.GetDisplayString("SupervisorViewName");
            ItemEmail.Text = this.colEmail.Caption = LanguageResource.GetDisplayString("Email");
            ItemMobilePhone.Text = this.colPhoneMobile.Caption = LanguageResource.GetDisplayString("SupervisorViewPhone");
            ItemAdminType.Text = this.colUserPermissionTypeID.Caption = LanguageResource.GetDisplayString("SupervisorViewAdminType");
            readOnlyAuthority.Text = this.colEmployeeAuthority.Caption = LanguageResource.GetDisplayString("SupervisorViewAuth");
            ItemRemarks.Text = this.colNote.Caption = LanguageResource.GetDisplayString("RemarkText");
            ItemDepartment.Text = LanguageResource.GetDisplayString("Department");
            
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<SupervisorViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);        
        }
        string TranEmployeeUserPermission(object type)
        {
            if( type.Equals(null))
                return "";
            UserPermissionType employUserPermission = new UserPermissionType();
            return employUserPermission[int.Parse(type.ToString().Trim())];
        }
        string TranEmployeeAuthType(object type)
        {
            if (type.Equals(null))
                return "";
            EmployeeAuthority employAuth = new EmployeeAuthority();
            string text = employAuth[Convert.ToInt32(type)];
            return employAuth[Convert.ToInt32(type)];
        }
        void RebindDataSource()
        {
            var fluentAPI = mvvmContext.OfType<SupervisorViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                   x => x.SuperVisorDataSet);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KCS Error");
            }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<SupervisorViewModel>();
            MVVMContext.RegisterFlyoutMessageBoxService();

            Messenger.Default.Register<UpdateCountMessage<SupervisorViewModel>>(this, x=> UpdateEntitiesCountRelatedUI(x));
            Messenger.Default.Register<RebindMessage<SupervisorViewModel>>(this, x => RebindDataSource());
            fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.SuperVisorDataSet);

           
            gridView.CustomColumnDisplayText += (s, e) =>
                {
                    // gridView.CusColDisplayTextHelper(name => name.Equals("EmployeeAuthority"), TranEmployeeAuthType, e);
                    gridView.CusColDisplayTextHelper(name => name.Equals("UserPermissionTypeID"), TranEmployeeUserPermission, e);
                };

            //fluentAPI.SetTrigger(x => x.RecordCount, (count) =>
            //    {
            //        hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), count);
            //    });
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedSupervisor,
                    args => args.Row as EmployeeSupervisor,
                    (gView, supervisor) => gView.FocusedRowHandle = gView.FindRow(supervisor));

            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                        .EventToCommand(
                            x => x.Edit(null), x => x.SelectedSupervisor,
                            args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));

            gridView.RowClick += (s, e) =>
            {
                if (e.Clicks == 1 && e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    popupMenu.ShowPopup(gridControl.PointToScreen(e.Location), s);
                }
            };

            fluentAPI.SetTrigger(x => x.DisplayDeparment, (bDisplay) =>
                {
                    if (bDisplay)
                    {
                        ItemDepartment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    }
                    else
                    {
                        ItemDepartment.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    }
                });
            fluentAPI.BindCommand(biDelete, x => x.Delete(null), x => x.SelectedSupervisor);
            fluentAPI.BindCommand(biEdit, x => x.Edit(null), x => x.SelectedSupervisor);
            fluentAPI.BindCommand(biNew, x => x.NewSupervisor());
            fluentAPI.BindCommand(biSetPassword, x => x.SetPassword(null), x => x.SelectedSupervisor);

            // Add: 2024/08/11
            fluentAPI.BindCommand(biAutoLogon, x => x.SetAutoLogon(null));



        }
        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion

       
    }
}
