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
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;
using DevExpress.Mvvm;

namespace KCS.Views
{
    public partial class EditPersonalShiftTable : DevExpress.XtraEditors.XtraForm
    {
        public EditPersonalShiftTable()
        {
            
            InitializeComponent();
            
            this.WindowState= FormWindowState.Maximized;

            
            
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            splashScreenManager1.ShowWaitForm();
            splashScreenManager1.SetWaitFormCaption(LanguageResource.GetDisplayString("PleaseWait"));
            splashScreenManager1.SetWaitFormDescription(LanguageResource.GetDisplayString("Loading") + "...");
            gridControl.Load += gridControl_Load;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
           // gridView.BestFitColumns();
            
        }
        protected override DevExpress.XtraEditors.FormShowMode ShowMode
        {
            get { return DevExpress.XtraEditors.FormShowMode.AfterInitialization; }
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            splashScreenManager1.CloseWaitForm();
        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }
        void RebindDataSource(RebindMessage<EditPersonalShiftTableViewModel> message)
        {
            if (message.BindType == 1)
            {
                gridView.RefreshData();
            }
            else
            {

                var fluentAPI = mvvmContext.OfType<EditPersonalShiftTableViewModel>();
                try
                {
                    fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.PersonalShiftTableDataSet);
                    fluentAPI.SetObjectDataSourceBinding(bindingSourceWorkShift,
                    x => x.WorkShiftItemDataSet);
                }
                catch
                {
                }
            }
        }
        
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<EditPersonalShiftTableViewModel>();
            fluentAPI.SetBinding(comboBoxEditYear, x => x.Text, x => x.SelectYear);
            Messenger.Default.Register<RebindMessage<EditPersonalShiftTableViewModel>>(this, x => RebindDataSource(x));
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.PersonalShiftTableDataSet);
                fluentAPI.SetObjectDataSourceBinding(bindingSourceWorkShift,
                x => x.WorkShiftItemDataSet);

                fluentAPI.WithEvent<CellValueChangedEventArgs>(gridView, "CellValueChanging")
          .EventToCommand(x => x.Save(null), new Func<CellValueChangedEventArgs, object>(e => e));


                fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                  .SetBinding(x => x.SelectedPerShiftTable,
                      args => args.Row as PerShiftTable,
                      (gView, PerShiftTableSet) => gView.FocusedRowHandle = gView.FindRow(PerShiftTableSet));

                fluentAPI.BindCommand(bbiClose, x => x.Close());
                gridView.RowStyle += (sender, e) =>
                {

                    if (e.RowHandle < 0)
                        return;
                    if (gridView.GetRow(e.RowHandle) == null) return;
                    try
                    {
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
                    }
                    catch
                    {
                    }
                };
            }
            catch
            {
            }
        }
        void InitViewDisplay()
        {
           
            colCHK_DATE.Caption = LanguageResource.GetDisplayString("DateText");
            colPerShiftTableWeekName.Caption = LanguageResource.GetDisplayString("WeekdayName");
            colCLASS_CODE.Caption = LanguageResource.GetDisplayString("WorkShiftCode");
            colCLASS_DESC.Caption = LanguageResource.GetDisplayString("WorkShiftName");
            colHolidayType.Caption = LanguageResource.GetDisplayString("HolidayBreakText");
            colCLOCK_CK.Caption = LanguageResource.GetDisplayString("ClockText");
            colWORK_TIME_START.Caption = LanguageResource.GetDisplayString("StartTime");
            colWORK_TIME_END.Caption = LanguageResource.GetDisplayString("EndTime");
            colWORK_TIME_LATE.Caption = LanguageResource.GetDisplayString("LateTimeText");
            colWORK_TIME_OVERTIME.Caption = LanguageResource.GetDisplayString("OverTimeText");
            colTURN_OVERTIME.Caption = LanguageResource.GetDisplayString("OverTimeUnitText");
            colRELAX_TIME1.Caption = LanguageResource.GetDisplayString("ResetTime1StartText");
            colRELAX_TIME2.Caption = LanguageResource.GetDisplayString("ResetTime1EndText");
            colRELAX_TIME3.Caption = LanguageResource.GetDisplayString("ResetTime2StartText");
            colRELAX_TIME4.Caption = LanguageResource.GetDisplayString("ResetTime2EndText");
            colDepartmentNote.Caption = LanguageResource.GetDisplayString("Department");
            colEmployeeNote.Caption = LanguageResource.GetDisplayString("NaviEmployees");
            colPerShiftTableMonth.Caption = LanguageResource.GetDisplayString("MonthText");
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
