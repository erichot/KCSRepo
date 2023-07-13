using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class CalendarEditViewModel : KcsDocument
    {
        public virtual int SelectYear { get; set; }
        public static CalendarEditViewModel Create()
        {
            return ViewModelSource.Create(() => new CalendarEditViewModel());
        }
        protected CalendarEditViewModel()
        {            
            SelectYear = DateTime.Now.Year;
        }
        public virtual AnnulaCalendar SelectedCalendarSet
        { 
            get; set; 
        }
        
        public object AnnualCalendarDataSet
        {
            get
            {
                return TaDataSource.GetAnnualCalendarList(SelectYear);
            }
        }
        protected void OnSelectYearChanged()
        {
            RebindDataSource();
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<CalendarEditViewModel>(this));
        }
        public void Save(object objectCalendarSet)
        {
            if (objectCalendarSet != null)
            {
                var calendarSet = objectCalendarSet as AnnulaCalendar;
                calendarSet.CREATE_NAME = calendarSet.BUILD_NAME = CredentialsSource.GetLoginSupervisorMsg();
                calendarSet.CREATE_TIME = calendarSet.BUILD_TIME = DateTime.Now;

                if( !TaDataSource.UpdateAnnualCalendarSet(calendarSet))
                    Messenger.Default.Send(new RebindMessage<CalendarEditViewModel>(this));
            }
        }
    }
}