using KCS.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    
    public class PerLeaveItem : DatabaseObject
    {
        [Key]
        public string NUM { get; set; }    //请假编号 自动生成
        [Required]
        public DateTime USE_DATE { get; set; } //申请日期
        [Required]
        public string EMP_CODE { get; set; } //人员编号
        public bool SPHOLIDAY { get; set; } //特休
        public bool OVERDAY { get; set; } //加班转休假
        [Required]
        public string LEAVE_CODE { get; set; }//假别代号
        [Required]
        public DateTime LEAVE_DATE1 { get; set; }//请假开始日期
        [Required]
        public DateTime LEAVE_DATE2 { get; set; }//请假结束日期
        public string LEAVE_TIME1 { get; set; }//请假开始时间
       // [Required]
        public string LEAVE_TIME2 { get; set; }//请假结束时间
        //[Required]
        public Double SUM_TIME  { get; set; }   //时间总计
        public string AGENT { get; set; }      //代理人编号
        public string STATUS { get; set; }     //请假状态 等了核准 取消
        public string CFM_NAME { get; set; }      //核准人
        public DateTime? CFM_TIME { get; set; }      //核准时间
        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }

        public string EMP_NAME { get; set; } //人员姓名
        //public string AGENT_NAME { get; set; }      //代理人姓名
        //public string LEAVE_NAME { get; set; }//假别名称

        public string CFM_TIME_Str { get; set; } 
        public string CreateMsg
        {
            get
            {
                if (STATUS == "A")
                    return "";
                return CREATE_NAME + "  " + CREATE_TIME.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public string BuildMsg
        {
            get
            {
                if (STATUS == "A")
                    return "";
                return BUILD_NAME + "  " + BUILD_TIME.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public Image StatusImage
        {
            get
            {
                if (STATUS == "A")
                {
                    return Properties.Resources.Edit;
                }
                else if (STATUS == "B")
                {
                    return Properties.Resources.Confirm;
                }
                else
                {
                    return Properties.Resources.Cancel;
                }
            }
        }
        public string StatusStr
        {
            get
            {
                if (STATUS == "A" || STATUS == "D")
                {
                    return LanguageResource.GetDisplayString("StatusEdit");
                }
                else if (STATUS == "B")
                {
                    return LanguageResource.GetDisplayString("StatusApproval");
                }
                else
                {
                    return LanguageResource.GetDisplayString("StatusCancel");
                }
            }
            set
            {
                if (value.Equals(LanguageResource.GetDisplayString("StatusEdit")))
                {
                    STATUS = "A";
                }
                else if (value.Equals(LanguageResource.GetDisplayString("StatusApproval")))
                {
                    STATUS = "B";
                }
                else
                {

                    STATUS = "C";
                }
            }
        }
        public string USE_DATE_STR {
            get
            {
                return USE_DATE.Date.ToShortDateString();
            }

        }
        public string LEAVE_DATE1_STR
        { 
            get
            {
                return LEAVE_DATE1.ToShortDateString();
            }
        }
        public string LEAVE_DATE2_STR
        {
            get
            {
                return LEAVE_DATE2.ToShortDateString();
            }
        }
        public PerLeaveItem()
        {
            //this.NUM = "";
            //this.USE_DATE = DateTime.Now;
            //this.EMP_CODE = "";
            //this.SPHOLIDAY = false;
            //this.OVERDAY = false;
            //this.LEAVE_CODE = "";
            //this.AGENT = "";
            //this.STATUS = "A";
            //this.LEAVE_DATE1 = DateTime.Now;
            //this.LEAVE_DATE2 = DateTime.Now;
        }
        public PerLeaveItem(string leaveNum)
        {
            this.NUM = leaveNum;
            this.USE_DATE = DateTime.Now;
            this.EMP_CODE = "";
            this.SPHOLIDAY = false;
            this.OVERDAY = false;
            this.LEAVE_CODE = "";
            this.AGENT = "";
            this.STATUS = "D";
            this.LEAVE_DATE1 = DateTime.Now;
            this.LEAVE_DATE2 = DateTime.Now;
            this.CFM_TIME = null;
            this.CFM_TIME_Str = null;
            //this.LEAVE_TIME1 = DateTime.Now.ToShortTimeString();
            //this.LEAVE_TIME2 = DateTime.Now.ToShortTimeString();
             
           
        }
        public PerLeaveItem(PerLeaveItem leaveItem)
        {
            this.NUM = leaveItem.NUM;
            this.USE_DATE = leaveItem.USE_DATE;
            this.EMP_CODE = leaveItem.EMP_CODE;
            this.SPHOLIDAY = leaveItem.SPHOLIDAY;
            this.OVERDAY = leaveItem.OVERDAY;
            this.LEAVE_CODE = leaveItem.LEAVE_CODE;
            this.LEAVE_DATE1 = leaveItem.LEAVE_DATE1;
            this.LEAVE_DATE2 = leaveItem.LEAVE_DATE2;
            this.LEAVE_TIME1 = leaveItem.LEAVE_TIME1;
            this.LEAVE_TIME2 = leaveItem.LEAVE_TIME2;
            this.SUM_TIME = leaveItem.SUM_TIME;
            this.AGENT = leaveItem.AGENT;
            this.STATUS = leaveItem.STATUS;
            this.CFM_NAME = leaveItem.CFM_NAME;
            this.CFM_TIME = leaveItem.CFM_TIME;
            this.CREATE_NAME = leaveItem.CREATE_NAME;
            this.CREATE_TIME = leaveItem.CREATE_TIME;
            this.BUILD_NAME = leaveItem.BUILD_NAME;
            this.BUILD_TIME = leaveItem.BUILD_TIME;
            this.CFM_TIME_Str = leaveItem.CFM_TIME_Str;
        }
    }

}
