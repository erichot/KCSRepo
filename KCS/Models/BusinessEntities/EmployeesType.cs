using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public class EmployeesType : DatabaseObject
    {
        [Key, Required,StringLength(16)]
        public string EmployeeTypeID { get; set; }
        [Required, StringLength(36)]
        public string EmployeeTypeName { get; set; }
        public bool InActive { get; set; }

        public EmployeesType()
        {
            this.EmployeeTypeID = "";
            this.EmployeeTypeName = "";
            this.InActive = false;
           

        }
        public EmployeesType(EmployeesType employeeType)
        {

            this.EmployeeTypeID = employeeType.EmployeeTypeID;
            this.EmployeeTypeName = employeeType.EmployeeTypeName;
            this.InActive = employeeType.InActive;
           

        }
        public EmployeesType(string id, string name, bool status)
        {

            EmployeeTypeID = id;
            EmployeeTypeName = name;
            InActive = status;
           
            
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is EmployeesType)
            {
                var op1 = obj as EmployeesType;
                if (op1.EmployeeTypeID == this.EmployeeTypeID &&
            op1.EmployeeTypeName == this.EmployeeTypeName &&
            op1.InActive == this.InActive)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }
        public override int GetHashCode()
        {
            return this.EmployeeTypeID.GetHashCode() | this.EmployeeTypeName.GetHashCode();
        }
        public static bool operator ==(EmployeesType op1, EmployeesType op2)
        {
            if (op1.EmployeeTypeID == op2.EmployeeTypeID &&
            op1.EmployeeTypeName == op2.EmployeeTypeName &&
            op1.InActive == op2.InActive)
            {
                  return true;
           }
           else
          {
                 return false;
           }
         }
        public static bool operator !=(EmployeesType op1, EmployeesType op2)
         {
             return !(op1 == op2);
         }
    }
}
