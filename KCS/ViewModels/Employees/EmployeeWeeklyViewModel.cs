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
    public class EmployeeWeeklyViewModel
    {
        public static EmployeeWeeklyViewModel Create()
        {

            //return ViewModelSource.Create<EmployeeWeeklyViewModel>();
            return ViewModelSource.Create(() => new EmployeeWeeklyViewModel());
        }


        protected EmployeeWeeklyViewModel()
        {
            workshiftsettings = new WorkShiftSetting();
        }
        public virtual UserWorkShift SelectedUserWorkShift { get; set; }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public WorkShiftSetting workshiftsettings { get; set; }
        public virtual IEnumerable<UserWorkShift> Selection { get; set; }

        public object UserWorkShiftDataSet
        {
            get
            {
                IList<UserWorkShift> userWorkShiftList = UserWorkShiftDataSource.GetUserWorkShiftList();
                return userWorkShiftList;
            }

        }
        public object WorkShiftDataSet
        {
            get
            {
                return WorkShiftDataSource.GetWorkShifItemstList();
            }

        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<EmployeeWeeklyViewModel>(this));
        }
        public void OnSaveUserWeeklySetting()
        {
            var UserWorkShiftList = UserWorkShiftDataSet as IList<UserWorkShift>;
            if (UserWorkShiftList == null || UserWorkShiftList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (Selection == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
           
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsApplySettingToSelectedItems"), LanguageResource.GetDisplayString("ApplyWeeklySettingsButton"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            Messenger.Default.Send(new WaitingMessage<EmployeeWeeklyViewModel>(this, true));
            string SetErrorUserID = "";
            foreach (UserWorkShift userWorkShift in Selection)
            {
                if (!UserWorkShiftDataSource.UpdateUserWorkShift(workshiftsettings, userWorkShift.UserSID))
                {
                    SetErrorUserID = userWorkShift.UserID + ":" + userWorkShift.UserName;
                    break;
                }
            }
            Messenger.Default.Send(new WaitingMessage<EmployeeWeeklyViewModel>(this, false));
            if( !string.IsNullOrEmpty(SetErrorUserID))
                MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed") + " " + SetErrorUserID);
            RebindDataSource();
        }
        public void Save(object selValue)
        {
            int WeekdayNo = 0;
            switch (((DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)selValue).Column.Name)
            {
                case "colMonday":
                    WeekdayNo = 1;
                    break;
                case "colTuesday":
                    WeekdayNo = 2;
                    break;
                case "colWednesday":
                    WeekdayNo = 3;
                    break;
                case "colThursday":
                    WeekdayNo = 4;
                    break;
                case "colFriday":
                    WeekdayNo = 5;
                    break;
                case "colSaturday":
                    WeekdayNo = 6;
                    break;
                case "colSunday":
                    WeekdayNo = 7;
                    break;
            }
            if (WeekdayNo > 0)
            {
                
                if (!UserWorkShiftDataSource.UpdateUserWorkShift(WeekdayNo, ((DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)selValue).Value.ToString(), SelectedUserWorkShift.UserSID))
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
            }
            
        }
    }
}