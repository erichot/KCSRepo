using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public interface IUserInfoAdd
    {       
        int UserSID { get; set; }        
        string UserID { get; set; }
        string DepartmentID { get; set; }
        string UserName { get; set; }
        string CardID { get; set; }        
        Int32 FingerPrint1 { get; set; }
        Int32 FingerPrint2 { get; set; }
        byte Group1 { get; set; }
        byte Group2 { get; set; }
        string UserPin { get; set; }
        string ValidDate { get; set; }
        Int32 StartTime { get; set; }
        Int32 EndTime { get; set; }

        string RegPhoto { get; set; }
    }
    public interface IUserInfoDel
    {
        int UserSID { get; set; }
        string UserID { get; set; }
        string UserName { get; set; }
        string CardID { get; set; }
    }
    public interface IUserFingerAdd
    {
        string CardID { get; set; }
        int FPNo { get; set; }
        byte[] FingerData { get; set; }
    }
    public interface IUserFingerDel
    {
        string CardID { get; set; }
        int FPNo { get; set; }
    }
    public interface IAcTimeSet
    {
        byte DoorID { get; set; }
        byte TimeSetID { get; set; }
        byte StartHour { get; set; }
        byte StartMin { get; set; }
        byte EndHour { get; set; }
        byte EndMin { get; set; }
        string Description { get; set; }
    }
    public interface IAcTimeZone
    {
        byte DoorID { get; set; }
        byte TimeZoneID { get; set; }
        byte Frame01 { get; set; }
        byte Frame02 { get; set; }
        byte Frame03 { get; set; }
        byte Frame04 { get; set; }
        string Description { get; set; }
    }
    public interface IAcUserGroupSet
    {
        byte DoorID { get; set; }
        byte GroupID { get; set; }
        byte Sun { get; set; }
        byte Mon { get; set; }
        byte Tue { get; set; }
        byte Wed { get; set; }
        byte Thu { get; set; }
        byte Fri { get; set; }
        byte Sat { get; set; }
        byte Holi1Group { get; set; }
        byte Holi2Group { get; set; }
        byte Holi3Group { get; set; }
        byte Holi4Group { get; set; }
        byte Holi5Group { get; set; }
        byte Holi6Group { get; set; }
        byte Holi7Group { get; set; }
        byte Holi8Group { get; set; }
        string Description { get; set; }
    }
    public interface IAcHolidaySet
    {
        byte DoorID { get; set; }
        int DoorHoliID { get; set; }
        byte HoliMonth { get; set; }
        byte HoliDay { get; set; }
        byte HoliType { get; set; }
        string Description { get; set; }
    }
    public interface IAcAuthority
    {
        string CardID { get; set; }
        int SlaveID { get; set; }
        byte AllowTimeStartHour { get; set; }
        byte AllowTimeStartMinute { get; set; }
        byte AllowTimeEndHour { get; set; }
        byte AllowTimeEndMinute { get; set; }
        byte GroupID { get; set; }
    }
    public interface IChangeCardID
    {
        int ChangeID { get; set; }
        string OldCardID { get; set; }
        string NewCardID { get; set; }
    }
    public interface ISyncParameter
    {
        string MenuPwd { get; set; }
        bool SyncMenuPwdFlag { get; set; }
        int WorkMode { get; set; }
        bool SyncWorkModeFlag { get; set; }
        int Language { get; set; }
        bool SyncLanguageFlag { get; set; }
    }
   
}
