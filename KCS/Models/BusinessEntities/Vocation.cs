using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class Vocation
    {
        public int UserSID { get; set; }
        public int LeaveApplicationHeadSID { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public  string SelectDate { get; set; }
        public  string LeaveReson { get; set; }
        public  string LeaveType1 { get; set; }
        public  string LeaveType2 { get; set; }
        public  string LeaveType3 { get; set; }

        public  int Leave1Hours { get; set; }
        public  int Leave2Hours { get; set; }
        public  int Leave3Hours { get; set; }

        
        public Vocation()
        {
            UserSID = 0;
            LeaveApplicationHeadSID = 0;
            UserId = "";
            UserName = "";
            SelectDate = DateTime.Now.ToShortDateString();
            LeaveReson = "";
            LeaveType1 = "";
            LeaveType2 = "";
            LeaveType3 = "";
            Leave1Hours = 1;
            Leave2Hours = 1;
            Leave3Hours = 1;
        }
        public Vocation(Vocation vocation)
        {
            this.UserSID = vocation.UserSID;
            this.LeaveApplicationHeadSID = vocation.LeaveApplicationHeadSID;
            this.UserId = vocation.UserId;
            this.UserName = vocation.UserName;
            this.SelectDate = vocation.SelectDate;
            this.LeaveReson = vocation.LeaveReson;
            this.LeaveType1 = vocation.LeaveType1;
            this.LeaveType2 = vocation.LeaveType2;
            this.LeaveType3 = vocation.LeaveType3;
            this.Leave1Hours = vocation.Leave1Hours;
            this.Leave2Hours = vocation.Leave2Hours;
            this.Leave3Hours = vocation.Leave3Hours;
        }
        public static bool operator ==(Vocation op1, Vocation op2)
        {
            if (op1.LeaveReson == op2.LeaveReson &&
                op1.LeaveType1 == op2.LeaveType1 &&
                op1.LeaveType2 == op2.LeaveType2 &&
                op1.LeaveType3 == op2.LeaveType3 &&
                op1.Leave1Hours == op2.Leave1Hours &&
                op1.Leave2Hours == op2.Leave2Hours &&
                op1.Leave3Hours == op2.Leave3Hours 
                )
             {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Vocation op1, Vocation op2)
        {

            return !(op1 == op2);
        }

        
    }
}
