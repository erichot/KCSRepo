using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.Common.Utils;
using System.Data.OleDb;
using KCS.Common.DAL;
using KCS.Models;
using KCS.ViewModels;
using System.IO;

namespace KCS.Views
{
    public partial class ImportEmployees : DevExpress.XtraEditors.XtraUserControl
    {

        public ImportEmployees()
        {
            InitializeComponent();
            this.radioGroupImportPara.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0,  LanguageResource.GetDisplayString("FromXLSX")),
             new DevExpress.XtraEditors.Controls.RadioGroupItem(1,  LanguageResource.GetDisplayString("FromXLS")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2,  LanguageResource.GetDisplayString("FromTxtWithComSep")),
             new DevExpress.XtraEditors.Controls.RadioGroupItem(3,  LanguageResource.GetDisplayString("FromTxtWithTabSep"))});
            radioGroupImportPara.SelectedIndex = 0;
            checkEditSyncOrNot.Text = LanguageResource.GetDisplayString("SyncAfterImport");
            checkEditOverwrite.Text = LanguageResource.GetDisplayString("ImportOverwrite");
            sbImport.Text = LanguageResource.GetDisplayString("ToolBarImportEmployee");


        }

        private void sbImport_Click(object sender, EventArgs e)
        {
            string ErrorMessage = "";
            int SucceedsCount = 0;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "";
            //dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.ValidateNames = true;
            //验证路径有效性
            dlg.CheckFileExists = true;
            //验证文件有效性
            dlg.CheckPathExists = true;
            if (radioGroupImportPara.SelectedIndex == 0)
            {//XLSX
                dlg.Filter = "Excel(*.xlsx)|*.xlsx";

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            else if (radioGroupImportPara.SelectedIndex == 1)
            {//XLS
                dlg.Filter = "Excel(*.xls)|*.xls";

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }
            else
            {
                dlg.Filter = "Text (*.txt)|*.txt";

                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

            }

            if (dlg.FileName == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(this, LanguageResource.GetDisplayString("NoSelectedExcelFileHint"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (!EmployeesDataSource.ImportFromFile(dlg.FileName, checkEditOverwrite.Checked, checkEditSyncOrNot.Checked, radioGroupImportPara.SelectedIndex, out ErrorMessage, out SucceedsCount))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, ErrorMessage, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //lblCtlHint.Text = string.Format("{0}\r\n {1}:{2}", LanguageResource.GetDisplayString("ImportComplete"), LanguageResource.GetDisplayString("ImportCompleteCounts"), SucceedsCount.ToString());
                lblCtlHint.Text = string.Format("{0}\r\n", LanguageResource.GetDisplayString("ImportComplete"));
                var fluentAPI = mvvmContext.OfType<ImportEmployeesViewModel>();
                fluentAPI.ViewModel.RefreshEmployees();
            }
            catch (Exception ex)
            {

            }
        }
        private static bool IsRealImage(string path)
        {
            try
            {
                Image img = Image.FromFile(path);
                //Console.WriteLine("\nIt is a real image");
                return true;
            }
            catch (Exception e)
            {
                //Console.WriteLine("\nIt is a fate image");
                return false;
            }
        }

        private void sbImportPhotos_Click(object sender, EventArgs e)
        {
            bool bDataChanged = false;
            progressBarControl1.Properties.Minimum = 0;
           // progressBarControl1.Properties.Maximum = 100;
            progressBarControl1.Properties.Step = 1;
            progressBarControl1.Properties.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            progressBarControl1.Position = 0;
            progressBarControl1.Properties.ShowTitle = true;
            progressBarControl1.Properties.PercentView = true;
            progressBarControl1.Properties.ProgressKind = DevExpress.XtraEditors.Controls.ProgressKind.Horizontal;


            try
            {
                string pathOfPhotos = string.Format("{0}\\Staff photos", System.Windows.Forms.Application.StartupPath);
                var files = Directory.GetFiles(pathOfPhotos,"*.jpg"); //String数组类型
                int count = files.Length;
                progressBarControl1.Properties.Maximum = count;

                foreach (var file in files)
                {
                    try
                    {
                        string strRegPhoto = file;
                        int len1 = pathOfPhotos.Length;
                        int len2 = strRegPhoto.Length;
                        string strEmployeeId = strRegPhoto.Substring(len1 + 1, len2 - len1 - 5);
                        if (IsRealImage(strRegPhoto))
                        {
                            if (EmployeesDataSource.ImportEmployeePhoto(strEmployeeId, strRegPhoto))
                                bDataChanged = true;
                        }
                    }
                    catch(Exception)
                    {

                    }
                    
                    progressBarControl1.PerformStep();
                    System.Windows.Forms.Application.DoEvents();
                }
                var fluentAPI = mvvmContext.OfType<ImportEmployeesViewModel>();
                fluentAPI.ViewModel.RefreshEmployees();
                //Console.WriteLine(files);
            }
            catch (Exception)
            { }
        }
    }
}
