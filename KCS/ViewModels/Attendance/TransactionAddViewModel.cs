using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class TransactionAddViewModel : KcsDocument
    {
        public virtual TaTransaction EditTransaction { get; set; }
        public virtual DateTime TransDateTime { get; set; }
        public virtual int TransType { get; set; }
         public static TransactionAddViewModel Create(TaTransaction transaction)
        {

            return ViewModelSource.Create(() => new TransactionAddViewModel(transaction));
        }
         protected TransactionAddViewModel(TaTransaction transaction)
        {
            EditTransaction = new TaTransaction();
            EditTransaction.CardID = transaction.CardID.TrimEnd('\0');
            EditTransaction.UserID = transaction.UserID;
            EditTransaction.UserName = transaction.UserName;
            TransDateTime = DateTime.Now;
            string ip = System.Net.Dns.GetHostName();
            if (ip.Length > 15)
                ip = ip.Substring(0, 15);
            EditTransaction.SlaveIP = ip;
            EditTransaction.Note = "AF";
           
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
         
         public void Save()
         {
             //if (string.IsNullOrEmpty(TransDateTime))
             //{
             //    return;
             //}
             try
             {
                 EditTransaction.TranDateTime = TransDateTime;
                 if (TransactionDataSource.InsertTransactions(EditTransaction) > 0)
                 {
                     Messenger.Default.Send(new RebindMessage<TimeAttendanceManageViewModel>(this.GetParentViewModel<TimeAttendanceManageViewModel>()));
                     Close();
                 }
                 else
                 {
                     MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
                 }
             }
             catch (Exception ex)
             {
                 MessageService.ShowMessage(ex.Message);
             }
         }
    }
}