using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.Common.Utils;
using KCS.ViewModels;
using KCS.Models;
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using KCS.Extensions;

namespace KCS.Views
{
    public partial class AllowTimeReportView : DevExpress.XtraEditors.XtraUserControl
    {
        KCS.Services.IWaitingService waitingService =  new KCS.Services.WaitingService();
        public AllowTimeReportView()
        {
            InitializeComponent();
        }
         protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
           // waitingService = GetService<Services.IWaitingService>();
        }
         void InitBindings()
         {
             var fluentAPI = mvvmContext.OfType<AllowTimeReportViewModel>();
             Messenger.Default.Register<WaitingMessage<AllowTimeReportViewModel>>(this, ShowWaiting);

            //fluentAPI.SetBinding(dateEditStart, x => x.EditValue, x => x.StartDate);
            //fluentAPI.SetBinding(dateEditEnd, x => x.EditValue, x => x.EndDate);
            //fluentAPI.SetBinding(checkByAttendanceRecords, x => x.Checked, x => x.ByTransactionType);

            //if (int.TryParse(cmbSlave.SelectedIndex.ToString(), out int _slaveSID)) {
            //    fluentAPI.SetBinding(cmbSlave, x => _slaveSID, x => x.SlaveSID);
            //}

            

            fluentAPI.SetObjectDataSourceBinding(bindingSourceDevice, x => x.DeviceInfoDataSet);
            fluentAPI.SetObjectDataSourceBinding(bindingSourceDepartment, x => x.DepartmentInfoDataSet);
            

            fluentAPI.SetBinding(cmbSlave, x => x.SelectedIndex, x => x.m_SelectedIndexSlave);
            fluentAPI.SetBinding(cmbDepartment, x => x.SelectedIndex, x => x.m_SelectedIndexDepartment);

            //fluentAPI.SetBinding(cmbStartHour, x => x.SelectedIndex, x => x.m_SelectedStartHour);
            //fluentAPI.SetBinding(cmbEndHour, x => x.SelectedIndex, x => x.m_SelectedEndHour);
            fluentAPI.SetBinding(cmbStartHour, x => x.SelectedIndex, x => x.m_SelectedStartHourText);
            fluentAPI.SetBinding(cmbEndHour, x => x.SelectedIndex, x => x.m_SelectedEndHourText);


            fluentAPI.BindCommand(simpleButtonQuery, x => x.RebindDataSource());
            //fluentAPI.SetBinding(cmbSlave, c => c.SelectedIndex, x => x.m_SelectedIndexSlave);
            //fluentAPI.SetBinding(cmbDepartment, c => c.SelectedIndex, x => x.m_SelectedIndexDepartment);
            //fluentAPI.SetBinding(cmbDepartment, c => c.SelectedValue, x => x.m_SelectedDepartmentID);
            //fluentAPI.SetBinding(lookUpEditSlave, x => x.EditValue, x => x.SlaveSID);

            //fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
            //  .SetBinding(x => x.Selection, e => GetSelectedEmployees());

            //fluentAPI.SetObjectDataSourceBinding(bindingSourceAllowTime, x => x.EmployeesBriefDataSet);


            //fluentAPI.WithEvent<EventArgs>(lookUpEditSlave, "SelectedIndexChanged")
            //   .EventToCommand(x => x.RebindDataSource());


            fluentAPI.SetObjectDataSourceBinding(bindingSourceAllowTime, x => x.UserSlaveAllowTimeList);
            Messenger.Default.Register<RebindMessage<AllowTimeReportViewModel>>(this, x => RebindDataSource());

            //fluentAPI.WithEvent<EventArgs>(cmbSlave, "SelectedIndexChanged")
            //   .EventToCommand(x => x.RebindDataSource());

            fluentAPI.BindCommand(bbiClose, x => x.Close());
            // fluentAPI.BindCommand(bbiDailyReport, x => x.DailyReport());
            // fluentAPI.BindCommand(bbiMonthlyReport, x => x.MonthlyReport());
            // fluentAPI.BindCommand(bbiMonthlySimplifiedReport, x => x.SimplifiedMonthlyReport());
            //fluentAPI.BindCommand(bbiFlexShiftReport, x => x.FlexShiftReport());

            //fluentAPI.WithEvent<selectinde>

            bbiExportToPDF.ItemClick += (s, e) =>
            {
                string fileName = ShowSaveFileDialog(exportData.GetValue(2, 0).ToString(), exportData.GetValue(2, 1).ToString());
                if (fileName == string.Empty) return;
                ExportToEx(fileName, "pdf", gridView);
                OpenFile(fileName);
            };
            bbiExportToExcel.ItemClick += (s, e) =>
            {
                string fileName = ShowSaveFileDialog(exportData.GetValue(0, 0).ToString(), exportData.GetValue(0, 1).ToString());
                if (fileName == string.Empty) return;
                ExportToEx(fileName, "xlsx", gridView);
                OpenFile(fileName);
            };

            //cmbStartHour.SelectedValue = 0;
            //cmbEndHour.SelectedValue = 23;
            cmbStartHour.SelectedIndex = 0;
            cmbEndHour.SelectedIndex = 0;
        }
         void InitViewDisplay()
         {
             //checkByAttendanceRecords.Text = LanguageResource.GetDisplayString("CalculateAttendanceRecordsOnly");
             colCardID.Caption = LanguageResource.GetDisplayString("CardID");
             colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
             colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
             colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentID");
             colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");

             bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
             //bbiDailyReport.Caption = LanguageResource.GetDisplayString("ToolBarDailyReport");
             //bbiMonthlyReport.Caption = LanguageResource.GetDisplayString("ToolBarMonthlyReport");
             //bbiMonthlySimplifiedReport.Caption = LanguageResource.GetDisplayString("ToolBarMonthlySimplifiedReport");
             ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
             ribbonPageGroupReport.Text = LanguageResource.GetDisplayString("AttendanceReport");

            simpleButtonQuery.Text = LanguageResource.GetDisplayString("QueryText");
        }
         //IEnumerable<EmployeeBrief> GetSelectedEmployees()
         //{
         //    return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as EmployeeBrief);
         //}
         void ShowWaiting(WaitingMessage<AllowTimeReportViewModel> message)
        {
            if (null == waitingService)
                return;
            if (message.IsShow)
            {

                waitingService.BeginWaiting(LanguageResource.GetDisplayString("ProcessingText") + "...");
            }
            else
            {
                waitingService.EndWaiting();
            }
        }

        void RebindDataSource()
        {            

            var fluentAPI = mvvmContext.OfType<AllowTimeReportViewModel>();
            fluentAPI.SetBinding(cmbSlave, x => x.SelectedIndex, x => x.m_SelectedIndexSlave);
            fluentAPI.SetBinding(cmbDepartment, x => x.SelectedIndex, x => x.m_SelectedIndexDepartment);

            //fluentAPI.SetBinding(cmbStartHour, x => x.SelectedIndex, x => x.m_SelectedStartHour);
            //fluentAPI.SetBinding(cmbEndHour, x => x.SelectedIndex, x => x.m_SelectedEndHour);
            fluentAPI.SetBinding(cmbStartHour, x => x.SelectedIndex, x => x.m_SelectedStartHourText);
            fluentAPI.SetBinding(cmbEndHour, x => x.SelectedIndex, x => x.m_SelectedEndHourText);

            fluentAPI.SetObjectDataSourceBinding(bindingSourceAllowTime,
                  x => x.UserSlaveAllowTimeList);           
        }

        private void bbiMonthlySimplifiedReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiMonthlyReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiFlexShiftReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void cmbSlave_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RebindDataSource();
            //Messenger.Default.Send(new RebindMessage<AllowTimeReportViewModel>(this));

            //var fluentAPI = mvvmContext.OfType<AllowTimeReportViewModel>();
            //Messenger.Default.Register<WaitingMessage<AllowTimeReportViewModel>>(this, ShowWaiting);

            //if (int.TryParse(cmbSlave.SelectedIndex.ToString(), out int _slaveSID))
            //{
            //    //fluentAPI.SetBinding(cmbSlave, x => x.SelectedIndex, x => x.SlaveSID);                
            //}


            //fluentAPI.SetObjectDataSourceBinding(bindingSourceAllowTime, x => x.UserSlaveAllowTimeList);
            //fluentAPI.SetBinding(cmbSlave, x => x.SelectedIndex, x => x.SlaveSID);
            //fluentAPI.SetObjectDataSourceBinding(bindingSourceAllowTime, x => x.UserSlaveAllowTimeList);
        }


        string[,] exportData = new string[,] {{"Microsoft Excel 2007 Document", "Microsoft Excel|*.xlsx", "xlsx"},
            {"Microsoft Excel Document", "Microsoft Excel|*.xls", "xls"},
            {"PDF Document", "PDF Files|*.pdf", "pdf"},
            {"Text Document", "Text Files|*.csv", "csv"}};
        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = "AllowTimeReport";//Application.ProductName;
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
                /*
                 * Remark:  2022/11/23
                 * By:      Eric
                 * Subject:    取消User & Departe群組功能
                 * Ver:         1.1.5.7
                 * Note:        (1) 匯出前後變動GroupIndex ，將造成欄位順序錯置，每次匯出檔案時，匯出內容的欄位順序不相同
                 *              (2) 取消群組功能，顯示&匯出都套用 => 透過UI，指定此兩欄位之GroupIndex=-1
                 */
                //colDepartmentID.GroupIndex = -1;
                //colUserID.GroupIndex = -1;


                if (ext == "pdf") exportView.ExportToPdf(filename);
                if (ext == "txt") exportView.ExportToCsv(filename);
                if (ext == "xlsx") exportView.ExportToXlsx(filename);


                //colDepartmentID.GroupIndex = 0;
                //colUserID.GroupIndex = 1;


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




    }
}
