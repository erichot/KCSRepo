using KCS.Common.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    class DepartmentSource
    {
        static public IList<Department> GetDepartmentList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetDepartmentList("All");
            return KCS.Common.Utils.ModelConvertHelper<Department>.ConvertToModel(dt);
           
        }
        static public bool DeleteDepartment(Department department)
        {
            return KCSDatabaseHelper.Instance.DeleteDepartment(department);
        }
        static public bool UpdateDepartment(Department department)
        {
            return KCSDatabaseHelper.Instance.UpdateDepartment(department);
        }
        static public bool NewDepartment(Department department)
        {
            return KCSDatabaseHelper.Instance.InsertDepartment(department);
        }
    }
}
