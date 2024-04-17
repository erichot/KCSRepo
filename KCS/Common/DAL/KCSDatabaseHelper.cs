using KCS.Common.DAL.Constants;
using KCS.Common.Utils;
using KCS.Models;
using LINQtoCSV;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Data.Common;
using System.Data.OleDb;
using System.Data;
//using System.Data.SqlClient;
//using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;

using KCS.Extensions;

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

        #region TimeAttendance
        /*
         * –查询SQL库中是否存在数据库 
        select COUNT(*) from master..sysdatabases where name=N’REPORT’;

        –表名是否存在

        select COUNT(*) from dbo.sysobjects where id = object_id(N’[dbo].[REPORT]’) and OBJECTPROPERTY(id, N’IsUserTable’) =1

        —判断要创建的存储过程名是否存在

        select count(*) from dbo.sysobjects where id = object_id(N’[dbo].[存储过程名]’) and OBJECTPROPERTY(id, N’IsProcedure’) = 1

        –判断视图是否存在 
        select COUNT(*) from dbo.sysobjects where id = object_id(N’[dbo].[视图名]’) and OBJECTPROPERTY(id, N’IsView’) = 1

        –函数名是否存在

        select * from sysobjects where xtype=’fn’ and name=’函数名’

        select * from dbo.sysobjects where id = object_id(N’[dbo].[函数名]’) and xtype in (N’FN’, N’IF’, N’TF’))

        –drop function [dbo].[函数名]
         * */
        public int IsTableColumnExist(string tablename, string columnname)
        {
            string SqlCommand = string.Format("select count(name) from syscolumns where id=(select id from sysobjects where name='{0}') and name='{1}'", tablename, columnname);
            object obj = sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand);
            return Convert.ToInt32(obj);
        }
        public bool IsViewExist(string viewname)
        {
            string SqlCommand = string.Format("select COUNT(*) as ViewNum from sysobjects where id=object_id(N'{0}') and OBJECTPROPERTY(id,N'IsView')=1", viewname);
            DataTable dt = sqlDatabaseProvider.ExcuteTable(SqlCommand);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["ViewNum"]) > 0)
                    return true;


            }

            return false;
        }
        public bool IsFunctionExist(string funcname)
        {
            string SqlCommand = string.Format("select COUNT(*) as FuncNum from sysobjects where id=object_id(N'{0}') ", funcname);
            DataTable dt = sqlDatabaseProvider.ExcuteTable(SqlCommand);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["FuncNum"]) > 0)
                    return true;


            }

            return false;
        }
        public bool IsStoreProcedureExist(string StoreProcedureName)
        {
            string SqlCommand = string.Format("select COUNT(*) as FuncNum from sysobjects  WHERE  xtype = 'P' and id=object_id(N'{0}') ", StoreProcedureName);
            DataTable dt = sqlDatabaseProvider.ExcuteTable(SqlCommand);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["FuncNum"]) > 0)
                    return true;


            }

            return false;
        }
        public bool IsTableExist(string tablename)
        {
            string SqlCommand = string.Format("select COUNT(*) as TableNum from sysobjects where id=object_id(N'{0}') and OBJECTPROPERTY(id,N'IsUserTable')=1", tablename);
            DataTable dt = sqlDatabaseProvider.ExcuteTable(SqlCommand);
           
            if (dt != null && dt.Rows.Count > 0)
            {
                if (Convert.ToInt32(dt.Rows[0]["TableNum"]) > 0)
                    return true;
                

            }
            
            return false;
        }
        public bool CreateTable(string createcommand)
        {
            
            return sqlDatabaseProvider.ExecuteSql(createcommand) > 0 ? true : false;
        }
        public bool CreateFunction(string createcommand)
        {

            return sqlDatabaseProvider.ExecuteSql(createcommand) > 0 ? true : false;
        }
        #endregion
        #region SQL Statements
        private const string SUPERVISOR_LISTFIELD_SQL = "select ListField from [VBF_Supervisor]";
        private const string SUPERVISOR_LISTALL_SQL = "SELECT UserSID,UserID, UserName,Email, PhoneMobile,A.DepartmentID,UserPermissionTypeID,IsReadOnly AS EmployeeAuthority,Note,B.ListField AS DepartmentList FROM [VBF_Supervisor] AS A Left join [VBF_Department] AS B ON A.DepartmentID=B.DepartmentID";
        private const string DEPARTMENT_LISTFIELD_SQL = "SELECT [DepartmentID], [ListField] FROM [VBF_Department] ORDER BY [DepartmentID]";
        private const string DEPARTMENT_LIST_SQL = "SELECT [DepartmentSID],[DepartmentID], [DepartmentName],[SupervisorSID] FROM [BF_Department] where InActive=0 ORDER BY [DepartmentSID] ";
        private const string ELEVATOR_LISTFIELD_SQL = "SELECT EleavatorID,A.SlaveSID,EleavatorName,EleavatorDes,SlaveName,SlaveDescription FROM ElevatorControl as A left join S_SlaveIP as B on A.SlaveSID = B.SlaveSID";
#if FOR_DEMO
        private const string EMPLOYEES_LIST_SQL = "SELECT top 10 UserSID,UserID,  DepartmentID, DepartmentName, UserName, A.CardID, TitleName, InActive,UserPWD,NotPropagateToSlaveByDefault as SyncOrNot,AllowTimeStartHour, AllowTimeStartMinute, AllowTimeEndHour, AllowTimeEndMinute,  IsTaOrNot,   EmployeeTypeID, EmployeeTypeName, Email,ValidDate,PhoneMobile ,ISNULL(B.FPNo,0) as Finger1,ISNULL(C.FPNo,0) AS Finger2 FROM [VBF_User] AS A left join (select CardID,FPNo from [BF_FP] where FPNo=1) AS B on A.CardID = B.CardID left join (select CardID,FPNo from [BF_FP] where FPNo=2) AS C on A.CardID = C.CardID order by UserID";
        private const string EMPLOYEES_BRIEF_LIST_SQL = "SELECT top 10 UserSID,UserID,  A.DepartmentID, B.DepartmentName, UserName, CardID,[ShiftCategory]  FROM [BF_User] AS A LEFT JOIN [BF_Department] AS B ON A.DepartmentID=B.DepartmentID order by UserID";
        private const string EMPLOYEES_MSG_LIST_SQL = "SELECT top 10 UserID, UserName, B.DepartmentName FROM [BF_User] AS A LEFT JOIN [BF_Department] AS B ON A.DepartmentID=B.DepartmentID Where A.InActive=0 order by UserID";
        private const string EMPLOYEES_TYPE_LIST_SQL = "SELECT top 10 EmployeeTypeID, EmployeeTypeName, InActive FROM BC_EmployeeType";
        private const string EMPLOYEES_TYPE_LIST_FIELD_SQL = "SELECT top 10 EmployeeTypeID, EmployeeTypeID + ':' +EmployeeTypeName AS ListFiled FROM BC_EmployeeType where InActive =0 order by EmployeeTypeID";
        private const string DEVICES_LIST_SQL = "SELECT top 10 [SlaveSID],  [IP], [IP_Internal], [ListField], [SlaveName], [SlaveDescription], [IsEnabled], [ResetToDefault], [SlaveCategoryID], [SlaveCategoryName], [IsServerMode], NotPropagateWithUsersByDefault FROM [VS_SlaveIP]";
        private const string DEVICES_LIST_FIELD_SQL = "SELECT  top 10 SlaveSID, [IP], [IP_Internal],  [SlaveName], [SlaveDescription] FROM [VS_SlaveIP] where IsEnabled=1 and NotPropagateWithUsersByDefault = 0";
        private const string DEVICE_CATEGEORY_LISTFIELD_SQL = "SELECT top 10 [SlaveCategoryID], [SlaveCategoryName] FROM [BC_SlaveCategory]";
        private const string JOB_CODE_LIST_SQL = "SELECT top 10 [TranType], [JobCode], [JobName], [Remark],[ListField] FROM [VBF_JobCode]";
#else
        private const string EMPLOYEES_LIST_SQL = "SELECT UserSID,UserID,  DepartmentID, DepartmentName, UserName, A.CardID, TitleName, InActive,UserPWD,NotPropagateToSlaveByDefault as SyncOrNot,AllowTimeStartHour, AllowTimeStartMinute, AllowTimeEndHour, AllowTimeEndMinute,  IsTaOrNot,   EmployeeTypeID, EmployeeTypeName, Email,ValidDate,PhoneMobile ,E.RegPhoto AS RegPhoto ,ISNULL(B.FPNo,0) as Finger1,ISNULL(C.FPNo,0) AS Finger2 FROM [VBF_User] AS A left join (select CardID,FPNo from [BF_FP] where FPNo=1) AS B on A.CardID = B.CardID left join (select CardID,FPNo from [BF_FP] where FPNo=2) AS C on A.CardID = C.CardID left join (select CardID,RegPhoto from BF_User) AS E ON A.CardID = E.CardID order by UserID";
        
        // Add:     2024/03/04
        // Ver:     1.1.5.17
        private const string EMPLOYEES_LIST_SQL_WhereDept = "SELECT UserSID,UserID,  DepartmentID, DepartmentName, UserName, A.CardID, TitleName, InActive,UserPWD,NotPropagateToSlaveByDefault as SyncOrNot,AllowTimeStartHour, AllowTimeStartMinute, AllowTimeEndHour, AllowTimeEndMinute,  IsTaOrNot,   EmployeeTypeID, EmployeeTypeName, Email,ValidDate,PhoneMobile ,E.RegPhoto AS RegPhoto ,ISNULL(B.FPNo,0) as Finger1,ISNULL(C.FPNo,0) AS Finger2 FROM [VBF_User] AS A left join (select CardID,FPNo from [BF_FP] where FPNo=1) AS B on A.CardID = B.CardID left join (select CardID,FPNo from [BF_FP] where FPNo=2) AS C on A.CardID = C.CardID left join (select CardID,RegPhoto from BF_User) AS E ON A.CardID = E.CardID WHERE ('{0}' = '' OR A.DepartmentID = '{0}') order by UserID";

        private const string EMPLOYEES_BRIEF_LIST_SQL = "SELECT UserSID,UserID,  A.DepartmentID, B.DepartmentName, UserName, CardID,[ShiftCategory]  FROM [BF_User] AS A LEFT JOIN [BF_Department] AS B ON A.DepartmentID=B.DepartmentID order by UserID";
        private const string EMPLOYEES_MSG_LIST_SQL = "SELECT UserID, UserName, B.DepartmentName FROM [BF_User] AS A LEFT JOIN [BF_Department] AS B ON A.DepartmentID=B.DepartmentID Where A.InActive=0 order by UserID";
        private const string EMPLOYEES_TYPE_LIST_SQL = "SELECT EmployeeTypeID, EmployeeTypeName, InActive FROM BC_EmployeeType";
        private const string EMPLOYEES_TYPE_LIST_FIELD_SQL = "SELECT EmployeeTypeID, EmployeeTypeID + ':' +EmployeeTypeName AS ListFiled FROM BC_EmployeeType where InActive =0 order by EmployeeTypeID";
        private const string DEVICES_LIST_SQL = "SELECT [SlaveSID],  [IP], [IP_Internal], [ListField], [SlaveName], [SlaveDescription], [IsEnabled], [ResetToDefault], [SlaveCategoryID], [SlaveCategoryName], [IsServerMode], NotPropagateWithUsersByDefault,ISNULL(MenuPwd,'') as MenuPwd,ISNULL(WorkMode,0) as WorkMode,ISNULL(Language,0) as Language FROM [S_SlaveIP]";
        private const string DEVICES_LIST_FIELD_SQL = "SELECT  SlaveSID, [IP], [IP_Internal],  [SlaveName], [SlaveDescription] FROM [VS_SlaveIP] where IsEnabled=1 and NotPropagateWithUsersByDefault = 0";
        private const string DEVICE_CATEGEORY_LISTFIELD_SQL = "SELECT [SlaveCategoryID], [SlaveCategoryName] FROM [BC_SlaveCategory]";
        private const string JOB_CODE_LIST_SQL = "SELECT [TranType], [JobCode], [JobName], [Remark],[ListField] FROM [VBF_JobCode]";
#endif
        // DeleteCommand="DELETE FROM [BF_User] WHERE [UserSID] = @UserSID"         
       // UpdateCommand="UPDATE [BF_User] SET [UserID] = @UserID, [DepartmentID] = @DepartmentID, [UserName] = @UserName, [CardID] = @CardID, [TitleName] = @TitleName, [InActive] = @InActive, [IsTaOrNot] = @IsTaOrNot, [Email] = @Email, [UserPWD] = @UserPWD, [UserPin] = @UserPin, [TimeModifyLast] = CURRENT_TIMESTAMP, [TimeModifyLastSID] = @TimeModifyLastSID, [EmployeeTypeID] = @EmployeeTypeID, [NotPropagateToSlaveByDefault] = @NotPropagateToSlaveByDefault  WHERE [UserSID] = @UserSID "
       // SelectCommand="SELECT UserID, ListField, DepartmentID, DepartmentName, UserName, CardID, TitleName, AllowTimeStartHour, AllowTimeStartMinute, AllowTimeEndHour, AllowTimeEndMinute, InActive, IsTaOrNot, UserSID, UserPWD, EmployeeTypeID, EmployeeTypeName, Email, NotPropagateToSlaveByDefault FROM [VBF_User] WHERE (@DepartmentID IS NULL OR DepartmentID = @DepartmentID) AND (@EmployeeTypeID IS NULL OR EmployeeTypeID = @EmployeeTypeID) AND (@UserSID IS NULL OR UserSID = @UserSID) ORDER BY UserID"  
        
       // InsertCommand="INSERT INTO [BF_User] ([UserID], [DepartmentID], [UserName], [CardID], [TitleName], [IsTaOrNot], [Email], [UserPWD], [UserPin], [UserAddNewSID], [EmployeeTypeID], [NotPropagateToSlaveByDefault]) VALUES (@UserID, @DepartmentID, @UserName, @CardID, @TitleName, @IsTaOrNot, @Email, @UserPWD, @UserPin, @UserAddNewSID, @EmployeeTypeID, @NotPropagateToSlaveByDefault);SELECT @UserSID=@@IDENTITY" >
        
        #endregion
        #region KCS Query
        #region Attendance
        #region Transactions 
        public int InsertTransactions(TaTransaction trans, int SupervisorSid)
        {
            string SqlCommand = string.Format("INSERT INTO [OR_Transactions] ([CardID], [TranDateTime], [DataType], [UserAddNewSID], [Original_CardID], [Original_TranDateTime], [Original_DataType], [SlaveIP], [Note]) VALUES ('{0}', '{1}', {2}, {3}, '{0}', '{1}', {2}, '{4}', N'{5}')",
            trans.CardID, trans.TranDateTime.ToString("yyyy-MM-dd HH:mm:ss"), trans.TranType.ToString(), SupervisorSid.ToString(), trans.SlaveIP, trans.Note);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int UpdateTransactions(TaTransaction trans,int SupervisorSid)
        {
            string SqlCommand = string.Format("UPDATE OR_Transactions SET InActive = {0}, TranDateTime = '{1}', DataType = {2}, TranType = {2}, WorkShiftNo = 0, TimeModifyLast = CURRENT_TIMESTAMP, UserModifyLastSID = {3}, Note = '{4}' WHERE (TranSID = {5})",
                trans.InActive ? "1" : "0", trans.TranDateTime.ToString("yyyy-MM-dd HH:mm:ss"), trans.TranType.ToString(), SupervisorSid.ToString(), trans.Note, trans.TranSID.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int GetTaTransactionsCount(List<int> slaveIdList, string start, string end)
        {
            if (slaveIdList.Count <= 0)
                return 0;
            string SqlCommand = string.Format(@"select count(*) AS TransNum from UVALID_TRANSACTIONS_New('{0}','{1}')  WHERE SlaveSID IN(", start, end);
            for (int n = 0; n < slaveIdList.Count; n++)
            {
                SqlCommand += string.Format("{0},", slaveIdList[n].ToString());

            }
            SqlCommand = SqlCommand.TrimEnd(',');
            SqlCommand += ") ";
            using (var sqlDatabaseProvider1 = new SQLDataProvider())
            {
                var objReturn = sqlDatabaseProvider1.ExecuteSqlWitResult(SqlCommand);
                if (objReturn == null)
                    return 0;
                return Convert.ToInt32(objReturn);
            }

           

        }
        public DataTable GetTaTransactionsList(List<int> slaveIdList, string start, string end)
        {
            if (slaveIdList.Count <= 0)
                return null;
            string SqlCommand = string.Format(@"select TOP 200 A.CardId,A.TranDateTime,IsByTranType,TranType,DataType,A.SlaveSID,B.UserID,B.UserName,C.SlaveName from UVALID_TRANSACTIONS_New('{0}','{1}') AS A Left join BF_User AS B ON A.CardID=B.CardID Left join S_SlaveIP as C ON A.SlaveSID=C.SlaveSID WHERE A.SlaveSID IN(", start, end);
            for (int n = 0; n < slaveIdList.Count; n++)
            {
                SqlCommand += string.Format("{0},", slaveIdList[n].ToString());
                
            }
            SqlCommand = SqlCommand.TrimEnd(',');
            SqlCommand += ") ORDER BY  TranDateTime ";
            using (var sqlDatabaseProvider1 = new SQLDataProvider())
            {
                return sqlDatabaseProvider1.ExcuteTable(SqlCommand);
            }
            
        }

        // Modified:     2024/03/04
        // Ver:     1.1.5.17
        //public DataTable GetTaTransactionsList(int SlaveId, string start, string end, int queryCondtion)
        public DataTable GetTaTransactionsList(int SlaveId, string start, string end, int queryCondtion, string _departmentID = null)
        {
            /*// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             * By           Eric
             * Modified:    2023/03/22
             * Ver:         1.1.5.8
             * Note:        刷卡報表重複
             *              queryCondtion=1 篩選排除停用資料
             *              queryCondtion=2 僅篩選停用資料
             */
            //string strSql = "SELECT TranSID, A.CardID,UserID, UserName, DepartmentID,DepartmentName, TranDateTime, TranDate, TranTime"
            //    + ", (CASE WHEN IsByTranType = 1 THEN TranType ELSE DataType END) AS TranType, JobName, ID, SlaveIP, SlaveDescription,InActive,[Note],B.Photos AS TransImage "
            //    + ", DegreeCelsius "
            //    + "FROM VOR_Transactions_SlaveIP_Public AS A LEFT JOIN [TRANS_PHOTO] AS B ON A.SlaveID=B.SlaveSID AND A.CardID=B.CardID AND A.TranDateTime=B.TransTime ";
            //string strSql = "SELECT TranSID, A.CardID,UserID, UserName, DepartmentID,DepartmentName, TranDateTime, TranDate, TranTime"
            //    + ", (CASE WHEN IsByTranType = 1 THEN TranType ELSE DataType END) AS TranType, JobName, ID, SlaveIP, SlaveDescription,InActive,[Note],B.Photos AS TransImage "
            //    + ", DegreeCelsius "
            //    + "FROM VOR_Transactions_SlaveIP_Public AS A LEFT JOIN (" +
            //    "       SELECT B1.Photos, B1.SlaveSID, B1.CardID, B1.TransTime FROM [TRANS_PHOTO] AS B1 INNER JOIN [VOR_TransPhoto] AS B2 ON B1.PhotoID = B2.PhotoID " +
            //    "   ) AS B ON A.SlaveID=B.SlaveSID AND A.CardID=B.CardID AND A.TranDateTime=B.TransTime ";
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // Modified:    2023/12/01 
            // Ver:         1.1.5.15
            // Note:        增加 SlaveID_Public            
            string strSql = "SELECT TranSID, A.CardID,UserID, UserName, DepartmentID,DepartmentName, TranDateTime, TranDate, TranTime"
                + ", (CASE WHEN IsByTranType = 1 THEN TranType ELSE DataType END) AS TranType, JobName, ID, SlaveIP, SlaveIP_Public, SlaveDescription,InActive,[Note],B.Photos AS TransImage "
                + ", DegreeCelsius "
                + "FROM VOR_Transactions_SlaveIP_Public AS A LEFT JOIN (" +
                "       SELECT B1.Photos, B1.SlaveSID, B1.CardID, B1.TransTime FROM [TRANS_PHOTO] AS B1 INNER JOIN [VOR_TransPhoto] AS B2 ON B1.PhotoID = B2.PhotoID " +
                "   ) AS B ON A.SlaveID=B.SlaveSID AND A.CardID=B.CardID AND A.TranDateTime=B.TransTime ";

            string strFormSqlWhere = "where 1=1";
            DateTime RecordDate = Convert.ToDateTime(end);
            end = RecordDate.Year.ToString() + "-" + RecordDate.Month.ToString("D2") + "-" + RecordDate.Day.ToString("D2") + " 23:59:59";
            if (start != null && end != null)
            {
                strFormSqlWhere = string.Format("where TranDateTime BETWEEN '{0}' AND '{1}' ", start, end);
            }

            // Add:     2024/03/04
            // Ver:     1.1.5.17
            if (string.IsNullOrEmpty(_departmentID) == false)
            {
                strFormSqlWhere += $"and DepartmentID = '{_departmentID}'";
            }

            if (SlaveId == 0)
            {
                if (queryCondtion == 1)
                {//active
                    strFormSqlWhere += "and InActive = 0";     
                }
                else if (queryCondtion == 2)
                {//inactive
                    strFormSqlWhere += "and InActive = 1";     
                }         
            }
            else
            {
                
                if (queryCondtion == 1)
                {//active
                    strFormSqlWhere += string.Format("and ID={0} and InActive = 0", SlaveId.ToString());
                }
                else if (queryCondtion == 2)
                {//inactive
                    strFormSqlWhere += string.Format("and ID={0} and InActive = 1", SlaveId.ToString());
                }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                // Note:    2023/11/16
                // Version:     1.1.5.14
                // Note:        Toyota UI修正
                else
                {
                    strFormSqlWhere += string.Format("and ID={0} ", SlaveId.ToString());
                }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
            
            strSql += strFormSqlWhere;
            strSql += " ORDER BY TranSID DESC";
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        #endregion
        int GetAcrossOffsetHour(int StartTimeHour, int StartTimeMinute, int EndTimeHour, int EndTimeMinute )
        {
        //此計算
            int intWorkHours ;
            int intReturnValue ;

        //intWorkHours = (24 - StartTimeHour) + EndTimeHour
        //intReturnValue = StartTimeHour - (12 - (intWorkHours / 2))

        if( StartTimeHour > EndTimeHour )
            //跨夜
            intWorkHours = (24 - StartTimeHour) + EndTimeHour;
        else
            //非跨夜
            intWorkHours = EndTimeHour - StartTimeHour;
        

        intReturnValue = StartTimeHour - (12 - (intWorkHours / 2));

        return intReturnValue;

        }
        public bool UpdateTaHolidaySetting(TaHolidays holidaySet,string holiday)
        {
            string SqlCommand = "";
            if (string.IsNullOrEmpty(holiday))
            {
                SqlCommand = string.Format("INSERT INTO [CHK_HOLIDAY] ([HOLIDAY], [HOLIDAY_DESC], [CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME]) VALUES (N'{0}', N'{1}', N'{2}', '{3}', N'{2}', '{3}')",
                    holidaySet.HOLIDAY, holidaySet.HOLIDAY_DESC, holidaySet.CREATE_NAME, holidaySet.CREATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                SqlCommand = string.Format("UPDATE [CHK_HOLIDAY] SET [HOLIDAY] = N'{0}', [HOLIDAY_DESC] = N'{1}', [BUILD_NAME] = N'{2}', [BUILD_TIME] = '{3}' where [HOLIDAY]=N'{4}'",
                    holidaySet.HOLIDAY, holidaySet.HOLIDAY_DESC, holidaySet.BUILD_NAME, holidaySet.BUILD_TIME.ToString("yyyy-MM-dd HH:mm:ss"), holiday);
            }
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public int UpdateVocationSetting(Vocation vocation)
        {
            string SqlCommand = string.Format("UPDATE [OR_LeaveApplication_Head] SET [Reason] = N'{0}' WHERE [LeaveApplicationHeadSID] = {1}", vocation.LeaveReson, vocation.LeaveApplicationHeadSID.ToString());
            if (sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0)
            {
                //if (SP_DELETE_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(vocation.LeaveApplicationHeadSID) > 0)
                SP_DELETE_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(vocation.LeaveApplicationHeadSID);
                {
                    int iRet1 = SP_INSERT_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(vocation.LeaveApplicationHeadSID, vocation.LeaveType1, vocation.Leave1Hours * 60, true);
                    int iRet2 = SP_INSERT_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(vocation.LeaveApplicationHeadSID, vocation.LeaveType2, vocation.Leave2Hours * 60, true);
                    int iRet3 = SP_INSERT_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(vocation.LeaveApplicationHeadSID, vocation.LeaveType3, vocation.Leave3Hours * 60, true);

                    if (iRet1 > 0 && iRet2 > 0 && iRet3 > 0)
                    {
                        SP_INSERT_REL_LeaveApplication_Justification(vocation.SelectDate, vocation.SelectDate, "", vocation.UserSID);
                        return 1;
                    }


                    return -3;
                }
                return -2;
            }
            return -1;
        }
        public int InsertVocationSetting(Vocation vocation)
        {
            if (SP_GET_OR_LeaveApplication_Head_ByUserSID_Date(vocation.UserSID, vocation.SelectDate) > 0)
            {
                return -1;
            }
            if( vocation.UserSID <= 0 )
            {
                return -2;
            }
            string SqlCommand = string.Format("INSERT INTO [OR_LeaveApplication_Head] ([UserSID], [DateJustification], [Reason], [IsApproved]) VALUES ({0}, '{1}', N'{2}', 1);SELECT  @@IDENTITY",
                vocation.UserSID.ToString(), vocation.SelectDate, vocation.LeaveReson);
            object obj = sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand);
            if (obj != null)
            {
                int intLeaveApplicationHeadSID = Convert.ToInt32(obj);
                int iRet1 = SP_INSERT_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(intLeaveApplicationHeadSID, vocation.LeaveType1, vocation.Leave1Hours*60, true);
                int iRet2 = SP_INSERT_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(intLeaveApplicationHeadSID, vocation.LeaveType2, vocation.Leave2Hours * 60, true);
                int iRet3 = SP_INSERT_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(intLeaveApplicationHeadSID, vocation.LeaveType3, vocation.Leave3Hours * 60, true);

                if (iRet1 > 0 && iRet2 > 0 && iRet3 > 0)
                {
                    SP_INSERT_REL_LeaveApplication_Justification(vocation.SelectDate, vocation.SelectDate, "", vocation.UserSID);
                    return 1;
                }

               
                return -3;
            }
            return -4;
        }
        public bool DeleteVocationSetting(int LeaveApplicationHeadSID)
        {
            ArrayList SQLStringList = new ArrayList();

            SQLStringList.Add(string.Format("DELETE FROM [OR_LeaveApplication_Head] WHERE [LeaveApplicationHeadSID] = {0}", LeaveApplicationHeadSID.ToString()));
            SQLStringList.Add(string.Format("DELETE FROM [OR_LeaveApplication_Detail] WHERE [LeaveApplicationHeadSID] = {0}", LeaveApplicationHeadSID.ToString()));

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
        public bool DeleteTaHolidaySetting(string Holiday)
        {

            string SqlCommand = string.Format("DELETE FROM [CHK_HOLIDAY] WHERE [HOLIDAY] ='{0}'", Holiday);


            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
            
        }
        public DataTable GetTaHolidaySettingList()
        {
            string strSql = string.Format("SELECT * FROM [CHK_HOLIDAY] ");
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public DataTable GetVacationSettingList()
        {
            string strSql = string.Format("SELECT A.[LeaveApplicationHeadSID], B.LeaveApplicationDetailSID,C.DepartmentID,C.DepartmentName,C.EmployeeTypeID,C.EmployeeTypeName,CAST(A.[DateJustification] AS NVARCHAR(10)) AS DateJustification, A.[UserSID], A.[UserID], A.[UserName], A.[Reason],"
                    + "B.LeaveTypeID, B.LeaveTypeName, B.LeaveMinute FROM [VOR_LeaveApplication_Head] AS A " 
                    + "left join VOR_LeaveApplication_Justification AS B ON A.LeaveApplicationHeadSID=B.LeaveApplicationHeadSID left join VBF_User AS C on A.UserSID=C.UserSID "
                    + "ORDER BY UserID, DateJustification ,LeaveApplicationDetailSID ASC");
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public DataTable GetCalendarSettingsList()
        {
            string strSql = string.Format("SELECT * FROM [CHK_CALENDAR]");
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public DataTable GetLeaveTypeList()
        {
            string strSql = string.Format("SELECT * FROM [CHK_LEAVE]");
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public int CheckLeaveItemDetails(string leaveNum)
        {
            string strSql = string.Format("SELECT count(*) FROM PER_LEAVE_D WHERE [NUM]='{0}'", leaveNum);
            var objReturn = sqlDatabaseProvider.ExecuteSqlWitResult(strSql);
            if (objReturn == null)
                return 0;
            return Convert.ToInt32(objReturn);
        }
        public bool DeleteLeaveItemDetails(string leaveNum)
        {
            string SqlCommand = string.Format("DELETE FROM [PER_LEAVE_D] WHERE [NUM] ='{0}'", leaveNum);

            return sqlDatabaseProvider.ExecuteSql(SqlCommand)>0?true:false;
        }
        public DataTable GetLeaveItemDetailsList(string leaveNum)
        {
            string SqlCommand = string.Format("select * from [PER_LEAVE_D] where [NUM]='{0}'", leaveNum);
            return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }
        public bool DeleteLeaveItem(string leaveNum)
        {
            ArrayList SQLStringList = new ArrayList();
            SQLStringList.Add(string.Format("DELETE FROM [PER_LEAVE_D] WHERE [NUM] ='{0}'", leaveNum));
            SQLStringList.Add(string.Format("DELETE FROM [PER_LEAVE] WHERE [NUM] ='{0}'", leaveNum));
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
        public int ConfirmLeaveItem(PerLeaveItem leavItem)
        {
            string SqlCommand = string.Format("UPDATE [PER_LEAVE] SET [STATUS]='B',[CFM_NAME] = N'{1}',[CFM_TIME]='{2}' where [NUM]='{0}'", leavItem.NUM, leavItem.CFM_NAME, leavItem.CFM_TIME_Str);

            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int CancelLeaveItem(string leavNum)
        {
            string SqlCommand = string.Format("UPDATE [PER_LEAVE] SET [STATUS]='C',[CFM_TIME]='' where [NUM]='{0}'", leavNum);

            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int InsertLeaveItem(PerLeaveItem leavItem)
        {
            string SqlCommand = string.Format("select * from [PER_LEAVE] where [NUM]='{0}'", leavItem.NUM);

            DateTime dtStart = Convert.ToDateTime(leavItem.LEAVE_TIME1);
            DateTime dtEnd = Convert.ToDateTime(leavItem.LEAVE_TIME2);
            

            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
            {
                SqlCommand = string.Format("UPDATE [PER_LEAVE] SET [USE_DATE]='{0}',[EMP_CODE]=N'{1}', [LEAVE_CODE]=N'{2}',[LEAVE_DATE1]='{3}',[LEAVE_DATE2]='{4}',[LEAVE_TIME1]='{5}',[LEAVE_TIME2]='{6}',[SUM_TIME]={11},[AGENT]='{7}',[BUILD_NAME] = N'{8}',[BUILD_TIME]=N'{9}' WHERE [NUM] = '{10}'",
                    leavItem.USE_DATE.ToShortDateString(), leavItem.EMP_CODE, leavItem.LEAVE_CODE, leavItem.LEAVE_DATE1_STR, leavItem.LEAVE_DATE2_STR, dtStart.ToString("HH:mm"), dtEnd.ToString("HH:mm"), leavItem.AGENT,
                    leavItem.BUILD_NAME, leavItem.BUILD_TIME.ToString("yyyy-MM-dd HH:mm:ss"), leavItem.NUM);
            }
            else
            {//[CFM_NAME],[CFM_TIME], 'A',/*'','',
                SqlCommand = string.Format(@"INSERT INTO [PER_LEAVE] ([NUM],[USE_DATE],[EMP_CODE],[SPHOLIDAY],[OVERDAY],[LEAVE_CODE],[LEAVE_DATE1],[LEAVE_DATE2],[LEAVE_TIME1],[LEAVE_TIME2],[SUM_TIME],[AGENT],[STATUS],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME]) VALUES (
                                            '{0}','{12}',N'{1}',0,0,N'{2}','{3}','{4}','{5}','{6}',{13},'{7}','A','{8}','{9}','{10}','{11}')", leavItem.NUM, leavItem.EMP_CODE, leavItem.LEAVE_CODE, leavItem.LEAVE_DATE1_STR, leavItem.LEAVE_DATE2_STR,
                                                                                 dtStart.ToString("HH:mm"), dtEnd.ToString("HH:mm"), leavItem.AGENT,
                                                                                 leavItem.CREATE_NAME, leavItem.CREATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"), leavItem.BUILD_NAME, leavItem.BUILD_TIME.ToString("yyyy-MM-dd HH:mm:ss"), leavItem.USE_DATE.ToShortDateString(),leavItem.SUM_TIME);

            }

            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int UpdateLeaveDetail(PerLeaveItemDetail leavItemDetails)
        {
            string SqlCommand = string.Format("UPDATE PER_LEAVE_D SET [SUM_TIME]={0} WHERE [NUM]='{1}' AND [SN]={2}", leavItemDetails.SUM_TIME.ToString(),
                leavItemDetails.NUM, leavItemDetails.SN.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int InsertLeaveItemDetails(PerLeaveItemDetail leavItemDetails)
        {
            string SqlCommand = string.Format("INSERT INTO PER_LEAVE_D ([NUM],[SN],[LEAVE_DATE],[TURN_HOUR],[SUM_TIME],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME]) VALUES ('{0}',{1},'{2}',{3},{4},N'{5}','{6}',N'{7}','{8}')",
                leavItemDetails.NUM, leavItemDetails.SN.ToString(), leavItemDetails.LEAVE_DATE_STR, leavItemDetails.TURN_HOUR.ToString(), leavItemDetails.SUM_TIME.ToString(),
                leavItemDetails.CREATE_NAME, leavItemDetails.CREATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"), leavItemDetails.BUILD_NAME, leavItemDetails.BUILD_TIME.ToString("yyyy-MM-dd HH:mm:ss"));
           
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public DataTable CheckPerCheckExistOrNot(string empCode, string dateStart, string dateEnd)
        {
            string SqlCommand = string.Format("select EMP_CODE,CHK_DATE,ISNULL(LIST_GRP,0) AS LIST_GRP,WORK_TIME_START,WORK_TIME_END,RELAX_TIME1,RELAX_TIME2,RELAX_TIME3,RELAX_TIME4,[TURN_TIME] from VPER_CHK where EMP_CODE=N'{0}' AND CHK_DATE>='{1}' AND CHK_DATE <= '{2}'", empCode, dateStart, dateEnd);
            return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }
        public DataTable GetLeaveItemDetails()
        {
            return sqlDatabaseProvider.ExcuteTable("SELECT * FROM PER_LEAVE_D");
        }
        public DataTable GetLeaveItems()
        {
            return sqlDatabaseProvider.ExcuteTable(@"select [NUM],[USE_DATE],[EMP_CODE],[SPHOLIDAY],[OVERDAY],[LEAVE_CODE],[LEAVE_DATE1],[LEAVE_DATE2],convert(char(5),[LEAVE_TIME1],108) AS LEAVE_TIME1,convert(char(5),[LEAVE_TIME2],108) AS LEAVE_TIME2,
                                                [SUM_TIME],[AGENT],[STATUS],[CFM_NAME],[CFM_TIME],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME],B.UserName AS EMP_NAME from [PER_LEAVE] AS A Left Join BF_User AS B ON A.EMP_CODE = B.UserID");
        }
        public string GetLeavNum(int year, int month)
        {
            string strSql = string.Format("SELECT MAX(NUM) FROM PER_LEAVE WHERE [NUM] Like 'LE{0}{1}%'", string.Format("{0:D2}", (year % 100)), string.Format("{0:D2}", month));
            var objReturn = sqlDatabaseProvider.ExecuteSqlWitResult(strSql);
            if (objReturn == null)
                return "";
            return Convert.ToString(objReturn);
        }
        public DataTable GetWorkShiftList()
        {
            string strSql = string.Format(@"select [CLASS_CODE],[CLASS_DESC],
                convert(char(5),[WORK_TIME_START],108) as WORK_TIME_START, 
                convert(char(5),[WORK_TIME_END],108) as WORK_TIME_END,
                convert(char(5),[WORK_TIME_LATE],108) as WORK_TIME_LATE,
                convert(char(5),[WORK_TIME_OVERTIME],108) as WORK_TIME_OVERTIME,
                [TURN_OVERTIME],
                convert(char(5),[RELAX_TIME1],108) as RELAX_TIME1,
                convert(char(5),[RELAX_TIME2],108) as RELAX_TIME2,
                convert(char(5),[RELAX_TIME3],108) as RELAX_TIME3,
                convert(char(5),[RELAX_TIME4],108) as RELAX_TIME4,
                [TURN_TIME],
                [CREATE_NAME],
                [CREATE_TIME],
                [BUILD_NAME],
                [BUILD_TIME],[CLASS_AMT],[LEAVE_CK],[LEAVE_HOURS]
                from [CHK_CLASS]");
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public DataTable GetTrunWorkBaseList()
        {
            string strSql = string.Format("SELECT '' as TURNWORK_GRP,'' as TURNWORK_DESC from [CHK_TURNWORK] union  SELECT TURNWORK_GRP,TURNWORK_DESC from CHK_TURNWORK");
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        
        public DataTable GetTrunWorkList()
        {
            string strSql = string.Format("SELECT * from CHK_TURNWORK");
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public DataTable GetAllWorkShiftList()
        {
            string strSql = string.Format("SELECT [CLASS_CODE], [CLASS_DESC],convert(char(5),[WORK_TIME_START],108) as WORK_TIME_START,convert(char(5),[WORK_TIME_END],108) as WORK_TIME_END FROM [CHK_CLASS]");
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public int DeleteWorkShift(string shiftCode)
        {
            string SqlCommand = string.Format("DELETE FROM [CHK_CLASS] WHERE [CLASS_CODE] = '{0}'", shiftCode);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int UpdateMonthlyWorkShift(WorkCalendar workMonthlyShift)
        {
            string SqlCommand = string.Format("UPDATE BF_WorkCalendar SET ShiftCode = '{0}', Note = N'{1}' WHERE (UserSID = {2}) AND (Year = {3}) AND (Month = {4}) AND (Day ={5})",
                workMonthlyShift.ShiftCode, workMonthlyShift.Note, workMonthlyShift.UserSID.ToString(), workMonthlyShift.Year.ToString(), workMonthlyShift.Month.ToString(), workMonthlyShift.Day.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public bool DeleteLeaveType(TaLeaveType leaveType)
        {
            string SqlCommand = string.Format("DELETE FROM [CHK_LEAVE] WHERE [LEAVE_CODE] ='{0}'", leaveType.LEAVE_CODE);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool AddLeaveType(TaLeaveType leaveType)
        {
            string SqlCommand = string.Format("select * from CHK_LEAVE where LEAVE_CODE='{0}'", leaveType.LEAVE_CODE);
            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
            {
                SqlCommand = string.Format("UPDATE [CHK_LEAVE] SET [LEAVE_DESC] = N'{0}', [BUILD_NAME] = N'{1}',[BUILD_TIME]=N'{2}' WHERE [LEAVE_CODE] = '{3}'", leaveType.LEAVE_DESC, leaveType.BUILD_NAME, leaveType.BUILD_TIME, leaveType.LEAVE_CODE);
            }
            else
            {
                SqlCommand = string.Format("INSERT INTO [CHK_LEAVE] ([LEAVE_CODE],[LEAVE_DESC],[CUT_MODE], [CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME],[CUT_ABS]) VALUES (N'{0}',  N'{1}', 1,N'{2}','{3}',N'{2}','{3}',0)", leaveType.LEAVE_CODE,leaveType.LEAVE_DESC,
                    leaveType.CREATE_NAME, leaveType.CREATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"), leaveType.BUILD_NAME, leaveType.BUILD_TIME.ToString("yyyy-MM-dd HH:mm:ss"));

            }

            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool DeleteFromShiftTable(string shifttable)
        {
            string SqlCommand = string.Format("DELETE FROM [CHK_TURNWORK] WHERE [TURNWORK_GRP] =N'{0}'", shifttable);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool UpdateShiftTable(object source, object newone)
        {
            var sourceShiftItem = source as TrunWork;
            var newShiftItem = newone as TrunWork;

            string SqlCommand = "";
            if (source == null || string.IsNullOrEmpty(sourceShiftItem.TURNWORK_GRP))
            {//Insert
                SqlCommand = string.Format(@"INSERT INTO [CHK_TURNWORK] ([TURNWORK_GRP],[TURNWORK_DESC],[CLASS_CODE1],[CLASS_CODE2],[CLASS_CODE3],[CLASS_CODE4],[CLASS_CODE5],[CLASS_CODE6],[CLASS_CODE7],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME]) VALUES (N'{0}',  N'{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}',N'{9}',N'{10}',N'{9}',N'{10}')", 
                    newShiftItem.TURNWORK_GRP, newShiftItem.TURNWORK_DESC, newShiftItem.CLASS_CODE1, newShiftItem.CLASS_CODE2,
                                     newShiftItem.CLASS_CODE3, newShiftItem.CLASS_CODE4, newShiftItem.CLASS_CODE5, newShiftItem.CLASS_CODE6, newShiftItem.CLASS_CODE7,
                                     newShiftItem.CREATE_NAME, newShiftItem.CREATE_TIME.ToString("yyyy-MM-dd HH:mm:ss"));

            }
            else
            {//Update
                SqlCommand = string.Format(@"UPDATE [CHK_TURNWORK] SET [TURNWORK_GRP] = N'{0}', [TURNWORK_DESC] = N'{1}',[CLASS_CODE1]='{2}',[CLASS_CODE2]='{3}',[CLASS_CODE3]='{4}',[CLASS_CODE4]='{5}',[CLASS_CODE5]='{6}',[CLASS_CODE6]='{7}',[CLASS_CODE7]='{8}',[BUILD_NAME]=N'{9}',[BUILD_TIME]=N'{10}' WHERE [TURNWORK_GRP] = N'{11}'",
                    newShiftItem.TURNWORK_GRP, newShiftItem.TURNWORK_DESC, newShiftItem.CLASS_CODE1, newShiftItem.CLASS_CODE2, newShiftItem.CLASS_CODE3,
                    newShiftItem.CLASS_CODE4, newShiftItem.CLASS_CODE5, newShiftItem.CLASS_CODE6, newShiftItem.CLASS_CODE7, newShiftItem.BUILD_NAME,
                    newShiftItem.BUILD_TIME.ToString("yyyy-MM-dd HH:mm:ss"), sourceShiftItem.TURNWORK_GRP);
       
            }
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        //出勤报表
        //出勤报表 日报表
        //a
        //开始 结束 日期报表
        public DataTable GetMonthlyAttendanceReportSimplified(string startDate, string endDate, bool byTransType, IEnumerable<EmployeeBrief> employeesObject)
        {
            string SqlCommand = "";


if (byTransType)
            {//仅计算考勤记录\
                SqlCommand = string.Format(@"select Convert(CHAR(10),TAT.CHK_DATE,102)  as CheckDateString,TAT.DepartmentName,TAT.CardID,TAT.EMP_CODE,TAT.CheckDay ,TAT.UserName,convert(char(5),TAT.OnDutyTime1,108) as OnDutyTime,convert(char(5),TAT.OffDutyTime1,108) as OffDutyTime,
            
--加班时间
case  when  TAT.LIST_GRP is null then
case when TAT.WORK_TIME_OVERTIME is null or OffDutyTime1 is null or OnDutyTime1 is null then
null
else
case when TAT.WORK_TIME_START < TAT.WORK_TIME_END then
case when DATEDIFF(mi,Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108), OffDutyTime1)>0 then 
case when TAT.TURN_OVERTIME = 0.5 then
cast(DATEDIFF(mi,  Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)/30.0 as int)*0.5
else
DATEDIFF(hh, Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)
end 
else
null
end

else -- span night
case when DATEDIFF(mi,Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108), OffDutyTime1)>0 then 
case when TAT.TURN_OVERTIME = 0.5 then
cast(DATEDIFF(mi,  Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)/30.0 as int)*0.5
else
DATEDIFF(hh, Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)
end 
else
null
end
end
end
else
case  when TAT.LEAVE_CODE is not null then
null
else
case when TAT.OffDutyTime1 <= TAT.OnDutyTime1 then
null
else
cast(DATEDIFF(mi,  OnDutyTime1,OffDutyTime1)/30.0 as int)*0.5
end
end
end AS OverTime
 from (select * from (select UA.CHK_DATE,UA.LIST_GRP,UA.EMP_CODE,UserName, 
day(UA.CHK_DATE) AS CheckDay,
case when UA.WORK_TIME_START < UA.WORK_TIME_END or UA.LIST_GRP is not null then
UI.TranDateTime
else 
case when UIS.EntriesNum = 1 then
case when abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_END,108),convert(char(5),UIS.TranDateTime,108)))>=abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_START,108),convert(char(5),UIS.TranDateTime,108))) then
UIS.TranDateTime
else
null
end
else
UIS.TranDateTime
end
end AS OnDutyTime1,convert(char(5),[RELAX_TIME1],108) as [RELAX_TIME1],convert(char(5),[RELAX_TIME2],108) as [RELAX_TIME2],
Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),[RELAX_TIME1],108) AS [RELAX_TIME11],
case when RELAX_TIME1 <= RELAX_TIME2 then
Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),[RELAX_TIME2],108) 
else
Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),[RELAX_TIME2],108)
end AS [RELAX_TIME21],

case when UA.WORK_TIME_START < UA.WORK_TIME_END or UA.LIST_GRP is not null then
case when UO.TranDateTime <> UI.TranDateTime then UO.TranDateTime
else null
end 
else--跨夜
case when UOS.TranDateTime is null then 
case when UO.TranDateTime <> UIS.TranDateTime then UO.TranDateTime
else null
end 
else
case when UOS.EntriesNum = 1 then
case when abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_END,108),convert(char(5),UOS.TranDateTime,108)))<abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_START,108),convert(char(5),UOS.TranDateTime,108))) then
UOS.TranDateTime
else
null
end
else
case when UOS.TranDateTime <> UIS.TranDateTime then UOS.TranDateTime
else null
end
end
end
end
 AS OffDutyTime1,
UL.LEAVE_CODE,
UL.LEAVE_DESC,UL.SUM_TIME AS LeaveTime,
UA.WORK_TIME_START,
UA.WORK_TIME_END,
UI.TranDateTime as TranDateTimeIn,
UO.TranDateTime as TranDateTimeOut,
UIS.TranDateTime as TranDateTimeInS,
UOS.TranDateTime as TranDateTimeOutS,
UA.WORK_TIME_LATE,
 UA.TURN_TIME,
 UA.WORK_TIME_OVERTIME,
 UA.TURN_OVERTIME,
 UA.DepartmentName,
            UA.CardID,
 case when UA.WORK_TIME_START <= UA.WORK_TIME_LATE then 
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_LATE,108)
 else
 Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),WORK_TIME_LATE,108) 
 end AS WORK_TIME_LATE1,
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_START,108) AS WORK_TIME_START1,

 case when UA.WORK_TIME_START < UA.WORK_TIME_END then 
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_END,108)
 else
 Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),WORK_TIME_END,108) 
 end AS WORK_TIME_END1
 from UPER_CHECK_SECTION('{0}','{1}') AS UA
Left join (select CardId,min(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') WHERE (((IsByTranType = 1) AND (TranType = 0 OR TranType = 161 OR TranType = 16  OR TranType = 96))    OR ((IsByTranType = 0) AND (DataType= 1 )) ) group by CardId,convert(varchar(10),TranDateTime,120))
AS UI ON UA.CardID=UI.CardID AND UA.CHK_DATE=UI.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,max(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') WHERE (((IsByTranType = 1) AND (TranType = 1 OR TranType = 162 OR TranType = 17  OR TranType = 97))    OR ((IsByTranType = 0) AND (DataType = 2)) ) group by CardId,convert(varchar(10),TranDateTime,120))
AS UO ON UA.CardID=UO.CardID AND UA.CHK_DATE=UO.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,min(TranDateTime) AS TranDateTime,convert(varchar(10),dateadd(dd,-1,TranDateTime),120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') WHERE (((IsByTranType = 1) AND (TranType = 1 OR TranType = 162 OR TranType = 17  OR TranType = 97))    OR ((IsByTranType = 0) AND (DataType = 2)) ) group by CardId,convert(varchar(10),dateadd(dd,-1,TranDateTime),120))
AS UOS ON UA.CardID=UOS.CardID AND UA.CHK_DATE=UOS.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,max(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') WHERE (((IsByTranType = 1) AND (TranType = 0 OR TranType = 161 OR TranType = 16  OR TranType = 96))    OR ((IsByTranType = 0) AND (DataType= 1 )) ) group by CardId,convert(varchar(10),TranDateTime,120))
AS UIS ON UA.CardID=UIS.CardID AND UA.CHK_DATE=UIS.CHK_DATE
Left Join (select LEAVE_DATE,EMP_CODE,LEAVE_CODE,LEAVE_DESC,LEAVE_TIME1,LEAVE_TIME2,SUM_TIME from  UPER_LEAVE_ITEMS ('{0}','{1}')) AS UL
ON UA.EMP_CODE = UL.EMP_CODE AND UA.CHK_DATE=UL.LEAVE_DATE) AS DD where DD.EMP_CODE IN( 
", startDate, endDate, endDate+" 23:59:59");
            }
            else
            {
                SqlCommand = string.Format(@"select Convert(CHAR(10),TAT.CHK_DATE,102)  as CheckDateString,TAT.DepartmentName,TAT.CardID,TAT.EMP_CODE,TAT.CheckDay ,TAT.UserName,convert(char(5),TAT.OnDutyTime1,108) as OnDutyTime,convert(char(5),TAT.OffDutyTime1,108) as OffDutyTime,
            
--加班时间
case  when  TAT.LIST_GRP is null then
case when TAT.WORK_TIME_OVERTIME is null or OffDutyTime1 is null or OnDutyTime1 is null then
null
else
case when TAT.WORK_TIME_START < TAT.WORK_TIME_END then
case when DATEDIFF(mi,Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108), OffDutyTime1)>0 then 
case when TAT.TURN_OVERTIME = 0.5 then
cast(DATEDIFF(mi,  Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)/30.0 as int)*0.5
else
DATEDIFF(hh, Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)
end 
else
null
end

else -- span night
case when DATEDIFF(mi,Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108), OffDutyTime1)>0 then 
case when TAT.TURN_OVERTIME = 0.5 then
cast(DATEDIFF(mi,  Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)/30.0 as int)*0.5
else
DATEDIFF(hh, Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)
end 
else
null
end
end
end
else
case  when TAT.LEAVE_CODE is not null then
null
else
case when TAT.OffDutyTime1 <= TAT.OnDutyTime1 then
null
else
cast(DATEDIFF(mi,  OnDutyTime1,OffDutyTime1)/30.0 as int)*0.5
end
end
end AS OverTime
 from (select * from (select UA.CHK_DATE,UA.LIST_GRP,UA.EMP_CODE,UserName, 
day(UA.CHK_DATE) AS CheckDay,
case when UA.WORK_TIME_START < UA.WORK_TIME_END or UA.LIST_GRP is not null then
UI.TranDateTime
else 
case when UIS.EntriesNum = 1 then
case when abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_END,108),convert(char(5),UIS.TranDateTime,108)))>=abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_START,108),convert(char(5),UIS.TranDateTime,108))) then
UIS.TranDateTime
else
null
end
else
UIS.TranDateTime
end
end AS OnDutyTime1,convert(char(5),[RELAX_TIME1],108) as [RELAX_TIME1],convert(char(5),[RELAX_TIME2],108) as [RELAX_TIME2],
Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),[RELAX_TIME1],108) AS [RELAX_TIME11],
case when RELAX_TIME1 <= RELAX_TIME2 then
Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),[RELAX_TIME2],108) 
else
Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),[RELAX_TIME2],108)
end AS [RELAX_TIME21],

case when UA.WORK_TIME_START < UA.WORK_TIME_END or UA.LIST_GRP is not null then
case when UO.TranDateTime <> UI.TranDateTime then UO.TranDateTime
else null
end 
else--跨夜
case when UOS.TranDateTime is null then 
case when UO.TranDateTime <> UIS.TranDateTime then UO.TranDateTime
else null
end 
else
case when UOS.EntriesNum = 1 then
case when abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_END,108),convert(char(5),UOS.TranDateTime,108)))<abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_START,108),convert(char(5),UOS.TranDateTime,108))) then
UOS.TranDateTime
else
null
end
else
case when UOS.TranDateTime <> UIS.TranDateTime then UOS.TranDateTime
else null
end
end
end
end
 AS OffDutyTime1,
UL.LEAVE_CODE,
UL.LEAVE_DESC,UL.SUM_TIME AS LeaveTime,
UA.WORK_TIME_START,
UA.WORK_TIME_END,
UI.TranDateTime as TranDateTimeIn,
UO.TranDateTime as TranDateTimeOut,
UIS.TranDateTime as TranDateTimeInS,
UOS.TranDateTime as TranDateTimeOutS,
UA.WORK_TIME_LATE,
 UA.TURN_TIME,
 UA.WORK_TIME_OVERTIME,
 UA.TURN_OVERTIME,
UA.DepartmentName,
            UA.CardID,
 case when UA.WORK_TIME_START <= UA.WORK_TIME_LATE then 
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_LATE,108)
 else
 Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),WORK_TIME_LATE,108) 
 end AS WORK_TIME_LATE1,
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_START,108) AS WORK_TIME_START1,

 case when UA.WORK_TIME_START < UA.WORK_TIME_END then 
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_END,108)
 else
 Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),WORK_TIME_END,108) 
 end AS WORK_TIME_END1
 from UPER_CHECK_SECTION('{0}','{1}') AS UA
Left join (select CardId,min(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') group by CardId,convert(varchar(10),TranDateTime,120))
AS UI ON UA.CardID=UI.CardID AND UA.CHK_DATE=UI.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,max(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') group by CardId,convert(varchar(10),TranDateTime,120))
AS UO ON UA.CardID=UO.CardID AND UA.CHK_DATE=UO.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,min(TranDateTime) AS TranDateTime,convert(varchar(10),dateadd(dd,-1,TranDateTime),120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') group by CardId,convert(varchar(10),dateadd(dd,-1,TranDateTime),120))
AS UOS ON UA.CardID=UOS.CardID AND UA.CHK_DATE=UOS.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,max(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') group by CardId,convert(varchar(10),TranDateTime,120))
AS UIS ON UA.CardID=UIS.CardID AND UA.CHK_DATE=UIS.CHK_DATE
Left Join (select LEAVE_DATE,EMP_CODE,LEAVE_CODE,LEAVE_DESC,LEAVE_TIME1,LEAVE_TIME2,SUM_TIME from  UPER_LEAVE_ITEMS ('{0}','{1}')) AS UL
ON UA.EMP_CODE = UL.EMP_CODE AND UA.CHK_DATE=UL.LEAVE_DATE) AS DD where DD.EMP_CODE IN( 
", startDate, endDate, endDate + " 23:59:59");
            }
/*
foreach (EmployeeBrief employee in employeesObject)
{
    SqlCommand += "'" + employee.UserID + "',";
}
SqlCommand = SqlCommand.TrimEnd(',');
SqlCommand += ") ) as TAT  order by EMP_CODE ASC ";
 * */
            
SqlCommand += "select [UserID] as EMP_CODE from [BF_User] where [UserID] IN("; 
 foreach (EmployeeBrief employee in employeesObject)
{
    SqlCommand += "'" + employee.UserID + "',";
}
SqlCommand = SqlCommand.TrimEnd(',');
SqlCommand += ") AND (TimeLastLogout IS NULL  or ( TimeLastLogout IS not NULL and DATEDIFF(dd,convert(varchar(10),TimeLastLogout,120),'";
SqlCommand +=   startDate;
SqlCommand += "')<0))) ) as TAT order by EMP_CODE ASC,CheckDay ASC ";

return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }
        public DataTable GetMonthlyAttendanceReportDetails(string startDate, string endDate, bool byTransType, IEnumerable<EmployeeBrief> employeesObject)
        {
            string SqlCommand = "";
            if (byTransType)
            {//仅计算考勤记录\ Convert(CHAR(10),TAT.CHK_DATE,102)
                SqlCommand = string.Format(@"select concat(MONTH(CHK_DATE),'.',DAY(CHK_DATE))  as CheckDateString,case when TAT.LIST_GRP is not null then CD.LIST_MEMO else '' end AS LIST_GRPString ,TAT.DepartmentName,TAT.EMP_CODE,TAT.UserName,TAT.CheckDay ,convert(char(5),TAT.OnDutyTime1,108) as OnDutyTime,TAT.RELAX_TIME1,TAT.RELAX_TIME2,convert(char(5),TAT.OffDutyTime1,108) as OffDutyTime,TAT.LEAVE_CODE,TAT.LEAVE_DESC,TAT.LeaveTime,


-- 迟到时间
case  when TAT.LEAVE_CODE is  null and TAT.LIST_GRP is null then
case  when TAT.WORK_TIME_START is not null and TAT.OnDutyTime1 is not null and TAT.OffDutyTime1 is not null and DATEDIFF(mi,TAT.WORK_TIME_START1,TAT.OnDutyTime1)>0 then
case --
when DATEDIFF(mi,TAT.WORK_TIME_LATE1,TAT.OnDutyTime1)<0 then --比设定上班时间晚，迟到
case 
when TAT.WORK_TIME_LATE is not null and DATEDIFF(mi,TAT.WORK_TIME_LATE1,TAT.OnDutyTime1)>=0 then --旷职时间设置不为空，并且刷卡时间迟于旷职时间
null --算旷职，不算迟到
else  
DATEDIFF(mi,TAT.WORK_TIME_START1,TAT.OnDutyTime1)  --迟到时间
end --迟到判断结束
else --刷卡时间早于设定上班时间
null 
end --比设定上班时间晚 
else
null
end 
else
null
end AS LateMins,
-- 早退时间
case  when  TAT.LIST_GRP is null then
case
when OffDutyTime1 is null OR TAT.WORK_TIME_END is null or OnDutyTime1 is null or OnDutyTime1 >= OffDutyTime1 or DATEDIFF(mi,OffDutyTime1,TAT.WORK_TIME_END1)>=30 then 
null
else
--早退计算
case when DATEDIFF(mi,TAT.WORK_TIME_END1, OffDutyTime1)>=0 then
null
else
DATEDIFF(mi, OffDutyTime1,TAT.WORK_TIME_END1)
end
--早退计算结束
end  
else
null
end AS LeaveEarlyMins,

--出勤时数
case  when  TAT.LIST_GRP is null then
case when OnDutyTime1 is null OR OffDutyTime1 is null or OnDutyTime1>=OffDutyTime1  then 
null
else

case when DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1) <= 0 then
 --小于上班时间，不考虑早上旷职 和迟到
 case when DATEDIFF(mi, TAT.WORK_TIME_END1,OffDutyTime1) < 0 then
 --小于下班时间，
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1)))/30.0 as int)*0.5  
  
else
case when  DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0 then
case when  DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)>=0 then 
cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5
else
cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)))/30.0 as int)*0.5 
end
else
cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1)))/30.0 as int)*0.5 
end
end
 
 else
 --大于下班时间
--正常
TAT.TURN_TIME/60

 --大于下班时间
 end 
 else
 --大于上班时间
  
  case when DATEDIFF(mi, TAT.WORK_TIME_END1,OffDutyTime1) < 0 then
 --小于下班时间
 case when DATEDIFF(mi, TAT.WORK_TIME_LATE1,OnDutyTime1) >= 0 then
 --算旷职
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1)))/30.0 as int)*0.5  - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)>=0 then --开始时间 在休息时间之外
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)<0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0 then --开始时间 正常 结束时间在休息时间内
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)  ))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)<= 0 then --开始时间 正常 结束时间在休息时间内

abs(cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)<0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.OnDutyTime1,TAT.OffDutyTime1))/30.0 as int)*0.5 )
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)>=0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.OffDutyTime1))/30.0 as int)*0.5 )
else
null
end

 else
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1)))/30.0 as int)*0.5  - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)>=0 then --开始时间 在休息时间之外
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5 - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)<0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0then --开始时间 正常 结束时间在休息时间内
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)  ))/30.0 as int)*0.5 - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)<= 0 then --开始时间 正常 结束时间在休息时间内

abs(cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1))/30.0 as int)*0.5 - 0.5)
when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)<0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.OnDutyTime1,TAT.OffDutyTime1))/30.0 as int)*0.5-0.5 )
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)>=0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.OffDutyTime1))/30.0 as int)*0.5 -0.5)
else
null
 end
 end
--- 小于上班结束

 else
 --大于下班时间
 case when DATEDIFF(mi, TAT.WORK_TIME_LATE1,OnDutyTime1) >= 0 then
 --算旷职
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1)))/30.0 as int)*0.5  - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, WORK_TIME_END1)>=0 then --开始时间 在休息时间之外
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, WORK_TIME_END1)<0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0then --开始时间 正常 结束时间在休息时间内
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)  ))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, WORK_TIME_END1)<= 0 then --开始时间 正常 结束时间在休息时间内

abs(cast((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)<0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.OnDutyTime1,TAT.WORK_TIME_END1))/30.0 as int)*0.5 )
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)>=0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1))/30.0 as int)*0.5 )
else
null
end

 else
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1)))/30.0 as int)*0.5  - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, WORK_TIME_END1)>=0 then --开始时间 在休息时间之外
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5 - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, WORK_TIME_END1)<0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0 then --开始时间 正常 结束时间在休息时间内
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)  ))/30.0 as int)*0.5 - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, WORK_TIME_END1)<= 0 then --开始时间 正常 结束时间在休息时间内

abs(cast((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1))/30.0 as int)*0.5 - 0.5)
when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)<0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.OnDutyTime1,TAT.WORK_TIME_END1))/30.0 as int)*0.5 - 0.5)
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)>=0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1))/30.0 as int)*0.5- 0.5 )
else
null
 end
 end
 --大于下班结束
 end 
  
 -- 大于上班时间 end
 end 
end 
else
null
end AS TurnTime,

--旷职时间 AbsentTime
case  when TAT.LEAVE_CODE is null and TAT.LIST_GRP is null then
case when TAT.WORK_TIME_LATE is null  OR TAT.WORK_TIME_START is null then --1
null
else--12
 case when OffDutyTime1 is null  or OnDutyTime1 is null or OnDutyTime1 >= OffDutyTime1 then --22
TAT.TURN_TIME/60
else 
case when DATEDIFF(mi,TAT.WORK_TIME_LATE1, OnDutyTime1)>=0 or DATEDIFF(mi,OffDutyTime1,TAT.WORK_TIME_END1)>=30 then --33
case when DATEDIFF(mi, TAT.WORK_TIME_LATE1,OnDutyTime1) < 0 then --44
case when DATEDIFF(mi,OffDutyTime1,TAT.WORK_TIME_END1)>=30 then --旷职
case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then --12333
 cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5
 else
 case when DATEDIFF(mi,OffDutyTime1,TAT.RELAX_TIME21)>= 0 then
case when DATEDIFF(mi,OffDutyTime1,TAT.RELAX_TIME11)>= 0 then
cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29-ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0))/30.0 as int)*0.5 
else
cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5
end
else
cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5
 end
 
 
 end --12333
 else
 null
 end
else --早上旷职
case when DATEDIFF(mi,OffDutyTime1,TAT.WORK_TIME_END1)>=30 then --旷职
case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then --Relex
cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5 + cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5
when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)>=0 then --开始时间 在休息时间之外
cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5 + cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)<0 then --开始时间 正常 结束时间在休息时间内
cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5 + cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5

  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)<= 0 then --开始时间 正常 结束时间在休息时间内

cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5 + cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5

else
TAT.TURN_TIME/60
 end --Relex
else
case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then 
cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5
else
case when DATEDIFF(mi,OnDutyTime1,TAT.RELAX_TIME21)> 0 then
case when DATEDIFF(mi,OnDutyTime1,TAT.RELAX_TIME11)<= 0 then
cast((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)+29)/30.0 as int)*0.5
else
cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5
end
else
cast((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.OnDutyTime1)+29-ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0))/30.0 as int)*0.5
end
end
end
end --44
else
null
end --33
end --22
end --12
else --1
null
end AS AbsentHours,
--加班时间
case  when  TAT.LIST_GRP is null then
case when TAT.WORK_TIME_OVERTIME is null or OffDutyTime1 is null or OnDutyTime1 is null then
null
else
case when TAT.WORK_TIME_START < TAT.WORK_TIME_END then
case when DATEDIFF(mi,Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108), OffDutyTime1)>0 then 
case when TAT.TURN_OVERTIME = 0.5 then
cast(DATEDIFF(mi,  Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)/30.0 as int)*0.5
else
DATEDIFF(hh, Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)
end 
else
null
end

else -- span night
case when DATEDIFF(mi,Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108), OffDutyTime1)>0 then 
case when TAT.TURN_OVERTIME = 0.5 then
cast(DATEDIFF(mi,  Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)/30.0 as int)*0.5
else
DATEDIFF(hh, Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)
end 
else
null
end
end
end
else
case  when TAT.LEAVE_CODE is not null then
null
else
case when TAT.OffDutyTime1 <= TAT.OnDutyTime1 then
null
else
cast(DATEDIFF(mi,  OnDutyTime1,OffDutyTime1)/30.0 as int)*0.5
end
end
end AS OverTime
 from (select * from (select UA.CHK_DATE,UA.LIST_GRP,UA.EMP_CODE,UserName, 
day(UA.CHK_DATE) AS CheckDay,
case when UA.WORK_TIME_START < UA.WORK_TIME_END or UA.LIST_GRP is not null then
UI.TranDateTime
else 
case when UIS.EntriesNum = 1 then
case when abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_END,108),convert(char(5),UIS.TranDateTime,108)))>=abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_START,108),convert(char(5),UIS.TranDateTime,108))) then
UIS.TranDateTime
else
null
end
else
UIS.TranDateTime
end
end AS OnDutyTime1,convert(char(5),[RELAX_TIME1],108) as [RELAX_TIME1],convert(char(5),[RELAX_TIME2],108) as [RELAX_TIME2],
Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),[RELAX_TIME1],108) AS [RELAX_TIME11],
case when RELAX_TIME1 <= RELAX_TIME2 then
Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),[RELAX_TIME2],108) 
else
Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),[RELAX_TIME2],108)
end AS [RELAX_TIME21],

case when UA.WORK_TIME_START < UA.WORK_TIME_END or UA.LIST_GRP is not null then
case when UO.TranDateTime <> UI.TranDateTime then UO.TranDateTime
else null
end 
else--跨夜
case when UOS.TranDateTime is null then 
case when UO.TranDateTime <> UIS.TranDateTime then UO.TranDateTime
else null
end 
else
case when UOS.EntriesNum = 1 then
case when abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_END,108),convert(char(5),UOS.TranDateTime,108)))<abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_START,108),convert(char(5),UOS.TranDateTime,108))) then
UOS.TranDateTime
else
null
end
else
case when UOS.TranDateTime <> UIS.TranDateTime then UOS.TranDateTime
else null
end
end
end
end
 AS OffDutyTime1,
UL.LEAVE_CODE,
UL.LEAVE_DESC,UL.SUM_TIME AS LeaveTime,
UA.WORK_TIME_START,
UA.WORK_TIME_END,
UI.TranDateTime as TranDateTimeIn,
UO.TranDateTime as TranDateTimeOut,
UIS.TranDateTime as TranDateTimeInS,
UOS.TranDateTime as TranDateTimeOutS,
UA.WORK_TIME_LATE,
 UA.TURN_TIME,
 UA.WORK_TIME_OVERTIME,
 UA.TURN_OVERTIME,
UA.DepartmentName,
 case when UA.WORK_TIME_START <= UA.WORK_TIME_LATE then 
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_LATE,108)
 else
 Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),WORK_TIME_LATE,108) 
 end AS WORK_TIME_LATE1,
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_START,108) AS WORK_TIME_START1,

 case when UA.WORK_TIME_START < UA.WORK_TIME_END then 
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_END,108)
 else
 Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),WORK_TIME_END,108) 
 end AS WORK_TIME_END1
 from UPER_CHECK_SECTION('{0}','{1}') AS UA
Left join (select CardId,min(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') WHERE (((IsByTranType = 1) AND (TranType = 0 OR TranType = 161 OR TranType = 16  OR TranType = 96))    OR ((IsByTranType = 0) AND (DataType= 1 )) ) group by CardId,convert(varchar(10),TranDateTime,120))
AS UI ON UA.CardID=UI.CardID AND UA.CHK_DATE=UI.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,max(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') WHERE (((IsByTranType = 1) AND (TranType = 1 OR TranType = 162 OR TranType = 17  OR TranType = 97))    OR ((IsByTranType = 0) AND (DataType = 2)) ) group by CardId,convert(varchar(10),TranDateTime,120))
AS UO ON UA.CardID=UO.CardID AND UA.CHK_DATE=UO.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,min(TranDateTime) AS TranDateTime,convert(varchar(10),dateadd(dd,-1,TranDateTime),120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') WHERE (((IsByTranType = 1) AND (TranType = 1 OR TranType = 162 OR TranType = 17  OR TranType = 97))    OR ((IsByTranType = 0) AND (DataType = 2)) ) group by CardId,convert(varchar(10),dateadd(dd,-1,TranDateTime),120))
AS UOS ON UA.CardID=UOS.CardID AND UA.CHK_DATE=UOS.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,max(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') WHERE (((IsByTranType = 1) AND (TranType = 0 OR TranType = 161 OR TranType = 16  OR TranType = 96))    OR ((IsByTranType = 0) AND (DataType= 1 )) ) group by CardId,convert(varchar(10),TranDateTime,120))
AS UIS ON UA.CardID=UIS.CardID AND UA.CHK_DATE=UIS.CHK_DATE
Left Join (select LEAVE_DATE,EMP_CODE,LEAVE_CODE,LEAVE_DESC,LEAVE_TIME1,LEAVE_TIME2,SUM_TIME from  UPER_LEAVE_ITEMS ('{0}','{1}')) AS UL
ON UA.EMP_CODE = UL.EMP_CODE AND UA.CHK_DATE=UL.LEAVE_DATE) AS DD where DD.EMP_CODE IN( 
", startDate, endDate, endDate+" 23:59:59");
            }
            else
            {
                SqlCommand = string.Format(@"select concat(MONTH(CHK_DATE),'.',DAY(CHK_DATE)) as CheckDateString,case when TAT.LIST_GRP is not null then CD.LIST_MEMO else '' end AS LIST_GRPString,TAT.DepartmentName,TAT.EMP_CODE,TAT.UserName,TAT.CheckDay ,convert(char(5),TAT.OnDutyTime1,108) as OnDutyTime,TAT.RELAX_TIME1,TAT.RELAX_TIME2,convert(char(5),TAT.OffDutyTime1,108) as OffDutyTime,TAT.LEAVE_CODE,TAT.LEAVE_DESC,TAT.LeaveTime,


-- 迟到时间
case  when TAT.LEAVE_CODE is  null and TAT.LIST_GRP is null then
case  when TAT.WORK_TIME_START is not null and TAT.OnDutyTime1 is not null and TAT.OffDutyTime1 is not null and DATEDIFF(mi,TAT.WORK_TIME_START1,TAT.OnDutyTime1)>0 then
case --
when DATEDIFF(mi,TAT.WORK_TIME_LATE1,TAT.OnDutyTime1)<0 then --比设定上班时间晚，迟到
case 
when TAT.WORK_TIME_LATE is not null and DATEDIFF(mi,TAT.WORK_TIME_LATE1,TAT.OnDutyTime1)>=0 then --旷职时间设置不为空，并且刷卡时间迟于旷职时间
null --算旷职，不算迟到
else  
DATEDIFF(mi,TAT.WORK_TIME_START1,TAT.OnDutyTime1)  --迟到时间
end --迟到判断结束
else --刷卡时间早于设定上班时间
null 
end --比设定上班时间晚 
else
null
end 
else
null
end AS LateMins,
-- 早退时间
case  when  TAT.LIST_GRP is null then
case
when OffDutyTime1 is null OR TAT.WORK_TIME_END is null or OnDutyTime1 is null or OnDutyTime1 >= OffDutyTime1 or DATEDIFF(mi,OffDutyTime1,TAT.WORK_TIME_END1)>=30 then 
null
else
--早退计算
case when DATEDIFF(mi,TAT.WORK_TIME_END1, OffDutyTime1)>=0 then
null
else
DATEDIFF(mi, OffDutyTime1,TAT.WORK_TIME_END1)
end
--早退计算结束
end  
else
null
end AS LeaveEarlyMins,

--出勤时数
case  when  TAT.LIST_GRP is null then
case when OnDutyTime1 is null OR OffDutyTime1 is null or OnDutyTime1>=OffDutyTime1  then 
null
else

case when DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1) <= 0 then
 --小于上班时间，不考虑早上旷职 和迟到
 case when DATEDIFF(mi, TAT.WORK_TIME_END1,OffDutyTime1) < 0 then
 --小于下班时间，
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1)))/30.0 as int)*0.5  
  
else
case when  DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0 then
case when  DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)>=0 then 
cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5
else
cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)))/30.0 as int)*0.5 
end
else
cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1)))/30.0 as int)*0.5 
end
end
 
 else
 --大于下班时间
--正常
TAT.TURN_TIME/60

 --大于下班时间
 end 
 else
 --大于上班时间
  
  case when DATEDIFF(mi, TAT.WORK_TIME_END1,OffDutyTime1) < 0 then
 --小于下班时间
 case when DATEDIFF(mi, TAT.WORK_TIME_LATE1,OnDutyTime1) >= 0 then
 --算旷职
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1)))/30.0 as int)*0.5  - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)>=0 then --开始时间 在休息时间之外
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)<0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0 then --开始时间 正常 结束时间在休息时间内
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)  ))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)<= 0 then --开始时间 正常 结束时间在休息时间内

abs(cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)<0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.OnDutyTime1,TAT.OffDutyTime1))/30.0 as int)*0.5 )
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)>=0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.OffDutyTime1))/30.0 as int)*0.5 )
else
null
end

 else
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1)))/30.0 as int)*0.5  - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)>=0 then --开始时间 在休息时间之外
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5 - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)<0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0then --开始时间 正常 结束时间在休息时间内
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)  ))/30.0 as int)*0.5 - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)<= 0 then --开始时间 正常 结束时间在休息时间内

abs(cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OffDutyTime1))/30.0 as int)*0.5 - 0.5)
when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)<0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.OnDutyTime1,TAT.OffDutyTime1))/30.0 as int)*0.5-0.5 )
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)>=0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.OffDutyTime1))/30.0 as int)*0.5 -0.5)
else
null
 end
 end
--- 小于上班结束

 else
 --大于下班时间
 case when DATEDIFF(mi, TAT.WORK_TIME_LATE1,OnDutyTime1) >= 0 then
 --算旷职
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1)))/30.0 as int)*0.5  - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, WORK_TIME_END1)>=0 then --开始时间 在休息时间之外
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, WORK_TIME_END1)<0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0then --开始时间 正常 结束时间在休息时间内
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)  ))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, WORK_TIME_END1)<= 0 then --开始时间 正常 结束时间在休息时间内

abs(cast((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1))/30.0 as int)*0.5 - cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5)
when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)<0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.OnDutyTime1,TAT.WORK_TIME_END1))/30.0 as int)*0.5 )
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)>=0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1))/30.0 as int)*0.5 )
else
null
end

 else
 case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1)))/30.0 as int)*0.5  - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, WORK_TIME_END1)>=0 then --开始时间 在休息时间之外
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1) - ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0)))/30.0 as int)*0.5 - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, WORK_TIME_END1)<0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)>=0 then --开始时间 正常 结束时间在休息时间内
abs(cast(((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)  ))/30.0 as int)*0.5 - 0.5)
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, WORK_TIME_END1)<= 0 then --开始时间 正常 结束时间在休息时间内

abs(cast((DATEDIFF(mi, TAT.WORK_TIME_START1,WORK_TIME_END1))/30.0 as int)*0.5 - 0.5)
when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)<0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.OnDutyTime1,TAT.WORK_TIME_END1))/30.0 as int)*0.5 - 0.5)
 when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME21)>=0 AND DATEDIFF(mi, OffDutyTime1,TAT.RELAX_TIME21)<= 0 then
 abs(cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1))/30.0 as int)*0.5- 0.5 )
else
null
 end
 end
 --大于下班结束
 end 
  
 -- 大于上班时间 end
 end 
end 
else
null
end AS TurnTime,

--旷职时间 AbsentTime
case  when TAT.LEAVE_CODE is null and TAT.LIST_GRP is null then
case when TAT.WORK_TIME_LATE is null  OR TAT.WORK_TIME_START is null then --1
null
else--12
 case when OffDutyTime1 is null  or OnDutyTime1 is null or OnDutyTime1 >= OffDutyTime1 then --22
TAT.TURN_TIME/60
else 
case when DATEDIFF(mi,TAT.WORK_TIME_LATE1, OnDutyTime1)>=0 or DATEDIFF(mi,OffDutyTime1,TAT.WORK_TIME_END1)>=30 then --33
case when DATEDIFF(mi, TAT.WORK_TIME_LATE1,OnDutyTime1) < 0 then --44
case when DATEDIFF(mi,OffDutyTime1,TAT.WORK_TIME_END1)>=30 then --旷职
case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then --12333
 cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5
 else
 case when DATEDIFF(mi,OffDutyTime1,TAT.RELAX_TIME21)>= 0 then
case when DATEDIFF(mi,OffDutyTime1,TAT.RELAX_TIME11)>= 0 then
cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29-ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0))/30.0 as int)*0.5 
else
cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5
end
else
cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5
 end
 
 
 end --12333
 else
 null
 end
else --早上旷职
case when DATEDIFF(mi,OffDutyTime1,TAT.WORK_TIME_END1)>=30 then --旷职
case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then --Relex
cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5 + cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5
when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)>=0 then --开始时间 在休息时间之外
cast((DATEDIFF(mi, TAT.OffDutyTime1,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5 + cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5
  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME21, OffDutyTime1)<0 then --开始时间 正常 结束时间在休息时间内
cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5 + cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5

  when DATEDIFF(mi,TAT.OnDutyTime1,TAT.RELAX_TIME11)>0 AND DATEDIFF(mi,TAT.RELAX_TIME11, OffDutyTime1)<= 0 then --开始时间 正常 结束时间在休息时间内

cast((DATEDIFF(mi, TAT.RELAX_TIME21,TAT.WORK_TIME_END1)+29)/30.0 as int)*0.5 + cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5

else
TAT.TURN_TIME/60
 end --Relex
else
case when TAT.RELAX_TIME1 is null OR TAT.RELAX_TIME2 is null then 
cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5
else
case when DATEDIFF(mi,OnDutyTime1,TAT.RELAX_TIME21)> 0 then
case when DATEDIFF(mi,OnDutyTime1,TAT.RELAX_TIME11)<= 0 then
cast((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.RELAX_TIME11)+29)/30.0 as int)*0.5
else
cast((DATEDIFF(mi, TAT.WORK_TIME_START1,OnDutyTime1)+29)/30.0 as int)*0.5
end
else
cast((DATEDIFF(mi, TAT.WORK_TIME_START1,TAT.OnDutyTime1)+29-ISNULL(DATEDIFF(mi, TAT.[RELAX_TIME1],TAT.[RELAX_TIME2]),0))/30.0 as int)*0.5
end
end
end
end --44
else
null
end --33
end --22
end --12
else --1
null
end AS AbsentHours,
--加班时间
case  when  TAT.LIST_GRP is null then
case when TAT.WORK_TIME_OVERTIME is null or OffDutyTime1 is null or OnDutyTime1 is null then
null
else
case when TAT.WORK_TIME_START < TAT.WORK_TIME_END then
case when DATEDIFF(mi,Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108), OffDutyTime1)>0 then 
case when TAT.TURN_OVERTIME = 0.5 then
cast(DATEDIFF(mi,  Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)/30.0 as int)*0.5
else
DATEDIFF(hh, Convert(varchar(100),TAT.CHK_DATE,23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)
end 
else
null
end

else -- span night
case when DATEDIFF(mi,Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108), OffDutyTime1)>0 then 
case when TAT.TURN_OVERTIME = 0.5 then
cast(DATEDIFF(mi,  Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)/30.0 as int)*0.5
else
DATEDIFF(hh, Convert(varchar(100),dateadd(dd,1,TAT.CHK_DATE),23) +' '+ convert(char(5),TAT.WORK_TIME_OVERTIME,108),OffDutyTime1)
end 
else
null
end
end
end
else
case  when TAT.LEAVE_CODE is not null then
null
else
case when TAT.OffDutyTime1 <= TAT.OnDutyTime1 then
null
else
cast(DATEDIFF(mi,  OnDutyTime1,OffDutyTime1)/30.0 as int)*0.5
end
end
end AS OverTime
 from (select * from (select UA.CHK_DATE,UA.LIST_GRP,UA.EMP_CODE,UserName, 
day(UA.CHK_DATE) AS CheckDay,
case when UA.WORK_TIME_START < UA.WORK_TIME_END or UA.LIST_GRP is not null then
UI.TranDateTime
else 
case when UIS.EntriesNum = 1 then
case when abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_END,108),convert(char(5),UIS.TranDateTime,108)))>=abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_START,108),convert(char(5),UIS.TranDateTime,108))) then
UIS.TranDateTime
else
null
end
else
UIS.TranDateTime
end
end AS OnDutyTime1,convert(char(5),[RELAX_TIME1],108) as [RELAX_TIME1],convert(char(5),[RELAX_TIME2],108) as [RELAX_TIME2],
Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),[RELAX_TIME1],108) AS [RELAX_TIME11],
case when RELAX_TIME1 <= RELAX_TIME2 then
Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),[RELAX_TIME2],108) 
else
Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),[RELAX_TIME2],108)
end AS [RELAX_TIME21],

case when UA.WORK_TIME_START < UA.WORK_TIME_END or UA.LIST_GRP is not null then
case when UO.TranDateTime <> UI.TranDateTime then UO.TranDateTime
else null
end 
else--跨夜
case when UOS.TranDateTime is null then 
case when UO.TranDateTime <> UIS.TranDateTime then UO.TranDateTime
else null
end 
else
case when UOS.EntriesNum = 1 then
case when abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_END,108),convert(char(5),UOS.TranDateTime,108)))<abs(DATEDIFF(mi, convert(char(5),UA.WORK_TIME_START,108),convert(char(5),UOS.TranDateTime,108))) then
UOS.TranDateTime
else
null
end
else
case when UOS.TranDateTime <> UIS.TranDateTime then UOS.TranDateTime
else null
end
end
end
end
 AS OffDutyTime1,
UL.LEAVE_CODE,
UL.LEAVE_DESC,UL.SUM_TIME AS LeaveTime,
UA.WORK_TIME_START,
UA.WORK_TIME_END,
UI.TranDateTime as TranDateTimeIn,
UO.TranDateTime as TranDateTimeOut,
UIS.TranDateTime as TranDateTimeInS,
UOS.TranDateTime as TranDateTimeOutS,
UA.WORK_TIME_LATE,
 UA.TURN_TIME,
 UA.WORK_TIME_OVERTIME,
 UA.TURN_OVERTIME,
UA.DepartmentName,
 case when UA.WORK_TIME_START <= UA.WORK_TIME_LATE then 
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_LATE,108)
 else
 Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),WORK_TIME_LATE,108) 
 end AS WORK_TIME_LATE1,
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_START,108) AS WORK_TIME_START1,

 case when UA.WORK_TIME_START < UA.WORK_TIME_END then 
 Convert(varchar(100),UA.CHK_DATE,23) +' '+ convert(char(5),WORK_TIME_END,108)
 else
 Convert(varchar(100),dateadd(dd,1,UA.CHK_DATE),23) +' '+ convert(char(5),WORK_TIME_END,108) 
 end AS WORK_TIME_END1
 from UPER_CHECK_SECTION('{0}','{1}') AS UA
Left join (select CardId,min(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') group by CardId,convert(varchar(10),TranDateTime,120))
AS UI ON UA.CardID=UI.CardID AND UA.CHK_DATE=UI.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,max(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') group by CardId,convert(varchar(10),TranDateTime,120))
AS UO ON UA.CardID=UO.CardID AND UA.CHK_DATE=UO.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,min(TranDateTime) AS TranDateTime,convert(varchar(10),dateadd(dd,-1,TranDateTime),120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') group by CardId,convert(varchar(10),dateadd(dd,-1,TranDateTime),120))
AS UOS ON UA.CardID=UOS.CardID AND UA.CHK_DATE=UOS.CHK_DATE
Left join (select count(CardId) AS EntriesNum,CardId,max(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS_New1('{0}','{2}') group by CardId,convert(varchar(10),TranDateTime,120))
AS UIS ON UA.CardID=UIS.CardID AND UA.CHK_DATE=UIS.CHK_DATE
Left Join (select LEAVE_DATE,EMP_CODE,LEAVE_CODE,LEAVE_DESC,LEAVE_TIME1,LEAVE_TIME2,SUM_TIME from  UPER_LEAVE_ITEMS ('{0}','{1}')) AS UL
ON UA.EMP_CODE = UL.EMP_CODE AND UA.CHK_DATE=UL.LEAVE_DATE) AS DD where DD.EMP_CODE IN( 
", startDate, endDate, endDate + " 23:59:59");
            }

            /*foreach (EmployeeBrief employee in employeesObject)
            {
                SqlCommand += "'" + employee.UserID + "',";
            }
            SqlCommand = SqlCommand.TrimEnd(',');
            SqlCommand += ") ) as TAT order by CHK_DATE ASC ";
             * */
            SqlCommand += "select [UserID] as EMP_CODE from [BF_User] where [UserID] IN(";
            foreach (EmployeeBrief employee in employeesObject)
            {
                SqlCommand += "'" + employee.UserID + "',";
            }
            SqlCommand = SqlCommand.TrimEnd(',');
            SqlCommand += ") AND (TimeLastLogout IS NULL  or ( TimeLastLogout IS not NULL and DATEDIFF(dd,convert(varchar(10),TimeLastLogout,120),'";
            SqlCommand += startDate;
            SqlCommand += "')<0))) ) as TAT LEFT JOIN CHK_DOLIST AS CD ON TAT.CHK_DATE = CD.LIST_DATE order by CHK_DATE ASC ";




return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }





        /* Add: 2023/01/22
         * By:  Eric
         * Ver: 1.1.5.7
         */
        public bool WriteWorkShiftNo(DateTime _startDate, DateTime _endDate,  IEnumerable<EmployeeBrief> _employeesObject)
        {
          
            int intTranSID = default(int);
            int intUserSIDCurrent = default(int);
            int intUserSIDLast = default(int);
            int intWorkShiftNo = default(int);
            int intWorkShiftNo_UserSID, intWorkShiftNo_Year, intWorkShiftNo_Month, intWorkShiftNo_Day;

            byte bytTranTypeCurrent = default(byte);
            byte bytTranTypeLast = default(byte);


            bool bolIsTranInCurrent = false;
            bool bolIsTranInLast = false;

            bool bolIsTranOutCurrent = false;
            bool bolIsTranOutLast = false;


            DateTime dteTranTimeCurrent = DateTime.Now;
            DateTime dteTranTimeLast = DateTime.Now;

            //string strDayCurrent;
            int intDayCurrent = default(int);
            int intDayLast = default(int);

            int intItemNo = default(int);

            bool bolIsSetWorkShiftNo_Current = false;              // 巡列的時候，目前這筆是否要設定新的WorkShiftNo
            bool bolIsSetWorkShiftNo_Next = false;          // 巡列的時候，下一筆是否要設定新的WorkShiftNo

            var strSqlWhereUserSID = string.Empty;
            if (_employeesObject != null && _employeesObject.Any())
            {
                strSqlWhereUserSID = "AND UserSID IN (" + string.Join(",", _employeesObject.Select(x => x.UserSID)) + ") ";
            }
            //var strSqlWhereTime = $"AND (WorkingTimeOn BETWEEN '{startDate}' AND '{endDate}') ";
            //var strSqlWhereTransactionsTranDateTime = $"AND (TranDateTime BETWEEN '" & mainMe.DateTimeGetStdString(dtDate1) & "' AND '" & mainMe.DateTimeGetStdString(dtDate2) & "') "
            var strSqlWhereTransactionsTranDateTimeAdd1Day = $"AND (TranDateTime BETWEEN '{_startDate.GetStdString()}' AND '{_endDate.AddDays(1).GetStdString()}') ";

            string sSQL = @"
            SELECT TranSID, UserSID, TranDateTime
                , (CASE WHEN IsByTranType = 1 THEN TranType ELSE DataType END) AS TranType  
            FROM [VJN_Transaction_Depart_User_JobCode]
            WHERE (
                    ((IsByTranType = 1) AND (TranType BETWEEN 1 AND 2 OR TranType BETWEEN 161 AND 162)) 
                    OR 
                    ((IsByTranType = 0) AND (DataType BETWEEN 1 AND 2)) 
                ) " 
                + strSqlWhereTransactionsTranDateTimeAdd1Day
                + strSqlWhereUserSID
            + "ORDER BY UserSID, TranDateTime ";

            // error 已經開啟一個與cmd相關的datareader
            //SqlDataReader drTranList = sqlDatabaseProvider.GetSqlDataReader(sSQL);

            DataTable dtTranList = sqlDatabaseProvider.ExcuteTable(sSQL);
            if (dtTranList != null)
            {
                foreach (DataRow drThis in dtTranList.Rows)
                {
                    intTranSID = int.Parse(drThis[0].ToString());
                    intUserSIDCurrent = int.Parse(drThis[1].ToString());
                    dteTranTimeCurrent = DateTime.Parse(drThis[2].ToString());
                    bytTranTypeCurrent = byte.Parse(drThis[3].ToString());


                    // ---------------------------------------
                    switch (bytTranTypeCurrent)
                    {
                        case 1:
                        case 161:
                            {
                                // IN
                                bolIsTranInCurrent = true;
                                bolIsTranOutCurrent = false;
                                break;
                            }

                        case 2:
                        case 162:
                            {
                                // OUT
                                bolIsTranOutCurrent = true;
                                bolIsTranInCurrent = false;
                                break;
                            }

                        default:
                            {
                                bolIsTranInCurrent = false;
                                bolIsTranOutCurrent = false;
                                break;
                            }
                    }



                    intDayCurrent = dteTranTimeCurrent.Day;
                    //strDayCurrent = intDayCurrent.ToString();

                    // 要找出哪一筆開頭才是上班（而非下班），預設先從搜尋範圍的第一筆開始是同為第一筆上班）
                    if (bolIsSetWorkShiftNo_Next)
                    {
                        bolIsSetWorkShiftNo_Next = false;
                        bolIsSetWorkShiftNo_Current = true;
                    }
                    else if (bolIsTranInCurrent)
                    {
                        // TranIn
                        bolIsSetWorkShiftNo_Current = true;
                    }
                    else if (bolIsTranOutCurrent)
                    {
                        bolIsSetWorkShiftNo_Next = true;
                    }




                    if (bolIsSetWorkShiftNo_Current)
                    {
                        if (intDayCurrent != intDayLast)
                            intItemNo = 0;

                        intItemNo = intItemNo + 1;


                        intWorkShiftNo_UserSID = System.Convert.ToInt32(intUserSIDCurrent.ToString().Right(2)) * 10_000_000;
                        intWorkShiftNo_Year = System.Convert.ToInt32(dteTranTimeCurrent.Year.ToString().Right(1)) * 1_000_000;
                        intWorkShiftNo_Month = dteTranTimeCurrent.Month * 10_000;
                        intWorkShiftNo_Day = intDayCurrent * 100;
                        intWorkShiftNo = intWorkShiftNo_UserSID + intWorkShiftNo_Year + intWorkShiftNo_Month + intWorkShiftNo_Day + intItemNo;

                        bolIsSetWorkShiftNo_Current = false;
                    }



                    intUserSIDLast = intUserSIDCurrent;
                    intDayLast = intDayCurrent;
                    bytTranTypeLast = bytTranTypeCurrent;
                    dteTranTimeLast = dteTranTimeCurrent;


                    // 將目前的指標值寫入暫存區
                    bolIsTranInLast = bolIsTranInCurrent;
                    bolIsTranOutLast = bolIsTranOutCurrent;

                    sqlDatabaseProvider.SP_Update_Transactions_WorkShiftNo(intTranSID, intWorkShiftNo);
                }
                            
            }

                  

            return true;
        }



        public DataTable GetFlexShiftReportDetails(DateTime _workingTime_Start, DateTime _workingTime_End, IEnumerable<int> _userSIDEnumer)
        {
            return sqlDatabaseProvider.SP_GetAttendanceReport_FlexShift(_workingTime_Start, _workingTime_End, _userSIDEnumer);
        }



        public bool ImportEmployeePhoto(string UserId, string photoPath)
        {
            string SqlCommand = string.Format("update [BF_User] SET [RegPhoto]='{0}' where [UserID]='{1}'", photoPath, UserId);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        //出勤历
        public bool UpdateEmployeeShiftTable(int UserSID, string shiftTableCode)
        {
            string SqlCommand = string.Format("UPDATE BF_User SET ShiftCategory=N'{0}' where UserSID={1} ", shiftTableCode, UserSID.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public DataTable GetAnnualCalendarListByMonth(int year, int month_start, int month_end)
        {
            int dayEnd = DateTime.DaysInMonth(year, month_end);
            DateTime start = new DateTime(year, month_start,1);
            DateTime end = new DateTime(year, month_end, dayEnd);
            string strSql = string.Format("SELECT * from CHK_DOLIST where LIST_YEAR={0} and LIST_DATE>='{1}' and LIST_DATE<='{2}' ", year.ToString(), start.ToShortDateString(), end.ToShortDateString());
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public DataTable GetAnnualCalendarList(int year)
        {
            string strSql = string.Format("SELECT * from CHK_DOLIST where LIST_YEAR={0} ", year.ToString());
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public bool UpdateAnnualCalendarSet(AnnulaCalendar calendar)
        {
            string SqlCommand = string.Format("UPDATE [CHK_DOLIST] SET [HOLIDAY_CK] = {0}, [LIST_MEMO] = N'{1}',[BUILD_NAME] = N'{2}',[BUILD_TIME]='{3}',[LIST_GRP]={6} WHERE [LIST_DATE] = '{4}' AND LIST_YEAR={5}",
                 calendar.HOLIDAY_CK ? "1" : "0", calendar.LIST_MEMO, calendar.BUILD_NAME, calendar.BUILD_TIME, calendar.LIST_DATE.ToShortDateString(), calendar.LIST_YEAR.ToString(), calendar.LIST_GRP.ToString());

            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool AddAnnualCalendar(AnnulaCalendar calendar)
        {
            string SqlCommand = "";
            if( calendar.LIST_GRP != 0 )
                SqlCommand = string.Format(@"INSERT INTO [CHK_DOLIST] ([LIST_YEAR],[LIST_DATE],[LIST_WEEK],[LIST_MEMO], [HOLIDAY_CK],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],
                                [BUILD_TIME],[LIST_GRP]) VALUES ('{0}', '{1}', N'{2}',N'{3}',{4},N'{5}',N'{6}',N'{5}',N'{6}',{7})", calendar.LIST_YEAR, calendar.LIST_DATE.ToShortDateString(), calendar.LIST_WEEK,
                                                                                                             calendar.LIST_MEMO, calendar.HOLIDAY_CK ? "1" : "0", calendar.BUILD_NAME, calendar.BUILD_TIME.ToString("yyyy-MM-dd HH:mm:ss"), calendar.LIST_GRP.ToString());
            else
                SqlCommand = string.Format(@"INSERT INTO [CHK_DOLIST] ([LIST_YEAR],[LIST_DATE],[LIST_WEEK],[LIST_MEMO], [HOLIDAY_CK],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],
                                [BUILD_TIME]) VALUES ('{0}', '{1}', N'{2}',N'{3}',{4},N'{5}',N'{6}',N'{5}',N'{6}')", calendar.LIST_YEAR, calendar.LIST_DATE.ToShortDateString(), calendar.LIST_WEEK,
                                                                                                             calendar.LIST_MEMO, calendar.HOLIDAY_CK ? "1" : "0", calendar.BUILD_NAME, calendar.BUILD_TIME.ToString("yyyy-MM-dd HH:mm:ss"));
        
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        //出勤历
        public  int CreatePersonalShiftTable(int year,string userid,string cardid,string turnwork_grp,string admin)
        {
            string SqlCommand = string.Format("DELETE FROM [PER_CHK] WHERE YEAR([CHK_DATE])='{0}' AND [EMP_CODE]=N'{1}'",  year.ToString(),userid);
            if (sqlDatabaseProvider.ExecuteSql(SqlCommand) < 0)
                return 0;
            SqlCommand = string.Format(@"insert into [PER_CHK] ([EMP_CODE],[CardID],[CHK_DATE],[CLASS_CODE],[CLOCK_CK],[CHK],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME],[LIST_GRP])
select N'{0}','{1}',[WORK_DATE],[CLASS_CODE],1,1 ,'{2}','{3}','{2}','{3}',[LIST_GRP] from [CHK_WORKLIST] where [WORK_YEAR]={4} and [TURNWORK_GRP]=N'{5}'",
                userid, cardid, admin, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), year.ToString(), turnwork_grp);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) ;
        }
        public int UpdateWorkListShiftCode(string date, string shiftType, string shifCode, string admin)
        {
            string SqlCommand = string.Format("UPDATE [CHK_WORKLIST] SET [CLASS_CODE]=N'{0}',[LIST_GRP]=null,[BUILD_NAME]=N'{1}',[BUILD_TIME]='{2}' WHERE [TURNWORK_GRP]=N'{3}' AND [WORK_DATE]='{4}'",
                shifCode, admin, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), shiftType, date);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) ;
        }
        public int UpdateWorkListHolidayType(string date, string shiftType, int holiType, string admin)
        {
            string SqlCommand = string.Format("UPDATE [CHK_WORKLIST] SET [CLASS_CODE]='',[LIST_GRP]={0},[BUILD_NAME]=N'{1}',[BUILD_TIME]='{2}' WHERE [TURNWORK_GRP]=N'{3}' AND [WORK_DATE]='{4}'",
               holiType.ToString(), admin, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), shiftType, date);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        //个人出勤历
        public int UpdatePersonShiftTableShiftCode(string userid, string date, string shiftcode, string admin)
        {
            string SqlCommand = string.Format("UPDATE [PER_CHK] SET [CLASS_CODE]=N'{0}',[LIST_GRP]=null,[BUILD_NAME]=N'{1}',[BUILD_TIME]='{2}' WHERE [EMP_CODE]=N'{3}' AND [CHK_DATE]='{4}'",
               shiftcode, admin, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), userid, date);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int UpdatePersonShiftTableHolidayType(string userid, string date, int holiType, string admin)
        {
            string SqlCommand = string.Format("UPDATE [PER_CHK] SET [CLASS_CODE]='',[LIST_GRP]={0},[BUILD_NAME]=N'{1}',[BUILD_TIME]='{2}' WHERE [EMP_CODE]=N'{3}' AND [CHK_DATE]='{4}'",
               holiType.ToString(), admin, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), userid, date);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public DataTable GetPerShiftTable(int year)
        {
            string strSql = string.Format(@"SELECT [DepartmentID],DepartmentName,UserName,[EMP_CODE],[CardID], CheckYear,[CHK_DATE],[CLASS_CODE],[CLOCK_CK],[LEAVE_CODE],[CHK],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME],[LIST_GRP],convert(char(5),[WORK_TIME_START],108) as [WORK_TIME_START],convert(char(5),[WORK_TIME_END],108) as [WORK_TIME_END],convert(char(5),[WORK_TIME_LATE],108) as [WORK_TIME_LATE],convert(char(5),[WORK_TIME_OVERTIME],108) as [WORK_TIME_OVERTIME],
        convert(char(5),[RELAX_TIME1],108) as [RELAX_TIME1],convert(char(5),[RELAX_TIME2],108) as [RELAX_TIME2],convert(char(5),[RELAX_TIME3],108) as [RELAX_TIME3],convert(char(5),[RELAX_TIME4],108) as [RELAX_TIME4],[TURN_OVERTIME],[CLASS_DESC] from [VPER_CHK] where CheckYear={0} order by [CHK_DATE] ASC", year.ToString());

            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public DataTable GetChkWorkList(int year)
        {
            string strSql = string.Format(@"select [WORK_YEAR],[TURNWORK_GRP],[WORK_DATE],[WORK_WEEK],A.[CLASS_CODE],A.CREATE_NAME,A.[CREATE_TIME],A.[BUILD_NAME],A.[BUILD_TIME],A.LIST_GRP,B.CLASS_DESC,convert(char(5),B.WORK_TIME_START,108) as WORK_TIME_START,convert(char(5),B.WORK_TIME_END,108) as WORK_TIME_END from [CHK_WORKLIST] AS A LEFT JOIN [CHK_CLASS] AS B ON A.CLASS_CODE=B.CLASS_CODE
where [WORK_YEAR] = {0} order by [WORK_DATE] ASC", year.ToString());
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public int CreateShiftTableWithoutDoList(int year, string shiftCategory, string admin)
        {
            string SqlCommand = string.Format("DELETE FROM [CHK_WORKLIST] WHERE [TURNWORK_GRP] =N'{0}' AND [WORK_YEAR]={1}", shiftCategory, year.ToString());
            if (sqlDatabaseProvider.ExecuteSql(SqlCommand) < 0)
                return 0;
            SqlCommand = string.Format(@"insert  [CHK_WORKLIST] ([WORK_YEAR],[TURNWORK_GRP],[WORK_DATE],[WORK_WEEK],[CLASS_CODE],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME])
select {1},N'{0}',DateAdd(day,number,'{1}-01-01') AS [LIST_DATE], datename(weekday, DateAdd(day,number,'{1}-01-01')) as [LIST_WEEK],
CASE datepart(weekday, DateAdd(day,number,'{1}-01-01'))
WHEN 1 then  (select [CLASS_CODE1] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 2 then  (select [CLASS_CODE2] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 3 then  (select [CLASS_CODE3] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 4 then  (select [CLASS_CODE4] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 5 then  (select [CLASS_CODE5] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 6 then  (select [CLASS_CODE6] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
ELSE  (select [CLASS_CODE7] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
END
 AS [CLASS_CODE],N'{2}',N'{3}',N'{2}',N'{3}'
 FROM master..spt_values  
 WHERE type = 'p'  
   AND number < DateDiff(day,'{1}-01-01','{4}-01-01') ", shiftCategory, year.ToString(), admin.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), (year + 1).ToString());

            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int CreateShiftTableByDoList(int year, string shiftCategory,string admin)
        {

            string SqlCommand = string.Format("DELETE FROM [CHK_WORKLIST] WHERE [TURNWORK_GRP] =N'{0}' AND [WORK_YEAR]={1}", shiftCategory, year.ToString());
            if (sqlDatabaseProvider.ExecuteSql(SqlCommand) < 0)
                return 0;
            SqlCommand = string.Format(@"insert  [CHK_WORKLIST] ([WORK_YEAR],[TURNWORK_GRP],[WORK_DATE],[WORK_WEEK],[CLASS_CODE],[CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME],[LIST_GRP])
select [LIST_YEAR],N'{0}',[LIST_DATE],[LIST_WEEK],
CASE when [HOLIDAY_CK] = 0 THEN
CASE datepart(weekday, [LIST_DATE])
WHEN 1 then  (select [CLASS_CODE1] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 2 then  (select [CLASS_CODE2] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 3 then  (select [CLASS_CODE3] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 4 then  (select [CLASS_CODE4] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 5 then  (select [CLASS_CODE5] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
WHEN 6 then  (select [CLASS_CODE6] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
ELSE  (select [CLASS_CODE7] from [CHK_TURNWORK] where [TURNWORK_GRP]=N'{0}')
END

ELSE
''
END AS [CLASS_CODE],N'{2}',N'{3}',N'{2}',N'{3}',[LIST_GRP]
 from [CHK_DOLIST] where [LIST_YEAR]={1}", shiftCategory, year.ToString(), admin.ToString(), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        public int HasAnnualCalendarOrNot(int year)
        {
            string SqlCommand = string.Format("select * from CHK_DOLIST where LIST_YEAR={0}", year.ToString());

            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
                return 1;
            return 0;
        }
        public bool DeleteAnnualCalendar(int year)
        {
            string SqlCommand = string.Format("delete from CHK_DOLIST where LIST_YEAR={0}", year.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool UpdateWorkShift(WorkShift workShift, string supervisorMsg) //
        {

            string SqlCommand = string.Format("select * from CHK_CLASS where CLASS_CODE='{0}'", workShift.CLASS_CODE);
            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
            {
               
//                SqlCommand = string.Format(@"UPDATE [CHK_CLASS] SET [CLASS_DESC] = N'{0}', [WORK_TIME_START]='{1}',[WORK_TIME_END]='{2}',[WORK_TIME_LATE]='{3}',
//                    [WORK_TIME_OVERTIME]='{4}',[TURN_OVERTIME]={5},[RELAX_TIME1]='{6}',[RELAX_TIME2]='{7}',[RELAX_TIME3]='{8}',[RELAX_TIME4]='{9}',[TURN_TIME]={10},
//                    [BUILD_NAME] = '{11}',[BUILD_TIME]=CURRENT_TIMESTAMP where [CLASS_CODE]='{12}'",
//                   workShift.CLASS_DESC, workShift.WORK_TIME_START, workShift.WORK_TIME_END, workShift.WORK_TIME_LATE, workShift.WORK_TIME_OVERTIME,
//                   workShift.TURN_OVERTIME.ToString(), workShift.RELAX_TIME1, workShift.RELAX_TIME2, workShift.RELAX_TIME3, workShift.RELAX_TIME4,
//                   workShift.TURN_TIME.ToString(), supervisorId.ToString(), workShift.CLASS_CODE);
                SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
                string sqlstr = string.Format(@"UPDATE[CHK_CLASS] SET [CLASS_DESC] = @CLASS_DESC, [WORK_TIME_START] = @WORK_TIME_START,[WORK_TIME_END]=@WORK_TIME_END,[WORK_TIME_LATE]=@WORK_TIME_LATE,
                            [WORK_TIME_OVERTIME]=@WORK_TIME_OVERTIME,[TURN_OVERTIME]=@TURN_OVERTIME,[RELAX_TIME1]=@RELAX_TIME1,[RELAX_TIME2]=@RELAX_TIME2,[RELAX_TIME3]=@RELAX_TIME3,[RELAX_TIME4]=@RELAX_TIME4,[TURN_TIME]=@TURN_TIME,
                            [BUILD_NAME]=@BUILD_NAME,[BUILD_TIME]=@BUILD_TIME where [CLASS_CODE]='{0}'", workShift.CLASS_CODE);
                SqlCommand mycom = new SqlCommand(sqlstr, cn);
                //添加参数 
               
                mycom.Parameters.Add(new SqlParameter("@CLASS_DESC", SqlDbType.NVarChar, 20));
                mycom.Parameters.Add(new SqlParameter("@WORK_TIME_START", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@WORK_TIME_END", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@WORK_TIME_LATE", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@WORK_TIME_OVERTIME", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@TURN_OVERTIME", SqlDbType.Float));
                mycom.Parameters.Add(new SqlParameter("@RELAX_TIME1", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@RELAX_TIME2", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@RELAX_TIME3", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@RELAX_TIME4", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@TURN_TIME", SqlDbType.Float));
                mycom.Parameters.Add(new SqlParameter("@BUILD_NAME", SqlDbType.NVarChar, 30));
                mycom.Parameters.Add(new SqlParameter("@BUILD_TIME", SqlDbType.DateTime));
                //给参数赋值 
                
                mycom.Parameters["@CLASS_DESC"].Value = workShift.CLASS_DESC;
                mycom.Parameters["@WORK_TIME_START"].Value = workShift.WORK_TIME_START;
                mycom.Parameters["@WORK_TIME_END"].Value = workShift.WORK_TIME_END;
                if (workShift.WORK_TIME_LATE == null)
                    mycom.Parameters["@WORK_TIME_LATE"].Value = DBNull.Value;
                else
                    mycom.Parameters["@WORK_TIME_LATE"].Value = workShift.WORK_TIME_LATE;
                if (workShift.WORK_TIME_OVERTIME == null)
                    mycom.Parameters["@WORK_TIME_OVERTIME"].Value = DBNull.Value;
                else
                    mycom.Parameters["@WORK_TIME_OVERTIME"].Value = workShift.WORK_TIME_OVERTIME;
                mycom.Parameters["@TURN_OVERTIME"].Value = workShift.TURN_OVERTIME;
                if (workShift.RELAX_TIME1 == null)
                    mycom.Parameters["@RELAX_TIME1"].Value = DBNull.Value;
                else
                    mycom.Parameters["@RELAX_TIME1"].Value = workShift.RELAX_TIME1;
                if (workShift.RELAX_TIME2 == null)
                    mycom.Parameters["@RELAX_TIME2"].Value = DBNull.Value;
                else
                    mycom.Parameters["@RELAX_TIME2"].Value = workShift.RELAX_TIME2;
                if (workShift.RELAX_TIME3 == null)
                    mycom.Parameters["@RELAX_TIME3"].Value = DBNull.Value;
                else
                    mycom.Parameters["@RELAX_TIME3"].Value = workShift.RELAX_TIME3;
                if (workShift.RELAX_TIME4 == null)
                    mycom.Parameters["@RELAX_TIME4"].Value = DBNull.Value;
                else
                    mycom.Parameters["@RELAX_TIME4"].Value = workShift.RELAX_TIME4;
                mycom.Parameters["@TURN_TIME"].Value = workShift.TURN_TIME;

                mycom.Parameters["@BUILD_NAME"].Value = supervisorMsg;
                mycom.Parameters["@BUILD_TIME"].Value = DateTime.Now;
                //执行添加语句 
                return mycom.ExecuteNonQuery() > 0 ? true : false;
            }
            else
            {
                SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
                string sqlstr = @"INSERT INTO [CHK_CLASS] ([CLASS_CODE],  [CLASS_DESC], [WORK_TIME_START],[WORK_TIME_END],[WORK_TIME_LATE],
                            [WORK_TIME_OVERTIME],[TURN_OVERTIME],[RELAX_TIME1],[RELAX_TIME2],[RELAX_TIME3],[RELAX_TIME4],[TURN_TIME],
                            [CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME],[LEAVE_CK]) VALUES (@CLASS_CODE,@CLASS_DESC,@WORK_TIME_START,@WORK_TIME_END,@WORK_TIME_LATE,
                            @WORK_TIME_OVERTIME,@TURN_OVERTIME,@RELAX_TIME1,@RELAX_TIME2,@RELAX_TIME3,@RELAX_TIME4,@TURN_TIME,@CREATE_NAME,@CREATE_TIME,
                            @BUILD_NAME,@BUILD_TIME,@LEAVE_CK)";
                SqlCommand mycom = new SqlCommand(sqlstr, cn);
                //添加参数 
                mycom.Parameters.Add(new SqlParameter("@CLASS_CODE", SqlDbType.NVarChar, 10));
                mycom.Parameters.Add(new SqlParameter("@CLASS_DESC", SqlDbType.NVarChar, 20));
                mycom.Parameters.Add(new SqlParameter("@WORK_TIME_START", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@WORK_TIME_END", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@WORK_TIME_LATE", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@WORK_TIME_OVERTIME", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@TURN_OVERTIME", SqlDbType.Float));
                mycom.Parameters.Add(new SqlParameter("@RELAX_TIME1", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@RELAX_TIME2", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@RELAX_TIME3", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@RELAX_TIME4", SqlDbType.Time));
                mycom.Parameters.Add(new SqlParameter("@TURN_TIME", SqlDbType.Float));
                mycom.Parameters.Add(new SqlParameter("@CREATE_NAME", SqlDbType.NVarChar, 30));
                mycom.Parameters.Add(new SqlParameter("@CREATE_TIME", SqlDbType.DateTime));
                mycom.Parameters.Add(new SqlParameter("@BUILD_NAME", SqlDbType.NVarChar, 30));
                mycom.Parameters.Add(new SqlParameter("@BUILD_TIME", SqlDbType.DateTime));
                mycom.Parameters.Add(new SqlParameter("@LEAVE_CK", SqlDbType.Bit));
                //给参数赋值 
                mycom.Parameters["@CLASS_CODE"].Value = workShift.CLASS_CODE;
                mycom.Parameters["@CLASS_DESC"].Value = workShift.CLASS_DESC;
                mycom.Parameters["@WORK_TIME_START"].Value = workShift.WORK_TIME_START;
                mycom.Parameters["@WORK_TIME_END"].Value = workShift.WORK_TIME_END;
                if (workShift.WORK_TIME_LATE == null)
                    mycom.Parameters["@WORK_TIME_LATE"].Value = DBNull.Value;
                else
                    mycom.Parameters["@WORK_TIME_LATE"].Value = workShift.WORK_TIME_LATE;
                if (workShift.WORK_TIME_OVERTIME == null)
                    mycom.Parameters["@WORK_TIME_OVERTIME"].Value = DBNull.Value;
                else
                    mycom.Parameters["@WORK_TIME_OVERTIME"].Value = workShift.WORK_TIME_OVERTIME;
                mycom.Parameters["@TURN_OVERTIME"].Value = workShift.TURN_OVERTIME;
                if (workShift.RELAX_TIME1 == null)
                    mycom.Parameters["@RELAX_TIME1"].Value = DBNull.Value;
                else
                    mycom.Parameters["@RELAX_TIME1"].Value = workShift.RELAX_TIME1;
                if (workShift.RELAX_TIME2 == null)
                    mycom.Parameters["@RELAX_TIME2"].Value = DBNull.Value;
                else
                    mycom.Parameters["@RELAX_TIME2"].Value = workShift.RELAX_TIME2;
                if (workShift.RELAX_TIME3 == null)
                    mycom.Parameters["@RELAX_TIME3"].Value = DBNull.Value;
                else
                    mycom.Parameters["@RELAX_TIME3"].Value = workShift.RELAX_TIME3;
                if (workShift.RELAX_TIME4 == null)
                    mycom.Parameters["@RELAX_TIME4"].Value = DBNull.Value;
                else
                    mycom.Parameters["@RELAX_TIME4"].Value = workShift.RELAX_TIME4;
                mycom.Parameters["@TURN_TIME"].Value = workShift.TURN_TIME;
                mycom.Parameters["@CREATE_NAME"].Value = supervisorMsg;
                mycom.Parameters["@CREATE_TIME"].Value = DateTime.Now;
                mycom.Parameters["@BUILD_NAME"].Value = supervisorMsg;
                mycom.Parameters["@BUILD_TIME"].Value = DateTime.Now;
                mycom.Parameters["@LEAVE_CK"].Value = 0;
                //执行添加语句 
                return mycom.ExecuteNonQuery() > 0 ? true : false;
//                SqlCommand = string.Format(@"INSERT INTO [CHK_CLASS] ([CLASS_CODE],  [CLASS_DESC], [WORK_TIME_START],[WORK_TIME_END],[WORK_TIME_LATE],
//                            [WORK_TIME_OVERTIME],[TURN_OVERTIME],[RELAX_TIME1],[RELAX_TIME2],[RELAX_TIME3],[RELAX_TIME4],[TURN_TIME],
//                            [CREATE_NAME],[CREATE_TIME],[BUILD_NAME],[BUILD_TIME],[LEAVE_CK]) VALUES (N'{0}',N'{1}', '{2}','{3}','{4}','{5}',{6},'{7}',
//                            '{8}','{9}','{10}',{11},'{12}','{13}','{12}','{13}',{14}
//                            )", workShift.CLASS_CODE, workShift.CLASS_DESC, workShift.WORK_TIME_START, workShift.WORK_TIME_END, workShift.WORK_TIME_LATE, workShift.WORK_TIME_OVERTIME,
//                   workShift.TURN_OVERTIME.ToString(), workShift.RELAX_TIME1, workShift.RELAX_TIME2, workShift.RELAX_TIME3, workShift.RELAX_TIME4,
                //                   workShift.TURN_TIME.ToString(), supervisorId.ToString(),DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),"0");

            }

            //return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        #endregion
        #region Device
        public DataTable GetDevicesSyncStatus(int SlaveSID)
        {
            string strSql = string.Format("select distinct UserSID,DepartmentName,UserID,UserName,CardID,IsReplicated,TimeReplicated,~InActive AS SyncFlag,SlaveSID from [VDS_BF_User_Add] where SlaveSID={0} ", SlaveSID.ToString());
            return sqlDatabaseProvider.ExcuteTable(strSql);
        }
        public DataTable GetDeviceBaseList()
        {
            // Modified:    2023/10/14
            // Ver:         1.1.5.12
            //string SqlCommand = "SELECT [SlaveSID],[IP],  [SlaveName], [SlaveDescription] from [VS_SlaveIP]";
            string SqlCommand = "SELECT  [ListField], [SlaveSID],[IP],  [SlaveName], [SlaveDescription] from [VS_SlaveIP] ORDER BY SlaveSID ";

            return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }
        public DataTable GetDeviceBriefList()
        {
            // Modified:    2023/11/16
            // Version:     1.1.5.14
            // Note:        Toyota UI修正
            //string SqlCommand = "SELECT 0 as SlaveSID,'All' as IP,'' as SlaveName,'' as SlaveDescription from [VS_SlaveIP] union all SELECT [SlaveSID],[IP],  [SlaveName], [SlaveDescription] from [VS_SlaveIP]";
            string SqlCommand = "SELECT TOP (1) 0 as SlaveSID,'All' as IP,'' as SlaveName,'' as SlaveDescription, '' AS ListField from [VS_SlaveIP] union all SELECT [SlaveSID],[IP],  [SlaveName], [SlaveDescription], ListField  from [VS_SlaveIP] ORDER BY SlaveSID ";
            return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }
        public DataTable GetDeviceBriefDataList()
        {
            string SqlCommand = " SELECT [SlaveSID],[IP],  [SlaveName], [SlaveDescription],ISNULL(MenuPwd,'') as MenuPwd,ISNULL(WorkMode,0) as WorkMode,ISNULL(Language,0) as Language from [S_SlaveIP] where IsEnabled=1";
            return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }
        public DataTable GetDevicesList()//A.ID,
        {
            string SqlCommand = "SELECT A.[SlaveSID], A.[IP], A.[IP_Internal], A.[ListField], A.[SlaveName], A.[SlaveDescription], A.[IsEnabled],"
            + "A.[ResetToDefault], A.[SlaveCategoryID], A.[SlaveCategoryName], A.[IsServerMode], A.NotPropagateWithUsersByDefault,A.[DeviceType],ISNULL(b.UserCounts, 0 ) "
            + "AS UserCounts,ISNULL(c.UserReplicatedCount,0) AS UserReplicatedCount,ISNULL(d.FingersCounts,0) AS FingersCounts,ISNULL(e.FingersReplicatedCounts,0) "
            + "AS FingersReplicatedCounts,F.MenuPwd,F.WorkMode,F.Language FROM (SELECT dbo.S_SlaveIP.SlaveSID, dbo.S_SlaveIP.ID, dbo.S_SlaveIP.IP, dbo.FORMAT(dbo.S_SlaveIP.SlaveSID, '        0') + ' : ' + dbo.S_SlaveIP.IP + ' (' + LEFT(dbo.S_SlaveIP.SlaveName, 10) + ')' AS ListField, 'Slave' + dbo.FORMAT(dbo.S_SlaveIP.ID, '000')"
          + "AS SlaveHostColumn, 'S_IP' + dbo.FORMAT(dbo.S_SlaveIP.SlaveSID, '000000') AS SlaveHostColumn2, dbo.S_SlaveIP.SlaveName, dbo.S_SlaveIP.SlaveDescription, dbo.S_SlaveIP.IsEnabled, dbo.S_SlaveIP.ResetToDefault, dbo.S_SlaveIP.IP_Internal, "
          + "dbo.S_SlaveIP.SlaveCategoryID, dbo.BC_SlaveCategory.SlaveCategoryName, dbo.S_SlaveIP.IsServerMode, dbo.S_SlaveIP.IsOnLine, dbo.S_SlaveIP.StatusCode, dbo.S_SlaveIP.TimeAddNew, dbo.S_SlaveIP.TimeModifyLast, "
          + "dbo.S_SlaveIP.NotPropagateWithUsersByDefault,dbo.S_SlaveIP.DeviceType "
            + "FROM  dbo.S_SlaveIP INNER JOIN "
          + "dbo.BC_SlaveCategory ON dbo.S_SlaveIP.SlaveCategoryID = dbo.BC_SlaveCategory.SlaveCategoryID) AS A "
            + "left join (select [SlaveSID],count(distinct CardID) AS UserCounts from [VDS_BF_User_Add] where InActive =0 group by [SlaveSID]) AS B ON A.SlaveSID=B.SlaveSID "
            + "left join (select [SlaveSID],count(distinct CardID) AS UserReplicatedCount from [VDS_BF_User_Add] where InActive =0 and [IsReplicated]=1 group by [SlaveSID]) AS C ON A.SlaveSID=C.SlaveSID "
            + "left join (select [SlaveSID],count( CardID) AS FingersCounts from [DS_BF_FP_Add] where InActive =0  group by [SlaveSID]) AS D ON A.SlaveSID=D.SlaveSID "
            + "left join (select [SlaveSID],count( CardID) AS FingersReplicatedCounts from [DS_BF_FP_Add] where InActive =0 and [IsReplicated]=1 group by [SlaveSID]) AS E ON A.SlaveSID=E.SlaveSID "
            + "left join (select [SlaveSID],ISNULL(MenuPwd,'') as MenuPwd,ISNULL(WorkMode,0) as WorkMode,ISNULL(Language,0) as Language  FROM [S_SlaveIP]) AS F ON A.SlaveSID=F.SlaveSID ";

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
        public bool ResetAccessParameters(int SlaveSID)
        {
            ArrayList SQLStringList = new ArrayList();
            SQLStringList.Add(string.Format("update [DS_BF_TimeSet_SlaveSID] set [IsReplicated]=0 where [SlaveSID]={0}", SlaveSID.ToString()));
            SQLStringList.Add(string.Format("update [DS_BF_TimeZone_SlaveSID] set [IsReplicated]=0 where [SlaveSID]={0}", SlaveSID.ToString()));
            SQLStringList.Add(string.Format("update [DS_BF_Holiday_SlaveSID] set [IsReplicated]=0 where [SlaveSID]={0}", SlaveSID.ToString()));
            SQLStringList.Add(string.Format("update [DS_BF_UserGroup_SlaveSID] set [IsReplicated]=0 where [SlaveSID]={0}", SlaveSID.ToString()));

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
            "[NotPropagateWithUsersByDefault] = {7},[WorkMode]={9},[MenuPwd]='{10}',[Language]={11},[LanguageSync]=1,[WorkModeSync]=1,[MenuPwdSync]=1,[DeviceType]='{12}' WHERE [SlaveSID] = {8}", device.IP,
            device.SlaveName, device.SlaveDescription, device.IsEnabled ? "1" : "0", device.ResetToDefault ? "1" : "0", device.SlaveCategoryID.ToString(),
            device.IsServerMode ? "1" : "0", device.NotPropagateWithUsersByDefault ? "1" : "0", device.SlaveSID, device.WorkMode, device.MenuPwd, device.Language, device.DeviceType);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand);
        }
        private bool EmployeeHaveBeenReplicated(IList<EmployeeSync> backSyncList,EmployeeSync employeeSync)
        {
            foreach (EmployeeSync employeeTmp in backSyncList)
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
            foreach (EmployeeSync employeeTmp in backSyncList)
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
            // string SqlCommandActive = string.Format("UPDATE DS_BF_User_Add set [InActive]=0");
             //string SqlCommandInActive = string.Format("UPDATE DS_BF_User_Add set [InActive]=1");
             ArrayList SQLStringList = new ArrayList();
             foreach (EmployeeSync employeeSync in SyncList)
            {
                if (employeeSync.SyncFlag)
                {//需要同步
                    if (!EmployeeHaveBeenSetSync(backSyncList, employeeSync))
                    {//未设置同步
                        SQLStringList.Add(string.Format("UPDATE DS_BF_User_Add set [InActive]=0,[IsReplicated]=0 where UserSID={0} and SlaveSID={1}", employeeSync.UserSID.ToString(), SlaveId.ToString()));
                        SQLStringList.Add(string.Format("UPDATE DS_BF_FP_Add set [InActive]=0,[IsReplicated]=0 where CardID='{0}' and SlaveSID={1}", employeeSync.CardID.PadLeft(10, '0'), SlaveId.ToString()));
                    }
                }
                else
                {//禁止同步
                    if (EmployeeHaveBeenSetSync(backSyncList, employeeSync))
                    {//允许同步
                        SQLStringList.Add(string.Format("UPDATE DS_BF_User_Add set [InActive]=1 where UserSID={0} and SlaveSID={1}", employeeSync.UserSID.ToString(), SlaveId.ToString()));
                        SQLStringList.Add(string.Format("UPDATE DS_BF_FP_Add set [InActive]=1 where CardID='{0}' and SlaveSID={1}", employeeSync.CardID.PadLeft(10, '0'), SlaveId.ToString()));
                    }
                    if (EmployeeHaveBeenReplicated(backSyncList, employeeSync))
                    {//已经同步到机器
                        SQLStringList.Add(string.Format("DELETE FROM [DS_BF_User_Del] WHERE (UserSID = {0} and SlaveSID={1})", employeeSync.UserSID.ToString(), SlaveId.ToString()));
                       // SQLStringList.Add(string.Format("INSERT INTO [DS_BF_User_Del] (UserSID, CardID, SlaveSID, UserAddNewSID) SELECT U.UserSID, U.CardID, S.SlaveSID, 5566"+
	                   // " FROM [BF_User] AS U, [S_SlaveIP] AS S " +
                       // "WHERE U.UserSID = {0} ", employeeSync.UserSID.ToString()));
                        SQLStringList.Add(string.Format("INSERT INTO [DS_BF_User_Del] (UserSID, CardID, SlaveSID, UserAddNewSID) SELECT U.UserSID, U.CardID,{1}, 5566" +
                        " FROM [BF_User] AS U " +
                        "WHERE U.UserSID = {0} ", employeeSync.UserSID.ToString(), SlaveId.ToString()));
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
                + "[SlaveDescription], [IsEnabled], [ResetToDefault], [SlaveCategoryID], [IsServerMode], [NotPropagateWithUsersByDefault],[WorkMode],[MenuPwd],[Language],[LanguageSync],[WorkModeSync],[MenuPwdSync],[DeviceType])"
            + "VALUES ({0}, {1}, '{2}', '{3}', N'{4}', N'{5}', {6}, 0, {7}, {8}, {9},{10},'{11}',{12},1,1,1,'{13}');SELECT @@IDENTITY",
            device.SlaveSID.ToString(), id.ToString(), device.IP, device.IP_Internal, device.SlaveName, device.SlaveDescription,
            device.IsEnabled ? "1" : "0", device.SlaveCategoryID, device.IsServerMode ? "1" : "0", device.NotPropagateWithUsersByDefault ? "1" : "0", device.WorkMode, device.MenuPwd, device.Language,device.DeviceType);
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
                    + "[Holi1Group] = {7},[Holi2Group] = {8},[Holi3Group] = {9},[Holi4Group] = {10},[Holi5Group] = {11},[Holi6Group] = {12},[Holi7Group] = {13},[Holi8Group] = {14} "
                    +" WHERE [DoorID] = {15} AND [GroupID] = {16}",
                  usergroup.Sun.ToString(), usergroup.Mon.ToString(), usergroup.Tue.ToString(), usergroup.Wed.ToString(), usergroup.Thu.ToString(), usergroup.Fri.ToString(), usergroup.Sat.ToString(),
                  usergroup.Holi1Group.ToString(), usergroup.Holi2Group.ToString(), usergroup.Holi3Group.ToString(), usergroup.Holi4Group.ToString(), usergroup.Holi5Group.ToString(),
                  usergroup.Holi6Group.ToString(), usergroup.Holi7Group.ToString(), usergroup.Holi8Group.ToString(), usergroup.DoorID.ToString(), usergroup.GroupID.ToString()));
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
                SQLStringList.Add(string.Format("UPDATE [DS_BF_TimeSet] SET [StartHour] = {0}, [StartMin] = {1}, [EndHour] = {2}, [EndMin] = {3},TimeModifyLast = CURRENT_TIMESTAMP,Description=N'{6}',[UserModifyLastSID]={7} WHERE [DoorID] = {4} AND [TimeSetID] = {5}",
                  timeFrame.StartHour.ToString(), timeFrame.StartMin.ToString(), timeFrame.EndHour.ToString(), timeFrame.EndMin.ToString(), timeFrame.DoorID.ToString(), timeFrame.TimeSetID.ToString(), timeFrame.Description, OperationID.ToString()));
            }
            else
            {
                SQLStringList.Add(string.Format("INSERT INTO [DS_BF_TimeSet] ([DoorID], [TimeSetID], [StartHour], [StartMin], [EndHour], [EndMin], [Description],[UserAddNewSID]) "
                + "VALUES ({0}, {1}, {2}, {3}, {4}, {5},N'{7}',{6})",
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
                SQLStringList.Add(string.Format("update [DS_BF_Holiday] set [DoorHoliID]={0},HoliType={1},Description=N'{2}' where  HoliMonth={3} and HoliDay={4}",
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
        public DataTable GetElevatorControllerList()
        {
            return sqlDatabaseProvider.ExcuteTable(ELEVATOR_LISTFIELD_SQL);
        }
        public bool ElevatorControllerExitOrNot(Elevator elevator)
        {
            string SqlCommand = string.Format("SELECT * FROM [ElevatorControl] WHERE [SlaveSID] = {0}", elevator.SlaveSID.ToString());
            if (sqlDatabaseProvider.ExecuteSqlWitResult(SqlCommand) != null)
                return true;
            return false;
        }
        public bool UpdateElevator(Elevator elevator)
        {
            string SqlCommand = string.Format("UPDATE [ElevatorControl] SET [SlaveSID]={0},[EleavatorName] = N'{1}',[EleavatorDes] = N'{2}' WHERE [EleavatorID] = {3}", elevator.SlaveSID.ToString(), elevator.EleavatorName, elevator.EleavatorDes, elevator.EleavatorID.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool InsertElevator(Elevator elevator)
        {           

            string SqlCommand = string.Format("INSERT INTO [ElevatorControl] ([SlaveSID],[EleavatorName],[EleavatorDes]) VALUES ({0},N'{1}', N'{2}')", elevator.SlaveSID.ToString(), elevator.EleavatorName, elevator.EleavatorDes);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool DeleteElevator(ElevatorController elevator)
        {
            string SqlCommand = string.Format("DELETE FROM [ElevatorControl] WHERE [SlaveSID] = {0}", elevator.SlaveSID);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;

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
            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             * Modified:    2023/08/08
             * Ver:         1.1.5.11
             * string sSQL = string.Format("SELECT UnionType, UserSID, UserName, GroupSID, UserPermissionTypeID, DepartmentID, IsReadOnly,UserPWD FROM [VUN_SupervisorUser] WHERE (UserID = '{0}')", loginId);
             */
            string sSQL = string.Format("SELECT UnionType, UserSID, UserName, GroupSID, UserPermissionTypeID, DepartmentID, IsReadOnly, UserPWD, IsLocked, TimeLockout, PasswordExpirationDate  FROM [VUN_SupervisorUser] WHERE (UserID = '{0}')", loginId);
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
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
            /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
             * Remark:  2023/08/08
             * Ver:     1.1.5.11
            string SqlCommand = string.Format("UPDATE [BF_Supervisor] SET [UserPWD] = '{0}' WHERE [UserID] = '{1}'", newPin, supervisorId);
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
            */
            var result = SP_UPDATE_BF_Supervisor_Password(supervisorId, newPin);
            return result > 0 ? true : false;
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
        #endregion
        #region Employees
        public DataTable GetWorkCalendarMonthlyList(int Year)
        {
            string SqlCommand = string.Format("select UserSID,A.DepartmentID,B.DepartmentName,UserID,UserName,Year AS Year,Month AS Month,Day AS Day,WeekdayName,ShiftCode,ShiftName,StartTimeHour,StartTimeMinute,EndTimeHour,EndTimeMinute,DeductBreakMinute,Note from VBF_WorkCalendar AS A"
                + " left join VBF_Department AS B on A.DepartmentID = B.DepartmentID where Year={0}", Year.ToString());
            return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }
        public DataTable GetUserWorkShiftList()
        {
            string SqlCommand = "select distinct(a.UserSID),a.DepartmentID,b.DepartmentName,a.UserID,a.UserName,(select ShiftCode from VBF_UserWeeklyShift_2nd Week1  where WeekdayNo=1 and Week1.UserSID = a.UserSID) as Monday,"
        + "(select ShiftCode from VBF_UserWeeklyShift_2nd Week2  where WeekdayNo=2 and Week2.UserSID = a.UserSID) as Tuesday,"
        + "(select ShiftCode from VBF_UserWeeklyShift_2nd Week3  where WeekdayNo=3 and Week3.UserSID = a.UserSID) as Wednesday,"
        + "(select ShiftCode from VBF_UserWeeklyShift_2nd Week4  where WeekdayNo=4 and Week4.UserSID = a.UserSID) as Thursday,"
        + "(select ShiftCode from VBF_UserWeeklyShift_2nd Week5  where WeekdayNo=5 and Week5.UserSID = a.UserSID) as Friday,"
        + "(select ShiftCode from VBF_UserWeeklyShift_2nd Week6  where WeekdayNo=6 and Week6.UserSID = a.UserSID) as Saturday,"
        + "(select ShiftCode from VBF_UserWeeklyShift_2nd Week7  where WeekdayNo=7 and Week7.UserSID = a.UserSID) as Sunday "
        + "from VBF_UserWeeklyShift_2nd a Left  Join [VBF_Department]  b ON a.[DepartmentID]=b.[DepartmentID] ";
            return sqlDatabaseProvider.ExcuteTable(SqlCommand);
        }
        //
        public bool UpdateUserWorkShift(WorkShiftSetting workshiftsetting, int UserSID)
        {
            ArrayList SQLStringList = new ArrayList();

            SQLStringList.Add(string.Format("UPDATE [BF_UserWeeklyShift] SET [ShiftCode] = N'{0}' WHERE [WeekdayNo] = 1 AND [UserSID] = {1}", workshiftsetting.WorkShiftMon, UserSID.ToString()));
            SQLStringList.Add(string.Format("UPDATE [BF_UserWeeklyShift] SET [ShiftCode] = N'{0}' WHERE [WeekdayNo] = 2 AND [UserSID] = {1}", workshiftsetting.WorkShiftTues, UserSID.ToString()));
            SQLStringList.Add(string.Format("UPDATE [BF_UserWeeklyShift] SET [ShiftCode] = N'{0}' WHERE [WeekdayNo] = 3 AND [UserSID] = {1}", workshiftsetting.WorkShiftWedn, UserSID.ToString()));
            SQLStringList.Add(string.Format("UPDATE [BF_UserWeeklyShift] SET [ShiftCode] = N'{0}' WHERE [WeekdayNo] = 4 AND [UserSID] = {1}", workshiftsetting.WorkShiftThir, UserSID.ToString()));
            SQLStringList.Add(string.Format("UPDATE [BF_UserWeeklyShift] SET [ShiftCode] = N'{0}' WHERE [WeekdayNo] = 5 AND [UserSID] = {1}", workshiftsetting.WorkShiftFri, UserSID.ToString()));
            SQLStringList.Add(string.Format("UPDATE [BF_UserWeeklyShift] SET [ShiftCode] = N'{0}' WHERE [WeekdayNo] = 6 AND [UserSID] = {1}", workshiftsetting.WorkShiftSat, UserSID.ToString()));
            SQLStringList.Add(string.Format("UPDATE [BF_UserWeeklyShift] SET [ShiftCode] = N'{0}' WHERE [WeekdayNo] = 7 AND [UserSID] = {1}", workshiftsetting.WorkShiftSun, UserSID.ToString()));
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
        }
        public bool UpdateUserWorkShift(int WeekdayNo, string ShiftCode, int UserSID)
        {
            string SqlCommand = string.Format("UPDATE [BF_UserWeeklyShift] SET [ShiftCode] = N'{0}' WHERE [WeekdayNo] = {1} AND [UserSID] = {2}", ShiftCode, WeekdayNo.ToString(), UserSID.ToString());
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
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

        // Add: 2023/10/13
        // Ver: 1.1.5.12
        public DataTable GetUserSlaveAllowTime(int _slaveSID, string _departmentID
            , int? _allowTimeStartHour, int? _allowTimeEndHour)
        {
            string SqlCommand = string.Format("SELECT * "
                + "FROM [VBFX_UserSlaveAllowTime] "
                + "WHERE ("+ _slaveSID + " = 0 OR SlaveSID = " + _slaveSID + ") " 
                + " AND ('" + _departmentID + "' = '' OR DepartmentID = '" + _departmentID + "') "
                );

                if (_allowTimeStartHour != null)
                    SqlCommand += " AND (AllowTimeStartHour = " + _allowTimeStartHour + ") ";

                if (_allowTimeEndHour != null)
                    SqlCommand += " AND (AllowTimeEndHour = " + _allowTimeEndHour + ") ";


            //+ "WHERE (" + _slaveSID  + " = 0 OR SlaveSID = " + _slaveSID + ") ");

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
        
         public DataTable GetElevatorAuthorityList(int slaveId)
        {
            string strSqlQuery = string.Format(" SELECT  B.UserID,B.DepartmentID,B.DepartmentName,B.UserName,A.[CardID],A.[AllowTimeStartHour],A.[AllowTimeStartMinute],A.[AllowTimeEndHour],A.[AllowTimeEndMinute] ,A.[GroupID] from [VBFX_UserSlaveAllowTime]  AS A Left join[VBF_User] AS B ON A.CardID = B.CardID   where A.SlaveSID = {0}", slaveId.ToString());

            return sqlDatabaseProvider.ExcuteTable(strSqlQuery);
        }
        public DataTable GetEmployeesMsgList()
        {
            return sqlDatabaseProvider.ExcuteTable(EMPLOYEES_MSG_LIST_SQL);
        }
        public DataTable GetEmployeesBriefList()
        {
            string strSqlQuery = "SELECT UserSID,UserID,  A.DepartmentID, B.DepartmentName, UserName, CardID,[ShiftCategory] FROM [BF_User]  AS A LEFT JOIN [BF_Department] AS B ON A.DepartmentID=B.DepartmentID  where (A.[InActive]=0 OR (A.[InActive]=1 and DateDiff(day,A.TimeLastLogout,getdate()) <= 0)) order by UserID ";

            return sqlDatabaseProvider.ExcuteTable(strSqlQuery);
        }

        // Add:     2024/03/09
        // Ver:     1.1.5.17
        public DataTable GetEmployeesBriefList(string _departmentID)
        {
            string strSqlQuery = $"SELECT UserSID,UserID,  A.DepartmentID, B.DepartmentName, UserName, CardID,[ShiftCategory] FROM [BF_User]  AS A LEFT JOIN [BF_Department] AS B ON A.DepartmentID=B.DepartmentID  where (A.[InActive]=0 OR (A.[InActive]=1 and DateDiff(day,A.TimeLastLogout,getdate()) <= 0)) AND ('{_departmentID}' = '' OR A.DepartmentID = '{_departmentID}') order by UserID ";

            return sqlDatabaseProvider.ExcuteTable(strSqlQuery);
        }

        public DataTable GetEmployeesList()
        {
            return sqlDatabaseProvider.ExcuteTable(EMPLOYEES_LIST_SQL);
        }

        // Add:     2024/03/04
        // Ver:     1.1.5.17
        public DataTable GetEmployeesList(string _departmentID)
        {
            return sqlDatabaseProvider.ExcuteTable(
                string.Format(EMPLOYEES_LIST_SQL_WhereDept, _departmentID));
        }

        public bool UpdateDeviceParameters(IEnumerable<DeviceBrief> deviceList, string menuPwd, int workMode, int language)
        {
            string StrDeviceList = " WHERE [SlaveSID] in(";
            foreach (DeviceBrief device in deviceList)
            {
                StrDeviceList += "'" + device.SlaveSID.ToString() + "',";
            }
            StrDeviceList = StrDeviceList.TrimEnd(',');
            StrDeviceList += ")";
            string SqlCommand = "update S_SlaveIP set ";
            if (menuPwd != null)
            {
                SqlCommand += string.Format("MenuPwd='{0}',MenuPwdSync=1,",menuPwd);
            }
            if( workMode >= 0 )
            {
                SqlCommand += string.Format("WorkMode={0},WorkModeSync=1,", workMode.ToString());
            }
            if (language >= 0)
            {
                SqlCommand += string.Format("Language={0},LanguageSync=1,", language.ToString());
            }
            SqlCommand = SqlCommand.TrimEnd(',');
            SqlCommand += StrDeviceList;

            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public AcAuthority GetAuthorityList(int slaveSID, string cardId)
        {
            
            //    string strSql = string.Format("select [AllowTimeStartHour],[AllowTimeStartMinute],[AllowTimeEndHour],[AllowTimeEndMinute] ,[GroupID] from [VBFX_UserSlaveAllowTime] where [SlaveSID]={0} AND [CardID] = '{1}'", slaveSID.ToString(), cardId.PadLeft(10, '0'));
            //    DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
            //if (dt != null && dt.Rows.Count > 0)
            //{
            //    AcAuthority authorityPara = new AcAuthority();
            //    authorityPara.AllowTimeStartHour = Convert.ToByte(dt.Rows[0]["AllowTimeStartHour"]);
            //    authorityPara.AllowTimeStartMinute = Convert.ToByte(dt.Rows[0]["AllowTimeStartMinute"]);

            //    authorityPara.AllowTimeEndHour = Convert.ToByte(dt.Rows[0]["AllowTimeEndHour"]);
            //    authorityPara.AllowTimeEndMinute = Convert.ToByte(dt.Rows[0]["AllowTimeEndMinute"]);

            //    authorityPara.GroupID = Convert.ToByte(dt.Rows[0]["GroupID"]);

            //    return authorityPara;


            //}
            return null;
            
        }
        public bool UpdateEmployeeAuthority(IEnumerable<ElevatorController> deviceList, IEnumerable<EmployeeBrief> employeesObject, AcAuthority Authority, int OperationId)
        {
            string StrDeviceList = "(";
            string StrEmployeesList = "(";
            foreach (EmployeeBrief employee in employeesObject)
            {
                StrEmployeesList += "'" + employee.CardID.PadLeft(10, '0') + "',";
            }
            StrEmployeesList = StrEmployeesList.TrimEnd(',');
            StrEmployeesList += ")";
            foreach (ElevatorController device in deviceList)
            {
                StrDeviceList += "'" + device.SlaveSID.ToString() + "',";
            }
            StrDeviceList = StrDeviceList.TrimEnd(',');
            StrDeviceList += ")";
            ArrayList SQLStringList = new ArrayList();
            SQLStringList.Add("DELETE FROM [BFX_UserSlaveAllowTime] WHERE [CardID] in" + StrEmployeesList + " AND [SlaveSID] in" + StrDeviceList);

            SQLStringList.Add(string.Format("INSERT INTO [BFX_UserSlaveAllowTime] ([UserSID],[SlaveSID],[SlaveID],[CardID],[AllowTimeStartHour],[AllowTimeStartMinute],[AllowTimeEndHour],[AllowTimeEndMinute],[IsEnabled],[UserAddNewSID],[GroupID])"
            + "SELECT [UserSID],S.SlaveSID,S.SlaveSID,CardID,{0},{1},{2},{3},1,{7},{4} FROM [BF_User] AS U,[S_SlaveIP] AS S WHERE [SlaveSID] in{5}  and [CardID] in{6}", Authority.AllowTimeStartHour.ToString(),
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
            SQLStringList.Add("DELETE FROM [BFX_UserSlaveAllowTime] WHERE [CardID] in" + StrEmployeesList + " AND [SlaveSID] in" + StrDeviceList);

            SQLStringList.Add(string.Format("INSERT INTO [BFX_UserSlaveAllowTime] ([UserSID],[SlaveSID],[SlaveID],[CardID],[AllowTimeStartHour],[AllowTimeStartMinute],[AllowTimeEndHour],[AllowTimeEndMinute],[IsEnabled],[UserAddNewSID],[GroupID])"
            + "SELECT [UserSID],S.SlaveSID,S.SlaveSID,CardID,{0},{1},{2},{3},1,{7},{4} FROM [BF_User] AS U,[S_SlaveIP] AS S WHERE [SlaveSID] in{5}  and [CardID] in{6}", Authority.AllowTimeStartHour.ToString(),
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
                SqlCommand = string.Format("INSERT INTO [BF_JobCode] ([TranType], [JobCode], [JobName],[Remark]) VALUES ({0}, {0}, '{1}','{2}')", jobcode.TranType.ToString(), jobcode.JobName, jobcode.Remark);
         
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
        public bool UpdateEmployee(Employees employee, int OperationId, bool updateFace)
        {
            string SqlCommand = string.Format("UPDATE [BF_User] SET  [DepartmentID] = N'{0}', [UserName] = N'{1}',  [TitleName] =  N'{2}',  [IsTaOrNot] = {3}, [Email] = N'{4}', [TimeModifyLast] = CURRENT_TIMESTAMP, [TimeModifyLastSID] = {5}, [EmployeeTypeID] = N'{6}', [NotPropagateToSlaveByDefault] = {7},[RegPhoto]='{8}'  WHERE [UserSID] = {9}",
                    employee.DepartmentID,
                    employee.UserName,
                    employee.TitleName,
                    employee.IsTaOrNot ? "1" : "0",
                    employee.Email,
                    OperationId,
                    employee.EmployeeTypeID,
                    employee.SyncOrNot ? "1" : "0",
                    employee.RegPhoto,
                    employee.UserSID);
            if (sqlDatabaseProvider.ExecuteSql(SqlCommand) <= 0)
            {
                return false;
            }

            //更新人脸同步表
            //if(updateFace)
            //{
            //    SqlCommand = string.Format("update [DS_User_Face_Add] set IsReplicated = 0,TimeModifyLast = CURRENT_TIMESTAMP,UserModifyLastSID = {0} where CardID='{1}' AND InActive = 0 AND IsReplicated = 1 ", OperationId, employee.CardID.PadLeft(10, '0'));
            //    sqlDatabaseProvider.ExecuteSql(SqlCommand);
            //}
            

            SP_DS_Update_UserAdd_SetAllSlaveToZero_ExceptNegativeMask(employee.UserSID, OperationId);
            if (employee.SyncOrNot)
            {
                SqlCommand = string.Format("update [DS_BF_User_Add] set InActive = 1 where UserSID={0};update [DS_BF_FP_Add] set InActive = 1 where CardID='{1}' ", employee.UserSID, employee.CardID.PadLeft(10, '0'));
                sqlDatabaseProvider.ExecuteSql(SqlCommand);
                //if (updateFace)
                //{
                //    SqlCommand = string.Format("update [DS_User_Face_Add] set InActive = 1 where CardID='{0}' ", employee.CardID.PadLeft(10, '0'));
                //    sqlDatabaseProvider.ExecuteSql(SqlCommand);
                //}
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

            string SqlCommand = string.Format("INSERT INTO [BF_User] ([UserID], [DepartmentID], [UserName], [CardID], [TitleName], [IsTaOrNot], [Email], [UserPWD], [UserPin], [UserAddNewSID], [EmployeeTypeID], [NotPropagateToSlaveByDefault],[RegPhoto]) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', {5}, N'{6}', N'{7}', N'{8}', {9}, N'{10}', {11},'{12}');SELECT @@IDENTITY",
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
                employee.SyncOrNot?"1" : "0",
                employee.RegPhoto);
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

                // Add:2024/04/09 
                // Ver:1.1.5.20
                SP_INSERT_BFX_UserSlaveAllowTime(employee.CardID.PadLeft(10, '0'));


                //插入人脸同步资料
                //            ArrayList SQLStringList = new ArrayList();
                //            SQLStringList.Add(string.Format("DELETE FROM [DS_User_Face_Add] WHERE (CardID = '{0}')", employee.CardID.PadLeft(10, '0')));
                //            SQLStringList.Add(string.Format(@"INSERT [DS_User_Face_Add] (UserSID, CardID, SlaveSID, InActive, UserAddNewSID)

                //SELECT @UserSID, U.CardID, S.SlaveSID
                //    , CASE WHEN U.NotPropagateToSlaveByDefault = 1

                //        THEN 1

                //        ELSE(
                //            CASE WHEN S.NotPropagateWithUsersByDefault = 1 THEN 1 ELSE 0 END
                //            )

                //        END AS InActive
                //    , U.UserAddNewSID

                //FROM[BF_User] AS U, [VS_SlaveFace] AS S

                //WHERE UserSID = {0}", getUserSID.ToString()));
                //            sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);


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
            catch (Exception ex)
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
            
            try
            {
                string SqlCommand = string.Format("DELETE FROM [DS_BF_FP_Add] WHERE (CardID = '{0}')", cardid);
                sqlDatabaseProvider.ExecuteSql(SqlCommand);
            }
            catch(Exception ex)
            {

            }
            

            SP_DS_Delete_User_ForceDelete(sid, OperatorSID);
            return 1;
        }
        public bool DeleteEmployeeFinger(string cardid,int fingerno)
        {
            string SqlCommand = string.Format("SELECT * FROM [BF_FP] where [CardID] = '{0}' and FPNo={1}", cardid.PadLeft(10, '0'), fingerno.ToString());
            DataTable dt = sqlDatabaseProvider.ExcuteTable(SqlCommand);
            if (dt != null && dt.Rows.Count > 0)
            {
                return SP_DS_Delete_FP_FPNo(cardid, fingerno) > 0 ? true : false;
            }
            return true;
        }
        public bool DeleteEmployeeFinger12(string cardid)
        {
            string SqlCommand = string.Format("SELECT FPNo FROM [BF_FP] where [CardID] = '{0}'", cardid.PadLeft(10, '0'));
            DataTable dt = sqlDatabaseProvider.ExcuteTable(SqlCommand);
            bool bRet = true;
            if (dt != null && dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count;i++)
                {
                    if (SP_DS_Delete_FP_FPNo(cardid, Convert.ToInt32(dt.Rows[i]["FPNo"].ToString())) <= 0)
                    {
                        bRet = false;
                    }
                }
                 
            }
            //int rRet1 = SP_DS_Delete_FP_FPNo(cardid, 1);
            //int rRet2 = SP_DS_Delete_FP_FPNo(cardid, 2);
            //return rRet1 > 0 && rRet2 > 0;
            return bRet;
        }
        public DataBaseAccessErrorCode ChangeCardIdOfUser(string oldCardId, string newCardId,string createname)
        {
            int UserSID;

            if (SP_IsExist_User_CardID(newCardId, out UserSID) > 0)
            {
                return DataBaseAccessErrorCode.ExisitedCardId;
            }
            ArrayList SQLStringList = new ArrayList();
            SQLStringList.Add(string.Format("update BF_User set [CardID]='{0}' where [CardID]='{1}'", newCardId, oldCardId));
            SQLStringList.Add(string.Format("update BFX_UserSlaveAllowTime set [CardID]='{0}' where [CardID]='{1}'", newCardId, oldCardId));
            SQLStringList.Add(string.Format("update DS_BF_User_Add set [CardID]='{0}' where [CardID]='{1}'", newCardId, oldCardId));
            SQLStringList.Add(string.Format("update DS_BF_User_Del set [CardID]='{0}' where [CardID]='{1}'", newCardId, oldCardId));
            SQLStringList.Add(string.Format("update DS_BF_FP_Add set [CardID]='{0}' where [CardID]='{1}'", newCardId, oldCardId));
            SQLStringList.Add(string.Format("update DS_BF_FP_Del set [CardID]='{0}' where [CardID]='{1}'", newCardId, oldCardId));
            SQLStringList.Add(string.Format("update BF_FP set [CardID]='{0}' where [CardID]='{1}'", newCardId, oldCardId));
            SQLStringList.Add(string.Format("update PER_CHK set [CardID]='{0}' where [CardID]='{1}'", newCardId, oldCardId));
            SQLStringList.Add(string.Format("update OR_Transactions set [CardID]='{0}' where [CardID]='{1}'", newCardId, oldCardId));
            SQLStringList.Add(string.Format("insert into [CHANGE_CARD] ([SlaveSID],[OldCardID],[NewCardID],[IsReplicated],[CREATE_NAME],[CREATE_TIME]) select [SlaveSID],'{0}','{1}',0,N'{2}','{3}' from [S_SlaveIP] where [IsEnabled] = 1", oldCardId, newCardId, createname, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

            try
            {

                sqlDatabaseProvider.ExecuteSqlTran(SQLStringList);
                return 0;
            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return DataBaseAccessErrorCode.OperationError;
        }
        public bool ReSyncAll()
        {
            string SqlCommand = string.Format("update [DS_BF_User_Add] set IsReplicated = 0 where InActive=0;update [DS_BF_FP_Add] set IsReplicated = 0 where InActive=0");/*;update [DS_User_Face_Add] set IsReplicated = 0 where InActive=0*/
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool ReSyncSelectedEmployee(Employees employee)
        {
            string SqlCommand = string.Format("update [DS_BF_User_Add] set IsReplicated = 0 where InActive=0 and CardID='{0}';update [DS_BF_FP_Add] set IsReplicated = 0 where InActive=0 and CardID='{0}'", employee.CardID.PadLeft(10, '0')); //; update[DS_User_Face_Add] set IsReplicated = 0 where InActive = 0 and CardID = '{0}'
            return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
        }
        public bool EnableEmployees(IEnumerable<Employees> employeesObject, int OperatorSID)
        {
            ArrayList SQLStringList = new ArrayList();
            foreach (Employees employee in employeesObject)
            {
                SQLStringList.Add(string.Format("update BF_User set InActive=0,TimeLastLogout=NULL where UserSID={0}", employee.UserSID));
                SQLStringList.Add(string.Format("delete from DS_BF_User_Del where UserSID={0}", employee.UserSID));
                SQLStringList.Add(string.Format("delete from DS_BF_User_Add where UserSID={0}", employee.UserSID));
                SQLStringList.Add(string.Format("delete from DS_BF_FP_Add where CardID='{0}'", employee.CardID.PadLeft(10, '0')));
                SQLStringList.Add(string.Format("delete from DS_BF_FP_Del where CardID='{0}'", employee.CardID.PadLeft(10, '0')));

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
            + "WHERE U.CardID = '{0}' ", employee.CardID.PadLeft(10, '0'), OperatorSID);
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
        public bool CreateEmployeesMonthlyShift(IEnumerable<EmployeeBrief> employeesBriefObject, int SelYear)
        {
            
            foreach (EmployeeBrief employeeBrief in employeesBriefObject )
            {
                for (int i = 1; i < 13; i++)
                {
                    SP_Delete_BF_WorkCalendar_ByUserMonth(employeeBrief.UserSID, SelYear, i);
                    SP_Insert_WorkShift_CreatFromUWS_Month(employeeBrief.UserSID, SelYear, i);
                }
            }
            return true;
        }
        public bool CreateEmployeesMonthlyShift(IList<EmployeeBrief> employeesBriefList, int SelYear)
        {
            foreach (EmployeeBrief employeeBrief in employeesBriefList)
            {
                for (int i = 1; i < 13; i++)
                {
                    SP_Delete_BF_WorkCalendar_ByUserMonth(employeeBrief.UserSID, SelYear, i);
                    SP_Insert_WorkShift_CreatFromUWS_Month(employeeBrief.UserSID, SelYear, i);
                }
            }
            return true;
        }
        public bool DisableEmployees(IEnumerable<Employees> employeesObject, int OperatorSID)
        {
           // string SqlCommand = "";
            ArrayList SQLStringList = new ArrayList();
            foreach (Employees employee in employeesObject)
            {
                SQLStringList.Add(string.Format("update BF_User set InActive=1,[TimeLastLogout]=CURRENT_TIMESTAMP where UserSID={0}", employee.UserSID));
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
        public  double JongCheckExcelVer()
        {
            Type objExcelType = Type.GetTypeFromProgID("Excel.Application");
            if (objExcelType == null)
            {
                return 0;
            }
            object objApp = Activator.CreateInstance(objExcelType);
            if (objApp == null)
            {
                return 0;
            }
            object objVer = objApp.GetType().InvokeMember("Version", System.Reflection.BindingFlags.GetProperty, null, objApp, null);
            double iVer = Convert.ToDouble(objVer.ToString());
            objVer = null;
            objApp = null;
            objExcelType = null;
            GC.Collect();
            return iVer;
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

            double excelVersion = JongCheckExcelVer();
            //if (bXlsx)
            //{
            //    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
            //             "Data Source=" + ImportFilePath + ";" +
            //             "Extended Properties=Excel 8.0;";
            //}
            //else
            //{
            //    strConn = "Microsoft.Jet.OLEDB.4.0;" +
            //             "Data Source=" + ImportFilePath + ";" +
            //             "Extended Properties=Excel 8.0;";
            //}
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                         "Data Source=" + ImportFilePath + ";" +
                         "Extended Properties=Excel 8.0;";
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
                sSQL = "Select " + strSqlSelect_ImportToDB +" FROM [" + strWorkSheetName + "] Where CardID<> NULL";
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
                         sSQL = "SELECT CardID FROM " + TBN_Import_BF_User + " WHERE (LEN(CardID) > 10)";
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
        private int SP_Insert_WorkShift_CreatFromUWS_Month(int UserSID, int Year, int Month)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            sqlPara[1] = new SqlParameter("@YearValue", SqlDbType.Int);
            sqlPara[1].Value = Year;

            sqlPara[2] = new SqlParameter("@MonthValue", SqlDbType.Int);
            sqlPara[2].Value = Month;

            return DataBase.RunProcedure(cn, "SP_Insert_WorkShift_CreatFromUWS_Month", sqlPara, out rowsAffect);
        }
        private int SP_Delete_BF_WorkCalendar_ByUserMonth(int UserSID, int Year, int Month)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            sqlPara[1] = new SqlParameter("@Year", SqlDbType.Int);
            sqlPara[1].Value = Year;

            sqlPara[2] = new SqlParameter("@Month", SqlDbType.Int);
            sqlPara[2].Value = Month;

            return DataBase.RunProcedure(cn, "SP_Delete_BF_WorkCalendar_ByUserMonth", sqlPara, out rowsAffect);
        }
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


        /*  Add:2024/04/09
         *  Ver:1.1.5.20
         *  Toyota 預設不允許進入	@IsDisallowFullTime = 1
         */
        private int SP_INSERT_BFX_UserSlaveAllowTime(string CardID, short? SlaveID = 0, bool? IsDisallowFullTime = null)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[3];

            sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar,14);
            sqlPara[0].Value = CardID;

            sqlPara[1] = new SqlParameter("@SlaveID", SqlDbType.SmallInt);
            if (SlaveID == null)
            {
                sqlPara[1].IsNullable = true;
                sqlPara[1].Value = DBNull.Value;
            }
            else
            {
                sqlPara[1].Value = SlaveID;
            }

            sqlPara[2] = new SqlParameter("@IsDisallowFullTime", SqlDbType.Bit);
            if (IsDisallowFullTime == null)
            {
                sqlPara[2].IsNullable = true;
                sqlPara[2].Value = DBNull.Value;
            }
            else
            {
                sqlPara[2].Value = IsDisallowFullTime;
            }

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_INSERT_BFX_UserSlaveAllowTime", sqlPara, out rowsAffect);
        }
        #endregion
        #region Attendacne
        public int SP_DELETE_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(int LeaveApplicationHeadSID)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@LeaveApplicationHeadSID", SqlDbType.Int);
            sqlPara[0].Value = LeaveApplicationHeadSID;



            return DataBase.RunProcedure(cn, "SP_DELETE_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID", sqlPara, out rowsAffect);
        }
        public int SP_INSERT_REL_LeaveApplication_Justification(string BeginDate, string EndDate, string DepartmentID = "", int UserSID =0)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@BeginDate", SqlDbType.Date);
            sqlPara[0].Value = BeginDate;

            sqlPara[1] = new SqlParameter("@EndDate", SqlDbType.Date);
            sqlPara[1].Value = EndDate;

            sqlPara[2] = new SqlParameter("@DepartmentID", SqlDbType.NVarChar,10);
            if (string.IsNullOrEmpty(DepartmentID))
            {
                sqlPara[2].IsNullable = true;
            }
            else
            {
                sqlPara[2].Value = DepartmentID;
            }

            sqlPara[3] = new SqlParameter("@UserSID", SqlDbType.Bit);
            if (UserSID == 0)
            {
                sqlPara[3].IsNullable = true;
            }
            else
            {
                sqlPara[3].Value = UserSID;
            }
            

            return DataBase.RunProcedure(cn, "SP_INSERT_REL_LeaveApplication_Justification", sqlPara, out rowsAffect);
        }
        public int SP_INSERT_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID(int LeaveApplicationHeadSID, string LeaveTypeID, int LeaveMinute, bool IsJustificationLeave)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[4];
            sqlPara[0] = new SqlParameter("@LeaveApplicationHeadSID", SqlDbType.Int);
            sqlPara[0].Value = LeaveApplicationHeadSID;

            sqlPara[1] = new SqlParameter("@LeaveTypeID", SqlDbType.NVarChar,12);
            sqlPara[1].Value = LeaveTypeID;

            sqlPara[2] = new SqlParameter("@LeaveMinute", SqlDbType.SmallInt);
            sqlPara[2].Value = LeaveMinute;

            sqlPara[3] = new SqlParameter("@IsJustificationLeave", SqlDbType.Bit);
            sqlPara[3].Value = IsJustificationLeave;

            return DataBase.RunProcedure(cn, "SP_INSERT_OR_LeaveApplication_Detail_ByLeaveApplicationHeadSID", sqlPara, out rowsAffect);
        }
        public int SP_GET_OR_LeaveApplication_Head_ByUserSID_Date(int UserSID, string DateJustification, int LeaveApplicationHeadSID_Orinigal=0)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            sqlPara[1] = new SqlParameter("@DateJustification", SqlDbType.Date);
            sqlPara[1].Value = DateJustification;

            sqlPara[2] = new SqlParameter("@LeaveApplicationHeadSID_Orinigal", SqlDbType.Int);
            sqlPara[2].Value = LeaveApplicationHeadSID_Orinigal;

            return DataBase.RunProcedure(cn, "SP_GET_OR_LeaveApplication_Head_ByUserSID_Date", sqlPara, out rowsAffect);
        }
        public int SP_INSERT_BF_GlobalHolidaySetting_Detail(int GlobalHolidaySID, int UserAddNewSID, bool DeleteBeforeInsert)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[3];
            sqlPara[0] = new SqlParameter("@GlobalHolidaySID", SqlDbType.Int);
            sqlPara[0].Value = GlobalHolidaySID;

            sqlPara[1] = new SqlParameter("@UserAddNewSID", SqlDbType.Int);
            sqlPara[1].Value = UserAddNewSID;

            sqlPara[2] = new SqlParameter("@DeleteBeforeInsert", SqlDbType.Bit);
            sqlPara[2].Value = DeleteBeforeInsert;

            return DataBase.RunProcedure(cn, "SP_INSERT_BF_GlobalHolidaySetting_Detail", sqlPara, out rowsAffect);
        }
        public int SP_Update_WorkShift_SetDefault(string ShiftCode)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@ShiftCode", SqlDbType.NVarChar, 6);
            sqlPara[0].Value = ShiftCode;

            return DataBase.RunProcedure(cn, "SP_Update_WorkShift_SetDefault", sqlPara, out rowsAffect);
        }
        public int SP_Insert_AttendanceStatusCode_FromWorkShift(string ShiftCode = null)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[1];
            sqlPara[0] = new SqlParameter("@ShiftCode", SqlDbType.NVarChar, 6);
            sqlPara[0].Value = ShiftCode;

            return DataBase.RunProcedure(cn, "SP_Insert_AttendanceStatusCode_FromWorkShift", sqlPara, out rowsAffect);
        }
        #endregion

        #endregion







        /*
         * Add:     2023/07/28
         * Ver:     1.1.5.11
         */
        public int SP_INSERT_S_UserLoginHistoryLog(string LoginID, string LoginPassword, bool IsSuccessfulLogon, int? UserSID = null)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[4];

            sqlPara[0] = new SqlParameter("@LoginID", SqlDbType.VarChar,16);
            sqlPara[0].Value = LoginID;
            sqlPara[1] = new SqlParameter("@LoginPassword", SqlDbType.VarChar,128);
            sqlPara[1].Value = LoginPassword;
            sqlPara[2] = new SqlParameter("@IsSuccessLogon", SqlDbType.Bit);
            sqlPara[2].Value = IsSuccessfulLogon;
            sqlPara[3] = new SqlParameter("@UserSID", SqlDbType.Int);
            
            if (UserSID == null)
            {
                sqlPara[3].IsNullable = true;
                sqlPara[3].Value = DBNull.Value;
            }
            else
            {
                sqlPara[3].Value = UserSID;
            }
            

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_INSERT_S_UserLoginHistoryLog", sqlPara, out rowsAffect);
        }

        public int SP_INSERT_S_UserPasswordHistory(int UserSID, string PasswordHash)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[2];

            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;
            sqlPara[1] = new SqlParameter("@PasswordHash", SqlDbType.VarChar, 128);
            sqlPara[1].Value = PasswordHash;
                                 

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_INSERT_S_UserPasswordHistory", sqlPara, out rowsAffect);
        }


        public int SP_UPDATE_BF_Supervisor_IsLocked(int UserSID, string UserID, bool IsLocked)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[3];

            sqlPara[0] = new SqlParameter("@UserSID", SqlDbType.Int);
            sqlPara[0].Value = UserSID;

            if (UserSID == default(int))
            {
                sqlPara[0].IsNullable = true;
                sqlPara[0].Value = DBNull.Value;
            }

            sqlPara[1] = new SqlParameter("@UserID", SqlDbType.NVarChar,12);
            sqlPara[1].Value = UserID;
            if (string.IsNullOrEmpty(UserID))
            {
                sqlPara[1].IsNullable = true;
                sqlPara[1].Value = DBNull.Value;
            }


            sqlPara[2] = new SqlParameter("@IsLocked", SqlDbType.Bit);
            sqlPara[2].Value = IsLocked;


            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_UPDATE_BF_Supervisor_IsLocked", sqlPara, out rowsAffect);
        }


        private int SP_UPDATE_BF_Supervisor_Password(string UserID, string UserPWD)
        {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;
            SqlParameter[] sqlPara = new SqlParameter[2];

            sqlPara[0] = new SqlParameter("@UserID", SqlDbType.NVarChar,12);
            sqlPara[0].Value = UserID;

            sqlPara[1] = new SqlParameter("@UserPWD", SqlDbType.NVarChar,128);
            sqlPara[1].Value = UserPWD;

            int rowsAffect = 0;
            return DataBase.RunProcedure(cn, "SP_UPDATE_BF_Supervisor_Password", sqlPara, out rowsAffect);
        }


        public DataTable GetUserPasswordHistoryList(string UserID)
        {

            string sSQL = string.Format("SELECT TOP(5) H.* FROM [S_UserPasswordHistory] AS H INNER JOIN [BF_Supervisor] AS S ON H.UserSID = S.UserSID WHERE (S.UserID = '{0}') ORDER BY LogNo DESC", UserID);
            return sqlDatabaseProvider.ExcuteTable(sSQL);
        }
        public DataTable GetUserPasswordHistoryList(int UserSID)
        {
           
            string sSQL = string.Format("SELECT TOP(5) * FROM [S_UserPasswordHistory] WHERE (UserSID = '{0}') ORDER BY LogNo DESC", UserSID);
            return sqlDatabaseProvider.ExcuteTable(sSQL);
        }
        public DataTable GetUserLoginHistoryLogList(string LoginID)
        {
            string sSQL = string.Format("SELECT TOP(10) * FROM [S_UserLoginHistoryLog] WHERE (LoginID = '{0}') ORDER BY LoginActionNo DESC", LoginID);
            return sqlDatabaseProvider.ExcuteTable(sSQL);
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~



    }

}
