﻿using KCS.Common.DAL;
using KCS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Common
{
    public class SyncDatabaseHelper : IDisposable
    {
        private  SQLDataProvider sqlDatabaseProvider ;
        #region LOCKERS
        public static readonly object sqlServerLocker = new object();
        #endregion
        
        public SyncDatabaseHelper()
        {
            sqlDatabaseProvider = new SQLDataProvider();
        }
        public void Dispose()
        {
            sqlDatabaseProvider.Dispose();
        }
        public Employees GetEmployeeByCardId(string cardId)
        {//[UserID],[UserName]
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select * from [BF_User] where [CardID]='{0}'", cardId);
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
            
           IList<Employees> List =  KCS.Common.Utils.ModelConvertHelper<Employees>.ConvertToModel(dt);
           if (List != null && List.Count > 0)
            {
                return List[0];
            }
            return null;
            }
        }
        public bool ResetDeviceOK(int slaveId)
        {
            lock (sqlServerLocker)
            {
                ArrayList SQLStringList = new ArrayList();
                SQLStringList.Add(string.Format("update S_SlaveIP WITH(ROWLOCK) set ResetToDefault = 0 where SlaveSID ={0}", slaveId.ToString()));
                SQLStringList.Add(string.Format("update DS_BF_User_Add WITH(ROWLOCK) set IsReplicated = 0 where SlaveSID ={0}", slaveId.ToString()));
                SQLStringList.Add(string.Format("update DS_BF_User_Del WITH(ROWLOCK) set IsReplicated = 0 where SlaveSID ={0}", slaveId.ToString()));
                SQLStringList.Add(string.Format("update DS_BF_FP_Add WITH(ROWLOCK) set IsReplicated = 0 where SlaveSID ={0}", slaveId.ToString()));
                SQLStringList.Add(string.Format("update DS_BF_FP_Del WITH(ROWLOCK) set IsReplicated = 0 where SlaveSID ={0}", slaveId.ToString()));
                SQLStringList.Add(string.Format("update BFX_UserSlaveAllowTime WITH(ROWLOCK) set IsReplicated = 0 where SlaveSID ={0}", slaveId.ToString()));
                //SQLStringList.Add(string.Format("update DS_User_Face_Add WITH(ROWLOCK) set IsReplicated = 0 where SlaveSID ={0}", slaveId.ToString()));
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
            
        }
        public bool ResetDeviceToDefault(int slaveId)
        {
            lock (sqlServerLocker)
            {
                string SqlCommand = string.Format("update S_SlaveIP WITH(ROWLOCK) set ResetToDefault = 1 where SlaveSID ={0}", slaveId.ToString());
                return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
            }
        }
        public bool SetDoorPinOK(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string SqlCommand = string.Format("update [DOOR_PWD] WITH(ROWLOCK) set [IsReplicated] = 1 where SlaveSID ={0}", slaveSID.ToString());
                return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;
            }
        }
        public bool UpdateDoorPin(DoorPIN pin, int slaveSID)
        {
            lock (sqlServerLocker)
            {
                ArrayList SQLStringList = new ArrayList();
                SQLStringList.Add(string.Format("delete from [DOOR_PWD] where [SlaveSID]={0}", slaveSID.ToString()));

                SQLStringList.Add(string.Format(@"insert into [DOOR_PWD]([SlaveSID], [PIN1_NAME],[PIN1_CODE],[PIN1_START_DATE],[PIN1_START_HOUR],[PIN1_START_MIN],[PIN1_END_DATE],
[PIN1_END_HOUR],[PIN1_END_MIN],[PIN1],[PIN2_NAME],[PIN2_CODE],[PIN2_START_DATE],[PIN2_START_HOUR],[PIN2_START_MIN],[PIN2_END_DATE],[PIN2_END_HOUR],[PIN2_END_MIN],[PIN2],[IsReplicated]) VALUES ({0},'{1}',{2},{3},{4},{5},{6},EncryptByPassPhrase('k12sc','{7}'),'{8}',{9},{10},{11},{12},{13},EncryptByPassPhrase('k12sc','{14}'),0)", slaveSID.ToString(), pin.PIN1Name.ToString(), pin.PIN1Code.ToString(), pin.PIN1StartDate.ToString(), pin.PIN1StartHour.ToString(),
                                         pin.PIN1StartMinute.ToString(),pin.PIN1EndDate.ToString(),pin.PIN1EndHour.ToString(),pin.PIN1EndMinute.ToString(),pin.PIN1.ToString(),
                                          pin.PIN2Name.ToString(), pin.PIN2Code.ToString(), pin.PIN2StartDate.ToString(), pin.PIN2StartHour.ToString(),
                                         pin.PIN2StartMinute.ToString(), pin.PIN2EndDate.ToString(),pin.PIN2EndHour.ToString(), pin.PIN2EndMinute.ToString(), pin.PIN2.ToString()));
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
        }
        public IList<DoorPIN> GetOpenDoorPinList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format(@"select [PIN1_NAME],[PIN1_CODE],[PIN1_START_DATE],[PIN1_START_HOUR],[PIN1_START_MIN],[PIN1_END_DATE],[PIN1_END_HOUR],[PIN1_END_MIN] ,CONVERT(VARCHAR(6),DecryptByPassPhrase('k12sc',[PIN1])) AS PIN1,[PIN2_NAME],[PIN2_CODE] ,[PIN2_START_DATE],[PIN2_START_HOUR],[PIN2_START_MIN],[PIN2_END_DATE],[PIN2_END_HOUR],[PIN2_END_MIN],CONVERT(VARCHAR(6),DecryptByPassPhrase('k12sc',[PIN2])) AS PIN2 from [DOOR_PWD] where [SlaveSID]={0} AND [IsReplicated] = 0", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
                return KCS.Common.Utils.ModelConvertHelper<DoorPIN>.ConvertToModel(dt);
            }
        }
        public string GetRegisterPhotoPath(string cardid)
        {
            string strSql = string.Format("select [RegPhoto] from [BF_User] where [CardID]='{0}'", cardid);
            var objReturn = sqlDatabaseProvider.ExecuteSqlWitResult(strSql);
            if (objReturn == null)
                return "";
            return Convert.ToString(objReturn);
        }
        public IList<AcTimeSet> GetTimeSetList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select [DoorID],[TimeSetID],[StartHour],[StartMin],[EndHour],[EndMin] from [VDS_BF_TimeSet_SlaveSID] where [SlaveSID]={0} AND [TimeSetID]<32 AND [DoorID] <=2 AND [IsReplicated] = 0", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
                return KCS.Common.Utils.ModelConvertHelper<AcTimeSet>.ConvertToModel(dt);
            }
        }
        public IList<AcTimeZone> GetTimeZoneList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select [DoorID],[TimeZoneID],[Frame01],[Frame02],[Frame03],[Frame04] from [VDS_BF_TimeZone_SlaveSID] where [SlaveSID]={0} AND [TimeZoneID]<64 AND [DoorID] <=2 AND [IsReplicated] = 0", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
                return KCS.Common.Utils.ModelConvertHelper<AcTimeZone>.ConvertToModel(dt);
            }
        }
        public IList<AcUserGroupSet> GetUserGroupSetList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select [DoorID],[GroupID],[Sun],[Mon],[Tue],[Wed],[Thu],[Fri],[Sat],[Holi1Group],[Holi2Group],[Holi3Group],[Holi4Group],[Holi5Group],[Holi6Group],[Holi7Group],[Holi8Group] from [VDS_BF_UserGroup_SlaveSID] where [SlaveSID]={0} AND [GroupID] < 16 AND [DoorID] <=2 AND [IsReplicated] = 0", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
                return KCS.Common.Utils.ModelConvertHelper<AcUserGroupSet>.ConvertToModel(dt);
            }
        }
        public IList<AcHolidaySet> GetHolidaySetList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select [DoorID],[DoorHoliID],[HoliMonth],[HoliDay],[HoliType] from [VDS_BF_Holiday_SlaveSID] where [SlaveSID]={0} AND [DoorID] <=2 AND [IsReplicated] = 0", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
                return KCS.Common.Utils.ModelConvertHelper<AcHolidaySet>.ConvertToModel(dt);
            }
        }
        public SyncParameter GetDeviceParameters(int slaveSID)
        {
            lock (sqlServerLocker)
            {

                string strSql = string.Format("select ISNULL([MenuPwd],'') AS MenuPwd,[MenuPwdSync],ISNULL([WorkMode],0) AS WorkMode,[WorkModeSync],ISNULL([Language],0) AS Language,[LanguageSync] from [S_SlaveIP] where [SlaveSID]={0}", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    SyncParameter syncPara = new SyncParameter();
                    syncPara.MenuPwd = dt.Rows[0]["MenuPwd"].ToString();
                    syncPara.SyncMenuPwdFlag = Convert.ToBoolean(dt.Rows[0]["MenuPwdSync"]);

                    syncPara.WorkMode = Convert.ToInt32(dt.Rows[0]["WorkMode"]);
                    syncPara.SyncWorkModeFlag = Convert.ToBoolean(dt.Rows[0]["WorkModeSync"]);

                    syncPara.Language = Convert.ToInt32(dt.Rows[0]["Language"]);
                    syncPara.SyncLanguageFlag = Convert.ToBoolean(dt.Rows[0]["LanguageSync"]);

                    return syncPara;


                }
                return null;
                
            }
        }
        public IList<AcAuthority> GetAuthorityList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select TOP 200 A.[CardID],[SlaveID],[AllowTimeStartHour],[AllowTimeStartMinute],[AllowTimeEndHour],[AllowTimeEndMinute] ,[GroupID] from [VBFX_UserSlaveAllowTime] AS A Left join DS_BF_User_Add AS B ON A.CardID = B.CardID AND A.SlaveSID = B.SlaveSID where A.[SlaveSID] = {0} AND A.[IsReplicated] = 0 AND B.IsReplicated = 1", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
                return KCS.Common.Utils.ModelConvertHelper<AcAuthority>.ConvertToModel(dt);
            }
        }
       
        public IList<UserInfoAdd> GetUserAddList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                // string strSql = string.Format("select * from [UDF_DS_BF_User_Add_BySlaveSID]({0})", slaveSID.ToString());
                string strSql = string.Format(@"SELECT TOP 200 
      A.[UserSID]
      ,A.[UserID]
      ,A.[DepartmentID]
      ,A.[UserName]
      ,A.[CardID]
      ,A.[FingerPrint1]
      ,A.[FingerPrint2]
      ,A.[Group1]
      ,A.[Group2]
      ,A.[UserPin]
      ,A.[ValidDate]
      ,A.[AllowTimeStartHour] * 100 + A.[AllowTimeStartMinute] AS StartTime 
      ,A.AllowTimeEndHour * 100 + A.AllowTimeEndMinute AS EndTime
	  ,B.RegPhoto
	FROM [VDS_BF_User_Add] AS A left join BF_User AS B ON A.CardID = B.CardID
	WHERE A.InActive = 0 AND A.SlaveSID = {0} AND A.IsReplicated = 0 
	ORDER BY A.UserAddSID ASC", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
            
                return KCS.Common.Utils.ModelConvertHelper<UserInfoAdd>.ConvertToModel(dt);
            }
        }
        public IList<UserInfoDel> GetUserDeleteList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select * from [UDF_DS_BF_User_Del_BySlaveSID]({0})", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
            
            return KCS.Common.Utils.ModelConvertHelper<UserInfoDel>.ConvertToModel(dt);
            }
        }
        public IList<UserFingerAdd> GetUserFingerAddList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select * from [UDF_DS_BF_FP_Add_BySlaveSID]({0})", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
            
            return KCS.Common.Utils.ModelConvertHelper<UserFingerAdd>.ConvertToModel(dt);
            }
        }
        public IList<UserFingerDel> GetFingerDeleteList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select * from [UDF_DS_BF_FP_Del_BySlaveSID]({0})", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);
            
            return KCS.Common.Utils.ModelConvertHelper<UserFingerDel>.ConvertToModel(dt);
            }
        }
        public IList<ChangeCardIDCls> GetChageCardIdList(int slaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("select TOP 200 ChangeID,OldCardID,NewCardID from [VCHANGE_CARD] where [SlaveSID]={0}", slaveSID.ToString());
                DataTable dt = sqlDatabaseProvider.ExcuteTable(strSql);

                return KCS.Common.Utils.ModelConvertHelper<ChangeCardIDCls>.ConvertToModel(dt);
            }
        }
        #region Sync
        public bool UPDATE_DevicePara(int SlaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("update [S_SlaveIP] set [WorkModeSync] = 0,[LanguageSync]=0,[MenuPwdSync]=0 where [SlaveSID]={0}", SlaveSID.ToString());

                return sqlDatabaseProvider.ExecuteSql(strSql) > 0 ? true : false;
            }
        }
        public bool UPDATE_ChangeCardID(int SlaveSID, UInt32 ChangeId)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("update [CHANGE_CARD] set [IsReplicated]=1 where [SlaveSID]={0} AND [ChangeID]={1}", SlaveSID.ToString(), ChangeId.ToString());

                return sqlDatabaseProvider.ExecuteSql(strSql) > 0 ? true : false;
            }
        }
        public bool UPDATE_DS_BF_TimeSet_SlaveSID(int SlaveSID, int DoorID, int TimeSetID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("update [DS_BF_TimeSet_SlaveSID] set [IsReplicated]=1 where [SlaveSID]={0} AND [DoorID]={1} AND [TimeSetID]={2}", SlaveSID.ToString(), DoorID.ToString(), TimeSetID.ToString());
               
                return sqlDatabaseProvider.ExecuteSql(strSql) > 0 ? true : false;
            }
        }
        public bool UPDATE_DS_BF_TimeZone_SlaveSID(int SlaveSID, int DoorID, int TimeZoneID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("update [DS_BF_TimeZone_SlaveSID] set [IsReplicated]=1 where [SlaveSID]={0} AND [DoorID]={1} AND [TimeZoneID]={2}", SlaveSID.ToString(), DoorID.ToString(), TimeZoneID.ToString());
                
                return sqlDatabaseProvider.ExecuteSql(strSql) > 0 ? true : false;
            }
        }
        public bool UPDATE_DS_BF_UserGroup_SlaveSID(int SlaveSID, int DoorID, int GroupID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("update [DS_BF_UserGroup_SlaveSID] set [IsReplicated]=1 where [SlaveSID]={0} AND [DoorID]={1} AND [GroupID]={2}", SlaveSID.ToString(), DoorID.ToString(), GroupID.ToString());
                
                return sqlDatabaseProvider.ExecuteSql(strSql) > 0 ? true : false;
            }
        }
        public bool UPDATE_DS_BF_Holiday_SlaveSID(int SlaveSID, int DoorID, int DoorHoliID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("update [DS_BF_Holiday_SlaveSID] set [IsReplicated]=1 where [SlaveSID]={0} AND [DoorID]={1} AND [DoorHoliID]={2}", SlaveSID.ToString(), DoorID.ToString(), DoorHoliID.ToString());
               
                return sqlDatabaseProvider.ExecuteSql(strSql) > 0 ? true : false;
            }
        }
        public bool UPDATE_BFX_UserSlaveAllowTime(int SlaveSID, string CardID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format("update [BFX_UserSlaveAllowTime] set [IsReplicated]=1 where [SlaveSID]={0} AND [CardID]='{1}'", SlaveSID.ToString(), CardID.PadLeft(10, '0'));
                
                return sqlDatabaseProvider.ExecuteSql(strSql) > 0 ? true : false;
            }
        }
        public bool UPDATE_DS_BF_User_Add_CardId_Int(UInt32 CardId, int SlaveSID)
        {
            lock (sqlServerLocker)
            {
                SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

                int rowsAffect = 0;
                SqlParameter[] sqlPara = new SqlParameter[3];
                //CardId
                sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
                string strCardId = CardId.ToString();
                sqlPara[0].Value = strCardId;
                //@SlaveSID
                sqlPara[1] = new SqlParameter("@SlaveSID", SqlDbType.Int);
                sqlPara[1].Value = SlaveSID;
                //@ReplicateReturnID
                sqlPara[2] = new SqlParameter("@ReplicateReturnID", SqlDbType.Int);
                sqlPara[2].Value = 0;


                return DataBase.RunProcedure(cn, "SP_DS_UPDATE_DS_BF_User_Add", sqlPara, out rowsAffect) > 0 ? true : false;
            }
        }
          public bool UPDATE_DS_BF_User_Add(UInt32 CardId, int SlaveSID)
        {
            lock (sqlServerLocker)
            {
                SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

                int rowsAffect = 0;
                SqlParameter[] sqlPara = new SqlParameter[3];
                //CardId
                sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
                string strCardId = CardId.ToString().PadLeft(10, '0');
                sqlPara[0].Value = strCardId;
                //@SlaveSID
                sqlPara[1] = new SqlParameter("@SlaveSID", SqlDbType.Int);
                sqlPara[1].Value = SlaveSID;
                //@ReplicateReturnID
                sqlPara[2] = new SqlParameter("@ReplicateReturnID", SqlDbType.Int);
                sqlPara[2].Value = 0;
            

            return DataBase.RunProcedure(cn, "SP_DS_UPDATE_DS_BF_User_Add", sqlPara, out rowsAffect) > 0 ? true : false;
            }
        }

        public bool UPDATE_DS_BF_User_Delete(UInt32 CardId, int SlaveSID)
        {
            lock (sqlServerLocker)
            {
                SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

                int rowsAffect = 0;
                SqlParameter[] sqlPara = new SqlParameter[3];
                //CardId
                sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
                string strCardId = CardId.ToString().PadLeft(10, '0');
                sqlPara[0].Value = strCardId;
                //@SlaveSID
                sqlPara[1] = new SqlParameter("@SlaveSID", SqlDbType.Int);
                sqlPara[1].Value = SlaveSID;
                //@ReplicateReturnID
                sqlPara[2] = new SqlParameter("@ReplicateReturnID", SqlDbType.Int);
                sqlPara[2].Value = 0;
            

            return DataBase.RunProcedure(cn, "SP_DS_UPDATE_DS_BF_User_Del", sqlPara, out rowsAffect) > 0 ? true : false;
            }
        }
        public bool UPDATE_DS_BF_FP_Add(UInt32 CardId, int FingerNo,int SlaveSID)
        {
            lock (sqlServerLocker)
            {
                string strSql = string.Format(@"UPDATE [DS_BF_FP_Add] 
 SET IsReplicated = 1
  , TimeReplicated = CURRENT_TIMESTAMP 
  , ReplicateReturnID = 0
 FROM [DS_BF_FP_Add] AS FA 
 WHERE FA.CardID = '{0}' AND FA.SlaveSID = {1} and FA.[FPNo] ={2}", CardId.ToString().PadLeft(10, '0'), SlaveSID.ToString(), FingerNo.ToString());

                return sqlDatabaseProvider.ExecuteSql(strSql) > 0 ? true : false;
            //    SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            //    int rowsAffect = 0;
            //    SqlParameter[] sqlPara = new SqlParameter[3];
            //    //CardId
            //    sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
            //    string strCardId = CardId.ToString().PadLeft(10, '0');
            //    sqlPara[0].Value = strCardId;
            //    //@SlaveSID
            //    sqlPara[1] = new SqlParameter("@SlaveSID", SqlDbType.Int);
            //    sqlPara[1].Value = SlaveSID;
            //    //@ReplicateReturnID
            //    sqlPara[2] = new SqlParameter("@ReplicateReturnID", SqlDbType.Int);
            //    sqlPara[2].Value = 0;

            //    return DataBase.RunProcedure(cn, "SP_DS_UPDATE_DS_BF_FP_Add", sqlPara, out rowsAffect) > 0 ? true : false;
            }
        }
        public bool UPDATE_DS_BF_FP_Delete(UInt32 CardId, int fpno,int SlaveSID)
        {
            lock (sqlServerLocker)
            {
               

                string SqlCommand = string.Format("UPDATE [DS_BF_FP_Del] "+
    "SET IsReplicated = 1"+
        ", TimeReplicated = CURRENT_TIMESTAMP " +
        ", ReplicateReturnID =1 " +
    "FROM [DS_BF_FP_Del]  "+
    "WHERE CardID = '{0}' AND SlaveSID = {1} AND FPNo={2}", CardId.ToString().PadLeft(10, '0'), SlaveSID.ToString(), fpno.ToString());
                return sqlDatabaseProvider.ExecuteSql(SqlCommand) > 0 ? true : false;

                //SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

                //int rowsAffect = 0;
                //SqlParameter[] sqlPara = new SqlParameter[3];
                ////CardId
                //sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
                //string strCardId = CardId.ToString().PadLeft(10, '0');
                //sqlPara[0].Value = strCardId;
                ////@SlaveSID
                //sqlPara[1] = new SqlParameter("@SlaveSID", SqlDbType.Int);
                //sqlPara[1].Value = SlaveSID;
                ////@ReplicateReturnID
                //sqlPara[2] = new SqlParameter("@ReplicateReturnID", SqlDbType.Int);
                //sqlPara[2].Value = 0;

                //return DataBase.RunProcedure(cn, "SP_DS_UPDATE_DS_BF_FP_Del", sqlPara, out rowsAffect) > 0 ? true : false;
            }
        }
        public bool InsertUserRecordPhoto(int SlaveSID, string CardId, string dateTime, byte[] PhotoData)
        {
            lock (sqlServerLocker)
            {
                SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

                int rowsAffect = 0;
                SqlParameter[] sqlPara = new SqlParameter[4];

                 sqlPara[0]  = new SqlParameter
                            ("@slaveId", SqlDbType.Int);

                 sqlPara[0].Value = SlaveSID;


                 sqlPara[1] = new SqlParameter("@cardId", SqlDbType.NVarChar, 14);
                 sqlPara[1].Value = CardId;


                 sqlPara[2] = new SqlParameter("@transTime", SqlDbType.DateTime);
                 sqlPara[2].Value = dateTime;




                 sqlPara[3] = new SqlParameter("@photos", SqlDbType.Image);
                 sqlPara[3].Value = PhotoData;



                 return DataBase.RunProcedure(cn, "SP_store_TRANS_PHOTO", sqlPara, out rowsAffect) > 0 ? true : false;
          
            }
        }
        public bool InsertUserFingerData( int SlaveSID,string CardId,int FingerNo,byte[] FingerData)
        {
            lock (sqlServerLocker)
            {
                SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

                int rowsAffect = 0;
                SqlParameter[] sqlPara = new SqlParameter[4];
                //CardId
                sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
                string strCardId = CardId.ToString().PadLeft(10, '0');
                sqlPara[0].Value = strCardId;
                //@Finger NO
                sqlPara[1] = new SqlParameter("@FingerNo", SqlDbType.Int);
                sqlPara[1].Value = FingerNo;
                //@Finger Data
                sqlPara[2] = new SqlParameter("@FingerData", SqlDbType.Image);
                sqlPara[2].Value = FingerData;
                //@SlaveSID
                sqlPara[3] = new SqlParameter("@SlaveSID", SqlDbType.Int);
                sqlPara[3].Value = SlaveSID;


                return DataBase.RunProcedure(cn, "SP_DS_Replace_FingerData", sqlPara, out rowsAffect) > 0 ? true : false;
            }
        }
        public bool GetDeviceReplicatedDetials(int SlaveSID, ref int UserCount, ref int UserReplicatedCount, ref int UserFingerCount, ref int UserFingerReplicatedCount)
        {
            

            lock (sqlServerLocker)
            {
                SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

                SqlParameter[] sqlParaIn = new SqlParameter[1];
                sqlParaIn[0] = new SqlParameter("@SlaveSID", SqlDbType.Int);
                sqlParaIn[0].Value = SlaveSID;

                SqlParameter[] sqlParaOut = new SqlParameter[4];
                sqlParaOut[0] = new SqlParameter("@WaitForReplicationUserCount", SqlDbType.Int);
                sqlParaOut[0].Direction = ParameterDirection.Output;

                sqlParaOut[1] = new SqlParameter("@ReplicatedUserCount", SqlDbType.Int);
                sqlParaOut[1].Direction = ParameterDirection.Output;

                sqlParaOut[2] = new SqlParameter("@WaitForReplicationFpCount", SqlDbType.Int);
                sqlParaOut[2].Direction = ParameterDirection.Output;

                sqlParaOut[3] = new SqlParameter("@ReplicatedFpCount", SqlDbType.Int);
                sqlParaOut[3].Direction = ParameterDirection.Output;


                int iRet = DataBase.RunProcedure(cn, "SP_DS_GET_ReplicateCountForUserAndFP_BySlaveSID", sqlParaIn, sqlParaOut);
                UserCount = Convert.ToInt32(sqlParaOut[0].Value) + Convert.ToInt32(sqlParaOut[1].Value);
                UserReplicatedCount = Convert.ToInt32(sqlParaOut[1].Value);
                UserFingerCount = Convert.ToInt32(sqlParaOut[2].Value) + Convert.ToInt32(sqlParaOut[3].Value);
                UserFingerReplicatedCount = Convert.ToInt32(sqlParaOut[3].Value);
                
                return iRet > 0 ? true : false;
            }
        }
        #endregion
        #region Transactions
        public int InsertToOR_TransactionsWithTransId(ITransactions transData,int TranSID)
        {
            lock (sqlServerLocker)
            {
                SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

                int rowsAffect = 0;
                SqlParameter[] sqlPara = new SqlParameter[10];
                //CardId
                sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
                sqlPara[0].Value = transData.TransactionCardId;
                //@TranDateTime
                sqlPara[1] = new SqlParameter("@TranDateTime", SqlDbType.DateTime);
                sqlPara[1].Value = transData.TransactionDateTime;
                //@TranType
                sqlPara[2] = new SqlParameter("@TranType", SqlDbType.TinyInt);
                sqlPara[2].Value = transData.TransactionType;
                //@SlaveIP
                sqlPara[3] = new SqlParameter("@SlaveIP", SqlDbType.NVarChar, 18);
                sqlPara[3].Value = transData.DeviceIP;
                //@DataType
                sqlPara[4] = new SqlParameter("@DataType", SqlDbType.TinyInt);
                sqlPara[4].Value = transData.DataType;
                //@SlaveIP_Public
                sqlPara[5] = new SqlParameter("@SlaveIP_Public", SqlDbType.NVarChar, 18);
                sqlPara[5].Value = transData.DevicePublicIP;
                //@IsByTranType
                sqlPara[6] = new SqlParameter("@IsByTranType", SqlDbType.Bit);
                sqlPara[6].Value = transData.IsByTranType ? 1 : 0;
                //@SlaveID
                sqlPara[7] = new SqlParameter("@SlaveSID", SqlDbType.SmallInt);
                sqlPara[7].Value = transData.SlaveId;
                //@Transaction ID
                sqlPara[8] = new SqlParameter("@ClientTranSID", SqlDbType.Int);
                sqlPara[8].Value = TranSID;

                /* Mofieid: 2024/04/04
                 * Exception  : Error - ReadSalveOk將資料類型從 numeric 轉換到 decimal 時發生錯誤。
                KCS 嘗試在DB建立一筆OR_Transaction卡號：!SOFTOPEN!
                TranType: 144
                體溫：38174.8就是這個體溫超出原本的設計
                */
                // Add:     2022/05/11 
                // By:      Eric
                // Subject: 體溫                
                //sqlPara[9] = new SqlParameter("@DegreeCelsius", SqlDbType.Decimal);
                //sqlPara[9].Value = transData.BodyTemp;
                decimal degreeCelsius = Convert.ToDecimal(transData.BodyTemp);
                if (degreeCelsius > 99) degreeCelsius = (decimal)99.9;
                degreeCelsius = Math.Round(degreeCelsius, 1);

                sqlPara[9] = new SqlParameter("@DegreeCelsius", SqlDbType.Decimal);
                sqlPara[9].Value = degreeCelsius;
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                return DataBase.RunProcedure(cn, "SP_DS_DataSync_INSERT_OR_Transactions", sqlPara, out rowsAffect);
            }
        }
        public bool InsertToOR_Transactions(ITransactions transData)
        {
            lock (sqlServerLocker)
            {
            SqlConnection cn = sqlDatabaseProvider.GetDatabaseConnection() as SqlConnection;

            int rowsAffect = 0;
            SqlParameter[] sqlPara = new SqlParameter[8];
            //CardId
            sqlPara[0] = new SqlParameter("@CardID", SqlDbType.NVarChar, 14);
            sqlPara[0].Value = transData.TransactionCardId;
            //@TranDateTime
            sqlPara[1] = new SqlParameter("@TranDateTime", SqlDbType.DateTime);
            sqlPara[1].Value = transData.TransactionDateTime;
            //@TranType
            sqlPara[2] = new SqlParameter("@TranType", SqlDbType.TinyInt);
            sqlPara[2].Value = transData.TransactionType;
            //@SlaveIP
            sqlPara[3] = new SqlParameter("@SlaveIP", SqlDbType.NVarChar, 18);
            sqlPara[3].Value = transData.DeviceIP;
            //@DataType
            sqlPara[4] = new SqlParameter("@DataType", SqlDbType.TinyInt);
            sqlPara[4].Value = transData.DataType;
            //@SlaveIP_Public
            sqlPara[5] = new SqlParameter("@SlaveIP_Public", SqlDbType.NVarChar, 18);
            sqlPara[5].Value = transData.DevicePublicIP;
            //@IsByTranType
            sqlPara[6] = new SqlParameter("@IsByTranType", SqlDbType.Bit);
            sqlPara[6].Value = transData.IsByTranType ? 1 : 0;
            //@SlaveID
            sqlPara[7] = new SqlParameter("@SlaveID", SqlDbType.SmallInt);
            sqlPara[7].Value = transData.SlaveId;


            return DataBase.RunProcedure(cn, "SP_DataSync_INSERT_OR_Transactions", sqlPara, out rowsAffect)>0?true:false;
                }
        }
        #endregion
    }
}
