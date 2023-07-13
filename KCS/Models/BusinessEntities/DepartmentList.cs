using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    public class DepartmentList : DatabaseObject
    {
        [Key]
        public string DepartmentID { get; set; }
        public string ListField { get; set; }
    }
}
