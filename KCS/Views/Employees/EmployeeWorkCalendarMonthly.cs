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

namespace KCS.Views
{
    public partial class EmployeeWorkCalendarMonthly : BaseViewControl, IRibbonModule
    {
        public EmployeeWorkCalendarMonthly()
            : base(typeof(EmployeeWorkCalendarMonthlyViewModel))
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
            this.gridView.BestFitColumns();
            InitViewDisplay();

        }
        void InitViewDisplay()
        {
            int curYear = DateTime.Now.Year;
            for(int i = -10; i < 0; i++)
            {
                comboBoxEditYear.Properties.Items.Add((curYear+i).ToString());
            }
            for (int i = 0; i < 10; i++)
            {
                comboBoxEditYear.Properties.Items.Add((curYear + i).ToString());
            }
            
            bbiCreateMonthWorkShift.Caption = LanguageResource.GetDisplayString("CreateMothlyShift");


            colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentId");
            colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");
            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            colYear.Caption = LanguageResource.GetDisplayString("YearText");
            colMonth.Caption = LanguageResource.GetDisplayString("MonthText");
            colDay.Caption = LanguageResource.GetDisplayString("DayText");
            colWeekdayName.Caption = LanguageResource.GetDisplayString("WeekdayName");
            colShiftCode.Caption = LanguageResource.GetDisplayString("WorkShiftCode");
            colStartTimeString.Caption = LanguageResource.GetDisplayString("StartTime");
            colEndTimeString.Caption = LanguageResource.GetDisplayString("EndTime");
            colNote.Caption = LanguageResource.GetDisplayString("RemarkText");
        }
        public  DateTime DateTimeByWeekAndDay(int week,int year,int month)
        {
            DateTime someTime = Convert.ToDateTime(year.ToString() + "-" + month.ToString() +"-1");

            int i = someTime.DayOfWeek - DayOfWeek.Monday;
            if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。
            TimeSpan ts = new TimeSpan(i, 0, 0, 0);

            //获取第N周的星期一
            someTime = someTime.Subtract(ts).AddDays((week - 1) * 7);
            //获得星期几
            //someTime = someTime.AddDays(day - 1);
            return someTime;
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<EmployeeWorkCalendarMonthlyViewModel>();
            try
            {
                Messenger.Default.Register<RebindMessage<EmployeeWorkCalendarMonthlyViewModel>>(this, x => RebindDataSource());
                fluentAPI.SetBinding(comboBoxEditYear, x => x.Text, x => x.SelectYear);
                fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EmployeesMonthlyShiftDataSet);
                fluentAPI.BindCommand(bbiCreateMonthWorkShift, x => x.CreateEmployeesMonthlyShift());

                fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
              .SetBinding(x => x.SelectedUserWorkMonthlyShift,
                  args => args.Row as KCS.Models.WorkCalendar,
                  (gView, WorkShift) => gView.FocusedRowHandle = gView.FindRow(WorkShift));

                fluentAPI.WithEvent<CellValueChangedEventArgs>(gridView, "CellValueChanging")
           .EventToCommand(x => x.Save(null), new Func<CellValueChangedEventArgs, object>(e => e.Value));

                fluentAPI.SetObjectDataSourceBinding(bindingSourceShift,
                  x => x.WorkShiftDataSet);
              
            }
            catch
            {
            }
        }
        void RebindDataSource()
        {
            var fluentAPI = mvvmContext.OfType<EmployeeWorkCalendarMonthlyViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EmployeesMonthlyShiftDataSet);
            }
            catch
            {
            }
        }
        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion
    }
}
