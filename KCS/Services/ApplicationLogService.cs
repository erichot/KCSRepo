using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using KCS.Models;

namespace KCS.Services
{
    public class ApplicationLogService
    {
        const char spearComma = ',';
        private string logFileName = "KCS_App_Log.txt";
        private string logPath = System.Windows.Forms.Application.StartupPath;
        


        public void WriteLog(ApplicationLogEntity _applicationLog)
        {
            return;

            var logFullPathFile = Path.Combine(logPath, logFileName);

            var logTextLine = _applicationLog.ProjectSourceNo.ToString()
               + spearComma
               + _applicationLog.ClassID
               + spearComma
               + _applicationLog.ProcedureID
               + spearComma
               + _applicationLog.ProcedureDetail
               + spearComma
               + _applicationLog.ExceptionHResult
               + spearComma
               + _applicationLog.ExceptionMessage
               + spearComma
               + _applicationLog.IsNotException
               + spearComma
               + _applicationLog.CreatedDate.ToShortDateString() + _applicationLog.CreatedDate.ToLongTimeString()
               ;


            using (StreamWriter outputFile = new StreamWriter(logFullPathFile, true))
            {
                outputFile.WriteLine(logTextLine);
                outputFile.Close();
            }

            try
            {
                
            }
            catch (Exception)
            {

            }
            

        }
    }
}
