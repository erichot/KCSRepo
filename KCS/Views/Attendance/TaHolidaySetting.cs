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
using DevExpress.Schedule;
using KCS.Views.Attendance;
using KCS.Models;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Utils;
using KCS.ViewModels;
using DevExpress.Mvvm;
using KCS.Common.Utils;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace KCS.Views
{
    public partial class TaHolidaySetting : DevExpress.XtraEditors.XtraUserControl
    {
      
        public TaHolidaySetting()
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
        void RebindDataSource()
        {
            try
            {
                var fluentAPI = mvvmContext.OfType<TaHolidaySettingViewModel>();
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.TaHolidayListsDataSet);
                gridView.RefreshData();
            }
            catch { }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<TaHolidaySettingViewModel>();
            Messenger.Default.Register<UpdateCountMessage<TaHolidaySettingViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.TaHolidayListsDataSet);
            }
            catch { }

            
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), fluentAPI.ViewModel.RecordCount);
            fluentAPI.WithEvent<RowObjectEventArgs>(gridView, "RowUpdated")
           .EventToCommand(x => x.Save(null), new Func<RowObjectEventArgs, object>(e => e.Row)); //

            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                       .EventToCommand(
                           x => x.Edit(null), x => x.SelectedHoliday,
                           args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));

            Messenger.Default.Register<RebindMessage<TaHolidaySettingViewModel>>(this, x => RebindDataSource());
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
               .SetBinding(x => x.SelectedHoliday,
                   args => args.Row as TaHolidays,
                   (gView, LeaveType) => gView.FocusedRowHandle = gView.FindRow(LeaveType));
            bbiNew.ItemClick += (s, e) =>
            {
                gridView.AddNewRow();
            };
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiDelete, x => x.Delete(null), x => x.SelectedHoliday);
            //gridView.RowUpdated += (s, e) =>
            //    {
            //        MessageBox.Show("1");
            //    };
        }
        void InitViewDisplay()
        {
            ribbonPageGroupEdit.Text = LanguageResource.GetDisplayString("ToolBarGroupEdit");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");

            bbiDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            bbiNew.Caption = LanguageResource.GetDisplayString("ToolBarNew");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            colHOLIDAY.Caption = LanguageResource.GetDisplayString("DateText");
            colHOLIDAY_DESC.Caption = LanguageResource.GetDisplayString("HolidayNameText");

            colCREATE_NAME.Caption = LanguageResource.GetDisplayString("BulidText");
            colCREATE_TIME.Caption = LanguageResource.GetDisplayString("BulidTimeText");
            colBUILD_NAME.Caption = LanguageResource.GetDisplayString("ModifyText");
            colBUILD_TIME.Caption = LanguageResource.GetDisplayString("ModifyTimeText");

            
        }

        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<TaHolidaySettingViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }

       
        

      
    }
}
