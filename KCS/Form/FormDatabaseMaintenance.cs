using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.Common.Utils;
using System.Data.SqlClient;
using KCS.Common.DAL;
using System.Collections;

namespace KCS.Form
{
    public partial class FormDatabaseMaintenance : DevExpress.XtraEditors.XtraForm
    {
        public FormDatabaseMaintenance()
        {
            InitializeComponent();
            this.Text = LanguageResource.GetDisplayString("ToolBarDatabaseMaintenance");
            tabNavigationPage1.Caption = LanguageResource.GetDisplayString("DatabaseBackup");
            tabNavigationPage2.Caption = LanguageResource.GetDisplayString("DatabaseRestore");
            tabNavigationPage3.Caption = LanguageResource.GetDisplayString("DatabaseDelRecords");

            sBBackUp.Text = LanguageResource.GetDisplayString("DBMBackup");
            sbRestore.Text = LanguageResource.GetDisplayString("DBMRestore");
            sbDeleteRecords.Text = LanguageResource.GetDisplayString("DBMDelRecords");
            lblCtlFrom.Text = LanguageResource.GetDisplayString("FromText");
            lblCtlTo.Text = LanguageResource.GetDisplayString("ToText");
        }

        private void sbBackUpPath_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf =  new SaveFileDialog();
            sf.Filter = "Backup file(*.bak)|*.bak";
            sf.ShowDialog();
            textEditBackUpPath.Text = sf.FileName;
            
            
        }

        private void sBBackUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditBackUpPath.Text))
                return;
            SqlConnection conn = new SqlConnection(SystemConfigure.KatesConnectionString);
            string sql = "BACKUP DATABASE " + SystemConfigure.DataBaseName + " TO DISK = '" + textEditBackUpPath.Text + "' ";
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                
                conn.Close();
                PopHintDialog.ShowMessage(LanguageResource.GetDisplayString("DBMBackupFailed") + " " + err.Message);
                return ;
            }

            conn.Close();//关闭数据库连接
            PopHintDialog.ShowMessage(LanguageResource.GetDisplayString("DBMBackupSucceeds"));
            return ;


        }

        private void sbRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditRestorePath.Text))
                return;
            SqlConnection conn = new SqlConnection(SystemConfigure.DBConnectionString);
            conn.Open();

            //KILLDataBaseProcess
            string szSqlScript = string.Format("SELECT spid FROM sysprocesses,sysdatabases WHERE sysprocesses.dbid=sysdatabases.dbid AND sysdatabases.Name='{0}'", SystemConfigure.DataBaseName);
            SqlCommand cmd = new SqlCommand(szSqlScript, conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            ArrayList list = new ArrayList();
            while (dr.Read())
            {
                list.Add(dr.GetInt16(0));
            }
            dr.Close();
            for (int i = 0; i < list.Count; i++)
            {
                cmd = new SqlCommand(string.Format("KILL {0}", list[i]), conn);
                cmd.ExecuteNonQuery();
            }

            SqlCommand cmdGetPath = new SqlCommand("select filename from master..sysfiles", conn);
            SqlDataReader drPath;
            string sqlRestorePath = "";
            string strDbFilePath = "";
            string strDbLogFilePath = "";
            drPath = cmdGetPath.ExecuteReader();
            if (drPath.Read())
            {
                sqlRestorePath = drPath["filename"].ToString();
            }
            drPath.Close();
            if (!string.IsNullOrEmpty(sqlRestorePath))
            {
                int pos = sqlRestorePath.IndexOf("master.");
                sqlRestorePath = sqlRestorePath.Substring(0, pos);
                strDbFilePath = string.Format("with move 'KATES_DATA' to '{0}'", sqlRestorePath + SystemConfigure.DataBaseName + ".mdf");
                strDbLogFilePath = string.Format(",move 'KATES_Log' to '{0}'", sqlRestorePath + SystemConfigure.DataBaseName + ".ldf");
            }

            szSqlScript = string.Format("restore database {0} from disk='{1}' {2}{3} ", SystemConfigure.DataBaseName, textEditRestorePath.Text, strDbFilePath, strDbLogFilePath);

            SqlCommand cmdRT = new SqlCommand();
            cmdRT.CommandType = CommandType.Text;
            cmdRT.Connection = conn;
            cmdRT.CommandText = szSqlScript;

            try
            {
                cmdRT.ExecuteNonQuery();
                
                XtraMessageBox.Show(LanguageResource.GetDisplayString("DBMRestoreSucceeds"), "KCS");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KCS");
            }
            finally
            {
                conn.Close();
            }
        }

        private void sbRestorePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Backup file(*.bak)|*.bak";
            of.ShowDialog();
            textEditRestorePath.Text = of.FileName;
        }

        private void sbDeleteRecords_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(SystemConfigure.KatesConnectionString);
            DateTime startDate = (DateTime)dateEditStart.EditValue;
            DateTime endDate = (DateTime)dateEditEnd.EditValue;
            string sql = string.Format("delete from [OR_Transactions] where [TranDateTime]>='{0}' AND [TranDateTime]<'{1}'", startDate.ToShortDateString(), endDate.ToShortDateString());
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            comm.CommandType = CommandType.Text;
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception err)
            {

                conn.Close();
                PopHintDialog.ShowMessage(LanguageResource.GetDisplayString("DBMDleRecordsFailed") + " " + err.Message);
                return;
            }

            conn.Close();//关闭数据库连接
            PopHintDialog.ShowMessage(LanguageResource.GetDisplayString("DBMDleRecordsSucceeds"));
            return;
        }
    }
}