using DevExpress.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public class EmployeeSupervisor : DatabaseObject,IEmployee 
    {
        [Key]
        public int UserSID { get; set; }
        [Required, Display(Name = "Supervisor ID"), StringLength(12)]
        public string UserID { get; set; }
        [Required, Display(Name = "Supervisor Name"), StringLength(64)]
        public string UserName { get; set; }
        //[EmailAddress]
        [StringLength(46)]
        public string Email { get; set; }
        [Display(Name = "Phone"), StringLength(16)]
        public string PhoneMobile { get; set; }
       // [NotMapped]
        public string DepartmentID { get; set; }
        [Display(Name = "Administrator type")]
        public int UserPermissionTypeID { get; set; }
        [Display(Name = "Read only")]
        public bool EmployeeAuthority { get; set; }
        //      
        //[DataType(DataType.MultilineText)]
        [StringLength(64)]
        public string Note { get; set; }
        public string DepartmentList { get; set; }
        [StringLength(32)]
        public string NewUserPwd { get; set; }
        [StringLength(32)]
        public string NewUserPwdAgain { get; set; }
     
        public string UserPermissionTypeBindable
        {
            get
            {
                UserPermissionType employUserPermission = new UserPermissionType();
                return employUserPermission[int.Parse(UserPermissionTypeID.ToString().Trim())];
            }
            set
            {
                if (!UserID.Equals("ADMIN"))
                {
                    UserPermissionType employUserPermission = new UserPermissionType();
                    UserPermissionTypeID = employUserPermission[value];
                }
            }
        }
        public EmployeeSupervisor()
        {
            this.UserSID = 0;
            this.UserID = "";
            this.UserName = "";
            this.Email = "";
            this.PhoneMobile = "";
            this.DepartmentID = "";
            this.Note = "";
            this.NewUserPwd = "";
            this.NewUserPwdAgain = "";

        }
        public EmployeeSupervisor(EmployeeSupervisor supervisor)
        {           

            this.UserSID = supervisor.UserSID;
            this.UserID = supervisor.UserID;
            this.UserName = supervisor.UserName;
            this.Email = supervisor.Email;
            this.PhoneMobile = supervisor.PhoneMobile;
            this.DepartmentID = supervisor.DepartmentID;
            this.UserPermissionTypeID = supervisor.UserPermissionTypeID;
            this.EmployeeAuthority = supervisor.EmployeeAuthority;
            this.Note = supervisor.Note;

            this.DepartmentList = supervisor.DepartmentList;
        }
        public EmployeeSupervisor(int sid, string userid, string username, string email, string phonemobile, string departmentid, int userpermissionid, bool authority, string note, string departmentlist)
        {          

            UserSID = sid;
            UserID = userid;
            UserName = username;
            Email = email;
            PhoneMobile = phonemobile;
            DepartmentID = departmentid;
            UserPermissionTypeID = userpermissionid;
            EmployeeAuthority = authority;
            Note = note;
            DepartmentList = departmentlist;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is EmployeeSupervisor)
            {
                var op1 = obj as EmployeeSupervisor;
                if (op1.UserSID == this.UserSID &&
            op1.UserID == this.UserID &&
            op1.UserName == this.UserName &&
            op1.Email == this.Email &&
            op1.PhoneMobile == this.PhoneMobile &&
            op1.DepartmentID == this.DepartmentID &&
            op1.UserPermissionTypeID == this.UserPermissionTypeID &&
            op1.EmployeeAuthority == this.EmployeeAuthority &&
            op1.Note == this.Note)
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
            return this.UserID.GetHashCode() | this.UserName.GetHashCode();
        }
        public static bool operator ==(EmployeeSupervisor op1, EmployeeSupervisor op2)
        {
            if (op1.UserSID == op2.UserSID &&
            op1.UserID == op2.UserID &&
            op1.UserName == op2.UserName &&
            op1.Email == op2.Email &&
            op1.PhoneMobile == op2.PhoneMobile &&
            op1.DepartmentID == op2.DepartmentID &&
            op1.UserPermissionTypeID == op2.UserPermissionTypeID &&
            op1.EmployeeAuthority == op2.EmployeeAuthority &&
            op1.Note == op2.Note)
            {
                  return true;
           }
           else
          {
                 return false;
           }
         }
        public static bool operator !=(EmployeeSupervisor op1, EmployeeSupervisor op2)
         {
             return !(op1 == op2);
         }
        
    }
}
