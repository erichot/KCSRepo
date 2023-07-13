using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Views.Attendance
{
    public class TaHolidaySetEventArgs : EventArgs
    {
        public string DateStart;
        public string DateEnd;
        public string Description;
        public bool InActive;
        public int GlobalHolidaySID;
        public bool DeleteHoliday = false;
        public TaHolidaySetEventArgs(string dateStart, string dateEnd, string description, bool inactive, int holidayID, bool deleteHoliday)
        {
            this.DateStart = dateStart;
            this.DateEnd = dateEnd;
            this.Description = description;
            this.InActive = inactive;
            this.GlobalHolidaySID = holidayID;
            this.DeleteHoliday = deleteHoliday;
        }
        
    }
}
