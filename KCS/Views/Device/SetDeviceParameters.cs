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
using KCS.Models;

namespace KCS.Views
{
    public partial class SetDeviceParameters : DevExpress.XtraEditors.XtraUserControl
    {
        public SetDeviceParameters()
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
            var fluentAPI = mvvmContext.OfType<SetDeviceParametersViewModel>();
            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.DeviceInfoDataSet);

            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.SelectionDevices, e => GetSelectedDevices());

            fluentAPI.SetBinding(MenuPwdTextEdit, x => x.Text, x => x.SetPassword);
            fluentAPI.SetBinding(LanguageTextComboBoxEdit, x => x.Text, x => x.SetLanguage);
            fluentAPI.SetBinding(WorkModeTextComboBoxEdit, x => x.Text, x => x.SetWorkMode);

            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(simpleButtonSetPwd, x => x.SetDevicePassword());
            fluentAPI.BindCommand(simpleButtonWorkMode, x => x.SetDeviceWorkMode());
            fluentAPI.BindCommand(simpleButtonDevLanguage, x => x.SetDeviceLanguage());
            fluentAPI.BindCommand(simpleButtonSetAll, x => x.SetAllPara());
        }
        void InitViewDisplay()
        {
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");


            lblCtlMenuPwd.Text = LanguageResource.GetDisplayString("DeviceMenuPwd");
            lblCtlWorkMode.Text = LanguageResource.GetDisplayString("DeviceWorkMode");
            lblCtlLanguage.Text = LanguageResource.GetDisplayString("DeviceLanguage");

            simpleButtonSetPwd.Text = LanguageResource.GetDisplayString("SetDevicePara");
            simpleButtonWorkMode.Text = LanguageResource.GetDisplayString("SetDevicePara");
            simpleButtonDevLanguage.Text = LanguageResource.GetDisplayString("SetDevicePara");

            simpleButtonSetAll.Text = LanguageResource.GetDisplayString("SetDeviceAllPara");

            colSlaveSID.Caption = LanguageResource.GetDisplayString("DeviceID");
            colIP.Caption = LanguageResource.GetDisplayString("DeviceIP");
            colSlaveName.Caption = LanguageResource.GetDisplayString("DeviceName");
            colSlaveDescription.Caption = LanguageResource.GetDisplayString("DeviceDescription");

            colMenuPwd.Caption = LanguageResource.GetDisplayString("DeviceMenuPwd");
            colWorkModeText.Caption = LanguageResource.GetDisplayString("DeviceWorkMode");
            colLanguageText.Caption = LanguageResource.GetDisplayString("DeviceLanguage");

            LanguageTextComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("LanguageCN"));
            LanguageTextComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("LanguageTW"));
            LanguageTextComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("LanguageEnglish"));
            LanguageTextComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("LanguageItalian"));
            LanguageTextComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("LanguageSpanish"));
            LanguageTextComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("LanguagePortuguese"));
            LanguageTextComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("LanguageThai"));
            LanguageTextComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("LanguageBrazilian"));
            LanguageTextComboBoxEdit.Properties.Items.Add(LanguageResource.GetDisplayString("LanguageCorean"));

            DeviceWorkMode devWorkMode = new DeviceWorkMode();
            WorkModeTextComboBoxEdit.Properties.Items.Add(devWorkMode[1]);
            WorkModeTextComboBoxEdit.Properties.Items.Add(devWorkMode[2]);
            WorkModeTextComboBoxEdit.Properties.Items.Add(devWorkMode[6]);

        }

        IEnumerable<DeviceBrief> GetSelectedDevices()
        {
            return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as DeviceBrief);
        }
    }
}
