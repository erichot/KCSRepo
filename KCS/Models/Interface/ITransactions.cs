using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public interface ITransactions
    {
        int  TransSIDInDevice{ get; set; }
        byte TransactionType { get; set; }
        string TransactionCardId { get; set; }
        string TransactionDateTime { get; set; }
        string DeviceIP { get; set; }
        string DevicePublicIP { get; set; }
        byte DataType { get; set; }
        bool IsByTranType { get; set; }
        int SlaveId { get; set; }


        // Add:     2022/05/11 
        // By:      Eric
        // Subject: 體溫
        float BodyTemp { get; set; }
        

    }
}
