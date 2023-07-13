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

namespace KCS.Views
{
    public partial class TransactionAdd : DevExpress.XtraEditors.XtraUserControl
    {
        public TransactionAdd()
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
            var fluentAPI = mvvmContext.OfType<TransactionAddViewModel>();
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.SetBinding(TranDateTimeDateEdit, x => x.EditValue, x => x.TransDateTime);
            fluentAPI.SetBinding(TranTypeComboBoxEdit, x => x.EditValue, x => x.TransType);
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EditTransaction);




        }
        void InitViewDisplay()
        {

            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");

           
            ItemForCardID.Text = LanguageResource.GetDisplayString("CardID");
            ItemForUserID.Text = LanguageResource.GetDisplayString("EmployeeID");
            ItemForUserName.Text = LanguageResource.GetDisplayString("EmployeeName");

            ItemForTranDateTime.Text = LanguageResource.GetDisplayString("TransctionDateTime");
            ItemForTranType.Text = LanguageResource.GetDisplayString("TransactionType");
           


        }
    }
}
