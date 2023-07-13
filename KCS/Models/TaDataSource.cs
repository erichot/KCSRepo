using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCS.Common.DAL;

namespace KCS.Models
{
    static class TaDataSource
    {
        //
        static public IList<CalendarSettings> GetCalendarSettingsList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetCalendarSettingsList();
            return KCS.Common.Utils.ModelConvertHelper<CalendarSettings>.ConvertToModel(dt);
        }
        static public IList<TaLeaveType> GetLeaveTypeList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetLeaveTypeList();
            return KCS.Common.Utils.ModelConvertHelper<TaLeaveType>.ConvertToModel(dt);
            
        }
        static public bool DeleteLeaveItemDetails(string leaveNum)
        {
            return KCSDatabaseHelper.Instance.DeleteLeaveItemDetails(leaveNum);
        }
        static public int CheckLeaveItemDetails(string leaveNum)
        {
            return KCSDatabaseHelper.Instance.CheckLeaveItemDetails(leaveNum);
        }
        static public int UpdateLeaveDetail(PerLeaveItemDetail leavItemDetails)
        {
            return KCSDatabaseHelper.Instance.UpdateLeaveDetail(leavItemDetails);
        }
        static public int InsertLeaveItemDetials(PerLeaveItemDetail leavItemDetails)
        {
            return KCSDatabaseHelper.Instance.InsertLeaveItemDetails(leavItemDetails);
        }
        static public IList<PerLeaveItemDetail> GetLeaveItemDetailsList(string leaveNum)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetLeaveItemDetailsList(leaveNum);
            return KCS.Common.Utils.ModelConvertHelper<PerLeaveItemDetail>.ConvertToModel(dt);
        }
        static public bool DeleteLeaveItem(string leaveNum)
        {
            return KCSDatabaseHelper.Instance.DeleteLeaveItem(leaveNum);
        }
        static public int ConfirmLeaveItem(PerLeaveItem leavItem)
        {
            return KCSDatabaseHelper.Instance.ConfirmLeaveItem(leavItem);
        }
        static public int CancelLeaveItem(string leavNum)
        {
            return KCSDatabaseHelper.Instance.CancelLeaveItem(leavNum);
        }
        static public int InsertLeaveItem(PerLeaveItem leavItem)
        {
            return  KCSDatabaseHelper.Instance.InsertLeaveItem(leavItem);
        }
        static public IList<PerShiftTableBase> CheckPerCheckExistOrNot(string empCode, string dateStart,string dateEnd)
        {
            DataTable dt = KCSDatabaseHelper.Instance.CheckPerCheckExistOrNot(empCode, dateStart, dateEnd);
            return KCS.Common.Utils.ModelConvertHelper<PerShiftTableBase>.ConvertToModel(dt);
        }
        static public DataTable GetLeaveItems()
        {
            return KCSDatabaseHelper.Instance.GetLeaveItems();
        }
        static public DataTable GetLeaveItemDetails()
        {
            return KCSDatabaseHelper.Instance.GetLeaveItemDetails();
        }
        static public string GetLeavNum(int year, int month)
        {
            string strLeaveNum = KCSDatabaseHelper.Instance.GetLeavNum(year, month);
            if (string.IsNullOrEmpty(strLeaveNum))
            {
                strLeaveNum = string.Format("LE{0}{1}000001", string.Format("{0:D2}", (year % 100)), string.Format("{0:D2}", month));
            }
            else
            {
                string strNum = strLeaveNum.Substring(strLeaveNum.Length-6,6);
                int leaveNum = Convert.ToInt32(strNum);
                leaveNum++;
                strLeaveNum = strLeaveNum.Substring(0, strLeaveNum.Length - 6);
                strLeaveNum += string.Format("{0:D6}", leaveNum);
            }
            return strLeaveNum;
        }
        //出勤报表
        static public IList<AttendanceReportSimplified> GetMonthlyAttendanceReportSimplified(string startDate, string endDate, bool byTransType, IEnumerable<EmployeeBrief> employeesObject)
        {
            IList<AttendanceReportSimplified> ts = new List<AttendanceReportSimplified>();
            DataTable dt = KCSDatabaseHelper.Instance.GetMonthlyAttendanceReportSimplified(startDate, endDate, byTransType, employeesObject);
            int rowsCout = 0;
           
            int employeeCount = 0;
            string oldCardId="";
            int GoupId = 1;
            int CheckDay = 0;
            foreach (DataRow dr in dt.Rows)
            {
                 
                string valueCardId = dr["CardID"].ToString();

                if (valueCardId != oldCardId)
                {
                    if (employeeCount >= 4)
                    {
                        employeeCount = 0;
                        GoupId++;
                    }
                    oldCardId = valueCardId;
                    employeeCount++;
                    if (employeeCount == 1)
                    {
                        rowsCout += CheckDay;
                    }
                }
                CheckDay = Convert.ToInt32(dr["CheckDay"]);
                if (employeeCount == 1)
                {
                    AttendanceReportSimplified t = new AttendanceReportSimplified();
                    t.CheckDateString = dr["CheckDateString"].ToString();
                    t.EMP_CODE = dr["EMP_CODE"].ToString();
                    t.CheckDay = CheckDay;
                    t.UserName1 = dr["UserName"].ToString();
                    t.OnDutyTime1 = dr["OnDutyTime"].ToString();
                    t.OffDutyTime1 = dr["OffDutyTime"].ToString();
                    t.OverTime1 = dr["OverTime"].ToString();
                    t.GroupId = GoupId;
                    ts.Add(t);
                    
                }
                else if (employeeCount == 2)
                {
                    ts[rowsCout+CheckDay-1].UserName2 =dr["UserName"].ToString();
                    ts[rowsCout + CheckDay - 1].OnDutyTime2 = dr["OnDutyTime"].ToString();
                    ts[rowsCout + CheckDay - 1].OffDutyTime2 = dr["OffDutyTime"].ToString();
                    ts[rowsCout + CheckDay - 1].OverTime2 = dr["OverTime"].ToString();
                }
                else if (employeeCount == 3)
                {
                    ts[rowsCout + CheckDay - 1].UserName3 = dr["UserName"].ToString();
                    ts[rowsCout + CheckDay - 1].OnDutyTime3 = dr["OnDutyTime"].ToString();
                    ts[rowsCout + CheckDay - 1].OffDutyTime3 = dr["OffDutyTime"].ToString();
                    ts[rowsCout + CheckDay - 1].OverTime3 = dr["OverTime"].ToString();
                }
                else if (employeeCount == 4)
                {
                    ts[rowsCout + CheckDay - 1].UserName4 = dr["UserName"].ToString();
                    ts[rowsCout + CheckDay - 1].OnDutyTime4 = dr["OnDutyTime"].ToString();
                    ts[rowsCout + CheckDay - 1].OffDutyTime4 = dr["OffDutyTime"].ToString();
                    ts[rowsCout + CheckDay - 1].OverTime4 = dr["OverTime"].ToString();

                    
                    
                }
                
                
            
                
            }
            return ts;
        }
        static public DataSet GetMonthlyAttendanceReportDetails(string startDate, string endDate, bool byTransType, IEnumerable<EmployeeBrief> employeesObject)
        {
           // 2018 4 8 1.0.1.3修改報表數據源，提升報表生成速度 去掉轉換成IList
            DataTable dt = KCSDatabaseHelper.Instance.GetMonthlyAttendanceReportDetails(startDate, endDate, byTransType, employeesObject);
            return dt.DataSet;// KCS.Common.Utils.ModelConvertHelper<AttendanceReportDetails>.ConvertToModel(dt);
        }


        /* Add: 2023/01/22
         * By:  Eric
         * Ver: 1.1.5.7
         */       
        static public DataSet GetFlexShiftReportDetails(DateTime _startDate, DateTime _endDate, IEnumerable<EmployeeBrief> _employeesObject)
        {
            var result = new DataSet();

            KCSDatabaseHelper.Instance.WriteWorkShiftNo(_startDate, _endDate, _employeesObject);

            // Modified: 2023/03/16 	1.1.5.8     跑彈性工時報表時雖僅選擇一個部門結果卻會顯示所有部門數據.
            var userSIDEnumer = _employeesObject.Select(x => x.UserSID).Distinct();
            DataTable dt = KCSDatabaseHelper.Instance.GetFlexShiftReportDetails(_startDate, _endDate, userSIDEnumer);
            result.Tables.Add(dt);
            return result;
        }


        static public IList<AnnulaCalendar> GetAnnualCalendarListByMonth(int year,int month_start,int month_end)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetAnnualCalendarListByMonth(year, month_start, month_end);
            return KCS.Common.Utils.ModelConvertHelper<AnnulaCalendar>.ConvertToModel(dt);
        }
        static public IList<AnnulaCalendar> GetAnnualCalendarList(int year)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetAnnualCalendarList(year);
            return KCS.Common.Utils.ModelConvertHelper<AnnulaCalendar>.ConvertToModel(dt);
        }
        //出勤历
        static public int CreatePersonalShiftTable(int year,string userid,string cardid,string turnwork_grp)
        {
            return KCSDatabaseHelper.Instance.CreatePersonalShiftTable(year, userid, cardid, turnwork_grp,CredentialsSource.GetLoginSupervisorMsg());
        }
        static public int UpdateWorkListShiftCode(string date,string shiftType,string shifCode)
        {
            return KCSDatabaseHelper.Instance.UpdateWorkListShiftCode(date, shiftType,shifCode, CredentialsSource.GetLoginSupervisorMsg());
        }
        static public int UpdateWorkListHolidayType(string date, string shiftType, int holiType)
        {
            return KCSDatabaseHelper.Instance.UpdateWorkListHolidayType(date,shiftType, holiType, CredentialsSource.GetLoginSupervisorMsg());
        }
        static public IList<WorkList> GetChkWorkList(int year)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetChkWorkList(year);
            return KCS.Common.Utils.ModelConvertHelper<WorkList>.ConvertToModel(dt);
        }
        //个人出勤历
        static public IList<PerShiftTable> GetPerShiftTable(int year)
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetPerShiftTable(year);
            return KCS.Common.Utils.ModelConvertHelper<PerShiftTable>.ConvertToModel(dt);
        }
        static public int UpdatePersonShiftTableShiftCode(string userid,string date,string shiftcode)
        {
            return KCSDatabaseHelper.Instance.UpdatePersonShiftTableShiftCode(userid, date, shiftcode, CredentialsSource.GetLoginSupervisorMsg());
        }
        static public int UpdatePersonShiftTableHolidayType(string userid, string date, int holiType)
        {
            return KCSDatabaseHelper.Instance.UpdatePersonShiftTableHolidayType(userid, date, holiType, CredentialsSource.GetLoginSupervisorMsg());
        }
        
        static public int CreateShiftTableByDoList(int year,string shiftCategory)
        {
            return KCSDatabaseHelper.Instance.CreateShiftTableByDoList(year, shiftCategory, CredentialsSource.GetLoginSupervisorMsg());
        }
        static public int CreateShiftTableWithoutDoList(int year, string shiftCategory)
        {
            return KCSDatabaseHelper.Instance.CreateShiftTableWithoutDoList(year, shiftCategory, CredentialsSource.GetLoginSupervisorMsg());
        }
        static public int HasAnnualCalendarOrNot(int year)
        {
            return KCSDatabaseHelper.Instance.HasAnnualCalendarOrNot(year);
        }
        static public bool UpdateAnnualCalendarSet(AnnulaCalendar calendar)
        {
            return KCSDatabaseHelper.Instance.UpdateAnnualCalendarSet(calendar);
        }
        static public bool AddAnnualCalendar(AnnulaCalendar calendar)
        {
            return KCSDatabaseHelper.Instance.AddAnnualCalendar(calendar);
        }
        static public bool DeleteAnnualCalendar(int year)
        {
            return KCSDatabaseHelper.Instance.DeleteAnnualCalendar(year);
        }
        static public bool AddLeaveType(TaLeaveType leaveType)
        {
            return KCSDatabaseHelper.Instance.AddLeaveType(leaveType);
        }
        static public bool DeleteLeaveType(TaLeaveType leaveType)
        {
            return KCSDatabaseHelper.Instance.DeleteLeaveType(leaveType);
        }
        static public IList<VocationSetting> GetVacationSettingList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetVacationSettingList();
            return KCS.Common.Utils.ModelConvertHelper<VocationSetting>.ConvertToModel(dt);

        }
        static public IList<TaHolidays> GetTaHolidaySettingList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetTaHolidaySettingList();
            return KCS.Common.Utils.ModelConvertHelper<TaHolidays>.ConvertToModel(dt);
        }
        static public bool DeleteTaHolidaySetting(string Holiday)
        {
            return KCSDatabaseHelper.Instance.DeleteTaHolidaySetting(Holiday);
        }
        static public bool UpdateTaHolidaySetting(TaHolidays holidaySet,string holiday)
        {
            return KCSDatabaseHelper.Instance.UpdateTaHolidaySetting(holidaySet,holiday );
        }
        static public bool DeleteVocationSetting(int LeaveApplicationHeadSID)
        {
            return KCSDatabaseHelper.Instance.DeleteVocationSetting(LeaveApplicationHeadSID);
        }
        static public int InsertVocationSetting(Vocation vocation)
        {
            return KCSDatabaseHelper.Instance.InsertVocationSetting(vocation);
        }
        static public int UpdateVocationSetting(Vocation vocation)
        {
            return KCSDatabaseHelper.Instance.UpdateVocationSetting(vocation);
        }
    }
}
