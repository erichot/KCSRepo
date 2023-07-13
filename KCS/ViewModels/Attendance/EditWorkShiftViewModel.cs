using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.ComponentModel;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
     [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class EditWorkShiftViewModel : KcsDocument
    {
        public virtual WorkShift EditWorkShift { get; set; }
        public bool ShiftCodeReadOnly { get; set; }

        public static EditWorkShiftViewModel Create()
        {
            
            return ViewModelSource.Create(() => new EditWorkShiftViewModel());
        }
        public static EditWorkShiftViewModel Create(WorkShift workshift)
        {
           
            return ViewModelSource.Create(() => new EditWorkShiftViewModel(workshift));
        }
        protected EditWorkShiftViewModel()
        {
            ShiftCodeReadOnly = false;
            EditWorkShift = new WorkShift();
        }
        protected EditWorkShiftViewModel(WorkShift workshift)
        {
            ShiftCodeReadOnly = true;
            EditWorkShift = new WorkShift(workshift);
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
       

        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<WorkShiftManagementViewModel>(this.GetParentViewModel<WorkShiftManagementViewModel>()));
        }
        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = EditWorkShift as IDataErrorInfo;

            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }
        public void Save()
        {
            //UpdateItemFailed
            //int iRet = WorkShiftDataSource.UpdateWorkShift(EditWorkShift, !ShiftCodeReadOnly);
            //if (iRet > 0)
            //{
            //    RebindDataSource();
            //    Close();
            //}
            //else
            //{
            //    MessageService.ShowMessage(LanguageResource.GetDisplayString("UpdateItemFailed"));
            //}
        }
    }
}