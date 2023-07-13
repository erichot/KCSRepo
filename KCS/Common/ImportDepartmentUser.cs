using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Common
{
    public class ImportDepartmentUser
    {
        [CsvColumn(Name = "UserID", FieldIndex = 0, CanBeNull = false)]
        public string UserID;
        [CsvColumn(Name = "UserName", FieldIndex = 1, CanBeNull = false)]
        public string UserName;
        [CsvColumn(Name = "DepartmentID", FieldIndex = 2, CanBeNull = true)]
        public string DepartmentID;
        [CsvColumn(Name = "DepartmentName", FieldIndex = 3, CanBeNull = true)]
        public string DepartmentName;
        [CsvColumn(Name = "CardID", FieldIndex = 4, CanBeNull = false)]
        public string CardID;
        [CsvColumn(Name = "ValidDate", FieldIndex = 5, CanBeNull = true)]
        public string ValidDate;
        [CsvColumn(Name = "AllowTimeStartHour", FieldIndex = 6, CanBeNull = true)]
        public string AllowTimeStartHour;
        [CsvColumn(Name = "AllowTimeStartMinute", FieldIndex = 7, CanBeNull = true)]
        public string AllowTimeStartMinute;
        [CsvColumn(Name = "AllowTimeEndHour", FieldIndex = 8, CanBeNull = true)]
        public string AllowTimeEndHour;
        [CsvColumn(Name = "AllowTimeEndMinute", FieldIndex = 9, CanBeNull = true)]
        public string AllowTimeEndMinute;
        [CsvColumn(Name = "Email", FieldIndex = 10, CanBeNull = true)]
        public string Email;
        [CsvColumn(Name = "PhoneMobile", FieldIndex = 11, CanBeNull = true)]
        public string PhoneMobile;
    }
}
