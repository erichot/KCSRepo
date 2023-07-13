using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class PerShiftTableBase
    {
        public string EMP_CODE { get; set; }
        public DateTime CHK_DATE { get; set; }
        public int LIST_GRP { get; set; }
        public string WORK_TIME_START { get; set; }
        public string WORK_TIME_END { get; set; }
        
        public string RELAX_TIME1 { get; set; }
        public string RELAX_TIME2 { get; set; }
        public string RELAX_TIME3 { get; set; }
        public string RELAX_TIME4 { get; set; }
        public float TURN_TIME { get; set; }
    }
}
