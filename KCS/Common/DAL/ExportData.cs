using KCS.Models;
using KCS.Sync;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.POIFS.FileSystem;

namespace KCS.Common.DAL
{
    class ExportData
    {
        private string UserName;
        private string UserID;          
        private string JobCode;
        private string CardID;
        private string SlaveID;
        private string TransDateTime;
        private string TransDate;
        private string TransTime;
        private string CustomText1;
        private string DeviceName;
        private string CustomText2;
        private string CustomText3;

        /*
        Add:        2022/12/19
        By:         Eric
        Subject:    adding TranType from Export data (The field name must match the name from the ExportFormate)
        Note:Hi Eric , Jeff         KCS 我发现一个问题
            如果我将Trantype加入输出格式、Txt file是不会输出任何东西
            Jeff 、 您那边可以帮我测试么？
            我这里测了很多次、如果将trantype拿走、就可以看见data了
        */
        private byte TranType;





        public void ManulExportDataToTxt(Transactions transaction, string fileName)
        {
            IWorkbook workbook = null;
            FileStream fs = null;
            IRow row = null;
            ISheet sheet = null;
            ICell cell = null;

            UserName = transaction.UserName;
            UserID = transaction.UserId;
            CardID = transaction.TransactionCardId;
            CardID = CardID.Trim();
            CardID = CardID.Trim('\0');
            CardID = CardID.Substring(10 - SystemConfigure.ExportCardIdLen);

            string extension = Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(SystemConfigure.ExportFilePath))
            {
                SystemConfigure.ExportFilePath = "ExportDatas";
            }
            CustomText1 = SystemConfigure.ExportFixedText;
            CustomText2 = SystemConfigure.ExportFixedText2;
            CustomText3 = SystemConfigure.ExportFixedText3;
            // string StrExportPath = SystemConfigure.ExportFilePath;
            // string StrExportFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + ".txt";
            //
            // if (SystemConfigure.ExportFileByMonth == 1)
            //{
            //  StrExportFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("D2") + ".txt";
            //}


            // Add: 2022/12/19  adding TranType from Export data
            TranType = transaction.TransactionType;


            string StrDateSep;
            if (SystemConfigure.ExportDateSeperator == 0)
            {
                StrDateSep = "/";
            }
            else if (SystemConfigure.ExportDateSeperator == 1)
            {
                StrDateSep = "-";
            }
            else
            {
                StrDateSep = "";
            }

            DateTime RecordDate = Convert.ToDateTime(transaction.TransactionDateTime);
            int TransDateYear = RecordDate.Year;
            if (SystemConfigure.ExportDateLen == 1)
            {
                TransDateYear = TransDateYear % 100;
            }
            if (SystemConfigure.ExportDateFormate == 0) // y/m/d
            {
                TransDate = TransDateYear.ToString("D2") + StrDateSep +
                    RecordDate.Month.ToString("D2") + StrDateSep +
                    RecordDate.Day.ToString("D2");

                TransDateTime = TransDate + " " + RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2") + ":" + RecordDate.Second.ToString("D2");
            }
            else if (SystemConfigure.ExportDateFormate == 1) // m/d/y
            {
                TransDate =
                    RecordDate.Month.ToString("D2") + StrDateSep +
                    RecordDate.Day.ToString("D2") + StrDateSep +
                    TransDateYear.ToString("D2");
                TransDateTime = TransDate + " " + RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2") + ":" + RecordDate.Second.ToString("D2");
            }
            else
            {
                /*  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                 Modified:    2022/12/09
                 TxtExportSetting set to Day/Month/Year not work
                TransDate =
                    RecordDate.Month.ToString("D2") + StrDateSep +
                    RecordDate.Day.ToString("D2") + StrDateSep +
                    TransDateYear.ToString("D2");
                */
                TransDate =
                    RecordDate.Day.ToString("D2") + StrDateSep +
                    RecordDate.Month.ToString("D2") + StrDateSep +
                    TransDateYear.ToString("D2");
                // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                TransDateTime = TransDate + " " + RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2") + ":" + RecordDate.Second.ToString("D2");
            }
            //时间
            if (SystemConfigure.ExportTimeFormate == 0)
            {
                TransTime = RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2") + ":" + RecordDate.Second.ToString("D2");
            }
            else if (SystemConfigure.ExportTimeFormate == 1)
            {
                TransTime = RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2");
            }
            else if (SystemConfigure.ExportTimeFormate == 2)
            {
                TransTime = RecordDate.Hour.ToString("D2") + RecordDate.Minute.ToString("D2") + RecordDate.Second.ToString("D2");
            }
            else
            {
                TransTime = RecordDate.Hour.ToString("D2") + RecordDate.Minute.ToString("D2");
            }
            //TransTime += "   ";
            //Slave ID
            if (SystemConfigure.ExportSlaveIdLen == 0)
            {
                SlaveID = string.Format("{0}", transaction.SlaveId.ToString());
            }
            else
            {
                SlaveID = string.Format("{0}", transaction.SlaveId.ToString());
                SlaveID = SlaveID.PadLeft(SystemConfigure.ExportSlaveIdLen, '0');
            }
            
            //JobCode
            if (SystemConfigure.ExportJobCodeProperty == 0)
            {
                if (transaction.IsByTranType)
                {
                    if (0xA0 == (transaction.RecordType & 0xf0))
                    {
                        JobCode = transaction.RecordType.ToString();
                    }
                    else if (0xB0 == (transaction.RecordType & 0xf0))
                    {
                        JobCode = transaction.RecordType.ToString();
                    }
                    else
                    {
                        JobCode = (transaction.RecordType & 0x0f).ToString();
                    }
                }
                else
                {
                    JobCode = transaction.DataType.ToString();
                }
            }
            else
            {
                if (transaction.IsByTranType)
                {
                    if (0xA0 == (transaction.RecordType & 0xf0))
                    {
                        JobCode = SyncManage.GetJobCodeName(transaction.RecordType);
                    }
                    else if (0xB0 == (transaction.RecordType & 0xf0))
                    {
                        JobCode = SyncManage.GetJobCodeName(transaction.RecordType );
                    }
                    else
                    {
                        JobCode = SyncManage.GetJobCodeName(transaction.RecordType & 0x0f);
                    }
                }
                else
                {
                    JobCode = SyncManage.GetJobCodeName(transaction.DataType);
                }
            }
            //if (!Directory.Exists(filePath))
            //{
            //    Directory.CreateDirectory(filePath);
            //}
            DeviceName = transaction.DeviceName;
            if (extension == ".xls")
            {
                if (!File.Exists(fileName))
                {

                    try
                    {
                        
                        workbook = new HSSFWorkbook();
                        sheet = workbook.CreateSheet("Sheet0");

                        row = sheet.CreateRow(0);//excel第一行设为列头  
                        for (int c = 0; c < SystemConfigure.ExportItemsList.Count; c++)
                        {
                            cell = row.CreateCell(c);
                            cell.SetCellValue(SystemConfigure.ExportItemsList[c]);
                        }
                        row = sheet.CreateRow(1);
                        byte Source = (byte)0xf0;
                        byte bType = (byte)(transaction.TransactionType & Source);
                        if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x70 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0  || (bType == (byte)0x30 && SystemConfigure.IncludeIllegalRecords == 1))
                        //if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0)//|| bType == (byte)0xB0
                        {

                            for (int i = 0; i < SystemConfigure.ExportItemsList.Count; i++)
                            {
                                cell = row.CreateCell(i);//excel第二行开始写入数据  
                                cell.SetCellValue(this.GetType().GetField(SystemConfigure.ExportItemsList[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).GetValue(this).ToString()); 
                                
                            }

                        }
                        using (fs = File.OpenWrite(fileName))
                        {
                            workbook.Write(fs);//向打开的这个xls文件中写入数据  
                            
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {//追加
                    FileStream fsAppend = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);//读取流

                    POIFSFileSystem ps = new POIFSFileSystem(fsAppend);//需using NPOI.POIFS.FileSystem;
                    IWorkbook workbookAppend = new HSSFWorkbook(ps);
                    ISheet sheetAppend = workbookAppend.GetSheetAt(0);//获取工作表
                   // IRow row = sheet.GetRow(0); //得到表头
                    FileStream fout = new FileStream(fileName, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);//写入流
                    row = sheetAppend.CreateRow((sheetAppend.LastRowNum + 1));//在工作表中添加一行

                    
                    byte Source = (byte)0xf0;
                    byte bType = (byte)(transaction.TransactionType & Source);
                    if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x70 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0 || (bType == (byte)0x30 && SystemConfigure.IncludeIllegalRecords == 1))
                    //if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0)//|| bType == (byte)0xB0
                    {

                        for (int i = 0; i < SystemConfigure.ExportItemsList.Count; i++)
                        {
                            ICell cell1 = row.CreateCell(i);
                            
                            cell1.SetCellValue(this.GetType().GetField(SystemConfigure.ExportItemsList[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).GetValue(this).ToString());

                        }

                    }

                    

                    fout.Flush();
                    workbookAppend.Write(fout);//写入文件
                    workbookAppend = null;
                    fout.Close();

                }
                    


                return;
            }
            if (!File.Exists(fileName))
            {
              
                if (!string.IsNullOrEmpty(SystemConfigure.ExortTitleText))
                {
                    using (var sw = new StreamWriter(fileName, true))
                    {
                        sw.WriteLine(SystemConfigure.ExortTitleText);
                        sw.Close();
                    }
                }
            }
           
            using (var sw = new StreamWriter(fileName, true))
            {
                byte Source = (byte)0xf0;
                byte bType = (byte)(transaction.TransactionType & Source);
                if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x70 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0 || (bType == (byte)0x30 && SystemConfigure.IncludeIllegalRecords == 1))
                //if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0)//|| bType == (byte)0xB0
                {
                    string strRecord = "";
                    for (int i = 0; i < SystemConfigure.ExportItemsList.Count; i++)
                    {
                        strRecord += this.GetType().GetField(SystemConfigure.ExportItemsList[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).GetValue(this).ToString();
                        if (i != (SystemConfigure.ExportItemsList.Count - 1))
                        {
                            //if (SystemConfigure.ExportFileExtension == "CSV")
                            if (extension == ".csv")
                                strRecord += ",";
                            else
                                strRecord += SystemConfigure.ExportSeperator;
                        }
                    }

                    /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                    * Add:          2023/07/21
                    * Ver:         1.1.5.10
                    * Note:        
                    */
                    if (SystemConfigure.IsEnableEncryptExportData)
                    {
                        strRecord = KCS.Helpers.EncryptHelper.EncryptAES(strRecord);
                    }
                    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                    sw.WriteLine(strRecord);
                }


                sw.Close();
            }
        }
        public void ExportDataToTxt(Transactions transaction)
        {
            UserName = transaction.UserName;
            UserID = transaction.UserId;
            CardID = transaction.TransactionCardId;
            CardID = CardID.Trim();
            CardID = CardID.Trim('\0');
            if (string.IsNullOrEmpty(SystemConfigure.ExportFilePath))
            {
                SystemConfigure.ExportFilePath = "ExportDatas";
            }
            CardID = CardID.Substring(10 - SystemConfigure.ExportCardIdLen);
            CustomText1 = SystemConfigure.ExportFixedText;
            CustomText2 = SystemConfigure.ExportFixedText2;
            CustomText3 = SystemConfigure.ExportFixedText3;
            DateTime RecordDate = Convert.ToDateTime(transaction.TransactionDateTime);
            string StrExportPath = SystemConfigure.ExportFilePath;
            // string StrExportFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + ".txt";
            string extension = SystemConfigure.ExportFileExtension;

            

            // Add: 2022/12/19  adding TranType from Export data
            TranType = transaction.TransactionType;

            if (extension == "Excel")
                extension = "xls";

            string StrExportFileName = RecordDate.Year.ToString() + RecordDate.Month.ToString("D2") + RecordDate.Day.ToString("D2") + "." + extension;
            if (SystemConfigure.ExportFileByMonth == 1)
            {
                StrExportFileName = RecordDate.Year.ToString() + RecordDate.Month.ToString("D2") + "." + extension;
            }
            if (SystemConfigure.CheckExportFixedFileName == 1)
            {
                StrExportFileName = SystemConfigure.ExportFixedFileName + "." + extension;
            }
            string StrDateSep;
            if (SystemConfigure.ExportDateSeperator == 0)
            {
                StrDateSep = "/";
            }
            else if (SystemConfigure.ExportDateSeperator == 1)
            {
                StrDateSep = "-";
            }
            else
            {
                StrDateSep = "";
            }


            int TransDateYear = RecordDate.Year;
            if (SystemConfigure.ExportDateLen == 1)
            {
                TransDateYear = TransDateYear % 100;
            }
            if (SystemConfigure.ExportDateFormate == 0) // y/m/d
            {
                TransDate = TransDateYear.ToString("D2") + StrDateSep +
                    RecordDate.Month.ToString("D2") + StrDateSep +
                    RecordDate.Day.ToString("D2");

                TransDateTime = TransDate + " " + RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2") + ":" + RecordDate.Second.ToString("D2");
            }
            else if (SystemConfigure.ExportDateFormate == 1) // m/d/y
            {
                TransDate =
                    RecordDate.Month.ToString("D2") + StrDateSep +
                    RecordDate.Day.ToString("D2") + StrDateSep +
                    TransDateYear.ToString("D2");
                TransDateTime = TransDate + " " + RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2") + ":" + RecordDate.Second.ToString("D2");
            }
            else
            {
                /*  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
               Modified:    2022/12/09
               TxtExportSetting set to Day/Month/Year not work
              TransDate =
                  RecordDate.Month.ToString("D2") + StrDateSep +
                  RecordDate.Day.ToString("D2") + StrDateSep +
                  TransDateYear.ToString("D2");
              */
                TransDate =
                    RecordDate.Day.ToString("D2") + StrDateSep +
                    RecordDate.Month.ToString("D2") + StrDateSep +
                    TransDateYear.ToString("D2");
                TransDateTime = TransDate + " " + RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2") + ":" + RecordDate.Second.ToString("D2");
            }
            //时间
            if (SystemConfigure.ExportTimeFormate == 0)
            {
                TransTime = RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2") + ":" + RecordDate.Second.ToString("D2");
            }
            else if (SystemConfigure.ExportTimeFormate == 1)
            {
                TransTime = RecordDate.Hour.ToString("D2") + ":" + RecordDate.Minute.ToString("D2");
            }
            else if (SystemConfigure.ExportTimeFormate == 2)
            {
                TransTime = RecordDate.Hour.ToString("D2") + RecordDate.Minute.ToString("D2") + RecordDate.Second.ToString("D2");
            }
            else
            {
                TransTime = RecordDate.Hour.ToString("D2") + RecordDate.Minute.ToString("D2");
            }
            //TransTime += "   ";
            //Slave ID
            if (SystemConfigure.ExportSlaveIdLen == 0)
            {
                SlaveID = string.Format("{0}", transaction.SlaveId.ToString());
            }
            else
            {
                SlaveID = string.Format("{0}", transaction.SlaveId.ToString());
                SlaveID = SlaveID.PadLeft(SystemConfigure.ExportSlaveIdLen, '0');
            }
            //JobCode
            if (SystemConfigure.ExportJobCodeProperty == 0)
            {
                if (transaction.IsByTranType)
                {
                    if (0xA0 == (transaction.RecordType & 0xf0))
                    {
                        JobCode = transaction.RecordType.ToString();
                    }
                    else if (0xB0 == (transaction.RecordType & 0xf0))
                    {
                        JobCode = transaction.RecordType.ToString();
                    }
                    else
                    {
                        JobCode = (transaction.RecordType & 0x0f).ToString();
                    }
                }
                else
                {
                    JobCode = transaction.DataType.ToString();
                }
            }
            else
            {
                if (transaction.IsByTranType)
                {
                    if (0xA0 == (transaction.RecordType & 0xf0))
                    {
                        JobCode = SyncManage.GetJobCodeName(transaction.RecordType);
                    }
                    else if (0xB0 == (transaction.RecordType & 0xf0))
                    {
                        JobCode = SyncManage.GetJobCodeName(transaction.RecordType );
                    }
                    else
                    {
                        JobCode = SyncManage.GetJobCodeName(transaction.RecordType & 0x0f);
                    }
                }
                else
                {
                    JobCode = SyncManage.GetJobCodeName(transaction.DataType);

                    // Add: Eric 
                    // Date:2022/09/06  DataType 常為0                    
                    if (string.IsNullOrEmpty(JobCode) && transaction.DataType == 0)
                        JobCode = SyncManage.GetJobCodeName(transaction.TransactionType);
                }
            }
            if (!Directory.Exists(StrExportPath))
            {
                Directory.CreateDirectory(StrExportPath);
            }
            DeviceName = transaction.DeviceName;

            if (SystemConfigure.ExportFileExtension == "Excel")
            {
                string fileName = StrExportPath + @"\" + StrExportFileName;
                if (!File.Exists(fileName))
                {
                    IWorkbook workbook = null;
                    FileStream fs = null;
                    IRow row = null;
                    ISheet sheet = null;
                    ICell cell = null;

                    try
                    {
                        workbook = new HSSFWorkbook();
                        sheet = workbook.CreateSheet("Sheet0");

                        row = sheet.CreateRow(0);//excel第一行设为列头  
                        for (int c = 0; c < SystemConfigure.ExportItemsList.Count; c++)
                        {
                            cell = row.CreateCell(c);
                            cell.SetCellValue(SystemConfigure.ExportItemsList[c]);
                        }
                        row = sheet.CreateRow(1);
                        byte Source = (byte)0xf0;
                        byte bType = (byte)(transaction.TransactionType & Source);
                        if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x70 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0 || (bType == (byte)0x30 && SystemConfigure.IncludeIllegalRecords == 1))
                        //if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0)//|| bType == (byte)0xB0
                        {

                            for (int i = 0; i < SystemConfigure.ExportItemsList.Count; i++)
                            {
                                cell = row.CreateCell(i);//excel第二行开始写入数据  
                                cell.SetCellValue(this.GetType().GetField(SystemConfigure.ExportItemsList[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).GetValue(this).ToString());

                            }

                        }
                        using (fs = File.OpenWrite(fileName))
                        {
                            workbook.Write(fs);//向打开的这个xls文件中写入数据  

                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {//追加
                    FileStream fsAppend = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);//读取流

                    POIFSFileSystem ps = new POIFSFileSystem(fsAppend);//需using NPOI.POIFS.FileSystem;
                    IWorkbook workbookAppend = new HSSFWorkbook(ps);
                    ISheet sheetAppend = workbookAppend.GetSheetAt(0);//获取工作表
                                                                      // IRow row = sheet.GetRow(0); //得到表头
                    FileStream fout = new FileStream(fileName, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);//写入流
                    IRow  row = sheetAppend.CreateRow((sheetAppend.LastRowNum + 1));//在工作表中添加一行


                    byte Source = (byte)0xf0;
                    byte bType = (byte)(transaction.TransactionType & Source);
                    // if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0)//|| bType == (byte)0xB0
                    if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x70 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0 || (bType == (byte)0x30 && SystemConfigure.IncludeIllegalRecords == 1))
                    {

                        for (int i = 0; i < SystemConfigure.ExportItemsList.Count; i++)
                        {
                            ICell cell1 = row.CreateCell(i);

                            cell1.SetCellValue(this.GetType().GetField(SystemConfigure.ExportItemsList[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).GetValue(this).ToString());

                        }

                    }



                    fout.Flush();
                    workbookAppend.Write(fout);//写入文件
                    workbookAppend = null;
                    fout.Close();

                }

                return;
            }
            if (!File.Exists(StrExportPath + @"\" + StrExportFileName))
            {
                if (!string.IsNullOrEmpty(SystemConfigure.ExortTitleText))
                {
                    using (var sw = new StreamWriter(StrExportPath + @"\" + StrExportFileName, true))
                    {
                        sw.WriteLine(SystemConfigure.ExortTitleText);
                        sw.Close();
                    }
                }
            }
            
            if (SystemConfigure.CheckASCIIFormat == 1)
            {
                
                using (var sw = new StreamWriter(StrExportPath + @"\" + StrExportFileName, true, Encoding.ASCII))
            {
                byte Source = (byte)0xf0;
                byte bType = (byte)(transaction.TransactionType & Source);
                    //if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x70 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0 || (bType == (byte)0x30 && SystemConfigure.IncludeIllegalRecords ==1 ))
                    if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x70 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0 || (bType == (byte)0x30 && SystemConfigure.IncludeIllegalRecords == 1))
                    {
                    string strRecord = "";
                    for (int i = 0; i < SystemConfigure.ExportItemsList.Count; i++)
                    {
                        strRecord += this.GetType().GetField(SystemConfigure.ExportItemsList[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).GetValue(this).ToString();
                        if (i != (SystemConfigure.ExportItemsList.Count - 1))
                        {
                            if (SystemConfigure.ExportFileExtension == "CSV")
                                strRecord += ",";
                            else
                                strRecord += SystemConfigure.ExportSeperator;
                        }
                    }

                    sw.WriteLine(strRecord);
                }


                sw.Close();
            }
            }
            else
            {
                using (var sw = new StreamWriter(StrExportPath + @"\" + StrExportFileName, true))
            {
                byte Source = (byte)0xf0;
                byte bType = (byte)(transaction.TransactionType & Source);
                    if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x70 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0 || (bType == (byte)0x30 && SystemConfigure.IncludeIllegalRecords == 1))
                    //if (bType == (byte)0x00 || bType == (byte)0x10 || bType == (byte)0x60 || bType == (byte)0xA0 || bType == (byte)0xE0 || bType == (byte)0xD0)//|| bType == (byte)0xB0
                    {
                    string strRecord = "";
                    for (int i = 0; i < SystemConfigure.ExportItemsList.Count; i++)
                    {
                        strRecord += this.GetType().GetField(SystemConfigure.ExportItemsList[i], BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static).GetValue(this).ToString();
                        if (i != (SystemConfigure.ExportItemsList.Count - 1))
                        {
                            if (SystemConfigure.ExportFileExtension == "CSV")
                                strRecord += ",";
                            else
                                strRecord += SystemConfigure.ExportSeperator;
                        }
                    }


                        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                        * Add:      2023/07/21
                        * Ver:      1.1.5.10
                        * Note:        
                        */
                        if (SystemConfigure.IsEnableEncryptExportData)
                        {
                            strRecord = KCS.Helpers.EncryptHelper.EncryptAES(strRecord);
                        }
                        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                        sw.WriteLine(strRecord);
                }


                sw.Close();
            }

            }
            
        }
    }
}
