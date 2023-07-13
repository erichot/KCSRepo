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
using KCS.ViewModels;
using KCS.Common.Utils;

namespace KCS.Views
{
    public partial class AnnualCalendarPrint : DevExpress.XtraEditors.XtraUserControl
    {
        
        public AnnualCalendarPrint()
        {
            InitializeComponent();//XtraReportAnnualCalendar
            
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
            var fluentAPI = mvvmContext.OfType<AnnualCalendarPrintViewModel>();
            fluentAPI.SetBinding(comboBoxEditSelectYear, x => x.Text, x => x.SelectYear);
            fluentAPI.SetBinding(monthEditStart, x => x.EditValue, x => x.SelectMonthStart);
            fluentAPI.SetBinding(monthEditEnd, x => x.EditValue, x => x.SelectMonthEnd);
            
        }
        void InitViewDisplay()
        {
            for (int i = 2016; i < 2100; i++)
            {

                comboBoxEditSelectYear.Properties.Items.Add(i.ToString());
            }
            comboBoxEditSelectYear.SelectedIndex = 0;
            lblCtlSelectYear.Text = LanguageResource.GetDisplayString("YearText");
            lblSelectMonth.Text = LanguageResource.GetDisplayString("MonthText");
            lblCtlFrom.Text = "(" + LanguageResource.GetDisplayString("FromText") + ")";
            lblCtlEnd.Text = "(" + LanguageResource.GetDisplayString("EndText") + ")";
        }
    }
}
