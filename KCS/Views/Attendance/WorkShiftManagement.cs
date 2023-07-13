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
using KCS.Common.Utils;
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;
using DevExpress.XtraGrid.Views.Grid;

namespace KCS.Views
{
    public partial class WorkShiftManagement : DevExpress.XtraEditors.XtraUserControl
    {
        public WorkShiftManagement()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            gridControl.Load += gridControl_Load;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
            
            gridView.BestFitColumns();

        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }
        void RebindDataSource(RebindMessage<WorkShiftManagementViewModel> message)
        {
            try
            {
                var fluentAPI = mvvmContext.OfType<WorkShiftManagementViewModel>();
                if (message.BindType == 1)
                {
                    fluentAPI.SetObjectDataSourceBinding(bindingSourceList,
                    x => x.WorkShiftDataSet);
                }
                else if (message.BindType == 2)
                {
                    fluentAPI.SetObjectDataSourceBinding(bindingSource,
                    x => x.SelectedWorkShift);
                }
                else
                {
                    fluentAPI.SetObjectDataSourceBinding(bindingSourceList,
                    x => x.WorkShiftDataSet);
                    fluentAPI.SetObjectDataSourceBinding(bindingSource,
                    x => x.SelectedWorkShift);
                }
            }
            catch { }
        }
        void InitBindings()
        {
            Messenger.Default.Register<UpdateCountMessage<WorkShiftManagementViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));
            Messenger.Default.Register<RebindMessage<WorkShiftManagementViewModel>>(this, x => RebindDataSource(x));
            var fluentAPI = mvvmContext.OfType<WorkShiftManagementViewModel>();
            try{
                fluentAPI.SetObjectDataSourceBinding(bindingSourceList,
                x => x.WorkShiftDataSet);
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.SelectedWorkShift);
            }
            catch { }
            
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedWorkShift,
                    args => args.Row as WorkShift,
                    (gView, workshift) => gView.FocusedRowHandle = gView.FindRow(workshift));

          
            //fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
             //           .EventToCommand(
             //               x => x.Edit(null), x => x.SelectedWorkShift,
             //               args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));

            fluentAPI.BindCommand(bbiNew, x => x.New());
            fluentAPI.BindCommand(bbiDelete, x => x.Delete(null), x => x.SelectedWorkShift);
            //fluentAPI.BindCommand(bbiEdit, x => x.Edit(null), x => x.SelectedWorkShift);
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            //fluentAPI.BindCommand(bbiSave, x => x.Save());

            bbiSave.ItemClick += (s, e) =>
                {
                    this.dataLayoutControl1.Validate();
                    fluentAPI.ViewModel.Save();
                };
            foreach (Control control in dataLayoutControl1.Controls)
            {
                BaseEdit edit = control as BaseEdit;
                if (edit == null || edit.DataBindings.Count == 0) continue;
                EditorHelpers.ApplyBindingSettings<WorkShift>(edit, dataLayoutControl1);

            }
        }
        void InitViewDisplay()
        {

            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            //bbiEdit.Caption = LanguageResource.GetDisplayString("ToolBarGroupEdit");
            bbiDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            bbiNew.Caption = LanguageResource.GetDisplayString("ToolBarNew");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");

            ItemForCLASS_CODE.Text = LanguageResource.GetDisplayString("WorkShiftCode");
            colCLASS_CODE.Caption = LanguageResource.GetDisplayString("WorkShiftCode");
            colCLASS_DESC.Caption = LanguageResource.GetDisplayString("WorkShiftName");
            ItemForCLASS_DESC.Text = LanguageResource.GetDisplayString("WorkShiftName");
            ItemForWORK_TIME_START.Text = LanguageResource.GetDisplayString("WorkShiftStartTime");
            ItemForWORK_TIME_END.Text = LanguageResource.GetDisplayString("WorkShiftEndTime");
            ItemForWORK_TIME_LATE.Text = LanguageResource.GetDisplayString("LateTimeText");
            ItemLateTimeMark.Text = LanguageResource.GetDisplayString("LateTimeNoteText");
            ItemForRELAX_TIME1.Text = LanguageResource.GetDisplayString("ResetTimeText") + " 1:(" +  LanguageResource.GetDisplayString("FromText") + ")";
            ItemForRELAX_TIME2.Text = " (" + LanguageResource.GetDisplayString("ToText") + ")";
            ItemForRELAX_TIME3.Text = LanguageResource.GetDisplayString("ResetTimeText") + " 2:(" + LanguageResource.GetDisplayString("FromText") + ")";
            ItemForRELAX_TIME4.Text = " (" + LanguageResource.GetDisplayString("ToText") + ")";
            ItemForWORK_TIME_OVERTIME.Text = LanguageResource.GetDisplayString("OverTimeText");
            ItemOverTimeNote.Text = "(" + LanguageResource.GetDisplayString("OverTimeNoteText") + ")";
            ItemForTURN_OVERTIME.Text = LanguageResource.GetDisplayString("OverTimeUnitText");
            ItemForTURN_TIME.Text = LanguageResource.GetDisplayString("AttendanceTimeText");
            ItemForLEAVE_HOURS.Text = LanguageResource.GetDisplayString("MaxAbsenceTimeText");
            ItemLeaveHoursUnit.Text = ItemTurnOverTimeUint.Text = LanguageResource.GetDisplayString("HourText");
            ItemTrunTimeUnit.Text = LanguageResource.GetDisplayString("MinuteText");
            colCREATE_NAME.Caption = LanguageResource.GetDisplayString("BulidText");
            colCREATE_TIME.Caption = LanguageResource.GetDisplayString("BulidTimeText");
            colBUILD_NAME.Caption = LanguageResource.GetDisplayString("ModifyText");
            colBUILD_TIME.Caption = LanguageResource.GetDisplayString("ModifyTimeText");
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<WorkShiftManagementViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }

        private void WORK_TIME_STARTTimeEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                e.Handled = true;               
                
            }
        }

        private void WORK_TIME_ENDTimeEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                e.Handled = true;

            }
        }

        private void WORK_TIME_LATETimeEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                e.Handled = true;

            }
        }

        private void RELAX_TIME1TimeEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                e.Handled = true;

            }
        }

        private void RELAX_TIME2TimeEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                e.Handled = true;

            }
        }

        private void RELAX_TIME3TimeEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                e.Handled = true;

            }
        }

        private void RELAX_TIME4TimeEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                e.Handled = true;

            }
        }

        private void WORK_TIME_OVERTIMETimeEdit_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is String)
            {
                DateTime dt = Convert.ToDateTime((String)e.Value);
                e.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                e.Handled = true;

            }
        }
    }
}
