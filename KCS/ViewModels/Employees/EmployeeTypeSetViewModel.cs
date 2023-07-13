using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using System.ComponentModel;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class EmployeeTypeSetViewModel : KcsDocument
    {
        public static EmployeeTypeSetViewModel Create()
        {

            return ViewModelSource.Create(() => new EmployeeTypeSetViewModel());
        }
        public virtual int RecordCount { get; set; }
        public object EmployeesTypeDataSet
        {
            get
            {
                IList<EmployeesType> empTypeList = EmployeesTypeDataSource.GetEmployeesTypeList();
                RecordCount = empTypeList.Count;
                return empTypeList;
            }

        }
        public virtual EmployeesType SelectedEmployeesType { get; set; }
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<EmployeeTypeSetViewModel>(this, RecordCount));
        }
        protected virtual bool HasValidationErrors()
        {
            IDataErrorInfo dataErrorInfo = SelectedEmployeesType as IDataErrorInfo;

            return dataErrorInfo != null && IDataErrorInfoHelper.HasErrors(dataErrorInfo);
        }
        public void SaveAndNew()
        {
            Save();
            New();
        }
        public void Save()
        {
            if (!HasValidationErrors())
            {
                if (EmployeesTypeDataSource.UpdateEmployeesType(SelectedEmployeesType))
                    RebindDataSource();
            }
        }
        public void ResetChanges()
        {
            RebindDataSource();
        }
        public void New()
        {
            SelectedEmployeesType = new EmployeesType();
        }
        public void SaveAndClose()
        {
            Save();
            Close();
        }
        private void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<EmployeeTypeSetViewModel>(this));
        }
        public void Delete(object employeeType)
        {
            var selEmployeeType = employeeType as EmployeesType;
            if (selEmployeeType == null)
                return;
            if(EmployeesTypeDataSource.DeleteEmployeesType(selEmployeeType))
            RebindDataSource();
        }
        
    }
}