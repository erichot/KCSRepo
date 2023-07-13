using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class EmployeeMsg
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string DepartmentName { get; set; }
       

        public string Details
        {
            get
            {
                return DepartmentName + "," + UserID + "," + UserName ;
            }
        }
    }
}
