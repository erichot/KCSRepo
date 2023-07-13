using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using KCS.Common.Utils;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class DepartmentSetViewModel
    {
        private enum OperationMode
        {
            Unkonwn,
            Edit,
            New
        } 
        private Department _Department;
        OperationMode operationMode = OperationMode.Unkonwn;
        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
       


        public static DepartmentSetViewModel Create()
        {
            
            return ViewModelSource.Create<DepartmentSetViewModel>();
        }
        public virtual Department SelectedDepartmentCopy
        {
            get
            {
                
                return _Department;
            }

            set
            {
                _Department = value;
            }
        }
        public void InitObject()
        {
            _Department = new Department();
        }
        public virtual Department SelectedDepartment {get;set;}
            
        public virtual int RecordCount { get; set; }
        public object DepartmentDataSet
        {
            get
            {
                IList<Department> superList = DepartmentSource.GetDepartmentList();
                RecordCount = superList.Count;
                return superList;
            }

        }
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<DepartmentSetViewModel>(this,RecordCount));
        }
        public void RefreshDataSource()
        {
            Messenger.Default.Send(new RebindMessage<DepartmentSetViewModel>(this));
        }
        public void Save()
        {
            bool bOperateRet =  false;
            if (operationMode == OperationMode.Unkonwn)
                return;
            if (operationMode == OperationMode.Edit)
            {//Edit
                bOperateRet = DepartmentSource.UpdateDepartment(SelectedDepartmentCopy);
            }
            else
            {
                bOperateRet = DepartmentSource.NewDepartment(SelectedDepartmentCopy);
            }
            if ( bOperateRet)
            RefreshDataSource();
        }
        public void NewDepartment()
        {
            SelectedDepartmentCopy = new Department();
            operationMode = OperationMode.New;
            Messenger.Default.Send(new BindDataMessage<DepartmentSetViewModel>(this));
        }
        public void Edit(object departmentObject)
        {
            SelectedDepartmentCopy = new Department(departmentObject as Department);
            operationMode = OperationMode.Edit;
            Messenger.Default.Send(new BindDataMessage<DepartmentSetViewModel>(this));
           
        }
        public void Delete(object  departmentObject)
        {
            if (departmentObject == null)
                return;
            Department department = new Department(departmentObject as Department);
           // var department = departmentObject as Department;
           
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsDeleteItem"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            try
            {

                if (!DepartmentSource.DeleteDepartment(department))
                {
                    MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteItemFailed"));
                }
                else
                {
                    RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                MessageService.ShowMessage(ex.Message);
            }
        }
    }
}