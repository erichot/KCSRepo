using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{

    public sealed class UserInfoAdd : IUserInfoAdd
    {
        public int UserSID { get; set; }
        public string UserID { get; set; }
        public string DepartmentID { get; set; }
        public string UserName { get; set; }
        public string CardID { get; set; }
        public Int32 FingerPrint1 { get; set; }
        public Int32 FingerPrint2 { get; set; }
        public byte Group1 { get; set; }
        public byte Group2 { get; set; }
        public string UserPin { get; set; }
        public string ValidDate { get; set; }
        public Int32 StartTime { get; set; }
        public Int32 EndTime { get; set; }

        public string RegPhoto { get; set; }
    }
    public sealed class UserInfoDel : IUserInfoDel
    {
        public int UserSID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string CardID { get; set; }
      
       
    }
    public sealed class UserFingerAdd : IUserFingerAdd
    {
        public string CardID { get; set; }
        public int FPNo { get; set; }
        public byte[] FingerData { get; set; }
    }
    public sealed class UserFingerDel : IUserFingerDel
    {
        public string CardID { get; set; }
        public int FPNo { get; set; }
    }
    public sealed class AcTimeSet : IAcTimeSet
    {
        public byte DoorID { get; set; }
        public byte TimeSetID { get; set; }
        public byte StartHour { get; set; }
        public byte StartMin { get; set; }
        public byte EndHour { get; set; }
        public byte EndMin { get; set; }
        public string Description { get; set; }
        public string TimeFrameDescription
        {
            get
            {
                return TimeSetID.ToString() + "(" + string.Format("{0:D2}", StartHour) + ":" + string.Format("{0:D2}", StartMin) + "~"+ string.Format("{0:D2}", EndHour) + ":" + string.Format("{0:D2}", EndMin) + ")";
            }
        }
        public string StartTimeStr
        {
            get
            {
                return string.Format("{0:D2}", StartHour) + ":" + string.Format("{0:D2}", StartMin);
            }
        }
        public DateTime StartTime
        {
            get
            {
                return Convert.ToDateTime(string.Format("{0:D2}", StartHour) + ":" + string.Format("{0:D2}", StartMin));
            }
            set{
                StartHour = (byte)value.Hour;
                StartMin = (byte)value.Minute;
                }
        }
        public string EndTimeStr
        {
            get
            {
                return string.Format("{0:D2}", EndHour) + ":" + string.Format("{0:D2}", EndMin);
            }
        }
        public DateTime EndTime
        {
            get
            {
                return Convert.ToDateTime(string.Format("{0:D2}", EndHour) + ":" + string.Format("{0:D2}", EndMin));
            }
            set
            {
                EndHour = (byte)value.Hour;
                EndMin = (byte)value.Minute;
            }
        }
        
        public AcTimeSet()
        {
        }
        public AcTimeSet(byte DoorID, byte TimeSetID, byte StartHour, byte StartMin, byte EndHour, byte EndMin, string Description)
        {
            this.DoorID = DoorID;
            this.TimeSetID = TimeSetID;
            this.StartHour = StartHour;
            this.StartMin = StartMin;
            this.EndHour = EndHour;
            this.EndMin = EndMin;
            this.Description = Description;
        }
    }
    public sealed class AcTimeZone:IAcTimeZone
    {
        public byte DoorID { get; set; }
        public byte TimeZoneID { get; set; }
        public byte Frame01 { get; set; }
        public byte Frame02 { get; set; }
        public byte Frame03 { get; set; }
        public byte Frame04 { get; set; }
        public string Description { get; set; }
        public byte FrameSet(int value)
        {
            switch (value)
            {
                case 0:
                    return Frame01;
                case 1:
                    return Frame02;
                case 2:
                    return Frame03;                
                default:
                    return Frame04;
            }
        }
        public AcTimeZone()
        {
        }
        public AcTimeZone(byte DoorID, byte TimeZoneID, byte Frame01, byte Frame02, byte Frame03, byte Frame04, string Description)
        {
            this.DoorID = DoorID;
            this.TimeZoneID = TimeZoneID;
            this.Frame01 = Frame01;
            this.Frame02 = Frame02;
            this.Frame03 = Frame03;
            this.Frame04 = Frame04;
            this.Description = Description;
        }
    }
    public sealed class AcUserGroupSet:IAcUserGroupSet
    {
        public byte DoorID { get; set; }
        public byte GroupID { get; set; }
        public byte Sun { get; set; }
        public byte Mon { get; set; }
        public byte Tue { get; set; }
        public byte Wed { get; set; }
        public byte Thu { get; set; }
        public byte Fri { get; set; }
        public byte Sat { get; set; }
        public byte Holi1Group { get; set; }
        public byte Holi2Group { get; set; }
        public byte Holi3Group { get; set; }
        public byte Holi4Group { get; set; }
        public byte Holi5Group { get; set; }
        public byte Holi6Group { get; set; }
        public byte Holi7Group { get; set; }
        public byte Holi8Group { get; set; }
        public string Description { get; set; }
        public byte WeekSet(int value)
        {
            switch (value)
            {
                case 0:
                    return Sun;
                case 1:
                    return Mon;
                case 2:
                    return Tue;
                case 3:
                    return Wed;
                case 4:
                    return Thu;
                case 5:
                    return Fri;
                default :
                    return Sat;
            }
        }
        public byte HolidaySet(int value)
        {
            switch (value)
            {
                case 0:
                    return Holi1Group;
                case 1:
                    return Holi2Group;
                case 2:
                    return Holi3Group;
                case 3:
                    return Holi4Group;
                case 4:
                    return Holi5Group;
                case 5:
                    return Holi6Group;
                case 6:
                    return Holi7Group;
                default:
                    return Holi8Group;
            }
        }
        public AcUserGroupSet()
        {
        }

        public AcUserGroupSet(byte DoorID, byte GroupID, byte Sun, byte Mon, byte Tue, byte Wed, byte Thu, byte Fri, byte Sat,
            byte Holi1Group, byte Holi2Group, byte Holi3Group, byte Holi4Group, byte Holi5Group, byte Holi6Group, byte Holi7Group, byte Holi8Group)
        {
            this.DoorID = DoorID;
            this.GroupID = GroupID;
            this.Sun = Sun;
            this.Mon = Mon;
            this.Tue = Tue;
            this.Wed = Wed;
            this.Thu = Thu;
            this.Fri = Fri;
            this.Sat = Sat;
            this.Holi1Group = Holi1Group;
            this.Holi2Group = Holi2Group;
            this.Holi3Group = Holi3Group;
            this.Holi4Group = Holi4Group;
            this.Holi5Group = Holi5Group;
            this.Holi6Group = Holi6Group;
            this.Holi7Group = Holi7Group;
            this.Holi8Group = Holi8Group;
        }
        public AcUserGroupSet(AcUserGroupSet usergroup)
        {
            this.DoorID = usergroup.DoorID;
            this.GroupID = usergroup.GroupID;
            this.Sun = usergroup.Sun;
            this.Mon = usergroup.Mon;
            this.Tue = usergroup.Tue;
            this.Wed = usergroup.Wed;
            this.Thu = usergroup.Thu;
            this.Fri = usergroup.Fri;
            this.Sat = usergroup.Sat;
            this.Holi1Group = usergroup.Holi1Group;
            this.Holi2Group = usergroup.Holi2Group;
            this.Holi3Group = usergroup.Holi3Group;
            this.Holi4Group = usergroup.Holi4Group;
            this.Holi5Group = usergroup.Holi5Group;
            this.Holi6Group = usergroup.Holi6Group;
            this.Holi7Group = usergroup.Holi7Group;
            this.Holi8Group = usergroup.Holi8Group;
        }

        public static bool operator ==(AcUserGroupSet op1, AcUserGroupSet op2)
        {
            if (op1.DoorID == op2.DoorID &&
            op1.GroupID == op2.GroupID &&
            op1.Sun == op2.Sun &&
            op1.Mon == op2.Mon &&
            op1.Tue == op2.Tue &&
            op1.Wed == op2.Wed &&
            op1.Thu == op2.Thu &&
            op1.Fri == op2.Fri &&
            op1.Sat == op2.Sat &&
             op1.Holi1Group == op2.Holi1Group &&
            op1.Holi2Group == op2.Holi2Group &&
             op1.Holi3Group == op2.Holi3Group &&
              op1.Holi4Group == op2.Holi4Group &&
                    op1.Holi5Group == op2.Holi5Group &&
                    op1.Holi6Group == op2.Holi6Group &&
                    op1.Holi7Group == op2.Holi7Group &&
                    op1.Holi8Group == op2.Holi8Group )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(AcUserGroupSet op1, AcUserGroupSet op2)
        {

            return !(op1 == op2);
        }

    }
    public sealed class AcHolidaySet:IAcHolidaySet
    {
        public byte DoorID { get; set; }
        public int DoorHoliID { get; set; }
        public byte HoliMonth { get; set; }
        public byte HoliDay { get; set; }
        public byte HoliType { get; set; }
        public string Description { get; set; }
    }
    public sealed class AcAuthority:IAcAuthority
    {
        public string CardID { get; set; }
        public int SlaveID { get; set; }
        public byte AllowTimeStartHour { get; set; }
        public byte AllowTimeStartMinute { get; set; }
        public byte AllowTimeEndHour { get; set; }
        public byte AllowTimeEndMinute { get; set; }
        public byte GroupID { get; set; }
    }
    public sealed class ChangeCardIDCls : IChangeCardID
    {
        public int ChangeID { get; set; }
        public string OldCardID { get; set; }
        public string NewCardID { get; set; }
    }
    public sealed class SyncParameter : ISyncParameter
    {
        public string MenuPwd { get; set; }
        public bool SyncMenuPwdFlag { get; set; }
        public int WorkMode { get; set; }
        public bool SyncWorkModeFlag { get; set; }
        public int Language { get; set; }
        public bool SyncLanguageFlag { get; set; }
    }
}
