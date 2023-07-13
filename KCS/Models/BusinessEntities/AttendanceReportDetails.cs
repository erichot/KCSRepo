using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    /* 
     * 
     * 
select * from (select UA.CHK_DATE,UA.LIST_GRP,UA.CardID,DepartmentName,UA.EMP_CODE,UserName,convert(char(7),UA.CHK_DATE,121) AS CheckDate, day(UA.CHK_DATE) AS CheckDay,convert(char(5),UI.TranDateTime,108) AS OnDutyTime,convert(char(5),[RELAX_TIME1],108) as [RELAX_TIME1],convert(char(5),[RELAX_TIME2],108) as [RELAX_TIME2],convert(char(5),UA.WORK_TIME_LATE,108) AS WORK_TIME_LATE,convert(char(5),UA.WORK_TIME_OVERTIME,108) AS WORK_TIME_OVERTIME,convert(char(5),UO.TranDateTime,108) AS OffDutyTime,UL.LEAVE_CODE,
UL.LEAVE_DESC,UL.LEAVE_TIME1,UL.LEAVE_TIME2,UL.SUM_TIME,
-- 迟到时间
case  when UL.LEAVE_CODE is  null then
case 
when UI.TranDateTime is null OR UA.WORK_TIME_START is null then --上班时间 和 工作开始时间空,无法计算
null 
else --上班时间 和 工作开始时间不为空
case --
when DATEDIFF(mi,UA.WORK_TIME_START, convert(char(5),UI.TranDateTime,108))>0 then --比设定上班时间晚，迟到
case 
when UA.WORK_TIME_LATE is not null and DATEDIFF(mi,UA.WORK_TIME_LATE, convert(char(5),UI.TranDateTime,108))>0 then --旷职时间设置不为空，并且刷卡时间迟于旷职时间
null --算旷职，不算迟到
else  
DATEDIFF(mi,UA.WORK_TIME_START, convert(char(5),UI.TranDateTime,108))  --迟到时间
end --迟到判断结束
else --刷卡时间早于设定上班时间
null 
end --比设定上班时间晚 
end --上班时间 和 工作开始时间不为空 结束
else
null
end
AS LateMins,
-- 早退时间
case  when UL.LEAVE_CODE is  null then
case
when UO.TranDateTime is null OR UA.WORK_TIME_END is null then --下班打卡时间或工作结束时间为空，无法计算
null
else
case when DATEDIFF(mi,UA.WORK_TIME_END, convert(char(5),UO.TranDateTime,108))>=0 then
null
else
DATEDIFF(mi, convert(char(5),UO.TranDateTime,108),UA.WORK_TIME_END)
end
end 
else
null
end
AS LeaveEarlyMins,
--出勤时数
case when UI.TranDateTime is null OR UO.TranDateTime is null then 
null
else
case when DATEDIFF(mi, UI.TranDateTime,UO.TranDateTime) >= UA.TURN_TIME then
cast(UA.TURN_TIME as float) /60 
else
case when UA.RELAX_TIME1 is null OR UA.RELAX_TIME2 is null then
cast(DATEDIFF(mi, UI.TranDateTime,UO.TranDateTime)/30.0 as int)*0.5
else
case when DATEDIFF(mi,convert(char(5),UI.TranDateTime,108),UA.RELAX_TIME1)>=0 AND DATEDIFF(mi,UA.RELAX_TIME2, convert(char(5),UO.TranDateTime,108))>=0 then
cast((DATEDIFF(mi, UI.TranDateTime,UO.TranDateTime) - ISNULL(DATEDIFF(mi, UA.[RELAX_TIME1],UA.[RELAX_TIME2]),0))/30.0 as int)*0.5
else
cast(DATEDIFF(mi, UI.TranDateTime,UO.TranDateTime)/30.0 as int)*0.5
end
end 
end
end AS TurnTime,
--旷职时间 AbsentTime
case  when UL.LEAVE_CODE is null then
case when UA.WORK_TIME_LATE is null OR UI.TranDateTime is null OR UA.WORK_TIME_START is null then
null
else
case when DATEDIFF(mi,UA.WORK_TIME_LATE, convert(char(5),UI.TranDateTime,108))>0 then
cast((DATEDIFF(mi,UA.WORK_TIME_START, convert(char(5),UI.TranDateTime,108))+29)/30.0 as int) *0.5
else
null
end
end 
else
null
end
AS AbsentHours,
--加班时间
case  when UL.LEAVE_CODE is null then
case when UA.WORK_TIME_OVERTIME is null or UO.TranDateTime is null then
null
else
case when DATEDIFF(mi,UA.WORK_TIME_OVERTIME, convert(char(5),UO.TranDateTime,108))>0 then 
case when UA.TURN_OVERTIME = 0.5 then
cast(DATEDIFF(mi,  UA.WORK_TIME_OVERTIME,convert(char(5),UO.TranDateTime,108))/30.0 as int)*0.5
else
DATEDIFF(hh, UA.WORK_TIME_OVERTIME,convert(char(5),UO.TranDateTime,108))
end 
else
null
end
end 
else
null
end
AS OverTime
 from UPER_CHECK_SECTION('2017-04-01','2017-04-30') AS UA
Left join (select CardId,min(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS('2017-04-01','2017-04-30') group by CardId,convert(varchar(10),TranDateTime,120))
AS UI ON UA.CardID=UI.CardID AND UA.CHK_DATE=UI.CHK_DATE
Left join (select CardId,max(TranDateTime) AS TranDateTime,convert(varchar(10),TranDateTime,120) AS CHK_DATE from UVALID_TRANSACTIONS('2017-04-01','2017-04-30') group by CardId,convert(varchar(10),TranDateTime,120))
AS UO ON UA.CardID=UO.CardID AND UA.CHK_DATE=UO.CHK_DATE
Left Join (select LEAVE_DATE,EMP_CODE,LEAVE_CODE,LEAVE_DESC,LEAVE_TIME1,LEAVE_TIME2,SUM_TIME from  UPER_LEAVE_ITEMS ('2017-04-01','2017-04-30')) AS UL
ON UA.EMP_CODE = UL.EMP_CODE AND UA.CHK_DATE=UL.LEAVE_DATE) AS DD where DD.EMP_CODE='0006' order by DD.CheckDay ASC







     * 
     * 
     * 
     * 最wan
     select CardId,max(TranDateTime) from UVALID_TRANSACTIONS('2017-04-01','2017-04-30') group by CardId,convert(varchar(10),TranDateTime,120)
     * 
     * select [DepartmentName],[CheckYear],[CHK_DATE],[EMP_CODE],[UserName],[LIST_GRP],[CardID],[WORK_TIME_START],[WORK_TIME_END],[WORK_TIME_LATE],[WORK_TIME_OVERTIME],[TURN_OVERTIME]
from [VPER_CHK]
     * select [LEAVE_DATE],B.[LEAVE_CODE],C.[LEAVE_DESC],A.[SUM_TIME],B.EMP_CODE from [PER_LEAVE_D] AS A left join [PER_LEAVE] AS B ON A.NUM=B.NUM
        Left Join [CHK_LEAVE] AS C ON B.LEAVE_CODE = C.LEAVE_CODE
     * 
     * --in trans
SELECT [CardID], TranDateTime FROM [OR_Transactions]  WHERE (((IsByTranType = 1) AND (TranType = 0 OR TranType = 161 OR TranType = 16  OR TranType = 96))    OR ((IsByTranType = 0) AND (DataType= 1 )) ) ORDER BY  TranDateTime

--out trans
SELECT [CardID], TranDateTime FROM [OR_Transactions]  WHERE (((IsByTranType = 1) AND (TranType = 1 OR TranType = 162 OR TranType = 17  OR TranType = 97))    OR ((IsByTranType = 0) AND (DataType = 2)) ) ORDER BY  TranDateTime 
     * 考勤记录
     * SELECT TranSID,  TranDateTime, (CASE WHEN IsByTranType = 1 THEN TranType ELSE DataType END) AS TranType  FROM [OR_Transactions]  WHERE (((IsByTranType = 1) AND (TranType BETWEEN 1 AND 2 OR TranType BETWEEN 161 AND 162))    OR ((IsByTranType = 0) AND (DataType BETWEEN 1 AND 2)) ) ORDER BY  TranDateTime 
     * 
     * 若報表的查詢型態是自動判斷：系統抓取當日最大 & 最小
若報表的查詢型態是依據TranType：系統依據TranType判斷，並抓取當日最大 & 最小
     * */
    public class AttendanceReportDetails
    {

        public DateTime CHK_DATE { get; set; } //日期
        public int LIST_GRP { get; set; }
        public string DepartmentName { get; set; }//部门
        public string EMP_CODE { get; set; } //员工编号
        public string UserName { get; set; }
        public int CheckDay { get; set; }
        public string OnDutyTime { get; set; }

        public string RELAX_TIME1 { get; set; }
        public string RELAX_TIME2 { get; set; }
        public string OffDutyTime { get; set; }
        public string LEAVE_CODE { get; set; }
        public string LEAVE_DESC { get; set; }
        public string LeaveTime { get; set; }

        public string LateMins { get; set; } //迟到
        public string LeaveEarlyMins { get; set; } //早退
        public string TurnTime { get; set; }  //出勤时数
        public string AbsentHours { get; set; }//旷职时数
        public string OverTime { get; set; }//加班时间


        public string CheckDateString
        {
            get
            {
                return CHK_DATE.ToShortDateString();
            }
        }
        public string LIST_GRPString
        {
            get;
            set;
            /*
            get
            {
                if (LIST_GRP == 1)
                {
                    return KCS.Common.Utils.LanguageResource.GetDisplayString("RestDayText");
                }
                else if (LIST_GRP == 3)
                {
                    return KCS.Common.Utils.LanguageResource.GetDisplayString("LegalHolidayText");
                }
                else
                {
                    return "";
                }
                
            }
             * 
             * */

        }
    }
}
