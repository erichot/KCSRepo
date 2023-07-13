using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class CalendarSettings
    {
        public int HolidayType { get; set; }
        public bool HolidayOrNot { get; set; }

        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }

        public CalendarSettings()
        {
            HolidayType = 0;
            //HolidayOrNot
        }
    }
}
