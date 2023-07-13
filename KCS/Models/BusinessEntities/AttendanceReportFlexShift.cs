using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class AttendanceReportFlexShift
    {
        
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string WorkDateString { get; set; }
        public string WEEKDAYNAME { get; set; }
        public string WorkingTimeOnString { get; set; }        
        public string WorkingTimeOffString { get; set; }       
        public string WorkingTimeTotal { get; set; }
        public int WorkingTimeTotalMinute { get; set; }




    }
}
