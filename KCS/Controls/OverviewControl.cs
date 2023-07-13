using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils;
using KCS.ViewModels;
using KCS.Views;
namespace KCS.Views
{
    public partial class OverviewControl : XtraUserControl
    {
        public OverviewControl()
        {
            InitializeComponent();
            descriptionLabel.AutoSizeInLayoutControl = false;
            descriptionLabel.Text = "<image=#UISuperHero><br>"
                + string.Format("<color=#{0:x6}><size=+24>Become a UI Superhero<br>", ColorHelper.TextColor.ToArgb())
                + string.Format("<color=#{0:x6}><size=-18>And deliver compelling user-experiences on the WinForms platform<br>", ColorHelper.DisabledTextColor.ToArgb())
                + "with award-winning DevExpress Controls and Libraries.";
            descriptionLabel.HyperlinkClick += descriptionLabel_HyperlinkClick;
        }
        void descriptionLabel_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            viewModel.SelectedModuleType = ModuleType.Employees;
            var form = FindForm();
            if (form != null)
                form.Close();
        }
        MainViewModel viewModel;
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            if (viewModel == null && AppHelper.MainForm != null)
            {
                viewModel = (AppHelper.MainForm as ISupportViewModel).ViewModel as MainViewModel;
                if (viewModel != null)
                    BindCommands();
            }
        }
        void BindCommands()
        {
            
        }
        internal void SetDescription(string description)
        {
            descriptionLabel.Appearance.Image = null;
            descriptionLabel.Text = "<image=#UISuperHero><br>"
                + string.Format("<color=#{0:x6}><size=+24>Become a UI Superhero<br>", ColorHelper.TextColor.ToArgb())
                + string.Format("<color=#{0:x6}><size=-18>{1}", ColorHelper.DisabledTextColor.ToArgb(), description);
        }
    }
}
