using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class UserSlaveAllowTimeSetting
    {
        public int SlaveID { get; set; }

        public string CardID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string DepartmentID { get; set; }        //[Required]
        public string DepartmentName { get; set; }        
        
        public string AllowTimeStartToEnd { get; set; }


        //public string UserTimeAddNewText { get; set; }

        public DateTime TimeAddNew { get; set; }

        public DateTime UserTimeAddNew { get; set; }

    }
}
