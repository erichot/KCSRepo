using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

using KCS.Common.DAL;
using KCS.Common.Utils;



namespace KCS.Models
{
    static class CredentialsSource
    {
        static List<string> userList = new List<string>();         
        private static LoginAdmin LoginSupervisor = new LoginAdmin();
       public static Administrator LoginAdministrator = new Administrator();
       static CredentialsSource()
       {
           string szPath = string.Format("{0}\\data.bin", XmlHelper.GetWorkDirectory());
           FileStream fs = new FileStream(szPath, FileMode.OpenOrCreate);

           if (fs.Length > 0)
           {
               BinaryFormatter bf = new BinaryFormatter();
               userList = bf.Deserialize(fs) as List<string>;      

           }
           fs.Close();
           ReadAdministrator();
       }
       static public string GetLoginSupervisorMsg()
       {
           return LoginSupervisor.UserNo + ":" + LoginSupervisor.UserName;
       }
        static public int GetLoginSupervisorSID()
       {
           return LoginSupervisor.UserSID;
       }
        static public int GetLoginSupervisorType()
       {
           return LoginSupervisor.UserPermissionTypeID;
       }
        static public string GetLoginSupervisorDepID()
       {
           return LoginSupervisor.DepartmentID;
       }

        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        * Add:     2023/08/08
        * Ver:     1.1.5.11
        */
        static public DateTime? GetLoginSupervisorExpirationDate()
        {
            return LoginSupervisor.PasswordExpirationDate;
        }

        static public bool GetLoginSupervisorIsLocked()
        {
            return LoginSupervisor.IsLocked;
        }
        static public DateTime? GetLoginSupervisorTimeLockout()
        {
            return LoginSupervisor.TimeLockout;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        * Add:     2023/09/19
        * Ver:     1.1.5.11
        */
     
        static public int GetLoginSupervisorUserPermissionTypeID()
        {
            return LoginSupervisor.UserPermissionTypeID ;
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        static public void ReadAdministrator()
       {
           try
           {
               DataTable dt = KCSDatabaseHelper.Instance.GetLoginUserMsg("ADMIN");
               if (dt != null && dt.Rows.Count != 0)
               {
                   LoginAdministrator.UserNo = "ADMIN";
                   LoginAdministrator.UserName = dt.Rows[0][2].ToString().Trim();
                   LoginAdministrator.NewUserPwd = "";
                   LoginAdministrator.NewUserPwdAgain = "";
                   LoginAdministrator.UserPwd = "";

                   /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    * Modified:    2023/07/20
                    * Ver:         1.1.5.11
                    * Note:        所有從DB讀出的密碼皆為Hashed/Encrypted
                    LoginAdministrator.OldUserPwd = LoginPwdCryption.DeCode(dt.Rows[0][7].ToString());
                    */
                    LoginAdministrator.OldUserPwd = dt.Rows[0][7].ToString();
                    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                }
            }
            catch
            {
            }
        }
         static public bool UpdateAdminPin()
        {
            /*
             * Modified:    2023/07/20
             * Ver:         1.1.5.10
            return KCSDatabaseHelper.Instance.UpdateSupervisorPin("ADMIN", LoginPwdCryption.EnCode(LoginAdministrator.NewUserPwd));
            */            
            return KCSDatabaseHelper.Instance.UpdateSupervisorPin("ADMIN", KCS.Helpers.HashHelper.ComputeStringToSha256Hash(LoginAdministrator.NewUserPwd));

        }
         static public void CacheLoginUser(string loginUser) 
        {
            string szPath = string.Format("{0}\\data.bin", XmlHelper.GetWorkDirectory());
            FileStream fs = new FileStream(szPath, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();

            if (!userList.Contains(loginUser))
            {
                userList.Add(loginUser);
                bf.Serialize(fs, userList);
            }

            fs.Close();
        }
         static public bool Check(string loginUserId, string pwd, bool cachOrNot)
        {
            int rUserSID;

            rUserSID = KCSDatabaseHelper.Instance.SP_GetUserSIDByUserID(loginUserId);
            if (rUserSID > 0)
            {
                string strReadPwd = "";
                if (KCSDatabaseHelper.Instance.SP_GetUserPwdByUserSID(rUserSID, out strReadPwd) > 0)
                {
                    /*
                     * Modified:    2023/07/20
                     * Ver:         1.1.5.11
                    string strPassword = LoginPwdCryption.DeCode(strReadPwd);
                    if (strPassword == pwd)
                    */
                    if ((strReadPwd == "" && pwd == "")
                        || strReadPwd == KCS.Helpers.HashHelper.ComputeStringToSha256Hash(pwd))
                    {
                        if (cachOrNot)
                        {
                            CacheLoginUser(loginUserId);
                        }
                        DataTable dt = KCSDatabaseHelper.Instance.GetLoginUserMsg(loginUserId);
                        if (dt != null && dt.Rows.Count != 0)
                        {
                            LoginSupervisor.UserNo = loginUserId;
                            LoginSupervisor.UserUnionType = int.Parse(dt.Rows[0][0].ToString().Trim());
                            LoginSupervisor.UserSID = rUserSID;
                            LoginSupervisor.UserName = dt.Rows[0][2].ToString().Trim();
                            LoginSupervisor.GroupSID = int.Parse(dt.Rows[0][3].ToString().Trim());
                            LoginSupervisor.UserPermissionTypeID = int.Parse(dt.Rows[0][4].ToString().Trim());
                            LoginSupervisor.DepartmentID = dt.Rows[0][5].ToString().Trim();
                            LoginSupervisor.IsReadOnly = int.Parse(dt.Rows[0][6].ToString().Trim());
                            LoginSupervisor.UserPwd = pwd;
                            if (!string.IsNullOrEmpty(LoginSupervisor.DepartmentID))
                            {
                                LoginSupervisor.DepartmentSID = KCSDatabaseHelper.Instance.SP_Get_BF_Department_DepartmentSID(LoginSupervisor.DepartmentID);
                            }

                            /*
                            * Add:    2023/08/08
                            * Ver:         1.1.5.11
                            */
                            LoginSupervisor.IsLocked = Convert.ToBoolean(dt.Rows[0]["IsLocked"]);

                            if (dt.Rows[0]["TimeLockout"] != DBNull.Value)
                            {
                                if (DateTime.TryParse(dt.Rows[0]["TimeLockout"].ToString(), out DateTime _timeLockout))
                                    LoginSupervisor.TimeLockout = _timeLockout;
                            }

                            if (dt.Rows[0]["PasswordExpirationDate"] != DBNull.Value)
                            {
                                if (DateTime.TryParse(dt.Rows[0]["PasswordExpirationDate"].ToString(), out DateTime _expirationDate))
                                    LoginSupervisor.PasswordExpirationDate = _expirationDate;
                            }
                            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                        }
                        return true;
                    }
                }
            }

            return false;
        }
         
         static public System.Collections.Generic.IEnumerable<string> GetUserIds()
        {
           
           
            
                foreach (string item in userList)
                    yield return item;
            
        }
    }
}
