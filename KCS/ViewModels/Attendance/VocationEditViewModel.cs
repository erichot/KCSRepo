using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using KCS.Models;
using DevExpress.Mvvm.POCO;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class VocationEditViewModel : KcsDocument
    {
        private Vocation backupEditVocationSetting;
        public virtual Vocation EditVocationSetting { get; set; }

        public static VocationEditViewModel Create(Vocation vocation)
        {

            return ViewModelSource.Create(() => new VocationEditViewModel(vocation));
        }
        protected VocationEditViewModel(Vocation vocation)
        {
            backupEditVocationSetting = new Vocation(vocation);
            EditVocationSetting = new Vocation(vocation);
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }

        public object LeaveTypeDataSet
        {
            get
            {
                return TaDataSource.GetLeaveTypeList();
            }
        }
        public virtual string EmployeeMsg {
            get
            {
                return EditVocationSetting.UserId + ":" + EditVocationSetting.UserName;
            }
        }
        public void Save()
        {
            if (backupEditVocationSetting != EditVocationSetting)
            {
                int iRet = TaDataSource.UpdateVocationSetting(EditVocationSetting);

                if (iRet > 0)
                {
                    Messenger.Default.Send(new RebindMessage<JustificationLeaveApplicationViewModel>(this.GetParentViewModel<JustificationLeaveApplicationViewModel>()));
                    Close();
                }
                else
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("InsertErrorMsg") + " " + LanguageResource.GetDisplayString("ErrorCodeText") + ":" + iRet.ToString());
                }
            
            }
            
        }
    }
}