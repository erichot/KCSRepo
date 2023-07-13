using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.DataAnnotations;
using KCS.Common;
using KCS.Common.Utils;

namespace KCS.Models
{

    public class Employees : DatabaseObject
    {
        [Key]
        public int UserSID { get; set; }
        [Required, Display(Name = "User ID"), StringLength(16)]
        public string UserID { get; set; }
        [Required]
        public string DepartmentID { get; set; }
        //[Required]
        public string DepartmentName { get; set; }
        [StringLength(64)]
        public string UserName { get; set; }
        [Required,Display(Name = "Card ID"), StringLength(10), Range(1,4294967295)]
        public string CardID { get; set; }
        [StringLength(32)]
        public string TitleName { get; set; }
        public bool InActive { get; set; }
        public string UserPWD { get; set; }
        //[EmailAddress]
        [StringLength(32)]
        public string Email { get; set; }
        public bool SyncOrNot { get; set; }
        public string UserPIN { get; set; }
        public int AllowTimeStartHour { get; set; }
        public int AllowTimeStartMinute { get; set; }
        public int AllowTimeEndHour { get; set; }
        public int AllowTimeEndMinute { get; set; }        
        public bool IsTaOrNot { get; set; }      
        public string EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }
        public string ValidDate { get; set; }
        public string PhoneMobile { get; set; }
        public int Finger1 { get; set; }
        public int Finger2 { get; set; }
        public string RegPhoto { get; set; }

        public Image EmpPhoto
        {
            get
            {
                try
                {
                    if (string.IsNullOrEmpty(RegPhoto))
                        return null;
                    return Image.FromFile(RegPhoto);
                }catch(Exception ex)
                {
                    return null;
                }
                
            }
            set
            {

            }
        }
        public string Finger1Status
        {
            get
            {
                if (Finger1 == 0)
                {
                    return LanguageResource.GetDisplayString("FingerNotEstablished");
                }
                else
                {
                    return LanguageResource.GetDisplayString("FingerEstablished");
                }
            }
        }
        public string Finger2Status
        {
            get
            {
                if (Finger2 == 0)
                {
                    return LanguageResource.GetDisplayString("FingerNotEstablished");
                }
                else
                {
                    return LanguageResource.GetDisplayString("FingerEstablished");
                }
            }
        }
        public string UserSIDString
        {
            get
            {
                return UserSID.ToString();
            }
        }
        public string DepListField {
            get
            {
                if (string.IsNullOrEmpty(DepartmentID) || string.IsNullOrEmpty(DepartmentName))
                    return null;
               return DepartmentID + ":" + DepartmentName;
            }
        }
        public string EmpTypeListField
        {
            get
            {
                if (string.IsNullOrEmpty(EmployeeTypeID) || string.IsNullOrEmpty(EmployeeTypeName))
                    return null;
                return EmployeeTypeID + ":" + EmployeeTypeName;
            }
        }
         

        public Employees()
        {
            this.UserID = "";
            this.DepartmentID = "";
            this.DepartmentName = "";
            this.UserName = "";
            this.CardID = "";
            this.TitleName = "";
            this.AllowTimeStartHour = 0;
            this.AllowTimeStartMinute = 0;
            this.AllowTimeEndHour = 23;
            this.AllowTimeEndMinute = 59;
            this.InActive = true;
            this.IsTaOrNot = false;
            this.UserSID = 0;
            this.UserPWD = "";
            this.EmployeeTypeID = "";
            this.EmployeeTypeName = "";
            this.Email = "";
            this.SyncOrNot = false;
            this.UserPIN = "888888";
            this.RegPhoto = null;
        }
        public Employees(Employees user)
        {

            this.UserID = user.UserID;
            this.DepartmentID = user.DepartmentID;
            this.DepartmentName = user.DepartmentName;
            this.UserName = user.UserName;
            this.CardID = user.CardID;
            this.TitleName = user.TitleName;
            this.AllowTimeStartHour = user.AllowTimeStartHour;
            this.AllowTimeStartMinute = user.AllowTimeStartMinute;
            this.AllowTimeEndHour = user.AllowTimeEndHour;
            this.AllowTimeEndMinute = user.AllowTimeEndMinute;
            this.InActive = user.InActive;
            this.IsTaOrNot = user.IsTaOrNot;
            this.UserSID = user.UserSID;
            this.UserPWD = user.UserPWD;
            this.EmployeeTypeID = user.EmployeeTypeID;
            this.EmployeeTypeName = user.EmployeeTypeName;
            this.Email = user.Email;
            this.SyncOrNot = user.SyncOrNot;
            this.UserPIN = user.UserPIN;
            this.RegPhoto = user.RegPhoto;
        }
        public Employees(string userId, string departmentId, string department, string username,
            string cardid, string tilename, int allowtimestarthour, int allowtimestartmin,
            int allowtimeendhour, int allowtimeendmin, bool inactive, bool istaornot, int usersid,
            string userpwd, string employeetypeid, string employeetypename,string email,bool syncornot,string userpin
            )
              {

            this.UserID = userId;
            this.DepartmentID = departmentId;
            this.DepartmentName = department;
            this.UserName = username;
            this.CardID = cardid;
            this.TitleName = tilename;
            this.AllowTimeStartHour = allowtimestarthour;
            this.AllowTimeStartMinute = allowtimestartmin;
            this.AllowTimeEndHour = allowtimeendhour;
            this.AllowTimeEndMinute = allowtimeendmin;
            this.InActive = inactive;
            this.IsTaOrNot = istaornot;
            this.UserSID = usersid;
            this.UserPWD = userpwd;
            this.EmployeeTypeID = employeetypeid;
            this.EmployeeTypeName = employeetypename;
            this.Email = email;
            this.SyncOrNot = syncornot;
            this.UserPIN = userpin; 
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is Employees)
            {
                var op1 = obj as Employees;
                if (op1.UserID == this.UserID &&
            op1.DepartmentID == this.DepartmentID &&
            op1.DepartmentName == this.DepartmentName &&
            op1.UserName == this.UserName &&
            op1.TitleName == this.TitleName &&
            op1.DepartmentID == this.DepartmentID &&
            op1.AllowTimeStartHour == this.AllowTimeStartHour &&
            op1.AllowTimeStartMinute == this.AllowTimeStartMinute &&
            op1.AllowTimeEndHour == this.AllowTimeEndHour &&
             op1.AllowTimeEndMinute == this.AllowTimeEndMinute &&
            op1.InActive == this.InActive &&
             op1.IsTaOrNot == this.IsTaOrNot &&
              op1.UserSID == this.UserSID &&
                    op1.UserPWD == this.UserPWD &&
                    op1.EmployeeTypeID == this.EmployeeTypeID &&
                    op1.EmployeeTypeName == this.EmployeeTypeName &&
                    op1.Email == this.Email &&
                    op1.SyncOrNot == this.SyncOrNot
                    && op1.UserPIN == this.UserPIN
                    && op1.RegPhoto == this.RegPhoto)
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
            return this.UserID.GetHashCode() | this.UserName.GetHashCode() | this.CardID.GetHashCode();
        }
        
        public static bool operator ==(Employees op1, Employees op2)
        {
            if (op1.UserID == op2.UserID &&
            op1.DepartmentID == op2.DepartmentID &&
            op1.DepartmentName == op2.DepartmentName &&
            op1.UserName == op2.UserName &&
            op1.TitleName == op2.TitleName &&
            op1.DepartmentID == op2.DepartmentID &&
            op1.AllowTimeStartHour == op2.AllowTimeStartHour &&
            op1.AllowTimeStartMinute == op2.AllowTimeStartMinute &&
            op1.AllowTimeEndHour == op2.AllowTimeEndHour &&
             op1.AllowTimeEndMinute == op2.AllowTimeEndMinute &&
            op1.InActive == op2.InActive &&
             op1.IsTaOrNot == op2.IsTaOrNot &&
              op1.UserSID == op2.UserSID &&
                    op1.UserPWD == op2.UserPWD &&
                    op1.EmployeeTypeID == op2.EmployeeTypeID &&
                    op1.EmployeeTypeName == op2.EmployeeTypeName &&
                    op1.Email == op2.Email &&
                    op1.SyncOrNot == op2.SyncOrNot &&
                    op1.UserPIN == op2.UserPIN &&
                    op1.RegPhoto == op2.RegPhoto)
            {
                return true;
            }
            else
            {
                return false;
            }
         }
        public static bool operator !=(Employees op1, Employees op2)
         {
            
             return !(op1 == op2);
         }


        public  override string ToString()
        {
            return UserID + ":" + UserName;
        }
    }
}
