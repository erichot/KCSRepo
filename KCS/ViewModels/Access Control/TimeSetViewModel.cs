using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;
using KCS.Common.Utils;
using KCS.Sync;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class TimeSetViewModel
    {
        //private IList<AcTimeSet> TimeFrameList = new List<AcTimeSet>();
        public static TimeSetViewModel Create()
        {
            
            return ViewModelSource.Create(() => new TimeSetViewModel());
        }
        public TimeSetViewModel()
        {
            
        }
        public AcTimeSet SelectedAcTimeSet { get; set; }
        public object TimeSetDataSet
        {
            get
            {
               
                
                return SyncManage.TimeFrameList;;
            }
        }

        public void Save(object objectTimeFrame)
        {
            var timeFrame = objectTimeFrame as AcTimeSet;
            AccessControlDataSource.UpdateTimeFrameSet(timeFrame);

            Messenger.Default.Send(new RebindMessage<TimeSetViewModel>(this));
        }
    }
}