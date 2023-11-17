using KCS.Common.DAL;
using KCS.Common.DAL.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    static class AllowTimeDataSource 
    {
        
        static public IList<UserSlaveAllowTimeSetting> GetUserSlaveAllowTimeList(int _slaveSID, string _departmentID
            , int _allowTimeStartHour, int _allowTimeEndHour)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetUserSlaveAllowTime(_slaveSID, _departmentID, _allowTimeStartHour, _allowTimeEndHour);
            return KCS.Common.Utils.ModelConvertHelper<UserSlaveAllowTimeSetting>.ConvertToModel(dt);
        }







        static public bool AddJobCode(EmployeeJobCode jobcode)
        {
            return KCSDatabaseHelper.Instance.AddJobCode(jobcode);
        }
        static public bool DeleteJobCode(EmployeeJobCode jobcode)
        {
            return KCSDatabaseHelper.Instance.DeleteJobCode(jobcode);
        }
        static public IList<Employees> GetEmployeesList()
        {
            try
            {
                DataTable dt = KCSDatabaseHelper.Instance.GetEmployeesList();
                return KCS.Common.Utils.ModelConvertHelper<Employees>.ConvertToModel(dt);
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
        static public IList<EmployeeMsg> GetEmployeesMsgList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetEmployeesMsgList();
            return KCS.Common.Utils.ModelConvertHelper<EmployeeMsg>.ConvertToModel(dt);
        }
        static public IList<ElevatorCtlAuthority> GetElevatorAuthorityList(int slaveId)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetElevatorAuthorityList(slaveId);
            return KCS.Common.Utils.ModelConvertHelper<ElevatorCtlAuthority>.ConvertToModel(dt);
        }
        
        static public IList<EmployeeBrief> GetEmployeesBriefList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetEmployeesBriefList();
            return KCS.Common.Utils.ModelConvertHelper<EmployeeBrief>.ConvertToModel(dt);
        }
        static public bool UpdateEmployee(Employees employee,bool updateFace)
        {
            return KCSDatabaseHelper.Instance.UpdateEmployee(employee, CredentialsSource.GetLoginSupervisorSID(), updateFace);
        }

        static public AcAuthority GetAuthorityList(int slaveSID, string cardId)
        {
            return KCSDatabaseHelper.Instance.GetAuthorityList(slaveSID, cardId);
         }
        static public bool UpdateEmployeeAuthority(IEnumerable<ElevatorController> deviceList, IEnumerable<EmployeeBrief> employeesObject, AcAuthority Authority)
        {
            return KCSDatabaseHelper.Instance.UpdateEmployeeAuthority(deviceList, employeesObject, Authority, CredentialsSource.GetLoginSupervisorSID());
        }

        static public bool UpdateEmployeeAuthority(IEnumerable<DeviceInfo> deviceList, IEnumerable<Employees> employeesObject, AcAuthority Authority)
        {
            return KCSDatabaseHelper.Instance.UpdateEmployeeAuthority(deviceList, employeesObject, Authority, CredentialsSource.GetLoginSupervisorSID());
        }
        static public DataBaseAccessErrorCode NewEmployee(Employees employee, bool SyncToAll, IEnumerable<DeviceInfo> deviceList)
        {

            return KCSDatabaseHelper.Instance.InsertEmployee(employee, CredentialsSource.GetLoginSupervisorSID(), SyncToAll, deviceList);
        }
        static public int DeleteEmployee(int EmployeeSID)
        {
            return KCSDatabaseHelper.Instance.DeleteEmployee(EmployeeSID, CredentialsSource.GetLoginSupervisorSID());
           
        }
        static public bool ForceDeleteEmployee(int EmployeeSID, string CardId)
        {
            return KCSDatabaseHelper.Instance.ForceDeleteEmployee(EmployeeSID, CardId, CredentialsSource.GetLoginSupervisorSID()) > 0 ? true : false;
            
        }
        static public bool DeleteEmployeeFinger(string EmployeeCardId,int fingerno)
        {
            return KCSDatabaseHelper.Instance.DeleteEmployeeFinger(EmployeeCardId, fingerno);
        }
        static public bool DeleteEmployeeFinger12(string EmployeeCardId)
        {
            return KCSDatabaseHelper.Instance.DeleteEmployeeFinger12(EmployeeCardId);
        }
        static public bool ReSyncAll()
        {
            return KCSDatabaseHelper.Instance.ReSyncAll();
        }
        static public bool ReSyncSelectedEmployee(Employees employee)
        {
            return KCSDatabaseHelper.Instance.ReSyncSelectedEmployee(employee);
        }
        static public DataBaseAccessErrorCode ChangeCardIdOfUser(string oldCardId, string newCardId)
        {
            return KCSDatabaseHelper.Instance.ChangeCardIdOfUser(oldCardId, newCardId, CredentialsSource.GetLoginSupervisorMsg());
        }
        static public bool UpdateSyncSetting(Employees employee, IList<DeviceInfo> deviceListBack, IList<DeviceInfo> deviceList)
        {
            return KCSDatabaseHelper.Instance.EmployeeSyncSetting(employee,CredentialsSource.GetLoginSupervisorSID(), deviceListBack, deviceList);
        }
        static public bool DisableEmployees(IEnumerable<Employees> employeesObject)
        {
            return KCSDatabaseHelper.Instance.DisableEmployees(employeesObject, CredentialsSource.GetLoginSupervisorSID());
        }
        static public bool EnableEmployees(IEnumerable<Employees> employeesObject)
        {
            return KCSDatabaseHelper.Instance.EnableEmployees(employeesObject, CredentialsSource.GetLoginSupervisorSID());
        }
        static public bool CreateEmployeesMonthlyShift(IList<EmployeeBrief> employeesBriefList, int SelYear)
        {
            return KCSDatabaseHelper.Instance.CreateEmployeesMonthlyShift(employeesBriefList, SelYear);
        }
        static public bool CreateEmployeesMonthlyShift(IEnumerable<EmployeeBrief> employeesBriefObject, int SelYear)
        {
            return KCSDatabaseHelper.Instance.CreateEmployeesMonthlyShift(employeesBriefObject, SelYear);
        }
        //个人出勤历
        static public bool UpdateEmployeeShiftTable(int UserSID,string shiftTableCode)
        {
            return KCSDatabaseHelper.Instance.UpdateEmployeeShiftTable(UserSID, shiftTableCode);
        }
        static public bool ImportEmployeePhoto(string UserId,string photoPath)
        {
            return KCSDatabaseHelper.Instance.ImportEmployeePhoto(UserId, photoPath);
        }
        static public bool ImportFromFile(string ImportFilePath, bool bOverwrite,bool bSync, int mode, out string ErrorMessage, out int SucceedsCounts)
        {
            ErrorMessage = "";
            SucceedsCounts = 0;
            if (mode == 0)
            {//xlsx
                return KCSDatabaseHelper.Instance.ImportFromXLS(ImportFilePath, bOverwrite,bSync, true,CredentialsSource.GetLoginSupervisorSID(), out ErrorMessage, out SucceedsCounts);
            }
            else if (mode == 1)
            {//xls
                return KCSDatabaseHelper.Instance.ImportFromXLS(ImportFilePath, bOverwrite, bSync,false, CredentialsSource.GetLoginSupervisorSID(), out ErrorMessage, out SucceedsCounts);
            }
            else if (mode == 2)
            {//CSV
                return KCSDatabaseHelper.Instance.ImportFromTXT(ImportFilePath, bOverwrite, bSync, ',', CredentialsSource.GetLoginSupervisorSID(), out ErrorMessage, out SucceedsCounts);
            }
            else if (mode == 3)
            {//CSV txt table
                return KCSDatabaseHelper.Instance.ImportFromTXT(ImportFilePath, bOverwrite, bSync, '\t', CredentialsSource.GetLoginSupervisorSID(), out ErrorMessage, out SucceedsCounts);
            }
            return false;
        }

    }
}
