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

namespace KCS.Views
{
    public partial class DepartmentSet : BaseViewControl, IRibbonModule
    {
        public DepartmentSet()
            : base(typeof(DepartmentSetViewModel))
        {
            InitializeComponent();
        }
        public DepartmentSetViewModel ViewModel
        {
            get { return GetViewModel<DepartmentSetViewModel>(); }
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
        void InitViewDisplay()
        {
            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
            biEdit.Caption = LanguageResource.GetDisplayString("ToolBarEdit");
            biDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
             biNewDepartment.Caption = LanguageResource.GetDisplayString("ToolNewDepartment");

             this.colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentId");
             this.colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");

             ItemForDepartmentID.Text = LanguageResource.GetDisplayString("DepartmentId");
             ItemForDepartmentName.Text = LanguageResource.GetDisplayString("DepartmentName");
        }
        void RebindDataSource()
        {
            var fluentAPI = mvvmContext.OfType<DepartmentSetViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                   x => x.DepartmentDataSet);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KCS Error");
            }
        }
        void RebindData()
        {
            var fluentAPI = mvvmContext.OfType<DepartmentSetViewModel>();

            fluentAPI.SetBinding(DepartmentIDTextEdit, x => x.EditValue, x => x.SelectedDepartmentCopy.DepartmentID);
            fluentAPI.SetBinding(DepartmentNameTextEdit, x => x.EditValue, x => x.SelectedDepartmentCopy.DepartmentName);
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<DepartmentSetViewModel>();

            Messenger.Default.Register<UpdateCountMessage<DepartmentSetViewModel>>(this, UpdateEntitiesCountRelatedUI);
            Messenger.Default.Register<RebindMessage<DepartmentSetViewModel>>(this, x => RebindDataSource());
            Messenger.Default.Register<BindDataMessage<DepartmentSetViewModel>>(this, x => RebindData());
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                    x => x.DepartmentDataSet);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KCS Error");
            }
            fluentAPI.ViewModel.InitObject();
           
            


            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedDepartment,
                    args => args.Row as Department,
                    (gView, department) => gView.FocusedRowHandle = gView.FindRow(department));

            //fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
            //            .EventToCommand(
            //                x => x.Edit(null), x => x.SelectedSupervisor,
            //                args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));

            gridView.RowClick += (s, e) =>
            {
                if (e.Clicks == 1 && e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    popupMenu.ShowPopup(gridControl.PointToScreen(e.Location), s);
                }
            };
            gridView.RowClick += (s, e) =>
            {
                if (e.Clicks == 1 && e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    DepartmentIDTextEdit.Properties.ReadOnly = true;
                    DepartmentNameTextEdit.Properties.ReadOnly = true;
                    ItemBtnSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            };

            biNewDepartment.ItemClick += (s, e) =>
            {
                DepartmentIDTextEdit.Properties.ReadOnly = false;
                DepartmentNameTextEdit.Properties.ReadOnly = false;
                ItemBtnSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                
            };
            biEdit.ItemClick += (s, e) =>
            {
                DepartmentIDTextEdit.Properties.ReadOnly = true;
                DepartmentNameTextEdit.Properties.ReadOnly = false;
                ItemBtnSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                
            };
            btnSave.Click += (s, e) =>
            {

                DepartmentIDTextEdit.Properties.ReadOnly = true ;
                DepartmentNameTextEdit.Properties.ReadOnly = true;
                ItemBtnSave.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            };
            fluentAPI.BindCommand(biDelete, x => x.Delete(null), x => x.SelectedDepartment);
            fluentAPI.BindCommand(biNewDepartment, x => x.NewDepartment());
            fluentAPI.BindCommand(biEdit, x => x.Edit(null), x => x.SelectedDepartment);
            fluentAPI.BindCommand(btnSave, x => x.Save());
            //fluentAPI.BindCommand(barButtonNewSupervisor, x => x.NewSupervisor());
            //fluentAPI.BindCommand(biSetPassword, x => x.SetPassword(null), x => x.SelectedSupervisor);
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<DepartmentSetViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);        
        }
       
        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion

    }
}
