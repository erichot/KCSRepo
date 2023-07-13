using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class WorkShiftManagementViewModel : KcsDocument
    {
        public static WorkShiftManagementViewModel Create()
        {

            return ViewModelSource.Create(() => new WorkShiftManagementViewModel());
        }
        protected WorkShiftManagementViewModel()
        {
            
            SelectedWorkShift = new WorkShift();
        }
        public virtual int RecordCount { get; set; }
        public virtual WorkShift SelectedWorkShift { get; set; }

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }

        public object WorkShiftDataSet
        {
            get
            {
                IList<WorkShift> workShiftsList = WorkShiftDataSource.GetWorkShiftList();
                RecordCount = workShiftsList.Count;
                return workShiftsList;
            }

        }
        void RebindDataSource(int type)
        {
            Messenger.Default.Send(new RebindMessage<WorkShiftManagementViewModel>(this, type));
        }
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<WorkShiftManagementViewModel>(this, RecordCount));
        }
        public void Edit(object workShiftObject)
        {
            //var workShiftNewViewModel = EditWorkShiftViewModel.Create(workShiftObject as WorkShift);
           // workShiftNewViewModel.SetParentViewModel(this);
            //var document = DocumentManagerService.CreateDocument("EditWorkShift", workShiftNewViewModel);
            //document.Show();
        }
        public void Save()
        {
            if (SelectedWorkShift == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(SelectedWorkShift.CLASS_CODE))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ShifCodeIsNecessary"));
                return;
            }
            if (string.IsNullOrEmpty(SelectedWorkShift.WORK_TIME_START))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("InputStartTimeText"));
                return;
            }
            if (string.IsNullOrEmpty(SelectedWorkShift.WORK_TIME_END))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("InputEndTimeText"));
                return;
            }
            DateTime dtStart = Convert.ToDateTime(SelectedWorkShift.WORK_TIME_START);
            DateTime dtEnd = Convert.ToDateTime(SelectedWorkShift.WORK_TIME_END);
            /*
             * 2018 2 12 修改，允许跨天
            if (dtStart > dtEnd)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("TimeSetErrorText"));
                return;
            }
             * */
            SelectedWorkShift.WORK_TIME_START = dtStart.ToString("HH:mm");
            SelectedWorkShift.WORK_TIME_END = dtEnd.ToString("HH:mm");
            if (dtEnd < dtStart)
            {
               dtEnd = dtEnd.AddDays(1);
            }
            TimeSpan ts = dtEnd-dtStart;
            //休息时间 1
            if (!string.IsNullOrEmpty(SelectedWorkShift.RELAX_TIME1))
            {
                if (string.IsNullOrEmpty(SelectedWorkShift.RELAX_TIME2))
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("ResetTimeText")+ " 1,"+ LanguageResource.GetDisplayString("InputEndTimeText"));
                    return;
                }
                DateTime dtStart1 = Convert.ToDateTime(SelectedWorkShift.RELAX_TIME1);
                DateTime dtEnd1 = Convert.ToDateTime(SelectedWorkShift.RELAX_TIME2);
                /*
                 * 2018 2 12 修改，允许跨天
                if (dtStart1 > dtEnd1)
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("ResetTimeText")+ " 1 " + LanguageResource.GetDisplayString("TimeSetErrorText"));
                    return;
                }
                if( dtStart1>= dtEnd || dtStart1 < dtStart || dtEnd1<= dtStart || dtEnd1 > dtEnd )
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("ResetTimeText")+ " 1," + LanguageResource.GetDisplayString("RestTimeError"));
                    return;
                }
                 * */
                if (dtEnd1 < dtStart1)
                {
                   dtEnd1= dtEnd1.AddDays(1);
                }
                ts -= (dtEnd1-dtStart1);
            }
            if (!string.IsNullOrEmpty(SelectedWorkShift.RELAX_TIME3))
            {
                if (string.IsNullOrEmpty(SelectedWorkShift.RELAX_TIME4))
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("ResetTimeText") + " 2," + LanguageResource.GetDisplayString("InputEndTimeText"));
                    return;
                }
                DateTime dtStart2 = Convert.ToDateTime(SelectedWorkShift.RELAX_TIME3);
                DateTime dtEnd2 = Convert.ToDateTime(SelectedWorkShift.RELAX_TIME4);
                 /*
                 * 2018 2 12 修改，允许跨天
                if (dtStart2 > dtEnd2)
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("ResetTimeText") + " 1 " + LanguageResource.GetDisplayString("TimeSetErrorText"));
                    return;
                }
                if( dtStart2>= dtEnd || dtStart2 < dtStart || dtEnd2<= dtStart || dtEnd2 > dtEnd )
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("ResetTimeText")+ " 1," + LanguageResource.GetDisplayString("RestTimeError"));
                    return;
                }
                  **/
                if (dtEnd2 < dtStart2)
                {
                    dtEnd2 = dtEnd2.AddDays(1);
                }
                ts -= (dtEnd2-dtStart2);
            }
            if( !string.IsNullOrEmpty(SelectedWorkShift.RELAX_TIME1) )
            {
                DateTime dt = Convert.ToDateTime(SelectedWorkShift.RELAX_TIME1);
                SelectedWorkShift.RELAX_TIME1 = dt.ToString("HH:mm");
            }
            if (!string.IsNullOrEmpty(SelectedWorkShift.RELAX_TIME2))
            {
                DateTime dt = Convert.ToDateTime(SelectedWorkShift.RELAX_TIME2);
                SelectedWorkShift.RELAX_TIME2 = dt.ToString("HH:mm");
            }
            if (!string.IsNullOrEmpty(SelectedWorkShift.RELAX_TIME3))
            {
                DateTime dt = Convert.ToDateTime(SelectedWorkShift.RELAX_TIME3);
                SelectedWorkShift.RELAX_TIME3 = dt.ToString("HH:mm");
            }
            if (!string.IsNullOrEmpty(SelectedWorkShift.RELAX_TIME4))
            {
                DateTime dt = Convert.ToDateTime(SelectedWorkShift.RELAX_TIME4);
                SelectedWorkShift.RELAX_TIME4 = dt.ToString("HH:mm");
            }

            if (!string.IsNullOrEmpty(SelectedWorkShift.WORK_TIME_LATE))
            {
                DateTime dt = Convert.ToDateTime(SelectedWorkShift.WORK_TIME_LATE);
                SelectedWorkShift.WORK_TIME_LATE = dt.ToString("HH:mm");
            }
            if (!string.IsNullOrEmpty(SelectedWorkShift.WORK_TIME_OVERTIME))
            {
                DateTime dt = Convert.ToDateTime(SelectedWorkShift.WORK_TIME_OVERTIME);
                SelectedWorkShift.WORK_TIME_OVERTIME = dt.ToString("HH:mm");
            }
            SelectedWorkShift.TURN_TIME = ts.Hours * 60 + ts.Minutes;
            if (WorkShiftDataSource.UpdateWorkShift(SelectedWorkShift))
            {
                RebindDataSource(0);
                
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
            }
        }
        public void New()
        {
            SelectedWorkShift = new WorkShift();
            RebindDataSource(2);
            //var workShiftNewViewModel = EditWorkShiftViewModel.Create();
            //workShiftNewViewModel.SetParentViewModel(this);
            //var document = DocumentManagerService.CreateDocument("EditWorkShift", workShiftNewViewModel);
            //document.Show();
        }
        public void Delete(object workShiftObject)
        {
            var WorkShiftList = WorkShiftDataSet as IList<WorkShift>;
            if (WorkShiftList == null || WorkShiftList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (workShiftObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }

            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsDeleteItems"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var selWorkShift = workShiftObject as WorkShift;
            bool bRet = WorkShiftDataSource.DeleteWorkShift(selWorkShift.CLASS_CODE);
            if (bRet)
            {

                RebindDataSource(0);
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteEmployeeFailed"));
            }
            
        }
    }
}