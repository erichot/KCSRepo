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
    public class CreatePersonalShiftTableViewModel : KcsDocument
    {
        public static CreatePersonalShiftTableViewModel Create()
        {
            return ViewModelSource.Create(() => new CreatePersonalShiftTableViewModel());
        }
        IList<EmployeeBrief> employeesBriefList = null;
        public virtual string SelectedShiftTable { get; set; }
        public virtual EmployeeBrief SelectedEmployee { get; set; }
        public virtual IEnumerable<EmployeeBrief> Selection { get; set; }

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }
        protected IDialogService DialogService
        {
            get { return this.GetService<IDialogService>(); }
        }

        public object TrunWorkBaseDataSet
        {
            get
            {
                return WorkShiftDataSource.GetTrunWorkBaseList();
            }
        }
        public object EmployeesBriefDataSet
        {
            get
            {
                employeesBriefList = EmployeesDataSource.GetEmployeesBriefList();
                return employeesBriefList;
            }

        }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<CreatePersonalShiftTableViewModel>(this));
        }
        public void CreatePersonalAnnualShiftTable(IEnumerable<EmployeeBrief> employeesObject)
        {
            //var EmployeesBriefList = employeesObject as IList<EmployeeBrief>;
            if (employeesObject == null )
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
           // var SelectEmployees = Selection as IList<EmployeeBrief>;
            //if (SelectEmployees == null || SelectEmployees.Count <= 0)
            //{
            //    SelectEmployees = employeesBriefList;
            //}
            CreatCalendarViewModel createCalendarViewModel = CreatCalendarViewModel.Create();
            if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("CreateAnnualShiftTableText"), "CreatCalendar", createCalendarViewModel))
            {
                Messenger.Default.Send(new WaitingMessage<CreatePersonalShiftTableViewModel>(this, true));
                bool bCreateResult = true;
                int count = 0;
                foreach (EmployeeBrief employee in employeesObject)
                {
                    if( !string.IsNullOrEmpty(employee.ShiftCategory))
                    {
                        if (TaDataSource.CreatePersonalShiftTable(createCalendarViewModel.SelectYear, employee.UserID, employee.CardID, employee.ShiftCategory) <= 0)
                        {
                            bCreateResult = false;
                            break;
                        }
                    }
                    count++;
                }
                
                 Messenger.Default.Send(new WaitingMessage<CreatePersonalShiftTableViewModel>(this, false));
                 if (count == 0)
                 {
                     MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                     return;
                 }
                 if (bCreateResult)
                 {
                     MessageService.ShowMessage(LanguageResource.GetDisplayString("CreatePersonalAnnualShiftTabledOkText"));
                 }
                 else
                 {
                     MessageService.ShowMessage(LanguageResource.GetDisplayString("CreatePersonalAnnualShiftTabledFailedText"));
                 }
            }
            
           
        }
        public void SaveShiftTableSetting()
        {
            var EmployeesList = EmployeesBriefDataSet as IList<EmployeeBrief>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                //MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (Selection == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            Messenger.Default.Send(new WaitingMessage<CreatePersonalShiftTableViewModel>(this, true));
            foreach (EmployeeBrief employee in Selection)
            {
                if (EmployeesDataSource.UpdateEmployeeShiftTable(employee.UserSID, SelectedShiftTable))
                {
                    employee.ShiftCategory = SelectedShiftTable;
                }
            }
            Messenger.Default.Send(new WaitingMessage<CreatePersonalShiftTableViewModel>(this, false));
            RebindDataSource();
        }
        public void Save(object obj)
        {
            string shiftCatogery = ((DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)obj).Value.ToString();
            if (SelectedEmployee == null)
            {
                return;
            }
            if (EmployeesDataSource.UpdateEmployeeShiftTable(SelectedEmployee.UserSID, shiftCatogery))
            {
                SelectedEmployee.ShiftCategory = shiftCatogery;
            }
            RebindDataSource();
            
        }
    }
}