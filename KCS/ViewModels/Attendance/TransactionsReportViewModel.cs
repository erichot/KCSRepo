using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using KCS.Models;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class TransactionsReportViewModel
    {
        IList<TaTransaction> TransactionList;
         public static TransactionsReportViewModel Create()
        {

            return ViewModelSource.Create(() => new TransactionsReportViewModel());
        }
         protected TransactionsReportViewModel()
        {
            SelectDeviceId = 0;
            DateStart = null;
            DateEnd = null;
            QueryCondition = 0;
        }
        
         [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
         protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }

        public virtual int RecordCount { get; set; }
        public virtual DateTime? DateStart { get; set; }
        public virtual DateTime? DateEnd { get; set; }
        public virtual int QueryCondition { get; set; }
        public virtual int SelectDeviceId { get; set; }
        public virtual TaTransaction SelectedTransaction { get; set; }
        public object TransactionDataSet
        {
            get
            {
                if (DateStart == null || DateEnd == null)
                      TransactionList = TransactionDataSource.GetTaTransactionsList(SelectDeviceId, null, null, QueryCondition);
                else
                     TransactionList  = TransactionDataSource.GetTaTransactionsList(SelectDeviceId, DateStart.ToString(), DateEnd.ToString(), QueryCondition);
                //var TransactionList = TransactionDataSet as IList<TaTransaction>;
                RecordCount = TransactionList.Count;
                return TransactionList;
            }
           
        }
        public object DeviceInfoDataSet
        {
            get
            {
                return DevicesDataSource.GetDeviceBriefList();
            }
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<TransactionsReportViewModel>(this));
        }
        public void AddTransaction(object transactionObject)
        {
            var transaction = transactionObject as TaTransaction;
            var addTransViewModel = TransactionAddViewModel.Create(transaction);
            addTransViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("TransactionAdd", addTransViewModel);
            document.Show();
        }
        public void Edit(object transactionObject)
        {
            if (transactionObject == null)
                return;            
            var transaction = transactionObject as TaTransaction;
            var modifyTransViewModel =TransactionModifyViewModel.Create(transaction);
            modifyTransViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("TransactionModify", modifyTransViewModel);
            document.Show();
        }
        public void ReloadTransactions()
        {
            
            RebindDataSource();
            RecordCount = TransactionList.Count;
        }
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<TransactionsReportViewModel>(this, RecordCount));
        }
        
         public void TaHolidaySetting()
         {
             var document = DocumentManagerService.CreateDocument("TaHolidaySetting", TaHolidaySettingViewModel.Create());
             document.Show();
         }
         public void LeaveCategorySetting()
         {
             var document = DocumentManagerService.CreateDocument("LeaveType", LeaveTypeViewModel.Create());
             document.Show();
         }
         public void VocationSetting()
         {
             var document = DocumentManagerService.CreateDocument("JustificationLeaveApplication", JustificationLeaveApplicationViewModel.Create());
             document.Show();
         }
        
    }
}