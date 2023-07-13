using KCS.Common.DAL;
using KCS.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class EmployeeAuthority
    {


        static string ReadOnly = (string)LanguageResource.GetDisplayString("AuthorityReadOnly");
        static string Super = (string)LanguageResource.GetDisplayString("AuthorityAdmin");

        public  int this[string name]
        {
            get
            {
                if (name.Equals(ReadOnly))
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string this[int iReadOnly]
        {
            get
            {
                if (iReadOnly == 1)
                {
                    return ReadOnly;
                }
                else
                {
                    return Super;
                }
            }
        }
    }
}
