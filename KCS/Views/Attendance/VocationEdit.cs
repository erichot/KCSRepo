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
using KCS.ViewModels;
using KCS.Common.Utils;

namespace KCS.Views
{
    public partial class VocationEdit : DevExpress.XtraEditors.XtraUserControl
    {
        public VocationEdit()
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
            var fluentAPI = mvvmContext.OfType<VocationEditViewModel>();
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());



            fluentAPI.SetObjectDataSourceBinding(bindingSourceLeaveType,
                 x => x.LeaveTypeDataSet);

            fluentAPI.SetBinding(textEditEmployeeMsg, x => x.EditValue, x => x.EmployeeMsg);
            fluentAPI.SetBinding(dateEditSel, x => x.EditValue, x => x.EditVocationSetting.SelectDate);
            fluentAPI.SetBinding(memoEditReason, x => x.EditValue, x => x.EditVocationSetting.LeaveReson);
            fluentAPI.SetBinding(lookUpEditVocation1, x => x.EditValue, x => x.EditVocationSetting.LeaveType1);
            fluentAPI.SetBinding(lookUpEditVocation2, x => x.EditValue, x => x.EditVocationSetting.LeaveType2);
            fluentAPI.SetBinding(lookUpEditVocation3, x => x.EditValue, x => x.EditVocationSetting.LeaveType3);
            fluentAPI.SetBinding(textEditLeave1Hour, x => x.EditValue, x => x.EditVocationSetting.Leave1Hours);
            fluentAPI.SetBinding(textEditLeave2Hour, x => x.EditValue, x => x.EditVocationSetting.Leave2Hours);
            fluentAPI.SetBinding(textEditLeave3Hour, x => x.EditValue, x => x.EditVocationSetting.Leave3Hours);

            
        }
        void InitViewDisplay()
        {

            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            lblCtlDate.Text = LanguageResource.GetDisplayString("DateText");
            lblCtlReason.Text = LanguageResource.GetDisplayString("ReasonText");
            lblCtlVocation1.Text = LanguageResource.GetDisplayString("LeaveText") + " 1";
            lblCtlVocation2.Text = LanguageResource.GetDisplayString("LeaveText") + " 2";
            lblCtlVocation3.Text = LanguageResource.GetDisplayString("LeaveText") + " 3";
            lblCtlHour1.Text = LanguageResource.GetDisplayString("hoursText");
            lblCtlHour2.Text = LanguageResource.GetDisplayString("hoursText");
            lblCtlHour3.Text = LanguageResource.GetDisplayString("hoursText");
            lblCtlSelEmployee.Text = LanguageResource.GetDisplayString("SelectEmployee");


        }
    }
}
