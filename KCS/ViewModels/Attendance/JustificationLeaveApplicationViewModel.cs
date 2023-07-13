using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class JustificationLeaveApplicationViewModel : KcsDocument
    {
        public static JustificationLeaveApplicationViewModel Create()
        {
            return ViewModelSource.Create(() => new JustificationLeaveApplicationViewModel());
        }//

        public JustificationLeaveApplicationViewModel()
        {
            SelectedPerLeaveItem = new PerLeaveItem();
        }
        public virtual PerLeaveItem SelectedPerLeaveItem { 
            get; 
            set; }

        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }

        public void NewVocation()
        {
            var vocationNewViewModel = VocationInsertViewModel.Create();
            vocationNewViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("VocationInsert", vocationNewViewModel);
           
            document.Show();
        }
        public void Edit(object perLeaveItemObject)
        {
            try
            {
                if (perLeaveItemObject == null)
                    return;
                var perLeaveItem = perLeaveItemObject as PerLeaveItem;
                var vocationNewViewModel = VocationInsertViewModel.Create(perLeaveItem);
                vocationNewViewModel.SetParentViewModel(this);
                var document = DocumentManagerService.CreateDocument("VocationInsert", vocationNewViewModel);

                document.Show();
            }
            catch
            {
            }
        }
        public void Delete(object perLeaveItemObject)
        {
            if (perLeaveItemObject == null)
                return;
            var perLeaveItem = perLeaveItemObject as PerLeaveItem;
            if (TaDataSource.DeleteLeaveItem(perLeaveItem.NUM))
            {
                RebindDataSource();
            }
        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<JustificationLeaveApplicationViewModel>(this));
        }
    }
}