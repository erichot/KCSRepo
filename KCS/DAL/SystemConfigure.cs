using KCS.Common.DAL.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace KCS.Common.DAL
{
    class SystemConfigure
    {
        private const int SERVER_PORT = 9008;
        public static string SqlServerName = "";
        public static string DataBaseName = "";
        public static string AuthUserName = "";
        public static string AuthUserPin = "";
        public static string KatesConnectionString = "";
        public static string LanguageSelect = "EN";
        private static string server_ip = "";
        private static int server_port = 0;
        public static DataBaseAuthMode AuthMode = DataBaseAuthMode.Unknown;
        private static string CONFIG_FILE = "KCS_Config.xml";
        
        public static string ServerIP
        {
            get
            {
                if (server_ip != "")
                {
                    return server_ip;
                }
               
                    System.Net.IPHostEntry ipHostInfo = System.Net.Dns.Resolve(System.Net.Dns.GetHostName());
                    return ipHostInfo.AddressList[0].ToString();
                
            }
        }
        public static int ServerPort
        {
            get
            {
                if (server_port == 0)
                    return SERVER_PORT;
                return server_port;
            }
        }
        public static bool DataBaseConfigureIsValidOrNot()
        {
            return !string.IsNullOrEmpty(KatesConnectionString);
        }
        private static bool ParaValidOrNot()
        {
            if (AuthMode == DataBaseAuthMode.Unknown)
            {
                return false;
            }
            if (string.IsNullOrEmpty(SqlServerName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(DataBaseName))
            {
                return false;
            }
            if (AuthMode == DataBaseAuthMode.SqlAuth)
            {
                if (string.IsNullOrEmpty(AuthUserName))
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSqlServerName"></param>
        /// <param name="strDbName"></param>
        /// <param name="strAuthName"></param>
        /// <param name="strAuthPin"></param>
        /// <param name="authMode"></param>
        public static void SaveDataBaseConnectionData(string strSqlServerName, string strDbName, string strAuthName, string strAuthPin, DataBaseAuthMode authMode,string LangSel)
        {
            XmlHelper.WriteConfigData("ServerName", strSqlServerName, CONFIG_FILE);
            XmlHelper.WriteConfigData("DataBaseName", strDbName, CONFIG_FILE);
            XmlHelper.WriteConfigData("LoginName", strAuthName, CONFIG_FILE);
            XmlHelper.WriteConfigData("LoginPwd", strAuthPin, CONFIG_FILE);
            XmlHelper.WriteConfigData("LoginMode", ((int)authMode).ToString(), CONFIG_FILE);
            SetDefaultLanguage(LangSel);
            LoadDataBaseConnectionData();

            return;
        }
        public static void SetDefaultLanguage(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                XmlHelper.WriteConfigData("DefaultLanguage", lang, CONFIG_FILE);
            }
        }
        public static void LoadDataBaseConnectionData()
        {
            
            string szConfigFile = string.Format("{0}\\{1}", XmlHelper.GetWorkDirectory(), CONFIG_FILE);
            if (System.IO.File.Exists(szConfigFile))
            {
                SqlServerName = XmlHelper.GetConfigData("ServerName", "", CONFIG_FILE);
                DataBaseName = XmlHelper.GetConfigData("DataBaseName", "", CONFIG_FILE);
                AuthUserName = XmlHelper.GetConfigData("LoginName", "", CONFIG_FILE);
                AuthUserPin = XmlHelper.GetConfigData("LoginPwd", "", CONFIG_FILE);
                AuthMode = (DataBaseAuthMode)XmlHelper.GetConfigData("LoginMode", 0, CONFIG_FILE);
                LanguageSelect = XmlHelper.GetConfigData("DefaultLanguage", "EN", CONFIG_FILE);
                server_ip = XmlHelper.GetConfigData("ServerIP", "", CONFIG_FILE);
                server_port = XmlHelper.GetConfigData("ServerPort", 0, CONFIG_FILE);
                
                
                
                if (ParaValidOrNot())
                {
                    if (AuthMode == DataBaseAuthMode.WindowsAuth)
                    {
                        KatesConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=" + DataBaseName + ";Integrated Security=SSPI;";
                    }
                    else
                    {
                        KatesConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=" + DataBaseName + ";User Id=" + AuthUserName + ";Password=" + AuthUserPin + ";";
                    }
                }
            }
            

        }
    }
}
