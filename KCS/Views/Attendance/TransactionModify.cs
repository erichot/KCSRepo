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
    public partial class TransactionModify : DevExpress.XtraEditors.XtraUserControl
    {
        public TransactionModify()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<TransactionModifyViewModel>();
            fluentAPI.BindCommand(bbiSave, x => x.Save());


            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EditTransaction);



            
        }
        void InitViewDisplay()
        {

            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");           
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");

            ItemForTranSID.Text = LanguageResource.GetDisplayString("SystemCode");
            ItemForCardID.Text = LanguageResource.GetDisplayString("CardID");
            ItemForUserID.Text = LanguageResource.GetDisplayString("EmployeeID");
            ItemForUserName.Text = LanguageResource.GetDisplayString("EmployeeName");

            ItemForTranDateTime.Text = LanguageResource.GetDisplayString("TransctionDateTime");
            ItemForTranType.Text = LanguageResource.GetDisplayString("TransactionType");
            ItemForID.Text = LanguageResource.GetDisplayString("DeviceID");
            ItemForSlaveIP.Text = LanguageResource.GetDisplayString("DeviceIP");
            ItemForSlaveDescription.Text = LanguageResource.GetDisplayString("DeviceDescription");
            ItemForInActive.Text = LanguageResource.GetDisplayString("InActive");
            ItemForNote.Text = LanguageResource.GetDisplayString("RemarkText");


        }
    }
}
