using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public enum ReportTypeValue
    {
        ReportTotal,
        ReportDetail,
        ReportSubTotalByDay
    }
    public enum QueryCondionValue
    {
        QueryByWeek,
        QueryByMonth,
        QueryByDate,
        QueryByAllTime
    }
    public enum QueryFilterValue
    {
        FilterAll,
        FilterAbsent,
        FilterPrsent
    }
    public class ReportParaSet
    {
        public ReportTypeValue ReportType { get; set; }
        public QueryCondionValue QueryConditon { get; set; }
        public int QueryByWeekType { get; set; }
        public int QueryByMonthType { get; set; }
        public DateTime QueryByDateStart { get; set; }
        public DateTime QueryByDateEnd { get; set; }
        public bool bIncludeJobCode { get; set; }
        public byte JobCodeValue { get; set; }
        public QueryFilterValue FilterType { get; set; }
        public bool bGroupByUserThenSum { get; set; }
        public bool bEnableSubtotal { get; set; }
        public bool bDisplayLeaveDescription { get; set; }
    }
}
