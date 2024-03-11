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

namespace KCS.Views
{
    public partial class AttendanceReportSetView : DevExpress.XtraEditors.XtraUserControl
    {

        // Add:         2024/03/04
        // Ver:         1.1.5.17
        bool m_SupervisorIsReadOnly;
        string m_SupervisorDepartmentID;


        KCS.Services.IWaitingService waitingService =  new KCS.Services.WaitingService();
        public AttendanceReportSetView()
        {
            InitializeComponent();
        }
         protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitViewDisplay();

            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
           * Add:      2024/03/04
           * Ver:      1.1.5.17
           */
            m_SupervisorIsReadOnly = KCS.Models.CredentialsSource.GetLoginSupervisorIsReadOnly();
            m_SupervisorDepartmentID = KCS.Models.CredentialsSource.GetLoginSupervisorDepID();
            lblSupervisorDepartmentID.Text = m_SupervisorDepartmentID;
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


            if (!DesignMode)
                InitBindings();
           // waitingService = GetService<Services.IWaitingService>();
        }
         void InitBindings()
         {
             var fluentAPI = mvvmContext.OfType<AttendanceReportSetViewModel>();
             Messenger.Default.Register<WaitingMessage<AttendanceReportSetViewModel>>(this, ShowWaiting);

            // Add:     2024/03/04
            // Ver:     1.1.5.17
            fluentAPI.SetBinding(lblSupervisorDepartmentID, label => label.Text, x => x.m_SupervisorDepartmentID);
            lblSupervisorDepartmentID.Text = m_SupervisorDepartmentID;



            fluentAPI.SetBinding(dateEditStart, x => x.EditValue, x => x.StartDate);
             fluentAPI.SetBinding(dateEditEnd, x => x.EditValue, x => x.EndDate);
             fluentAPI.SetBinding(checkByAttendanceRecords, x => x.Checked, x => x.ByTransactionType);

             fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.Selection, e => GetSelectedEmployees());

             fluentAPI.SetObjectDataSourceBinding(bindingSourceEmBrief, x => x.EmployeesBriefDataSet);

             fluentAPI.BindCommand(bbiClose, x => x.Close());
             fluentAPI.BindCommand(bbiDailyReport, x => x.DailyReport());
             fluentAPI.BindCommand(bbiMonthlyReport, x => x.MonthlyReport());
             fluentAPI.BindCommand(bbiMonthlySimplifiedReport, x => x.SimplifiedMonthlyReport());

            // Add: 2023/01/22  By:Eric
            fluentAPI.BindCommand(bbiFlexShiftReport, x => x.FlexShiftReport());

        }
         void InitViewDisplay()
         {
             checkByAttendanceRecords.Text = LanguageResource.GetDisplayString("CalculateAttendanceRecordsOnly");
             colCardID.Caption = LanguageResource.GetDisplayString("CardID");
             colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
             colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
             colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentID");
             colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");

             bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
             bbiDailyReport.Caption = LanguageResource.GetDisplayString("ToolBarDailyReport");
             bbiMonthlyReport.Caption = LanguageResource.GetDisplayString("ToolBarMonthlyReport");
             bbiMonthlySimplifiedReport.Caption = LanguageResource.GetDisplayString("ToolBarMonthlySimplifiedReport");
             ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
             ribbonPageGroupReport.Text = LanguageResource.GetDisplayString("AttendanceReport");

            /*
             * Add:     2023/02/02
             * By:      Eric
             * Ver:     1.1.5.7
             * Note:    FlexReport
             */
             bbiFlexShiftReport.Caption = LanguageResource.GetDisplayString("ToolBarFlexShiftReport");

        }
         IEnumerable<EmployeeBrief> GetSelectedEmployees()
         {
             return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as EmployeeBrief);
         }
         void ShowWaiting(WaitingMessage<AttendanceReportSetViewModel> message)
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

        private void bbiMonthlySimplifiedReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiMonthlyReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiFlexShiftReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
