using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class WorkShiftSetting
    {
        public string WorkShiftMon { get; set; }
        public string WorkShiftTues { get; set; }
        public string WorkShiftWedn { get; set; }
        public string WorkShiftThir { get; set; }
        public string WorkShiftFri { get; set; }
        public string WorkShiftSat { get; set; }
        public string WorkShiftSun { get; set; }

        public WorkShiftSetting()
        {
            WorkShiftMon = "";
            WorkShiftTues = "";
            WorkShiftWedn = "";
            WorkShiftThir = "";
            WorkShiftFri = "";
            WorkShiftSat = "";
            WorkShiftSun = "";
        }
        
    }
}
