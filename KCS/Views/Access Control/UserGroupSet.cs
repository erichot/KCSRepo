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

namespace KCS.Views
{
    public partial class UserGroupSet : DevExpress.XtraEditors.XtraUserControl
    {
        public UserGroupSet()
        {
            InitializeComponent();
        }
        protected override void OnLoad(System.EventArgs e)
        {

            base.OnLoad(e);

            if (!DesignMode)
                InitBindings();
            InitViewDisplay();

        }
        void InitViewDisplay()
        {
            ItemForGroupID.Text = LanguageResource.GetDisplayString("SystemCode");
            ItemForSun.Text = LanguageResource.GetDisplayString("SundayText");
            ItemForMon.Text = LanguageResource.GetDisplayString("MondayText");
            ItemForTue.Text = LanguageResource.GetDisplayString("TuesdayText");
            ItemForWed.Text = LanguageResource.GetDisplayString("WednesdayText");
            ItemForThu.Text = LanguageResource.GetDisplayString("ThursdayText");
            ItemForFri.Text = LanguageResource.GetDisplayString("FridayText");
            ItemForSat.Text = LanguageResource.GetDisplayString("SaturdayText");

            ItemForHoli1Group.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + " 1";
            ItemForHoli2Group.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + " 2";
            ItemForHoli3Group.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + " 3";
            ItemForHoli4Group.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + " 4";
            ItemForHoli5Group.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + " 5";
            ItemForHoli6Group.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + " 6";
            ItemForHoli7Group.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + " 7";
            ItemForHoli8Group.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + " 8";
            ItemForDescription.Text = LanguageResource.GetDisplayString("DescriptionText");
           
        }
        void InitBindings()
        {
        }
    }
}
