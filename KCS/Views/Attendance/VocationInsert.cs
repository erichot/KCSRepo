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
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;
using DevExpress.XtraEditors.Controls;
using DevExpress.Mvvm;

namespace KCS.Views
{
    public partial class VocationInsert : DevExpress.XtraEditors.XtraUserControl
    {
        public VocationInsert()
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
        void RebindDataSource(RebindMessage<VocationInsertViewModel> message)
        {
            var fluentAPI = mvvmContext.OfType<VocationInsertViewModel>();
            try
            {
                if (message.BindType == 1)
                {
                    fluentAPI.SetObjectDataSourceBinding(bindingSourceLeaveDetails,
                     x => x.LeaveItemDetailsList);
                    fluentAPI.SetObjectDataSourceBinding(bindingSourcePerLeaveItem,
                 x => x.EditPerLeaveItem);
                    fluentAPI.SetBinding(dateEditAplplyDate, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(lookUpEditApplicant, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(lookUpEditLeaveType, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(dateEditLeaveStart, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(dateEditLeavEnd, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(timeEditLeaveStart, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(timeEditLeaveEnd, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(lookUpEditAgent, x => x.ReadOnly, x => x.ReadOnlyOrNot);

                    fluentAPI.SetBinding(simpleButtonApproval, x => x.Enabled, x => x.BtnConfirmEnable);
                    fluentAPI.SetBinding(simpleButtonCancel, x => x.Enabled, x => x.BtnCancelEnable);
                }
                else
                {
                    fluentAPI.SetObjectDataSourceBinding(bindingSourcePerLeaveItem,
                 x => x.EditPerLeaveItem);
                    fluentAPI.SetBinding(dateEditAplplyDate, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(lookUpEditApplicant, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(lookUpEditLeaveType, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(dateEditLeaveStart, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(dateEditLeavEnd, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(timeEditLeaveStart, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(timeEditLeaveEnd, x => x.ReadOnly, x => x.ReadOnlyOrNot);
                    fluentAPI.SetBinding(lookUpEditAgent, x => x.ReadOnly, x => x.ReadOnlyOrNot);

                    fluentAPI.SetBinding(simpleButtonApproval, x => x.Enabled, x => x.BtnConfirmEnable);
                    fluentAPI.SetBinding(simpleButtonCancel, x => x.Enabled, x => x.BtnCancelEnable);
                }
            }
            catch (Exception ex)
            {
            }
        }

        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<VocationInsertViewModel>();
            //fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(simpleButtonCreateLeave, x => x.CreateLeavDetails());
            fluentAPI.BindCommand(simpleButtonApproval, x => x.ConfirmLeave());
            fluentAPI.BindCommand(simpleButtonCancel, x => x.CancelLeave());

            fluentAPI.SetBinding(dateEditAplplyDate,x => x.ReadOnly,x => x.ReadOnlyOrNot);
            fluentAPI.SetBinding(lookUpEditApplicant, x => x.ReadOnly, x => x.ReadOnlyOrNot);
            fluentAPI.SetBinding(lookUpEditLeaveType, x => x.ReadOnly, x => x.ReadOnlyOrNot);
            fluentAPI.SetBinding(dateEditLeaveStart, x => x.ReadOnly, x => x.ReadOnlyOrNot);
            fluentAPI.SetBinding(dateEditLeavEnd, x => x.ReadOnly, x => x.ReadOnlyOrNot);
            fluentAPI.SetBinding(timeEditLeaveStart, x => x.ReadOnly, x => x.ReadOnlyOrNot);
            fluentAPI.SetBinding(timeEditLeaveEnd, x => x.ReadOnly, x => x.ReadOnlyOrNot);
            fluentAPI.SetBinding(lookUpEditAgent, x => x.ReadOnly, x => x.ReadOnlyOrNot);

            fluentAPI.SetBinding(simpleButtonApproval, x => x.Enabled , x => x.BtnConfirmEnable);
            fluentAPI.SetBinding(simpleButtonCancel, x => x.Enabled, x => x.BtnCancelEnable);
            try
            {

                fluentAPI.SetObjectDataSourceBinding(bindingSourceEmp,
                 x => x.EmployeeMsgList);

                fluentAPI.SetObjectDataSourceBinding(bindingSourceLeaveType,
                 x => x.LeaveTypeDataSet);

                fluentAPI.SetObjectDataSourceBinding(bindingSourcePerLeaveItem,
                 x => x.EditPerLeaveItem);

                fluentAPI.SetObjectDataSourceBinding(bindingSourceLeaveDetails,
                 x => x.LeaveItemDetailsList);
                
            }
            catch (Exception ex)
            {
            }
            Messenger.Default.Register<RebindMessage<VocationInsertViewModel>>(this, x => RebindDataSource(x));
            fluentAPI.WithEvent<ChangingEventArgs>(dateEditAplplyDate, "EditValueChanging").EventToCommand(x => x.DateChanged(null), new Func<ChangingEventArgs, object>(e => e.NewValue));
            fluentAPI.WithEvent<RowObjectEventArgs>(gridView, "RowUpdated")
           .EventToCommand(x => x.Save(null), new Func<RowObjectEventArgs, object>(e => e.Row));



            
        }
        void InitViewDisplay()
        {

            //ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            lblCtlStatusTitle.Text = LanguageResource.GetDisplayString("StatusText");
            lblCtlAuthorizer.Text = LanguageResource.GetDisplayString("Authorizer");
            lblCtlApprovalTime.Text = LanguageResource.GetDisplayString("ApprovalTime");
            lblCtlLeaveNum.Text = LanguageResource.GetDisplayString("LeaveNUM");
            lblCtlApplyDate.Text = LanguageResource.GetDisplayString("ApplyDate") + "<color=red>*</color>";
            lblCtlApplicant.Text = LanguageResource.GetDisplayString("Applicant") + "<color=red>*</color>" ;
            lblCtlLeaveType.Text = LanguageResource.GetDisplayString("LeaveCategoryText") + "<color=red>*</color>";
           // lblCtlLeaveName.Text = LanguageResource.GetDisplayString("LeaveTypeNameText");
            lblCtlLeaveDateStart.Text = LanguageResource.GetDisplayString("LeaveDateStart") + "<color=red>*</color>";
            lblCtlLeaveTimeStart.Text = LanguageResource.GetDisplayString("LeaveTimeStart");
            lblCtlLeaveDateEnd.Text = LanguageResource.GetDisplayString("LeaveDateEnd") + "<color=red>*</color>";
            lblCtlLeaveTimeEnd.Text = LanguageResource.GetDisplayString("LeaveTimeEnd") ;
            lblCtlHourlyTotal.Text = LanguageResource.GetDisplayString("HourlyTotal");
            lblCtlHourlyTips.Text = LanguageResource.GetDisplayString("HourlyTotalTips");
            lblCtlAgent.Text = LanguageResource.GetDisplayString("Agent");
            simpleButtonCreateLeave.Text = LanguageResource.GetDisplayString("CreateLeaveDetails");
            simpleButtonApproval.Text = LanguageResource.GetDisplayString("StatusApproval");
            simpleButtonCancel.Text = LanguageResource.GetDisplayString("StatusCancel");
            colSN.Caption = LanguageResource.GetDisplayString("IDText");
            colLEAVE_DATE_STR.Caption = LanguageResource.GetDisplayString("LeaveDate");
            colTURN_HOUR.Caption = LanguageResource.GetDisplayString("AttendanceHours");
            colSUM_TIME.Caption = LanguageResource.GetDisplayString("LeaveHours");
            lookUpEditAgent.Properties.Columns[1].Caption = lookUpEditApplicant.Properties.Columns[1].Caption = LanguageResource.GetDisplayString("EmployeeID");
            lookUpEditAgent.Properties.Columns[2].Caption = lookUpEditApplicant.Properties.Columns[2].Caption = LanguageResource.GetDisplayString("EmployeeName");
            lookUpEditAgent.Properties.Columns[0].Caption = lookUpEditApplicant.Properties.Columns[0].Caption = LanguageResource.GetDisplayString("DepartmentName");
        }

        private void timeEditLeaveStart_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("HH:mm");
                e.Handled = true;

            }
        }

        private void timeEditLeaveEnd_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("HH:mm");
                e.Handled = true;

            }
        }
    }
}
