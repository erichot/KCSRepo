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

namespace KCS.Views
{
    public partial class SetOpenDoorPin : DevExpress.XtraEditors.XtraUserControl
    {
        public SetOpenDoorPin()
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
            var fluentAPI = mvvmContext.OfType<SetOpenDoorPinViewModel>();
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EditDoorPIN);
            fluentAPI.BindCommand(bbiClose, x => x.Close());

            bbiSave.ItemClick += (s, e) =>
            {
                this.dataLayoutControl1.Validate();
                this.dataLayoutControl2.Validate();
                fluentAPI.ViewModel.Save();
            };
           
        }
        void InitViewDisplay()
        {
            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            lblCtlPIN1.Text = LanguageResource.GetDisplayString("PIN1GroupName");
            lblCtlPIN2.Text = LanguageResource.GetDisplayString("PIN2GroupName");

            ItemForPIN1Name.Text = ItemForPIN2Name.Text = LanguageResource.GetDisplayString("PINName");
            ItemForPIN1StartHour.Text = ItemForPIN2StartHour.Text = LanguageResource.GetDisplayString("PINStartHour");
            ItemForPIN1StartMinute.Text = ItemForPIN2StartMinute.Text = LanguageResource.GetDisplayString("PINStartMin");
            ItemForPIN1EndHour.Text = ItemForPIN2EndHour.Text = LanguageResource.GetDisplayString("PINEndHour");
            ItemForPIN1EndMinute.Text = ItemForPIN2EndMinute.Text = LanguageResource.GetDisplayString("PINEndMin");
            ItemForPIN1.Text = ItemForPIN2.Text = LanguageResource.GetDisplayString("PINValue");

        }

        
    }
}
