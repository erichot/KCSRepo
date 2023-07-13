using KCS.Common.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace KCS.Models
{
    class DepartmentListSource
    {
        static public IList<DepartmentList> GetDepartmentListField()
        {
            DataTable dt = KCSDatabaseHelper.Instance.GetDepartmentListField();
            return KCS.Common.Utils.ModelConvertHelper<DepartmentList>.ConvertToModel(dt);

        }
    }
}
