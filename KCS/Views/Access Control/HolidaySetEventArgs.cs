using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Views
{
    public class HolidaySetEventArgs : EventArgs
    {
        private byte holidayType;
        private string holidayDescription;

        public HolidaySetEventArgs(byte holidayType, string holidayDescription)
        {
            this.holidayType = holidayType;
            this.holidayDescription = holidayDescription;
        }
        public byte HolidayType
        {
            get
            {
                return this.holidayType;
            }
        }
        public string HolidayDescription
        {
            get
            {
                return this.holidayDescription;
            }
        }
    }
}
