using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class TaHolidaySettingViewModel : KcsDocument
    {
        TaHolidays EditTaHolidays = new TaHolidays();
        public static TaHolidaySettingViewModel Create()
        {
            return ViewModelSource.Create(() => new TaHolidaySettingViewModel());
        }
        public object TaHolidayListsDataSet
        {
            get
            {
                try
                {
                    IList<TaHolidays> leaveTypesList = TaDataSource.GetTaHolidaySettingList();
                    RecordCount = leaveTypesList.Count;
                    return leaveTypesList;
                }
                catch
                {
                    return null;
                }
                
            }
        }
        public virtual int RecordCount { get; set; }
        public TaHolidays SelectedHoliday { 
            get; set; 
        }
        public void Edit(object objectHoliday)
        {
            var holiday = objectHoliday as TaHolidays;
            if( holiday == null)
                EditTaHolidays = new TaHolidays();
            else
                EditTaHolidays = new TaHolidays(holiday);
        }
        public void Save(object objectHoliday)
        {
            
            if (objectHoliday != null)
            {
                var holiday = objectHoliday as TaHolidays;
                holiday.CREATE_NAME = holiday.BUILD_NAME = CredentialsSource.GetLoginSupervisorMsg();
                holiday.CREATE_TIME = holiday.BUILD_TIME = DateTime.Now;
                holiday.HOLIDAY = string.Format("{0:D2}{1:D2}", holiday.HOLIDAY_DT.Month, holiday.HOLIDAY_DT.Day);
                if (!holiday.HOLIDAY.Equals(EditTaHolidays.HOLIDAY) || !holiday.HOLIDAY_DESC.Equals(EditTaHolidays.HOLIDAY_DESC))                
                {
                    TaDataSource.UpdateTaHolidaySetting(holiday, EditTaHolidays.HOLIDAY);
                }

                Messenger.Default.Send(new RebindMessage<TaHolidaySettingViewModel>(this));
            }

        }
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<TaHolidaySettingViewModel>(this, RecordCount));
        }
        public void Delete(object objectHoliday)
        {
           
            if (objectHoliday == null)
                return;
            var holiday = objectHoliday as TaHolidays;
            TaDataSource.DeleteTaHolidaySetting(holiday.HOLIDAY);

            Messenger.Default.Send(new RebindMessage<TaHolidaySettingViewModel>(this));
        }
    }
}