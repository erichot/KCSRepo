using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class TaLeaveType
    {
        [Required]
        public string LEAVE_CODE { get; set; }
        [Required]
        public string LEAVE_DESC { get; set; }
        public byte CUT_MODE { get; set; }
        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }
        public bool CUT_ABS { get; set; }

        public string LEAVE_MSG
        {
            get
            {
                return LEAVE_CODE + ":" + LEAVE_DESC;
            }
        }
        public TaLeaveType()
        {
            LEAVE_CODE = "";
            LEAVE_DESC = "";
            this.CREATE_NAME = "";
            this.CREATE_TIME = DateTime.Now;
            this.BUILD_NAME = "";
            this.BUILD_TIME = DateTime.Now;
            CUT_ABS = false;
        }
    }
}
