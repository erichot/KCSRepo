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
using KCS.Common.Utils;
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using KCS.Models;

namespace KCS.Views
{
    public partial class CalendarEdit : DevExpress.XtraEditors.XtraUserControl
    {
        public CalendarEdit()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<CalendarEditViewModel>();
            Messenger.Default.Register<RebindMessage<CalendarEditViewModel>>(this, x => RebindDataSource());
            fluentAPI.SetBinding(comboBoxEditYear, x => x.Text, x => x.SelectYear);
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.AnnualCalendarDataSet);

            fluentAPI.WithEvent<RowObjectEventArgs>(gridView, "RowUpdated")
           .EventToCommand(x => x.Save(null), new Func<RowObjectEventArgs, object>(e => e.Row)); //

            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
              .SetBinding(x => x.SelectedCalendarSet,
                  args => args.Row as AnnulaCalendar,
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
            var fluentAPI = mvvmContext.OfType<CalendarEditViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.AnnualCalendarDataSet);
            }
            catch
            {
            }
        }
        void InitViewDisplay()
        {
            colLIST_YEAR.Caption = LanguageResource.GetDisplayString("YearText");
            colLIST_DATE.Caption = LanguageResource.GetDisplayString("DateText");
            colLIST_WEEK.Caption = LanguageResource.GetDisplayString("WeekdayName");
            colLIST_MEMO.Caption = LanguageResource.GetDisplayString("HolidaySetText");
            colHOLIDAY_CK.Caption = LanguageResource.GetDisplayString("HolidayBreakText");
            colCalendarMonth.Caption = LanguageResource.GetDisplayString("MonthText");
            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            for (int i = 2016; i < 2100; i++)
            {

                comboBoxEditYear.Properties.Items.Add(i.ToString());
            }
            comboBoxEditYear.SelectedIndex = 0;
            repositoryItemComboBox.Properties.Items.Add(LanguageResource.GetDisplayString("LegalHolidayText"));
            repositoryItemComboBox.Properties.Items.Add(LanguageResource.GetDisplayString("RestDayText"));
            
        }
    }
}
