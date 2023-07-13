using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public class Department :  DatabaseObject,IDepartment
    {

        [Key,StringLength(10)]
        public string DepartmentID { get; set; }
        [StringLength(36)]
        public string DepartmentName { get; set; }
        public int SupervisorSID { get; set; }
        public int DepartmentStatus { get; set; }
        public string ListField {
            get
            {
               return DepartmentID + ":" + DepartmentName;
            }
        }
        public Department()
        {
            this.DepartmentID = "";
            this.DepartmentName = "";
            this.SupervisorSID = 0;
            this.DepartmentStatus = 0;
           

        }
        public Department(Department department)
        {           

            this.DepartmentID = department.DepartmentID;
            this.DepartmentName = department.DepartmentName;
            this.SupervisorSID = department.SupervisorSID;
            this.DepartmentStatus = department.DepartmentStatus;
           

        }
        public Department(string id,string name,int sid,int status)
        {

            DepartmentID = id;
            DepartmentName = name;
            SupervisorSID = sid;
            DepartmentStatus = status;
            
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is Department)
            {
                var op1 = obj as Department;
                if (op1.DepartmentID == this.DepartmentID &&
            op1.DepartmentName == this.DepartmentName &&
            op1.DepartmentStatus == this.DepartmentStatus )
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
            return this.DepartmentID.GetHashCode() | this.DepartmentName.GetHashCode();
        }
        public static bool operator ==(Department op1, Department op2)
        {
            if (op1.DepartmentID == op2.DepartmentID &&
            op1.DepartmentName == op2.DepartmentName &&
            op1.DepartmentStatus == op2.DepartmentStatus )
            {
                  return true;
           }
           else
          {
                 return false;
           }
         }
        public static bool operator !=(Department op1, Department op2)
         {
             return !(op1 == op2);
         }
    }
}
