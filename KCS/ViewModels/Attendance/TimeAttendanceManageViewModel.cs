using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;
using KCS.Common.Utils;
using System.Linq;
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;
using KCS.Report;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class TimeAttendanceManageViewModel
    {
        IList<TaTransaction> TransactionList;
        
         public static TimeAttendanceManageViewModel Create()
        {
             return ViewModelSource.Create(() => new TimeAttendanceManageViewModel());
        }

        protected TimeAttendanceManageViewModel()
        {
            SelectDeviceId = 0;
            // DateStart = null;
            //DateEnd = null;

            
            QueryCondition = 0;

            int dayEnd = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            DateStart = Convert.ToDateTime(string.Format("{0}-{1}-1 ", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString()));
            DateEnd = Convert.ToDateTime(string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), dayEnd.ToString()));
        }
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }

        protected IDialogService DialogService
        {
            get { return this.GetService<IDialogService>(); }
        }

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }

        public virtual int RecordCount { get; set; }
        public virtual DateTime DateStart { get; set; }
        public virtual DateTime DateEnd { get; set; }

        
        public virtual int QueryCondition { get; set; } 

        public virtual int SelectDeviceId { get; set; }
        public virtual TaTransaction SelectedTransaction { get; set; }

        //public object AnnualCalendarDataSet
        //{
        //    get
        //    {
        //        return TaDataSource.GetAnnualCalendarList(2017);
        //    }
        //}
        public object TransactionDataSet
        {
            get
            {
               
                if (DateStart == null || DateEnd == null)
                    TransactionList = TransactionDataSource.GetTaTransactionsList(SelectDeviceId, null, null, QueryCondition);
                else
                    TransactionList = TransactionDataSource.GetTaTransactionsList(SelectDeviceId, DateStart.ToString("yyyy-MM-dd HH:mm:ss"), DateEnd.ToString("yyyy-MM-dd HH:mm:ss"), QueryCondition);
                //var TransactionList = TransactionDataSet as IList<TaTransaction>;
                RecordCount = TransactionList.Count;
                return TransactionList;
            }

        }
        public object DeviceInfoDataSet
        {
            get
            {
                return DevicesDataSource.GetDeviceBriefList();
            }
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<TimeAttendanceManageViewModel>(this));
        }
        public void AddTransaction(object transactionObject)
        {
            if (transactionObject == null)
                return;
            var transaction = transactionObject as TaTransaction;
            var addTransViewModel = TransactionAddViewModel.Create(transaction);
            addTransViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("TransactionAdd", addTransViewModel);
            document.Show();
        }
        public void Edit(object transactionObject)
        {
            if (transactionObject == null)
                return;
            var transaction = transactionObject as TaTransaction;
            var modifyTransViewModel = TransactionModifyViewModel.Create(transaction);
            modifyTransViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("TransactionModify", modifyTransViewModel);
            document.Show();
        }
        public void ReloadTransactions()
        {
            var xxx = SelectDeviceId;
            RebindDataSource();
            RecordCount = TransactionList.Count;
        }
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<TimeAttendanceManageViewModel>(this, RecordCount));
        }

        public void TaHolidaySetting()
        {
            var document = DocumentManagerService.CreateDocument("TaHolidaySetting", TaHolidaySettingViewModel.Create());
            document.Show();
        }
        public void LeaveCategorySetting()
        {
            var document = DocumentManagerService.CreateDocument("LeaveType", LeaveTypeViewModel.Create());
            document.Show();
        }
        public void VocationSetting()
        {
            var document = DocumentManagerService.CreateDocument("JustificationLeaveApplication", JustificationLeaveApplicationViewModel.Create());
            document.Show();
        }

        public void JobCodeSet()
        {
            var document = DocumentManagerService.CreateDocument("EmployeeJobCodecs", EmployeeJobCodecsViewModel.Create());
            document.Show();
        }
        public void NewWorkShift()
        {
            var document = DocumentManagerService.CreateDocument("WorkShiftManagement", WorkShiftManagementViewModel.Create());
            document.Show();
        }
        public void CalendarSettings()
        {
            //if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("CalendarSetText"), "CalendarSettings", CalendarSettingsViewModel.Create()))
            //{
            //}
        }
        public void EditAnnualCalendar()
        {
            var document = DocumentManagerService.CreateDocument("CalendarEdit", CalendarEditViewModel.Create());
            document.Show();
        }
        public void ShiftTableCategoryEdition()
        {
            var document = DocumentManagerService.CreateDocument("ShiftTableCategory", ShiftTableCategoryViewModel.Create());
            document.Show();
        }
        public void EditAnnualShiftTable()
        {
            var document = DocumentManagerService.CreateDocument("ShiftTableEdit", ShiftTableEditViewModel.Create());
            document.Show();
        }
        public void CreatePersonalShiftTable()
        {
            var document = DocumentManagerService.CreateDocument("CreatePersonalShiftTable", CreatePersonalShiftTableViewModel.Create());
            document.Show();
        }
        public void EditPersonalShiftTable()
        {
            var document = DocumentManagerService.CreateDocument("EditPersonalShiftTable", EditPersonalShiftTableViewModel.Create());
            
            document.Show();
        }
        public void PrintAnnualCalendar()
        {

           AnnualCalendarPrintViewModel annualCalendarPrint = AnnualCalendarPrintViewModel.Create();
           if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("PrintText"), "AnnualCalendarPrint", annualCalendarPrint))
            {
               object objDataSource = TaDataSource.GetAnnualCalendarListByMonth(annualCalendarPrint.SelectYear, annualCalendarPrint.SelectMonthStart, annualCalendarPrint.SelectMonthEnd);
               if (objDataSource == null)
                   return;
               var annualCalendar = objDataSource as List<AnnulaCalendar>;
               if (annualCalendar.Count == 0)
                   return;
               XtraReportAnnualCalendar annualCalendarReport = new XtraReportAnnualCalendar(objDataSource, annualCalendarPrint.SelectYear);
                // annualCalendarReport.DataSource = ;
                ReportPrintTool printTool = new ReportPrintTool(annualCalendarReport);
                //printTool.ShowPreviewDialog();

                // Invoke the Print Preview form
                // with the specified look and feel setting.
                printTool.ShowPreview(UserLookAndFeel.Default);
            }
           // var document = DocumentManagerService.CreateDocument("AnnualCalendarPrint", AnnualCalendarPrintViewModel.Create());
            //document.Show();
        }
        public void CreateAnnualCalendar()
        {

            CreateCalendarSettingsViewModel createCalendarViewModel = CreateCalendarSettingsViewModel.Create();
            if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("CreateAnnualCalendarText"), "CreateCalendarSettings", createCalendarViewModel))
            {

                if (TaDataSource.HasAnnualCalendarOrNot(createCalendarViewModel.SelectYear) > 0)
                {
                    if (MessageService.ShowMessage(LanguageResource.GetDisplayString("CalendarIsExistedText"), LanguageResource.GetDisplayString("CreateAnnualCalendarText"), MessageButton.YesNo) != MessageResult.Yes)
                        return;
                    TaDataSource.DeleteAnnualCalendar(createCalendarViewModel.SelectYear);
                }
                var leaveTypesList = TaDataSource.GetTaHolidaySettingList();
                Messenger.Default.Send(new WaitingMessage<TimeAttendanceManageViewModel>(this, true));
                for (int month = 1; month <= 12; month++)
                {
                    int dayEnd = DateTime.DaysInMonth(createCalendarViewModel.SelectYear, month);
                    for (int day = 1; day <= dayEnd; day++)
                    {
                        string curHOLIDAY = string.Format("{0:D2}{1:D2}", month, day);
                        AnnulaCalendar calendar = new AnnulaCalendar();
                        calendar.CREATE_NAME = calendar.BUILD_NAME = CredentialsSource.GetLoginSupervisorMsg();
                        calendar.LIST_YEAR = createCalendarViewModel.SelectYear;
                        calendar.LIST_DATE = DateTime.Parse(string.Format("{0:D4}-{1:D2}-{2:D2}", createCalendarViewModel.SelectYear, month, day));
                        calendar.LIST_WEEK = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(calendar.LIST_DATE.DayOfWeek);
                        
                        TaHolidays holidaySet = leaveTypesList.FirstOrDefault(f => f.HOLIDAY.Equals(curHOLIDAY));
                        if (null != holidaySet)
                        {//假日
                            if (createCalendarViewModel.HaveHolidayOrNot == 0)
                            {//例行假日放假的时候使用
                                calendar.LIST_MEMO = holidaySet.HOLIDAY_DESC;
                                calendar.HOLIDAY_CK = true;
                                calendar.LIST_GRP = 3;
                            }
                        }
                        else
                        {
                            string curDayOfWeek = calendar.LIST_DATE.DayOfWeek.ToString();
                            if (curDayOfWeek.Equals("Saturday") || curDayOfWeek.Equals("Sunday"))
                            {
                                if (createCalendarViewModel.HolidayTypeOnWeekend == 0)
                                {//周末双休的时候 使用 
                                    if (curDayOfWeek.Equals("Saturday") )
                                        calendar.LIST_MEMO = LanguageResource.GetDisplayString("SaturdayText");
                                    else
                                        calendar.LIST_MEMO = LanguageResource.GetDisplayString("SundayText");
                                    calendar.HOLIDAY_CK = true;
                                    calendar.LIST_GRP = 1;
                                }
                            }
                        }
                        try
                        {
                            TaDataSource.AddAnnualCalendar(calendar);
                        }
                        catch(Exception ex)
                        {
                            
                            Messenger.Default.Send(new WaitingMessage<TimeAttendanceManageViewModel>(this, false));
                            MessageService.ShowMessage(LanguageResource.GetDisplayString("CreateAnnualCalendarFailedText"));
                           
                            return;
                        }
                        
                    }
                }
                Messenger.Default.Send(new WaitingMessage<TimeAttendanceManageViewModel>(this, false));
                PopHintDialog.ShowMessage(LanguageResource.GetDisplayString("CreateAnnualCalendarOKText"));
              //  
             }
        }

        public void AttendanceReportDetails()
        {
            AttendanceReportSetViewModel attendanceReportSet = AttendanceReportSetViewModel.Create();
            var document = DocumentManagerService.CreateDocument("AttendanceReportSetView", attendanceReportSet);
            document.Show();
            //if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("ReportDetails"), "AttendanceReportSetView", attendanceReportSet))
            //{
            //    if (attendanceReportSet.Selection == null)
            //        return;
            //    int count = attendanceReportSet.Selection.Count();
            //    if (count <= 0)
            //        return;
            //    Messenger.Default.Send(new WaitingMessage<TimeAttendanceManageViewModel>(this, true));
                
            //    object objDataSource = TaDataSource.GetAttendanceReportDetails(attendanceReportSet.StartDate.ToShortDateString(), attendanceReportSet.EndDate.ToShortDateString(), attendanceReportSet.ByTransactionType, attendanceReportSet.Selection);
            //    Messenger.Default.Send(new WaitingMessage<TimeAttendanceManageViewModel>(this, false));
            //    if (objDataSource == null)
            //        return;
                
            //    var attendanceReport = objDataSource as List<AttendanceReportDetails>;
            //    if (attendanceReport.Count == 0)
            //        return;
            //    XtraReportAttendanceDetails annualCalendarReport = new XtraReportAttendanceDetails(attendanceReportSet.StartDate.ToShortDateString(), attendanceReportSet.EndDate.ToShortDateString(), objDataSource);
               
            //    ReportPrintTool printTool = new ReportPrintTool(annualCalendarReport);
                
            //    printTool.ShowPreview(UserLookAndFeel.Default);
               
            //}
        }

        public void AttendanceReportStatics()
        {
            AttendanceReportSetViewModel attendanceReportSet = AttendanceReportSetViewModel.Create();
            if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("ReportCount"), "AttendanceReportSetView", attendanceReportSet))
            {
            }
        }
       
    }

    
}