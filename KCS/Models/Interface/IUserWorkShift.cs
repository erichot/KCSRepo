using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public interface IUserWorkShift
    {
        int UserSID { get; set; }
        string DepartmentID { get; set; }
        string DepartmentName { get; set; }
        string UserID { get; set; }
        string UserName { get; set; }
        string Monday { get; set; }
        string Tuesday { get; set; }
        string Wednesday { get; set; }
        string Thursday { get; set; }
        string Friday { get; set; }
        string Saturday { get; set; }
        string Sunday { get; set; }
        //string UserID { get; set; }
        //string UserName { get; set; }
        //int WeekdayNo { get; set; }
        //string WeekdayName { get; set; }
        //string ShiftCode { get; set; }
        //string ShiftCode_2nd { get; set; }
        //string ShiftName { get; set; }
        //string ShiftName_2nd { get; set; }
        //int UserSID { get; set; }
        //string StartTimeString { get; set; }
        //string EndTimeString { get; set; }
        //string StartTimeString_2nd { get; set; }
        //string EndTimeString_2nd { get; set; }
    }
}
