using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class ReReadTransPara
    {
        public bool ReReadFlag { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public DateTime timeStart { get; set; }
        public DateTime timeEnd { get; set; }

        public ReReadTransPara()
        {
            ReReadFlag = false;
        }
    }
}
