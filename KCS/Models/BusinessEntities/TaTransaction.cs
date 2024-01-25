using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class TaTransaction 
    {
        public int TranSID { get; set; }
        public string CardID { get; set; }       
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public DateTime TranDateTime { get; set; }
        public DateTime TranDate { get; set; }
        public DateTime TranTime { get; set; }
        public byte TranType { get; set; }
        public string JobName { get; set; }
        public int ID { get; set; }
        public string SlaveIP { get; set; }        
        public string SlaveDescription { get; set; }       
        public bool InActive { get; set; }
        public string Note { get; set; }
        public bool IsByTranType { get; set; }
        public int SlaveSID { get; set; }
        public byte DataType { get; set; }
        public Image TransImage { get; set; }
        public string DeviceName { get; set; }

        public decimal DegreeCelsius { get; set; }

        // 2023/12/01 Cy-Toyota
        public string SlaveIP_Public { get; set; }

        public string TranDateTimeString
        {
            get
            {
                return TranDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public TaTransaction()
        {

        }
        public TaTransaction(TaTransaction trans)
        {
            this.TranSID = trans.TranSID;
            this.CardID = trans.CardID;
            this.UserID = trans.UserID;
            this.UserName = trans.UserName;
            this.DepartmentID = trans.DepartmentID;
            this.DepartmentName = trans.DepartmentName;
            this.TranDateTime = trans.TranDateTime;
            this.TranDate = trans.TranDate;
            this.TranTime = trans.TranTime;
            this.TranType = trans.TranType;
            this.JobName = trans.JobName;
            this.ID = trans.ID;
            this.SlaveIP = trans.SlaveIP;
            this.SlaveDescription = trans.SlaveDescription;
            this.InActive = trans.InActive;
            this.Note = trans.Note;
            this.TransImage = trans.TransImage;
            this.DegreeCelsius = trans.DegreeCelsius;
        }

        public static bool operator ==(TaTransaction op1, TaTransaction op2)
        {
            if (op1.TranDateTime == op2.TranDateTime &&
                op1.TranType == op2.TranType &&
                op1.Note == op2.Note &&
                op1.InActive == op2.InActive 
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(TaTransaction op1, TaTransaction op2)
        {

            return !(op1 == op2);
        }
    }
}
