using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using KCS.Common.Utils;
using System.IO;
using KCS.Common.DAL.Constants;
using KCS.Views;

namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class ElevatorControlViewModel : KcsDocument
    {
        private ElevatorController _ElevatorController;

        public static ElevatorControlViewModel Create()
        {
            return ViewModelSource.Create(() => new ElevatorControlViewModel());
        }
        protected ElevatorControlViewModel()
        {
        }

        public object ElevatorControllerDataSet
        {
            get
            {
                IList<ElevatorController> superList = ElevatorControlDataSource.GetElevatorControllerList();
                return superList;
            }

        }
        public virtual ElevatorController SelectedElevator
        {
            get
            {
                return _ElevatorController;
            }
            set
            {
                _ElevatorController = value;


            }
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }

        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<ElevatorControlViewModel>(this));
        }
        public void DeleteElevator(object elevatorObject)
        {
            var ElevatorList = ElevatorControllerDataSet as IList<ElevatorController>;
            if (ElevatorList == null || ElevatorList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (elevatorObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var elevator = elevatorObject as ElevatorController;
             if (ElevatorControlDataSource.DeleteElevator(elevator))
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteElevatorOk"));
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteElevatorFailed"));
            }
           
        }
        public void ShowAuthority(object elevatorObject)
        {
            var ElevatorList = ElevatorControllerDataSet as IList<ElevatorController>;
            if (ElevatorList == null || ElevatorList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (elevatorObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var elevator = elevatorObject as ElevatorController;
            

            var elevatorAuthorityShowViewModel = ShowElevatorAuthorityViewModel.Create(elevator.SlaveSID);
            elevatorAuthorityShowViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("ShowElevatorAuthority", elevatorAuthorityShowViewModel);
            document.Show();
        }
        public void Edit(object elevatorObject)
        {
            var ElevatorList = ElevatorControllerDataSet as IList<ElevatorController>;
            if (ElevatorList == null || ElevatorList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (elevatorObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var elevator = elevatorObject as ElevatorController;
            Elevator EditedElevator = new Elevator();
            EditedElevator.SlaveSID = elevator.SlaveSID;
            EditedElevator.EleavatorID = elevator.EleavatorID;
            EditedElevator.EleavatorName = elevator.EleavatorName;
            EditedElevator.EleavatorDes = elevator.EleavatorDes;

            var elevatorEditViewModel = ElevatorEditViewModel.Create(EditedElevator);
            elevatorEditViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("ElevatorEdit", elevatorEditViewModel);
            document.Show();
        }
        public void ElevatorAuthority()
        {
            var document = DocumentManagerService.CreateDocument("ElevatorAuthority", ElevatorAuthorityViewModel.Create());
            document.Show();
        }
        public void NewElevator()
        {
            var addElevatorViewModel = ElevatorAddViewModel.Create();
            addElevatorViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("ElevatorAdd", addElevatorViewModel);
            document.Show();
        }

    }
    
}