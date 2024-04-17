using KCS.Common.DAL.Constants;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;

using KCS.Helpers;

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
        public static string DBConnectionString = "";
        public static string LanguageSelect = "EN";
        public static string CompanyName = "Test";
        public static int IsDisSyncDataOrNot = 1;
        private static string server_ip = "";
        private static int server_port = 0;
        public static DataBaseAuthMode AuthMode = DataBaseAuthMode.Unknown;
        private static string CONFIG_FILE = "KCS_Config.xml";
        private static string EXPORT_TXT_FILE = "KCS_TxtExportConfig.xml";
        //是否导出 TxT
        public static int ExportToTxtOrNot = 0;
        //导出分隔符
        public static string ExportSeperator = ",";
        //时间分隔符
        public static int ExportDateSeperator = 0;
        //设备id长度
        public static int ExportSlaveIdLen = 0;
        //导出工作代码值还是名称
        public static int ExportJobCodeProperty = 0;
        //导出文件名称,默认每天导出
        public static int ExportFileByMonth = 0;
        // 0 Year/Moth/Day
        // 1 Moth/Day/Year
        // 2 Day/Moth/Year
        public static int ExportDateFormate = 0;
        //日期长度
        public static int ExportDateLen = 0;
        //Time formate
        public static int ExportTimeFormate = 0;
        //Store Pah
        public static string ExportFilePath = "ExportDatas";
        //
        public static string ExportFixedText = "";
        public static string ExportFixedText2 = "";
        public static string ExportFixedText3 = "";
        public static string ExortTitleText = "";
        public static string ExportFileExtension = "";
        public static int CheckExportFixedFileName = 0;
        public static string ExportFixedFileName = "";
        public static int CheckASCIIFormat = 0;
        public static int IncludeIllegalRecords = 0;
        //
        //Card Id长度
        public static int ExportCardIdLen = 0;
        public static List<string> ExportItemsList = new List<string>();
        public static List<int> slavesList = new List<int>();


        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        * Add:          2023/07/21
        * Ver:         1.1.5.11
        * Note:        所有從DB讀出的密碼皆為Hashed/Encrypted
        */
        public static bool IsEnableEncryptDbConfigXML = false;
        public static bool IsEnableEncryptExportData = false;
        public static bool IsEnablePasswordPolicy = false;
        public static bool IsForceToChangePassword = false;     // 系統變數，非常數，比對DB後才設定該變數
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        static void GetSlavesList()
        {
            string szPath = string.Format("{0}\\SlaveLists.bin", XmlHelper.GetWorkDirectory());
            FileStream fs = new FileStream(szPath, FileMode.OpenOrCreate);

            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                slavesList = bf.Deserialize(fs) as List<int>;

            }
            fs.Close();

        }
        public static void SaveSlavesList()
        {
            string szPath = string.Format("{0}\\SlaveLists.bin", XmlHelper.GetWorkDirectory());
            FileStream fs = new FileStream(szPath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, slavesList);

            fs.Close();
        }
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
        public static void SaveDataBaseConnectionData(string strSqlServerName, string strDbName, string strAuthName, string strAuthPin, DataBaseAuthMode authMode,string LangSel,int isSync)
        {
            /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            * Modified:    2023/07/21
            * Ver:         1.1.5.10
            * Note:        
            XmlHelper.WriteConfigData("ServerName", strSqlServerName, CONFIG_FILE);
            XmlHelper.WriteConfigData("DataBaseName", strDbName, CONFIG_FILE);
            XmlHelper.WriteConfigData("LoginName", strAuthName, CONFIG_FILE);
            XmlHelper.WriteConfigData("LoginPwd", strAuthPin, CONFIG_FILE);
            */
            var vSqlServerName = strSqlServerName;
            var vDbName = strDbName;
            var vAuthName = strAuthName;
            var vAuthPin = strAuthPin;
            if (IsEnableEncryptDbConfigXML)
            {
                vSqlServerName = EncryptHelper.EncryptAES(strSqlServerName);
                vDbName = EncryptHelper.EncryptAES(strDbName);
                vAuthName = EncryptHelper.EncryptAES(strAuthName);
                vAuthPin = EncryptHelper.EncryptAES(strAuthPin);
            }
            XmlHelper.WriteConfigData("ServerName", vSqlServerName, CONFIG_FILE);
            XmlHelper.WriteConfigData("DataBaseName", vDbName, CONFIG_FILE);
            XmlHelper.WriteConfigData("LoginName", vAuthName, CONFIG_FILE);
            XmlHelper.WriteConfigData("LoginPwd", vAuthPin, CONFIG_FILE);
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            XmlHelper.WriteConfigData("LoginMode", ((int)authMode).ToString(), CONFIG_FILE);
            SetDefaultLanguage(LangSel);
            SetDisableSyncData(isSync);
            LoadDataBaseConnectionData();

            return;
        }
        public static void SetDefaultLanguage(string lang)
        {
            if (!string.IsNullOrEmpty(lang))
            {
                
                XmlHelper.WriteConfigData("DefaultLanguage", lang, CONFIG_FILE);
                LanguageSelect = lang;
            }
        }
        public static void SetDisableSyncData(int value)
        {
            XmlHelper.WriteConfigData("DisSyncData", value.ToString(), CONFIG_FILE);
            IsDisSyncDataOrNot = value;
        }
        public static void SetDefaultCompanyName(string companyName)
        {
            if (!string.IsNullOrEmpty(companyName))
            {

                XmlHelper.WriteConfigData("CompanyName", companyName, CONFIG_FILE);
                CompanyName = companyName;
            }
        }
        public static void LoadDataBaseConnectionData()
        {
            try
            {
                string szConfigFile = string.Format("{0}\\{1}", XmlHelper.GetWorkDirectory(), CONFIG_FILE);
                if (System.IO.File.Exists(szConfigFile))
                {
                    LanguageSelect = XmlHelper.GetConfigData("DefaultLanguage", "EN", CONFIG_FILE);
                    IsDisSyncDataOrNot = XmlHelper.GetConfigData("DisSyncData", 0, CONFIG_FILE);
                    AuthMode = (DataBaseAuthMode)XmlHelper.GetConfigData("LoginMode", 0, CONFIG_FILE);

                    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                     * Modified:    2023/07/20
                     * Ver:         1.1.5.11
                     * Note:        所有從DB讀出的密碼皆為Hashed/Encrypted
                     SqlServerName = XmlHelper.GetConfigData("ServerName", "", CONFIG_FILE);
                    DataBaseName = XmlHelper.GetConfigData("DataBaseName", "", CONFIG_FILE);
                    AuthUserName = XmlHelper.GetConfigData("LoginName", "", CONFIG_FILE);                   
                    AuthUserPin = XmlHelper.GetConfigData("LoginPwd", "", CONFIG_FILE);
                     */
                    var vServerName = XmlHelper.GetConfigData("ServerName", "", CONFIG_FILE);
                    var vDataBaseName = XmlHelper.GetConfigData("DataBaseName", "", CONFIG_FILE);
                    var vAuthUserName = XmlHelper.GetConfigData("LoginName", "", CONFIG_FILE);
                    var vLoginPwd = XmlHelper.GetConfigData("LoginPwd", "", CONFIG_FILE);

                    if (IsEnableEncryptDbConfigXML )
                    {
                        try
                        {
                            SqlServerName = EncryptHelper.DecryptAES(vServerName);
                            DataBaseName = EncryptHelper.DecryptAES(vDataBaseName);
                            AuthUserName = EncryptHelper.DecryptAES(vAuthUserName);
                            AuthUserPin = EncryptHelper.DecryptAES(vLoginPwd);
                        }
                        catch (Exception ex)
                        {
                            // Message = "輸入不是有效的 Base-64 字串，因為它含有非 Base-64 字元、兩個以上填補字元，或在填補字元中有不合法的字元。 "
                            if (ex.HResult == -2146233033)
                            {
                                SaveDataBaseConnectionData(vServerName, vDataBaseName, vAuthUserName, AuthUserPin, AuthMode, LanguageSelect, IsDisSyncDataOrNot);
                            }
                        }
                    }
                    else
                    {
                        SqlServerName = vServerName;
                        DataBaseName = vDataBaseName;
                        AuthUserName = vAuthUserName;
                        AuthUserPin = vLoginPwd;
                    }
                    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                    
                    
                    CompanyName = XmlHelper.GetConfigData("CompanyName", "Test", CONFIG_FILE);
                    
                    server_ip = XmlHelper.GetConfigData("ServerIP", "", CONFIG_FILE);
                    server_port = XmlHelper.GetConfigData("ServerPort", 0, CONFIG_FILE);
                    


                    if (ParaValidOrNot())
                    {
                        if (AuthMode == DataBaseAuthMode.WindowsAuth)
                        {

                            // Modified:2024/04/09
                            // Ver:1.1.5.20
                            // Remark:A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - 此憑證鏈結是由不受信任的授權單位發出的
                            // DBConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=master"  + ";Integrated Security=SSPI;Connect Timeout=20;Max Pool Size = 10000;";
                            //KatesConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=" + DataBaseName + ";Integrated Security=SSPI;Connect Timeout=20;Max Pool Size = 10000;";
                            DBConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=master" + ";Integrated Security=SSPI;Connect Timeout=20;Max Pool Size = 10000;TrustServerCertificate=true;";
                            KatesConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=" + DataBaseName + ";Integrated Security=SSPI;Connect Timeout=20;Max Pool Size = 10000;TrustServerCertificate=true;";
                        }
                        else
                        {

                            // Modified:2024/04/09
                            // Ver:1.1.5.20
                            // Remark:A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - 此憑證鏈結是由不受信任的授權單位發出的
                            // DBConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=master"  + ";User Id=" + AuthUserName + ";Password=" + AuthUserPin + ";;Connect Timeout=20;Max Pool Size = 10000;";
                            //KatesConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=" + DataBaseName + ";User Id=" + AuthUserName + ";Password=" + AuthUserPin + ";;Connect Timeout=20;Max Pool Size = 10000;";
                            DBConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=master" + ";User Id=" + AuthUserName + ";Password=" + AuthUserPin + ";;Connect Timeout=20;Max Pool Size = 10000;TrustServerCertificate=true;";
                            KatesConnectionString = "Data Source=" + SqlServerName + ";Initial Catalog=" + DataBaseName + ";User Id=" + AuthUserName + ";Password=" + AuthUserPin + ";;Connect Timeout=20;Max Pool Size = 10000;TrustServerCertificate=true;";
                        }
                    }
                }
                szConfigFile = string.Format("{0}\\{1}", XmlHelper.GetWorkDirectory(), EXPORT_TXT_FILE);
                if (System.IO.File.Exists(szConfigFile))
                {
                    ExportSeperator = XmlHelper.GetConfigData("ExportSeperator", ",", EXPORT_TXT_FILE);
                    ExportDateSeperator = XmlHelper.GetConfigData("ExportDateSeperator", 0, EXPORT_TXT_FILE);
                    ExportToTxtOrNot = XmlHelper.GetConfigData("ExportToTxtOrNot", 0, EXPORT_TXT_FILE);
                    ExportSlaveIdLen = XmlHelper.GetConfigData("ExportSlaveIdLen", 0, EXPORT_TXT_FILE);
                    ExportJobCodeProperty = XmlHelper.GetConfigData("ExportJobCodeProperty", 0, EXPORT_TXT_FILE);

                    ExportFileByMonth = XmlHelper.GetConfigData("ExportFileByMonth", 0, EXPORT_TXT_FILE);
                    ExportDateFormate = XmlHelper.GetConfigData("ExportDateFormate", 0, EXPORT_TXT_FILE);
                    ExportTimeFormate = XmlHelper.GetConfigData("ExportTimeFormate", 0, EXPORT_TXT_FILE);
                    ExportFilePath = XmlHelper.GetConfigData("ExportFilePath", "ExportDatas", EXPORT_TXT_FILE);
                    ExportDateLen = XmlHelper.GetConfigData("ExportDateLength", 0, EXPORT_TXT_FILE);
                    ExportFixedText = XmlHelper.GetConfigData("ExportFixedText","", EXPORT_TXT_FILE);
                    ExortTitleText = XmlHelper.GetConfigData("ExortTitleText", "", EXPORT_TXT_FILE);
                    ExportFileExtension = XmlHelper.GetConfigData("ExortFileExtension", "txt", EXPORT_TXT_FILE);
                    CheckExportFixedFileName = XmlHelper.GetConfigData("CheckExportFixedFileName", 0, EXPORT_TXT_FILE);
                    ExportFixedFileName = XmlHelper.GetConfigData("ExportFixedFileName", "Attendance", EXPORT_TXT_FILE);
                    CheckASCIIFormat = XmlHelper.GetConfigData("CheckASCIIFormat", 0, EXPORT_TXT_FILE);
                    ExportCardIdLen = XmlHelper.GetConfigData("ExportCardIdLen", 0, EXPORT_TXT_FILE);
                    ExportFixedText2=XmlHelper.GetConfigData("ExportFixedText2", "", EXPORT_TXT_FILE);
                    ExportFixedText3 = XmlHelper.GetConfigData("ExportFixedText3", "", EXPORT_TXT_FILE);
                    IncludeIllegalRecords = XmlHelper.GetConfigData("IncludeIllegal", 0, EXPORT_TXT_FILE);
                }



                ReadExportItems();
                GetSlavesList();
            }
            catch
            {
            }
        }
        private static void ReadExportItems()
        {
            string szConfigFile = string.Format("{0}\\ExportFormate.txt", XmlHelper.GetWorkDirectory());
            if (System.IO.File.Exists(szConfigFile))
            {
                StreamReader sr = new StreamReader(szConfigFile, Encoding.Default);
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    ExportItemsList.Add(line.ToString());
                }
            }
        }
        public static void SaveTxtExportSetting(int exportToTxtOrNot, int exportDateSeperator, string exportSeperator,
            int exportSlaveIdLen, int exportJobCodeProperty, int exportFileByMonth, int exportDateFormate,
            int exportTimeFormate, string exportFilePath, int exportDateLen, string exportFixedText, string exportExortTitleText, string exportExortExtensionText,
            int checkExportFixedFileName, string exportFixedFileName, int checkAsciiFormat, int exportCardIdLen,string exportFixedText2,string exportFixedText3,
            int includeIllegal)
        {
            XmlHelper.WriteConfigData("ExportSeperator", exportSeperator, EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportDateSeperator", exportDateSeperator.ToString(), EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportToTxtOrNot", exportToTxtOrNot.ToString(), EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportSlaveIdLen", exportSlaveIdLen.ToString(), EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportJobCodeProperty", exportJobCodeProperty.ToString(), EXPORT_TXT_FILE);

            XmlHelper.WriteConfigData("ExportFileByMonth", exportFileByMonth.ToString(), EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportDateFormate", exportDateFormate.ToString(), EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportTimeFormate", exportTimeFormate.ToString(), EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportFilePath", exportFilePath, EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportDateLength", exportDateLen.ToString(), EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportFixedText", exportFixedText, EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExortTitleText", exportExortTitleText, EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExortFileExtension", exportExortExtensionText, EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("CheckExportFixedFileName", checkExportFixedFileName.ToString(), EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportFixedFileName", exportFixedFileName, EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("CheckASCIIFormat", checkAsciiFormat.ToString(), EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportCardIdLen", exportCardIdLen.ToString(), EXPORT_TXT_FILE);

            XmlHelper.WriteConfigData("ExportFixedText2", exportFixedText2, EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("ExportFixedText3", exportFixedText3, EXPORT_TXT_FILE);
            XmlHelper.WriteConfigData("IncludeIllegal", includeIllegal.ToString(), EXPORT_TXT_FILE);

            


            ExportSeperator = exportSeperator;
            ExportDateSeperator = exportDateSeperator;
            ExportToTxtOrNot = exportToTxtOrNot;
            ExportSlaveIdLen = exportSlaveIdLen;
            ExportJobCodeProperty = exportJobCodeProperty;

            ExportFileByMonth = exportFileByMonth;
            ExportDateFormate = exportDateFormate;
            ExportTimeFormate = exportTimeFormate;
            ExportFilePath = exportFilePath;
            ExportDateLen = exportDateLen;
            ExportFixedText = exportFixedText;
            ExortTitleText = exportExortTitleText;
            ExportFileExtension = exportExortExtensionText;

            CheckExportFixedFileName = checkExportFixedFileName;
            ExportFixedFileName = exportFixedFileName;
            CheckASCIIFormat = checkAsciiFormat;
            ExportCardIdLen = exportCardIdLen;
            ExportFixedText2 = exportFixedText2;
            ExportFixedText2 = exportFixedText3;
            IncludeIllegalRecords = includeIllegal;

            return;
        }
    }
}
