using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ReadTransAgainViewModel
    {
        public static ReadTransAgainViewModel Create()
        {
            return ViewModelSource.Create(() => new ReadTransAgainViewModel());
        }
        protected ReadTransAgainViewModel()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }

        public object DeviceInfoDataSet
        {
            get
            {
                return DevicesDataSource.GetDevicesInofList();
            }
        }

        public virtual IEnumerable<DeviceInfo> SelectionDevices { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
    }
}