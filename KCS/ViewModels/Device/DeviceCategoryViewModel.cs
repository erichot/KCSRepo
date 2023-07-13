using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class DeviceCategoryViewModel : KcsDocument 
    {
        public static DeviceCategoryViewModel Create()
        {

            return ViewModelSource.Create(() => new DeviceCategoryViewModel());
        }
        
        public object DeviceCategoryDataSet
        {
            get
            {
                return DevicesDataSource.GetDeviceCategoryList();
            }
        }
        public SlaveCategory SelectedSlaveCategory { get; set; }
        public void Save(object objectSlaveCategory)
        {
            var slaveCategory = objectSlaveCategory as SlaveCategory;
            DevicesDataSource.AddDeviceCategory(slaveCategory);
           
            Messenger.Default.Send(new RebindMessage<DeviceCategoryViewModel>(this));
            
        }
        public void Delete(object objectSlaveCategory)
        {
            var slaveCategory = objectSlaveCategory as SlaveCategory;
            if (slaveCategory == null)
                return;
            DevicesDataSource.DeleteDeviceCategory(slaveCategory);

            Messenger.Default.Send(new RebindMessage<DeviceCategoryViewModel>(this));
        }
    }
}