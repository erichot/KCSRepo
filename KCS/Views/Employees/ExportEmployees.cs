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
using KCS.ViewModels;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

namespace KCS.Views
{
    public partial class ExportEmployees : DevExpress.XtraEditors.XtraUserControl
    {
        public ExportEmployees()
        {
            InitializeComponent();
        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }
        protected override void OnLoad(System.EventArgs e)
        {

            base.OnLoad(e);
            gridControl.Load += gridControl_Load;
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();
            gridView1.OptionsPrint.UsePrintStyles = false;
        }
        
        void InitViewDisplay()
        {
            InitExportData();
            sbExport.Text = LanguageResource.GetDisplayString("ExportString")+"...";
            labelControlExport.Text = string.Format("<b>{0}</b> {1}:", LanguageResource.GetDisplayString("ExportString"), LanguageResource.GetDisplayString("ToStrString"));
            colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentId");
            colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
            colCardID.Caption = LanguageResource.GetDisplayString("CardID");
            colEmployeeTypeName.Caption = LanguageResource.GetDisplayString("EmployeeTypeName");
            colValidDate.Caption = LanguageResource.GetDisplayString("ValideDate");
            colAllowTimeStartHour.Caption = LanguageResource.GetDisplayString("AllowTimeStartHour");
            colAllowTimeStartMinute.Caption = LanguageResource.GetDisplayString("AllowTimeStartHMin");
            colAllowTimeEndHour.Caption = LanguageResource.GetDisplayString("AllowTimeEndHour");
            colAllowTimeEndMinute.Caption = LanguageResource.GetDisplayString("AllowTimeEndHMin");
            colEmail.Caption = LanguageResource.GetDisplayString("Email");
            colPhoneMobile.Caption = LanguageResource.GetDisplayString("SupervisorViewPhone");
            gridView.BestFitColumns();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ExportEmployeesViewModel>();
            fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.EmployeesDataSet);
            sbExport.Click += (s, e) =>
                {
                    int index = cbExport.SelectedIndex;
                    if (index < 0) return;
                    string fileName = ShowSaveFileDialog(exportData.GetValue(index, 0).ToString(), exportData.GetValue(index, 1).ToString());
                    if (fileName == string.Empty) return;
                    ExportToEx(fileName, exportData.GetValue(index, 2).ToString(), gridView);
                    OpenFile(fileName);
                };
        }
        private void OpenFile(string fileName)
        {
            if (XtraMessageBox.Show(LanguageResource.GetDisplayString("OpenExportFile"), LanguageResource.GetDisplayString("ExportToString"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
                catch
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, LanguageResource.GetDisplayString("CannotOpenExportFile"), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
        string[,] exportData = new string[,] {{"Microsoft Excel 2007 Document", "Microsoft Excel|*.xlsx", "xlsx"}, 
            {"Microsoft Excel Document", "Microsoft Excel|*.xls", "xls"}, 
            {"PDF Document", "PDF Files|*.pdf", "pdf"},
            {"Text Document", "Text Files|*.txt", "txt"}};
        void InitExportData()
        {
            for (int i = 0; i < exportData.GetLength(0); i++)
                cbExport.Properties.Items.Add(exportData.GetValue(i, 0));
            cbExport.SelectedIndex = 0;
        }
        
        private void ExportToEx(String filename, string ext, BaseView exportView)
        {
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach (GridColumn col in gridView.Columns)
                    col.Caption = col.FieldName;
                if (ext == "pdf") exportView.ExportToPdf(filename);
                if (ext == "txt") exportView.ExportToText(filename);
                if (ext == "xls") exportView.ExportToXls(filename);
                if (ext == "xlsx") exportView.ExportToXlsx(filename);
                colUserID.Caption = LanguageResource.GetDisplayString("EmployeeID");
                colDepartmentID.Caption = LanguageResource.GetDisplayString("DepartmentId");
                colDepartmentName.Caption = LanguageResource.GetDisplayString("DepartmentName");
                colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");
                colCardID.Caption = LanguageResource.GetDisplayString("CardID");
                colEmployeeTypeName.Caption = LanguageResource.GetDisplayString("EmployeeTypeName");
                colValidDate.Caption = LanguageResource.GetDisplayString("ValideDate");
                colAllowTimeStartHour.Caption = LanguageResource.GetDisplayString("AllowTimeStartHour");
                colAllowTimeStartMinute.Caption = LanguageResource.GetDisplayString("AllowTimeStartHMin");
                colAllowTimeEndHour.Caption = LanguageResource.GetDisplayString("AllowTimeEndHour");
                colAllowTimeEndMinute.Caption = LanguageResource.GetDisplayString("AllowTimeEndHMin");
                colEmail.Caption = LanguageResource.GetDisplayString("Email");
                colPhoneMobile.Caption = LanguageResource.GetDisplayString("SupervisorViewPhone");
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Cursor.Current = currentCursor;
        }
        private string ShowSaveFileDialog(string title, string filter)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            string name = "EmployeesList";//Application.ProductName;
            int n = name.LastIndexOf(".") + 1;
            if (n > 0) name = name.Substring(n, name.Length - n);
            dlg.Title = LanguageResource.GetDisplayString("ExportString") + LanguageResource.GetDisplayString("ToStrString") + title;
            dlg.FileName = name;
            dlg.Filter = filter;
            if (dlg.ShowDialog() == DialogResult.OK) return dlg.FileName;
            return "";
        }
    }
}
