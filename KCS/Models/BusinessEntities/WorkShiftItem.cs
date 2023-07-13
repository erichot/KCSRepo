using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class WorkShiftItem
    {
        public string CLASS_CODE { get; set; }
        public string CLASS_DESC { get; set; }       
        public string WORK_TIME_START { get; set; }
        public string WORK_TIME_END { get; set; }


        //public string WORK_TIME_LATE { get; set; }
        //public string WORK_TIME_OVERTIME { get; set; }
    }
}
