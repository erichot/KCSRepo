using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class TransactionModifyViewModel : KcsDocument
    {
        private TaTransaction backupEditTransaction;
        public virtual TaTransaction EditTransaction { get; set; }
        public static TransactionModifyViewModel Create(TaTransaction transaction)
        {

            return ViewModelSource.Create(() => new TransactionModifyViewModel(transaction));
        }
        protected TransactionModifyViewModel(TaTransaction transaction)
        {
            EditTransaction = new TaTransaction(transaction);
            backupEditTransaction = new TaTransaction(transaction);
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public void Save()
        {
            if (EditTransaction == backupEditTransaction)
            {
                Close();
                return;
            }
            if (TransactionDataSource.UpdateTransactions(EditTransaction) > 0)
            {
                Messenger.Default.Send(new RebindMessage<TimeAttendanceManageViewModel>(this.GetParentViewModel<TimeAttendanceManageViewModel>()));
                Close();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
            }
                       
        }
    }
}