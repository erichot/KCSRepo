using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    class EmployeesTypeFiled : DatabaseObject
    {
        [Key, Required]
        public string EmployeeTypeID { get; set; }
        public string ListFiled { get; set; }
    }
}
