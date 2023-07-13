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
using KCS.Common.Utils;
using System.Xml;
using KCS.Common.DAL;
using KCS.Controls;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace KCS.Form
{
    public partial class FormLangSelect : DevExpress.XtraEditors.XtraForm
    {
        public FormLangSelect()
        {
            this.Text = LanguageResource.GetDisplayString("ChangeLanguage");
            
            InitializeComponent();
        }
        private string GetLanguageValue(string lang)
        {
            try
            {
                string pattern = @"\[.*?\]";//匹配模式
                Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(lang);
                StringBuilder sb = new StringBuilder();//存放匹配结果
                foreach (Match match in matches)
                {
                    string value = match.Value;
                    return value;
                }

                return "";
            }
            catch
            {
                return "";
            }

        }
        private void ReadSupportLanguage()
        {
            string szPath = string.Format("{0}\\Resources\\AppLangConfig.xml", XmlHelper.GetWorkDirectory());
            XmlReader reader = new XmlTextReader(szPath);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            XmlNode root = doc.DocumentElement;
            XmlNodeList nodelist = root.SelectNodes("Area[Language='" + SystemConfigure.LanguageSelect + "']/List/Item");
            int index = 0, indexCount = 0;
            foreach (XmlNode node in nodelist)
            {
                string langnode = node.InnerText;
                langnode = langnode.TrimEnd('\r').TrimEnd('\n');

                string strValue = GetLanguageValue(langnode);
                string strText = langnode.Substring(0, langnode.IndexOf(strValue));
                if (!string.IsNullOrEmpty(strValue))
                {

                    comboBoxEditLang.Properties.Items.Add(new ComboxLang(strText, strValue.Trim('[', ']')));
                    if (strValue.Trim('[', ']') == SystemConfigure.LanguageSelect)
                        index = indexCount;
                    indexCount++;
                }
            }
            reader.Close();
            comboBoxEditLang.SelectedIndex = index;
        }

        private void FormLangSelect_Load(object sender, EventArgs e)
        {
            lblCtlLanguage.Text = LanguageResource.GetDisplayString("DefaultLanguage");
            buttonSaveLang.Text = buttonSaveLang.Text = LanguageResource.GetDisplayString("ToolBarSave");
            try
            {
                ReadSupportLanguage();
            }
            catch (Exception ex)
            {
                comboBoxEditLang.Properties.Items.Add(new ComboxLang("English", "EN"));
                comboBoxEditLang.SelectedIndex = 0;
            }
        }
        
        private void buttonSaveLang_Click(object sender, EventArgs e)
        {
            var SelectLang = comboBoxEditLang.EditValue as ComboxLang;
            SystemConfigure.SetDefaultLanguage(SelectLang.Value);
            //开启新的实例
            Process.Start(Application.ExecutablePath);
 
             //关闭当前实例
             Process.GetCurrentProcess().Kill();
        }
    }
}