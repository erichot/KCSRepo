using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.ViewModels;
using KCS.Common.Utils;
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using KCS.Models;
using DevExpress.XtraGrid.Columns;

namespace KCS.Views
{
    public partial class TransactionsReport : BaseViewControl, IRibbonModule
    {
        public TransactionsReport()
            : base(typeof(TransactionsReportViewModel))
        {
            InitializeComponent();
        }
        protected override void OnLoad(System.EventArgs e)
        {

            base.OnLoad(e);
            gridControl.Load += gridControl_Load;
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();
            gridView.OptionsPrint.UsePrintStyles = false;

        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }
        void InitViewDisplay()
        {
            bbiHolidaySetting.Caption = LanguageResource.GetDisplayString("HolidaySetText");
            bbiLeaveCategory.Caption = LanguageResource.GetDisplayString("LeaveCategoryText");
            bbiVocationSetting.Caption = LanguageResource.GetDisplayString("VocationSettingText");
            bbiModifyTrans.Caption = LanguageResource.GetDisplayString("ModifyTransText");
            bbiAddTrans.Caption = LanguageResource.GetDisplayString("AddTransText");
            simpleButtonQuery.Text = LanguageResource.GetDisplayString("QueryText");
            lblCtlFrom.Text = LanguageResource.GetDisplayString("FromText");
            lblCtlTo.Text = LanguageResource.GetDisplayString("ToText");
            lblCtlDevice.Text = LanguageResource.GetDisplayString("ToolBarGroupDevice");
            colTranSID.Caption = LanguageResource.GetDisplayString("SystemCode");
            colCardID.Caption = LanguageResource.GetDisplayString("CardID");
            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentId");
            colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");
            colTranDateTime.Caption = LanguageResource.GetDisplayString("TransctionDateTime");
            colTranType.Caption = LanguageResource.GetDisplayString("TransactionType");
            colJobName.Caption = LanguageResource.GetDisplayString("JobNameText");
            colID.Caption = LanguageResource.GetDisplayString("DeviceID");
            colSlaveIP.Caption = LanguageResource.GetDisplayString("DeviceIP");
            colSlaveDescription.Caption = LanguageResource.GetDisplayString("DeviceDescription");
            colInActive.Caption = LanguageResource.GetDisplayString("ActiveInactiveText");

            bbiExportToTxt.Caption = LanguageResource.GetDisplayString("ExportToTxtText");
            bbiExportXLSX.Caption = LanguageResource.GetDisplayString("ExportXLSXText");
            bbiExprtToPDF.Caption = LanguageResource.GetDisplayString("ExportToPDFText");

            this.radioGroupCondition.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
             new DevExpress.XtraEditors.Controls.RadioGroupItem(0,  LanguageResource.GetDisplayString("BothText")),
             new DevExpress.XtraEditors.Controls.RadioGroupItem(1,  LanguageResource.GetDisplayString("OnlyActiveEmployee")),
             new DevExpress.XtraEditors.Controls.RadioGroupItem(2, LanguageResource.GetDisplayString("OnlyInactiveEmployee"))
            });
            radioGroupCondition.SelectedIndex = 0;

        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<TransactionsReportViewModel>();
            fluentAPI.BindCommand(bbiHolidaySetting, x => x.TaHolidaySetting());
            fluentAPI.BindCommand(bbiLeaveCategory, x => x.LeaveCategorySetting());
            fluentAPI.BindCommand(bbiVocationSetting, x => x.VocationSetting());
            fluentAPI.BindCommand(simpleButtonQuery, x => x.ReloadTransactions());
            fluentAPI.BindCommand(bbiAddTrans, x => x.AddTransaction(null), x => x.SelectedTransaction);
            fluentAPI.BindCommand(bbiModifyTrans, x => x.Edit(null), x => x.SelectedTransaction);

            


            fluentAPI.SetBinding(lookUpEditDevice, x => x.EditValue, x => x.SelectDeviceId);
            fluentAPI.SetBinding(dateEditStart, x => x.EditValue, x => x.DateStart);
            fluentAPI.SetBinding(dateEditEnd, x => x.EditValue, x => x.DateEnd);
            fluentAPI.SetBinding(radioGroupCondition, x => x.EditValue, x => x.QueryCondition);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceDevice, x => x.DeviceInfoDataSet);
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.TransactionDataSet);

            Messenger.Default.Register<UpdateCountMessage<TransactionsReportViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));
            Messenger.Default.Register<RebindMessage<TransactionsReportViewModel>>(this, x => RebindDataSource());

            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedTransaction,
                    args => args.Row as TaTransaction,
                    (gView, transaction) => gView.FocusedRowHandle = gView.FindRow(transaction));

            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                       .EventToCommand(
                           x => x.Edit(null), x => x.SelectedTransaction,
                           args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));

            barHeaderItem.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), fluentAPI.ViewModel.RecordCount.ToString());

            
            bbiExportToTxt.ItemClick += (s, e) =>
                {
                    string fileName = ShowSaveFileDialog(exportData.GetValue(3, 0).ToString(), exportData.GetValue(3, 1).ToString());
                          if (fileName == string.Empty) return;
                          ExportToEx(fileName, "txt", gridView);
                          
                          OpenFile(fileName);
                         
                };

            bbiExportXLSX.ItemClick += (s, e) =>
            {
                string fileName = ShowSaveFileDialog(exportData.GetValue(0, 0).ToString(), exportData.GetValue(0, 1).ToString());
                if (fileName == string.Empty) return;
                ExportToEx(fileName, "xlsx", gridView);
                OpenFile(fileName);

            };

            bbiExprtToPDF.ItemClick += (s, e) =>
            {
                string fileName = ShowSaveFileDialog(exportData.GetValue(2, 0).ToString(), exportData.GetValue(2, 1).ToString());
                if (fileName == string.Empty) return;
                ExportToEx(fileName, "pdf", gridView);
                OpenFile(fileName);
            };

            
        }
        string[,] exportData = new string[,] {{"Microsoft Excel 2007 Document", "Microsoft Excel|*.xlsx", "xlsx"}, 
            {"Microsoft Excel Document", "Microsoft Excel|*.xls", "xls"}, 
            {"PDF Document", "PDF Files|*.pdf", "pdf"},
            {"Text Document", "Text Files|*.csv", "csv"}};
        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = "Transactions";//Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = LanguageResource.GetDisplayString("ExportString") + LanguageResource.GetDisplayString("ToStrString") + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
        private void ExportToEx(String filename, string ext, BaseView exportView)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            
            try
            {
                //gridControl.he
                colDepartmentID.GroupIndex = -1;
                colUserID.GroupIndex = -1;
                if (ext == "pdf") exportView.ExportToPdf(filename);
                if (ext == "txt") exportView.ExportToCsv(filename);
                if (ext == "xlsx") exportView.ExportToXlsx(filename);

                colDepartmentID.GroupIndex = 0;
                colUserID.GroupIndex = 1;

            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = currentCursor;
        }
        private void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show(LanguageResource.GetDisplayString("OpenExportFile"), LanguageResource.GetDisplayString("ExportToString"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, LanguageResource.GetDisplayString("CannotOpenExportFile"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        void RebindDataSource()
        {
            //simpleButtonQuery.PerformClick();

            var fluentAPI = mvvmContext.OfType<TransactionsReportViewModel>();
            try
            {

                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                   x => x.TransactionDataSet);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KCS Error");
            }
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<TransactionsReportViewModel> message)
        {
            barHeaderItem.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }
        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion

        private void simpleButtonQuery_Click(object sender, EventArgs e)
        {

        }

        private void bbiExportXLSX_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
