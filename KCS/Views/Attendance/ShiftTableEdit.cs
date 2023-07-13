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
using KCS.Common.Utils;
using KCS.ViewModels;
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;

namespace KCS.Views
{
    public partial class ShiftTableEdit : DevExpress.XtraEditors.XtraUserControl
    {
        public ShiftTableEdit()
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
            gridView.BestFitColumns();
        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ShiftTableEditViewModel>();
            Messenger.Default.Register<RebindMessage<ShiftTableEditViewModel>>(this, x => RebindDataSource());
            fluentAPI.SetBinding(comboBoxEditYear, x => x.Text, x => x.SelectYear);
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.AnnualShiftTableDataSet);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceWorkShift,
                x => x.WorkShiftItemDataSet);

           // fluentAPI.WithEvent<RowObjectEventArgs>(gridView, "RowUpdated")
           //.EventToCommand(x => x.Save(null), new Func<RowObjectEventArgs, object>(e => e.Row)); //

            fluentAPI.WithEvent<CellValueChangedEventArgs>(gridView, "CellValueChanging")
           .EventToCommand(x => x.Save(null), new Func<CellValueChangedEventArgs, object>(e => e));


            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
              .SetBinding(x => x.SelectedWorkListItem,
                  args => args.Row as WorkList,
                  (gView, CalendarSet) => gView.FocusedRowHandle = gView.FindRow(CalendarSet));

            fluentAPI.BindCommand(bbiClose, x => x.Close());
            gridView.RowStyle += (sender, e) =>
            {

                if (e.RowHandle < 0)
                    return;
                if (gridView.GetRow(e.RowHandle) == null) return;
                string cellValue = gridView.GetRowCellValue(e.RowHandle, "HolidayType").ToString();
                if (cellValue == LanguageResource.GetDisplayString("RestDayText"))
                {

                    e.Appearance.BackColor = Color.LightGreen;
                }
                else if (cellValue == LanguageResource.GetDisplayString("LegalHolidayText"))
                {

                    e.Appearance.BackColor = Color.LightBlue;
                }
                else
                {
                    e.Appearance.BackColor = Color.Transparent;
                }
            };

        }
        void RebindDataSource()
        {
           // gridView.RefreshData();
            var fluentAPI = mvvmContext.OfType<ShiftTableEditViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.AnnualShiftTableDataSet);
                fluentAPI.SetObjectDataSourceBinding(bindingSourceWorkShift,
               x => x.WorkShiftItemDataSet);
            }
            catch
            {
            }
        }
        void InitViewDisplay()
        {
            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            colWORK_YEAR.Caption = LanguageResource.GetDisplayString("YearText");
            colTURNWORK_GRP.Caption = LanguageResource.GetDisplayString("ShiftTabelTypeText");
            colWorkMonth.Caption = LanguageResource.GetDisplayString("MonthText");
            colWORK_DATE.Caption = LanguageResource.GetDisplayString("DateText");
            colWORK_WEEK.Caption = LanguageResource.GetDisplayString("WeekdayName");
            colCLASS_CODE.Caption = LanguageResource.GetDisplayString("ShiftCode");
            colCLASS_DESC.Caption = LanguageResource.GetDisplayString("RemarkText");
            colWORK_TIME_START.Caption = LanguageResource.GetDisplayString("WorkShiftStartTime");
            colWORK_TIME_END.Caption = LanguageResource.GetDisplayString("WorkShiftEndTime");
            colHolidayType.Caption = LanguageResource.GetDisplayString("HolidayBreakText");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            for (int i = 2016; i < 2100; i++)
            {

                comboBoxEditYear.Properties.Items.Add(i.ToString());
            }
            comboBoxEditYear.SelectedIndex = 0;
            repositoryItemComboBox1.Properties.Items.Add(LanguageResource.GetDisplayString("RestDayText"));
            repositoryItemComboBox1.Properties.Items.Add(LanguageResource.GetDisplayString("LegalHolidayText"));
            
        }
    }
}
