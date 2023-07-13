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
using KCS.ViewModels;

namespace KCS.Views
{
    public partial class ElevatorEdit : DevExpress.XtraEditors.XtraUserControl
    {
        public ElevatorEdit()
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
            var fluentAPI = mvvmContext.OfType<ElevatorEditViewModel>();

            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());

            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSourceDevice,
                x => x.DeviceInfoDataSet);
                fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EditElevator);
            }
            catch { }
        }
        void InitViewDisplay()
        {
            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");


            ItemForEleavatorName.Text = LanguageResource.GetDisplayString("EleavatorName");
            ItemForEleavatorDes.Text = LanguageResource.GetDisplayString("EleavatorDes");
            ItemForSlaveSID.Text = LanguageResource.GetDisplayString("DeviceID");

        }
    }
}
