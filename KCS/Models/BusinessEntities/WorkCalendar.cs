using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{    
    public class WorkCalendar
    {
        public int UserSID { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public short Year { get; set; }
        public byte Month { get; set; }
        public byte Day { get; set; }
        public string WeekdayName { get; set; }
        public string ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public byte StartTimeHour { get; set; }
        public byte StartTimeMinute { get; set; }
        public byte EndTimeHour { get; set; }
        public byte EndTimeMinute { get; set; }
        public int DeductBreakMinute { get; set; }
        public string Note { get; set; }

        public string StartTimeString {
            get
            {
                return StartTimeHour.ToString() + ":" + StartTimeMinute.ToString("D2");
            }
        }
        public string EndTimeString
        {
            get
            {
                return EndTimeHour.ToString() + ":" + EndTimeMinute.ToString("D2");
            }
        }
       
        public WorkCalendar()
        {
            this.UserSID = 0;
            this.Year = 0;
            this.Month = 0;
            this.Day = 0;
            this.ShiftCode = "";
            this.ShiftName = "";
            this.StartTimeHour = 9;
            this.StartTimeMinute = 0;
            this.EndTimeHour = 18;
            this.EndTimeMinute = 0;
            this.DeductBreakMinute = 0;
            this.Note = "";
        }
        public WorkCalendar(WorkCalendar workcalendar)
        {
            this.UserSID = workcalendar.UserSID;
            this.Year = workcalendar.Year;
            this.Month = workcalendar.Month;
            this.Day = workcalendar.Day;
            this.ShiftCode = workcalendar.ShiftCode;
            this.ShiftName = workcalendar.ShiftName;
            this.StartTimeHour = workcalendar.StartTimeHour;
            this.StartTimeMinute = workcalendar.StartTimeMinute;
            this.EndTimeHour = workcalendar.EndTimeHour;
            this.EndTimeMinute = workcalendar.EndTimeMinute;
            this.DeductBreakMinute = workcalendar.DeductBreakMinute;
            this.Note = workcalendar.Note;
        }
    }
}
