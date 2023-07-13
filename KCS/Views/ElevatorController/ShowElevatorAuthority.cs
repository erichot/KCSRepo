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

namespace KCS.Views
{
    public partial class ShowElevatorAuthority : DevExpress.XtraEditors.XtraUserControl
    {
        public ShowElevatorAuthority()
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
            var fluentAPI = mvvmContext.OfType<ShowElevatorAuthorityViewModel>();

            fluentAPI.BindCommand(bbiClose, x => x.Close());

            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSourceEmployee,
                x => x.ElevatorAuthorityDataSet);
            }
            catch { }
        }
        void InitViewDisplay()
        {
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            colCardID.Caption = LanguageResource.GetDisplayString("CardID");
            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentID");
            colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");
            colStartTime.Caption = LanguageResource.GetDisplayString("StartTime");
            colEndTime.Caption = LanguageResource.GetDisplayString("EndTime");
            colAuthority_B1.Caption = "B1";
            colAuthority_F1.Caption = "F1";
            colAuthority_F2.Caption = "F2";
            colAuthority_F3.Caption = "F3";
            colAuthority_F4.Caption = "F4";
            colAuthority_F5.Caption = "F5";
        }
     }
}
