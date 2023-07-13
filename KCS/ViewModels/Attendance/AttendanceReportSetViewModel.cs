using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using KCS.Report;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class AttendanceReportSetViewModel : KcsDocument
    {
        public DateTime  StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ByTransactionType { get; set; }
        IList<EmployeeBrief> employeesBriefList = null;
        public virtual IEnumerable<EmployeeBrief> Selection { get; set; }

        public static AttendanceReportSetViewModel Create()
        {
            return ViewModelSource.Create(() => new AttendanceReportSetViewModel());
        }
        protected AttendanceReportSetViewModel()
        {
            int moth = DateTime.Now.Month;
            int dayEnd = DateTime.DaysInMonth(DateTime.Now.Year, moth);

            StartDate = Convert.ToDateTime(string.Format("{0}-{1}-1", DateTime.Now.Year.ToString(), moth.ToString()));
            EndDate = Convert.ToDateTime(string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), moth.ToString(), dayEnd.ToString()));
            ByTransactionType = false;
        }
        public void DailyReport()
        {
            
            if (Selection == null)
                return;
            Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, true));

           

            object objDataSource = TaDataSource.GetMonthlyAttendanceReportDetails(StartDate.ToShortDateString(), StartDate.ToShortDateString(), ByTransactionType, Selection);

            if (objDataSource == null)
            {
                Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
                return;
            }
            //var attendanceReport = objDataSource as List<AttendanceReportDetails>;
            //if (attendanceReport.Count == 0)
            //{
            //    Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
            //    return;
            //}
            XtraReportDailyAttendance annualCalendarReport = new XtraReportDailyAttendance(StartDate.ToShortDateString(), objDataSource);

            ReportPrintTool printTool = new ReportPrintTool(annualCalendarReport);
            Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
            
            printTool.ShowPreview(UserLookAndFeel.Default);
            //int count = S
            //
        }
        public void SimplifiedMonthlyReport()
        {
            if (Selection == null)
                return;

            //int count = Selection.Count();
            // if (count <= 0)
            //   return;
            Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, true));

            object objDataSource = TaDataSource.GetMonthlyAttendanceReportSimplified(StartDate.ToShortDateString(), EndDate.ToShortDateString(), ByTransactionType, Selection);


            if (objDataSource == null)
            {
                Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
                return;
            }

            
            XtraReportSimplified annualCalendarReport = new XtraReportSimplified(StartDate.ToShortDateString(), EndDate.ToShortDateString(), objDataSource);

            ReportPrintTool printTool = new ReportPrintTool(annualCalendarReport);
            Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
            printTool.ShowPreview(UserLookAndFeel.Default);
        }
        public void MonthlyReport()
        {
            if (Selection == null)
                return;

            //int count = Selection.Count();
           // if (count <= 0)
             //   return;
            Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, true));

            object objDataSource = TaDataSource.GetMonthlyAttendanceReportDetails(StartDate.ToShortDateString(), EndDate.ToShortDateString(), ByTransactionType, Selection);

            if (objDataSource == null)
            {
                Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
                return;
            }

            //var attendanceReport = objDataSource as List<AttendanceReportDetails>;
            //if (attendanceReport.Count == 0)
            //{
            //    Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
            //    return;
            //}

            XtraReportAttendanceDetails annualCalendarReport = new XtraReportAttendanceDetails(StartDate.ToShortDateString(), EndDate.ToShortDateString(), objDataSource);

            ReportPrintTool printTool = new ReportPrintTool(annualCalendarReport);
            Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
            printTool.ShowPreview(UserLookAndFeel.Default);
        }



        /* Add: 2023/01/22
         * By:  Eric
         * Ver: 1.1.5.7
         */
        public void FlexShiftReport()
        {
            if (Selection == null)
                return;

           
            Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, true));

            object objDataSource = TaDataSource.GetFlexShiftReportDetails(StartDate, EndDate, Selection);

            if (objDataSource == null)
            {
                Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
                return;
            }

            XtraReportFlexShift flexShiftReport = new XtraReportFlexShift(StartDate.ToShortDateString(), EndDate.ToShortDateString(), objDataSource);

            ReportPrintTool printTool = new ReportPrintTool(flexShiftReport);
            Messenger.Default.Send(new WaitingMessage<AttendanceReportSetViewModel>(this, false));
            printTool.ShowPreview(UserLookAndFeel.Default);
        }


        public object EmployeesBriefDataSet
        {
            get
            {
                employeesBriefList = EmployeesDataSource.GetEmployeesBriefList();
                return employeesBriefList;
            }

        }
    }
}