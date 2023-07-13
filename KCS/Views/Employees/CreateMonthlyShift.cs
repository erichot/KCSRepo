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
using KCS.Models;

namespace KCS.Views
{
    public partial class CreateMonthlyShift : BaseViewControl
    {
        KCS.Services.IWaitingService waitingService;

        public CreateMonthlyShift()
            : base(typeof(CreateMonthlyShiftViewModel))
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            gridControl.Load += gridControl_Load;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();

            waitingService = GetService<Services.IWaitingService>();
        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<CreateMonthlyShiftViewModel>();

            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
              .SetBinding(x => x.Selection, e => GetSelectedEmployeesBrief());


            fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.EmployeesBriefDataSet);
            fluentAPI.SetBinding(radioButtonAll, x => x.Checked, x => x.SelectAllEmployees);
            fluentAPI.SetBinding(comboBoxEditYear, x => x.Text, x => x.SelectYear);
            fluentAPI.BindCommand(simpleButtonCreate, x => x.CreateMonthlyShift());
        }
        void InitViewDisplay()
        {
            int curYear = DateTime.Now.Year;
            for (int i = -10; i < 0; i++)
            {
                comboBoxEditYear.Properties.Items.Add((curYear + i).ToString());
            }
            for (int i = 0; i < 10; i++)
            {
                comboBoxEditYear.Properties.Items.Add((curYear + i).ToString());
            }
            //comboBoxEditYear.SelectedItem = curYear;
            radioButtonAll.Text = LanguageResource.GetDisplayString("ApplyToAll");
            radioButtonSelected.Text = LanguageResource.GetDisplayString("ApplyToSelectedUser");
            simpleButtonCreate.Text = LanguageResource.GetDisplayString("CreateMonthlyShift");
            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentID");
            colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName"); 
        }
        void ShowWaiting(WaitingMessage<CreateMonthlyShiftViewModel> message)
        {
            if (message.IsShow)
            {

                waitingService.BeginWaiting(LanguageResource.GetDisplayString("ProcessingText") + "...");
            }
            else
            {
                waitingService.EndWaiting();
            }
        }
        IEnumerable<EmployeeBrief> GetSelectedEmployeesBrief()
        {
            return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as EmployeeBrief);
        }
    }
}
