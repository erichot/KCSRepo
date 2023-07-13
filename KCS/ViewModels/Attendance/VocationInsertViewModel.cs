using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;
using System.Collections.Generic;
using KCS.Common.Utils;
using System.ComponentModel;

namespace KCS.ViewModels
{
    [POCOViewModel(ImplementIDataErrorInfo = true)]
    public class VocationInsertViewModel : KcsDocument
    {

        public virtual PerLeaveItem EditPerLeaveItem { get; set; }
        public virtual bool BtnConfirmEnable
        {
            get
            {
                if (EditPerLeaveItem.STATUS == "B" || EditPerLeaveItem.STATUS == "D")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public virtual bool BtnCancelEnable
        {
            get
            {
                if (EditPerLeaveItem.STATUS == "B")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public virtual bool ReadOnlyOrNot
        {
            get
            {
                if (EditPerLeaveItem.STATUS == "B" )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public static VocationInsertViewModel Create()
        {
            
            return ViewModelSource.Create(() => new VocationInsertViewModel());
        }
        public static VocationInsertViewModel Create(PerLeaveItem editPerLeaveItem)
        {

            return ViewModelSource.Create(() => new VocationInsertViewModel(editPerLeaveItem));
        }
        protected VocationInsertViewModel(PerLeaveItem editPerLeaveItem)
        {
           
            EditPerLeaveItem = new PerLeaveItem(editPerLeaveItem);
            
        }
        protected VocationInsertViewModel()
        {
            string nextLeaveItem = TaDataSource.GetLeavNum(DateTime.Now.Year, DateTime.Now.Month);
            EditPerLeaveItem = new PerLeaveItem(nextLeaveItem);

        }

        void RebindDataSource(int type)
        {
            Messenger.Default.Send(new RebindMessage<VocationInsertViewModel>(this,type));
            Messenger.Default.Send(new RebindMessage<JustificationLeaveApplicationViewModel>(this.GetParentViewModel<JustificationLeaveApplicationViewModel>()));
        }
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        public object LeaveItemDetailsList
        {
            get
            {
                IList<PerLeaveItemDetail> perLeaveItemList = TaDataSource.GetLeaveItemDetailsList(EditPerLeaveItem.NUM);
                return perLeaveItemList;
            }
        }
        public object EmployeeMsgList
        {
            get
            {
                IList<EmployeeMsg> employeesMsgList = EmployeesDataSource.GetEmployeesMsgList();
                return employeesMsgList;
            }

        }
        public object LeaveTypeDataSet
        {
            get
            {
                return TaDataSource.GetLeaveTypeList();
            }
        }
        public void DateChanged(object setValue)
        {
            try
            {
                DateTime UseDate = Convert.ToDateTime(setValue.ToString());

                EditPerLeaveItem.NUM = TaDataSource.GetLeavNum(UseDate.Year, UseDate.Month);
            }
            catch
                {
                }
        }
        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = EditPerLeaveItem as IDataErrorInfo;
            
            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }
        public void ConfirmLeave()
        {
            DateTime time1 = DateTime.Now;
            DateTime time2 = EditPerLeaveItem.LEAVE_DATE1;

            TimeSpan ts = time2.Subtract(time1);
            if (System.Math.Abs(ts.Days) >= 31)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ApproveOverDueHint") + "...");
                return;
            }
            EditPerLeaveItem.STATUS = "B";
            EditPerLeaveItem.CFM_NAME = CredentialsSource.GetLoginSupervisorMsg();
            EditPerLeaveItem.CFM_TIME = DateTime.Now;
            EditPerLeaveItem.CFM_TIME_Str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (TaDataSource.ConfirmLeaveItem(EditPerLeaveItem) > 0)
            {
                RebindDataSource(2);
    
            }
        }
        public void CancelLeave()
        {
            //假期超过31天 不可核准
            DateTime time1 = DateTime.Now;
            DateTime time2 = EditPerLeaveItem.LEAVE_DATE1;

            TimeSpan ts = time2.Subtract(time1);
            if (ts.Days >= 31)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("CancelOverDueHint") + "...");
                return;
            }
            EditPerLeaveItem.STATUS = "C";
            if(TaDataSource.CancelLeaveItem(EditPerLeaveItem.NUM) > 0 )
            {
                RebindDataSource(2);
            }
        }
        
        public void Save(object objectLeaveDetail)
        {
            if (objectLeaveDetail == null)
                return;
            var leave = objectLeaveDetail as PerLeaveItemDetail;
            TaDataSource.UpdateLeaveDetail(leave);
            RebindDataSource(1);
        }
        public void CreateLeavDetails()
        {
            
            if (!HasValidationErrors())
            {
                IList<PerShiftTableBase> perShiftTableBaseList = TaDataSource.CheckPerCheckExistOrNot(EditPerLeaveItem.EMP_CODE, EditPerLeaveItem.LEAVE_DATE1_STR, EditPerLeaveItem.LEAVE_DATE2_STR);
                if (perShiftTableBaseList.Count <= 0)
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("NoPersonalAnnualShiftMsg")+"...");
                    return;
                }
                //
                int SnCount = 1;
                if (TaDataSource.CheckLeaveItemDetails(EditPerLeaveItem.NUM) > 0)
                {
                    if (MessageService.ShowMessage(LanguageResource.GetDisplayString("ResetLeaveDetailsHints"), LanguageResource.GetDisplayString("LeaveManagementText"), MessageButton.YesNo) != MessageResult.Yes)
                        return;
                    TaDataSource.DeleteLeaveItemDetails(EditPerLeaveItem.NUM);
                }
                EditPerLeaveItem.SUM_TIME = 0;
                foreach (PerShiftTableBase perShift in perShiftTableBaseList)
                {
                   
                    if (perShift.LIST_GRP == 0)
                    {//非假期,insert into PER_LEAVE_D
                        PerLeaveItemDetail perLeaveItemDetail = new PerLeaveItemDetail();
                        perLeaveItemDetail.LEAVE_DATE = perShift.CHK_DATE;
                        perLeaveItemDetail.CREATE_NAME = perLeaveItemDetail.BUILD_NAME = CredentialsSource.GetLoginSupervisorMsg();
                        perLeaveItemDetail.CREATE_TIME = perLeaveItemDetail.BUILD_TIME = DateTime.Now;
                        perLeaveItemDetail.NUM = EditPerLeaveItem.NUM;
                        perLeaveItemDetail.SN = SnCount++;
                         perLeaveItemDetail.TURN_HOUR = perShift.TURN_TIME / 60;

                         DateTime dtStart = Convert.ToDateTime(perShift.WORK_TIME_START);
                         DateTime dtEnd = Convert.ToDateTime(perShift.WORK_TIME_END);
                         DateTime dtLeaveStart = Convert.ToDateTime(EditPerLeaveItem.LEAVE_TIME1);
                         DateTime dtLeaveEnd = Convert.ToDateTime(EditPerLeaveItem.LEAVE_TIME2);

                         string strCheckDate = perShift.CHK_DATE.ToShortDateString();
                         string leaveDateStart = EditPerLeaveItem.LEAVE_DATE1.ToShortDateString();
                         string leaveDateEnd = EditPerLeaveItem.LEAVE_DATE2.ToShortDateString();

                         if (strCheckDate == leaveDateStart && strCheckDate == leaveDateEnd)
                         {//请假只有一天
                             if (dtLeaveStart >= dtLeaveEnd)
                                 continue;
                             if (dtLeaveStart >= dtEnd || dtLeaveEnd <= dtLeaveStart)
                             {
                                 continue;
                             }

                             DateTime dtCalStart = (dtLeaveStart >= dtStart) ? dtLeaveStart : dtStart;
                             DateTime dtCalEnd = (dtLeaveEnd >= dtEnd) ? dtEnd : dtLeaveEnd;
                             if (dtCalStart >= dtCalEnd)
                                 continue;
                             if (!string.IsNullOrEmpty(perShift.RELAX_TIME1) && !string.IsNullOrEmpty(perShift.RELAX_TIME2))
                             {
                                 DateTime dtRelaxStart = Convert.ToDateTime(perShift.RELAX_TIME1);
                                 DateTime dtRelaxEnd = Convert.ToDateTime(perShift.RELAX_TIME2);
                                 if (dtCalStart < dtRelaxStart && dtCalEnd > dtRelaxEnd)
                                 {
                                     TimeSpan ts = dtCalEnd - dtCalStart;
                                     ts -= (dtRelaxEnd - dtRelaxStart);
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;
                                 }
                                 else if (dtCalStart >= dtRelaxStart && dtCalEnd <= dtRelaxEnd)
                                 {
                                     continue;
                                 }
                                 else if (dtCalStart >= dtRelaxStart && dtCalEnd > dtRelaxEnd && dtCalStart <= dtRelaxEnd)
                                 {
                                     TimeSpan ts = dtCalEnd - dtRelaxEnd;
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;
                                 }
                                 else if (dtCalStart < dtRelaxStart && dtCalEnd <= dtRelaxEnd && dtCalEnd >= dtRelaxStart)
                                 {
                                     TimeSpan ts = dtRelaxStart - dtCalStart;
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;
                                 }
                                 else
                                 {
                                     TimeSpan ts = dtCalEnd - dtCalStart;
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;
                                 }
                                
                             }
                             else
                             {
                                 TimeSpan ts = dtCalEnd - dtCalStart;
                                 perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;
                             }
                             
                         }
                         else if (strCheckDate == leaveDateStart)
                         {//开始一天
                             if (dtLeaveStart >= dtEnd )
                             {
                                 continue;
                             }
                             DateTime dtCalStart = (dtLeaveStart >= dtStart) ? dtLeaveStart : dtStart;
                             if (!string.IsNullOrEmpty(perShift.RELAX_TIME1) && !string.IsNullOrEmpty(perShift.RELAX_TIME2))
                             {
                                 DateTime dtRelaxStart = Convert.ToDateTime(perShift.RELAX_TIME1);
                                 DateTime dtRelaxEnd = Convert.ToDateTime(perShift.RELAX_TIME2);
                                 if (dtCalStart <= dtRelaxStart )
                                 {
                                     TimeSpan ts = dtEnd - dtCalStart;
                                     ts -= (dtRelaxEnd - dtRelaxStart);
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;

                                 }
                                 else if (dtCalStart > dtRelaxStart && dtCalStart <= dtRelaxEnd)
                                 {
                                     TimeSpan ts = dtEnd - dtRelaxEnd;
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;
                                 }
                                 else
                                 {
                                     TimeSpan ts = dtEnd - dtCalStart;
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;
                                 }
                             }
                             else
                             {
                                 TimeSpan ts = dtEnd - dtCalStart;
                                 perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;
                                
                             }
                         }
                         else if (strCheckDate == leaveDateEnd)
                         {//结束一天
                             if (dtLeaveEnd <= dtLeaveStart )
                             {
                                 continue;
                             }
                             DateTime dtCalEnd = (dtLeaveEnd >= dtEnd) ? dtEnd : dtLeaveEnd;
                             if (!string.IsNullOrEmpty(perShift.RELAX_TIME1) && !string.IsNullOrEmpty(perShift.RELAX_TIME2))
                             {
                                 DateTime dtRelaxStart = Convert.ToDateTime(perShift.RELAX_TIME1);
                                 DateTime dtRelaxEnd = Convert.ToDateTime(perShift.RELAX_TIME2);
                                 if (dtCalEnd >= dtRelaxEnd)
                                 {
                                     TimeSpan ts = dtCalEnd - dtStart;
                                     ts -= (dtRelaxEnd - dtRelaxStart);
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;

                                 }
                                 else if (dtCalEnd < dtRelaxEnd && dtCalEnd >= dtRelaxStart)
                                 {
                                     TimeSpan ts = dtRelaxStart - dtStart;
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0;
                                 }
                                 else
                                 {
                                     TimeSpan ts = (dtCalEnd - dtStart);
                                     perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0; 
                                 }
                             }
                             else
                             {
                                 TimeSpan ts = (dtCalEnd - dtStart);
                                 perLeaveItemDetail.SUM_TIME = ts.Hours + (float)(ts.Minutes) / 60.0; 
                             }

                             
                         }
                         else
                         {//中间的天数
                              perLeaveItemDetail.SUM_TIME = perShift.TURN_TIME / 60.0; //请假时间等于应工作时间
                         }


                         //perLeaveItemDetail.SUM_TIME =
                        EditPerLeaveItem.SUM_TIME += perLeaveItemDetail.SUM_TIME;
                        //perLeaveItemDetail.SUM_TIME = 0;
                        TaDataSource.InsertLeaveItemDetials(perLeaveItemDetail);
                       
                    }
                }
                //Insert into PER_LEAVE
                EditPerLeaveItem.CREATE_NAME = EditPerLeaveItem.BUILD_NAME = CredentialsSource.GetLoginSupervisorMsg();
                EditPerLeaveItem.CREATE_TIME = EditPerLeaveItem.BUILD_TIME = DateTime.Now;
                if( EditPerLeaveItem.STATUS == "D")
                    EditPerLeaveItem.STATUS = "A";
                if (EditPerLeaveItem.SUM_TIME != 0)
                {//有请假时间才有效
                    try
                    {
                        TaDataSource.InsertLeaveItem(EditPerLeaveItem);
                    }
                    catch
                    {
                        TaDataSource.DeleteLeaveItemDetails(EditPerLeaveItem.NUM);
                    }
                }
                RebindDataSource(1);
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NewEmployeeFailedInput"));
            }
        }
        
        
    }
}