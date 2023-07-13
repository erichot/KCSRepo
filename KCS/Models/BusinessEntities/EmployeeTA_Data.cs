using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models.BusinessEntities
{
    public class EmployeeTA_Data
    {
        public string CurrentDate { get; set;}
        public int   TransCountInDate { get; set; }
        public Transactions maxTransaction { get; set; }

        public EmployeeTA_Data(string date, Transactions max)
        {
            this.CurrentDate = date;
            this.maxTransaction = max;
            this.TransCountInDate = 0;
        }
        

    }
}
