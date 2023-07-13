using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ShiftTableCategoryViewModel : KcsDocument
    {
        
        public IList<WorkShiftItem> workShiftItemList = new List<WorkShiftItem>();
        public static ShiftTableCategoryViewModel Create()
        {
            return ViewModelSource.Create(() => new ShiftTableCategoryViewModel());
        }
        protected ShiftTableCategoryViewModel()
        {
            workShiftItemList = WorkShiftDataSource.GetWorkShifItemstList();
            WorkShiftEdit = new TrunWork();
            //SelectedTurnWork = new TrunWork(); 
        }
        protected IDialogService DialogService
        {
            get { return this.GetService<IDialogService>(); }
        }
        private TrunWork TrunWorkFiled;
        private IList<TrunWork> trunWorkList = null;
        public virtual int RecordCount { get; set; }
        public virtual TrunWork WorkShiftEdit { get; set; }

        public virtual IEnumerable<TrunWork> Selection { get; set; }
        

        public virtual TrunWork SelectedTurnWork
        {
            get
            {
                return TrunWorkFiled;
            }
            set
            {
                TrunWorkFiled = value;
                WorkShiftEdit = new TrunWork(TrunWorkFiled);
            }
         }
            

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public  object TrunWorkDataSet
        {
            get
            {
                trunWorkList = WorkShiftDataSource.GetTrunWorkList();
                RecordCount = trunWorkList.Count;
                return trunWorkList;
            }

        }
        public object WorkShiftItemDataSet
        {
            get
            {
                
                return workShiftItemList;
            }

        }
        
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<ShiftTableCategoryViewModel>(this, RecordCount));
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<ShiftTableCategoryViewModel>(this));
        }
        public void CreateAnnualShiftTable(IEnumerable<TrunWork> selectShiftItems)
        {
            if(trunWorkList == null || trunWorkList.Count <= 0 )
            {
                return;
            }
            var SelectShiftTableList = selectShiftItems as IList<TrunWork>;
            if (SelectShiftTableList == null || SelectShiftTableList.Count <= 0)
            {
                SelectShiftTableList = trunWorkList;
            }
            CreatCalendarViewModel createCalendarViewModel = CreatCalendarViewModel.Create();
            if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("CreateAnnualShiftTableText"), "CreatCalendar", createCalendarViewModel))
            {

                if (TaDataSource.HasAnnualCalendarOrNot(createCalendarViewModel.SelectYear) <= 0)
                {//行事历不存在
                    if (MessageService.ShowMessage(LanguageResource.GetDisplayString("CalendarNotExistedText"), LanguageResource.GetDisplayString("CreateAnnualShiftTableText"), MessageButton.YesNo) != MessageResult.Yes)
                        return;
                    Messenger.Default.Send(new WaitingMessage<ShiftTableCategoryViewModel>(this, true));
                    foreach (var shiftTableItem in SelectShiftTableList)
                    {
                        if (TaDataSource.CreateShiftTableWithoutDoList(createCalendarViewModel.SelectYear, shiftTableItem.TURNWORK_GRP) <= 0)
                        {
                            Messenger.Default.Send(new WaitingMessage<ShiftTableCategoryViewModel>(this, false));
                            MessageService.ShowMessage(LanguageResource.GetDisplayString("CreateAnnualShiftTabledFailedText"));

                            return;
                        }
                        
                    }
                }
                else
                {//行事历存在
                    Messenger.Default.Send(new WaitingMessage<ShiftTableCategoryViewModel>(this, true));
                    foreach (var shiftTableItem in SelectShiftTableList)
                    {
                        if (TaDataSource.CreateShiftTableByDoList(createCalendarViewModel.SelectYear, shiftTableItem.TURNWORK_GRP) <= 0)
                        {
                            Messenger.Default.Send(new WaitingMessage<ShiftTableCategoryViewModel>(this, false));
                            MessageService.ShowMessage(LanguageResource.GetDisplayString("CreateAnnualShiftTabledFailedText"));
                            
                            return ;
                        }
                        
                    }
                }

                Messenger.Default.Send(new WaitingMessage<ShiftTableCategoryViewModel>(this, false));
                MessageService.ShowMessage(LanguageResource.GetDisplayString("CreateAnnualShiftTabledOkText"));
            }
        }
        public void Save()
        {
            if (string.IsNullOrEmpty(WorkShiftEdit.TURNWORK_GRP))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ShifTableCodeIsNecessary"));
                return;
            }
            WorkShiftEdit.CREATE_NAME = WorkShiftEdit.BUILD_NAME = CredentialsSource.GetLoginSupervisorMsg();
            if (WorkShiftDataSource.UpdateShiftTable(SelectedTurnWork, WorkShiftEdit))
            {
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("InsertErrorMsg"));
                return;
            }
        }
        public void Edit(object objectTurnWork)
        {
            var selectTrunWork = objectTurnWork as TrunWork;
            WorkShiftEdit = new TrunWork(selectTrunWork);
            
        }
        public void New()
        {
            WorkShiftEdit = new TrunWork();
            SelectedTurnWork = new TrunWork();
        }
        public void Delete(object objectTurnWork)
        {
            if (null != objectTurnWork)
            {
                var sourceShiftItem = objectTurnWork as TrunWork;
                if (WorkShiftDataSource.DeleteFromShiftTable(sourceShiftItem.TURNWORK_GRP))
                {
                    RebindDataSource();
                }
                else
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteItemFailed"));
                    return;
                }
            }
        }
        
    }
}