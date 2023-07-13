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
using DevExpress.Mvvm;
using KCS.ViewModels;
using KCS.Common.Utils;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;
using DevExpress.XtraGrid.Views.Grid;

namespace KCS.Views
{
    public partial class ShiftTableCategory : DevExpress.XtraEditors.XtraUserControl
    {
        KCS.Services.IWaitingService waitingService1 = new KCS.Services.WaitingService();

        public ShiftTableCategory()
        {
            InitializeComponent();
           // waitingService1 = mvvmContext.GetService<Services.IWaitingService>();
        }

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            gridControl.Load += gridControl_Load;
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();
            gridView.BestFitColumns();
           
            
        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }
        void RebindDataSource()
        {
            try
            {
                var fluentAPI = mvvmContext.OfType<ShiftTableCategoryViewModel>();
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
               x => x.TrunWorkDataSet);
            }
            catch { }
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ShiftTableCategoryViewModel>();
            Messenger.Default.Register<UpdateCountMessage<ShiftTableCategoryViewModel>>(this, x => UpdateEntitiesCountRelatedUI(x));
            Messenger.Default.Register<RebindMessage<ShiftTableCategoryViewModel>>(this, x => RebindDataSource());
            Messenger.Default.Register<WaitingMessage<ShiftTableCategoryViewModel>>(this, ShowWaiting);
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSourceWorkShift,
                x => x.WorkShiftItemDataSet);

                

                fluentAPI.SetObjectDataSourceBinding(bindingSource,
               x => x.TrunWorkDataSet);

                fluentAPI.SetObjectDataSourceBinding(bindingSourceEdit,
               x => x.WorkShiftEdit);
            }
            catch {
                
            }
           
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedTurnWork,
                    args => args.Row as TrunWork,
                    (gView, turnWork) => gView.FocusedRowHandle = gView.FindRow(turnWork));

            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                       .EventToCommand(
                           x => x.Edit(null), x => x.SelectedTurnWork,
                           args => (args.Clicks == 1) && (args.Button == System.Windows.Forms.MouseButtons.Left));

            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView, "SelectionChanged")
               .SetBinding(x => x.Selection, e => GetSelectedShiftItem());

            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiNew, x => x.New());
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiDelete, x => x.Delete(null), x => x.SelectedTurnWork);
            fluentAPI.BindCommand(bbiCreateAnnualShiftTable, x => x.CreateAnnualShiftTable(null),x => x.Selection);
            
            //fluentAPI.SetBinding(textEditShiftCode, x => x.Text, x => x.WorkShiftEdit.TURNWORK_GRP);

            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), fluentAPI.ViewModel.RecordCount);
            
           

            lookUpEditShiftCode1.EditValueChanged += (s, e) =>
                {
                    TextEdit edit = s as TextEdit;
                    WorkShiftItem workShiftItem = fluentAPI.ViewModel.workShiftItemList.FirstOrDefault(f => f.CLASS_CODE.Equals(edit.Text));
                    if (workShiftItem != null)
                    {
                        textEditShiftName1.Text = workShiftItem.CLASS_DESC;
                        textEditStartTime1.Text = workShiftItem.WORK_TIME_START;
                        textEditEndTime1.Text = workShiftItem.WORK_TIME_END;
                    }
                };
            lookUpEditShiftCode2.EditValueChanged += (s, e) =>
            {
                TextEdit edit = s as TextEdit;
                WorkShiftItem workShiftItem = fluentAPI.ViewModel.workShiftItemList.FirstOrDefault(f => f.CLASS_CODE.Equals(edit.Text));
                if (workShiftItem != null)
                {
                    textEditShiftName2.Text = workShiftItem.CLASS_DESC;
                    textEditStartTime2.Text = workShiftItem.WORK_TIME_START;
                    textEditEndTime2.Text = workShiftItem.WORK_TIME_END;
                }
            };
            lookUpEditShiftCode3.EditValueChanged += (s, e) =>
            {
                TextEdit edit = s as TextEdit;
                WorkShiftItem workShiftItem = fluentAPI.ViewModel.workShiftItemList.FirstOrDefault(f => f.CLASS_CODE.Equals(edit.Text));
                if (workShiftItem != null)
                {
                    textEditShiftName3.Text = workShiftItem.CLASS_DESC;
                    textEditStartTime3.Text = workShiftItem.WORK_TIME_START;
                    textEditEndTime3.Text = workShiftItem.WORK_TIME_END;
                }
            };
            lookUpEditShiftCode4.EditValueChanged += (s, e) =>
            {
                TextEdit edit = s as TextEdit;
                WorkShiftItem workShiftItem = fluentAPI.ViewModel.workShiftItemList.FirstOrDefault(f => f.CLASS_CODE.Equals(edit.Text));
                if (workShiftItem != null)
                {
                    textEditShiftName4.Text = workShiftItem.CLASS_DESC;
                    textEditStartTime4.Text = workShiftItem.WORK_TIME_START;
                    textEditEndTime4.Text = workShiftItem.WORK_TIME_END;
                }
            };
            lookUpEditShiftCode5.EditValueChanged += (s, e) =>
            {
                TextEdit edit = s as TextEdit;
                WorkShiftItem workShiftItem = fluentAPI.ViewModel.workShiftItemList.FirstOrDefault(f => f.CLASS_CODE.Equals(edit.Text));
                if (workShiftItem != null)
                {
                    textEditShiftName5.Text = workShiftItem.CLASS_DESC;
                    textEditStartTime5.Text = workShiftItem.WORK_TIME_START;
                    textEditEndTime5.Text = workShiftItem.WORK_TIME_END;
                }
            };
            lookUpEditShiftCode6.EditValueChanged += (s, e) =>
            {
                TextEdit edit = s as TextEdit;
                WorkShiftItem workShiftItem = fluentAPI.ViewModel.workShiftItemList.FirstOrDefault(f => f.CLASS_CODE.Equals(edit.Text));
                if (workShiftItem != null)
                {
                    textEditShiftName6.Text = workShiftItem.CLASS_DESC;
                    textEditStartTime6.Text = workShiftItem.WORK_TIME_START;
                    textEditEndTime6.Text = workShiftItem.WORK_TIME_END;
                }
            };
            lookUpEditShiftCode7.EditValueChanged += (s, e) =>
            {
                TextEdit edit = s as TextEdit;
                WorkShiftItem workShiftItem = fluentAPI.ViewModel.workShiftItemList.FirstOrDefault(f => f.CLASS_CODE.Equals(edit.Text));
                if (workShiftItem != null)
                {
                    textEditShiftName7.Text = workShiftItem.CLASS_DESC;
                    textEditStartTime7.Text = workShiftItem.WORK_TIME_START;
                    textEditEndTime7.Text = workShiftItem.WORK_TIME_END;
                }
            };
           
        }
        void InitViewDisplay()
        {
            lblCtlShiftCode.Text = colTURNWORK_GRP.Caption = LanguageResource.GetDisplayString("ShiftTabelCodeText");
            lblCtlShiftName.Text = colTURNWORK_DESC.Caption = LanguageResource.GetDisplayString("RemarkText");
            lblCtlShiftNameDis.Text =  LanguageResource.GetDisplayString("WorkShiftName");
            lblCtlSunday.Text = colCLASS_CODE1.Caption = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)0);
            lblCtlMonday.Text = colCLASS_CODE2.Caption = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)1);
            lblCtlTuesday.Text = colCLASS_CODE3.Caption = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)2);
            lblCtlWendsday.Text = colCLASS_CODE4.Caption = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)3);
            lblCtlThirsday.Text = colCLASS_CODE5.Caption = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)4);
            lblCtlFriday.Text = colCLASS_CODE6.Caption = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)5);
            lblCtlSaturday.Text = colCLASS_CODE7.Caption = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName((DayOfWeek)6);

            colCREATE_NAME.Caption = LanguageResource.GetDisplayString("BulidText");
            colCREATE_TIME.Caption = LanguageResource.GetDisplayString("BulidTimeText");
            colBUILD_NAME.Caption = LanguageResource.GetDisplayString("ModifyText");
            colBUILD_TIME.Caption = LanguageResource.GetDisplayString("ModifyTimeText");

            lblCtlDefaultShift.Text = LanguageResource.GetDisplayString("DefaultShiftText");
            lblCtlStartTime.Text = LanguageResource.GetDisplayString("WorkShiftStartTime");
            lblCtlEndTime.Text = LanguageResource.GetDisplayString("WorkShiftEndTime");

            bbiDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            bbiNew.Caption = LanguageResource.GetDisplayString("ToolBarNew");
            ribbonPageGroupClose.Text = bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");

            bbiCreateAnnualShiftTable.Caption = LanguageResource.GetDisplayString("CreateAnnualShiftTableText");
            ribbonPageGroupEdit.Text = LanguageResource.GetDisplayString("ToolBarGroupAction"); ;
              // EditorHelpers.ApplyBindingSettings<WorkShift>(edit, dataLayoutControl1);

            
        }
        void ShowWaiting(WaitingMessage<ShiftTableCategoryViewModel> message)
        {
            if (null == waitingService1)
                return;
            if (message.IsShow)
            {

                waitingService1.BeginWaiting(LanguageResource.GetDisplayString("ProcessingText") + "...");
            }
            else
            {
                waitingService1.EndWaiting();
            }
        }
        IEnumerable<TrunWork> GetSelectedShiftItem()
        {
            return gridView.GetSelectedRows().Select(r => gridView.GetRow(r) as TrunWork);
        }
        void UpdateEntitiesCountRelatedUI(UpdateCountMessage<ShiftTableCategoryViewModel> message)
        {
            hiItemsCount.Caption = string.Format("{0}: {1}", LanguageResource.GetDisplayString("RecordsText"), message.RecordCount);
        }
    }
}
