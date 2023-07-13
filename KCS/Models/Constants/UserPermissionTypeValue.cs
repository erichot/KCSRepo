using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public enum UserPermissionTypeValue
    {
        Administrators = 99,
        SupervisorsAllDepartments = 29,
        SupervisorsDepartment = 21,
        Users = 10 ,
        Guest = 0
    }
}
