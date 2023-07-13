using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Collections;
using KCS.Common.DAL.Constants;
using KCS.Common.DAL;
using System.IO;
using System.Xml;
using System.Data.Sql;
using System.Runtime.Remoting.Messaging;
using DevExpress.Utils;
using System.Threading;
using Microsoft.Win32;
using KCS.Controls;
using System.Text.RegularExpressions;
using KCS.Common.Utils;

namespace KCS
{
    public partial class FormDbServerSet : DevExpress.XtraEditors.XtraForm
    {
        private static string SQL_SCRIPT_FILE = "Kates_script.sql";
        private static int FormLoadFinish = 0;
        public delegate List<string> GetLocalSqlServerHandler();
        SqlConnection SqlConn = new SqlConnection();
        WaitDialogForm sdf = new WaitDialogForm("Sql Server", "Finding......");
        SynchronizationContext syncContext;
        IAsyncResult ar;
        public FormDbServerSet()
        {
            FormLoadFinish = 0;
            InitializeComponent();
            sdf.Hide();
            this.Text = LanguageResource.GetDisplayString("SystemSetting");
            labelControl1.Text = LanguageResource.GetDisplayString("ServerName");
            groupBoxLoginMethod.Text = LanguageResource.GetDisplayString("LoginMode");
            radioButtonWindowsAuth.Text = LanguageResource.GetDisplayString("WindowsAuthentication");
            radioButtonSqlAuth.Text = LanguageResource.GetDisplayString("SqlAuthentication");
            labelControl2.Text = LanguageResource.GetDisplayString("UserName");
            labelControl3.Text = LanguageResource.GetDisplayString("Password");
            radioButtonExistDb.Text = LanguageResource.GetDisplayString("UsingExistingDatabase");
            radioButtonNewDb.Text = LanguageResource.GetDisplayString("NewDatabase");
            radioRestoreDB.Text = LanguageResource.GetDisplayString("RestoreDatabase");
            labelControl5.Text = LanguageResource.GetDisplayString("DataBase");
            labelControl6.Text = LanguageResource.GetDisplayString("DefaultLanguage");
            buttonTest.Text = LanguageResource.GetDisplayString("Test");
            buttonRestore.Text = LanguageResource.GetDisplayString("Restore");
            buttonNew.Text = LanguageResource.GetDisplayString("ToolBarNew");
            buttonSave.Text = buttonSaveLang.Text = LanguageResource.GetDisplayString("ToolBarSave");
            checkEditDisableSync.Text = LanguageResource.GetDisplayString("DisableSync");

            
            checkEditDisableSync.Checked  = SystemConfigure.IsDisSyncDataOrNot > 0? true:false;
           
            this.DialogResult = DialogResult.Cancel; 
        }

        private void radioButtonWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxUserData.Enabled = false;
        }

        private void radioButtonSqlAuth_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxUserData.Enabled = true;

        }
        private void ShowSqlInstanceName(object  ServerList)
        {
            var serverList = ServerList as List<string>;
            sdf.Hide();
            if (serverList != null)
            {
                foreach (string servername in serverList)
                    comboBoxEditServerName.Properties.Items.Add(servername);
                comboBoxEditServerName.SelectedIndex = 0;
            }
        }
        private  void OnGetComplete(IAsyncResult asyncResult)
        {
            try
            {
                AsyncResult result = (AsyncResult)asyncResult;
                GetLocalSqlServerHandler del = (GetLocalSqlServerHandler)result.AsyncDelegate;

                List<string> ServerList = del.EndInvoke(asyncResult);
                syncContext.Post(new SendOrPostCallback(ShowSqlInstanceName), ServerList);
            }
            catch { }
            

            
        }
        private void FormDbServerSet_Load(object sender, EventArgs e)
        {
            sdf.Show();
             syncContext = SynchronizationContext.Current;
            GetLocalSqlServerHandler handler = new GetLocalSqlServerHandler(GetSqlServerNames);
            AsyncCallback callBack = new AsyncCallback(OnGetComplete);

            ar = handler.BeginInvoke(callBack, null);    
          // GetSqlServerNames();
            try
            {
                ReadSupportLanguage();
            }
            catch (Exception ex)
            {
                comboBoxEditLang.Properties.Items.Add(new ComboxLang("English", "EN"));
                comboBoxEditLang.SelectedIndex = 0;
            }
            textEditNewDb.Text = "KATES";

            progressBarNew.Visible = false;
            buttonSave.Enabled = false;
            buttonNew.Visible = false;
            buttonRestore.Visible = false;
            FormLoadFinish = 1;
        }
        
        private string GetLanguageValue(string lang)
        {
            try
            {
                string pattern = @"\[.*?\]";//匹配模式
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(lang);
                StringBuilder sb = new StringBuilder();//存放匹配结果
                foreach (Match match in matches)
                {
                    string value = match.Value;
                    return value;
                }

                return "";
            }
            catch
            {
                return "";
            }
           
        }
        private void ReadSupportLanguage()
        {
            string szPath = string.Format("{0}\\Resources\\AppLangConfig.xml", XmlHelper.GetWorkDirectory());
            XmlReader reader = new XmlTextReader(szPath);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            XmlNode root = doc.DocumentElement;
            XmlNodeList nodelist = root.SelectNodes("Area[Language='" + SystemConfigure.LanguageSelect + "']/List/Item");
            int index = 0,indexCount = 0;
            foreach (XmlNode node in nodelist)
            {
                string langnode = node.InnerText;
                langnode = langnode.TrimEnd('\r').TrimEnd('\n');
                
                string strValue = GetLanguageValue(langnode);
                string strText = langnode.Substring(0,langnode.IndexOf(strValue));
                if (!string.IsNullOrEmpty(strValue))
                {
                    
                    comboBoxEditLang.Properties.Items.Add(new ComboxLang(strText, strValue.Trim('[', ']')));
                    if (strValue.Trim('[', ']') == SystemConfigure.LanguageSelect)
                        index = indexCount;
                    indexCount++;
                }
            }
            reader.Close();
            comboBoxEditLang.SelectedIndex = index;
        }
        private void radioButtonExistDb_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxExistDB.Visible = true;
            groupBoxNewDB.Visible = false;

            buttonSave.Visible = true;
            buttonSave.Enabled = true;
            buttonNew.Visible = false;
            buttonRestore.Visible = false;
            progressBarNew.Visible = false;
        }

        private void radioButtonNewDb_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxExistDB.Visible = false;
            groupBoxNewDB.Visible = true;

            buttonNew.Visible = true;
            buttonNew.Enabled = true;
            buttonSave.Visible = false;
            buttonRestore.Visible = false;
            progressBarNew.Visible = false;
        }
        private void radioRestoreDB_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxExistDB.Visible = false;
            groupBoxNewDB.Visible = true;

            buttonNew.Visible = false;
            buttonSave.Visible = false;
            buttonRestore.Visible = true;
            progressBarNew.Visible = false;
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBoxEditServerName.Text))
            {
                XtraMessageBox.Show("Please enter server name first!", "KCS");
                return;
            }

            string SQLLinkStr = "Data Source=" + comboBoxEditServerName.Text.Trim();
            SqlConn.Close();
            if (radioButtonWindowsAuth.Checked)
            {//window 验证
                SQLLinkStr = SQLLinkStr + ";Initial Catalog=master;Integrated Security=SSPI;";
            }
            else
            {
                SQLLinkStr = SQLLinkStr + ";Initial Catalog=master;User Id=" + textEditUserName.Text.Trim() + ";Password=" + textEditUserPwd.Text.Trim() + ";";
            }
            SqlConn.ConnectionString = SQLLinkStr;
            try
            {
                SqlConn.Open();
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select name from   sysdatabases where name not in('master','tempdb','model','msdb','pubs','northwind')", SqlConn);
                sqlDataAdapter.Fill(dataSet, "Dat");
                comboBoxDataBase.Items.Clear();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    comboBoxDataBase.Items.Add(dataSet.Tables[0].Rows[i][0].ToString());
                }
                groupBoxDBData.Enabled = true;
                UpdateDataBaseSet();
                XtraMessageBox.Show("Test OK!", "KCS");
            }
            catch (Exception ex)
            {
                groupBoxDBData.Enabled = false;
                XtraMessageBox.Show(ex.Message, "KCS Error");
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open)
                {
                    SqlConn.Close();
                }
            }
        }


        private void buttonNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditNewDb.Text))
            {

                XtraMessageBox.Show("Please enter DataBase name first!", "KCS");
                return;

            }
            string szSqlScript = string.Format("{0}\\{1}", XmlHelper.GetWorkDirectory(), SQL_SCRIPT_FILE);
            FileStream fs = new FileStream(szSqlScript, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string strAll = sr.ReadToEnd().ToString();
            string[] AllStep = strAll.Split('\n');
            sr.Close();
            fs.Close();
            progressBarNew.Visible = true;
            progressBarNew.Maximum = AllStep.GetLength(0) + 40;
            progressBarNew.Value = 0;

            string StrSql;
            string errorReturn = "";
            string dbName = textEditNewDb.Text.Trim();
            try
            {
                StrSql = "CREATE DATABASE [" + dbName + "] ";
                ExcCmdSQLStr(StrSql, ref errorReturn);
                if (string.IsNullOrEmpty(errorReturn))
                {
                    StrSql = "";
                    string SQLLinkStr = "Data Source=" + comboBoxEditServerName.Text.Trim();
                    SqlConn.Close();
                    if (radioButtonWindowsAuth.Checked)
                    {//window 验证
                        SQLLinkStr = SQLLinkStr + ";Initial Catalog=master;Integrated Security=SSPI;";
                    }
                    else
                    {
                        SQLLinkStr = SQLLinkStr + ";Initial Catalog=master;User Id=" + textEditUserName.Text.Trim() + ";Password=" + textEditUserPwd.Text.Trim() + ";";
                    }
                    SqlConn.ConnectionString = SQLLinkStr;
                    for (int i = 0; i < AllStep.GetLength(0); i++)
                    {
                        string strReadCommand = AllStep[i].Trim('\r');
                        strReadCommand = strReadCommand.ToUpper();
                        progressBarNew.PerformStep();
                        if (strReadCommand.Equals("GO"))
                        {
                            errorReturn = "";
                            ExcCmdSQLStr(StrSql, ref errorReturn);
                            if (!string.IsNullOrEmpty(errorReturn))
                            {
                                XtraMessageBox.Show(errorReturn, "KCS Error");
                                break;
                            }
                            StrSql = "";
                        }
                        else
                        {
                            StrSql += " ";
                            StrSql += strReadCommand;
                        }

                    }

                }
                else
                {
                    XtraMessageBox.Show(errorReturn, "KCS Error");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "KCS Error");
            }


        }        

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEditNewDb.Text))
            {

                XtraMessageBox.Show("Please enter DataBase name first!", "KCS");
                return;

            }
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.AutoUpgradeEnabled = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.ReadOnlyChecked = false;
            openFileDialog.Multiselect = false;
            openFileDialog.FileName = "";

            openFileDialog.Filter = "All files|*.*";
            openFileDialog.Title = "Browse";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strDbFileName = openFileDialog.FileName;
                //SplashScreenManager.ShowForm( typeof(KCS.Forms.wfMain));

                RestoreDataBase(strDbFileName, textEditNewDb.Text.Trim());
                //Thread.Sleep(10000);

            }
        }
        #region "调用函数"

        private void UpdateDataBaseSet()
        {
            if (radioButtonExistDb.Checked)
            {
                groupBoxExistDB.Visible = true;
                groupBoxNewDB.Visible = false;

                buttonSave.Visible = true;
                buttonSave.Enabled = true;
                buttonNew.Visible = false;
                buttonRestore.Visible = false;
                progressBarNew.Visible = false;
            }
            else if (radioButtonNewDb.Checked)
            {
                groupBoxExistDB.Visible = false;
                groupBoxNewDB.Visible = true;

                buttonNew.Visible = true;
                buttonNew.Enabled = true;
                buttonSave.Visible = false;
                buttonRestore.Visible = false;
                progressBarNew.Visible = false;
            }
            else
            {
                groupBoxExistDB.Visible = false;
                groupBoxNewDB.Visible = true;

                buttonNew.Visible = false;
                buttonSave.Visible = false;
                buttonRestore.Visible = true;
                progressBarNew.Visible = false;
            }
        }
        private void SaveDataBasePara()
        {
            DataBaseAuthMode authMode = DataBaseAuthMode.Unknown;
            string strDataBaseName = "";
            if (radioButtonExistDb.Checked)
            {
                strDataBaseName = comboBoxDataBase.Text;
            }
            else
            {
                strDataBaseName = textEditNewDb.Text;
            }
            if (radioButtonWindowsAuth.Checked)
            {//window 验证
                authMode = DataBaseAuthMode.WindowsAuth;
            }
            else
            {
                authMode = DataBaseAuthMode.SqlAuth;
            }
            var SelectLang = comboBoxEditLang.EditValue as ComboxLang;
            SystemConfigure.SaveDataBaseConnectionData(comboBoxEditServerName.Text.Trim(), strDataBaseName.Trim(), textEditUserName.Text.Trim(), textEditUserPwd.Text.Trim(), authMode, SelectLang.Value, checkEditDisableSync.Checked ? 1 : 0);
            
        }
        private int ExcCmdSQLStr(string strSql, ref string errorDes)
        {
            int intRec = -1;

            errorDes = "";
            SqlConn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(strSql, SqlConn);
                cmd.CommandTimeout = 0;
                intRec = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorDes = ex.Message;
            }
            finally
            {
                SqlConn.Close();
            }


            return intRec;
        }
        private void RestoreDataBase(string fileName, string dataBaseName)
        {
            string SQLLinkStr = "Data Source=" + comboBoxEditServerName.Text.Trim();
            if (radioButtonWindowsAuth.Checked)
            {//window 验证
                SQLLinkStr = SQLLinkStr + ";Initial Catalog=master;Integrated Security=SSPI;";
            }
            else
            {
                SQLLinkStr = SQLLinkStr + ";Initial Catalog=master;User Id=" + textEditUserName.Text.Trim() + ";Password=" + textEditUserPwd.Text.Trim() + ";";
            }

            SqlConnection conn = new SqlConnection(SQLLinkStr);
            conn.Open();

            //KILLDataBaseProcess
            string szSqlScript = string.Format("SELECT spid FROM sysprocesses,sysdatabases WHERE sysprocesses.dbid=sysdatabases.dbid AND sysdatabases.Name='{0}'", dataBaseName);
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
                strDbFilePath = string.Format("with move 'KATES_DATA' to '{0}'", sqlRestorePath + dataBaseName + ".mdf");
                strDbLogFilePath = string.Format(",move 'KATES_Log' to '{0}'", sqlRestorePath + dataBaseName + ".ldf");
            }

            szSqlScript = string.Format("restore database {0} from disk='{1}' {2}{3} ", dataBaseName, fileName, strDbFilePath, strDbLogFilePath);

            SqlCommand cmdRT = new SqlCommand();
            cmdRT.CommandType = CommandType.Text;
            cmdRT.Connection = conn;
            cmdRT.CommandText = szSqlScript;

            try
            {
                cmdRT.ExecuteNonQuery();
                SaveDataBasePara();
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
            return;
        }
        private List<string> GetSqlServerNames()
        //private void GetSqlServerNames()
        {
            List<string> SqlList = new List<string>();
            //SQLDMO.Application sqlApp = new SQLDMO.Application();
            //SQLDMO.NameList serverName;

            //serverName = sqlApp.ListAvailableSQLServers();
            //for (int i = 1; i <= serverName.Count; i++)
            //{
            //    SqlList.Add(serverName.Item(i));
            //}
            //if(serverName.Count > 0)
           // comboBoxEditServerName.SelectedIndex = 0;

            try
            {
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE/Microsoft/Microsoft SQL Server");
                String[] instances = (String[])rk.GetValue("InstalledInstances");
                if (instances.Length > 0)
                {
                    foreach (String element in instances)
                    {
                        if (element == "MSSQLSERVER")
                            SqlList.Add(System.Environment.MachineName);
                        else
                            SqlList.Add(System.Environment.MachineName + @"/" + element);
                    }
                    //comboBoxEditServerName.SelectedIndex = 0;
                }
            }
            catch
            {
            }
          
            //List<string> SqlList = new List<string>();
            //SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            //System.Data.DataTable dataSources = instance.GetDataSources();

            //DataColumn column = dataSources.Columns["InstanceName"];
            //DataColumn column2 = dataSources.Columns["ServerName"];

            //DataRowCollection rows = dataSources.Rows;
            //string array = string.Empty;
            //for (int i = 0; i < rows.Count; i++)
            //{
            //    string str2 = rows[i][column2] as string;
            //    string str = rows[i][column] as string;
            //    if (((str == null) || (str.Length == 0)) || ("MSSQLSERVER" == str))
            //    {
            //        array = str2;
            //    }
            //    else
            //    {
            //        //array = str2 + @"/" + str;
            //        array = str2;
            //    }
            //    //comboBoxEditServerName.Properties.Items.Add(array);
            //    SqlList.Add(array);
            //}
           // if (rows.Count > 0)
              //  comboBoxEditServerName.SelectedIndex = 0;
            return SqlList;
        }
        #endregion

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            SaveDataBasePara();
            this.DialogResult = DialogResult.OK; 
            this.Close();
        }

        private void FormDbServerSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void FormDbServerSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            sdf.Hide();
            ar.AsyncWaitHandle.Close();
        }

        private void buttonSaveLang_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxEditLang_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void checkEditDisableSync_EditValueChanged(object sender, EventArgs e)
        {
            if (FormLoadFinish == 1)
            {
                //SystemConfigure.SetDisableSyncData(checkEditDisableSync.Checked?1:0);
            }
            //
        }

        private void comboBoxEditLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormLoadFinish == 1)
            {
                //var SelectLang = comboBoxEditLang.EditValue as ComboxLang;
                //SystemConfigure.SetDefaultLanguage(SelectLang.Value);
                //System.Environment.Exit(0);
            }
        }

       

    }
}