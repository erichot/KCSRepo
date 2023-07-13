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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Mvvm;
using KCS.Models;
using KCS.Common.Utils;

namespace KCS.Views
{
    public partial class LeaveType : DevExpress.XtraEditors.XtraUserControl
    {
        public LeaveType()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
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
                var fluentAPI = mvvmContext.OfType<LeaveTypeViewModel>();
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.LeaveTypeDataSet);
            }
            catch { }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<LeaveTypeViewModel>();
            Messenger.Default.Register<UpdateCountMessage<LeaveTypeViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.LeaveTypeDataSet);
            }
            catch { }
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), fluentAPI.ViewModel.RecordCount);
            fluentAPI.WithEvent<RowObjectEventArgs>(gridView, "RowUpdated")
           .EventToCommand(x => x.Save(null), new Func<RowObjectEventArgs, object>(e => e.Row));
            Messenger.Default.Register<RebindMessage<LeaveTypeViewModel>>(this, x => RebindDataSource());
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
               .SetBinding(x => x.SelectedLeaveType,
                   args => args.Row as TaLeaveType,
                   (gView, LeaveType) => gView.FocusedRowHandle = gView.FindRow(LeaveType));
            bbiNew.ItemClick += (s, e) =>
            {
                gridView.AddNewRow();
            };
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiDelete, x => x.Delete(null), x => x.SelectedLeaveType);
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

            colLEAVE_CODE.Caption = LanguageResource.GetDisplayString("LeaveTypeIdText");
            colLEAVE_DESC.Caption = LanguageResource.GetDisplayString("LeaveTypeNameText");

            colCREATE_NAME.Caption = LanguageResource.GetDisplayString("BulidText");
            colCREATE_TIME.Caption = LanguageResource.GetDisplayString("BulidTimeText");
            colBUILD_NAME.Caption = LanguageResource.GetDisplayString("ModifyText");
            colBUILD_TIME.Caption = LanguageResource.GetDisplayString("ModifyTimeText");
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<LeaveTypeViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }
    }
}
