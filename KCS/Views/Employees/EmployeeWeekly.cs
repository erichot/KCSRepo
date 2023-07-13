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
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;
using DevExpress.Mvvm;

namespace KCS.Views
{
    public partial class EmployeeWeekly : BaseViewControl, IRibbonModule
    {
        KCS.Services.IWaitingService waitingService ;

        public EmployeeWeekly()
            : base(typeof(EmployeeWeeklyViewModel))
        {
            InitializeComponent();
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
            waitingService = GetService<Services.IWaitingService>();
        }
        void InitViewDisplay()
        {
            //bbiSave.Caption = LanguageResource.GetDisplayString("SaveSetting");   
            colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentId");
            colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");
            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            //colWeekdayName.Caption = LanguageResource.GetDisplayString("WeekdayName");
            //colShiftCode.Caption = LanguageResource.GetDisplayString("ShiftCode");
            //colStartTimeString.Caption = LanguageResource.GetDisplayString("StartTime");
            //colEndTimeString.Caption = LanguageResource.GetDisplayString("EndTime");
            layoutControlItemMon.Text = colMonday.Caption = LanguageResource.GetDisplayString("MondayText");
            layoutControlItemSun.Text = colSunday.Caption = LanguageResource.GetDisplayString("SundayText");
            layoutControlItemSat.Text = colSaturday.Caption = LanguageResource.GetDisplayString("SaturdayText");
            layoutControlItemFri.Text = colFriday.Caption = LanguageResource.GetDisplayString("FridayText");
            layoutControlItemThurs.Text = colThursday.Caption = LanguageResource.GetDisplayString("ThursdayText");
            layoutControlItemWedn.Text = colWednesday.Caption = LanguageResource.GetDisplayString("WednesdayText");
            layoutControlItemTues.Text = colTuesday.Caption = LanguageResource.GetDisplayString("TuesdayText");
            simpleButtonSet.Text = LanguageResource.GetDisplayString("ApplyWeeklySettingsButton");

            
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<EmployeeWeeklyViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                   x => x.UserWorkShiftDataSet);
                fluentAPI.SetObjectDataSourceBinding(bindingSourceShiftCode,
                  x => x.WorkShiftDataSet);

                Messenger.Default.Register<RebindMessage<EmployeeWeeklyViewModel>>(this, x => RebindDataSource());
                Messenger.Default.Register<WaitingMessage<EmployeeWeeklyViewModel>>(this, ShowWaiting);
                fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
              .SetBinding(x => x.SelectedUserWorkShift,
                  args => args.Row as KCS.Models.UserWorkShift,
                  (gView, WorkShift) => gView.FocusedRowHandle = gView.FindRow(WorkShift));
               
                fluentAPI.WithEvent<CellValueChangedEventArgs>(gridView, "CellValueChanging")
           .EventToCommand(x => x.Save(null), new Func<CellValueChangedEventArgs, object>(e => e));

                fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.Selection, e => GetSelectedEmployees());

                fluentAPI.SetBinding(lookUpEditMon, x => x.EditValue, x => x.workshiftsettings.WorkShiftMon);
                fluentAPI.SetBinding(lookUpEditTues, x => x.EditValue, x => x.workshiftsettings.WorkShiftTues);
                fluentAPI.SetBinding(lookUpEditWedn, x => x.EditValue, x => x.workshiftsettings.WorkShiftWedn);
                fluentAPI.SetBinding(lookUpEditThurs, x => x.EditValue, x => x.workshiftsettings.WorkShiftThir);
                fluentAPI.SetBinding(lookUpEditFri, x => x.EditValue, x => x.workshiftsettings.WorkShiftFri);
                fluentAPI.SetBinding(lookUpEditSat, x => x.EditValue, x => x.workshiftsettings.WorkShiftSat);
                fluentAPI.SetBinding(lookUpEditSun, x => x.EditValue, x => x.workshiftsettings.WorkShiftSun);

                fluentAPI.BindCommand(simpleButtonSet, x => x.OnSaveUserWeeklySetting());
                //fluentAPI.SetBinding
                lookUpEditMon.ItemIndex = 0;
                lookUpEditTues.ItemIndex = 0;
                lookUpEditWedn.ItemIndex = 0;
                lookUpEditThurs.ItemIndex = 0;
                lookUpEditFri.ItemIndex = 0;
                lookUpEditSat.ItemIndex = 0;
                lookUpEditSun.ItemIndex = 0;
                
                
            }
            catch
            {
            }
        }
        void ShowWaiting(WaitingMessage<EmployeeWeeklyViewModel> message)
        {
            if (message.IsShow)
            {

                waitingService.BeginWaiting(LanguageResource.GetDisplayString("ProcessingText")+"...");
            }
            else
            {
                waitingService.EndWaiting();
            }
        }
        void RebindDataSource()
        {
            var fluentAPI = mvvmContext.OfType<EmployeeWeeklyViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                   x => x.UserWorkShiftDataSet);
            }
            catch
            {
            }
        }
        IEnumerable<UserWorkShift> GetSelectedEmployees()
        {
            return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as UserWorkShift);
        }
        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion

       
      

       
    }
}
