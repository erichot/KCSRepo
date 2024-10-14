using System;
using DevExpress.Xpo;

namespace KCS.Models
{

    public static class AppRegistryModel 
    {

        public const string REG_KEY_SW_CU_KCS = @"SOFTWARE\KCS";
        public const string REG_ITEM_UserID = @"UserID";
        public const string REG_ITEM_Password = @"Password";
        public const string REG_ITEM_IsAutoLogon = @"IsAutoLogon";
    }

}