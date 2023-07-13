using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using System.Collections.Generic;
using KCS.Models;
using KCS.Common.Utils;
using System.IO;
using KCS.Common.DAL.Constants;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class EmployeeViewModel
    {
        private Employees _Employee;

        public static EmployeeViewModel Create()
        {

            return ViewModelSource.Create<EmployeeViewModel>();
        }

        protected IMessageBoxService MessageService
        {
            get { return this.GetRequiredService<IMessageBoxService>(); }
        }

        protected IDialogService DialogService
        {
            get { return this.GetService<IDialogService>(); }
        }
        protected INotificationService INotificationService
        {
            // using the GetService<> extension method for obtaining service instance
            get { return this.GetService<INotificationService>(); }
        }
        public virtual INotification Notification
        {
            get;
            set;
        }
        protected virtual void OnNotificationChanged()
        {
            this.RaiseCanExecuteChanged(x => x.HideNotification());
        }

        public void ShowNotification(string strTip)
        {
            // using the INotificationService.CreatePredefinedNotification method
            Notification = INotificationService.CreatePredefinedNotification(strTip, "", "");

            // using the INotification.ShowAsync method
            Notification.ShowAsync();
        }
        public void HideNotification()
        {
            // using the INotification.Hide method
            Notification.Hide();

        }
        public bool CanHideNotification()
        {
            return Notification != null;
        }

        [ServiceProperty(SearchMode = ServiceSearchMode.PreferParents)]
        protected virtual IDocumentManagerService DocumentManagerService { get { return null; } }

        public virtual Employees SelectedEmployee
        {
            get
            {
                return _Employee;
            }
            set
            {
                _Employee = value;

               
            }
        }
        public virtual int RecordCount { get; set; }
        public object EmployeesDataSet
        {
            get
            {
                IList<Employees> employeesList = EmployeesDataSource.GetEmployeesList();
                RecordCount = employeesList.Count;
                return employeesList;
            }

        }
        protected ISaveFileDialogService SaveFileDialogService { get { return this.GetService<ISaveFileDialogService>(); } }
        protected IOpenFileDialogService OpenFileDialogService { get { return this.GetService<IOpenFileDialogService>(); } }
        public virtual IEnumerable<Employees> Selection { get; set; }
        void RebindDataSource()
        {
            Messenger.Default.Send(new RebindMessage<EmployeeViewModel>(this));
        }
        protected void OnRecordCountChanged()
        {
            Messenger.Default.Send(new UpdateCountMessage<EmployeeViewModel>(this, RecordCount));
        }
        
        public void New()
        {
            var emplyeeNewViewModel = NewEmployeeViewModel.Create();
            emplyeeNewViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("NewEmployee", emplyeeNewViewModel);
            document.Show();
           // DialogService.ShowDialog(MessageButton.OK, "New Employees", "NewEmployee", NewEmployeeViewModel.Create());
        }
        public void ForceDelete(IEnumerable<Employees> employeesObject)
        {
            var EmployeesList  = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsForceDeleteItems"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            foreach (Employees employee in employeesObject)
                EmployeesDataSource.ForceDeleteEmployee(employee.UserSID, employee.CardID);
            RebindDataSource();
        }
        public void Delete(object employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsDeleteItems"), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var employee = employeesObject as Employees;
            int iRet = EmployeesDataSource.DeleteEmployee(employee.UserSID);
            if (iRet == 0)
            {
                ShowNotification(LanguageResource.GetDisplayString("DeleteEmployeeOK"));
                RebindDataSource();
            }
            else if (iRet == -1)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteEmployeeFailed")); 
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteEmployeeFailedTip"));
            }
        }
        public void Edit(object employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var emplyeeEditViewModel = EditEmployeeViewModel.Create(employeesObject as Employees);
            emplyeeEditViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("EditEmployee", emplyeeEditViewModel);
            document.Show();
        }
        public void DeleteFinger1(object employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(string.Format("{0} 1?", LanguageResource.GetDisplayString("IsDeleteFiner")), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var employee = employeesObject as Employees;
            if (EmployeesDataSource.DeleteEmployeeFinger(employee.CardID.PadLeft(10, '0'), 1))
            {
                ShowNotification(LanguageResource.GetDisplayString("DeleteEmployeeFingerOK"));
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteEmployeeFingerFailed")); 
            }
        }
        public void DeleteFinger2(object employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(string.Format("{0} 2?", LanguageResource.GetDisplayString("IsDeleteFiner")), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var employee = employeesObject as Employees;
            if (EmployeesDataSource.DeleteEmployeeFinger(employee.CardID.PadLeft(10, '0'), 2))
            {
                ShowNotification(LanguageResource.GetDisplayString("DeleteEmployeeFingerOK"));
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteEmployeeFingerFailed"));
            }
        }
        public void DeleteFinger12(object employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(string.Format("{0} 1,2?", LanguageResource.GetDisplayString("IsDeleteFiner")), LanguageResource.GetDisplayString("DeleteConfirm"), MessageButton.YesNo) != MessageResult.Yes)
                return;
            var employee = employeesObject as Employees;
            if (EmployeesDataSource.DeleteEmployeeFinger12(employee.CardID.PadLeft(10, '0')))
            {
                ShowNotification(LanguageResource.GetDisplayString("DeleteEmployeeFingerOK"));
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DeleteEmployeeFingerFailed"));
            }
        }
        public void EmployeesAuthoritySet(IEnumerable<Employees> employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
             var document = DocumentManagerService.CreateDocument("EmployeesAuthority", EmployeesAuthorityViewModel.Create(employeesObject));
            document.Show();
        }
        public void EnableEmployees(IEnumerable<Employees> employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsEnableItems"), "", MessageButton.YesNo) != MessageResult.Yes)
                return;
            if (EmployeesDataSource.EnableEmployees(employeesObject))
            {
                ShowNotification(LanguageResource.GetDisplayString("EnableAllEmployeeOK"));
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("EnableAllEmployeeFailed"));
            }
            //foreach (Employees employee in employeesObject)
            //   EmployeesDataSource.ForceDeleteEmployee(employee.UserSID, employee.CardID);
        }
        public void DisableEmployees(IEnumerable<Employees> employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("IsDisableItems"), "", MessageButton.YesNo) != MessageResult.Yes)
                return;
            if (EmployeesDataSource.DisableEmployees(employeesObject))
            {
                ShowNotification(LanguageResource.GetDisplayString("DisableAllEmployeeOK"));
                RebindDataSource();
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("DisableAllEmployeeFailed"));
            }
            //foreach (Employees employee in employeesObject)
             //   EmployeesDataSource.ForceDeleteEmployee(employee.UserSID, employee.CardID);
        }
        
        public void ReSyncAll()
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
           
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("ReSyncAllEmployees"), "", MessageButton.YesNo) != MessageResult.Yes)
                return;
            if (EmployeesDataSource.ReSyncAll())
            {
                ShowNotification(LanguageResource.GetDisplayString("ReSyncAllEmployeeOK"));
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ReSyncAllEmployeeFailed"));
            }
        }
        public void ReSyncSelect(object employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var employee = employeesObject as Employees;
            if (employee.SyncOrNot)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ForbidSyncSelectedEmployee"));
                return;
            }
            if (MessageService.ShowMessage(LanguageResource.GetDisplayString("ReSyncSelectedEmployee"), "", MessageButton.YesNo) != MessageResult.Yes)
                return;
            if (EmployeesDataSource.ReSyncSelectedEmployee(employee))
            {
                ShowNotification(LanguageResource.GetDisplayString("ReSyncSelectedEmployeeOK"));
            }
            else
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ReSyncSelectedEmployeeFailed"));
            }
        }
        public void ChangeCardId(object employeesObject)
        {
            var employee = employeesObject as Employees;
            ChangeCardIDViewModel changeCardIdViewModel = ChangeCardIDViewModel.Create(employee);
            if (MessageResult.OK == DialogService.ShowDialog(MessageButton.OKCancel, LanguageResource.GetDisplayString("ToolBarChangeCardId"), "ChangeCardID", changeCardIdViewModel))
            {
                if (!string.IsNullOrEmpty(changeCardIdViewModel.NewCardId))
                {//卡号不为空
                    try{
                        DataBaseAccessErrorCode iRet = EmployeesDataSource.ChangeCardIdOfUser(employee.CardID, changeCardIdViewModel.NewCardId.PadLeft(10, '0'));
                        if (iRet == DataBaseAccessErrorCode.ExisitedCardId)
                        {
                            MessageService.ShowMessage(LanguageResource.GetDisplayString("ExisitedCardId"));
                        }
                        else
                        {
                            employee.CardID = changeCardIdViewModel.NewCardId.PadLeft(10, '0');
                            MessageService.ShowMessage(LanguageResource.GetDisplayString("ChageCardIdOk"));
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageService.ShowMessage(LanguageResource.GetDisplayString("ChageCardIdFailed") + "\r\n" + ex.Message);
                    }
                }
            }
        }
        public void SyncSetting(object employeesObject)
        {
            var EmployeesList = EmployeesDataSet as IList<Employees>;
            if (EmployeesList == null || EmployeesList.Count <= 0)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoExistingDatas"));
                return;
            }
            if (employeesObject == null)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("NoSelectedDatas"));
                return;
            }
            var employee = employeesObject as Employees;
            if (employee.SyncOrNot)
            {
                MessageService.ShowMessage(LanguageResource.GetDisplayString("ForbidSyncSelectedEmployee"));
                return;
            }
            var document = DocumentManagerService.CreateDocument("SyncSetting", SyncSettingViewModel.Create(employee));
            document.Show();
        }
        public void ExportEmployees()
        {
            var document = DocumentManagerService.CreateDocument("ExportEmployees", ExportEmployeesViewModel.Create());
            document.Show();
            //SaveFileDialogService.DefaultExt = "xls";
            //SaveFileDialogService.DefaultFileName = "EmployeesList.xlsx";
            //SaveFileDialogService.Filter = "Excel files (*.xlsx)|*.xlsx|Text Files (.txt)|*.txt|All files (*.*)|*.*";
            //SaveFileDialogService.FilterIndex = 1;
            //bool DialogResult = SaveFileDialogService.ShowDialog();

            //string ResultFileName;
            //if (!DialogResult)
            //{
            //    ResultFileName = string.Empty;
            //}
            //else
            //{
            //    //ResultFileName = SaveFileDialogService.File.GetFullName();
            //    //Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            //    //excel.Workbooks.Add(true);
            //    //Microsoft.Office.Interop.Excel.Worksheet wSheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
            //    //Microsoft.Office.Interop.Excel.Range range;
            //    //try
            //    //{
            //    //}
            //    //catch
            //    //{
            //    //}
            //    //finally
            //    //{
            //    //}
            //    //using (var stream = new StreamWriter(SaveFileDialogService.OpenFile()))
            //    //{
            //    //    //stream.Write(FileBody);
            //    //}
            //}
        }
        public void ImportEmployees()
        {
            var importEmployeesViewModel = ImportEmployeesViewModel.Create();
            importEmployeesViewModel.SetParentViewModel(this);
            var document = DocumentManagerService.CreateDocument("ImportEmployees", importEmployeesViewModel);
            document.Show();
           
        }
        public void ImportEmployeesPhotos()
        {

        }

    }
}