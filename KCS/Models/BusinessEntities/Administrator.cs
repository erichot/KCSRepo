using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public class Administrator
    {
        public string UserNo { get; set; }
        public string UserName { get; set; }
        public string OldUserPwd { get; set; }
        public string UserPwd { get; set; }
        public string NewUserPwd { get; set; }
        public string NewUserPwdAgain { get; set; }

        public Administrator()
         {
             this.UserNo = "";
             this.UserName = "";
             this.OldUserPwd = "";
             this.UserPwd = "";
             this.NewUserPwd = "";
             this.NewUserPwdAgain = "";
         }
    }
}
