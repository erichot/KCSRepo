using KCS.Common.DAL;
using KCS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
   public class UserPermissionType
    {
         static int iAdministrators = 99;
         static int iSupervisorsAllDepartments = 29;
         static int iSupervisorsDepartment = 21;
         static int iUsers = 10 ;
         static int iGuest = 0;

         static string Administrators = LanguageResource.GetDisplayString("UserPermissionTypeAdministrators");
         static string SupervisorsAllDepartments = LanguageResource.GetDisplayString("UserPermissionTypeSupervisorsAllDepartments");
         static string SupervisorsDepartment = LanguageResource.GetDisplayString("UserPermissionTypeSupervisorsDepartment");
         static string Users = LanguageResource.GetDisplayString("UserPermissionTypeUsers");
         static string Guest = LanguageResource.GetDisplayString("UserPermissionTypeGuest");

        public int this[string name]
        {
            get
            {
                if (name.Equals(Administrators))
                {
                    return iAdministrators;
                }
                else if (name.Equals(SupervisorsAllDepartments))
                {
                    return iSupervisorsAllDepartments;
                }
                else if (name.Equals(SupervisorsDepartment))
                {
                    return iSupervisorsDepartment;
                }
                else if (name.Equals(Users))
                {
                    return iUsers;
                }
                else if (name.Equals(Guest))
                {
                    return iGuest;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string this[int EmployeeType]
        {
            get
            {
                if (EmployeeType == iAdministrators)
                {
                    return Administrators;
                }
                else if (EmployeeType == iSupervisorsAllDepartments)
                {
                    return SupervisorsAllDepartments;
                }
                else if (EmployeeType == iSupervisorsDepartment)
                {
                    return SupervisorsDepartment;
                }
                else if (EmployeeType == iUsers)
                {
                    return Users;
                }
                else if (EmployeeType == iGuest)
                {
                    return "";
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
