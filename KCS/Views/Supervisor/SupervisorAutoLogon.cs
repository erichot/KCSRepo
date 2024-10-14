using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;


using KCS.Common.Utils;
using KCS.ViewModels;
using KCS.Models;
//using DevExpress.Mvvm;
using DevExpress.Utils.MVVM;
using Microsoft.Win32;


namespace KCS.Views.Supervisor
{
    public partial class SupervisorAutoLogon : DevExpress.XtraEditors.XtraUserControl
    {
        public SupervisorAutoLogon()
        {
            InitializeComponent();
        }


        private void SupervisorAutoLogon_Load(object sender, EventArgs e)
        {
            InitLanguageResource();
            InitBindings();
            LoadRegData();

        }




        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<SupervisorAutoLognViewModel>();
            fluentAPI.BindCommand(btnCancel, x => x.Close());
        }




        private void LoadRegData()
        {
            string userID = string.Empty;
            string pwdDec = string.Empty;
            bool isAutoLogon = false;

            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(AppRegistryModel.REG_KEY_SW_CU_KCS);
            if (regKey != null)
            {
                userID = regKey.GetValue(AppRegistryModel.REG_ITEM_UserID).ToString();
               
                string isAutoLogonText = regKey.GetValue(AppRegistryModel.REG_ITEM_IsAutoLogon).ToString();
                if (string.IsNullOrEmpty(isAutoLogonText) == false 
                    && Boolean.TryParse(isAutoLogonText, out bool _isAutoLogon) == true
                    )
                {
                    isAutoLogon = _isAutoLogon;
                }


                string pwdEnc = regKey.GetValue(AppRegistryModel.REG_ITEM_Password).ToString();
                if (string.IsNullOrEmpty(pwdEnc) == false)
                {
                    pwdDec = LoginPwdCryption.DeCode(pwdEnc);
                }

                chkIsAutoLogon.Checked = isAutoLogon;
                txtPassword.Text = pwdDec;
                txtUserID.Text = userID;

                regKey.Close();
            }

            
            
            

        }







        private void SaveRegData()
        {
            string userID = txtUserID.Text.Trim();
            string pwdDec = txtPassword.Text.Trim();
            bool isAutoLogon = chkIsAutoLogon.Checked;

            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(AppRegistryModel.REG_KEY_SW_CU_KCS,true);
            if (regKey == null)
            {

                Registry.CurrentUser.CreateSubKey(AppRegistryModel.REG_KEY_SW_CU_KCS);
                regKey = Registry.CurrentUser.OpenSubKey(AppRegistryModel.REG_KEY_SW_CU_KCS);
            }


            try
            {
                regKey.SetValue(AppRegistryModel.REG_ITEM_UserID, userID);

                string pwdEnc = LoginPwdCryption.EnCode(pwdDec);
                regKey.SetValue(AppRegistryModel.REG_ITEM_Password, pwdEnc);

                string isAutoLogonText = isAutoLogon.ToString();
                regKey.SetValue(AppRegistryModel.REG_ITEM_IsAutoLogon, isAutoLogonText);

                KCS.Common.Utils.PopHintDialog.ShowMessage(
                    LanguageResource.GetDisplayString("SaveSucceeds"));
            }
            catch (UnauthorizedAccessException ex)
            {
                KCS.Common.Utils.PopHintDialog.ShowMessage("Cannot access the Registry");
            }
            catch (Exception ex)
            {
                KCS.Common.Utils.PopHintDialog.ShowMessage(ex.Message);
            }

            regKey.Close();


        }








        private void InitLanguageResource()
        {
            
            this.btnOk.Text = LanguageResource.GetDisplayString("DialogOkButtonText");
            //this.btnCancel.Text = LanguageResource.GetDisplayString("DialogCancelButtonText");
            this.btnCancel.Text = LanguageResource.GetDisplayString("ToolBarClose");
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveRegData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
