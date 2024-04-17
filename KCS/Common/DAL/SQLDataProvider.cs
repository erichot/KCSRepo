using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;

namespace KCS.Common.DAL
{
    class SQLDataProvider : IDisposable
    {
        private DataBase Database { get; set; }
        private SqlConnection m_connection = null;
        private static SQLDataProvider _Instance = null;
        
        #region Constructor(s)

        public SQLDataProvider()
        {
            Database = new DataBase(SystemConfigure.KatesConnectionString);

        }
        public static SQLDataProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SQLDataProvider();
                }
                return _Instance;
            }
        }
        public static bool CheckDatabaseIsValidOrNot()
        {
            SqlConnection SqlConn = new SqlConnection();
            SqlConn.ConnectionString = SystemConfigure.KatesConnectionString;
            try
            {
                SqlConn.Open();
                DataSet dataSet = new DataSet();
                string strSqlCheckDb;
                strSqlCheckDb = string.Format("use master;select * from sysdatabases where name = '{0}'", SystemConfigure.DataBaseName);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(strSqlCheckDb, SqlConn);
                sqlDataAdapter.Fill(dataSet, "Dat");
                if (dataSet.Tables[0].Rows.Count < 1)
                {
                    return false;
                }


                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }
            }

        }
        public void Dispose()
        {
            if (m_connection != null)
            {
                m_connection.Dispose();
                m_connection = null;
            }
        }

        #endregion

        #region Public Instance Method(s)
        public IDbConnection GetDatabaseConnection(bool createNew)
        {
            if (!createNew) return GetDatabaseConnection();

            return Database.CreateConnection();
        }

        public IDbConnection GetDatabaseConnection()
        {
            if (m_connection == null)
            {
                m_connection = Database.CreateConnection();
               
            }
            if (m_connection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    m_connection.Open();
                }
                catch (ObjectDisposedException)
                {
                    m_connection = Database.CreateConnection();
                }
            }
            return m_connection;
        }
        #endregion
        #region Query data
        public DataTable ExcuteTable(string strQuery)
        {
            SqlConnection cn = GetDatabaseConnection() as SqlConnection;

            DataSet ds = DataBase.Query(cn, strQuery);

            return ds.Tables[0];
        }
        public DataSet ExcuteDataSet(string strQuery)
        {
            SqlConnection cn = GetDatabaseConnection() as SqlConnection;

            DataSet ds = DataBase.Query(cn, strQuery);

            return ds;
        }
        public int ExecuteSql(string strCommand)
        {
            SqlConnection cn = GetDatabaseConnection() as SqlConnection;

            return DataBase.ExecuteSql(cn, strCommand);


        }
        public void ExecuteSqlTran(ArrayList SQLStringList)
        {
            SqlConnection cn = GetDatabaseConnection() as SqlConnection;

            DataBase.ExecuteSqlTran(cn, SQLStringList);


        }
        public object ExecuteSqlWitResult(string strCommand)
        {
            SqlConnection cn = GetDatabaseConnection() as SqlConnection;
            return DataBase.GetSingle(cn, strCommand);
            
            //return obj;


        }




        #endregion













        /* Add: 2023/01/25
         * By:  Eric
         * Ver: 1.1.5.7
         */
        public SqlDataReader GetSqlDataReader(string _selectStatment)
        {
            SqlConnection cn = GetDatabaseConnection() as SqlConnection;
            SqlCommand cmd = new SqlCommand(_selectStatment, cn);
            return cmd.ExecuteReader();
        }









        #region "SP"
   

        /* Add: 2023/01/25
         * By:  Eric
         * Ver: 1.1.5.7
         */
        public DataTable SP_GetAttendanceReport_FlexShift(DateTime _workingTime_Start, DateTime _workingTime_End, IEnumerable<int> _userSIDEnumer)
        {
            var result = new DataTable();
            SqlConnection cn = GetDatabaseConnection() as SqlConnection;
            SqlCommand cmd = new SqlCommand("dbo.SP_GetAttendanceReport_FlexShift", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter spmWorkingTime_Start = cmd.Parameters.Add("@WorkingTime_Start", SqlDbType.DateTime);
            spmWorkingTime_Start.Value = _workingTime_Start;

            SqlParameter spmWorkingTime_End = cmd.Parameters.Add("@WorkingTime_End", SqlDbType.DateTime);
            spmWorkingTime_End.Value = _workingTime_End;

            var userSIDArrayString = string.Join(",", _userSIDEnumer);
            SqlParameter spmUserSIDArrayString = cmd.Parameters.Add("@UserSIDArrayString", SqlDbType.VarChar,1000);
            spmUserSIDArrayString.Value = userSIDArrayString;

            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                result.Load(dr);
                dr.Close();
            }
            catch (Exception ex)
            {

            }

            
            return result;
        }







        /* Add: 2023/01/25
         * By:  Eric
         * Ver: 1.1.5.7
         */
        public int SP_Update_Transactions_WorkShiftNo(int _tranSID, int _workShiftNo)
        {
            var result = default(int);

            SqlConnection cn = GetDatabaseConnection() as SqlConnection;
            SqlCommand cmd = new SqlCommand("dbo.SP_Update_Transactions_WorkShiftNo", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter spmTranSID = cmd.Parameters.Add("@TranSID", SqlDbType.Int);
            spmTranSID.Value = _tranSID;

            SqlParameter spmWorkShiftNo = cmd.Parameters.Add("@WorkShiftNo", SqlDbType.Int);
            spmWorkShiftNo.Value = _workShiftNo;

            try
            {
                result =  cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = -1;
            }

            return result;
        }

        #endregion



    }
}
