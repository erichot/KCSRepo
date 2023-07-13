using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class AnnulaCalendar
    {
        public int LIST_YEAR { get; set; }
        public DateTime LIST_DATE { get; set; }
        public string LIST_WEEK { get; set; }
        public string LIST_MEMO { get; set; }
        public bool HOLIDAY_CK { get; set; }
        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }
        public int LIST_GRP { get; set; }

        public Image HolidayStatsImage
        {
            get
            {
                if (HOLIDAY_CK)
                {
                    return Properties.Resources.icon_check;
                }
                else
                {
                    return null;
                }
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
                       return  KCS.Common.Utils.LanguageResource.GetDisplayString("RestDayText");
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
        public int CalendarDay {
            get
            {
                return LIST_DATE.Day;
            }
        }
        public int CalendarMonth {
            get
            {
                return LIST_DATE.Month;
            }
            

        }
        public int CalendarMonthName
        {
            get
            {
                return LIST_DATE.Month;
            }

        }

        public AnnulaCalendar()
        {
            this.LIST_YEAR = DateTime.Now.Year;
            this.LIST_DATE = DateTime.Now.Date;
            this.LIST_WEEK = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            this.LIST_MEMO = "";
            this.HOLIDAY_CK = false;
            this.CREATE_NAME = "";
            this.CREATE_TIME = DateTime.Now;
            this.BUILD_NAME = "";
            this.BUILD_TIME = DateTime.Now;
            this.LIST_GRP = 0;
        }

        public AnnulaCalendar(AnnulaCalendar calendar)
        {
            this.LIST_YEAR = calendar.LIST_YEAR;
            this.LIST_DATE = calendar.LIST_DATE;
            this.LIST_WEEK = calendar.LIST_WEEK;
            this.LIST_MEMO = calendar.LIST_MEMO;
            this.HOLIDAY_CK = calendar.HOLIDAY_CK;
            this.CREATE_NAME = calendar.CREATE_NAME;
            this.CREATE_TIME = calendar.CREATE_TIME;
            this.BUILD_NAME = calendar.BUILD_NAME;
            this.BUILD_TIME = calendar.BUILD_TIME;
            this.LIST_GRP = calendar.LIST_GRP;
        }
    }
}
