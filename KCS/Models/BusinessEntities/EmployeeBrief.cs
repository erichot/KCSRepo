using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class EmployeeBrief
    {
        public int UserSID { get; set; }      
        public string UserID { get; set; }
        public string DepartmentID { get; set; }        //[Required]
        public string DepartmentName { get; set; }
        public string UserName { get; set; }
        public string CardID { get; set; }
        public string ShiftCategory { get; set; }

        

    }
}
