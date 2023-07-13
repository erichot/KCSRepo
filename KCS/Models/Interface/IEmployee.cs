using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public interface IEmployee
    {
        // int UnionType { get; set; }
        int UserSID { get; set; }
        string UserID { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string PhoneMobile { get; set; }
        string DepartmentID { get; set; }
        // int GroupSID { get; set; }
        //int IsLogon { get; set; }
        //int UserAddNewSID { get; set; }
        //IDepartment Department { get; set; }
        int UserPermissionTypeID { get; set; }
        bool EmployeeAuthority { get; set; }


        //EmployeeStatus EmployeeStatus { get; set; }
        // DateTime TimeAddNew { get; set; }
        // DateTime TimeLastLogout { get; set; }

    }
}
