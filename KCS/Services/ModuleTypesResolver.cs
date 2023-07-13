using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Services
{
    public interface IModuleTypesResolver
    {
        string GetName(ModuleType moduleType);
        string GetTypeName(ModuleType moduleType);
        System.Guid GetId(ModuleType moduleType);
        ModuleType GetMainModuleType(ModuleType type);
        ModuleType GetMapModuleType(ModuleType type);
        ModuleType GetMailMergeModuleType(ModuleType type);
        ModuleType GetAnalysisModuleType(ModuleType type);
        ModuleType GetPeekModuleType(ModuleType type);
        ModuleType GetNavPaneModuleType(ModuleType type);
        ModuleType GetNavPaneHeaderModuleType(ModuleType type);
        ModuleType GetExportModuleType(ModuleType type);
        ModuleType GetPrintModuleType(ModuleType type);
    }
    class ModuleTypesResolver : IModuleTypesResolver
    {
        public string GetName(ModuleType moduleType)
        {
            if (moduleType == ModuleType.Unknown)
                return null;
            return moduleType.ToString();
        }
        public string GetTypeName(ModuleType moduleType)
        {
            if (moduleType == ModuleType.Unknown)
                return null;
            return moduleType.ToString();
        }
        public System.Guid GetId(ModuleType moduleType)
        {
            switch (moduleType)
            {
                
                default:
                    return System.Guid.Empty;
            }
        }
        
        public ModuleType GetMainModuleType(ModuleType moduleType)
        {
            switch (moduleType)
            {
                case ModuleType.Supervisor:
                    return ModuleType.Supervisor;
                case ModuleType.DeviceSetting:
                    return ModuleType.DeviceSetting;
                case ModuleType.Employees:
                    return ModuleType.Employees;
                case ModuleType.AccessControl:
                    return ModuleType.AccessControl;
                case ModuleType.TimeAttendance:
                    return ModuleType.TimeAttendance;
                case ModuleType.SupervisorManage:
                    return ModuleType.SupervisorManage;
                case ModuleType.DepartmentSet:
                    return ModuleType.DepartmentSet;
                case ModuleType.DeviceSettingManage:
                    return ModuleType.DeviceSettingManage;
                case ModuleType.EmployeesManage:
                    return ModuleType.EmployeesManage;
                //case ModuleType.EmployeeTypeSet:
                   // return ModuleType.EmployeeTypeSet;
                //case ModuleType.EmployeeWeekly:
                 //   return ModuleType.EmployeeWeekly;
               // case ModuleType.EmployeeWorkCalendarMonthly:
                //    return ModuleType.EmployeeWorkCalendarMonthly;
               // case ModuleType.EmployeeWorkCalendarMonthlyMultiUsers:
                  //  return ModuleType.EmployeeWorkCalendarMonthlyMultiUsers;
                //case ModuleType.EmployeeJobCode:
                    //return ModuleType.EmployeeJobCode;
                case ModuleType.AccessControlManage:
                    return ModuleType.AccessControlManage;
                case ModuleType.TimeAttendanceManage:
                    return ModuleType.TimeAttendanceManage;
               // case ModuleType.WorkShiftManagement:
                  //  return ModuleType.WorkShiftManagement;
                //case ModuleType.AttendanceReportWeekly:
                //    return ModuleType.AttendanceReportWeekly;
                //case ModuleType.AttendanceReportWorkCalendar:
                 //   return ModuleType.AttendanceReportWorkCalendar;
                //case ModuleType.AttendanceReportMultiWorkShift:
                 //   return ModuleType.AttendanceReportMultiWorkShift;
                //case ModuleType.AttendanceStatusSetting:
                 //   return ModuleType.AttendanceStatusSetting;
                //case ModuleType.AttendanceStatusSheet:
                 //   return ModuleType.AttendanceStatusSheet;
                //case ModuleType.TransactionsReport:
                //    return ModuleType.TransactionsReport;
                //case ModuleType.TransactionAdd:
                //    return ModuleType.TransactionAdd;
                //case ModuleType.TransactionModify:
                //    return ModuleType.TransactionModify;
               // case ModuleType.GlobalHolidaySetting:
                 //   return ModuleType.GlobalHolidaySetting;
                //case ModuleType.LeaveType:
                   // return ModuleType.LeaveType;
               // case ModuleType.JustificationLeaveApplication:
                //    return ModuleType.JustificationLeaveApplication;
                
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetMapModuleType(ModuleType moduleType)
        {
            switch (moduleType)
            {
                
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetMailMergeModuleType(ModuleType moduleType)
        {
            switch (moduleType)
            {
                
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetAnalysisModuleType(ModuleType moduleType)
        {
            switch (moduleType)
            {
                
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetPeekModuleType(ModuleType moduleType)
        {
            switch (moduleType)
            {
                
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetNavPaneModuleType(ModuleType moduleType)
        {
            switch (moduleType)
            {
                case ModuleType.Employees:
                    return ModuleType.Employees;
                case ModuleType.DeviceSetting:
                    return ModuleType.DeviceSetting;
                case ModuleType.Supervisor:
                    return ModuleType.Supervisor;
                case ModuleType.AccessControl:
                    return ModuleType.AccessControl;
                case ModuleType.TimeAttendance:
                    return ModuleType.TimeAttendance;
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetNavPaneHeaderModuleType(ModuleType moduleType)
        {
            switch (moduleType)
            {
                case ModuleType.Employees:
                    return ModuleType.Employees;
                case ModuleType.DeviceSetting:
                    return ModuleType.DeviceSetting;
                case ModuleType.Supervisor:
                    return ModuleType.Supervisor;
                case ModuleType.AccessControl:
                    return ModuleType.AccessControl;
                case ModuleType.TimeAttendance:
                    return ModuleType.TimeAttendance;
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetExportModuleType(ModuleType moduleType)
        {
            switch (moduleType)
            {
                
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetPrintModuleType(ModuleType moduleType)
        {
            switch (moduleType)
            {
                
                default:
                    return ModuleType.Unknown;
            }
        }
    }
}
