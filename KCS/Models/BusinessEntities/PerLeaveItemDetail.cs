using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class PerLeaveItemDetail
    {
        public string NUM { get; set; }    //请假编号 自动生成
        public int SN { get; set; }        //请假条目编号
        public DateTime LEAVE_DATE { get; set; } //具体日期
        public Double TURN_HOUR { get; set; }     //应工作时数
        public Double SUM_TIME { get; set; }      //请假时数
        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }

        public PerLeaveItemDetail()
        {
            this.NUM = "";
            this.SN = 0;
            this.LEAVE_DATE = DateTime.Now;
            this.TURN_HOUR = 0;
            this.SUM_TIME = 0;
        }
        public PerLeaveItemDetail(PerLeaveItemDetail itemDetail)
        {
            this.NUM = itemDetail.NUM;
            this.SN = itemDetail.SN;
            this.LEAVE_DATE = itemDetail.LEAVE_DATE;
            this.TURN_HOUR = itemDetail.TURN_HOUR;
            this.SUM_TIME = itemDetail.SUM_TIME;
            this.CREATE_NAME = itemDetail.CREATE_NAME;
            this.CREATE_TIME = itemDetail.CREATE_TIME;
            this.BUILD_NAME = itemDetail.BUILD_NAME;
            this.BUILD_TIME = itemDetail.BUILD_TIME;
        }
        public string LEAVE_DATE_STR {
            get
            {
                return LEAVE_DATE.ToShortDateString();
            }
        }
    }
}
