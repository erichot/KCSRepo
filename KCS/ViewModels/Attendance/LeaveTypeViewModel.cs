using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class LeaveTypeViewModel : KcsDocument
    {
        public static LeaveTypeViewModel Create()
        {

            return ViewModelSource.Create<LeaveTypeViewModel>();
        }
        public object LeaveTypeDataSet
        {
            get
            {
                IList<TaLeaveType> leaveTypesList = TaDataSource.GetLeaveTypeList();
                RecordCount = leaveTypesList.Count;
                return leaveTypesList;
            }
        }
        public virtual int RecordCount { get; set; }
        public TaLeaveType SelectedLeaveType { get; set; }
        public void Save(object objectLeaveType)
        {
            var leaveType = objectLeaveType as TaLeaveType;
            leaveType.CREATE_NAME = leaveType.BUILD_NAME = CredentialsSource.GetLoginSupervisorMsg();
            leaveType.CREATE_TIME = leaveType.BUILD_TIME = DateTime.Now;
            TaDataSource.AddLeaveType(leaveType);

            Messenger.Default.Send(new RebindMessage<LeaveTypeViewModel>(this));

        }
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<LeaveTypeViewModel>(this, RecordCount));
        }
        public void Delete(object objectLeaveType)
        {
            var leaveType = objectLeaveType as TaLeaveType;
            if (leaveType == null)
                return;
            TaDataSource.DeleteLeaveType(leaveType);

            Messenger.Default.Send(new RebindMessage<LeaveTypeViewModel>(this));
        }
    }
}