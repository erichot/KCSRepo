using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.Common.Utils;

namespace KCS.Views
{
    public partial class NewHoliday : DevExpress.XtraEditors.XtraForm
    {
        public EventHandler<HolidaySetEventArgs> HolidaySetChanged;
        public NewHoliday(string displayName)
        {
            InitializeComponent();
            string Holitype = displayName.Substring(0, displayName.IndexOf("("));
            InitDisplay();
            cmbEditHoliType.Text = Holitype;
            string Holides = displayName.Substring(displayName.IndexOf("("));
            textEditHoliDescription.Text = Holides.Substring(1, Holides.Length - 2);
        }
        public NewHoliday()
        {
            InitializeComponent();
            InitDisplay();
            cmbEditHoliType.SelectedIndex = 0;
        }
        void InitDisplay()
        {
            this.Text = LanguageResource.GetDisplayString("HolidaySetText");
            lblCtlHoliType.Text = LanguageResource.GetDisplayString("AccessControlHoliType");
            lblCtlDescription.Text = LanguageResource.GetDisplayString("DescriptionText");
            sbOk.Text = LanguageResource.GetDisplayString("DialogOkButtonText");
            sbCancel.Text = LanguageResource.GetDisplayString("DialogCancelButtonText");
            cmbEditHoliType.Properties.Items.Add(LanguageResource.GetDisplayString("AccessControlHoliTypeNULL"));
            cmbEditHoliType.Properties.Items.Add(LanguageResource.GetDisplayString("AccessControlHoliType") + "1");
            cmbEditHoliType.Properties.Items.Add(LanguageResource.GetDisplayString("AccessControlHoliType") + "2");
            cmbEditHoliType.Properties.Items.Add(LanguageResource.GetDisplayString("AccessControlHoliType") + "3");
            cmbEditHoliType.Properties.Items.Add(LanguageResource.GetDisplayString("AccessControlHoliType") + "4");
            cmbEditHoliType.Properties.Items.Add(LanguageResource.GetDisplayString("AccessControlHoliType") + "5");
            cmbEditHoliType.Properties.Items.Add(LanguageResource.GetDisplayString("AccessControlHoliType") + "6");
            cmbEditHoliType.Properties.Items.Add(LanguageResource.GetDisplayString("AccessControlHoliType") + "7");
            cmbEditHoliType.Properties.Items.Add(LanguageResource.GetDisplayString("AccessControlHoliType") + "8");
            
        }
        protected virtual void OnHolidaySetChanged(HolidaySetEventArgs e)
        {
            if (HolidaySetChanged != null)
            {
                HolidaySetChanged(this, e);
            }
        }
        private void sbOk_Click(object sender, EventArgs e)
        {
            HolidaySetEventArgs args = new HolidaySetEventArgs((byte)cmbEditHoliType.SelectedIndex,textEditHoliDescription.Text);
            OnHolidaySetChanged(args);
            this.Close();
        }

        private void sbCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}