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
            return KCSDatabaseHelper.Instance.UpdateSupervisorPin(id, LoginPwdCryption.EnCode(pin));
        }
        static public bool NewSupervisor(EmployeeSupervisor supervisor)
        {
            supervisor.NewUserPwd = LoginPwdCryption.EnCode(supervisor.NewUserPwd);
            return KCSDatabaseHelper.Instance.InsertNewSupervisor(supervisor, CredentialsSource.GetLoginSupervisorSID());
        }
        static public bool DeleteSupervisor(int supervisorSID)
        {
            return KCSDatabaseHelper.Instance.DeleteSuervisorBySID(supervisorSID);
        }
    }
}
