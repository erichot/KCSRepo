using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class ApplicationLogEntity
    {
        
        public int LogNo { get; set; }


        public byte ProjectSourceNo { get; set; } = 1;



       
        public string ClassID { get; set; } = string.Empty;



        public string ProcedureID { get; set; } = string.Empty;



        public int UserNo { get; set; }


       
        public int LoginActionNo { get; set; }



        public string ProcedureDetail { get; set; } = string.Empty;


        
        public int ExceptionHResult { get; set; }


     
        public string ExceptionMessage { get; set; } = string.Empty;


        public bool IsNotException { get; set; }


        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
