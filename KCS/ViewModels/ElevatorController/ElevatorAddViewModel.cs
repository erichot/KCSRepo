using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using KCS.ViewModels;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ElevatorAddViewModel : KcsDocument
    {
        public virtual Elevator NewElevator { get; set; }

        public static ElevatorAddViewModel Create()
        {

            return ViewModelSource.Create(() => new ElevatorAddViewModel());
        }
        protected ElevatorAddViewModel()
        {
            NewElevator = new Elevator();
        }

        public object DeviceInfoDataSet
        {
            get
            {
                return DevicesDataSource.GetDeviceBaseList();
            }
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<ElevatorControlViewModel>(this.GetParentViewModel<ElevatorControlViewModel>()));
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        private bool SavElevator()
        {
            if (NewElevator.SlaveSID == 0)
                return false;
            bool ret = ElevatorControlDataSource.ElevatorControllerExitOrNot(NewElevator);
            if (ret)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ExitedElevatorController"));
                return false;
            }
           if( ElevatorControlDataSource.NewElevator(NewElevator) )
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NewElevatorOk"));
                RebindDataSource();
                return true;
            }
            MessageService.ShowMessage(LanguageResource.GetDisplayString("NewElevatorFailed"));
            return false;
        }
        public void Save()
        {

            SavElevator();
        }

        public void SaveAndClose()
        {

            if (SavElevator())
            {
                Close();
            }

        }
        public void SaveAndNew()
        {
            if (SavElevator())
            {
                NewElevator = new Elevator();
            }

        }
    }
    
}