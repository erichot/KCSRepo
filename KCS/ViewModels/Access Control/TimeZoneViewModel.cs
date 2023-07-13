using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using KCS.Common.Utils;
using KCS.Sync;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class TimeZoneViewModel
    {
       
        public static TimeZoneViewModel Create()
        {
            return ViewModelSource.Create(() => new TimeZoneViewModel());
        }
        public TimeZoneViewModel()
        {
            
           

        }
        public AcTimeZone SelectedAcTimeZone { get; set; }
        public object TimeSetDataSet
        {
            get
            {


                return SyncManage.TimeFrameList;
            }
        }
        public object AcTimeZoneDataSet
        {
            get
            {


                return SyncManage.TimeZoneList;
            }
        }

        public void Save(object objectZoneFrame)
        {
            var timeZone = objectZoneFrame as AcTimeZone;
            AccessControlDataSource.UpdateTimeZoneSet(timeZone);

            Messenger.Default.Send(new RebindMessage<TimeZoneViewModel>(this));
        }
    }
}