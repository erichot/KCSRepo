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
using DevExpress.XtraScheduler;
using DevExpress.Utils.Menu;
using KCS.Common.Utils;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Schedule;
using KCS.Models;

namespace KCS.Views
{
    
    public partial class HolidaySet : DevExpress.XtraEditors.XtraUserControl
    {
        //HolidayBaseCollection HolidayCollection = new HolidayBaseCollection();
        private IList<AcHolidaySet>  HolidayList;
        public HolidaySet()
        {
            InitializeComponent();
            
            HolidayList = AccessControlDataSource.GetHolidaySetList();
        }//

        protected override void OnLoad(System.EventArgs e)
        {

            base.OnLoad(e);
            
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();

        }
        void InitViewDisplay()
        {
            lblCtlType1.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + "1";
            lblCtlType2.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + "2";
            lblCtlType3.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + "3";
            lblCtlType4.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + "4";
            lblCtlType5.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + "5";
            lblCtlType6.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + "6";
            lblCtlType7.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + "7";
            lblCtlType8.Text = LanguageResource.GetDisplayString("AccessControlHoliType") + "8";
            
            schedulerControl.BeginUpdate();
            this.schedulerControl.WorkDays.Clear();
            this.schedulerControl.WorkDays.Add(WeekDays.WorkDays);
            foreach (AcHolidaySet holidaySet in HolidayList)
            {
                if (holidaySet.HoliType != 255)
                    this.schedulerControl.WorkDays.Add(new Holiday(new DateTime(DateTime.Now.Year, holidaySet.HoliMonth, holidaySet.HoliDay), LanguageResource.GetDisplayString("AccessControlHoliType") + holidaySet.HoliType.ToString() + "(" + holidaySet.Description + ")"));
            }
            this.schedulerControl.EndUpdate();
        }
        void AddHoliday(Holiday holiday)
        {
            //foreach (Holiday item in HolidayCollection) {
            //    this.schedulerControl1.WorkDays.Add(item);

           // if (HolidayCollection.Contains(holiday))
                    //HolidayCollection.Add(holiday);
        }
        void SetHolidayType(int holiType)
        {
        }
        
        void form_HolidaySet(object sender, HolidaySetEventArgs e)
        {
            TimeInterval dt = dateNavigator.SchedulerControl.SelectedInterval;
            
            byte HoliType = e.HolidayType;
            string HoliDes = e.HolidayDescription;
            //if (HoliType != 0)
            {
                schedulerControl.BeginUpdate();
                //this.schedulerControl.WorkDays.Clear();
                //this.schedulerControl.WorkDays.Add(WeekDays.WorkDays);
                //foreach (Holiday item in HolidayCollection)
                Holiday holi = FindHoliday(dt.Start.Date);
                if (null == holi)
                {
                    if (HoliType != 0)
                    this.schedulerControl.WorkDays.Add(new Holiday(new DateTime(dt.Start.Year, dt.Start.Month, dt.Start.Day), LanguageResource.GetDisplayString("AccessControlHoliType") + HoliType.ToString() + "(" + HoliDes + ")"));
                }
                else
                {
                    if (HoliType != 0)
                        holi.DisplayName = LanguageResource.GetDisplayString("AccessControlHoliType") + HoliType.ToString() + "(" + HoliDes + ")";
                    else
                        this.schedulerControl.WorkDays.Remove(holi);
                }
                

                //this.schedulerControl.WorkDays.Add(new Holiday(new DateTime(dt.Start.Year, dt.Start.Month, dt.Start.Day), LanguageResource.GetDisplayString("AccessControlHoliType") + HoliType.ToString()));
                schedulerControl.EndUpdate();
                AcHolidaySet holidaySet = new AcHolidaySet();
                holidaySet.HoliType = HoliType;
                if (HoliType == 0)
                    holidaySet.HoliType = 0xff;
                holidaySet.HoliMonth = (byte)dt.Start.Month;
                holidaySet.HoliDay = (byte)dt.Start.Day;
                holidaySet.Description = HoliDes;
                holidaySet.DoorHoliID = (holidaySet.HoliMonth - 1) * 31 + (holidaySet.HoliDay - 1);
                AccessControlDataSource.UpdateHolidaySet(holidaySet);
            }
            

             

        }
        void HolidaySet_Click(object sender, EventArgs e)
        {
            
           
            //dt.Start
           

        }
        void TypeNull_Click(object sender, EventArgs e)
        {
        }
        void Type1_Click(object sender, EventArgs e)
        {
           // AppointmentViewInfoCollection appointmentViewInfos = this.schedulerControl.selectDate;  
           // apt.Description = "1234";
            
        }
        void Type2_Click(object sender, EventArgs e)
        {
        }
        void Type3_Click(object sender, EventArgs e)
        {
        }
        void Type4_Click(object sender, EventArgs e)
        {
        }
        void Type5_Click(object sender, EventArgs e)
        {
        }
        void Type6_Click(object sender, EventArgs e)
        {
        }
        void Type7_Click(object sender, EventArgs e)
        {
        }
        void Type8_Click(object sender, EventArgs e)
        {
        }
        void InitBindings()
        {
            
            schedulerControl.PopupMenuShowing += (s, e) =>
                {
                    SchedulerControl control = this.schedulerControl;
                    if (e.Menu.Id == DevExpress.XtraScheduler.SchedulerMenuItemId.DefaultMenu)
                    {
                        e.Menu.RemoveMenuItem(SchedulerMenuItemId.SwitchViewMenu);
                        e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);
                        e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoDate);
                        e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoThisDay);
                        e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoToday);
                        //隐藏【视图更改为】菜单
                       // SchedulerPopupMenu itemChangeViewTo = e.Menu.GetPopupMenuById(SchedulerMenuItemId.SwitchViewMenu);
                        //itemChangeViewTo.Visible = false;

                        //删除【新建所有当天事件】菜单
                        //e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);

                        //设置【新建定期日程安排】菜单为不可用
                       // e.Menu.DisableMenuItem(SchedulerMenuItemId.NewRecurringAppointment);

                        //改名【新建日程安排】菜单为自定义名称
                        //SchedulerMenuItem item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment);
                        //if (item != null) item.Caption = "新建一个计划";
                        //创建一个新的自定义事件菜单
                        //DXMenuItem menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("HolidaySetText"));
                        //menuTest.Click += HolidaySet_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);

                        //DXMenuItem menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("AccessControlHoliTypeNULL") );
                        //menuTest.Click += TypeNull_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);

                        //menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("AccessControlHoliType") + "1");
                        //menuTest.Click += Type1_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);

                        //menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("AccessControlHoliType") + "2");
                        //menuTest.Click += Type2_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);

                        //menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("AccessControlHoliType") + "3");
                        //menuTest.Click += Type3_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);

                        //menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("AccessControlHoliType") + "4");
                        //menuTest.Click += Type4_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);

                        //menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("AccessControlHoliType") + "5");
                        //menuTest.Click += Type5_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);

                        //menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("AccessControlHoliType") + "6");
                        //menuTest.Click += Type6_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);

                        //menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("AccessControlHoliType") + "7");
                        //menuTest.Click += Type7_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);

                        //menuTest = new SchedulerMenuItem(LanguageResource.GetDisplayString("AccessControlHoliType") + "8");
                        //menuTest.Click += Type8_Click;
                        //menuTest.BeginGroup = true;
                        //e.Menu.Items.Add(menuTest);
                    }
                };
        }
        private Holiday FindHoliday(DateTime date)
        {
            foreach (WorkDay item in schedulerControl.WorkDays)
            {
                if (item is Holiday)
                {
                    Holiday hol = (Holiday)item;
                    if (hol.Date == date)
                        return hol;
                }
            }
            return null;
        }

        private void schedulerControl_CustomDrawDayHeader(object sender, CustomDrawObjectEventArgs e)
        {
            SchedulerHeader header = e.ObjectInfo as SchedulerHeader;
            if (header != null)
            {

                // Check whether the current date is a known holiday.
                Holiday hol = FindHoliday(header.Interval.Start.Date);
                if (hol != null)
                {

                    // Add the holiday name to the day header's caption.
                    header.Caption = String.Format("{0}", hol.DisplayName);
                    string Holitype = hol.DisplayName.Substring(0,hol.DisplayName.IndexOf("("));
                    string HolitypeNum = Holitype.Substring(Holitype.Length - 1, 1);
                    switch (HolitypeNum)
                    {
                        case "1":
                            header.Appearance.HeaderCaption.ForeColor = Color.LightCoral;
                            header.Appearance.AlternateHeaderCaption.ForeColor = Color.LightCoral;
                            break;
                        case "2":
                            header.Appearance.HeaderCaption.ForeColor = Color.OrangeRed;
                            header.Appearance.AlternateHeaderCaption.ForeColor = Color.OrangeRed;
                            break;
                        case "3":
                            header.Appearance.HeaderCaption.ForeColor = Color.Chartreuse;
                            header.Appearance.AlternateHeaderCaption.ForeColor = Color.Chartreuse;
                            break;
                        case "4":
                            header.Appearance.HeaderCaption.ForeColor = Color.YellowGreen;
                            header.Appearance.AlternateHeaderCaption.ForeColor = Color.YellowGreen;
                            break;
                        case "5":
                            header.Appearance.HeaderCaption.ForeColor = Color.DarkGreen;
                            header.Appearance.AlternateHeaderCaption.ForeColor = Color.DarkGreen;
                            break;
                        case "6":
                            header.Appearance.HeaderCaption.ForeColor = Color.Aqua;
                            header.Appearance.AlternateHeaderCaption.ForeColor = Color.Aqua;
                            break;
                        case "7":
                            header.Appearance.HeaderCaption.ForeColor = Color.MidnightBlue;
                            header.Appearance.AlternateHeaderCaption.ForeColor = Color.MidnightBlue;
                            break;
                        case "8":
                            header.Appearance.HeaderCaption.ForeColor = Color.Indigo;
                            header.Appearance.AlternateHeaderCaption.ForeColor = Color.Indigo;
                            break;
                        case "0":
                            header.Caption = String.Format("{0}", hol.Date.Day.ToString());
                            break;
                        default:
                            break;
                    }
                    
                    header.ToolTipText = header.Caption;
                    header.ShouldShowToolTip = true;
                }
            }

        }

        private void schedulerControl_DoubleClick(object sender, EventArgs e)
        {
            TimeInterval dt = dateNavigator.SchedulerControl.SelectedInterval;
            Holiday holi = FindHoliday(dt.Start.Date);
            if (holi != null)
            {                
                NewHoliday newHolidayDlg = new NewHoliday(holi.DisplayName);
                newHolidayDlg.HolidaySetChanged += form_HolidaySet;

                newHolidayDlg.ShowDialog();
            }
            else
            {
                NewHoliday newHolidayDlg = new NewHoliday();
                newHolidayDlg.HolidaySetChanged += form_HolidaySet;

                newHolidayDlg.ShowDialog();
            }
            
        }

    }
}
