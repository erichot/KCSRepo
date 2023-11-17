using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public class LoginAdmin
    {
        public string UserNo { get; set; }
        public string UserName { get; set; }
        public int UserUnionType { get; set; }
        public int UserSID { get; set; }
        public int GroupSID { get; set; }
        public int UserPermissionTypeID { get; set; }
        public string DepartmentID { get; set; }
        public int DepartmentSID { get; set; }
        public int IsReadOnly { get; set; }
        public string UserPwd { get; set; }
        public bool IsCacheOrNot { get; set; }


        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
       * Add:     2023/08/08
       * Ver:     1.1.5.11
       */
        public DateTime? PasswordExpirationDate { get; set; }

        public bool IsLocked { get; set; }
        public DateTime? TimeLockout { get; set; }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



        public LoginAdmin()
        {
            this.UserNo = "";
            this.UserName = "";
            this.UserUnionType = 0;
            this.UserSID = 0;
            this.GroupSID = 0;
            this.UserPermissionTypeID = 0;
            this.DepartmentID = "";
            this.DepartmentSID = 0;
            this.IsReadOnly = 0;
            this.UserPwd = "";
            this.IsCacheOrNot = false;
            
        }
    }
}
