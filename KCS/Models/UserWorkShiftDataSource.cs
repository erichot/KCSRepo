using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCS.Common.DAL;

namespace KCS.Models
{
    static class UserWorkShiftDataSource
    {
        static public IList<UserWorkShift> GetUserWorkShiftList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetUserWorkShiftList();
            return KCS.Common.Utils.ModelConvertHelper<UserWorkShift>.ConvertToModel(dt);

        }
        static public bool UpdateUserWorkShift(WorkShiftSetting workshiftsetting, int UserSID)
        {
            return KCSDatabaseHelper.Instance.UpdateUserWorkShift(workshiftsetting, UserSID);
        }
        static public bool UpdateUserWorkShift(int WeekdayNo, string ShiftCode, int UserSID)
        {
            return KCSDatabaseHelper.Instance.UpdateUserWorkShift(WeekdayNo, ShiftCode, UserSID);
        }
        static public IList<WorkCalendar> GetWorkCalendarMonthlyList(int Year)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetWorkCalendarMonthlyList(Year);
            return KCS.Common.Utils.ModelConvertHelper<WorkCalendar>.ConvertToModel(dt);

        }
    }
}
