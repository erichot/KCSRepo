using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class VocationSetting{

        public int LeaveApplicationHeadSID { get; set; }
        public int LeaveApplicationDetailSID { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }
        public string DateJustification { get; set; }
        public int UserSID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Reason { get; set; }
        public string LeaveTypeID { get; set; }
        public string LeaveTypeName { get; set; }
        public int LeaveMinute { get; set; }
        public int LeaveHour
        {
            get
            {
                return LeaveMinute / 60;
            }
        }
        public VocationSetting(VocationSetting vocation)
        {
            this.LeaveApplicationHeadSID = vocation.LeaveApplicationHeadSID;
            this.LeaveApplicationDetailSID = vocation.LeaveApplicationHeadSID;
            this.DepartmentID = vocation.DepartmentID;
            this.DepartmentName = vocation.DepartmentName;
            this.EmployeeTypeID = vocation.EmployeeTypeID;
            this.EmployeeTypeName = vocation.EmployeeTypeName;
            this.DateJustification = vocation.DateJustification;
            this.UserSID = vocation.UserSID;
            this.UserID = vocation.UserID;
            this.UserName = vocation.UserName;
            this.Reason = vocation.Reason;
            this.LeaveTypeID = vocation.LeaveTypeID;
            this.LeaveTypeName = vocation.LeaveTypeName;
            this.LeaveMinute = vocation.LeaveMinute;
        }
        public VocationSetting()
        {
            LeaveApplicationHeadSID = 0;
            LeaveApplicationDetailSID = 0;
            DepartmentID = "";
            DepartmentName = "";
            EmployeeTypeID = "";
            EmployeeTypeName = "";
            DateJustification = "";
            UserSID = 0;
            UserID = "";
            UserName = "";
            Reason = "";
            LeaveTypeID = "";
            LeaveTypeName = "";
            LeaveMinute = 0;
        }
    }
}
