using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class EmployeeAuthritySync : DatabaseObject
    {
       
        public string UserID { get; set; }            
        public string UserName { get; set; }       
        public string CardID { get; set; }       
        public int AllowTimeStartHour { get; set; }
        public int AllowTimeStartMinute { get; set; }
        public int AllowTimeEndHour { get; set; }
        public int AllowTimeEndMinute { get; set; }
        public byte GroupID { get; set; }
        public int SlaveSID { get; set; }
        public bool IsReplicated { get; set; }

        public string GroupIDStr
        {
            get
            {
                if (GroupID == 0)
                    return "";
                return GroupID.ToString();
            }
        }
        public string StartTimeStr
        {
            get
            {
                // Remark:  2024/04/23
                // Ver:
                // Note:    EmployeesAuthorityViewModel.bUseAdvAccessControlSet =>  SelectUserGroup => UserGroupNo
                //if (GroupID == 0)
                //    return "";
                return string.Format("{0:D2}", AllowTimeStartHour) + ":" + string.Format("{0:D2}", AllowTimeStartMinute);
            }
        }
       
        public string EndTimeStr
        {
            get
            {
                // Remark:  2024/04/23
                // Ver:
                // Note:    EmployeesAuthorityViewModel.bUseAdvAccessControlSet =>  SelectUserGroup => UserGroupNo
                //if (GroupID == 0)
                //    return "";
                return string.Format("{0:D2}", AllowTimeEndHour) + ":" + string.Format("{0:D2}", AllowTimeEndMinute);
            }
        }
    }
}
