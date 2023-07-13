using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Sync;
using DevExpress.Utils.MVVM.Services;
using KCS.Models;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class FindDeviceViewModel : KcsDocument
    {
        public static FindDeviceViewModel Create()
        {

            return ViewModelSource.Create(() => new FindDeviceViewModel());
        }
        public object RegDevicesDataSet
        {
            get
            {
                RecordCount = SyncManage.GetRegisterDevices().Count;
                return SyncManage.GetRegisterDevices();
            }
        }
        public virtual int RecordCount { get; set; }
        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }
        public KCS.Models.RegDevice SelectedRegDevice { get; set; }

        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<FindDeviceViewModel>(this, RecordCount));
        }

        public void Refresh()
        {
            NetSockets.NetUtility.BroadCastToAllDevices();
        }
        
        public void Edit(object regDeviceObject)
        {
            var regDevice = regDeviceObject as RegDevice;
            var deviceNewViewModel = NewDeviceViewModel.Create(regDevice.SlaveSID, regDevice.IP);
            deviceNewViewModel.SetParentViewModel(this.GetParentViewModel<DeviceSettingManageViewModel>());
            var document = DocumentManagerService.CreateDocument("NewDevice", deviceNewViewModel);
            document.Show();
        }
    }
}