using KCS.Common.DAL;
using KCS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    static class EmployeesTypeDataSource
    {
        static public IList<EmployeesType> GetEmployeesTypeList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetEmployeesTypeList();
            return KCS.Common.Utils.ModelConvertHelper<EmployeesType>.ConvertToModel(dt);
        }
        static public IList<EmployeesTypeFiled> GetEmployeesTypeInfoList()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetEmployeesTypeInfoList();
            return KCS.Common.Utils.ModelConvertHelper<EmployeesTypeFiled>.ConvertToModel(dt);
        }
        static public bool UpdateEmployeesType(EmployeesType emptype)
        {
            return KCSDatabaseHelper.Instance.UpdateEmployeesType(emptype);
        }

        static public bool NewEmployeesType(EmployeesType emptype)
        {

            return KCSDatabaseHelper.Instance.InsertEmployeesType(emptype);
        }
        static public bool DeleteEmployeesType(EmployeesType emptype)
        {
            return KCSDatabaseHelper.Instance.DeleteEmployeesType(emptype);
        }
    }
}
