using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCS.Common.DAL;

namespace KCS.Models
{
    static class WorkShiftDataSource
    {
        static public IList<WorkShiftItem> GetWorkShifItemstList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetAllWorkShiftList();
            return KCS.Common.Utils.ModelConvertHelper<WorkShiftItem>.ConvertToModel(dt);

        }
        static public IList<TrunWorkBase> GetTrunWorkBaseList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetTrunWorkBaseList();
            return KCS.Common.Utils.ModelConvertHelper<TrunWorkBase>.ConvertToModel(dt);
        }
        static public IList<TrunWork> GetTrunWorkList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetTrunWorkList();
            return KCS.Common.Utils.ModelConvertHelper<TrunWork>.ConvertToModel(dt);
        }
        static public IList<WorkShift> GetWorkShiftList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetWorkShiftList();
            return KCS.Common.Utils.ModelConvertHelper<WorkShift>.ConvertToModel(dt);

        }
        static public bool DeleteWorkShift(string shiftCode)
        {
            return KCSDatabaseHelper.Instance.DeleteWorkShift(shiftCode) > 0 ? true : false;
        }
        static public bool UpdateWorkShift(WorkShift workShift)
        {
            return KCSDatabaseHelper.Instance.UpdateWorkShift(workShift, CredentialsSource.GetLoginSupervisorMsg());
        }
        static public int UpdateMonthlyWorkShift(WorkCalendar workMonthlyShift)
        {
            return KCSDatabaseHelper.Instance.UpdateMonthlyWorkShift(workMonthlyShift);
        }
        static public bool DeleteFromShiftTable(string shifttable)
        {
            return KCSDatabaseHelper.Instance.DeleteFromShiftTable(shifttable);
        }
        static public bool UpdateShiftTable(object source, object newone)
        {
            return KCSDatabaseHelper.Instance.UpdateShiftTable(source, newone);
        }
    }
}
