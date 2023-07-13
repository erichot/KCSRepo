using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class AttendanceReportSimplified
    {
        //public DateTime CHK_DATE { get; set; } //日期
       public  int GroupId { get; set; }
        public string DepartmentName { get; set; }//部门
        public string EMP_CODE { get; set; } //员工编号
        public int CheckDay { get; set; }
        public string UserName1 { get; set; }        
        public string OnDutyTime1 { get; set; }       
        public string OffDutyTime1 { get; set; }       
        public string OverTime1 { get; set; }//加班时间

        public string UserName2 { get; set; }
        public string OnDutyTime2 { get; set; }
        public string OffDutyTime2 { get; set; }
        public string OverTime2 { get; set; }//加班时间

        public string UserName3 { get; set; }
        public string OnDutyTime3 { get; set; }
        public string OffDutyTime3 { get; set; }
        public string OverTime3 { get; set; }//加班时间

        public string UserName4 { get; set; }
        public string OnDutyTime4 { get; set; }
        public string OffDutyTime4 { get; set; }
        public string OverTime4 { get; set; }//加班时间

        public string CheckDateString { get; set; } 
        
       
    
    }
}
