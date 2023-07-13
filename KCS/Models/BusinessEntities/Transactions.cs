using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class Transactions : ITransactions
    {
        public int TransSIDInDevice { get; set; }
        public byte TransactionType { get; set; }
        public string TransactionCardId { get; set; }
        public string TransactionDateTime { get; set; }
        public string DeviceIP { get; set; }
        public string DevicePublicIP { get; set; }
        public byte DataType { get; set; }
        public bool IsByTranType { get; set; }
        public int SlaveId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string DeviceName { get; set; }

        public float BodyTemp { get; set; }

        public byte RecordType
        {
            get
            {
                if (IsByTranType)
                    return TransactionType;
                else
                    return DataType;
            }
        }
        public Transactions()
        {
        }
        public Transactions(string DeviceIP, string DevicePublicIP, int SlaveId, bool IsByTranType)
        {
            this.DeviceIP = DeviceIP;
            this.DevicePublicIP = DevicePublicIP;
            this.SlaveId = SlaveId;
            this.IsByTranType = IsByTranType;
            this.UserId = "";
            this.UserName = "";
        }
        public Transactions(int SlaveId, bool IsByTranType, byte transType, byte DataType, string transCardId, string TransDateTime, string UserId, string UserName, string DeviceName)
        {
            this.TransactionType = transType;
            this.DataType = DataType;
            this.SlaveId = SlaveId;
            this.TransactionCardId = transCardId;
            this.TransactionDateTime = TransDateTime;
            this.IsByTranType = IsByTranType;
            this.UserId = string.IsNullOrEmpty(UserId) ? "" : UserId;
            this.UserName = string.IsNullOrEmpty(UserName) ? "" : UserName;
            this.DeviceName = DeviceName;
        }
    }
}
