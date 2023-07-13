using KCS.Common.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    static class TransactionDataSource
    {
        static public IList<TaTransaction> GetTaTransactionsList(int SlaveId, string start = null, string end = null, int queryCondtion = 0)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetTaTransactionsList(SlaveId, start, end, queryCondtion);
            return KCS.Common.Utils.ModelConvertHelper<TaTransaction>.ConvertToModel(dt);

        }
        static public int GetTaTransactionsCount(List<int> slaveIdList, string start, string end)
        {
            return KCSDatabaseHelper.Instance.GetTaTransactionsCount(slaveIdList, start, end);
            
        }
        static public IList<TaTransaction> GetTaTransactionsList(List<int> slaveIdList, string start, string end)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetTaTransactionsList(slaveIdList, start, end);
            return KCS.Common.Utils.ModelConvertHelper<TaTransaction>.ConvertToModel(dt);
        }
        static public int InsertTransactions(TaTransaction trans)
        {
            return KCSDatabaseHelper.Instance.InsertTransactions(trans, CredentialsSource.GetLoginSupervisorSID());
        }
        static public int UpdateTransactions(TaTransaction trans)
        {
            return KCSDatabaseHelper.Instance.UpdateTransactions(trans,CredentialsSource.GetLoginSupervisorSID());
        }
    }
}
