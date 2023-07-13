using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using KCS.Common.Utils;
using KCS.Common.DAL;
using KCS.Models.BusinessEntities;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ExportDatasViewModel
    {
        public static ExportDatasViewModel Create()
        {
            return ViewModelSource.Create(() => new ExportDatasViewModel());
        }
        protected ExportDatasViewModel()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            proBarVisible = false;
            proBarValue = 0;
           
        }

        
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual bool proBarVisible { get; set; }
        public virtual int proBarValue { get; set; }

        public virtual bool checkExportAllDatas { get; set; }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        protected ISaveFileDialogService SaveFileDialogService
        {
            // using the GetService<> extension method for obtaining service instance
            get { return this.GetService<ISaveFileDialogService>(); }
        }
        public void ExportDatas()
        {
            int dataCount = 0;
            Dictionary<string, EmployeeTA_Data> EmployeesTA = new Dictionary<string, EmployeeTA_Data>();

        proBarVisible = true;
            proBarValue = 0;
            
            if (KCS.Common.DAL.SystemConfigure.slavesList.Count == 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedDevicesFirst"));
                return;
            }
            string strStartDate = StartDate.Year.ToString() + "-" +
                   StartDate.Month.ToString() + "-" +
                   StartDate.Day.ToString();
            string strEndDate = EndDate.Year.ToString() + "-" +
                   EndDate.Month.ToString() + "-" +
                   EndDate.Day.ToString();

            int TotalCount = TransactionDataSource.GetTaTransactionsCount(SystemConfigure.slavesList, string.Format("{0} {1}", strStartDate, StartTime.ToString("HH:mm")), string.Format("{0} {1}", strEndDate, EndTime.ToString("HH:mm")));
            if (TotalCount == 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                proBarVisible = false;
                return;
            }
            SaveFileDialogService.Filter = "Text|*.txt|CSV|*.csv|Excel|.xls";
            SaveFileDialogService.ShowDialog();
            string FileNmae = SaveFileDialogService.GetFullFileName();
            try
            {
                string startDateTime = string.Format("{0} {1}", strStartDate, StartTime.ToString("HH:mm"));
                int i = 0;
                          
                string strCurDate = "";

               // int transCountOneDay = 1;
                while (true)
                {
                    IList<TaTransaction> readTrans = TransactionDataSource.GetTaTransactionsList(SystemConfigure.slavesList, startDateTime, string.Format("{0} {1}", strEndDate, EndTime.ToString("HH:mm")));
                    if (readTrans.Count <= 0)
                        break;
                    ExportData exportData = new ExportData();
                    for (i = 0; i < readTrans.Count; i++)
                    {
                        
                        Transactions transaction = new Transactions(readTrans[i].SlaveSID, readTrans[i].IsByTranType, readTrans[i].TranType, readTrans[i].DataType, readTrans[i].CardID, readTrans[i].TranDateTime.ToString("yyyy-MM-dd HH:mm:ss"), readTrans[i].UserID, readTrans[i].UserName, readTrans[i].DeviceName);
                        if(!checkExportAllDatas)
                        {//导出首尾记录shen
                            strCurDate = readTrans[i].TranDateTime.ToString("yyyy-MM-dd");
                            if(!EmployeesTA.ContainsKey(readTrans[i].CardID))
                            {//第一条记录
                                exportData.ManulExportDataToTxt(transaction, FileNmae); 


                                EmployeesTA.Add(readTrans[i].CardID, new EmployeeTA_Data(strCurDate, transaction));
                            }
                            else
                            {
                                if (EmployeesTA[readTrans[i].CardID].CurrentDate != strCurDate)
                                {//第一条记录

                                    EmployeesTA[readTrans[i].CardID].CurrentDate = strCurDate;
                                    if (EmployeesTA[readTrans[i].CardID].TransCountInDate > 0)
                                    {
                                         exportData.ManulExportDataToTxt(EmployeesTA[readTrans[i].CardID].maxTransaction, FileNmae);
                                    }
                                    exportData.ManulExportDataToTxt(transaction, FileNmae);
                                    EmployeesTA[readTrans[i].CardID].maxTransaction = transaction;
                                    EmployeesTA[readTrans[i].CardID].TransCountInDate = 0;


                                }
                                else
                                {
                                    EmployeesTA[readTrans[i].CardID].TransCountInDate++;
                                    EmployeesTA[readTrans[i].CardID].maxTransaction = transaction;
                                }
                            }
                            

                        }
                        else
                        {
                            exportData.ManulExportDataToTxt(transaction, FileNmae);
                        }
                        dataCount++;
                        proBarValue = (int)(dataCount * 100.0 / TotalCount);
                       

                    }
                    foreach (var item in EmployeesTA)
                    {
                        exportData.ManulExportDataToTxt(item.Value.maxTransaction , FileNmae);
                    }
                        startDateTime = readTrans[i - 1].TranDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                    Messenger.Default.Send(new RebindMessage<ExportDatasViewModel>(this));
                    if (readTrans.Count <= 1)
                        break;
                }

                MessageService.ShowMessage(LanguageResource.GetDisplayString("ExportSucceeds"));
                proBarVisible = false;
            }
            catch (Exception ex)
            {
                MessageService.ShowMessage("Export Failed,Exception:" + ex.Message);
            }
        }
    }
}