using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class WorkList
    {
        public int WORK_YEAR { get; set; }
        public string TURNWORK_GRP { get; set; }
        public DateTime WORK_DATE { get; set; }
        public string WORK_WEEK { get; set; }
        public string CLASS_CODE { get; set; }
        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }
        public int LIST_GRP { get; set; }
        public string CLASS_DESC { get; set; }
        public string WORK_TIME_START { get; set; }
        public string WORK_TIME_END { get; set; }
        public string HolidayType
        {
            get
            {
                if (LIST_GRP == null)
                {
                    return "";
                }
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
        public string WORK_DATE_Dis
        {
            get
            {
                return WORK_DATE.ToShortDateString();
            }
        }
        public int WorkMonth
        {
            get
            {
                return WORK_DATE.Month;
            }
            

        }
        public string WorkMonthName
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(WORK_DATE.Month);
            }
        }
        public WorkList()
        {
            this.WORK_YEAR = 0;
            this.TURNWORK_GRP = "";
            this.WORK_DATE = DateTime.Now;
            this.WORK_WEEK = "";
            this.CLASS_CODE = "";
            this.CREATE_NAME = "";
            this.CREATE_TIME = DateTime.Now;
            this.BUILD_NAME = "";
            this.BUILD_TIME = DateTime.Now;
            this.LIST_GRP = 0;
            this.CLASS_DESC = "";
            this.WORK_TIME_START = "";
            this.WORK_TIME_END = "";
        }
        public WorkList(WorkList workList)
        {
            this.WORK_YEAR = workList.WORK_YEAR;
            this.TURNWORK_GRP = workList.TURNWORK_GRP;
            this.WORK_DATE = workList.WORK_DATE;
            this.WORK_WEEK = workList.WORK_WEEK;
            this.CLASS_CODE = workList.CLASS_CODE;
            this.CREATE_NAME = workList.CREATE_NAME;
            this.CREATE_TIME = workList.CREATE_TIME;
            this.BUILD_NAME = workList.BUILD_NAME;
            this.BUILD_TIME = workList.BUILD_TIME;
            this.LIST_GRP = workList.LIST_GRP;
            this.CLASS_DESC = workList.CLASS_DESC;
            this.WORK_TIME_START = workList.WORK_TIME_START;
            this.WORK_TIME_END = workList.WORK_TIME_END;
        }
    }
}
