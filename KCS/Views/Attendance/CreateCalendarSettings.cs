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
using KCS.Common.DAL;

namespace KCS.Views
{
    public partial class CreateCalendarSettings : DevExpress.XtraEditors.XtraUserControl
    {
        public CreateCalendarSettings()
        {
            InitializeComponent();//
        }
        protected override void  OnLoad(EventArgs e)
        {
            base.OnLoad(e);          
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<CreateCalendarSettingsViewModel>();
            fluentAPI.SetBinding(comboBoxEditSelectYear, x => x.Text, x => x.SelectYear);
            fluentAPI.SetBinding(radioGroupHolidayOrNot, x => x.EditValue, x => x.HaveHolidayOrNot);
            fluentAPI.SetBinding(radioGroupHolidayType, x => x.EditValue, x => x.HolidayTypeOnWeekend);
           
        }
        void InitViewDisplay()
        {
            if (SystemConfigure.LanguageSelect == "zh_TW" || SystemConfigure.LanguageSelect == "zh_CN")
            {
                this.radioGroupHolidayOrNot.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
             new DevExpress.XtraEditors.Controls.RadioGroupItem(0,  LanguageResource.GetDisplayString("DialogYesButton")),
             new DevExpress.XtraEditors.Controls.RadioGroupItem(1,  LanguageResource.GetDisplayString("DialogNoButtonText"))
            });
                //radioGroupHolidayOrNot.SelectedIndex = 0;

                this.radioGroupHolidayType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
             new DevExpress.XtraEditors.Controls.RadioGroupItem(0,  LanguageResource.GetDisplayString("CalendarSetting2DaysWeekend")),
             new DevExpress.XtraEditors.Controls.RadioGroupItem(1,  LanguageResource.GetDisplayString("CalendarSettingNosWeekend"))
            });
                lblCtlHolidayOrNot.Text = LanguageResource.GetDisplayString("HolidayOrNotText");
                lblCtlHolidayType.Text = LanguageResource.GetDisplayString("WeekenTypeText");

                this.radioGroupHolidayOrNot.Visible = true;
                this.radioGroupHolidayType.Visible = true;
                this.lblCtlHolidayOrNot.Visible = true;
                this.lblCtlHolidayType.Visible = true;
            }
            else
            {
                this.radioGroupHolidayOrNot.Visible = false;
                this.radioGroupHolidayType.Visible = false;
                this.lblCtlHolidayOrNot.Visible = false;
                this.lblCtlHolidayType.Visible = false;
            }
            for (int i = 2016; i < 2100; i++)
            {

                comboBoxEditSelectYear.Properties.Items.Add(i.ToString());
            }
            lblCtlSelectYear.Text = LanguageResource.GetDisplayString("YearText");
           
            //radioGroupHolidayType.SelectedIndex = 0;
        }
    }
}
