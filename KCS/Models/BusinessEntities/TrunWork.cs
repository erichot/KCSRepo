using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCS.Models
{
    public class TrunWork : TrunWorkBase
    {
       
        public string CLASS_CODE1 { get; set; }
        public string CLASS_CODE2 { get; set; }
        public string CLASS_CODE3 { get; set; }
        public string CLASS_CODE4 { get; set; }
        public string CLASS_CODE5 { get; set; }
        public string CLASS_CODE6 { get; set; }
        public string CLASS_CODE7 { get; set; }
        public string CREATE_NAME { get; set; }
        public DateTime CREATE_TIME { get; set; }
        public string BUILD_NAME { get; set; }
        public DateTime BUILD_TIME { get; set; }

        public TrunWork()
        {
            this.TURNWORK_GRP = "";
            this.TURNWORK_DESC = "";
            this.CLASS_CODE1 = "";
            this.CLASS_CODE2 = "";
            this.CLASS_CODE3 = "";
            this.CLASS_CODE4 = "";
            this.CLASS_CODE5 = "";
            this.CLASS_CODE6 = "";
            this.CLASS_CODE7 = "";
            this.CREATE_NAME = "";
            this.CREATE_TIME = DateTime.Now;
            this.BUILD_NAME = "";
            this.BUILD_TIME = DateTime.Now;

        }
        public TrunWork(TrunWork trunWork)
        {
            this.TURNWORK_GRP = trunWork.TURNWORK_GRP;
            this.TURNWORK_DESC = trunWork.TURNWORK_DESC;
            this.CLASS_CODE1 = trunWork.CLASS_CODE1;
            this.CLASS_CODE2 = trunWork.CLASS_CODE2;
            this.CLASS_CODE3 = trunWork.CLASS_CODE3;
            this.CLASS_CODE4 = trunWork.CLASS_CODE4;
            this.CLASS_CODE5 = trunWork.CLASS_CODE5;
            this.CLASS_CODE6 = trunWork.CLASS_CODE6;
            this.CLASS_CODE7 = trunWork.CLASS_CODE7;
            this.CREATE_NAME = trunWork.CREATE_NAME;
            this.CREATE_TIME = trunWork.CREATE_TIME;
            this.BUILD_NAME = trunWork.BUILD_NAME;
            this.BUILD_TIME = trunWork.BUILD_TIME;

        }
    }
}
