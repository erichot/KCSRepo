using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class EmployeeJobCode : DatabaseObject
    {
        [Required]
        public byte TranType { get; set; }
        public string JobCode { get; set; }
        [Required]
        public string JobName { get; set; }
        public string Remark { get; set; }
        public string ListField { get; set; }

        public EmployeeJobCode()
        {
            TranType = 1;
            JobCode = "";
            JobName = "";
            Remark = "";
        }
    }
}
