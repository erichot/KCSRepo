using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KCS.Common.Utils
{
    class PopHintDialog
    {
        #region Dialog
        /// <summary>
        /// 确认对话框
        /// </summary>
        /// <param name="strString">提示内容</param>
        /// <returns>用户点击结果</returns>
        public static DialogResult Confirm(string strString)
        {
            return DevExpress.XtraEditors.XtraMessageBox.Show(strString, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        /// <summary>
        /// 确认对话框
        /// </summary>
        /// <param name="strSting">提示内容</param>
        public static void ShowMessage(string strSting)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(strSting, "KCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 错误信息框
        /// </summary>
        /// <param name="strSting"></param>
        public static void ShowErrorMessage(string strSting)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show(strSting, "KCS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 确认删除对话框
        /// </summary>
        /// /// <returns>用户点击结果</returns>
        public static DialogResult ConfirmDelete()
        {
            return DevExpress.XtraEditors.XtraMessageBox.Show("确定要删除吗？", "KCS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
        #endregion
    }
}
