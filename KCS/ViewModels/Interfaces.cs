using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS
{
    using KCS.Common.Utils;
    using System;
    using System.ComponentModel.DataAnnotations;

    public enum ModuleType
    {
        Unknown,
        [Display(Name = "Supervisor")]
        Supervisor,
        [NaviGroupAttribute("Supervisor")]
        SupervisorManage,//管理员
        [NaviGroupAttribute("Supervisor")]
        DepartmentSet,   //部门设置
        [Display(Name = "DeviceSetting")]
        DeviceSetting,
        [NaviGroupAttribute("DeviceSetting")]
        DeviceSettingManage, //考勤记录，设备列表
        [Display(Name = "Employees")]
        Employees,
        [NaviGroupAttribute("Employees")]
        EmployeesManage,
        //[NaviGroup("Employees")]
        //EmployeeTypeSet,
        //[NaviGroup("Employees")]
       // EmployeeWeekly,
        //[NaviGroup("Employees")]
       // EmployeeWorkCalendarMonthly,
        //[NaviGroup("Employees")]
        //EmployeeWorkCalendarMonthlyMultiUsers,
        //[NaviGroup("Employees")]
        //EmployeeJobCode,
        [Display(Name = "AccessControl")]
        AccessControl,
        [NaviGroup("AccessControl")]
        AccessControlManage,
        [Display(Name = "TimeAttendance")]
        TimeAttendance,
        [NaviGroup("TimeAttendance")]
        TimeAttendanceManage,
        //[NaviGroup("TimeAttendance")]
       // WorkShiftManagement,
        //[NaviGroup("TimeAttendance")]
        //AttendanceReportWeekly,
        //[NaviGroup("TimeAttendance")]
       // AttendanceReportWorkCalendar,
        //[NaviGroup("TimeAttendance")]
        //AttendanceReportMultiWorkShift,
       // [NaviGroup("TimeAttendance")]
       // AttendanceStatusSetting,
        //[NaviGroup("TimeAttendance")]
        //AttendanceStatusSheet,
       // [NaviGroup("TimeAttendance")]
      //  TransactionsReport,
        //[NaviGroup("TimeAttendance")]
       // TransactionAdd,
        //[NaviGroup("TimeAttendance")]
        //TransactionModify,
        //[NaviGroup("TimeAttendance")]
       // GlobalHolidaySetting,
       // [NaviGroup("TimeAttendance")]
       // LeaveType,
       // [NaviGroup("TimeAttendance")]
       // JustificationLeaveApplication,



    } 
    public interface IMainModule : 
        ISupportModuleLayout, ISupportTransitions
    {
    }
    public interface ISupportCompactLayout
    {
        bool Compact { get; set; }
    }
    
    public interface ISupportTransitions
    {
        void StartTransition(bool forward, object waitParameter);
        void EndTransition();
    }
    public interface ISupportModuleLayout
    {
        void SaveLayoutToStream(System.IO.MemoryStream ms);
        void RestoreLayoutFromStream(System.IO.MemoryStream ms);
    }  
    
    
    public interface ISupportModifications
    {
        bool Modified { get; }
        void Save();
    }
    public interface ISupportCustomFilters
    {
        void ResetCustomFilters();
        event EventHandler CustomFiltersReset;
    }
    
}
