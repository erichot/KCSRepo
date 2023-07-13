using KCS.Common.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    class AccessControlDataSource
    {
        static public IList<AcHolidaySet> GetHolidaySetList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetHolidaySetList();
            return KCS.Common.Utils.ModelConvertHelper<AcHolidaySet>.ConvertToModel(dt);
        }
        static public IList<AcTimeSet> GetTimeFrameList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetTimeFrameList();
            return KCS.Common.Utils.ModelConvertHelper<AcTimeSet>.ConvertToModel(dt);
        }
        static public IList<AcTimeZone> GetTimeZoneList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetTimeZoneList();
            return KCS.Common.Utils.ModelConvertHelper<AcTimeZone>.ConvertToModel(dt);
        }
        static public IList<AcUserGroupSet> GetUserGroupList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetUserGoupList();
            return KCS.Common.Utils.ModelConvertHelper<AcUserGroupSet>.ConvertToModel(dt);
        }

        static public bool UpdateUserGroupSet(AcUserGroupSet usergroup)
        {
            return KCSDatabaseHelper.Instance.UpdateUserGroupSet(usergroup, CredentialsSource.GetLoginSupervisorSID());
        }
        
        static public bool UpdateHolidaySet(AcHolidaySet holiday)
        {
            return KCSDatabaseHelper.Instance.UpdateHolidaySet(holiday, CredentialsSource.GetLoginSupervisorSID());
        }
        static public bool UpdateTimeFrameSet(AcTimeSet timeFrame)
        {
            return KCSDatabaseHelper.Instance.UpdateTimeFrameSet(timeFrame, CredentialsSource.GetLoginSupervisorSID());
        }
        static public bool UpdateTimeZoneSet(AcTimeZone timeZone)
        {
            return KCSDatabaseHelper.Instance.UpdateTimeZoneSet(timeZone, CredentialsSource.GetLoginSupervisorSID());
        }
        
    }
}
