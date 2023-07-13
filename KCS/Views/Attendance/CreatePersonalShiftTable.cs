using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.ViewModels;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;
using KCS.Common.Utils;
using DevExpress.Mvvm;

namespace KCS.Views
{
    public partial class CreatePersonalShiftTable : DevExpress.XtraEditors.XtraUserControl
    {
        KCS.Services.IWaitingService waitingService = new KCS.Services.WaitingService();
        public CreatePersonalShiftTable()
        {
            InitializeComponent();
        }
         protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            gridControl.Load += gridControl_Load;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<CreatePersonalShiftTableViewModel>();

            Messenger.Default.Register<WaitingMessage<CreatePersonalShiftTableViewModel>>(this, ShowWaiting);
            Messenger.Default.Register<RebindMessage<CreatePersonalShiftTableViewModel>>(this, x => RebindDataSource());
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
             .SetBinding(x => x.SelectedEmployee,
                 args => args.Row as EmployeeBrief,
                 (gView, EmployeeBrief) => gView.FocusedRowHandle = gView.FindRow(EmployeeBrief));

            fluentAPI.WithEvent<CellValueChangedEventArgs>(gridView, "CellValueChanging")
           .EventToCommand(x => x.Save(null), new Func<CellValueChangedEventArgs, object>(e => e));

            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.Selection, e => GetSelectedEmployees());

            fluentAPI.SetBinding(lookUpEditShiftTable,x => x.EditValue,x => x.SelectedShiftTable);
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EmployeesBriefDataSet);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceShiftTable, x => x.TrunWorkBaseDataSet);
            fluentAPI.BindCommand(simpleButtonSet, x => x.SaveShiftTableSetting());
            fluentAPI.BindCommand(bbiCreateAnnualShiftTable, x => x.CreatePersonalAnnualShiftTable(null), x => x.Selection);
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            
            //
        }
        void InitViewDisplay()
        {
            colCardID.Caption = LanguageResource.GetDisplayString("CardID");
            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentID");
            colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");
            lblShiftTable.Text = colShiftCategory.Caption = LanguageResource.GetDisplayString("ShiftTabelCodeText");
            bbiClose.Caption = ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            ribbonPageGroupEdit.Text = LanguageResource.GetDisplayString("ToolBarGroupEdit");
            bbiCreateAnnualShiftTable.Caption = LanguageResource.GetDisplayString("CreatePersonalCalendarText");
            simpleButtonSet.Text = LanguageResource.GetDisplayString("ApplyWeeklySettingsButton");
        }
        void RebindDataSource()
        {
            gridView.RefreshData();
        }
        IEnumerable<EmployeeBrief> GetSelectedEmployees()
        {
            return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as EmployeeBrief);
        }
        void ShowWaiting(WaitingMessage<CreatePersonalShiftTableViewModel> message)
        {
            if (null == waitingService)
                return;
            if (message.IsShow)
            {

                waitingService.BeginWaiting(LanguageResource.GetDisplayString("ProcessingText") + "...");
            }
            else
            {
                waitingService.EndWaiting();
            }
        }
    }
}
