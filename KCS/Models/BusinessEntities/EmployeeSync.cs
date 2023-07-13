using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class EmployeeSync : DatabaseObject
    {
        [Key]
        public int UserSID { get; set; }        
        
        public string DepartmentName { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }        
        public string CardID { get; set; }        
        public bool IsReplicated { get; set; }
        public DateTime TimeReplicated { get; set; }
        public bool SyncFlag { get; set; }
        public int SlaveSID { get; set; }   
        public EmployeeSync()
        {
            this.UserSID = 0;
            this.DepartmentName = "";
            this.UserID = "";
            this.UserName = "";
            this.CardID = "";
            this.SlaveSID = 0;
            this.IsReplicated = false;
            //this.TimeReplicated = null;
            this.SyncFlag = false;
        }
        public EmployeeSync(EmployeeSync employeesync)
        {
            this.UserSID = employeesync.UserSID;
            this.DepartmentName = employeesync.DepartmentName;
            this.UserID = employeesync.UserID;
            this.UserName = employeesync.UserName;
            this.CardID = employeesync.CardID;
            this.SlaveSID = employeesync.SlaveSID;
            this.IsReplicated = employeesync.IsReplicated;
            this.TimeReplicated = employeesync.TimeReplicated;
            this.SyncFlag = employeesync.SyncFlag;
        }
    }
}
