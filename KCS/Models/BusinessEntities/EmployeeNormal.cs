using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using DevExpress.DataAnnotations;

namespace KCS.Models
{
     //DeleteCommand="DELETE FROM [BF_User] WHERE [UserSID] = @UserSID"         
      //  UpdateCommand="UPDATE [BF_User] SET [UserID] = @UserID, [DepartmentID] = @DepartmentID, [UserName] = @UserName, [CardID] = @CardID, [TitleName] = @TitleName, [InActive] = @InActive, [IsTaOrNot] = @IsTaOrNot, [Email] = @Email, [UserPWD] = @UserPWD, [UserPin] = @UserPin, [TimeModifyLast] = CURRENT_TIMESTAMP, [TimeModifyLastSID] = @TimeModifyLastSID, [EmployeeTypeID] = @EmployeeTypeID, [NotPropagateToSlaveByDefault] = @NotPropagateToSlaveByDefault  WHERE [UserSID] = @UserSID "
      //  SelectCommand="SELECT UserID, ListField, DepartmentID, DepartmentName, UserName, CardID, TitleName, AllowTimeStartHour, AllowTimeStartMinute, AllowTimeEndHour, AllowTimeEndMinute, InActive, IsTaOrNot, UserSID, UserPWD, EmployeeTypeID, EmployeeTypeName, Email, NotPropagateToSlaveByDefault FROM [VBF_User] WHERE (@DepartmentID IS NULL OR DepartmentID = @DepartmentID) AND (@EmployeeTypeID IS NULL OR EmployeeTypeID = @EmployeeTypeID) AND (@UserSID IS NULL OR UserSID = @UserSID) ORDER BY UserID"  
        
      //  InsertCommand="INSERT INTO [BF_User] ([UserID], [DepartmentID], [UserName], [CardID], [TitleName], [IsTaOrNot], [Email], [UserPWD], [UserPin], [UserAddNewSID], [EmployeeTypeID], [NotPropagateToSlaveByDefault]) VALUES (@UserID, @DepartmentID, @UserName, @CardID, @TitleName, @IsTaOrNot, @Email, @UserPWD, @UserPin, @UserAddNewSID, @EmployeeTypeID, @NotPropagateToSlaveByDefault);SELECT @UserSID=@@IDENTITY" >
       
    public class EmployeeNormal : DatabaseObject
    {
        [Required, Display(Name = "User ID")]
        string UserID {get;set;}
        string DepartmentID { get; set; }
        string DepartmentName { get; set; }
        string UserName { get; set; }
        [Required, Display(Name = "Card ID")]
        string CardID { get; set; }
        string TitleName { get; set; }
        int AllowTimeStartHour { get; set; }
        int AllowTimeStartMinute { get; set; }
        int AllowTimeEndHour { get; set; }
        int AllowTimeEndMinute { get; set; }
        bool InActive { get; set; }
        bool IsTaOrNot { get; set; }
        int UserSID { get; set; }
        string UserPWD { get; set; }
        string EmployeeTypeID { get; set; }
        string EmployeeTypeName { get; set; }
        [EmailAddress]
        string Email { get; set; }
        bool NotPropagateToSlaveByDefault { get; set; }  

        public EmployeeNormal()
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
            this.NotPropagateToSlaveByDefault = false;

        }
        public EmployeeNormal(EmployeeNormal user)
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
            this.NotPropagateToSlaveByDefault = this.NotPropagateToSlaveByDefault;
        }
        public EmployeeNormal(string userId,string departmentId,string department,string username,
            string cardid, string tilename, int allowtimestarthour, int allowtimestartmin,
            int allowtimeendhour, int allowtimeendmin, bool inactive, bool istaornot, int usersid,
            string userpwd, string employeetypeid, string employeetypename,string email,bool syncornot
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
            this.NotPropagateToSlaveByDefault = syncornot;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is EmployeeNormal)
            {
                var op1 = obj as EmployeeNormal;
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
                    op1.NotPropagateToSlaveByDefault == this.NotPropagateToSlaveByDefault)
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
        public static bool operator ==(EmployeeNormal op1, EmployeeNormal op2)
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
                    op1.NotPropagateToSlaveByDefault == op2.NotPropagateToSlaveByDefault)
            {
                return true;
            }
            else
            {
                return false;
            }
         }
        public static bool operator !=(EmployeeNormal op1, EmployeeNormal op2)
         {
             return !(op1 == op2);
         }

        public  override string ToString()
        {
            return UserID + ":" + UserName;
        }
    }
}
