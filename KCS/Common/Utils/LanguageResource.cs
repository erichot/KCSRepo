using KCS.Common.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace KCS.Common.Utils
{
    class LanguageResource
    {
#pragma warning disable  414
        #region Default Language
        #region Navi Item
        private static string NaviItemSupervisorManage = "Supervisor Management";
        private static string NaviItemDepartmentSet = "Department Setting";
        private static string NaviItemDeviceSettingManage = "Devices Management";
        private static string NaviItemEmployeesManage = "Employees Management";
       // private static string NaviItemEmployeeTypeSet = "Employee Type Setting";
        private static string NaviItemEmployeeWeekly = "Weekly Setting";
        private static string NaviItemEmployeeWorkCalendarMonthly = "WorkCalendar Monthly Setting";
        private static string NaviItemEmployeeWorkCalendarMonthlyMultiUsers = "WorkCalendar Monthly MultiUsers";
        private static string NaviItemEmployeeJobCode = "Employee Job Code";
        private static string NaviItemAccessControlManage = "AccessControl Management";
        private static string NaviItemTimeAttendanceManage = "TimeAttendance Management";
        private static string NaviItemWorkShiftManagement = "WorkShift Management";
        private static string NaviItemAttendanceReportWeekly = "Attendance ReportWeekly";
        private static string NaviItemAttendanceReportWorkCalendar = "Attendance Report WorkCalendar";
        private static string NaviItemAttendanceReportMultiWorkShift = "Attendance Report MultiWorkShift";
        private static string NaviItemAttendanceStatusSetting = "Attendance Status Setting";
        private static string NaviItemAttendanceStatusSheet = "Attendance Status Sheet";
        private static string NaviItemTransactionsReport = "Transactions Report";
        private static string NaviItemTransactionAdd = "Transaction Add";
        private static string NaviItemTransactionModify = "Transaction Modify";
        private static string NaviItemGlobalHolidaySetting = "Global Holiday Setting";
        private static string NaviItemLeaveType = "Leave Type";
        private static string NaviItemJustificationLeaveApplication = "Justification Leave Application";
#endregion
        private static string KCSTitle = "KCS" ;
        private static string ProcessBarInit="Initializing...";
        private static string ProcessBarStart="Starting...";
        private static string ProcessBarFinish="Successfully loaded";
        private static string LoginFormTitle = "Login Attendance Management";
        private static string LoginViewWelcome = "Welcome";
        private static string LoginViewUserId = "User ID";
        private static string LoginViewUserPin = "Password";
        private static string LoginViewRemember = "Remember me?";
        private static string LoginViewLogin = "Log In";
        private static string LoginViewLoginFailed = "Login failed";

        private static string NaviSupervisor="Supervisor";
        private static string NaviDeviceSetting="Devices";
        private static string NaviEmployees="Employees";
        private static string NaviAccessControl="Access Control";
        private static string NaviTimeAttendance="Time Attendance";
        private static string ToolBarGroupNew="New";
        private static string ToolBarNewEmployee="New Employee";
        private static string ToolBarNewDevice="New Device";
        private static string ToolNewDepartment="New Department";
        private static string ToolBarWorkShiftSetting="Work Shift Setting";
        private static string ToolBarNewSupervisor="New Supervisor";
        private static string ToolBarGroupSystem="System";
        private static string ToolBarSystemSetting="System Setting";
        private static string ToolBarSetAdminPin="Set Administrators PIN";
        private static string ToolBarGroupSave="Save";
        private static string ToolBarGroupEdit = "Edit";
        private static string ToolBarGroupClose = "Close";
        private static string ToolBarGroupAction = "Actions";
        private static string ToolBarGroupFinger = "Finger";

        private static string ToolBarJobCode = "Job Code";
        private static string ToolBarForceDelete = "Force delete";
        private static string ToolBarEmployeesType = "Employee Type";
        private static string ToolBarDisableEmployee = "Disable Employees";
        private static string ToolBarEnableEmployee = "Enable  Employees";
        private static string ToolBarSetAcPara = "Access Control Parameters";
        private static string ToolBarImportEmployee = "Import Employees";
        private static string ToolBarExportEmployee = "Export Employees";
        private static string ToolBarDeleteFinger1 = "Delete Finger1";
        private static string ToolBarDeleteFinger2 = "Delete Finger2";
        private static string ToolBarDeleteFinger12 = "Delete two fingers";
        private static string ToolBarReSyncAll = "ReSync all";
        private static string ToolBarReSyncSelectd = "ReSync select employee";
        private static string ToolBarSyncSetting = "Sync Setting";
        private static string ToolBarSave = "Save";
        private static string ToolBarSaveAndClose = "SaveAndClose";
        private static string ToolBarSaveAndNew = "SaveAndNew";
        private static string ToolBarReset = "Reset";
        private static string ToolBarNew = "New";
        private static string ToolBarClose = "Close";
        private static string ToolBarEdit="Edit";
        private static string ToolBarDelete="Delete";
        private static string ToolBarSetPassword = "Set Password";
        private static string IsDeleteItem="Do you want to delete this item?";
        private static string IsDeleteItems = "Do you want to delete these items?";
        private static string IsDeleteFiner = "Do you want to delete the finger";
        private static string IsForceDeleteItems = "Do you want to force delete these items?";
        private static string IsDisableItems = "Do you want to disable the select employees?";
        private static string IsEnableItems = "Do you want to enable the select employees?";
        private static string IsApplySettingToSelectedItems = "Do you want to apply settings to selected items?";
        private static string ReSyncAllEmployees = "Do you want to ReSynchronization all employees to devices?";
        private static string ReSyncSelectedEmployee = "Do you want to ReSynchronization selected employee to devices?";
        private static string DeleteEmployeeFailedTip = "Cannot delete the user because the transaction record";
        private static string DeleteEmployeeFailed = "Delete employee failed";
        private static string DeleteEmployeeOK = "Delete employee succeeds";
        private static string DeleteEmployeeFingerOK = "Delete employee finger succeeds";
        private static string DeleteEmployeeFingerFailed = "Delete employee finger failed";
        private static string ReSyncAllEmployeeOK = "Set ReSynchronization all employees to devices succeeds";
        private static string ReSyncAllEmployeeFailed = "Set ReSynchronization all employees to devices failed";
        private static string ReSyncSelectedEmployeeOK = "Set ReSynchronization selected employee to devices succeeds";
        private static string ReSyncSelectedEmployeeFailed = "Set ReSynchronization selected employee to devices failed";
        private static string ForbidSyncSelectedEmployee = "The selected employee is forbidden to sync to device ";
        private static string SyncSettingForSelectedEmployee = "Do you want to change the sync setting?";
        private static string SyncSettingForSelectedEmployeeFailed = "Set Sync for selected employee failed";
        private static string DisableAllEmployeeOK = "Disable selected employees succeeds";
        private static string DisableAllEmployeeFailed = "Disable selected employees failed";
        private static string EnableAllEmployeeOK = "Enable selected employees succeeds";
        private static string EnableAllEmployeeFailed = "Enable selected employees failed";
        private static string FromXLSX = "From XLSX";
        private static string FromXLS = "From XLS";
        private static string FromTxtWithComSep = "From TXT(CSV)";
        private static string FromTxtWithTabSep = "From TXT(Tab separation)";
        private static string NoSelectedExcelFileHint = "There aren't select the Excel file, can not be imported";
        private static string DeleteConfirm = "Confirmation";
        private static string AuthorityReadOnly="Read only";
        private static string AuthorityAdmin="Read and Write";
        private static string UserPermissionTypeAdministrators="Administrators";
        private static string UserPermissionTypeSupervisorsAllDepartments="Supervisors Of all departments";
        private static string UserPermissionTypeSupervisorsDepartment="Supervisors Of one department";
        private static string UserPermissionTypeUsers="User";
        private static string UserPermissionTypeGuest = "guest";

        private static string ContextMenuNew = "New";
        private static string ContextMenuEdit = "Edit";
        private static string ContextMenuDelete = "Delete";

        private static string SupervisorViewId = "Supervisor ID";
        private static string SupervisorViewName = "Supervisor Name";
        private static string DepartmentID = "Department ID";
        private static string Email = "Email";
        private static string SupervisorViewPhone = "Mobile phone";
        private static string SupervisorViewAdminType = "Authority";
        private static string SupervisorViewAuth = "Read only";
        private static string RemarkText = "Description";
        private static string RecordsText = "Records";
        private static string SetAdminPinCapiton = "Set Administrators PIN";

        private static string GridContrlUpdateText = "Update";
        private static string DialogCancelButtonText = "Cancel";
        private static string DialogOkButtonText = "Ok";
        private static string DialogYesButton = "Yes";
        private static string DialogNoButtonText = "No";
        private static string DialogIgnoreButtonText = "Ignore";
        private static string DialogAbortButtonText = "Abort";
        private static string DialogRetryButtonText = "Retry";
        private static string DateEditTodayText = "Today";
        private static string TwoInputNotConsistent = "Two input passwords are not consistent";
        private static string PasswordValidateFailed = "Password authentication failed";
        private static string ModifyPinFailed = "Modify passwords failed";
        private static string EditSupervisor = "Edit supervisor";
        private static string ResetSupervisorPin = "Reset supervisor password";
        private static string AddItemFailed = "New failed";
        private static string UpdateItemFailed = "Update failed";
        private static string DeleteItemFailed = "Delete failed";
        private static string NewSupervisorView = "New a supervisor";
        private static string Department = "Department";
        private static string DepartmentId = "Department ID";
        private static string DepartmentName = "Department Name";
        private static string SystemCode = "Code";
        private static string EmployeeID = "Employee ID";
        private static string EmployeeName = "Employee Name";
        private static string ExportString = "Export";
        private static string ToStrString = "to";
        private static string OpenExportFile = "Do you want to open this file?";
        private static string ExportToString = "Export to...";
        private static string CannotOpenExportFile = "Cannot find an application on your system suitable for openning the file with exported data.";

        private static string CardID = "Card ID";
        private static string TitleName = "Title Name";
        private static string InActive = "Inactive";
        private static string EmployeeTypeId = "Employee Type ID";
        private static string EmployeeTypeName = "Employee Type Name";
        private static string EmployeeType = "Employee Type";
        private static string SyncOrNot = "Disables Sync";
        private static string DontSyncToDevices = "Do not sync to any devices";
        private static string SyncSetting = "Sync setting";
        private static string SyncToAll = "Sync to all devices";
        private static string SynToSelectedDevice = "Sync to selected devices";
        private static string SelectDevices = "Select devices";
        private static string Details = "Details";
        private static string IsTaOrNot = "Is TA or not";
        private static string ValideDate = "Valid Date";
        private static string AllowTimeStartHour = "Allow time start hour";
        private static string AllowTimeStartHMin = "Allow time start Minute";
        private static string AllowTimeEndHour = "Allow time end hour";
        private static string AllowTimeEndHMin = "Allow time end Minute";
        private static string NotCheckAttendance = "Do not Check work attendance";
       

        private static string NewEmployeeOk = "New employee succeeds";
        private static string NewEmployeeFailed = "New employee failed";
        private static string NewEmployeeFailedInput = "Please check the input,The Items(*) are necessary";
        private static string ExisitedCardId = "Duplicate Card ID";
        private static string ExisitedUserId = "Duplicate user id";
        private static string DeviceID = "Device ID";
        private static string DeviceIP = "IP Address";
        private static string DeviceName = "Device Name";
        private static string DeviceDescription = "Description";
        private static string DeviceIsEnable = "Is Enabled";
        //2023/06/27
        //private static string DeviceIsServerMode = "Is Client Mode";
        private static string DeviceIsServerMode = "Is Push Sync";
        private static string EditEmployeeOk = "Modify employee succeeds";
        private static string EditEmployeeFailed = "Modify employee failed";
        private static string SetToSync = "Set to Sync";
        private static string EmployeeDataReplicated = "Employee Replicated";
        private static string Finger1Replicated = "Finger 1 Replicated";
        private static string Finger2Replicated = "Finger 2 Replicated";

        private static string ErrorMsgUserIdLength = "The column of UserID exceeds the maximun length of 16";
        private static string ErrorMsgDuplicatedUserId = "Duplicate value in the column of UserID";

        private static string ErrorMsgCardIdLength = "The column of CardID exceeds the maximun length of 10";
        private static string ErrorMsgDuplicatedCardId = "Duplicate value in the column of CardID";
        private static string ImportComplete = "Import operation complete";
        private static string ImportCompleteCounts = "Insert Records";
        private static string SyncAfterImport = "Sync to devices after import";
        private static string ImportOverwrite = "Import && Overwrite";
        //Device
        private static string ToolBarGroupDevice = "Device";
        private static string ToolBarGroupSync = "Synchronization";

        private static string ToolBarDeleteDevice = "Delete Device";
        private static string ToolBarEnableDevice = "Enable Device";
        private static string ToolBarDisableDevice = "Disable Device";
        private static string ToolBarResetDevice = "Reset Device";
        private static string ToolBarDeviceSyncSetting = "Device Sync Setting";
        private static string TransactionID = "Transaction ID";
        private static string TransactionType = "Transaction Type";
        private static string TransctionCardID = "Card ID";
        private static string TransctionDateTime = "Date Time";
        private static string DeviceCategoryName = "Category Name";
        private static string DialogDeviceCategory = "Device Category";
        private static string NotPropagateWithUsersByDefault = "Do not propagate with all users by default";
        private static string ItemForIP = "IP";
        private static string ItemForIP_Internal = "IP (Internal)";

        private static string IPIsNecessary = "IP Address is Necessary";
        private static string NewDeviceOk = "New Device OK";
        private static string NewDeviceFailed = "New Device Failed";
        private static string DeleteDeviceFailed = "Delete Device Failed";
        private static string ExisitedSlaveId = "ID Already exist!";
        private static string ExisitedSlaveIP = "IP Address  Already exist!";
        private static string IsEnableDevice = "Do you want to enable selected device";
        private static string EnableDeviceFailed = "Enable Device Failed";
        private static string IsDisableDevice = "Do you want to disable selected device";
        private static string DisableDeviceFailed = "Disable Device Failed";
        private static string IsResetDevice = "Do you want to reset selected device to default";
        private static string UpdateDeviceFailed = "Update Device Failed";
        private static string IsReplicated = "IsReplicated";
        private static string TimeReplicated = "Replicated Time";
        private static string AllowSync = "Allow Sync";
        private static string SyncSettingForSelectedDevice = "Do you want to change the sync setting?";
        private static string SyncSettingForSelectedDeviceFailed = "Set Sync for selected device failed";

        private static string AccessControlHoliType = "Type ";
        private static string AccessControlHoliTypeNULL = "NULL";
        private static string SchedulerGotoDateText = "Goto Date";
        private static string SchedulerGotoTodayText = "Goto Today";
        private static string HolidaySetText = "Holiday";
        private static string TimeSetSetText = "Time Frame Setting";
        private static string TimeZoneSetText = "Time Zone Setting";
        private static string DescriptionText = "Description";
        private static string StartTime = "Start Time";
        private static string EndTime = "End Time";
        private static string TimeSetNoPassing = "No Passing";
        private static string TimeSet24HoursPassing = "24 Hours Passing";
        private static string FirstFrame = "First Frame";
        private static string SecondFrame = "Second Frame";
        private static string ThirdFrame = "Third Frame";
        private static string FourthFrame = "Fourth Frame";
        private static string UserGroupText = "User Group";
        private static string NodeValueText = "Value";
        private static string SundayText = "Sunday";
        private static string MondayText = "Monday";
        private static string TuesdayText = "Tuesday";
        private static string WednesdayText = "Wednesday";
        private static string ThursdayText = "Thursday";
        private static string FridayText = "Friday";
        private static string SaturdayText = "Saturday";

        private static string TimeFrameText = "Time Frame";
        private static string TimeZoneText = "Time Zone";
        private static string WeekPlayText = "Week Plan";
        private static string HolidayPlanText = "Holiday Plan";
        private static string ToolBarSaveUserGroup = "Save UserGroup Setting";
        private static string UseAdvancedAccessControlSetting = "Use Advanced AccessControl Setting";
        private static string AccessGrantedTime = "Access Granted Time";
        private static string AccessGrantedGroup = "Access Granted Group";
        private static string BlackList = "Blacklist";
        private static string SelectedDevicesFirst = "Please select devices first";
        private static string SelectedEmployeesFirst = "Please select employees first";
        private static string GroupIDText = "Group ID";
        private static string NoSelectedDatas = "No data is selected!";
        private static string NoExistingDatas = "No existing data.";

        private static string RefreshText = "Refresh";
        private static string DeviceType = "Device Type";
        private static string FirmwareVersion = "Firmware Version";
        //Work shift
        private static string WorkShiftCode = "Shift Code";
        private static string WorkShiftName = "Shift Name";
        private static string WorkShiftStartTime = "Start Time";
        private static string WorkShiftEndTime = "End Time";
        private static string WorkShiftBreakTime = "Break Time";
        private static string WorkShiftIsDefault = "Default";
        private static string WorkShiftTotalTime = "Total Time";
        private static string BreakTimeByMinute = "By minute";
        private static string WeekdayName = "Weekday";
        private static string ShiftCode = "Shift Code";
        private static string SaveSetting = "Save all settings";
        private static string ApplyWeeklySettingsButton = "Apply to selected employees";
        private static string CreateMothlyShift = "Create employees MonthlyShift";
        private static string ApplyToAll = "All Employees";
        private static string ApplyToSelectedUser = "Selected Employees";
        private static string CreateMonthlyShift = "Create MonthlyShift";
        private static string ProcessingText = "Processing";
        private static string IsCreateMonthlyShift = "Do you want to create monthlyshift for selected employees";

        private static string YearText = "Year";
        private static string MonthText = "Month";
        private static string DayText = "Day";

        private static string LeaveCategoryText = "Leave category";
        private static string VocationSettingText = "Vacation setting";
        private static string ModifyTransText = "Modify Transaction";
        private static string AddTransText = "Add Transaction";
        private static string LeaveTypeIdText = "Type ID";
        private static string LeaveTypeNameText = "Type Name";
      
       
      
       
        private static string DisableText = "Disable";
        private static string TimeSetErrorText = "Error!Start Time has to be prior to End Time";
        private static string DateText = "Date";
        private static string HourText = "Hour";
        private static string ReasonText = "Reason";
        private static string LeaveText = "Leave";
        private static string hoursText = "hours";
        private static string SaveSetttings = "Save settings";
        private static string SelectEmployee = "Selected employee";
        private static string Leave1ErrorMsg = "Leave 1 setting is incorrect!";
        private static string Leave1HourErrorMsg = "Leave 1 hours is incorrect!";
        private static string Leave2ErrorMsg = "Leave 2 setting is incorrect!";
        private static string Leave2HourErrorMsg = "Leave 2 hours is incorrect!";
        private static string Leave3ErrorMsg = "Leave 3 setting is incorrect!";
        private static string Leave3HourErrorMsg = "Leave 3 hours is incorrect!";

        private static string InsertErrorMsg = "Insert failure!";
        private static string ErrorCodeText = "Error Code";
        private static string OnlyActiveEmployee = "Only active employees";
        private static string OnlyInactiveEmployee = "Only inactive employees";
        private static string BothText = "Both";
        private static string QueryText = "Query";
        private static string FromText = "From";
        private static string ToText = "To";
        private static string JobNameText = "Job Name";
        private static string ActiveInactiveText = "Active/Inactive";
        private static string ReportsText = "Reports";

        private static string ExportToTxtText = "Export to CSV";
        private static string ExportXLSXText = "Export to XLSX";
        private static string ExportToPDFText = "Export to PDF";

        private static string LateTimeText = "Late starts";
        private static string LateTimeNoteText = "(Late starts from time)";
        private static string ResetTimeText = "Reset Time";
        private static string OverTimeText = "Overtime starts";
        private static string OverTimeNoteText = "Overtime starts from time";
        private static string OverTimeUnitText = "Overtime unit";
        private static string AttendanceTimeText = "Attendance time";
        private static string MaxAbsenceTimeText = "Max. absence Hrs/Day";
        private static string MinuteText = "Minute";
        private static string ShifCodeIsNecessary = "Shift code is Necessary";
        private static string InputStartTimeText = "Please input start time";
        private static string InputEndTimeText = "Please input end time";
        private static string RestTimeError = "must be between Start Time and End Time";
        private static string TaSettingText = "Time Attendance settings";
        private static string BulidText = "Build";
        private static string BulidTimeText = "Build Time";
        private static string ModifyText = "Modify";
        private static string ModifyTimeText = "Modify Time";
        private static string HolidayNameText = "Holiday Name";
        private static string TransactionText = "Transaction";
        private static string AnnualCalendarText = "Annual Calendar";
        private static string SettingsText = "Settings";
        private static string CalendarSetText = "Canlendar Settings";
        private static string RestlessYearText = "Restless Year Round";
        private static string WeekendText = "2days Weekend";
        private static string CalendarText = "Calendar";
        private static string CreateAnnualCalendarText = "Create Annual Canlendar";
        private static string CalendarIsExistedText = "Calendar existed already. Do you want to overwrite it?";
        private static string CreateAnnualCalendarFailedText = "Create Annual Canlendar Failed!";
        private static string CreateAnnualCalendarOKText = "Create Annual Canlendar Succeeds!";
        private static string HolidayBreakText = "Holiday/Break";
        private static string PrintText = "Print";
        private static string CreateText = "Create";
        private static string EditText = "Edit";
        private static string ClockText = "Clock";

        private static string RestDayText = "Weekly Offs";
        private static string LegalHolidayText = "Holidays";
        private static string EndText = "End";
        private static string PageText = "Page";
        private static string ShiftTabelCodeText = "Shift Table";
        private static string ShiftTabelEditionText = "Shift Table Edition";
        private static string ShiftTabelTypeText = "Shift Table category";
        private static string CreatePersonalCalendarText = "Create Personal Shift Table";
        private static string EditPersonalShiftTableText = "Edit Personal Shift Table";

        private static string DefaultShiftText = "Default Shift";
        private static string ShifTableCodeIsNecessary = "Shift Table is Necessary";
        private static string CreateAnnualShiftTableText = "Create Annual Shift Table";
        private static string CalendarNotExistedText = "The annual calendar has not been generated! Continue or not?";
        private static string CreateAnnualShiftTabledFailedText = "Create Annual Shift Table Failed!";
        private static string CreateAnnualShiftTabledOkText = "Create Annual Shift Table Succeeds!";

        private static string CreatePersonalAnnualShiftTabledFailedText = "Create Personal Annual Shift Table Failed!";
        private static string CreatePersonalAnnualShiftTabledOkText = "Create Personal Annual Shift Table Succeeds!";

        private static string ResetTime1StartText = "Reset Time 1 Start";
        private static string ResetTime1EndText = "Reset Time 1 End";
        private static string ResetTime2StartText = "Reset Time 2 Start";
        private static string ResetTime2EndText = "Reset Time 2 End";
        private static string ToolBarExportSetting = "Export Text Setting";
        private static string AboutText = "AboutText";
        private static string ToolBarSearchDevice = "Search Devices";
        private static string ToolBarNetWorkTest = "Network Test";
        private static string ToolBarRebootDevice = "Reboot Device";
        private static string InputNewPassword = "Input New Password";
        private static string NewPasswordAgain = "New Password Again";
        private static string SystemSetting = "System Setting";
        private static string LoginMode = "Login mode";
        private static string WindowsAuthentication = "Windows authentication";
        private static string SqlAuthentication = "Sql authentication";
        private static string UserName = "User Name";
        private static string Password = "Password";
        private static string UsingExistingDatabase = "Using existing database";
        private static string NewDatabase = "New database";
        private static string RestoreDatabase = "Restore database";
        private static string DataBase = "DataBase";
        private static string DefaultLanguage = "Default Language";
        private static string Test = "Test";
        private static string ServerName = "Server Name";
        private static string Restore = "Restore";
        private static string ExportTextSet = "Export to Text Setting";
        private static string AutoExportToTxt = "Auto Export Transactions to TXT";
        private static string Createfilebymonth = "Create file by month";
        private static string Separator = "Separator";
        private static string DateSeparator = "Date Separator";
        private static string SlaveIDlength = "Slave ID length";
        private static string DateFormate = "Date Formate";
        private static string TimeFormate = "Time Formate";
        private static string FilePath = "File Path";

        private static string LeaveManagementText = "Leave management";
        private static string Finger1Status = "Finger1 Status";
        private static string Finger2Status = "Finger2 Status";
        private static string FingerEstablished = "Already established";
        private static string FingerNotEstablished = "Not established";
        //請假
        private static string StatusText = "Staus";
        private static string StatusEdit = "Edit";
        private static string StatusApproval = "Approval";
        private static string StatusCancel = "Cancel";
        private static string Authorizer = "Authorizer";
        private static string ApprovalTime = "Approval time";
        private static string LeaveNUM = "Leave NUM";
        private static string ApplyDate = "Apply Date";
        private static string LeaveDateStart = "Leave Date Start";
        private static string LeaveTimeStart = "Leave Time Start";
        private static string LeaveDateEnd = "Leave Date End";
        private static string LeaveTimeEnd = "Leave Time End";
        private static string HourlyTotal = "Hourly total";
        private static string HourlyTotalTips = "(Minimum unit 0.5 hours)";
        private static string Agent = "Agent";
        private static string Applicant = "Applicant";
        private static string CreateLeaveDetails = "Create Leave details";
        private static string IDText = "ID";
        private static string LeaveDate = "Leave Date";
        private static string AttendanceHours = "Attendance hours";
        private static string LeaveHours = "Leave hours";
        private static string NoPersonalAnnualShiftMsg = "No shift table of the employee is found! Setup the employee's shift table first";
        private static string ResetLeaveDetailsHints = "Do you want to reset your leave details";

        private static string ApproveOverDueHint = "The holiday has been over 31 days,Can't be approved";
        private static string CancelOverDueHint = "The holiday has been over 31 days,Can't be canceled";
        private static string AttendanceReport = "Attendance Report";

        private static string ReportDetails = "Report details";
        private static string ReportCount = "Report statistics";

        private static string PleaseWait = "Please Wait";
        private static string Loading = "Loading";
        private static string CalculateAttendanceRecordsOnly = "Calculate attendance record only"; //
        private static string CompanyBasicData = "Company basic data";
        private static string CompanyName = "Company Name";
        private static string OndutyTime = "On Dutty";
        private static string OffdtuyTime = "Off Dutty";
        private static string RestStartTime = "Rest start";
        private static string RestEndTime = "Rest end";
        private static string LateMinutes = "Minutes late";
        private static string LeavEarlyMinutes = "Leave early minutes";
        private static string Attendancehours = "Attendance hours";
        private static string Absenthours = "Absent hours";
        private static string OverTimehours = "Overtime hours";
        private static string TotalText = "Total";
        private static string ReReadTransactions = "Re-Read Transactions";
        private static string SaveSucceeds = "Save Succeeds";
        private static string ExportDataMannual = "Export datas";
        private static string StartDate = "Start date";
        private static string EndDate = "End date";
        private static string ExportSucceeds = "Export Succeeds";
        private static string CalendarSetting2DaysWeekend = "Two-day Weekend";
        private static string CalendarSettingNosWeekend = "Restless Year Round";
        private static string HolidayOrNotText = "Holiday or not";
        private static string WeekenTypeText = "Holiday or not";
        private static string ToolBarChangeCardId = "Change CardID";
        private static string NewCardIdText = "New Card ID";
        private static string ChageCardIdOk = "Change Card ID succeeds";
        private static string ChageCardIdFailed = "Change Card ID failed";
        private static string DisableSync = "Disable Synchronization";
        private static string SyncSettings = "Synchronization Setup";
        private static string ChangeLanguage = "Change Language";
        private static string PhotosText = "Photo";
        private static string ToolBarDailyReport = "Daily Report";
        private static string ToolBarMonthlyReport = "Monthly Report";
        private static string YearLen = "Length of year";
        private static string FixedText = "Fixed Text";
        private static string DeviceMenuPwd = "Menu Password";
        private static string DeviceWorkMode = "Device Work Mode";
        private static string DeviceLanguage = "Device Language";
        private static string LanguageCN = "Simplified Chinese";
        private static string LanguageTW = "Traditional Chinese";
        private static string LanguageEnglish = "English";
        private static string LanguageItalian = "Italian";
        private static string LanguageSpanish = "Spanish";
        private static string LanguagePortuguese = "Portuguese";
        private static string LanguageThai = "Thai";
        private static string LanguageBrazilian = "Brazilian";
        private static string LanguageCorean = "Corean";
        private static string DeviceParaSetting = "Device Parameters Setting";
        private static string SetDevicePara = "Set";
        private static string SetDeviceAllPara = "Set All";
        private static string ToolBarMonthlySimplifiedReport = "Simplified Report";
        private static string AdministratorsId = "Administrators ID";
        private static string AdministratorsName = "Administrators Name";
        private static string ToolBarDatabaseMaintenance = "Database Maintenance";
        private static string DatabaseBackup = "Database backup";
        private static string DatabaseRestore = "Database restore";
        private static string DatabaseDelRecords = "Delete attendance records";
        private static string DBMBackup = "Backup";
        private static string DBMRestore = "Restore";
        private static string DBMDelRecords = "Delete records";
        private static string DBMBackupSucceeds = "Backup succeeds";
        private static string DBMBackupFailed = "Backup failed";
        private static string DBMRestoreSucceeds = "Restore succeeds";
        private static string DBMRestoreFailed = "Restore failed";
        private static string DBMDleRecordsSucceeds = "Delete records succeeds";
        private static string DBMDleRecordsFailed = "Delete records failed";

        private static string ToolBarOpenDoor = "Open Door";
        private static string ToolBarSetDoorPin = "Open Door Password";
        private static string PIN1GroupName = "PIN 1";
        private static string PIN2GroupName = "PIN 2";
        private static string PINName = "Name" ;
        private static string PINStartHour = "Start Hour";
        private static string PINStartMin = "Start Minute";
        private static string PINEndHour = "End Hour";
        private static string PINEndMin = "End Minute";
        private static string PINValue = "Password";

        private static string FileExtension = "File extension";
        private static string CardIdLen = "Card ID length";
        private static string TileText = "Title";
        private static string FixedExportFileName = "Fixed export file name";
        private static string ASCIIFormat = "ASCII format";
        private static string LiftController = "Elevator Controller";
        private static string EleavatorID = "Eleavator ID";
        private static string EleavatorName = "Eleavator Name";
        private static string EleavatorDes = "Description";

        private static string NewElevator = "New Elevator";
        private static string ElevatorAuthority = "Elevator Authority";

        private static string NewElevatorOk = "New elevator succeeds";
        private static string NewElevatorFailed = "New elevator failed";

        private static string ModifyElevatorOk = "Modify elevator succeeds";
        private static string ModifyElevatorFailed = "Modify elevator failed";

        private static string DeleteElevatorOk = "Delete elevator succeeds";
        private static string DeleteElevatorFailed = "Delete elevator failed";

        private static string ExitedElevatorController = "The elevator controller already exists";
        private static string ElevatorControlAuthority = "Lift control rights";
        private static string ApplyText = "Apply";
        private static string SetElevatorControlAuthorityFailed = "Setting elevator authority failed";
        private static string SetElevatorControlAuthorityOk = "Setting elevator authority succeeds";
        private static string ToolBarImportEmployeesPhotos = "Import employees photos";
        private static string ImportEmployeesPhotosFailed = "Import employees photos failed";
        private static string ImportEmployeesPhotosOk = "Import employees photos succeeds";
        private static string ToolBarResyncAcParas = "Resync access control parameters";
        private static string ResyncAcParasFailed = "Resync access control parameters failed";
        private static string ResyncAcParasOk = "Resync access control parameters succeeds";

        #endregion
#pragma warning restore  414
        public static Hashtable LangResource { get; set; }
        static public string GetDisplayString(string itemkey)
        {
            return Convert.ToString(LangResource[itemkey]);
        }

        private void ReadResource(string lang)
        {

            if (string.IsNullOrEmpty(lang))
                return;
            XmlReader reader = null;
            string szPath = string.Format("{0}\\Resources\\Language\\AppLangResource_", XmlHelper.GetWorkDirectory());
            FileInfo fi = new FileInfo(szPath + lang + ".xml");
            if (!fi.Exists)
            {
                szPath = string.Format("{0}\\Resources\\Language\\AppLangResource.xml", XmlHelper.GetWorkDirectory());
                reader = new XmlTextReader(szPath);
            }
            else
                reader = new XmlTextReader(szPath + lang + ".xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            XmlNode root = doc.DocumentElement;
            XmlNodeList nodelist = root.SelectNodes("Item");
            foreach (XmlNode node in nodelist)
            {
                try
                {
                    XmlNode node1 = node.SelectSingleNode("@name");
                    XmlNode node2 = node.SelectSingleNode("@text");
                    if (node1 != null)
                    {
                        LangResource[node1.InnerText] = node2.InnerText.ToString();
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.ToString());
                }
            }
            reader.Close();


        }
        public XmlAttribute CreateAttribute(XmlNode node, string attributeName, string value)
        {
            try
            {
                XmlDocument doc = node.OwnerDocument;
                XmlAttribute attr = null;
                attr = doc.CreateAttribute(attributeName);
                attr.Value = value;
                node.Attributes.SetNamedItem(attr);
                return attr;
            }
            catch (Exception err)
            {
                string desc = err.Message;
                return null;
            }
        } 
        public void CreateLanuageFile()
        {
            System.Reflection.FieldInfo[] properties = this.GetType().GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            if (properties.Length <= 0)
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", ""));
            //创建一个根节点（一级）
            XmlElement root = doc.CreateElement("Resource");
            doc.AppendChild(root);
            //创建节点（二级）
            XmlNode node ;
            try
            {
                
                foreach (System.Reflection.FieldInfo item in properties)
                {
                    if (item != null)
                    {
                        node = doc.CreateElement("Item");
                        node.Attributes.Append(CreateAttribute(node, "name", item.Name));
                        string str = item.GetValue(this).ToString();
                        node.Attributes.Append(CreateAttribute(node, "text", str));
                        root.AppendChild(node);
                        Debug.WriteLine(item.Name);
                    }


                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            doc.Save(@"AppLangResource.xml");
        }
        private void InitDefaultLanguageHashTable()
        {
            LangResource = new Hashtable();
            System.Reflection.FieldInfo[] properties = this.GetType().GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            if (properties.Length <= 0)
            {
                return ;
            }
            
            foreach (System.Reflection.FieldInfo item in properties)
            {
                if (item != null)
                LangResource[item.Name] = item.GetValue(this);
               
                
            }
        }
        public LanguageResource()
        {
        }
        public LanguageResource(string lang)
        {
            InitDefaultLanguageHashTable();
            try
            {
                ReadResource(lang);
            }
            catch (Exception ex)
            {
            }
            
        } 
    }
}
