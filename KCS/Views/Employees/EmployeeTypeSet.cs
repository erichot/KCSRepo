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
using DevExpress.Mvvm;
using KCS.Common.Utils;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;

namespace KCS.Views
{
    public partial class EmployeeTypeSet : DevExpress.XtraEditors.XtraUserControl
    {
        public EmployeeTypeSet()
        {
            InitializeComponent();
        }

        protected override void OnLoad(System.EventArgs e)
        {
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            base.OnLoad(e);
           
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();

        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<EmployeeTypeSetViewModel>();
           
            Messenger.Default.Register<UpdateCountMessage<EmployeeTypeSetViewModel>>(this, UpdateEntitiesCountRelatedUI);
            Messenger.Default.Register<RebindMessage<EmployeeTypeSetViewModel>>(this, x => RebindDataSource());

            try
            {
            fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.SelectedEmployeesType);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceList,
                x => x.EmployeesTypeDataSet);
            }
            catch { }
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), fluentAPI.ViewModel.RecordCount);
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEmployeesType,
                    args => args.Row as EmployeesType,
                    (gView, employeeType) => gView.FocusedRowHandle = gView.FindRow(employeeType));

            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiSaveAndClose, x => x.SaveAndClose());
            fluentAPI.BindCommand(bbiSaveAndNew, x => x.SaveAndNew());
            fluentAPI.BindCommand(bbiReset, x => x.ResetChanges());
            fluentAPI.BindCommand(bbiDelete, x => x.Delete(null), x => x.SelectedEmployeesType);
            fluentAPI.BindCommand(bbiNew, x => x.New());

            gridView.RowClick += (s, e) =>
            {
                if (e.Clicks == 1 && e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    TypeIdTextEdit.Properties.ReadOnly = true;
                    ItemForInActive.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    
                }
            };
            bbiNew.ItemClick += (s, e) =>
            {
                TypeIdTextEdit.Properties.ReadOnly = false;
                ItemForInActive.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            };
        }
        void InitViewDisplay()
        {
            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupEdit.Text = LanguageResource.GetDisplayString("ToolBarGroupEdit");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiSaveAndClose.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndClose");
            bbiSaveAndNew.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndNew");
            bbiReset.Caption = LanguageResource.GetDisplayString("ToolBarReset");
            bbiDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            bbiNew.Caption = LanguageResource.GetDisplayString("ToolBarNew");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            ItemForTypeId.Text = LanguageResource.GetDisplayString("EmployeeTypeId");
            ItemForTypeName.Text = LanguageResource.GetDisplayString("EmployeeTypeName");
            ItemForInActive.Text = LanguageResource.GetDisplayString("InActive");
            ItemForEmployeeType.Text = LanguageResource.GetDisplayString("EmployeeType");

            colTypeId.Caption = LanguageResource.GetDisplayString("EmployeeTypeId");
            colTypeName.Caption = LanguageResource.GetDisplayString("EmployeeTypeName");
            colInActive.Caption = LanguageResource.GetDisplayString("InActive");
        }
        void RebindDataSource()
        {
            var fluentAPI = mvvmContext.OfType<EmployeeTypeSetViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSourceList,
                   x => x.EmployeesTypeDataSet);
            }
            catch
            {
            }
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<EmployeeTypeSetViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }
        
    }
}
