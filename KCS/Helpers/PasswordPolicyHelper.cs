using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace KCS.Helpers
{
    public static class PasswordPolicyHelper
    {
        

        public static bool IsPasswordValid(string newPassword, out string ReturnMessage)
        {
            // Define password policy criteria
            int minimumLength = 15;
            bool requireUppercase = true;
            bool requireLowercase = true;
            bool requireDigit = true;
            bool requireSpecialChar = true;
            bool requireIdentical = true;
            

            // 1 Check password length
            if (newPassword.Length < minimumLength)
            {
                ReturnMessage = "Password must be at least " + minimumLength + " characters long.";
                return false;
            }

            // 2 Check password complexity
            if (requireUppercase && !Regex.IsMatch(newPassword, "[A-Z]"))
            {
                ReturnMessage = "Password must contain at least one uppercase letter.";
                return false;
            }

            // 3
            if (requireLowercase && !Regex.IsMatch(newPassword, "[a-z]"))
            {
                ReturnMessage = "Password must contain at least one lowercase letter.";
                return false;
            }

            // 4
            if (requireDigit && !Regex.IsMatch(newPassword, "\\d"))
            {
                ReturnMessage = "Password must contain at least one digit.";
                return false;
            }

            // 5
            if (requireSpecialChar && !Regex.IsMatch(newPassword, "[^a-zA-Z0-9]"))
            {
                ReturnMessage = "Password must contain at least one special character.";
                return false;
            }



            if (requireIdentical)
            {
                if (HasConsecutiveNumbers(newPassword))
                {
                    //ReturnMessage = "Password does preventing consecutive numbers!";
                    ReturnMessage = "Password should not contain sequential numbers.";
                    return false;
                }


                if (HasRepeatingCharacters(newPassword))
                {
                    //ReturnMessage = "Password does preventing repeating characters!";
                    ReturnMessage = "Password should not contain repeating number or characters.";
                    return false;
                }


                if (m_CommonPasswordList.Contains(newPassword, StringComparer.OrdinalIgnoreCase))
                {
                    //ReturnMessage = "Password does now allow contain common text to make a password difficult to guess or crack!";
                    ReturnMessage = "Password should not contain common text or easily guessed words.";
                    return false;
                }
            }


            // If all checks pass, the password is considered valid
            ReturnMessage = string.Empty;
            return true;
        }








        private static bool HasRepeatingCharacters(string password)
        {
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] == password[i + 1] && password[i + 1] == password[i + 2])
                    return true;
            }
            return false;
        }


        private static bool HasConsecutiveNumbers(string password)
        {
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (char.IsDigit(password[i]) && char.IsDigit(password[i + 1]) && char.IsDigit(password[i + 2]))
                {
                    int num1 = int.Parse(password[i].ToString());
                    int num2 = int.Parse(password[i + 1].ToString());
                    int num3 = int.Parse(password[i + 2].ToString());

                    if (num2 == num1 + 1 && num3 == num2 + 1)
                        return true;
                }
            }
            return false;
        }







        private static readonly List<string> m_CommonPasswordList = new List<string>(new[]
        {
            "InvalidAuthInfo_InvalidAuthInfo_",
            "tusfbnjoh_Apps0tusfbnjoh_Apps0",
            "IaaS@DATABASE-PublicCLOUD9!",
            "redisdb@dbuser@Cspdbr@2017",
            "itaportal _On_Install_123",
            "@S#_U!T$V&C*0(0)%1^R&78D",
            "itaportal_On_Install_123",
            "qpsubm_Apps0qpsubm_Apps0",
            "z(7%Uk@sd04NiE*b!Q2w#E8r",
            "charging_On_Install_123",
            "itabfm _On_Install_123",
            "payment_On_Install_123",
            "thirdcn_On_Install_123",
            "Trace$Fba$db3@2C6#4bG3",
            "vbpqe_Apps0vbpqe_Apps0",
            "vbpqu_Apps0vbpqu_Apps0",
            "aomsbo_On_Install_123",
            "IaaS@DATABASE-CLOUD8!",
            "IaaS@OS-FSBDBACLOUD8!",
            "itaBfm_On_Install_123",
            "vnIaaS@PORTAL-CLOUD9!",
            "admin123@CallEnabler",
            "apimg_On_Install_123",
            "Huawei123@MuHS#A195N",
            "Huawei123@R3ZhjAgE6X",
            "Huawei123@Vdj5F3O#YI",
            "HuaweiEncryption_123",
            "IaaS@SERVICE-CLOUD8!",
            "IaaS@SERVICE-CLOUD9!",
            "MIIXvcNAQ@cCoII_XSDC",
            "openasadminAdmin23@#",
            "order_On_Install_123",
            "REDIS@B2B_HWsdp-2015",
            "t_authoroperatorinfo",
            "UGW9811adminhwbs@com",
            "Changeme_1234567890",
            "dsbo_On_Install_123",
            "DSDPitaptl_1qaz2wsx",
            "IaaS@PORTAL-CLOUD8!",
            "IaaS@PORTAL-CLOUD9!",
            "Ideploy_Sysadmin123",
            "OdpInner_3er4#ER$12",
            "3er4#ER$3er4#ER$12",
            "4r5t$R%T4r5t$R%T12",
            "aep_On_Install_123",
            "cej_Apps0cej_Apps0",
            "Changemeacs_635241",
            "Changemegvn_635241",
            "Changemepol_635241",
            "cnp200@HWomu800@HW",
            "Dis_13579Dis_13579",
            "eyf_Apps0eyf_Apps0",
            "Huaweinetview2102!",
            "IaaS@OS-FSBCLOUD8!",
            "mdp_On_Install_123",
            "prm_On_Install_123",
            "udaApps0Huawei123#",
            "veb_Apps0veb_Apps0",
            "vtf_Apps0vtf_Apps0",
            "12wedfvb09iuhgvcz",
            "AqkxNwgj@huawei99",
            "cce2OMUrest600@HW",
            "Changemenf_635241",
            "CloudService@123!",
            "dbChangeMe@123456",
            "DSDPoper_1qaz2wsx",
            "Huawei2019QWERT#$",
            "Huawei2019ZXCVB#$",
            "Ideploy_Sftp12345",
            "IR2res@37$Adapter",
            "NetViewCommon2012",
            "IaaS@NODEMANAGER-",
            "/EzFp+2%r6@IxSCv",
            "4a747f28cb32100b",
            "6b6K6Xk]Zws)+[Y5",
            "6SSfJezESqjr14Me",
            "8@o6EuxWqwJf2Y47",
            "Abc1234%$9876zyX",
            "admin@huawei.com",
            "BGq98Zoo@63DOciX",
            "BK3l0c36lF3PkL1x",
            "BMEIMPL@YYYYMMDD",
            "Bmpapp_1Bmpapp_1",
            "C1Ja6F4gM2e_Lb3s",
            "c8$d+S9Q[#n!)v&c",
            "CSP@gaussdb@2017",
            "dbomMql_17itiADb",
            "DSDPamg_1qaz2wsx",
            "DSDPchg_1qaz2wsx",
            "DSDPmdp_1qaz2wsx",
            "DSDPord_1qaz2wsx",
            "DSDPpay_1qaz2wsx",
            "DSDPpro_1qaz2wsx",
            "DSDPrem_1qaz2wsx",
            "DSDPsub_1qaz2wsx",
            "DSDPupm_1qaz2wsx",
            "DSDPZookeeper@1q",
            "DSSPamg_1qaz2wsx",
            "eh_Apps0eh_Apps0",
            "ei*b+@b#6Nh(tS1j",
            "em_Apps0em_Apps0",
            "er_Apps0er_Apps0",
            "expert@cnp200@HW",
            "gcGe_28#F@k83cJk",
            "gW@xtsGyvz9DxAWq",
            "Hk%w-!d@8Ve)qH6p",
            "hsQ7VX^m#Cjoae(y",
            "Huawei@123456789",
            "Ideploy_Derby123",
            "Ideploy_Ftp12345",
            "Image0@Huawei123",
            "itcbbS@EVP123ASD",
            "IVAS@Huawei_1234",
            "J2c55640@999301_",
            "k3<N5_A:l4uYFu?",
            "LbSynIf@C72#2016",
            "LdapChangeMe@123",
            "M8p#iYdQnpv$2u@z",
            "Mj40NT_zNzMwMTgx",
            "msqlOs_179itiADb",
            "Oracle_omOrc_123",
            "pg_search_dn@123",
            "rootMql_17itiADb",
            "rplMql_179itiADb",
            "secOrc_179itiADb",
            "stemsyOrc_179iti",
            "svcOac_179itiADb",
            "sw$24Is@W9Pe#S4s",
            "vBlUSqMN3VQ1VjBj",
            "vrpv8@huawei.com",
            "w0KLJ4xEgZ5XdBvF",
            "WBaESpPNNOKEJsIK",
            "wetallOrc_179iti",
            "wIs3#KqP6M$i@8sU",
            "workssys1qaz@WSX",
            "xu2NDe2hIOClL8C5",
            "zieTmnYtSId0zCKX",
            "Zjg5MjIwNWE3ZTU2",
            "ZyJdJdYwDl,@18y$",
            "OBSCharging8800!",
            "!akira%chaichai",
            "CCN4fma2_dbpd0$",
            "ChangeMe@123456",
            "cnp200@cspos@HW",
            "FusionSphere123",
            "Huaweiftps2102#",
            "IaaS@OS-CLOUD0!",
            "IaaS@OS-CLOUD8!",
            "IaaS@OS-CLOUD9!",
            "mm_user@storage",
            "mt2017@cspos@HW",
            "Oracle_omOs_123",
            "PSVNtest2019@hw",
            "RCS9880_ideploy",
            "123456789123456789",
            "mychemicalromance",
            "highschoolmusical",
            "manchesterunited",
            "cristianoronaldo",
            "123456789123456",            
            "123456789012345",
            "nuncateolvidare",
            "123456789101112",
            "panicatthedisco",
            "111111111111111",


        });


    }



}
