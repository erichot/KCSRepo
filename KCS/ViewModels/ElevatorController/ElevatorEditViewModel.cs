using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using KCS.Common.Utils;
using KCS.Models;
using KCS.ViewModels;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ElevatorEditViewModel : KcsDocument
    {
        public virtual Elevator EditElevator { get; set; }

        private Elevator backupEditElevator;
        public static ElevatorEditViewModel Create()
        {

            return ViewModelSource.Create(() => new ElevatorEditViewModel());
        }
        public static ElevatorEditViewModel Create(Elevator elevator)
        {

            return ViewModelSource.Create(() => new ElevatorEditViewModel(elevator));
        }
        protected ElevatorEditViewModel()
        {
            EditElevator = new Elevator();
        }
        protected ElevatorEditViewModel(Elevator elevator)
        {
            backupEditElevator = new Elevator(elevator);
            EditElevator = new Elevator(elevator);
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
            bool ret = false;

            if (backupEditElevator.SlaveSID == EditElevator.SlaveSID && backupEditElevator.EleavatorName == EditElevator.EleavatorName && backupEditElevator.EleavatorDes == EditElevator.EleavatorDes)
                return false;
            if (backupEditElevator.SlaveSID != EditElevator.SlaveSID)
             ret = ElevatorControlDataSource.ElevatorControllerExitOrNot(EditElevator);
            if (ret)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ExitedElevatorController"));
                return false;
            }
            if (ElevatorControlDataSource.UpdateElevator(EditElevator))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ModifyElevatorOk"));
                RebindDataSource();
                return true;
            }
            MessageService.ShowMessage(LanguageResource.GetDisplayString("ModifyElevatorFailed"));
            return false;
        }
        public void Save()
        {

            SavElevator();
        }

    }
}
