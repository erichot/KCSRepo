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
    public partial class ChangeCardID : DevExpress.XtraEditors.XtraUserControl
    {
        public ChangeCardID()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ChangeCardIDViewModel>();
            fluentAPI.SetObjectDataSourceBinding(bindingSourceEmployee, x => x.EditEmployee);
            fluentAPI.SetBinding(textEditNewCardId, x => x.Text, x => x.NewCardId);
        }
        void InitViewDisplay()
        {
            ItemForUserID.Text = LanguageResource.GetDisplayString("EmployeeID");
            ItemForDepListField.Text = LanguageResource.GetDisplayString("Department");
            ItemForUserName.Text = LanguageResource.GetDisplayString("EmployeeName");
            ItemForCardID.Text = LanguageResource.GetDisplayString("CardID");
            lblCtlNewCardId.Text = LanguageResource.GetDisplayString("CardID");
        }
    }
}
