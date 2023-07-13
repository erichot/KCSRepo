using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using KCS.Common.DAL;
using KCS.Models;
using KCS.Common.Utils;

namespace KCS
{
    public partial class ExportTextSet : DevExpress.XtraEditors.XtraForm
    {
        
        public ExportTextSet()
        {
            InitializeComponent();
            this.Text = LanguageResource.GetDisplayString("ExportTextSet");
            checkEditAutoExportTxt.Text = LanguageResource.GetDisplayString("AutoExportToTxt");
            labelControl1.Text = LanguageResource.GetDisplayString("Separator");
            labelControl2.Text = LanguageResource.GetDisplayString("DateSeparator");
            labelControl3.Text = LanguageResource.GetDisplayString("SlaveIDlength");
            labelControl4.Text = LanguageResource.GetDisplayString("ToolBarJobCode");
            labelControl5.Text = LanguageResource.GetDisplayString("DateFormate");
            checkEditCreateByMonth.Text = LanguageResource.GetDisplayString("Createfilebymonth");
            labelControl6.Text = LanguageResource.GetDisplayString("TimeFormate");
            labelControl7.Text = LanguageResource.GetDisplayString("FilePath");
            simpleButtonSave.Text = LanguageResource.GetDisplayString("ToolBarSave");
            lblCtlYearLen.Text = LanguageResource.GetDisplayString("YearLen");
            lblCtlFixedText.Text = LanguageResource.GetDisplayString("FixedText")+"1";
            lblCtlFixedText2.Text = LanguageResource.GetDisplayString("FixedText") + "2";
            lblCtlFixedText3.Text = LanguageResource.GetDisplayString("FixedText") + "3";
            labelControl9.Text = LanguageResource.GetDisplayString("FileExtension");
            labelControl10.Text = LanguageResource.GetDisplayString("CardIdLen");
            labelControl8.Text = LanguageResource.GetDisplayString("TileText");
            checkEditFixedExportFileName.Text = LanguageResource.GetDisplayString("FixedExportFileName");
            checkEditASCII.Text = LanguageResource.GetDisplayString("ASCIIFormat");

            gridColumnID.Caption = LanguageResource.GetDisplayString("DeviceID");
            gridColumnIp.Caption = LanguageResource.GetDisplayString("DeviceIP");
            gridColumnSlaveName.Caption = LanguageResource.GetDisplayString("DeviceName");
            gridColumnSlaveDis.Caption = LanguageResource.GetDisplayString("DeviceDescription");

           
            checkEditAutoExportTxt.Checked = (SystemConfigure.ExportToTxtOrNot != 0);
            textEditSeperator.Text = SystemConfigure.ExportSeperator;
            comboBoxEditDateSep.SelectedIndex = SystemConfigure.ExportDateSeperator;
            comboBoxEditSlaveIdLen.SelectedIndex = SystemConfigure.ExportSlaveIdLen;
            comboBoxEditJobCode.SelectedIndex = SystemConfigure.ExportJobCodeProperty;
            checkEditCreateByMonth.Checked = (SystemConfigure.ExportFileByMonth != 0);
            comboBoxEditDate.SelectedIndex = SystemConfigure.ExportDateFormate;
            comboBoxEditTime.SelectedIndex = SystemConfigure.ExportTimeFormate;
            textEditPath.Text = SystemConfigure.ExportFilePath;
            comboBoxDateLen.SelectedIndex = SystemConfigure.ExportDateLen;
            textEditFixData.Text = SystemConfigure.ExportFixedText;
            textEditFixData2.Text = SystemConfigure.ExportFixedText2;
            textEditFixData3.Text = SystemConfigure.ExportFixedText3;
            comboBoxEditExtension.Text = SystemConfigure.ExportFileExtension;
            checkEditFixedExportFileName.Checked = (SystemConfigure.CheckExportFixedFileName != 0);
            textEditFiexedExportFileName.Text = SystemConfigure.ExportFixedFileName;
            checkEditASCII.Checked = (SystemConfigure.CheckASCIIFormat != 0);
            cmbEditCardIdLen.Text = SystemConfigure.ExportCardIdLen.ToString();
            checkEditIncIllegal.Text = SystemConfigure.IncludeIllegalRecords.ToString();

            for (int i = 0; i < SystemConfigure.ExportItemsList.Count; i++)
            {
                listBoxControlSeItems.Items.Add(SystemConfigure.ExportItemsList[i]);
            }

            gridControl.DataSource = DevicesDataSource.GetDevicesInofList();
            
            for (int i = 0; i < gridView.RowCount; i++)    
            {   //   获取选中行的check的值  
                if (SystemConfigure.slavesList.Contains(Convert.ToInt32(gridView.GetRowCellValue(i, gridView.Columns["SlaveSID"]))))
                {
                    gridView.SelectRow(i);
                }
            }
        }

        private void simpleButtonAdd_Click(object sender, EventArgs e)
        {
            if (listBoxControlSource.SelectedItem != null)
            {
                if (!listBoxControlSeItems.Items.Contains(listBoxControlSource.SelectedItem) || Convert.ToString(listBoxControlSource.SelectedItem) == "CustomText")
                listBoxControlSeItems.Items.Add(listBoxControlSource.SelectedItem);
            }
        }

        private void simpleButtonDelete_Click(object sender, EventArgs e)
        {
            if( listBoxControlSeItems.SelectedIndex != -1)
            listBoxControlSeItems.Items.RemoveAt(listBoxControlSeItems.SelectedIndex);
        }

        private void simpleButtonDeleteAll_Click(object sender, EventArgs e)
        {
            listBoxControlSeItems.Items.Clear();
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            SystemConfigure.SaveTxtExportSetting(checkEditAutoExportTxt.Checked ? 1 : 0, comboBoxEditDateSep.SelectedIndex, textEditSeperator.Text, comboBoxEditSlaveIdLen.SelectedIndex, comboBoxEditJobCode.SelectedIndex,
                checkEditCreateByMonth.Checked ? 1 : 0, comboBoxEditDate.SelectedIndex, comboBoxEditTime.SelectedIndex, textEditPath.Text, comboBoxDateLen.SelectedIndex, textEditFixData.Text, textEditTitle.Text, comboBoxEditExtension.Text,
                checkEditFixedExportFileName.Checked ? 1 : 0, textEditFiexedExportFileName.Text, checkEditASCII.Checked ? 1 : 0, Convert.ToInt32(cmbEditCardIdLen.Text), textEditFixData2.Text, textEditFixData3.Text, Convert.ToInt32(checkEditIncIllegal.Text));
            SystemConfigure.ExportItemsList.Clear();
            string szConfigFile = string.Format("{0}\\ExportFormate.txt", System.Windows.Forms.Application.StartupPath);

            if (File.Exists(szConfigFile))
            {
                //如果存在则删除
                File.Delete(szConfigFile);
            }
            using (var sw = new StreamWriter(szConfigFile, true))
            {
               // sw.WriteLine(str);
                for (int i = 0; i < listBoxControlSeItems.Items.Count; i++)
                {
                    sw.WriteLine(listBoxControlSeItems.Items[i].ToString());
                    SystemConfigure.ExportItemsList.Add(listBoxControlSeItems.Items[i].ToString());
                }
                
                sw.Close();
            }
            SystemConfigure.slavesList.Clear();
            int[] rowSelected = this.gridView.GetSelectedRows();
            foreach (int iRow in rowSelected)
            {
               
                SystemConfigure.slavesList.Add(Convert.ToInt32(gridView.GetRowCellValue(iRow, gridView.Columns["SlaveSID"])));
            }
            SystemConfigure.SaveSlavesList();
            DevExpress.XtraEditors.XtraMessageBox.Show(LanguageResource.GetDisplayString("SaveSucceeds"), "KCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButtonPath_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folder = new System.Windows.Forms.FolderBrowserDialog();

            if (folder.ShowDialog() == DialogResult.OK)
            {
                this.textEditPath.Text = folder.SelectedPath;
            }
        }
    }
}