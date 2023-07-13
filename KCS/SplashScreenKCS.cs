using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using KCS.Common.Utils;

namespace KCS
{
    public partial class SplashScreenKCS : SplashScreen
    {
        public SplashScreenKCS()
        {
            InitializeComponent();
            
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            if (cmd.ToString() == "UpdateLabel")
            {
                labelControl2.Text = Convert.ToString(arg);
            }
        }

        #endregion
        
        public enum SplashScreenCommand
        {
            UpdateLabel
        }
    }
}