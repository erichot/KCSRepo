using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using KCS.ViewModels;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;
using KCS.Common.Utils;

namespace KCS.Views
{
    [POCOViewModel]
    public class SetDeviceParametersViewModel : KcsDocument
    {
        public virtual string SetPassword { get; set; }
        public virtual string SetWorkMode { get; set; }
        public virtual string SetLanguage { get; set; }

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public static SetDeviceParametersViewModel Create()
        {

            return ViewModelSource.Create(() => new SetDeviceParametersViewModel());
        }
        protected SetDeviceParametersViewModel()
        {
            DeviceLanguage devLang = new DeviceLanguage();
            SetLanguage = devLang[2];
            DeviceWorkMode devWorkMode = new DeviceWorkMode();
            SetWorkMode = devWorkMode[0];
        }
        public virtual IEnumerable<DeviceBrief> SelectionDevices { get; set; }

        public object DeviceInfoDataSet
        {
            get
            {
                return DevicesDataSource.GetDeviceBriefDataList();
            }
        }

        public void SetDevicePassword()
        {
            if (SelectionDevices == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedDevicesFirst"));
                return;
            }
            if (!DevicesDataSource.UpdateDeviceParameters(SelectionDevices, String.IsNullOrEmpty(SetPassword) ? "" : SetPassword, -1, -1))
            
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
            }
        }

        public void SetDeviceWorkMode()
        {
            if (SelectionDevices == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedDevicesFirst"));
                return;
            }
            DeviceWorkMode devWorkMode = new DeviceWorkMode();
            int iWorkMode = devWorkMode[SetWorkMode];

            if( !DevicesDataSource.UpdateDeviceParameters(SelectionDevices, null, iWorkMode, -1))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
            }
        }

        public void SetDeviceLanguage()
        {
            if (SelectionDevices == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedDevicesFirst"));
                return;
            }
            DeviceLanguage devLang = new DeviceLanguage();
            int iLanguage = devLang[SetLanguage];
            if(!DevicesDataSource.UpdateDeviceParameters(SelectionDevices, null, -1, iLanguage))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
            }
        }

        public void SetAllPara()
        {
            if (SelectionDevices == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("SelectedDevicesFirst"));
                return;
            }
            DeviceWorkMode devWorkMode = new DeviceWorkMode();
            int iWorkMode = devWorkMode[SetWorkMode];

            DeviceLanguage devLang = new DeviceLanguage();
            int iLanguage = devLang[SetLanguage];
            if(!DevicesDataSource.UpdateDeviceParameters(SelectionDevices, SetPassword, iWorkMode, iLanguage))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
            }

        }


    }
}