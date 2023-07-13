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
using DevExpress.Utils.MVVM.Services;
using KCS.Models;


namespace KCS.Views
{
    public partial class NewDevice : DevExpress.XtraEditors.XtraUserControl
    {
        public NewDevice()
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
            var fluentAPI = mvvmContext.OfType<NewDeviceViewModel>();

            mvvmContext.RegisterService(NotificationService.Create(alertControl));
            //fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiSaveAndClose, x => x.SaveAndClose());
            fluentAPI.BindCommand(bbiSaveAndNew, x => x.SaveAndNew());

            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSourceDeviceCategory,
                x => x.DeviceCategoryDataSet);
                fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.NewDevices);
            }
            catch { }

            bbiSave.ItemClick += (s, e) =>
            {
                this.dataLayoutControl1.Validate();
                fluentAPI.ViewModel.Save();
            };

        }
        void InitViewDisplay()
        {
            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiSaveAndClose.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndClose");
            bbiSaveAndNew.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndNew");
            bbiReset.Caption = LanguageResource.GetDisplayString("ToolBarReset");
            bbiDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            ItemForID.Text = LanguageResource.GetDisplayString("DeviceID");
            ItemForIP.Text = LanguageResource.GetDisplayString("ItemForIP");
            ItemForIP_Internal.Text = LanguageResource.GetDisplayString("ItemForIP_Internal");
            ItemForSlaveName.Text = LanguageResource.GetDisplayString("DeviceName");
            ItemForSlaveDescription.Text = LanguageResource.GetDisplayString("DeviceDescription");
            ItemForIsEnabled.Text = LanguageResource.GetDisplayString("DeviceIsEnable");
            ItemForSlaveCategoryID.Text = LanguageResource.GetDisplayString("DialogDeviceCategory");
            ItemForIsServerMode.Text = LanguageResource.GetDisplayString("DeviceIsServerMode");
            NotPropagateWithUsersByDefaultCheckEdit.Text = LanguageResource.GetDisplayString("NotPropagateWithUsersByDefault");

            ItemForMenuPwd.Text = LanguageResource.GetDisplayString("DeviceMenuPwd");
            ItemForWorkModeText.Text = LanguageResource.GetDisplayString("DeviceWorkMode");
            ItemForLanguageText.Text = LanguageResource.GetDisplayString("DeviceLanguage");
            
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

            DeviceTypeComboBoxEdit.Properties.Items.Add("Card");
            DeviceTypeComboBoxEdit.Properties.Items.Add("Finger");
            DeviceTypeComboBoxEdit.Properties.Items.Add("Face");

        }
    }
}
