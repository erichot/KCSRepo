using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using KCS.Report;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

using KCS.Extensions;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class AllowTimeReportViewModel : KcsDocument
    {
        public int m_SelectedIndexSlave { get; set; }
        public int m_SelectedIndexDepartment { get; set; }


        public int m_SelectedStartHour { get; set; }

        public int m_SelectedEndHour { get; set; }

        public string m_SelectedDepartmentID { get; set; }
        public object SelectedSlave { get; set; }
        public int SlaveSID { get; set; }

        public string SelectedDepartmentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ByTransactionType { get; set; }
        IList<EmployeeBrief> employeesBriefList = null;
        IList<UserSlaveAllowTimeSetting> userSlaveAllowTimeSettingList = null;
        public virtual IEnumerable<EmployeeBrief> Selection { get; set; }

        public static IList<DeviceBase> m_DeviceBaseList { get; set; }

        public static IList<Department> m_DepartmentList { get; set; }

        public static AllowTimeReportViewModel Create()
        {
            return ViewModelSource.Create(() => new AllowTimeReportViewModel());
        }
        protected AllowTimeReportViewModel()
        {
            //int moth = DateTime.Now.Month;
            //int dayEnd = DateTime.DaysInMonth(DateTime.Now.Year, moth);

            //StartDate = Convert.ToDateTime(string.Format("{0}-{1}-1", DateTime.Now.Year.ToString(), moth.ToString()));
            //EndDate = Convert.ToDateTime(string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), moth.ToString(), dayEnd.ToString()));
            //ByTransactionType = false;
        }
        //public void DailyReport()
        //{
            
        //    if (Selection == null)
        //        return;
        //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, true));

           

        //    object objDataSource = TaDataSource.GetMonthlyAttendanceReportDetails(StartDate.ToShortDateString(), StartDate.ToShortDateString(), ByTransactionType, Selection);

        //    if (objDataSource == null)
        //    {
        //        Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
        //        return;
        //    }
        //    //var attendanceReport = objDataSource as List<AttendanceReportDetails>;
        //    //if (attendanceReport.Count == 0)
        //    //{
        //    //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
        //    //    return;
        //    //}
        //    XtraReportDailyAttendance annualCalendarReport = new XtraReportDailyAttendance(StartDate.ToShortDateString(), objDataSource);

        //    ReportPrintTool printTool = new ReportPrintTool(annualCalendarReport);
        //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
            
        //    printTool.ShowPreview(UserLookAndFeel.Default);
        //    //int count = S
        //    //
        //}
        //public void SimplifiedMonthlyReport()
        //{
        //    if (Selection == null)
        //        return;

        //    //int count = Selection.Count();
        //    // if (count <= 0)
        //    //   return;
        //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, true));

        //    object objDataSource = TaDataSource.GetMonthlyAttendanceReportSimplified(StartDate.ToShortDateString(), EndDate.ToShortDateString(), ByTransactionType, Selection);


        //    if (objDataSource == null)
        //    {
        //        Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
        //        return;
        //    }

            
        //    XtraReportSimplified annualCalendarReport = new XtraReportSimplified(StartDate.ToShortDateString(), EndDate.ToShortDateString(), objDataSource);

        //    ReportPrintTool printTool = new ReportPrintTool(annualCalendarReport);
        //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
        //    printTool.ShowPreview(UserLookAndFeel.Default);
        //}
        //public void MonthlyReport()
        //{
        //    if (Selection == null)
        //        return;

        //    //int count = Selection.Count();
        //   // if (count <= 0)
        //     //   return;
        //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, true));

        //    object objDataSource = TaDataSource.GetMonthlyAttendanceReportDetails(StartDate.ToShortDateString(), EndDate.ToShortDateString(), ByTransactionType, Selection);

        //    if (objDataSource == null)
        //    {
        //        Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
        //        return;
        //    }

        //    //var attendanceReport = objDataSource as List<AttendanceReportDetails>;
        //    //if (attendanceReport.Count == 0)
        //    //{
        //    //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
        //    //    return;
        //    //}

        //    XtraReportAttendanceDetails annualCalendarReport = new XtraReportAttendanceDetails(StartDate.ToShortDateString(), EndDate.ToShortDateString(), objDataSource);

        //    ReportPrintTool printTool = new ReportPrintTool(annualCalendarReport);
        //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
        //    printTool.ShowPreview(UserLookAndFeel.Default);
        //}
        ///* Add: 2023/01/22
        // * By:  Eric
        // * Ver: 1.1.5.7
        // */
        //public void FlexShiftReport(int aaa)
        //{
        //    if (Selection == null)
        //        return;

           
        //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, true));

        //    object objDataSource = TaDataSource.GetFlexShiftReportDetails(StartDate, EndDate, Selection);

        //    if (objDataSource == null)
        //    {
        //        Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
        //        return;
        //    }

        //    XtraReportFlexShift flexShiftReport = new XtraReportFlexShift(StartDate.ToShortDateString(), EndDate.ToShortDateString(), objDataSource);

        //    ReportPrintTool printTool = new ReportPrintTool(flexShiftReport);
        //    Messenger.Default.Send(new WaitingMessage<AllowTimeReportViewModel>(this, false));
        //    printTool.ShowPreview(UserLookAndFeel.Default);
        //}


        public object EmployeesBriefDataSet
        {
            get
            {
                employeesBriefList = EmployeesDataSource.GetEmployeesBriefList();
                return employeesBriefList;
            }

        }


        public void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<AllowTimeReportViewModel>(this));
        }

        public object DeviceInfoDataSet
        {
            get
            {
                m_DeviceBaseList = DevicesDataSource.GetDeviceBaseList();
                m_DeviceBaseList.Insert(0, new DeviceBase() { SlaveSID  = 0, ListField = "" });
                return m_DeviceBaseList;
                //return DevicesDataSource.GetDeviceBriefList();
            }
        }



        public object DepartmentInfoDataSet
        {
            get
            {
                m_DepartmentList = DepartmentSource.GetDepartmentList();
                m_DepartmentList.Insert(0,new Department() { DepartmentID = "", DepartmentName = "(ALL)" });
                return m_DepartmentList;
                //return DevicesDataSource.GetDeviceBriefList();
            }
        }

        public object UserSlaveAllowTimeList
        {
            get
            {
                if (m_DeviceBaseList != null)
                {
                    var selectedItem = m_DeviceBaseList[m_SelectedIndexSlave];
                    SlaveSID = selectedItem.SlaveSID;
                }

                if (m_DepartmentList != null)
                {
                    var selectedItem = m_DepartmentList[m_SelectedIndexDepartment];
                    SelectedDepartmentID = selectedItem.DepartmentID;
                }

                userSlaveAllowTimeSettingList = AllowTimeDataSource.GetUserSlaveAllowTimeList(SlaveSID, SelectedDepartmentID,m_SelectedStartHour, m_SelectedEndHour );
                return userSlaveAllowTimeSettingList;
            }

        }


    }
}