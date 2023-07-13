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

namespace KCS.Views
{
    public partial class CreatCalendar : DevExpress.XtraEditors.XtraUserControl
    {
        public CreatCalendar()
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
            var fluentAPI = mvvmContext.OfType<CreatCalendarViewModel>();
            fluentAPI.SetBinding(comboBoxEditSelectYear, x => x.Text, x => x.SelectYear);
        }
        void InitViewDisplay()
        {
            for (int i = 2016; i < 2100; i++)
            {
               
                comboBoxEditSelectYear.Properties.Items.Add(i.ToString() );
            }
            //comboBoxEditSelectYear.SelectedIndex = 0;
            lblCtlSelectYear.Text = LanguageResource.GetDisplayString("YearText");
        }
    }
}
