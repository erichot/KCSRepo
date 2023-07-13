using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public interface IDepartment
    {
        string DepartmentID { get; set; }
        string DepartmentName { get; set; }
        int SupervisorSID { get; set; }
        int DepartmentStatus { get; set; }
    }
}
