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

namespace KCS
{
    public partial class XtraFormCompanyData : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormCompanyData()
        {
            InitializeComponent();
            this.Text = LanguageResource.GetDisplayString("CompanyBasicData");
            sbSave.Text = LanguageResource.GetDisplayString("SaveSetttings");
            lblCtlCompanyName.Text = LanguageResource.GetDisplayString("CompanyName");
        }

        private void sbSave_Click(object sender, EventArgs e)
        {
            KCS.Common.DAL.SystemConfigure.SetDefaultCompanyName(textEditCompany.Text);
        }
    }
}