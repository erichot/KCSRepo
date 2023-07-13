using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class PerShiftTable : PerShiftTableBase
    {
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string UserName { get; set; }
        
        public string CardID { get; set; }
        public int CheckYear { get; set; }
       // public DateTime CHK_DATE { get; set; }
        public string CLASS_CODE { get; set; }
        public string CLASS_DESC { get; set; }
        public bool CLOCK_CK { get; set; }
        public string LEAVE_CODE { get; set; }
        public bool CHK { get; set; }
        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }
        //public int LIST_GRP { get; set; }
        //public string WORK_TIME_START { get; set; }
        //public string WORK_TIME_END { get; set; }
        public string WORK_TIME_LATE { get; set; }
        public string WORK_TIME_OVERTIME { get; set; }
        public double TURN_OVERTIME { get; set; }
       // public string RELAX_TIME1 { get; set; }
       // public string RELAX_TIME2 { get; set; }
        //public string RELAX_TIME3 { get; set; }
        //public string RELAX_TIME4 { get; set; }

        public string DepartmentNote
        {
            get
            {
                return DepartmentID + ":" + DepartmentName;
            }
        }
        public string EmployeeNote
        {
            get
            {
                return EMP_CODE + ":" + UserName;
            }
        }
        public int PerShiftTableMonth
        {
            get
            {
                return CHK_DATE.Month;
            }

        }
        public string PerShiftTableMonthName
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CHK_DATE.Month);
            }

        }
        public DayOfWeek PerShiftTableWeek
        {
            get
            {
                return CHK_DATE.DayOfWeek;
            }

        }
        public string PerShiftTableWeekName
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(CHK_DATE.DayOfWeek);
            }

        }

        public string HolidayType
        {
            get
            {
                if (LIST_GRP == null)
                {
                    return "";
                }
                else
                {
                    if (LIST_GRP == 1)
                    {
                        return KCS.Common.Utils.LanguageResource.GetDisplayString("RestDayText");
                    }
                    else if (LIST_GRP == 3)
                    {
                        return KCS.Common.Utils.LanguageResource.GetDisplayString("LegalHolidayText");
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            set
            {
                if (value.Equals(KCS.Common.Utils.LanguageResource.GetDisplayString("RestDayText")))
                {
                    LIST_GRP = 1;
                }
                else if (value.Equals(KCS.Common.Utils.LanguageResource.GetDisplayString("LegalHolidayText")))
                {
                    LIST_GRP = 3;
                }
                else
                {
                    LIST_GRP = 0;
                }
            }
        }
    }
}
