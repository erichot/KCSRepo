using KCS.Common.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using KCS.Common.Utils;

namespace KCS.Models
{
    static class SupervisorDataSource
    {
        static public IList<EmployeeSupervisor> GetSupervisorList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetSupervisorListByCommand("All");
            return KCS.Common.Utils.ModelConvertHelper<EmployeeSupervisor>.ConvertToModel(dt);
        }
        static public bool UpdateSupervisor(EmployeeSupervisor supervisor)
        {
            return KCSDatabaseHelper.Instance.UpdateSupervisor(supervisor, CredentialsSource.GetLoginSupervisorSID());
        }
        static public bool UpdateSupervisorPin(string id, string pin)
        {
            /*
             * Modified:    2023/07/20
             * Ver:         1.1.5.11
             */
            //return KCSDatabaseHelper.Instance.UpdateSupervisorPin(id, LoginPwdCryption.EnCode(pin));
            return KCSDatabaseHelper.Instance.UpdateSupervisorPin(id, KCS.Helpers.HashHelper.ComputeStringToSha256Hash(pin));
        }
        static public bool NewSupervisor(EmployeeSupervisor supervisor)
        {
            /*
             * Modified:    2023/07/20
             * Ver:         1.1.5.11
            supervisor.NewUserPwd = LoginPwdCryption.EnCode(supervisor.NewUserPwd);
             */
            supervisor.NewUserPwd = KCS.Helpers.HashHelper.ComputeStringToSha256Hash(supervisor.NewUserPwd);

            return KCSDatabaseHelper.Instance.InsertNewSupervisor(supervisor, CredentialsSource.GetLoginSupervisorSID());
        }
        static public bool DeleteSupervisor(int supervisorSID)
        {
            return KCSDatabaseHelper.Instance.DeleteSuervisorBySID(supervisorSID);
        }
    }
}
