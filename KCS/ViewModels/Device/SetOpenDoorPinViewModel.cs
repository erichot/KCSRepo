using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using KCS.Models;
using DevExpress.Mvvm.POCO;
using KCS.ViewModels;
using System.ComponentModel;
using KCS.Sync;
using KCS.Common.Utils;

namespace KCS.Views
{
    [POCOViewModel]
    public class SetOpenDoorPinViewModel : KcsDocument
    {
         public virtual int SelectDeviceId { get; set; }
         public virtual DoorPIN EditDoorPIN { get; set; }
        public static SetOpenDoorPinViewModel Create()
        {

            return ViewModelSource.Create(() => new SetOpenDoorPinViewModel());
        }
        public static SetOpenDoorPinViewModel Create(int deviceId)
        {

            return ViewModelSource.Create(() => new SetOpenDoorPinViewModel(deviceId));
        }
        protected SetOpenDoorPinViewModel()
        {
                        
        }
        protected SetOpenDoorPinViewModel(int deviceId)
        {
            SelectDeviceId = deviceId;
            EditDoorPIN = SyncManage.GetOpenDoorPin(SelectDeviceId);
           
            
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = EditDoorPIN as IDataErrorInfo;
          
            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }
        public void Save()
        {
            if (EditDoorPIN == null)
                return;
            if (!HasValidationErrors())
            {
                if (!SyncManage.SetOpenDoorPin(SelectDeviceId, EditDoorPIN))
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
                }
                else
                {
                    Close();
                }
            }
        }
    }
}