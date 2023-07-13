using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class WorkShift : DatabaseObject
    {

        [Required, Display(Name = "Shift Code"), StringLength(10)]
        public string CLASS_CODE { get; set; }
        public string CLASS_DESC { get; set; }
        [Required]
        public string WORK_TIME_START { get; set; }
        [Required]
        public string WORK_TIME_END { get; set; }
        public string WORK_TIME_LATE { get; set; }
        public string WORK_TIME_OVERTIME { get; set; }
        public double TURN_OVERTIME { get; set; }
        public string RELAX_TIME1 { get; set; }
        public string RELAX_TIME2 { get; set; }
        public string RELAX_TIME3 { get; set; }
        public string RELAX_TIME4 { get; set; }
        public int TURN_TIME { get; set; }  //上班时间
        public string CREATE_NAME  { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }
        public int CLASS_AMT { get; set; }//班别津贴
        public bool LEAVE_CK { get; set; }//请假是否发放
        public double LEAVE_HOURS { get; set; }//当日缺勤最多时间

        public WorkShift()
        {
            this.CLASS_CODE = "";
            this.CLASS_DESC = "";
            //this.WORK_TIME_START = "";
           // this.WORK_TIME_END = "";
           // this.WORK_TIME_LATE = "";
           // this.WORK_TIME_OVERTIME = "";
            this.TURN_OVERTIME = 0.5f;
            //this.RELAX_TIME1 = "";
           // this.RELAX_TIME2 = "";
            //this.RELAX_TIME3 = "";
           // this.RELAX_TIME4 = "";
           // this.TURN_TIME = 0;
            this.CREATE_NAME = "";
            this.CREATE_TIME = DateTime.Now;
            this.BUILD_NAME = "";
            this.BUILD_TIME = DateTime.Now;
            this.CLASS_AMT = 0;
            this.LEAVE_CK = false;
           // this.LEAVE_HOURS = 0.0f;
        }
        public WorkShift(WorkShift workshift)
        {
            this.CLASS_CODE = workshift.CLASS_CODE;
            this.CLASS_DESC = workshift.CLASS_DESC;
            this.WORK_TIME_START = workshift.WORK_TIME_START;
            this.WORK_TIME_END = workshift.WORK_TIME_END;
            this.WORK_TIME_LATE = workshift.WORK_TIME_LATE;
            this.WORK_TIME_OVERTIME = workshift.WORK_TIME_OVERTIME;
            this.TURN_OVERTIME =workshift.TURN_OVERTIME;
            this.RELAX_TIME1 = workshift.RELAX_TIME1;
            this.RELAX_TIME2 = workshift.RELAX_TIME2;
            this.RELAX_TIME3 = workshift.RELAX_TIME3;
            this.RELAX_TIME4 = workshift.RELAX_TIME4;
            this.TURN_TIME = workshift.TURN_TIME;
            this.CREATE_NAME = workshift.CREATE_NAME;
            this.CREATE_TIME = workshift.CREATE_TIME;
            this.BUILD_NAME = workshift.BUILD_NAME;
            this.BUILD_TIME = workshift.BUILD_TIME;
            this.CLASS_AMT = workshift.CLASS_AMT;
            this.LEAVE_CK = workshift.LEAVE_CK;
            this.LEAVE_HOURS = workshift.LEAVE_HOURS;
        }

        /*
        [Required]
        public string ShiftCode { get; set; }
        [Required]
        public string ShiftName { get; set; }
        public string ListField { get; set; }
        public int StartTimeHour { get; set; }
        public int StartTimeMinute { get; set; }
        public int EndTimeHour { get; set; }
        public int EndTimeMinute { get; set; }
        public int DeductBreakMinute { get; set; }
        public bool IsDefault { get; set; }
        public string TotalTimeString { get; set; }

        public string StartTimeString {
            get
            {
                return StartTimeHour.ToString() + ":" + StartTimeMinute.ToString("D2");
            }
        }

        public string EndTimeString
        {
            get
            {
                return EndTimeHour.ToString() + ":" + EndTimeMinute.ToString("D2");
            }
        }
        public WorkShift()
        {
            this.ShiftCode = "";
            this.ShiftName = "";
            this.StartTimeHour = 9;
            this.StartTimeMinute = 0;
            this.EndTimeHour = 18;
            this.EndTimeMinute = 0;
            this.DeductBreakMinute = 0;
            this.IsDefault = false;
            this.TotalTimeString = "";
        }
        public WorkShift(WorkShift workshift)
        {
            this.ShiftCode = workshift.ShiftCode;
            this.ShiftName = workshift.ShiftName;
            this.StartTimeHour = workshift.StartTimeHour;
            this.StartTimeMinute = workshift.StartTimeMinute;
            this.EndTimeHour = workshift.EndTimeHour;
            this.EndTimeMinute = workshift.EndTimeMinute;
            this.DeductBreakMinute = workshift.DeductBreakMinute;
            this.IsDefault = workshift.IsDefault;
            this.TotalTimeString = workshift.TotalTimeString;
        }
         */
    }
}
