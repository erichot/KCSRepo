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
using DevExpress.XtraReports.UI;
using DevExpress.LookAndFeel;

namespace KCS.Views
{
    public partial class TimeAttendanceManage : BaseViewControl, IRibbonModule
    {
        KCS.Services.IWaitingService waitingService;
        public TimeAttendanceManage()
            : base(typeof(TimeAttendanceManageViewModel))
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
            waitingService = GetService<Services.IWaitingService>();
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
            bbiLeaveManagement.Caption = LanguageResource.GetDisplayString("LeaveManagementText");
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
            colTransImage.Caption = LanguageResource.GetDisplayString("PhotosText");

            bbiExportToTxt.Caption = LanguageResource.GetDisplayString("ExportToTxtText");
            bbiExportXLSX.Caption = LanguageResource.GetDisplayString("ExportXLSXText");
            bbiExprtToPDF.Caption = LanguageResource.GetDisplayString("ExportToPDFText");

            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
            ribbonPageGroupTASetting.Text = LanguageResource.GetDisplayString("TaSettingText");
            ribbonPageGroupTransactoins.Text = LanguageResource.GetDisplayString("TransactionText");
            ribbonPageGroupCalendar.Text = LanguageResource.GetDisplayString("AnnualCalendarText");
            ribbonPageGroupShiftTable.Text = LanguageResource.GetDisplayString("ShiftTabelEditionText");
            ribbonPageGroupAttendanceReport.Text = LanguageResource.GetDisplayString("AttendanceReport");

            bbiCalendarSettings.Caption = LanguageResource.GetDisplayString("SettingsText");

            biNewWorkShift.Caption = LanguageResource.GetDisplayString("ToolBarWorkShiftSetting");
            bbiJobCode.Caption = LanguageResource.GetDisplayString("ToolBarJobCode");
            bbiPrint.Caption = LanguageResource.GetDisplayString("PrintText");

            bbiReportDetails.Caption = LanguageResource.GetDisplayString("ReportDetails");
            bbiReportCount.Caption = LanguageResource.GetDisplayString("ReportCount");
            
            bbiShiftType.Caption = LanguageResource.GetDisplayString("ShiftTabelTypeText");
            bbiCalendarCreate.Caption = LanguageResource.GetDisplayString("CreateText");
            bbiEditCalendar.Caption = bbiEditAnnaulShiftTable.Caption = LanguageResource.GetDisplayString("EditText");
            bbiCreatePersonalCalendar.Caption = LanguageResource.GetDisplayString("CreatePersonalCalendarText");
            bbiEditPersonalShiftTable.Caption = LanguageResource.GetDisplayString("EditPersonalShiftTableText");

            this.radioGroupCondition.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
             new DevExpress.XtraEditors.Controls.RadioGroupItem(0,  LanguageResource.GetDisplayString("BothText")),
             new DevExpress.XtraEditors.Controls.RadioGroupItem(1,  LanguageResource.GetDisplayString("OnlyActiveEmployee")),
             new DevExpress.XtraEditors.Controls.RadioGroupItem(2, LanguageResource.GetDisplayString("OnlyInactiveEmployee"))
            });
            radioGroupCondition.SelectedIndex = 0;

          
        }
        void InitBindings()
        {
            
            var fluentAPI = mvvmContext.OfType<TimeAttendanceManageViewModel>();
            fluentAPI.BindCommand(bbiHolidaySetting, x => x.TaHolidaySetting());
            fluentAPI.BindCommand(bbiLeaveCategory, x => x.LeaveCategorySetting());
            fluentAPI.BindCommand(bbiLeaveManagement, x => x.VocationSetting());
            fluentAPI.BindCommand(simpleButtonQuery, x => x.ReloadTransactions());
            fluentAPI.BindCommand(bbiAddTrans, x => x.AddTransaction(null), x => x.SelectedTransaction);
            fluentAPI.BindCommand(bbiModifyTrans, x => x.Edit(null), x => x.SelectedTransaction);


            fluentAPI.BindCommand(biNewWorkShift, x => x.NewWorkShift());
            fluentAPI.BindCommand(bbiJobCode, x => x.JobCodeSet());

            fluentAPI.BindCommand(bbiCalendarSettings, x => x.CalendarSettings());
            fluentAPI.BindCommand(bbiCalendarCreate, x => x.CreateAnnualCalendar());
            fluentAPI.BindCommand(bbiEditCalendar, x => x.EditAnnualCalendar());
            fluentAPI.BindCommand(bbiPrint, x => x.PrintAnnualCalendar());

            fluentAPI.BindCommand(bbiShiftType, x => x.ShiftTableCategoryEdition());
            fluentAPI.BindCommand(bbiEditAnnaulShiftTable, x => x.EditAnnualShiftTable());
            fluentAPI.BindCommand(bbiCreatePersonalCalendar, x => x.CreatePersonalShiftTable());
            fluentAPI.BindCommand(bbiEditPersonalShiftTable, x => x.EditPersonalShiftTable());

            fluentAPI.BindCommand(bbiReportDetails, x => x.AttendanceReportDetails());
            fluentAPI.BindCommand(bbiReportCount, x => x.AttendanceReportStatics());

            // Modified:    2023/11/16
            // Version:     1.1.5.14
            // Note:        Toyota UI修正
            //fluentAPI.SetBinding(lookUpEditDevice, x => x.EditValue, x => x.SelectDeviceId);
            fluentAPI.SetBinding(cmbDevice, x => x.SelectedValue, x => x.SelectDeviceId);

            fluentAPI.SetBinding(dateEditStart, x => x.EditValue, x => x.DateStart);
            fluentAPI.SetBinding(dateEditEnd, x => x.EditValue, x => x.DateEnd);
            fluentAPI.SetBinding(radioGroupCondition, x => x.EditValue, x => x.QueryCondition);

            Messenger.Default.Register<UpdateCountMessage<TimeAttendanceManageViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));

            fluentAPI.SetObjectDataSourceBinding(bindingSourceDevice, x => x.DeviceInfoDataSet);
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.TransactionDataSet);
            //fluentAPI.SetObjectDataSourceBinding(bindingSourceAannualCalendar, x => x.AnnualCalendarDataSet);

            barHeaderItem1.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), fluentAPI.ViewModel.RecordCount);

            Messenger.Default.Register<RebindMessage<TimeAttendanceManageViewModel>>(this, x => RebindDataSource());
            Messenger.Default.Register<WaitingMessage<TimeAttendanceManageViewModel>>(this, ShowWaiting);
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedTransaction,
                    args => args.Row as TaTransaction,
                    (gView, transaction) => gView.FocusedRowHandle = gView.FindRow(transaction));

            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                       .EventToCommand(
                           x => x.Edit(null), x => x.SelectedTransaction,
                           args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));

            barHeaderItem.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), fluentAPI.ViewModel.RecordCount.ToString());

            //bbiPrint.ItemClick += (s, e) =>
            //    {
            //        XtraReportAnnualCalendar annualCalendarReport = new XtraReportAnnualCalendar(bindingSourceAannualCalendar);
            //       // annualCalendarReport.DataSource = ;
            //        ReportPrintTool printTool = new ReportPrintTool(annualCalendarReport);
            //        //printTool.ShowPreviewDialog();

            //        // Invoke the Print Preview form
            //        // with the specified look and feel setting.
            //        printTool.ShowPreview(UserLookAndFeel.Default);
            //    };
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
                //GridToXLS(gridView, fileName);

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
        void ShowWaiting(WaitingMessage<TimeAttendanceManageViewModel> message)
        {
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
            //simpleButtonQuery.PerformClick();

            var fluentAPI = mvvmContext.OfType<TimeAttendanceManageViewModel>();
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
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<TimeAttendanceManageViewModel> message)
        {
            barHeaderItem1.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }
        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion







        private void GridToXLS(GridView _grv, string _fileName)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;

            colDepartmentID.Visible = false;
            colUserID.Visible = false;
            //colDepartmentID.GroupIndex = -1;
            //colUserID.GroupIndex = -1;

            _grv.ExportToXlsx(_fileName);

            //colDepartmentID.GroupIndex = 0;
            //colUserID.GroupIndex = 1;

            colDepartmentID.Visible = true;
            colUserID.Visible = true;
        }

    }
}
