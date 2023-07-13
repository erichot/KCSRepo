using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    //DateStartString AS DateStart, DateEndString AS DateEnd, [NumberOfDays], [Description], [InActive], [GlobalHolidaySID] 
    public class TaHolidays
    {
        [Required]
        public string HOLIDAY { get; set; }
        public string HOLIDAY_DESC { get; set; }
        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }
        public DateTime HOLIDAY_DT
        {
            get
            {
                if (HOLIDAY.Length == 4)
                    return Convert.ToDateTime(DateTime.Now.Year.ToString () +"/" + HOLIDAY.Substring(0, 2) + "/" + HOLIDAY.Substring(2, 2));
                return DateTime.Now ;
            }
            set
            {
               
                HOLIDAY = string.Format("{0:D2}{1:D2}", value.Month, value.Day);
            }

        }
        
        public string HOLIDAY_Dis { 
            get
            {
                if (HOLIDAY.Length == 4)
                    return HOLIDAY.Substring(0, 2) + "/" + HOLIDAY.Substring(2,2);
                return HOLIDAY;
            }
            set
            {
                DateTime DateSet = Convert.ToDateTime(value);
                HOLIDAY = string.Format("{0:D2}{1:D2}", DateSet.Month, DateSet.Day);
            }

        }
       
        public TaHolidays()
        {
            this.HOLIDAY = "";
            this.HOLIDAY_DESC = "";
            this.CREATE_NAME = "";
            this.CREATE_TIME = DateTime.Now;
            this.BUILD_NAME = "";
            this.BUILD_TIME = DateTime.Now;

        }
        public TaHolidays(TaHolidays holi)
        {
            this.HOLIDAY = holi.HOLIDAY;
            this.HOLIDAY_DESC = holi.HOLIDAY_DESC;
            this.CREATE_NAME = holi.CREATE_NAME;
            this.CREATE_TIME = holi.CREATE_TIME;
            this.BUILD_NAME = holi.BUILD_NAME;
            this.BUILD_TIME = holi.BUILD_TIME;

        }
        
    }
}
