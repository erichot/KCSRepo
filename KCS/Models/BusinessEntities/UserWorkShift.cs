 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class UserWorkShift : IUserWorkShift
    {
        public int UserSID { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        //public string UserID { get; set; }
        //public string UserName { get; set; }
        //public int WeekdayNo { get; set; }
        //public string WeekdayName { get; set; }
        //public string ShiftCode { get; set; }
        //public string ShiftCode_2nd { get; set; }
        //public string ShiftName { get; set; }
        //public string ShiftName_2nd { get; set; }
        //public int UserSID { get; set; }
        //public string StartTimeString { get; set; }
        //public string EndTimeString { get; set; }
        //public string StartTimeString_2nd { get; set; }
        //public string EndTimeString_2nd { get; set; }
    }
}
