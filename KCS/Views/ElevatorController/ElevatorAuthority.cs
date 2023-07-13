using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KCS.Common.Utils;
using DevExpress.Utils.MVVM.Services;
using KCS.ViewModels;
using KCS.Models;
using DevExpress.XtraGrid.Views.Grid;

namespace KCS.Views
{
    public partial class ElevatorAuthority : DevExpress.XtraEditors.XtraUserControl
    {
        KCS.Services.IWaitingService waitingService = new KCS.Services.WaitingService();
        public ElevatorAuthority()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ElevatorAuthorityViewModel>();

            fluentAPI.BindCommand(bbiClose, x => x.Close());

            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSourceEmployee,
                x => x.EmployeesBriefDataSet);
                fluentAPI.SetObjectDataSourceBinding(bindingSourceElevator, x => x.ElevatorControllerDataSet);

                fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.SelectionEmployees, e => GetSelectedEmployees());

               



                fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView1, "SelectionChanged")
              .SetBinding(x => x.SelectionDevices, e => GetSelectedDevices());


                fluentAPI.SetBinding(timeEditStart, c => c.EditValue, x => x.StartTime);
                fluentAPI.SetBinding(timeEditEnd, c => c.EditValue, x => x.EndTime);

                fluentAPI.SetBinding(checkEditB1, x => x.EditValue, x => x.AuthorityB1);
                fluentAPI.SetBinding(checkEditF1, x => x.EditValue, x => x.AuthorityF1);
                fluentAPI.SetBinding(checkEditF2, x => x.EditValue, x => x.AuthorityF2);
                fluentAPI.SetBinding(checkEditF3, x => x.EditValue, x => x.AuthorityF3);
                fluentAPI.SetBinding(checkEditF4, x => x.EditValue, x => x.AuthorityF4);
                fluentAPI.SetBinding(checkEditF5, x => x.EditValue, x => x.AuthorityF5);

                fluentAPI.BindCommand(sbApply, x => x.SetEmployeesElevatorAuthority());
            }
            catch { }
        }
        void InitViewDisplay()
        {           
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            lblCtlElevatorAuthority.Text = LanguageResource.GetDisplayString("ElevatorControlAuthority");
            lblCtlSelectDevice.Text = LanguageResource.GetDisplayString("SelectDevices");

            colCardID.Caption = LanguageResource.GetDisplayString("CardID");
            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentID");
            colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");

            colEleavatorID.Caption = LanguageResource.GetDisplayString("EleavatorID");
            colEleavatorName.Caption = LanguageResource.GetDisplayString("EleavatorName");
            colEleavatorDes.Caption = LanguageResource.GetDisplayString("EleavatorDes");
            colSlaveSID.Caption = LanguageResource.GetDisplayString("DeviceID");
            colIP.Caption = LanguageResource.GetDisplayString("DeviceIP");
            colSlaveName.Caption = LanguageResource.GetDisplayString("DeviceName");
            sbApply.Text = LanguageResource.GetDisplayString("ApplyText");

            lblCtlStartTime.Text = LanguageResource.GetDisplayString("StartTime");
            lblCtlEndTime.Text = LanguageResource.GetDisplayString("EndTime");

        }
        IEnumerable<ElevatorController> GetSelectedDevices()
        {
            return gridView1.GetSelectedRows().Select(r => gridView1.GetRow(r) as ElevatorController);
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


    }
}
