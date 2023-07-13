using KCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Sync
{
    public class ClientResultFactory : BridgeUtility
    {
        private string DeviceIp { get; set; }
        private string DevicePublicIp { get; set; }
        private int SlaveSID { get; set; }
        public delegate bool TransactionHandle(Transactions transactions);
        public TransactionHandle transactionHandleEvent;

        public ClientResultFactory(string DeviceIp, string DevicePublicIp, int SlaveSID)
        {
            this.DeviceIp = DeviceIp;
            this.DevicePublicIp = DevicePublicIp;
            this.SlaveSID = SlaveSID;
        }
        public  void AnalysReadDeviceResult(ref byte[] response, AsyncCallback callback = null)
        {
            int rcvDataLen = 1;
            int iTypePos = rcvDataLen;
            byte[] CardId = new byte[11];
            byte[] TransactionTime = new byte[32];
            byte[] TransactionDevIp = new byte[15];
            rcvDataLen++;
            Transactions transaction = new Transactions(DeviceIp, DevicePublicIp, SlaveSID, true);

            if (0x01 == (response[iTypePos] & 0x01))
            {
                transaction.TransactionType = response[1]; 
                rcvDataLen ++;
                Array.Copy(response,rcvDataLen, CardId, 0,11);
                rcvDataLen += 11;
                Array.Copy(response, rcvDataLen, TransactionTime, 0, 32);
                rcvDataLen += 32;
                Array.Copy(response, rcvDataLen, TransactionDevIp, 0, 15);
                rcvDataLen += 15;

                transaction.TransactionCardId = Encoding.UTF8.GetString(CardId);
                transaction.TransactionDateTime = Encoding.UTF8.GetString(TransactionTime);
                //transaction.DeviceIP = Encoding.UTF8.GetString(TransactionDevIp);
            }
            if (0x08 == (response[iTypePos] & 0x08))
            {
                transaction.IsByTranType = false;
                transaction.TransactionType = response[1];
                rcvDataLen++;
                Array.Copy(response, rcvDataLen, CardId, 0, 11);
                rcvDataLen += 11;
                Array.Copy(response, rcvDataLen, TransactionTime, 0, 32);
                rcvDataLen += 32;
                Array.Copy(response, rcvDataLen, TransactionDevIp, 0, 15);
                rcvDataLen += 15;
                transaction.DataType = response[rcvDataLen];
                rcvDataLen++;

                transaction.TransactionCardId = Encoding.UTF8.GetString(CardId);
                transaction.TransactionDateTime = Encoding.UTF8.GetString(TransactionTime);
                //transaction.DeviceIP = Encoding.UTF8.GetString(TransactionDevIp);
            }
            
            transactionHandleEvent.BeginInvoke(transaction, callback, transactionHandleEvent);
        }
    }
}
