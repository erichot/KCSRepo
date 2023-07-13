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

namespace KCS.Views
{
    public partial class DeviceSettingManage : BaseViewControl, IRibbonModule
    {
        public DeviceSettingManage()
            : base(typeof(DeviceSettingManageViewModel))
        {
            InitializeComponent();
        }
        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion
    }
}
