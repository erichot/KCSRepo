using KCS.Common.DAL.Constants;
using KCS.Common.Utils;
using KCS.Models;
using LINQtoCSV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KCS.Common.DAL
{
    public class KCSDatabaseHelper
    {
        private static KCSDatabaseHelper _Instance = null;
        private static SQLDataProvider sqlDatabaseProvider = null;

        public static KCSDatabaseHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new KCSDatabaseHelper();
                }
                return _Instance;
            }
        }

        public KCSDatabaseHelper()
        {
            sqlDatabaseProvider = new SQLDataProvider();
            sqlDatabaseProvider.ExecuteSql("set dateformat ymd");
        }


        #region SQL Statements
        private const string SUPERVISOR_LISTFIELD_SQL = "select ListField from [VBF_Supervisor]";
        private const string SUPERVISOR_LISTALL_SQL = "SELECT UserSID,UserID, UserName,Email, PhoneMobile,A.DepartmentID,UserPermissionTypeID,IsReadOnly AS EmployeeAuthority,Note,B.ListField AS DepartmentList FROM [VBF_Supervisor] AS A Left join [VBF_Department] AS B ON A.DepartmentID=B.DepartmentID";
        private const string DEPARTMENT_LISTFIELD_SQL = "SELECT [DepartmentID], [ListField] FROM [VBF_Department] ORDER BY [DepartmentID]";
        private const string DEPARTMENT_LIST_SQL = "SELECT [DepartmentSID],[DepartmentID], [DepartmentName],[SupervisorSID] FROM [BF_Department] where InActive=0 ORDER BY [DepartmentSID] ";
        private const string EMPLOYEES_LIST_SQL = "SELECT UserSID,UserID,  DepartmentID, DepartmentName, UserName, CardID, TitleName, InActive,UserPWD,NotPropagateToSlaveByDefault as SyncOrNot,AllowTimeStartHour, AllowTimeStartMinute, AllowTimeEndHour, AllowTimeEndMinute,  IsTaOrNot,   EmployeeTypeID, EmployeeTypeName, Email,ValidDate,PhoneMobile FROM [VBF_User]";
        private const string EMPLOYEES_TYPE_LIST_SQL = "SELECT EmployeeTypeID, EmployeeTypeName, InActive FROM BC_EmployeeType";
        private const string EMPLOYEES_TYPE_LIST_FIELD_SQL = "SELECT EmployeeTypeID, EmployeeTypeID + ':' +EmployeeTypeName AS ListFiled FROM BC_EmployeeType where InActive =0";
        private const string DEVICES_LIST_SQL = "SELECT [SlaveSID],  [IP], [IP_Internal], [ListField], [SlaveName], [SlaveDescription], [IsEnabled], [ResetToDefault], [SlaveCategoryID], [SlaveCategoryName], [IsServerMode], NotPropagateWithUsersByDefault FROM [VS_SlaveIP]";
        private const string DEVICES_LIST_FIELD_SQL = "SELECT  SlaveSID, [IP], [IP_Internal],  [SlaveName], [SlaveDescription] FROM [VS_SlaveIP] where IsEnabled=1 and NotPropagateWithUsersByDefault = 0";
        private const string DEVICE_CATEGEORY_LISTFIELD_SQL = "SELECT [SlaveCategoryID], [SlaveCategoryName] FROM [BC_SlaveCategory]";
        private const string JOB_CODE_LIST_SQL = "SELECT [TranType], [JobCode], [JobName], [Remark],[ListField] FROM [VBF_JobCode]";

        // DeleteCommand="DELETE FROM [BF_User] WHERE [UserSID] = @UserSID"         
       // UpdateCommand="UPDATE [BF_User] SET [UserID] = @UserID, [DepartmentID] = @DepartmentID, [UserName] = @UserName, [CardID] = @CardID, [TitleName] = @TitleName, [InActive] = @InActive, [IsTaOrNot] = @IsTaOrNot, [Email] = @Email, [UserPWD] = @UserPWD, [UserPin] = @UserPin, [TimeModifyLast] = CURRENT_TIMESTAMP, [TimeModifyLastSID] = @TimeModifyLastSID, [EmployeeTypeID] = @EmployeeTypeID, [NotPropagateToSlaveByDefault] = @NotPropagateToSlaveByDefault  WHERE [UserSID] = @UserSID "
       // SelectCommand="SELECT UserID, ListField, DepartmentID, DepartmentName, UserName, CardID, TitleName, AllowTimeStartHour, AllowTimeStartMinute, AllowTimeEndHour, AllowTimeEndMinute, InActive, IsTaOrNot, UserSID, UserPWD, EmployeeTypeID, EmployeeTypeName, Email, NotPropagateToSlaveByDefault FROM [VBF_User] WHERE (@DepartmentID IS NULL OR DepartmentID = @DepartmentID) AND (@EmployeeTypeID IS NULL OR EmployeeTypeID = @EmployeeTypeID) AND (@UserSID IS NULL OR UserSID = @UserSID) ORDER BY UserID"  
        
       // InsertCommand="INSERT INTO [BF_User] ([UserID], [DepartmentID], [UserName], [CardID], [TitleName], [IsTaOrNot], [Email], [UserPWD], [UserPin], [UserAddNewSID], [EmployeeTypeID], [NotPropagateToSlaveByDefault]) VALUES (@UserID, @DepartmentID, @UserName, @CardID, @TitleName, @IsTaOrNot, @Email, @UserPWD, @UserPin, @UserAddNewSID, @EmployeeTypeID, @NotPropagateToSlaveByDefault);SELECT @UserSID=@@IDENTITY" >
        
        #endregion
        #region KCS Query
        #region Device
        public DataTable GetDevicesSyncStatus(int SlaveSID)
        {
            string strSql = string.Format("select distinct UserSID,DepartmentName,UserID,UserName,CardID,IsReplicated,TimeReplicated,~InActive AS SyncFlag,SlaveSID from [VDS_BF_User_Add] where SlaveSID={0} ", SlaveSID.ToString());
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        
        public DataTable GetDevicesList()//A.ID,
        {
            string SqlCommand = "SELECT A.[SlaveSID], A.[IP], A.[IP_Internal], A.[ListField], A.[SlaveName], A.[SlaveDescription], A.[IsEnabled],"
            + "A.[ResetToDefault], A.[SlaveCategoryID], A.[SlaveCategoryName], A.[IsServerMode], A.NotPropagateWithUsersByDefault, ISNULL(b.UserCounts, 0 ) "
            + "AS UserCounts,ISNULL(c.UserReplicatedCount,0) AS UserReplicatedCount,ISNULL(d.FingersCounts,0) AS FingersCounts,ISNULL(e.FingersReplicatedCounts,0) "
            + "AS FingersReplicatedCounts FROM [VS_SlaveIP] AS A "
            + "left join (select [SlaveSID],count(distinct CardID) AS UserCounts from [VDS_BF_User_Add] where InActive =0 group by [SlaveSID]) AS B ON A.SlaveSID=B.SlaveSID "
            + "left join (select [SlaveSID],count(distinct CardID) AS UserReplicatedCount from [VDS_BF_User_Add] where InActive =0 and [IsReplicated]=1 group by [SlaveSID]) AS C ON A.SlaveSID=C.SlaveSID "
            + "left join (select [SlaveSID],count( CardID) AS FingersCounts from [DS_BF_FP_Add] where InActive =0  group by [SlaveSID]) AS D ON A.SlaveSID=D.SlaveSID "
            + "left join (select [SlaveSID],count( CardID) AS FingersReplicatedCounts from [DS_BF_FP_Add] where InActive =0 and [IsReplicated]=1 group by [SlaveSID]) AS E ON A.SlaveSID=E.SlaveSID ";

            return sqlDatabaseProvider.ExcuteTable(SqlCommand);//DEVICES_LIST_SQL
        }
        public DataTable GetDevicesInfoList()
        {
            return sqlDatabaseProvider.ExcuteTable(DEVICES_LIST_FIELD_SQL);
        }
        public DataTable GetDeviceCategoryList()
        {
            return sqlDatabaseProvider.ExcuteTable(DEVICE_CATEGEORY_LISTFIELD_SQL);
        }
        public bool DeleteDeviceCategory(ISlaveCategory slaveCategory)
        {
            string SqlCommand = string.Format("DELETE FROM [BC_SlaveCategory] WHERE [SlaveCategoryID] = {0}", slaveCategory.SlaveCategoryID.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public int GetSalveSID()
        {
            int iRet = GetSelectStatementStr("SELECT MAX(SlaveSID) FROM [S_SlaveIP]");
            if (iRet < 0)
            {
                return 1;
            }
            return (iRet + 1);
        }
        public bool ResetDevice(int SlaveSID)
        {
            string SqlCommand = string.Format("UPDATE [S_SlaveIP] set [ResetToDefault]= 1 WHERE [SlaveSID] = {0}", SlaveSID.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        
        public bool EnableDevice(int SlaveSID)
        {
            string SqlCommand = string.Format("UPDATE [S_SlaveIP] set [IsEnabled]= 1 WHERE [SlaveSID] = {0}", SlaveSID.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool DisableDevice(int SlaveSID)
        {
            string SqlCommand = string.Format("UPDATE [S_SlaveIP] set [IsEnabled]= 0 WHERE [SlaveSID] = {0}", SlaveSID.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool DeleteDevice(Devices device)
        {
            string SqlCommand = string.Format("DELETE FROM [S_SlaveIP] WHERE [SlaveSID] = {0}", device.SlaveSID.ToString());
            if (sqlDatabaseProvider.ExecuteSql(SqlCommand) <= 0)
                return false;
            SP_DELETE_S_SlaveIP_BySlaveSID(device.SlaveSID);
            SP_Delete_BFX_UserSlaveAllowTime_BySlaveSID(device.SlaveSID);
            SP_Delete_BFX_UserSlaveAddSync_BySlaveID(device.SlaveSID);
            return true;
            
        }
        public int UpdateDevice(Devices device)
        {
            int RetrunID = 0;
            if (SP_IsExist_SlaveIP_IP(device.IP, device.SlaveSID, out RetrunID) > 0)
            {
                return -2;//IP 已存在
            }
            string SqlCommand = string.Format("UPDATE [S_SlaveIP] SET [IP] = '{0}', [IP_Internal] = '',"+
            "[SlaveName] = N'{1}', [SlaveDescription] = N'{2}', [IsEnabled] = {3}," +
            "[ResetToDefault] =  {4}, [SlaveCategoryID] = {5}, [IsServerMode] = {6},"+
            "[NotPropagateWithUsersByDefault] = {7} WHERE [SlaveSID] = {8}", device.IP,
            device.SlaveName, device.SlaveDescription, device.IsEnabled ? "1" : "0", device.ResetToDefault ? "1" : "0", device.SlaveCategoryID.ToString(),
            device.IsServerMode ? "1" : "0", device.NotPropagateWithUsersByDefault ? "1" : "0", device.SlaveSID);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        private bool EmployeeHaveBeenReplicated(IList<EmployeeSync> backSyncList,EmployeeSync employeeSync)
        {
            foreach (var employeeTmp in backSyncList)
            {
                if (employeeTmp.UserSID == employeeSync.UserSID)
                {
                    return employeeTmp.IsReplicated;
                }
            }

            return false;
        }
        private bool EmployeeHaveBeenSetSync(IList<EmployeeSync> backSyncList, EmployeeSync employeeSync)
        {
            foreach (var employeeTmp in backSyncList)
            {
                if (employeeTmp.UserSID == employeeSync.UserSID)
                {
                    return employeeTmp.SyncFlag;
                }
            }

            return false;
        }
        public bool UpdateDeviceSyncSetting(int SlaveId, IList<EmployeeSync> backSyncList, IList<EmployeeSync> SyncList)
        {
             string SqlCommandActive = string.Format("UPDATE DS_BF_User_Add set [InActive]=0");
             string SqlCommandInActive = string.Format("UPDATE DS_BF_User_Add set [InActive]=1");
             ArrayList SQLStringList = new ArrayList();
            foreach( var employeeSync in SyncList)
            {
                if (employeeSync.SyncFlag)
                {//需要同步
                    if (!EmployeeHaveBeenSetSync(backSyncList, employeeSync))
                    {//未设置同步
                        SQLStringList.Add(string.Format("UPDATE DS_BF_User_Add set [InActive]=0 where UserSID={0}", employeeSync.UserSID.ToString()));
                        SQLStringList.Add(string.Format("UPDATE DS_BF_FP_Add set [InActive]=0 where CardID='{0}'", employeeSync.CardID.PadLeft(10,'0')));
                    }
                }
                else
                {//禁止同步
                    if (EmployeeHaveBeenSetSync(backSyncList, employeeSync))
                    {//允许同步
                        SQLStringList.Add(string.Format("UPDATE DS_BF_User_Add set [InActive]=1 where UserSID={0}", employeeSync.UserSID.ToString()));
                        SQLStringList.Add(string.Format("UPDATE DS_BF_FP_Add set [InActive]=1 where CardID='{0}'", employeeSync.CardID.PadLeft(10, '0')));
                    }
                    if (EmployeeHaveBeenReplicated(backSyncList, employeeSync))
                    {//已经同步到机器
                        SQLStringList.Add(string.Format("DELETE FROM [DS_BF_User_Del] WHERE (UserSID = {0})}", employeeSync.UserSID.ToString()));
                        SQLStringList.Add(string.Format("INSERT INTO [DS_BF_User_Del] (UserSID, CardID, SlaveSID, UserAddNewSID) SELECT U.UserSID, U.CardID, S.SlaveSID, 5566"+
	                    " FROM [BF_User] AS U, [S_SlaveIP] AS S " +
                        "WHERE U.UserSID = {0}", employeeSync.UserSID.ToString()));
                    }
                }
            }
            try
            {

                sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                return true;
            }
            catch
            {
            }
            return false;
           
        }
        public int AddDevice(Devices device)
        {
            int id = device.SlaveSID < 32767?device.SlaveSID:0;//SP_IsExist_SlaveIP_IP
            if (SP_IsExist_SlaveIP_SlaveSID(device.SlaveSID) > 0)
            {
                return -1;//SlaveId 已存在
            }
            int RetrunID = 0;
            if (SP_IsExist_SlaveIP_IP(device.IP, device.SlaveSID, out RetrunID) > 0)
            {
                return -2;//IP 已存在
            }
            string SqlCommand = string.Format("INSERT INTO [S_SlaveIP] ([SlaveSID], [ID], [IP], [IP_Internal], [SlaveName],"
                + "[SlaveDescription], [IsEnabled], [ResetToDefault], [SlaveCategoryID], [IsServerMode], [NotPropagateWithUsersByDefault])"
            + "VALUES ({0}, {1}, '{2}', '{3}', N'{4}', N'{5}', {6}, 0, {7}, {8}, {9});SELECT @@IDENTITY",
            device.SlaveSID.ToString(), id.ToString(), device.IP, device.IP_Internal, device.SlaveName, device.SlaveDescription,
            device.IsEnabled ? "1" : "0", device.SlaveCategoryID,device.IsServerMode?"1":"0",device.NotPropagateWithUsersByDefault?"1":"0");
            int iRet = sqlDatabaseProvider.ExecuteSql(SqlCommand);
            if (iRet <= 0)            
                return -3; //存储失败
            SP_Insert_DS_BF_User_Add_AfterAddSlave(device.SlaveSID);
            return 0;
        }
        public bool AddDeviceCategory(ISlaveCategory slaveCategory)
        {
            string SqlCommand = string.Format("select * from BC_SlaveCategory where SlaveCategoryName=N'{0}'", slaveCategory.SlaveCategoryName);
            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
                return false;
            if (slaveCategory.SlaveCategoryID == 0)
            {
                SqlCommand = string.Format("INSERT INTO [BC_SlaveCategory] ([SlaveCategoryName]) VALUES (N'{0}')", slaveCategory.SlaveCategoryName);
            }
            else
            {
                SqlCommand = string.Format("update [BC_SlaveCategory] set [SlaveCategoryName]=N'{0}' where [SlaveCategoryID]={1}", slaveCategory.SlaveCategoryName, slaveCategory.SlaveCategoryID.ToString());
            }
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        
        #endregion
        #region Access Control
        public DataTable GetUserGoupList()
        {
            return sqlDatabaseProvider.ExcuteTable(string.Format("select [DoorID],[GroupID],[Sun],[Mon],[Tue],[Wed],[Thu], [Fri],[Sat],[Holi1Group],[Holi2Group],[Holi3Group],[Holi4Group],[Holi5Group],[Holi6Group],[Holi7Group],[Holi8Group] from [DS_BF_UserGroup]"));
        }
        public DataTable GetTimeZoneList()
        {
            return sqlDatabaseProvider.ExcuteTable(string.Format("SELECT [DoorID],[TimeZoneID],[Frame01],[Frame02],[Frame03],[Frame04],[Description] from [DS_BF_TimeZone]"));
        }
        public DataTable GetTimeFrameList()
        {
            return sqlDatabaseProvider.ExcuteTable(string.Format("SELECT [DoorID],[TimeSetID],[StartHour],[StartMin],[EndHour],[EndMin],[Description] from [DS_BF_TimeSet]"));
        }
        public DataTable GetHolidaySetList()
        {
            return sqlDatabaseProvider.ExcuteTable(string.Format("select[DoorID],[DoorHoliID],[HoliMonth],[HoliDay],[HoliType],[Description] from [DS_BF_Holiday]"));
        }
        public bool UpdateUserGroupSet(AcUserGroupSet usergroup, int OperationID)
        {
            string SqlCommand = string.Format("select * from DS_BF_UserGroup where GroupID={0}", usergroup.GroupID.ToString());
            ArrayList SQLStringList = new ArrayList();
            SQLStringList.Add(string.Format("delete from [DS_BF_UserGroup_SlaveSID] where [GroupID]={0}", usergroup.GroupID.ToString()));
            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
            {//存在
                SQLStringList.Add(string.Format("UPDATE [DS_BF_UserGroup] SET [Sun] ={0}, [Mon] = {1}, [Tue] = {2}, [Wed] = {3}, [Thu] = {4}, [Fri] = {5}, [Sat] = {6},"
                    + "[Holi1Group] = {7},[Holi2Group] = {8},[Holi3Group] = {9},[Holi4Group] = {10},[Holi5Group] = {11},[Holi6Group] = {12},[Holi7Group] = {13},[Holi8Group] = {14},"
                    +" WHERE [DoorID] = @DoorID AND [GroupID] = @GroupID",
                  usergroup.Sun.ToString(), usergroup.Mon.ToString(), usergroup.Tue.ToString(), usergroup.Wed.ToString(), usergroup.Thu.ToString(), usergroup.Fri.ToString(), usergroup.Sat.ToString(),
                  usergroup.Holi1Group.ToString(), usergroup.Holi2Group.ToString(), usergroup.Holi3Group.ToString(), usergroup.Holi4Group.ToString(), usergroup.Holi5Group.ToString(),
                  usergroup.Holi6Group.ToString(), usergroup.Holi7Group.ToString(), usergroup.Holi8Group.ToString()));
            }
            else
            {
                SQLStringList.Add(string.Format("INSERT INTO [DS_BF_UserGroup] ([DoorID],[GroupID],[Sun],[Mon],[Tue],[Wed],[Thu], [Fri],[Sat],[Holi1Group],[Holi2Group],[Holi3Group],[Holi4Group],[Holi5Group],[Holi6Group],[Holi7Group],[Holi8Group],[Description]) VALUES "
                    + "({0}, {1}, {2}, {3}, {4}, {5}, {6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},N'{17}')",
                usergroup.DoorID.ToString(), usergroup.GroupID.ToString(), usergroup.Sun.ToString(), usergroup.Mon.ToString(), usergroup.Tue.ToString(),usergroup.Wed.ToString(), usergroup.Thu.ToString(), usergroup.Fri.ToString(),
                usergroup.Sat.ToString(), usergroup.Holi1Group.ToString(), usergroup.Holi2Group.ToString(),usergroup.Holi3Group.ToString(),
                usergroup.Holi4Group.ToString(), usergroup.Holi5Group.ToString(), usergroup.Holi6Group.ToString(), usergroup.Holi7Group.ToString(),
                usergroup.Holi8Group.ToString(), usergroup.Description));
            }
            SQLStringList.Add(string.Format("INSERT INTO [DS_BF_UserGroup_SlaveSID] ([DoorID],[GroupID],[SlaveSID])"
                + " SELECT DoorID, GroupID, S.SlaveSID FROM [DS_BF_UserGroup]  AS U, [S_SlaveIP] AS S WHERE GroupID = {0}", usergroup.GroupID.ToString()));
            try
            {

                sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                return true;
            }
            catch
            {
            }
            return false;
        }
        public bool UpdateTimeZoneSet(AcTimeZone timeZone, int OperationID)
        {
            string SqlCommand = string.Format("select * from DS_BF_TimeZone where TimeZoneID={0}", timeZone.TimeZoneID.ToString());
            ArrayList SQLStringList = new ArrayList();
            SQLStringList.Add(string.Format("delete from [DS_BF_TimeZone_SlaveSID] where [TimeZoneID]={0}", timeZone.TimeZoneID.ToString()));
            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
            {//存在
                SQLStringList.Add(string.Format("UPDATE [DS_BF_TimeZone] SET [Frame01] = {0}, [Frame02] = {1}, [Frame03] = {2}, [Frame04] = {3}, [Description] = N'{4}' WHERE [DoorID] = {5} AND [TimeZoneID] = {6}",
                  timeZone.Frame01.ToString(), timeZone.Frame02.ToString(), timeZone.Frame03.ToString(), timeZone.Frame04.ToString(), timeZone.Description, timeZone.DoorID.ToString(), timeZone.TimeZoneID.ToString()));
            }
            else
            {
                SQLStringList.Add(string.Format("INSERT INTO [DS_BF_TimeZone] ([DoorID], [TimeZoneID], [Frame01], [Frame02], [Frame03], [Frame04], [Description]) VALUES "
                    + "({0}, {1}, {2}, {3}, {4}, {5}, N'{6}')",
                timeZone.DoorID.ToString(), timeZone.TimeZoneID.ToString(), timeZone.Frame01.ToString(), timeZone.Frame02.ToString(), timeZone.Frame03.ToString(), timeZone.Frame04.ToString(), timeZone.Description));
            }
            SQLStringList.Add(string.Format("INSERT INTO [DS_BF_TimeZone_SlaveSID] ([DoorID],[TimeZoneID],[SlaveSID])"
                + " SELECT DoorID, TimeZoneID, S.SlaveSID FROM [DS_BF_TimeZone]  AS U, [S_SlaveIP] AS S WHERE TimeZoneID = {0}", timeZone.TimeZoneID.ToString()));
            try
            {

                sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                return true;
            }
            catch
            {
            }
            return false;
        }
        public bool UpdateTimeFrameSet(AcTimeSet timeFrame, int OperationID)
        {
            string SqlCommand = string.Format("select * from DS_BF_TimeSet where TimeSetID={0}", timeFrame.TimeSetID.ToString());
            ArrayList SQLStringList = new ArrayList();
            SQLStringList.Add(string.Format("delete from [DS_BF_TimeSet_SlaveSID] where [TimeSetID]={0}", timeFrame.TimeSetID.ToString()));
            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
            {//存在
                SQLStringList.Add(string.Format("UPDATE [DS_BF_TimeSet] SET [StartHour] = {0}, [StartMin] = {1}, [EndHour] = {2}, [EndMin] = {3},TimeModifyLast = CURRENT_TIMESTAMP,Description=N'{6}' WHERE [DoorID] = {4} AND [TimeSetID] = {5}",
                  timeFrame.StartHour.ToString(), timeFrame.StartMin.ToString(), timeFrame.EndHour.ToString(), timeFrame.EndMin.ToString(), timeFrame.DoorID.ToString(), timeFrame.TimeSetID.ToString(), timeFrame.Description));
            }
            else
            {
                SQLStringList.Add(string.Format("INSERT INTO [DS_BF_TimeSet] ([DoorID], [TimeSetID], [StartHour], [StartMin], [EndHour], [EndMin], [Description],[UserModifyLastSID]) "
                + "VALUES ({0}, {1}, {2}, {3}, {4}, {5},'{7}',{6})",
                timeFrame.DoorID.ToString(), timeFrame.TimeSetID.ToString(), timeFrame.StartHour.ToString(), timeFrame.StartMin.ToString(), timeFrame.EndHour.ToString(), timeFrame.EndMin.ToString(), OperationID.ToString(), timeFrame.Description));
            }
            SQLStringList.Add(string.Format("INSERT INTO [DS_BF_TimeSet_SlaveSID]([DoorID],[TimeSetID],[SlaveSID])"
                + " SELECT DoorID, TimeSetID, S.SlaveSID FROM [DS_BF_TimeSet]  AS U, [S_SlaveIP] AS S WHERE TimeSetID = {0}", timeFrame.TimeSetID.ToString()));
            try
            {

                sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                return true;
            }
            catch
            {
            }
            return false;
        }
        public bool UpdateHolidaySet(AcHolidaySet holiday,int OperationID)
        {
            string SqlCommand = string.Format("select * from DS_BF_Holiday where HoliMonth={0} and HoliDay={1}", holiday.HoliMonth.ToString(), holiday.HoliDay.ToString());
            ArrayList SQLStringList = new ArrayList();
            SQLStringList.Add(string.Format("delete from [DS_BF_Holiday_SlaveSID] where [DoorHoliID]={0}", holiday.DoorHoliID.ToString()));
            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
            {//存在
                SQLStringList.Add(string.Format("update [DS_BF_Holiday] set [DoorHoliID]={0},HoliType={1},Description=N'{2}',TimeModifyLast = CURRENT_TIMESTAMP, UserModifyLastSID = {5} where  HoliMonth={3} and HoliDay={4}",
                   holiday.DoorHoliID.ToString(), holiday.HoliType.ToString(), holiday.Description, holiday.HoliMonth.ToString(), holiday.HoliDay.ToString(),OperationID.ToString()));
            }
            else
            {
                SQLStringList.Add(string.Format("INSERT INTO [DS_BF_Holiday] ([DoorHoliID], [HoliMonth], [HoliDay], [HoliType], [Description], [UserAddNewSID]) VALUES"
                    + "({0}, {1}, {2}, {3}, N'{4}', {5})", holiday.DoorHoliID.ToString(), holiday.HoliMonth.ToString(), holiday.HoliDay.ToString(), holiday.HoliType.ToString(), holiday.Description, OperationID.ToString()));
            }
            SQLStringList.Add(string.Format("INSERT INTO [DS_BF_Holiday_SlaveSID]([DoorID],[DoorHoliID],[SlaveSID])"
                + " SELECT DoorID, DoorHoliID, S.SlaveSID FROM [DS_BF_Holiday]  AS U, [S_SlaveIP] AS S WHERE DoorHoliID = {0}", holiday.DoorHoliID.ToString()));
            try
            {

                sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                return true;
            }
            catch
            {
            }
            return false;
        }
        #endregion
        #region Department
        public DataTable GetDepartmentListField()
        {
            return sqlDatabaseProvider.ExcuteTable(DEPARTMENT_LISTFIELD_SQL);
        }
        public DataTable GetDepartmentList(string strCommad)
        {
            string strQuery = DEPARTMENT_LIST_SQL;
            if (strCommad != "All" && !string.IsNullOrEmpty(strCommad))
            {

                strQuery += " where [DepartmentID]='" + strCommad + "'";
            }

            return sqlDatabaseProvider.ExcuteTable(strQuery);
        }

        public bool UpdateDepartment(IDepartment department)
        {
            string SqlCommand = string.Format("UPDATE [BF_Department] SET [DepartmentName] = N'{0}' WHERE [DepartmentID] = N'{1}'", department.DepartmentName, department.DepartmentID);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool InsertDepartment(IDepartment department)
        {
            string SqlCommand = string.Format("INSERT INTO [BF_Department] ([DepartmentID], [DepartmentName]) VALUES (N'{0}', N'{1}')", department.DepartmentID, department.DepartmentName);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool DeleteDepartment(IDepartment department)
        {
            string SqlCommand = string.Format("DELETE FROM [BF_Department] WHERE [DepartmentID] = N'{0}'", department.DepartmentID);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) >= 0 ? true : false;
        }
        #endregion
        #region Supervisor

        public DataTable GetSupervisorListField()
        {
            return sqlDatabaseProvider.ExcuteTable(SUPERVISOR_LISTFIELD_SQL);
        }
        public DataTable GetSupervisorListByCommand(string strCommad)
        {
            string strQuery = SUPERVISOR_LISTALL_SQL;
            if (strCommad != "All" && !string.IsNullOrEmpty(strCommad))
            {
                if (strCommad.LastIndexOf(':') > 0)
                {
                    strCommad = strCommad.Substring(0, strCommad.LastIndexOf(':'));
                    strCommad = strCommad.Trim();
                }
                strQuery += " where UserID='" + strCommad + "'";
            }

            return sqlDatabaseProvider.ExcuteTable(strQuery);
        }
        public DataTable GetLoginUserMsg(string loginId)
        {
            string sSQL = string.Format("SELECT UnionType, UserSID, UserName, GroupSID, UserPermissionTypeID, DepartmentID, IsReadOnly,UserPWD FROM [VUN_SupervisorUser] WHERE (UserID = '{0}')", loginId);

            return sqlDatabaseProvider.ExcuteTable(sSQL);
        }
        public bool DeleteSuervisorBySID(int Sid)
        {
            string SqlCommand = string.Format("DELETE FROM [BF_Supervisor] WHERE ([UserSID] = {0}) AND (UserID <> 'ADMIN')", Sid);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) >= 0 ? true : false;

        }
        public bool UpdateSupervisor(EmployeeSupervisor supervisor,int UserSID)
        {
            string SqlCommand = string.Format("UPDATE BF_Supervisor SET UserID = N'{0}', UserName = N'{1}', Email = '{2}', PhoneMobile = '{3}', UserPermissionTypeID = {4}, DepartmentID = '{5}', IsReadOnly = {6}, Note = N'{7}', UserModifyLastSID = {8}, TimeModifyLast = CURRENT_TIMESTAMP WHERE (UserSID = {9})",
                supervisor.UserID,
                supervisor.UserName,
                supervisor.Email,
                supervisor.PhoneMobile,
                (int)supervisor.UserPermissionTypeID,
                supervisor.DepartmentID,
                supervisor.EmployeeAuthority?"1":"0",
                supervisor.Note,
                UserSID,
                supervisor.UserSID
                );
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;

        }
        public bool InsertNewSupervisor(EmployeeSupervisor supervisor, int UserSID)
        {
            string SqlCommand = string.Format("INSERT INTO BF_Supervisor(UserID, UserName, UserPWD, DepartmentID, Email, PhoneMobile, UserPermissionTypeID, IsReadOnly, Note, UserAddNewSID, UserModifyLastSID) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, '{8}', {9}, {9})",
                supervisor.UserID,
                supervisor.UserName,
                supervisor.NewUserPwd,
                supervisor.DepartmentID,
                supervisor.Email,
                supervisor.PhoneMobile,
                (int)supervisor.UserPermissionTypeID,
                supervisor.EmployeeAuthority ? "1" : "0",
                supervisor.Note,
                UserSID
                );
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;

        }
        public bool UpdateSupervisorPin(string supervisorId, string newPin)
        {
            string SqlCommand = string.Format("UPDATE [BF_Supervisor] SET [UserPWD] = '{0}' WHERE [UserID] = '{1}'", newPin, supervisorId);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        #endregion
        #region Employees
        public DataTable GetEmployeesSyncStatus(string CardID)
        {
            string SqlCommand = string.Format("select A.SlaveSID,A.[ID], A.[IP], A.[IP_Internal],  A.[SlaveName],"
            + "A.[SlaveDescription],ISNULL(~B.InActive,0) AS IsSyncOrNot,ISNULL(B.IsReplicated,0) As UserIsReplicated,ISNULL(C.IsReplicated,0) AS Finger1IsReplicated,"
            + "ISNULL(D.IsReplicated,0) AS Finger2IsReplicated from (SELECT  SlaveSID,[ID], [IP], [IP_Internal],  [SlaveName], [SlaveDescription] "
            + "FROM [VS_SlaveIP] where IsEnabled=1 and NotPropagateWithUsersByDefault = 0)AS A left OUTER join "
            + "(select distinct [SlaveSID],[InActive],[IsReplicated] from [DS_BF_User_Add] where CardID='{0}') AS B "
            + "on A.SlaveSID = B.[SlaveSID] left OUTER join (select distinct [SlaveSID],[IsReplicated] from [DS_BF_FP_Add] where CardID='{0}' "
            + "and FPNo=1) AS C on A.SlaveSID = C.[SlaveSID] left OUTER join (select distinct [SlaveSID],[IsReplicated] from [DS_BF_FP_Add] where "
            + "CardID='{0}' and FPNo=2) AS D on A.SlaveSID = D.[SlaveSID]", CardID.PadLeft(10, '0'));
            //string SqlCommand = string.Format("select distinct A.SlaveSID,A.[ID], A.[IP], A.[IP_Internal],  A.[SlaveName],"
            //+ "A.[SlaveDescription],B.InActive,B.IsReplicated As UserIsReplicated,C.IsReplicated AS Finger1IsReplicated,"
            //+ "D.IsReplicated AS Finger2IsReplicated from [VS_SlaveIP] AS A "
            //+"left OUTER join [DS_BF_User_Add] AS B ON A.SlaveSID=B.SlaveSID "
            //+"left OUTER join [DS_BF_FP_Add] AS C ON A.SlaveSID=C.SlaveSID "
            //+"left OUTER join [DS_BF_FP_Add] AS D ON A.SlaveSID=D.SlaveSID "
            //+"where A.IsEnabled=1 and A.NotPropagateWithUsersByDefault = 0 and B.CardID='{0}' "
            //+ "and C.FPNo=1 and C.CardID='{0}'  and D.FPNo=2 and D.CardID='{0}' ", CardID.PadLeft(10, '0'));
            return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }

        public DataTable GetEmployeesAuthoritySync(IEnumerable<Employees> employeesObject)
        {
            string SqlCommand = string.Format("select U.UserID,U.UserName,A.CardID,A.AllowTimeStartHour,A.AllowTimeStartMinute,A.AllowTimeEndHour,A.AllowTimeEndMinute,GroupID,SlaveSID,A.IsReplicated "
                +"from [BFX_UserSlaveAllowTime] AS A Left Join BF_User AS U ON A.CardID=U.CardID  where A.CardID IN(");
            foreach (Employees employee in employeesObject)
            {
                SqlCommand += "'" + employee.CardID.PadLeft(10, '0') + "',";
            }
            SqlCommand = SqlCommand.TrimEnd(',');
            SqlCommand += ")";
            return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }
        
        public DataTable GetEmployeesTypeInfoList()
        {
            return sqlDatabaseProvider.ExcuteTable(EMPLOYEES_TYPE_LIST_FIELD_SQL);
        }
        public DataTable GetEmployeesTypeList()
        {
            return sqlDatabaseProvider.ExcuteTable(EMPLOYEES_TYPE_LIST_SQL);
        }
        public DataTable GetJobCodeList()
        {
            return sqlDatabaseProvider.ExcuteTable(JOB_CODE_LIST_SQL);
        }
        public DataTable GetEmployeesList()
        {
            return sqlDatabaseProvider.ExcuteTable(EMPLOYEES_LIST_SQL);
        }
        public bool UpdateEmployeeAuthority(IEnumerable<DeviceInfo> deviceList, IEnumerable<Employees> employeesObject, AcAuthority Authority, int OperationId)
        {
            string StrDeviceList="(";
            string StrEmployeesList = "(";
            foreach (Employees employee in employeesObject)
            {
                StrEmployeesList += "'" + employee.CardID.PadLeft(10, '0') + "',";
            }
            StrEmployeesList = StrEmployeesList.TrimEnd(',');
            StrEmployeesList += ")";
            foreach (DeviceInfo device in deviceList)
            {
                StrDeviceList += "'" + device.SlaveSID.ToString() + "',";
            }
            StrDeviceList = StrDeviceList.TrimEnd(',');
            StrDeviceList += ")";
            ArrayList SQLStringList = new ArrayList();
            SQLStringList.Add("DELETE FROM [BFX_UserSlaveAllowTime] WHERE [CardID] in" + StrEmployeesList + " AND [SlaveID] in" + StrDeviceList);

            SQLStringList.Add(string.Format("INSERT INTO [BFX_UserSlaveAllowTime] ([UserSID],[SlaveSID],[SlaveID],[CardID],[AllowTimeStartHour],[AllowTimeStartMinute],[AllowTimeEndHour],[AllowTimeEndMinute],[IsEnabled],[UserAddNewSID],[GroupID])"
            + "SELECT [UserSID],S.SlaveSID,0,CardID,{0},{1},{2},{3},1,{7},{4} FROM [BF_User] AS U,[S_SlaveIP] AS S WHERE SlaveSID in{5}  and [CardID] in{6}", Authority.AllowTimeStartHour.ToString(),
            Authority.AllowTimeStartMinute.ToString(), Authority.AllowTimeEndHour.ToString(), Authority.AllowTimeEndMinute.ToString(),
            Authority.GroupID.ToString(), StrDeviceList, StrEmployeesList, OperationId.ToString()));
            try
            {

                sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                return true;
            }
            catch
            {
            }
            return false;

         }
        public bool AddJobCode(EmployeeJobCode jobcode)
        {
            string SqlCommand = string.Format("select * from BF_JobCode where TranType={0}", jobcode.TranType.ToString());
            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
            {
                SqlCommand = string.Format("UPDATE [BF_JobCode] SET  [JobName] = '{0}', [Remark] = '{1}' WHERE [TranType] = {2}", jobcode.JobName, jobcode.Remark, jobcode.TranType.ToString());
            }
            else
            {
                SqlCommand = string.Format("INSERT INTO [BF_JobCode] ([TranType], [JobCode], [JobName],[Remark]) VALUES ({0}, {0}, {1},{2})", jobcode.TranType.ToString(), jobcode.JobName, jobcode.Remark);
         
            }
            
               return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool DeleteJobCode(EmployeeJobCode jobcode)
        {
            string SqlCommand = string.Format("DELETE FROM [BF_JobCode] WHERE [TranType] = {0}", jobcode.TranType.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool UpdateEmployeesType(EmployeesType employeeType)
        {
            string SqlCommand = string.Format("SELECT * FROM [BC_EmployeeType] where [EmployeeTypeID] = N'{0}'", employeeType.EmployeeTypeID);
            DataTable dt = sqlDatabaseProvider.ExcuteTable(SqlCommand);
            if (dt != null && dt.Rows.Count > 0)
            {
                SqlCommand = string.Format("UPDATE [BC_EmployeeType] SET [EmployeeTypeName] = N'{0}',[InActive]={1} WHERE [EmployeeTypeID] = N'{2}'", employeeType.EmployeeTypeName, employeeType.InActive ? 1 : 0, employeeType.EmployeeTypeID);
            }
            else
            {
                SqlCommand = string.Format("INSERT INTO [BC_EmployeeType] ([EmployeeTypeID], [EmployeeTypeName]) VALUES (N'{0}', N'{1}')", employeeType.EmployeeTypeID, employeeType.EmployeeTypeName);
            }
             
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool InsertEmployeesType(EmployeesType employeeType)
        {
            string SqlCommand = string.Format("INSERT INTO [BC_EmployeeType] ([EmployeeTypeID], [EmployeeTypeName]) VALUES (N'{0}', N'{1}')", employeeType.EmployeeTypeID, employeeType.EmployeeTypeName);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool DeleteEmployeesType(EmployeesType employeeType)
        {
            string SqlCommand = string.Format("DELETE FROM [BC_EmployeeType] WHERE [EmployeeTypeID] = N'{0}'", employeeType.EmployeeTypeID);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) >= 0 ? true : false;
        }
        public bool UpdateEmployee(Employees employee, int OperationId)
        {
            string SqlCommand = string.Format("UPDATE [BF_User] SET  [DepartmentID] = N'{0}', [UserName] = N'{1}',  [TitleName] =  N'{2}',  [IsTaOrNot] = {3}, [Email] = N'{4}', [TimeModifyLast] = CURRENT_TIMESTAMP, [TimeModifyLastSID] = {5}, [EmployeeTypeID] = N'{6}', [NotPropagateToSlaveByDefault] = {7}  WHERE [UserSID] = {8}",
                    employee.DepartmentID,
                    employee.UserName,
                    employee.TitleName,
                    employee.IsTaOrNot ? "1" : "0",
                    employee.Email,
                    OperationId,
                    employee.EmployeeTypeID,
                    employee.SyncOrNot ? "1" : "0",
                    employee.UserSID);
            if (sqlDatabaseProvider.ExecuteSql(SqlCommand) <= 0)
            {
                return false;
            }
            SP_DS_Update_UserAdd_SetAllSlaveToZero_ExceptNegativeMask(employee.UserSID, OperationId);
            if (employee.SyncOrNot)
            {
                SqlCommand = string.Format("update [DS_BF_User_Add] set InActive = 1 where UserSID={0};update [DS_BF_FP_Add] set InActive = 1 where CardID='{1}' ", employee.UserSID, employee.CardID.PadLeft(10, '0'));
                sqlDatabaseProvider.ExecuteSql(SqlCommand);
            }
            return true;

        }
        public DataBaseAccessErrorCode InsertEmployee(Employees employee, int OperationId, bool SyncToAll, IEnumerable<DeviceInfo> deviceList)
        {
            int UserSID;
            if (SP_IsExist_User_UserID(employee.UserID, out UserSID) > 0)
            {
                return DataBaseAccessErrorCode.ExisitedUserId;
            }
            if (SP_IsExist_User_CardID(employee.CardID, out UserSID) > 0)
            {
                return DataBaseAccessErrorCode.ExisitedCardId;
            }

            string SqlCommand = string.Format("INSERT INTO [BF_User] ([UserID], [DepartmentID], [UserName], [CardID], [TitleName], [IsTaOrNot], [Email], [UserPWD], [UserPin], [UserAddNewSID], [EmployeeTypeID], [NotPropagateToSlaveByDefault]) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', {5}, N'{6}', N'{7}', N'{8}', {9}, N'{10}', {11});SELECT @@IDENTITY",
                employee.UserID,
                employee.DepartmentID,
                employee.UserName,
                employee.CardID.PadLeft(10,'0'),
                employee.TitleName,
                employee.IsTaOrNot?"1":"0",
                employee.Email,
                employee.UserPWD,
                employee.UserPIN,
                OperationId,
                employee.EmployeeTypeID,
                employee.SyncOrNot?"1" : "0");
            int getUserSID;
            object  obj = sqlDatabaseProvider. ExecuteSqlWitResult(SqlCommand);
            if (obj == null)
            {
                return DataBaseAccessErrorCode.OperationError;
            }
            try
            {
                getUserSID = Convert.ToInt32(obj);
                if (getUserSID <= 0)
                    return DataBaseAccessErrorCode.OperationError;
                SqlCommand = string.Format("DELETE FROM [DS_BF_FP_Add] WHERE (CardID = '{0}'); DELETE FROM [DS_BF_FP_Del] WHERE (CardID = '{0}');DELETE FROM [BF_FP] WHERE (CardID = '{0}')",
                    employee.CardID.PadLeft(10, '0'));
                sqlDatabaseProvider.ExecuteSql(SqlCommand);
                SP_Insert_User_DefaultWorkShift(getUserSID);
                SP_Insert_BF_WorkCalendar_WhenNewUserOnThisMonth(getUserSID, System.DateTime.Now.Year, System.DateTime.Now.Month, OperationId);
                SP_DS_Insert_User_Add_NewUser(getUserSID, OperationId);
                if (!employee.SyncOrNot && !SyncToAll && deviceList != null)
                {

                    SqlCommand = string.Format("update [DS_BF_User_Add] set InActive = 1 where UserSID={0} AND SlaveSID NOT IN(", getUserSID);
                    foreach (DeviceInfo device in deviceList)
                    {
                        if (device != null)
                            SqlCommand += string.Format("{0},", device.SlaveSID);
                    }
                    SqlCommand = SqlCommand.TrimEnd(',');
                    SqlCommand += ")";
                    int iRet = sqlDatabaseProvider.ExecuteSql(SqlCommand);

                }
                return 0;
            }
            catch
            {
            }
            return DataBaseAccessErrorCode.OperationError; 
      
        }
        public int DeleteEmployee(int sid, int OperatorSID)
        {
            int TransSID;
            if (0 == SP_IsVaild_User_Delete(sid, out TransSID))
            {
                return TransSID;
            }
            SP_Delete_User_UserWeeklyShift(sid);
            SP_DS_Delete_User_UserSID(sid, OperatorSID);
            SP_Delete_BFX_UserSlaveAddSync_ByUserSID(sid);
            SP_Delete_BFX_UserSlaveAllowTime_ByUserSID(sid);
            string SqlCommand = string.Format("DELETE FROM [BF_User] WHERE [UserSID] = {0}", sid);
            int iRet = sqlDatabaseProvider.ExecuteSql(SqlCommand);
            if( iRet == 1)
            return 0;
            return -1;
        }
        public int ForceDeleteEmployee(int sid,string cardid, int OperatorSID)
        {
            SP_Delete_BFX_UserSlaveAddSync_ByUserSID(sid);
            SP_Delete_BFX_UserSlaveAllowTime_ByUserSID(sid);
            SP_DS_Delete_FP_FPNo(cardid, 1);
            SP_DS_Delete_FP_FPNo(cardid, 2);
            SP_DS_Delete_User_ForceDelete(sid, OperatorSID);
            return 1;
        }
        public bool DeleteEmployeeFinger(string cardid,int fingerno)
        {
            return SP_DS_Delete_FP_FPNo(cardid, fingerno)>0?true:false;
        }
        public bool DeleteEmployeeFinger12(string cardid)
        {
            int rRet1 = SP_DS_Delete_FP_FPNo(cardid, 1);
            int rRet2 = SP_DS_Delete_FP_FPNo(cardid, 2);
            return rRet1 > 0 && rRet2 > 0;
        }
        public bool ReSyncAll()
        {
            string SqlCommand = string.Format("update [DS_BF_User_Add] set IsReplicated = 0 where InActive=0;update [DS_BF_FP_Add] set IsReplicated = 0 where InActive=0");
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool ReSyncSelectedEmployee(Employees employee)
        {
            string SqlCommand = string.Format("update [DS_BF_User_Add] set IsReplicated = 0 where InActive=0 and CardID='{0}';update [DS_BF_FP_Add] set IsReplicated = 0 where InActive=0 and CardID='{0}'", employee.CardID.PadLeft(10, '0'));
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool EnableEmployees(IEnumerable<Employees> employeesObject, int OperatorSID)
        {
            ArrayList SQLStringList = new ArrayList();
            foreach (Employees employee in employeesObject)
            {
                SQLStringList.Add(string.Format("update BF_User set InActive=00 where UserSID={0}", employee.UserSID));
                SQLStringList.Add(string.Format("delete from DS_BF_User_Del where UserSID={0}", employee.UserSID));
                SQLStringList.Add(string.Format("delete from DS_BF_User_Add where UserSID={0}", employee.UserSID));
                SQLStringList.Add(string.Format("delete from DS_BF_FP_Add where CardID={0}", employee.CardID.PadLeft(10, '0')));
                SQLStringList.Add(string.Format("delete from DS_BF_FP_Del where CardID={0}", employee.CardID.PadLeft(10, '0')));

                string SqlCommandNewSync = string.Format("INSERT [DS_BF_User_Add]"
        + "(UserSID , CardID , SlaveSID, InActive, UserAddNewSID)"
        + "SELECT {0} , U.CardID , S.SlaveSID"
        + ", CASE WHEN U.NotPropagateToSlaveByDefault = 1 "
        + "THEN 1 "
        + "ELSE ("
        + "CASE WHEN S.NotPropagateWithUsersByDefault = 1 THEN 1 ELSE 0 END"
        + ")"
        + "END AS InActive"
        + ", U.UserAddNewSID "
        + "FROM [BF_User] AS U, [S_SlaveIP] AS S "
        + "WHERE UserSID = {0}", employee.UserSID);
                SQLStringList.Add(SqlCommandNewSync);
                string SqlCommandNewFp = string.Format("INSERT [DS_BF_FP_Add]"
            + "([SlaveSID],[FPNo],[CardID],[InActive],[UserAddNewSID],[IsReplicated]) "
            + "SELECT S.SlaveSID,U.FPNo , U.CardID ,0 AS InActive,{1} AS UserAddNewSID,0 AS TimeReplicated "
            + "FROM [BF_FP] AS U, [S_SlaveIP] AS S "
            + "WHERE U.CardID = {0} ", employee.CardID.PadLeft(10, '0'), OperatorSID);
                SQLStringList.Add(SqlCommandNewFp);
            }
            try
            {

                sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                return true;
            }
            catch
            {
            }
            return false;
        }
        
        public bool DisableEmployees(IEnumerable<Employees> employeesObject, int OperatorSID)
        {
           // string SqlCommand = "";
            ArrayList SQLStringList = new ArrayList();
            foreach (Employees employee in employeesObject)
            {
                SQLStringList.Add(string.Format("update BF_User set InActive=1 where UserSID={0}", employee.UserSID));
                SQLStringList.Add(string.Format("delete from DS_BF_User_Del where UserSID={0}", employee.UserSID));
                SQLStringList.Add(string.Format("update DS_BF_User_Add set InActive=1 where CardID='{0}'", employee.CardID.PadLeft(10, '0')));
                SQLStringList.Add(string.Format("update DS_BF_FP_Add set InActive=1 where CardID='{0}'", employee.CardID.PadLeft(10, '0')));
                SQLStringList.Add(string.Format("INSERT INTO [DS_BF_User_Del](UserSID, CardID, SlaveSID, UserAddNewSID)"
           + " SELECT U.UserSID, U.CardID, S.SlaveSID, {0} FROM [BF_User] AS U, [S_SlaveIP] AS S WHERE U.UserSID = {1}", OperatorSID, employee.UserSID));
           //     SqlCommand += string.Format("update BF_User set InActive=1 where UserSID={0}", employee.UserSID);
           //     SqlCommand += ";";
           //     SqlCommand += string.Format("delete from DS_BF_User_Del where UserSID={0}", employee.UserSID);
           //     SqlCommand += ";";
           //     string.Format("update DS_BF_User_Add set InActive=1 where CardID='{2}';update DS_BF_FP_Add set InActive=1 where CardID='{2}';INSERT INTO [DS_BF_User_Del](UserSID, CardID, SlaveSID, UserAddNewSID)"
           //+ " SELECT U.UserSID, U.CardID, S.SlaveSID, {0} FROM [BF_User] AS U, [S_SlaveIP] AS S WHERE U.UserSID = {1};", OperatorSID, employee.UserSID, employee.CardID.PadLeft(10, '0'));
            }
            //return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
                try
                {

                    sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                    return true;
                }
                catch
                {
                }
                return false;
        }
        private bool HaveSyncOrNot(IList<DeviceInfo> deviceList,DeviceInfo device)
        {
            foreach (var tempDevice in deviceList)
            {
                if (tempDevice.SlaveSID == device.SlaveSID )
                {
                    return tempDevice.IsSyncOrNot;
                }
            }
            return false;
        }
        public bool EmployeeSyncSetting(Employees employee,int OperatorSID, IList<DeviceInfo> deviceListBack, IList<DeviceInfo> deviceList)
        {
            bool bAdd = false;
            bool bDelete = false;
            bool bUpdate = false;
            string SqlDeviceListAdd ="(";
            string SqlDeviceListDel ="(";
            string SqlDeviceListUpdate= "(";
            //string SqlCommand = "";
           // string SqlCommandDel = string.Format("delete from DS_BF_FP_Del where CardID='{0}';delete from DS_BF_User_Del where CardID='{0}'",employee.CardID.PadLeft(10, '0'));
            string SqlCommandNewSync = string.Format("INSERT [DS_BF_User_Add]"
		+"(UserSID , CardID , SlaveSID, InActive, UserAddNewSID)"
        + "SELECT {0} , U.CardID , S.SlaveSID"
		+", CASE WHEN U.NotPropagateToSlaveByDefault = 1 "
		+	"THEN 1 "
		+	"ELSE ("
		+		"CASE WHEN S.NotPropagateWithUsersByDefault = 1 THEN 1 ELSE 0 END"
		+		")"
		+	"END AS InActive"
		+", U.UserAddNewSID "
	    +"FROM [BF_User] AS U, [S_SlaveIP] AS S "
        + "WHERE UserSID = {0} AND S.SlaveSID IN ", employee.UserSID);
            string SqlCommandNewFp = string.Format("INSERT [DS_BF_FP_Add]"
        + "([SlaveSID],[FPNo],[CardID],[InActive],[UserAddNewSID],[IsReplicated]) "
        + "SELECT S.SlaveSID,U.FPNo , U.CardID ,0 AS InActive,{1} AS UserAddNewSID,0 AS TimeReplicated "
        + "FROM [BF_FP] AS U, [S_SlaveIP] AS S "
        + "WHERE U.CardID = {0} AND S.SlaveSID IN ", employee.CardID.PadLeft(10, '0'), OperatorSID);
             foreach (DeviceInfo device in deviceList)
            {
                 
                if (device.IsSyncOrNot)
                {//同步到改设备
                    if (!HaveSyncOrNot(deviceListBack,device))
                    {//未设置过，增加到同步
                        SqlDeviceListAdd += string.Format("{0},", device.SlaveSID);
                        bAdd = true;
                    }
                    else
                    {
                        SqlDeviceListUpdate += string.Format("{0},", device.SlaveSID);
                        bUpdate = true;
                    }

                    
                }
                else
                {
                    //if (deviceListBack.Contains(device))
                    if (HaveSyncOrNot(deviceListBack, device))
                    {//已经设置同步过，清楚同步标记,并同步删除改用户到设备
                        SqlDeviceListDel += string.Format("{0},", device.SlaveSID);
                        bDelete = true;
                    }
                }
            }

                if (bAdd)
                {
                    SqlDeviceListAdd = SqlDeviceListAdd.TrimEnd(',');
                    SqlDeviceListAdd += ")";
                }
                if (bDelete)
                {
                    SqlDeviceListDel = SqlDeviceListDel.TrimEnd(',');
                    SqlDeviceListDel += ")";
                }
                if (bUpdate)
                {
                    SqlDeviceListUpdate = SqlDeviceListUpdate.TrimEnd(',');
                    SqlDeviceListUpdate += ")";
                }
                //SqlCommand = SqlCommandDel;
                ArrayList SQLStringList = new ArrayList();
                SQLStringList.Add(string.Format("delete from DS_BF_FP_Del where CardID='{0}'",employee.CardID.PadLeft(10, '0')));
                SQLStringList.Add(string.Format("delete from DS_BF_User_Del where CardID='{0}'",employee.CardID.PadLeft(10, '0')));
                
                //sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                if (bAdd)
                {
                    
                    //SqlCommand += ";";
                    string SqlDeleteUserFromAdd = string.Format("delete from DS_BF_User_Add where CardID='{0}' AND SlaveSID IN",employee.CardID.PadLeft(10, '0'));
                    SqlDeleteUserFromAdd += SqlDeviceListAdd;
                    //SqlCommand += SqlDeleteUserFromAdd;
                    SQLStringList.Add(SqlDeleteUserFromAdd);
                   // SqlCommand += ";";                    
                    SqlCommandNewSync += SqlDeviceListAdd;
                    SQLStringList.Add(SqlCommandNewSync);
                    //SqlCommand += SqlCommandNewSync;
                    //SqlCommand += ";";
                    string SqlDeleteFpFromAdd = string.Format("delete from [DS_BF_FP_Add] where CardID='{0}' AND SlaveSID IN",employee.CardID.PadLeft(10, '0'));
                    SqlDeleteFpFromAdd += SqlDeviceListAdd;
                   // SqlCommand += SqlDeleteFpFromAdd;
                    SQLStringList.Add(SqlDeleteFpFromAdd);
                     //SqlCommand += ";";
                     SqlCommandNewFp += SqlDeviceListAdd;
                    // SqlCommand += SqlCommandNewFp;
                    SQLStringList.Add(SqlCommandNewFp);
                }
                if (bUpdate)
                {
                    //SqlCommand += ";";
                    string SqlUpdateUserFromAdd = string.Format("update DS_BF_User_Add set InActive=0 where CardID='{0}' AND SlaveSID IN {1};update DS_BF_FP_Add set InActive=0 where CardID='{0}' AND SlaveSID IN {1}", employee.CardID.PadLeft(10, '0'), SqlDeviceListUpdate);
                    //SqlCommand += SqlUpdateUserFromAdd;
                    SQLStringList.Add(SqlUpdateUserFromAdd);
                   
                }
                if (bDelete)
                {
                    string SqlCommandDeleteSync = string.Format("update DS_BF_User_Add set InActive=1 where CardID='{2}' AND SlaveSID IN {3};update DS_BF_FP_Add set InActive=1 where CardID='{2}' AND SlaveSID IN {3};INSERT INTO [DS_BF_User_Del](UserSID, CardID, SlaveSID, UserAddNewSID)"
           + " SELECT U.UserSID, U.CardID, S.SlaveSID, {0} FROM [BF_User] AS U, [S_SlaveIP] AS S WHERE U.UserSID = {1} AND S.SlaveSID IN {3}", OperatorSID, employee.UserSID, employee.CardID.PadLeft(10, '0'), SqlDeviceListDel);
           
                    //SqlCommand += ";";
                    //SqlCommand += SqlCommandDeleteSync;
                    SQLStringList.Add(SqlCommandDeleteSync);
                }


                try
                {

                    sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return false;
            // return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        
        #endregion
        #endregion
        #region Import Employees
        private static string TBN_Import_BF_User = "TMP_BF_User_196";
        private static string FN_BF_User_UserSID = "UserSID";
        private static string FN_BF_User_UserID = "UserID";
        private static string FN_BF_User_UserName = "UserName";
        private static string FN_BF_User_DepartmentID = "DepartmentID";
        private static string FN_BF_Department_DepartmentName = "DepartmentName";
        private static string FN_BF_User_CardID = "CardID";
        private static string FN_BF_User_ValidDate = "ValidDate";
        private static string FN_BF_User_AllowTimeStartHour = "AllowTimeStartHour";
        private static string FN_BF_User_AllowTimeStartMinute = "AllowTimeStartMinute";
        private static string FN_BF_User_AllowTimeEndHour = "AllowTimeEndHour";
        private static string FN_BF_User_AllowTimeEndMinute = "AllowTimeEndMinute";
        private static string FN_BF_User_Email = "Email";
        private static string FN_BF_User_PhoneMobile = "PhoneMobile";
        private int GetSelectStatementStr(string SelectCommandText)
        {
            int iReturn;
            object obj = sqlDatabaseProvider.ExecuteSqlWitResult(SelectCommandText);
            if (obj == null)
                return -1;
            else{
                    try
                    {
                        iReturn = Convert.ToInt32(obj);
                         return iReturn;
                    }
                catch{}
            }
            return -1;
        }
        private DataSet GetDataFromExcelWithAppointSheetName(string Path, bool bXlsx)
        {
            String strConn = "";
            if (bXlsx)
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                         "Data Source=" + Path + ";" +
                         "Extended Properties=Excel 8.0;";
            }
            else
            {
                strConn = "Microsoft.Jet.OLEDB.4.0;" +
                         "Data Source=" + Path + ";" +
                         "Extended Properties=Excel 8.0;";
            }
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等　
            DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            //包含excel中表名的字符串数组
            string[] strTableNames = new string[dtSheetName.Rows.Count];
            for (int k = 0; k < dtSheetName.Rows.Count; k++)
            {
                strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
            }
            OleDbDataAdapter da = null;
            DataSet ds = new DataSet();
            //从指定的表明查询数据,可先把所有表明列出来供用户选择
            string strExcel = "select * from[" + strTableNames[0] + "]";
            da = new OleDbDataAdapter(strExcel, conn);
            da.Fill(ds);

            return ds;
        }
        public bool ImportFromTXT(string ImportFilePath, bool bOverwrite, bool bSync, char SaparatorChar, int OperationId, out string ErrorMessage, out int SucceedsCounts)
        {
            bool bolInValid = false;
            ErrorMessage ="";
            SucceedsCounts = 0;
            CsvFileDescription cfdMain = new CsvFileDescription();

            cfdMain.SeparatorChar = SaparatorChar;
            cfdMain.FirstLineHasColumnNames = true;

            CsvContext ccMain = new CsvContext();
            IEnumerable<ImportDepartmentUser> iduUser = ccMain.Read<ImportDepartmentUser>(ImportFilePath, cfdMain);
            string sSQL = "TRUNCATE TABLE [TMP_BF_User_196]";         

            sqlDatabaseProvider.ExecuteSql(sSQL);

            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlDataAdapter daImportUser =new SqlDataAdapter("SELECT * FROM [" + TBN_Import_BF_User + "]", cn);
            DataSet dsImportUser = new DataSet();
            SqlCommandBuilder sqlBuilder = new SqlCommandBuilder(daImportUser);
            DataRow rowCurrent ;


            daImportUser.Fill(dsImportUser, TBN_Import_BF_User);

            foreach(ImportDepartmentUser CurrentUser in iduUser)
            {
                rowCurrent = dsImportUser.Tables[TBN_Import_BF_User].NewRow();
                rowCurrent[FN_BF_User_UserID] = CurrentUser.UserID;
                rowCurrent[FN_BF_User_UserName] = CurrentUser.UserName;
                rowCurrent[FN_BF_User_DepartmentID] = CurrentUser.DepartmentID;
                rowCurrent[FN_BF_Department_DepartmentName] = CurrentUser.DepartmentName;
                rowCurrent[FN_BF_User_CardID] = CurrentUser.CardID;
                rowCurrent[FN_BF_User_ValidDate] = CurrentUser.ValidDate;
                rowCurrent[FN_BF_User_AllowTimeStartHour] = CurrentUser.AllowTimeStartHour;
                rowCurrent[FN_BF_User_AllowTimeStartMinute] = CurrentUser.AllowTimeStartMinute;
                rowCurrent[FN_BF_User_AllowTimeEndHour] = CurrentUser.AllowTimeEndHour;
                rowCurrent[FN_BF_User_AllowTimeEndMinute] = CurrentUser.AllowTimeEndMinute;
                rowCurrent[FN_BF_User_Email] = CurrentUser.Email;
                rowCurrent[FN_BF_User_PhoneMobile] = CurrentUser.PhoneMobile;
                dsImportUser.Tables[TBN_Import_BF_User].Rows.Add(rowCurrent);
            }       

            daImportUser.Update(dsImportUser, TBN_Import_BF_User);
            //UserID 长度检查
                     if (!bolInValid )
                     {
                         sSQL = "SELECT UserID FROM " + TBN_Import_BF_User + " WHERE (LEN(UserID) > 16)";
                         int iCurrentUserID = GetSelectStatementStr(sSQL);
                         if ( iCurrentUserID > 0)
                         {
                             ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgUserIdLength") + "\r\n" + "UserID:" + iCurrentUserID.ToString();
                             bolInValid = true;
                         }
                     }
                    //UserID重复性检查
                     if ( !bolInValid && !bOverwrite)
                     {
                         sSQL = "SELECT UserID FROM " + TBN_Import_BF_User + " GROUP BY (UserID) HAVING COUNT(UserID) > 1";
                         int iCurrentUserID = GetSelectStatementStr(sSQL);
                         if (iCurrentUserID > 0)
                         {
                             ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgDuplicatedUserId") + "\r\n" + "UserID:" + iCurrentUserID.ToString();
                             bolInValid = true;
                         }
                     }
                     if (!bolInValid && !bOverwrite)
                     {
                         sSQL = "SELECT T.UserID FROM " + TBN_Import_BF_User + " AS T INNER JOIN [BF_User] AS U ON T.UserID = U.UserID ";
                         int iCurrentUserID = GetSelectStatementStr(sSQL);
                         if (iCurrentUserID > 0)
                         {
                             ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgDuplicatedUserId") + "\r\n" + "UserID:" + iCurrentUserID.ToString();
                             bolInValid = true;
                         }
                     }
                     if (!bolInValid)
                     {
                         sSQL = "SELECT CardID FROM " + TBN_Import_BF_User + " WHERE (LEN(CardID) <> 10)";
                         int iCurrentUserID = GetSelectStatementStr(sSQL);
                         if (iCurrentUserID > 0)
                         {
                             ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgCardIdLength") + "\r\n" + "CardID:" + iCurrentUserID.ToString();
                             bolInValid = true;
                         }
                     }
                     if (!bolInValid)
                     {
                         if (!bOverwrite)                         
                         {
                             sSQL = "SELECT T.CardID FROM " + TBN_Import_BF_User + " AS T INNER JOIN [BF_User] AS U ON T.CardID = U.CardID ";
                             int iCurrentUserID = GetSelectStatementStr(sSQL);
                             if (iCurrentUserID > 0)
                             {
                                 ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgDuplicatedCardId") + "\r\n" + "CardID:" + iCurrentUserID.ToString();
                                 bolInValid = true;
                             }
                         }
                     }
                     if (!bolInValid)
                     {
                         sSQL = "DELETE [" + TBN_Import_BF_User + "] WHERE (UserID IS NULL) OR (UserID = '')";
                         sqlDatabaseProvider.ExecuteSql(sSQL);
                     }
                     ImportUserToDB(OperationId, TBN_Import_BF_User,bOverwrite, bSync, out SucceedsCounts);
                     if (!bolInValid)
                        return true;
                     return false;

            
        }
        public bool ImportFromXLS(string ImportFilePath,bool bOverwrite,bool bSync, bool bXlsx,int OperationId,out string ErrorMessage,out int SucceedsCounts)
        {
            string sSQL="";
            string strCurrnetSheetCoumnName = "";
            int intColumnIndexDate = 0;
            string strDDL_DateColumn = "";
            string strSqlSelect_ImportToDB = "";
            string strSqlSelect_BF_User = "";
            bool bolInValid = false;
            string strWorkSheetName = "";
            String strConn = "";
            OleDbDataAdapter daImportUser = new OleDbDataAdapter();
            DbDataReader ExcelDr;
            DataSet xlDataSet = new DataSet();
            DataTable xlDataTable = new DataTable();
           // DataSet ds = GetDataFromExcelWithAppointSheetName(ImportFilePath, bXlsx);
            ErrorMessage = "";
            SucceedsCounts = 0;
            if (bXlsx)
            {
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                         "Data Source=" + ImportFilePath + ";" +
                         "Extended Properties=Excel 8.0;";
            }
            else
            {
                strConn = "Microsoft.Jet.OLEDB.4.0;" +
                         "Data Source=" + ImportFilePath + ";" +
                         "Extended Properties=Excel 8.0;";
            }
            OleDbConnection olecnMain = new OleDbConnection(strConn);
            olecnMain.Open();
            DataTable dtSheetName = olecnMain.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            strWorkSheetName = dtSheetName.Rows[0]["TABLE_NAME"].ToString();
            olecnMain.Close();
            daImportUser = new OleDbDataAdapter("SELECT TOP 1 * FROM [" + strWorkSheetName + "]", strConn);
            daImportUser.Fill(xlDataSet);
            DataTable dt = xlDataSet.Tables[0];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName != null)
                {
                    strCurrnetSheetCoumnName = dt.Columns[i].ColumnName;
                    intColumnIndexDate += 1;

                    if (intColumnIndexDate == 1)
                    {
                        if (!strCurrnetSheetCoumnName.ToUpper().Equals("DEPARTMENTNAME"))
                        {
                            strSqlSelect_BF_User += "[";
                            strSqlSelect_BF_User += strCurrnetSheetCoumnName;
                            strSqlSelect_BF_User += "]";


                        }
                        strSqlSelect_ImportToDB += "[";
                        strSqlSelect_ImportToDB += strCurrnetSheetCoumnName;
                        strSqlSelect_ImportToDB += "]";

                        strDDL_DateColumn += "[";
                        strDDL_DateColumn += strCurrnetSheetCoumnName;
                        strDDL_DateColumn += "] [NVARCHAR] (64) NULL";
                    }
                    else
                    {
                        if (!strCurrnetSheetCoumnName.ToUpper().Equals("DEPARTMENTNAME"))
                        {
                            strSqlSelect_BF_User += ", [";
                            strSqlSelect_BF_User += strCurrnetSheetCoumnName;
                            strSqlSelect_BF_User += "]";


                        }
                        strSqlSelect_ImportToDB += ", [";
                        strSqlSelect_ImportToDB += strCurrnetSheetCoumnName;
                        strSqlSelect_ImportToDB += "]";

                        strDDL_DateColumn += ", [";
                        strDDL_DateColumn += strCurrnetSheetCoumnName;
                        strDDL_DateColumn += "] [NVARCHAR] (64) NULL";
                    }
                }

            }
            //start
            
            if (!bolInValid)
            {
                sSQL = "TRUNCATE TABLE [TMP_BF_User_196]";
            //    sSQL = "IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TBN_Import_BF_User + "]') AND type in (N'U')) " +
            //"DROP TABLE [dbo].[" + TBN_Import_BF_User +"] " +
            //"CREATE TABLE [dbo].[" + TBN_Import_BF_User + "] (" + strDDL_DateColumn +
            //" )";

            
                sqlDatabaseProvider.ExecuteSql(sSQL);
            }
            if (!bolInValid)
            {
                sSQL = "Select " + strSqlSelect_ImportToDB +" FROM [" + strWorkSheetName + "] ";
                OleDbCommand ExcelCmd = new OleDbCommand();
                
                ExcelCmd.CommandText = sSQL ;
                ExcelCmd.CommandType = CommandType.Text;
                ExcelCmd.Connection = olecnMain;
                olecnMain.Open();
                try
                {

                    ExcelDr = ExcelCmd.ExecuteReader(CommandBehavior.CloseConnection);
                    SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
                    using( SqlBulkCopy BulkCopy = new SqlBulkCopy(cn)) 
                    {
                        BulkCopy.DestinationTableName = TBN_Import_BF_User ;  
                        BulkCopy.WriteToServer(ExcelDr);
                    }
                     ExcelDr.Close();
                     ExcelCmd.Dispose();
                     olecnMain.Close();
                    //UserID 长度检查
                     if (!bolInValid )
                     {
                         sSQL = "SELECT UserID FROM " + TBN_Import_BF_User + " WHERE (LEN(UserID) > 16)";
                         int iCurrentUserID = GetSelectStatementStr(sSQL);
                         if ( iCurrentUserID > 0)
                         {
                             ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgUserIdLength") + "\r\n" + "UserID:" + iCurrentUserID.ToString();
                             bolInValid = true;
                         }
                     }
                    //UserID重复性检查
                     if ( !bolInValid && !bOverwrite)
                     {
                         sSQL = "SELECT UserID FROM " + TBN_Import_BF_User + " GROUP BY (UserID) HAVING COUNT(UserID) > 1";
                         int iCurrentUserID = GetSelectStatementStr(sSQL);
                         if (iCurrentUserID > 0)
                         {
                             ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgDuplicatedUserId") + "\r\n" + "UserID:" + iCurrentUserID.ToString();
                             bolInValid = true;
                         }
                     }
                     if (!bolInValid && !bOverwrite)
                     {
                         sSQL = "SELECT T.UserID FROM " + TBN_Import_BF_User + " AS T INNER JOIN [BF_User] AS U ON T.UserID = U.UserID ";
                         int iCurrentUserID = GetSelectStatementStr(sSQL);
                         if (iCurrentUserID > 0)
                         {
                             ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgDuplicatedUserId") + "\r\n" + "UserID:" + iCurrentUserID.ToString();
                             bolInValid = true;
                         }
                     }
                     if (!bolInValid)
                     {
                         sSQL = "SELECT CardID FROM " + TBN_Import_BF_User + " WHERE (LEN(CardID) <> 10)";
                         int iCurrentUserID = GetSelectStatementStr(sSQL);
                         if (iCurrentUserID > 0)
                         {
                             ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgCardIdLength") + "\r\n" + "CardID:" + iCurrentUserID.ToString();
                             bolInValid = true;
                         }
                     }
                     if (!bolInValid)
                     {
                         if (!bOverwrite)                         
                         {
                             sSQL = "SELECT T.CardID FROM " + TBN_Import_BF_User + " AS T INNER JOIN [BF_User] AS U ON T.CardID = U.CardID ";
                             int iCurrentUserID = GetSelectStatementStr(sSQL);
                             if (iCurrentUserID > 0)
                             {
                                 ErrorMessage = LanguageResource.GetDisplayString("ErrorMsgDuplicatedCardId") + "\r\n" + "CardID:" + iCurrentUserID.ToString();
                                 bolInValid = true;
                             }
                         }
                     }
                     if (!bolInValid)
                     {
                         sSQL = "DELETE [" + TBN_Import_BF_User + "] WHERE (UserID IS NULL) OR (UserID = '')";
                         sqlDatabaseProvider.ExecuteSql(sSQL);
                     }
                     ImportUserToDB(OperationId, TBN_Import_BF_User,bOverwrite, bSync, out SucceedsCounts);
                     if (!bolInValid)
                        return true;
                     return false;
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
                
            

           
            }
            return false;
        }
        private void ImportUserToDB(int OperationId, string TBN_Import_BF_User,bool bOverwrite,bool bSync, out int ImportCounts)
        {
            string sSQL = "";
            bool bolInValid = false;
           // int intCurrentUserSID;

            ImportCounts = 0;
            if (!bolInValid)
            {
                sSQL = " INSERT INTO [BF_Department] "
                + "(DepartmentID, DepartmentName ) "
                + "SELECT I.DepartmentID, I.DepartmentName "
                + "FROM [" + TBN_Import_BF_User + "] AS I LEFT JOIN [BF_Department] AS D "
                 + "ON I.DepartmentID = D.DepartmentID "
                + "WHERE (D.DepartmentID IS NULL) "
                + "GROUP BY I.DepartmentID, I.DepartmentName ";

                ImportCounts = sqlDatabaseProvider.ExecuteSql(sSQL);
            }
            ArrayList SQLStringList = new ArrayList();
            if (bOverwrite)
            {
                sSQL = "UPDATE [BF_User] SET UserID = T.UserID, UserName = T.UserName, DepartmentID = T.DepartmentID " +
                       "FROM " + TBN_Import_BF_User + " AS T INNER JOIN [BF_User] AS U ON T.CardID = U.CardID ";
                SQLStringList.Add(sSQL);
                sSQL = "UPDATE [DS_BF_User_Add] SET IsReplicated = 0 " +
                       "FROM " + TBN_Import_BF_User + " AS T INNER JOIN [DS_BF_User_Add] AS U ON T.CardID = U.CardID ";
                SQLStringList.Add(sSQL);
                sSQL = "DELETE [" + TBN_Import_BF_User + "] FROM " + TBN_Import_BF_User + " AS T INNER JOIN [BF_User] AS U ON T.CardID = U.CardID  WHERE U.CardID <>  '' ";
                SQLStringList.Add(sSQL);
                sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
            }
                         

            sSQL = "SELECT ShiftCode FROM [BF_WorkShift] WHERE (IsDefault = 1) ";
            string  strShiftCodeDefault = GetSelectStatementStr(sSQL).ToString();
            SQLStringList.Clear();
            sSQL = "INSERT INTO [BF_User] "
           + "(UserAddNewSID, UserID, UserName, DepartmentID, CardID, ValidDate, AllowTimeStartHour, AllowTimeStartMinute, AllowTimeEndHour, AllowTimeEndMinute ) "
           + "SELECT " + OperationId.ToString() + " , UserID, UserName, DepartmentID, CardID, ValidDate, AllowTimeStartHour, AllowTimeStartMinute, AllowTimeEndHour, AllowTimeEndMinute "
                       + "FROM [" + TBN_Import_BF_User +"] ";
            SQLStringList.Add(sSQL);

            
                         
            string intInActive = "";
            if (bSync)
            {
                intInActive = "1";
            }
            else
            {
                intInActive = "0";
            }
            sSQL = "INSERT INTO [DS_BF_User_Add] " +
                 "(UserSID, CardID, SlaveSID, InActive, UserAddNewSID) " +
                 "SELECT U.UserSID, U.CardID, S.SlaveSID," +  intInActive + ", U.UserAddNewSID " +
                     "FROM ([BF_User] AS U INNER JOIN [" + TBN_Import_BF_User + "] AS T " +
                     "ON U.UserID = T.UserID), [S_SlaveIP] AS S " +
                 "ORDER BY U.UserSID, S.SlaveSID ";
            SQLStringList.Add(sSQL);
            for (int i = 1; i < 8; i++)
            {
                sSQL = "INSERT INTO [BF_UserWeeklyShift] " +
                         "SELECT U.UserSID, " + i.ToString() + " AS WeekdayNo, '" + strShiftCodeDefault + "' AS ShiftCode, NULL AS ShiftCode_2nd " +
                         "FROM [BF_User] AS U INNER JOIN [" + TBN_Import_BF_User + "] AS T " +
                            "ON U.UserID = T.UserID ";
                SQLStringList.Add(sSQL);
            }
            sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
            //sSQL = "TRUNCATE TABLE [" + TBN_Import_BF_User + "]";
            //sqlDatabaseProvider.ExecuteSql(sSQL);
        }
        #endregion
        #region Public Stored Procedure
        #region Device 
        private int SP_Delete_BFX_UserSlaveAllowTime_BySlaveSID(int SlaveSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[1];

            sqlPara[0] = new SqlParameter("@SlaveSID", SqlDbType.Int);
            sqlPara[0].Value = SlaveSID;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_Delete_BFX_UserSlaveAllowTime_BySlaveSID", sqlPara, out rowsAffect);
        }
        private int SP_Delete_BFX_UserSlaveAddSync_BySlaveID(int SlaveSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[1];

            sqlPara[0] = new SqlParameter("@SlaveSID", SqlDbType.Int);
            sqlPara[0].Value = SlaveSID;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_Delete_BFX_UserSlaveAddSync_BySlaveSID", sqlPara, out rowsAffect);
        }
        private int SP_DELETE_S_SlaveIP_BySlaveSID(int SlaveSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[1];

            sqlPara[0] = new SqlParameter("@SlaveSID", SqlDbType.Int);
            sqlPara[0].Value = SlaveSID;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_DELETE_S_SlaveIP_BySlaveSID", sqlPara, out rowsAffect);
        }
        private int SP_Insert_DS_BF_User_Add_AfterAddSlave(int SlaveSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[1];

            sqlPara[0] = new SqlParameter("@SlaveSID", SqlDbType.Int);
            sqlPara[0].Value = SlaveSID;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_Insert_DS_BF_User_Add_AfterAddSlave", sqlPara, out rowsAffect);
        }
        private int SP_IsExist_SlaveIP_SlaveSID(int SlaveSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[1];

            sqlPara[0] = new SqlParameter("@SlaveSID", SqlDbType.Int);
            sqlPara[0].Value = SlaveSID;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_IsExist_SlaveIP_SlaveSID", sqlPara, out rowsAffect);
        }
        private int SP_IsExist_SlaveIP_IP(string ip, int SlaveSID, out int ReturnID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlParaIn = new SqlParameter[2];

            sqlParaIn[0] = new SqlParameter("@IP", SqlDbType.NVarChar, 15);
            sqlParaIn[0].Value = ip;

            sqlParaIn[1] = new SqlParameter("@ExcludeID", SqlDbType.Int);
            sqlParaIn[1].Value = SlaveSID;

            SqlParameter[] sqlParaOut = new SqlParameter[1];
            sqlParaOut[0] = new SqlParameter("@ReturnID", SqlDbType.Int);
            sqlParaOut[0].Direction = ParameterDirection.Output;

            ReturnID = 0;
            int iRet = DataBase.RunProcedure(cn, "SP_IsExist_SlaveIP_IP", sqlParaIn, sqlParaOut);
            try
            {
                ReturnID = Convert.ToInt32(sqlParaOut[0].Value);
            }
            catch
            {

            }

            return iRet;
        }
        #endregion
        #region Employees
        #region Update
        private int SP_DS_Update_UserAdd_SetAllSlaveToZero_ExceptNegativeMask(int UserSID, int OperatorSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[2];

            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;
            sqlPara[1] = new SqlParameter("@OperatorSID", SqlDbType.Int);
            sqlPara[1].Value = OperatorSID;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_DS_Update_UserAdd_SetAllSlaveToZero_ExceptNegativeMask", sqlPara, out rowsAffect);
        }
        #endregion
        #region Insert
        private int SP_Insert_BF_WorkCalendar_WhenNewUserOnThisMonth(int UserSID,int YearValue,int MonthValue,int OperatorSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[4];

            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;
            sqlPara[1] = new SqlParameter("@Year", SqlDbType.SmallInt);
            sqlPara[1].Value = YearValue;
            sqlPara[2] = new SqlParameter("@Month", SqlDbType.SmallInt);
            sqlPara[2].Value = MonthValue;
            sqlPara[3] = new SqlParameter("@OperatorSID", SqlDbType.Int);
            sqlPara[3].Value = OperatorSID;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_Insert_BF_WorkCalendar_WhenNewUserOnThisMonth", sqlPara, out rowsAffect);
        }
        private int SP_DS_Insert_User_Add_NewUser(int UserSID,int OperatorSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[2];

            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;
            sqlPara[1] = new SqlParameter("@OperatorSID", SqlDbType.Int);
            sqlPara[1].Value = OperatorSID;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_DS_Insert_User_Add_NewUser", sqlPara, out rowsAffect);
        }
       
        private int SP_Insert_User_DefaultWorkShift(int UserSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[1];

            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_Insert_User_DefaultWorkShift", sqlPara, out rowsAffect);
        }
        private int SP_IsExist_User_UserID(string UserID, out int UserSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlParaIn = new SqlParameter[1];

            sqlParaIn[0] = new SqlParameter("@UserID", SqlDbType.NVarChar, 12);
            sqlParaIn[0].Value = UserID;

            SqlParameter[] sqlParaOut = new SqlParameter[1];
            sqlParaOut[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlParaOut[0].Direction = ParameterDirection.Output;

            UserSID = 0;
            int iRet = DataBase.RunProcedure(cn, "SP_IsExist_User_UserID", sqlParaIn, sqlParaOut);
            try
            {
                UserSID = Convert.ToInt32(sqlParaOut[0].Value);
            }
            catch
            {

            }

            return iRet;
        }
        private int SP_IsExist_User_CardID(string CardID, out int UserSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlParaIn = new SqlParameter[1];

            sqlParaIn[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
            sqlParaIn[0].Value = CardID;

            SqlParameter[] sqlParaOut = new SqlParameter[1];
            sqlParaOut[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlParaOut[0].Direction = ParameterDirection.Output;

            UserSID = 0;
            int iRet = DataBase.RunProcedure(cn, "SP_IsExist_User_CardID", sqlParaIn, sqlParaOut);
            try
            {
                UserSID = Convert.ToInt32(sqlParaOut[0].Value);
            }
            catch
            {

            }

            return iRet;
        }
        #endregion
        #region Delete
        private int SP_DS_Delete_User_ForceDelete(int UserSID, int OperatorSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            sqlPara[1] = new SqlParameter("@OperatorSID", SqlDbType.Int);
            sqlPara[1].Value = OperatorSID;

            return DataBase.RunProcedure(cn, "SP_DS_Delete_User_ForceDelete", sqlPara, out rowsAffect);
        }
        private int SP_DS_Delete_FP_FPNo(string CardID, int FPNo)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
            sqlPara[0].Value = CardID;

            sqlPara[1] = new SqlParameter("@FPNo", SqlDbType.Int);
            sqlPara[1].Value = FPNo;

            return DataBase.RunProcedure(cn, "SP_DS_Delete_FP_FPNo", sqlPara, out rowsAffect);
        }
        private int SP_IsVaild_User_Delete(int UserSID, out int TranSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlParaIn = new SqlParameter[1];

            sqlParaIn[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlParaIn[0].Value = UserSID;

            SqlParameter[] sqlParaOut = new SqlParameter[1];
            sqlParaOut[0] = new SqlParameter("@TranSID", SqlDbType.Int);
            sqlParaOut[0].Direction = ParameterDirection.Output;

            TranSID = 0;
             int iRet = DataBase.RunProcedure(cn, "SP_IsVaild_User_Delete", sqlParaIn, sqlParaOut);
            try{
            TranSID = Convert.ToInt32(sqlParaOut[0].Value);
            }
            catch
            {
                
            }

            return iRet;

        }
        private int SP_Delete_User_UserWeeklyShift(int UserSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[1];

            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            int rowsAffect = 0;

            return DataBase.RunProcedure(cn, "SP_Delete_User_UserWeeklyShift", sqlPara, out rowsAffect);
        }
        private int SP_Delete_BFX_UserSlaveAddSync_ByUserSID(int UserSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[1];

            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            int rowsAffect = 0;

            return DataBase.RunProcedure(cn, "SP_Delete_BFX_UserSlaveAddSync_ByUserSID", sqlPara, out rowsAffect);
        }
        private int SP_Delete_BFX_UserSlaveAllowTime_ByUserSID(int UserSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[1];

            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            int rowsAffect = 0;

            return DataBase.RunProcedure(cn, "SP_Delete_BFX_UserSlaveAllowTime_ByUserSID", sqlPara, out rowsAffect);
        }
        private int SP_DS_Delete_User_UserSID(int UserSID, int OperatorSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            sqlPara[1] = new SqlParameter("@OperatorSID", SqlDbType.Int);
            sqlPara[1].Value = OperatorSID;

            return DataBase.RunProcedure(cn, "SP_DS_Delete_User_UserSID", sqlPara, out rowsAffect);
        }
        #endregion

        #endregion
        #region Supervisor
        public int SP_GetUserSIDByUserID(string strUserID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@UserID", SqlDbType.NVarChar, 12);
            sqlPara[0].Value = strUserID;

            return DataBase.RunProcedure(cn, "SP_Get_User_UserSID", sqlPara, out rowsAffect);
        }
        public int SP_GetUserPwdByUserSID(int iUserSID, out string getUserPwd)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            SqlParameter[] sqlParaIn = new SqlParameter[1];
            sqlParaIn[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlParaIn[0].Value = iUserSID;

            SqlParameter[] sqlParaOut = new SqlParameter[1];
            sqlParaOut[0] = new SqlParameter("@UserPWD", SqlDbType.NVarChar, 128);
            sqlParaOut[0].Direction = ParameterDirection.Output;

            int iRet = DataBase.RunProcedure(cn, "SP_Get_User_UserPWD", sqlParaIn, sqlParaOut);
            getUserPwd = sqlParaOut[0].Value.ToString();
            return iRet;
        }

        public int SP_Update_BF_Department_SupervisorSID(string DepartmentID, int SupervisorSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[2];
            sqlPara[0] = new SqlParameter("@DepartmentID", SqlDbType.NVarChar, 10);
            sqlPara[0].Value = DepartmentID;

            sqlPara[1] = new SqlParameter("@SupervisorSID", SqlDbType.Int);
            sqlPara[1].Value = SupervisorSID;

            return DataBase.RunProcedure(cn, "SP_Update_BF_Department_SupervisorSID", sqlPara, out rowsAffect);
        }
        public int SP_Get_BF_Department_DepartmentSID(string DepartmentID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@DepartmentID", SqlDbType.NVarChar, 10);
            sqlPara[0].Value = DepartmentID;



            return DataBase.RunProcedure(cn, "SP_Get_BF_Department_DepartmentSID", sqlPara, out rowsAffect);

        }
        public int SP_IsValid_Department_Delete(string DepartmentId)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@DepartmentID", SqlDbType.NVarChar, 10);
            sqlPara[0].Value = DepartmentId;

            return DataBase.RunProcedure(cn, "SP_IsValid_Department_Delete", sqlPara, out rowsAffect);
        }
        #endregion
        
        #endregion

    }

}
