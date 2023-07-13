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
using KCS.Common.DAL;
using System.Diagnostics;

namespace KCS.Form
{
    public partial class FormSyncSet : DevExpress.XtraEditors.XtraForm
    {
        public FormSyncSet()
        {
            this.Text = LanguageResource.GetDisplayString("SyncSettings");
            InitializeComponent();
        }

        private void FormSyncSet_Load(object sender, EventArgs e)
        {
            buttonSave.Text = buttonSave.Text = LanguageResource.GetDisplayString("ToolBarSave");
            checkEditDisableSync.Text = LanguageResource.GetDisplayString("DisableSync");


            checkEditDisableSync.Checked = SystemConfigure.IsDisSyncDataOrNot > 0 ? true : false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SystemConfigure.SetDisableSyncData(checkEditDisableSync.Checked ? 1 : 0);
            //开启新的实例
            Process.Start(Application.ExecutablePath);

            //关闭当前实例
            Process.GetCurrentProcess().Kill();
        }
    }
}