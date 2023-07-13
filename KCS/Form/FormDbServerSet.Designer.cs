namespace KCS
{
    partial class FormDbServerSet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxEditServerName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.progressBarNew = new System.Windows.Forms.ProgressBar();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.groupBoxLoginMethod = new System.Windows.Forms.GroupBox();
            this.groupBoxDBData = new System.Windows.Forms.GroupBox();
            this.radioRestoreDB = new System.Windows.Forms.RadioButton();
            this.groupBoxExistDB = new System.Windows.Forms.GroupBox();
            this.comboBoxDataBase = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.groupBoxNewDB = new System.Windows.Forms.GroupBox();
            this.textEditNewDb = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.radioButtonNewDb = new System.Windows.Forms.RadioButton();
            this.radioButtonExistDb = new System.Windows.Forms.RadioButton();
            this.groupBoxUserData = new System.Windows.Forms.GroupBox();
            this.textEditUserPwd = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEditUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioButtonSqlAuth = new System.Windows.Forms.RadioButton();
            this.radioButtonWindowsAuth = new System.Windows.Forms.RadioButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEditLang = new DevExpress.XtraEditors.ComboBoxEdit();
            this.buttonSaveLang = new System.Windows.Forms.Button();
            this.checkEditDisableSync = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditServerName.Properties)).BeginInit();
            this.groupBoxLoginMethod.SuspendLayout();
            this.groupBoxDBData.SuspendLayout();
            this.groupBoxExistDB.SuspendLayout();
            this.groupBoxNewDB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewDb.Properties)).BeginInit();
            this.groupBoxUserData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDisableSync.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxEditServerName
            // 
            this.comboBoxEditServerName.Location = new System.Drawing.Point(56, 61);
            this.comboBoxEditServerName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.comboBoxEditServerName.Name = "comboBoxEditServerName";
            this.comboBoxEditServerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditServerName.Size = new System.Drawing.Size(574, 28);
            this.comboBoxEditServerName.TabIndex = 16;
            // 
            // buttonRestore
            // 
            this.buttonRestore.Location = new System.Drawing.Point(437, 699);
            this.buttonRestore.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(156, 69);
            this.buttonRestore.TabIndex = 15;
            this.buttonRestore.Text = "Restore";
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Visible = false;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // progressBarNew
            // 
            this.progressBarNew.Location = new System.Drawing.Point(56, 775);
            this.progressBarNew.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.progressBarNew.Name = "progressBarNew";
            this.progressBarNew.Size = new System.Drawing.Size(574, 33);
            this.progressBarNew.TabIndex = 14;
            this.progressBarNew.Visible = false;
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(436, 699);
            this.buttonNew.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(156, 69);
            this.buttonNew.TabIndex = 13;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Visible = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(436, 699);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(156, 69);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(91, 699);
            this.buttonTest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(156, 69);
            this.buttonTest.TabIndex = 11;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // groupBoxLoginMethod
            // 
            this.groupBoxLoginMethod.Controls.Add(this.groupBoxDBData);
            this.groupBoxLoginMethod.Controls.Add(this.groupBoxUserData);
            this.groupBoxLoginMethod.Controls.Add(this.radioButtonSqlAuth);
            this.groupBoxLoginMethod.Controls.Add(this.radioButtonWindowsAuth);
            this.groupBoxLoginMethod.Location = new System.Drawing.Point(56, 108);
            this.groupBoxLoginMethod.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxLoginMethod.Name = "groupBoxLoginMethod";
            this.groupBoxLoginMethod.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxLoginMethod.Size = new System.Drawing.Size(574, 525);
            this.groupBoxLoginMethod.TabIndex = 10;
            this.groupBoxLoginMethod.TabStop = false;
            this.groupBoxLoginMethod.Text = "Login mode";
            // 
            // groupBoxDBData
            // 
            this.groupBoxDBData.Controls.Add(this.radioRestoreDB);
            this.groupBoxDBData.Controls.Add(this.groupBoxExistDB);
            this.groupBoxDBData.Controls.Add(this.groupBoxNewDB);
            this.groupBoxDBData.Controls.Add(this.radioButtonNewDb);
            this.groupBoxDBData.Controls.Add(this.radioButtonExistDb);
            this.groupBoxDBData.Enabled = false;
            this.groupBoxDBData.Location = new System.Drawing.Point(33, 255);
            this.groupBoxDBData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxDBData.Name = "groupBoxDBData";
            this.groupBoxDBData.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxDBData.Size = new System.Drawing.Size(510, 259);
            this.groupBoxDBData.TabIndex = 3;
            this.groupBoxDBData.TabStop = false;
            // 
            // radioRestoreDB
            // 
            this.radioRestoreDB.AutoSize = true;
            this.radioRestoreDB.Location = new System.Drawing.Point(19, 83);
            this.radioRestoreDB.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioRestoreDB.Name = "radioRestoreDB";
            this.radioRestoreDB.Size = new System.Drawing.Size(170, 26);
            this.radioRestoreDB.TabIndex = 8;
            this.radioRestoreDB.Text = "Restore database";
            this.radioRestoreDB.UseVisualStyleBackColor = true;
            this.radioRestoreDB.CheckedChanged += new System.EventHandler(this.radioRestoreDB_CheckedChanged);
            // 
            // groupBoxExistDB
            // 
            this.groupBoxExistDB.Controls.Add(this.comboBoxDataBase);
            this.groupBoxExistDB.Controls.Add(this.labelControl5);
            this.groupBoxExistDB.Location = new System.Drawing.Point(27, 137);
            this.groupBoxExistDB.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxExistDB.Name = "groupBoxExistDB";
            this.groupBoxExistDB.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxExistDB.Size = new System.Drawing.Size(441, 105);
            this.groupBoxExistDB.TabIndex = 7;
            this.groupBoxExistDB.TabStop = false;
            // 
            // comboBoxDataBase
            // 
            this.comboBoxDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBase.FormattingEnabled = true;
            this.comboBoxDataBase.Location = new System.Drawing.Point(149, 36);
            this.comboBoxDataBase.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.comboBoxDataBase.Name = "comboBoxDataBase";
            this.comboBoxDataBase.Size = new System.Drawing.Size(260, 30);
            this.comboBoxDataBase.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(56, 42);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(73, 22);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "DataBase";
            // 
            // groupBoxNewDB
            // 
            this.groupBoxNewDB.Controls.Add(this.textEditNewDb);
            this.groupBoxNewDB.Controls.Add(this.labelControl4);
            this.groupBoxNewDB.Location = new System.Drawing.Point(27, 137);
            this.groupBoxNewDB.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxNewDB.Name = "groupBoxNewDB";
            this.groupBoxNewDB.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxNewDB.Size = new System.Drawing.Size(441, 85);
            this.groupBoxNewDB.TabIndex = 6;
            this.groupBoxNewDB.TabStop = false;
            // 
            // textEditNewDb
            // 
            this.textEditNewDb.Location = new System.Drawing.Point(150, 36);
            this.textEditNewDb.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textEditNewDb.Name = "textEditNewDb";
            this.textEditNewDb.Size = new System.Drawing.Size(263, 28);
            this.textEditNewDb.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(56, 42);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(73, 22);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "DataBase";
            // 
            // radioButtonNewDb
            // 
            this.radioButtonNewDb.AutoSize = true;
            this.radioButtonNewDb.Location = new System.Drawing.Point(294, 35);
            this.radioButtonNewDb.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioButtonNewDb.Name = "radioButtonNewDb";
            this.radioButtonNewDb.Size = new System.Drawing.Size(145, 26);
            this.radioButtonNewDb.TabIndex = 5;
            this.radioButtonNewDb.Text = "New database";
            this.radioButtonNewDb.UseVisualStyleBackColor = true;
            this.radioButtonNewDb.CheckedChanged += new System.EventHandler(this.radioButtonNewDb_CheckedChanged);
            // 
            // radioButtonExistDb
            // 
            this.radioButtonExistDb.AutoSize = true;
            this.radioButtonExistDb.Checked = true;
            this.radioButtonExistDb.Location = new System.Drawing.Point(19, 35);
            this.radioButtonExistDb.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioButtonExistDb.Name = "radioButtonExistDb";
            this.radioButtonExistDb.Size = new System.Drawing.Size(221, 26);
            this.radioButtonExistDb.TabIndex = 4;
            this.radioButtonExistDb.TabStop = true;
            this.radioButtonExistDb.Text = "Using existing database";
            this.radioButtonExistDb.UseVisualStyleBackColor = true;
            this.radioButtonExistDb.CheckedChanged += new System.EventHandler(this.radioButtonExistDb_CheckedChanged);
            // 
            // groupBoxUserData
            // 
            this.groupBoxUserData.Controls.Add(this.textEditUserPwd);
            this.groupBoxUserData.Controls.Add(this.labelControl3);
            this.groupBoxUserData.Controls.Add(this.textEditUserName);
            this.groupBoxUserData.Controls.Add(this.labelControl2);
            this.groupBoxUserData.Location = new System.Drawing.Point(31, 91);
            this.groupBoxUserData.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxUserData.Name = "groupBoxUserData";
            this.groupBoxUserData.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.groupBoxUserData.Size = new System.Drawing.Size(510, 165);
            this.groupBoxUserData.TabIndex = 2;
            this.groupBoxUserData.TabStop = false;
            // 
            // textEditUserPwd
            // 
            this.textEditUserPwd.Location = new System.Drawing.Point(180, 97);
            this.textEditUserPwd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textEditUserPwd.Name = "textEditUserPwd";
            this.textEditUserPwd.Size = new System.Drawing.Size(263, 28);
            this.textEditUserPwd.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(56, 104);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 22);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Password";
            // 
            // textEditUserName
            // 
            this.textEditUserName.Location = new System.Drawing.Point(180, 36);
            this.textEditUserName.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textEditUserName.Name = "textEditUserName";
            this.textEditUserName.Size = new System.Drawing.Size(263, 28);
            this.textEditUserName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(56, 42);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 22);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "User Name";
            // 
            // radioButtonSqlAuth
            // 
            this.radioButtonSqlAuth.AutoSize = true;
            this.radioButtonSqlAuth.Checked = true;
            this.radioButtonSqlAuth.Location = new System.Drawing.Point(340, 55);
            this.radioButtonSqlAuth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioButtonSqlAuth.Name = "radioButtonSqlAuth";
            this.radioButtonSqlAuth.Size = new System.Drawing.Size(176, 26);
            this.radioButtonSqlAuth.TabIndex = 1;
            this.radioButtonSqlAuth.TabStop = true;
            this.radioButtonSqlAuth.Text = "Sql authentication";
            this.radioButtonSqlAuth.UseVisualStyleBackColor = true;
            this.radioButtonSqlAuth.CheckedChanged += new System.EventHandler(this.radioButtonSqlAuth_CheckedChanged);
            // 
            // radioButtonWindowsAuth
            // 
            this.radioButtonWindowsAuth.AutoSize = true;
            this.radioButtonWindowsAuth.Location = new System.Drawing.Point(31, 55);
            this.radioButtonWindowsAuth.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.radioButtonWindowsAuth.Name = "radioButtonWindowsAuth";
            this.radioButtonWindowsAuth.Size = new System.Drawing.Size(223, 26);
            this.radioButtonWindowsAuth.TabIndex = 0;
            this.radioButtonWindowsAuth.Text = "Windows authentication";
            this.radioButtonWindowsAuth.UseVisualStyleBackColor = true;
            this.radioButtonWindowsAuth.CheckedChanged += new System.EventHandler(this.radioButtonWindowsAuth_CheckedChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 20);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 22);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Server Name";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(79, 658);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(138, 22);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Default Language";
            // 
            // comboBoxEditLang
            // 
            this.comboBoxEditLang.Location = new System.Drawing.Point(237, 658);
            this.comboBoxEditLang.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.comboBoxEditLang.Name = "comboBoxEditLang";
            this.comboBoxEditLang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditLang.Size = new System.Drawing.Size(146, 28);
            this.comboBoxEditLang.TabIndex = 17;
            this.comboBoxEditLang.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditLang_SelectedIndexChanged);
            this.comboBoxEditLang.EditValueChanged += new System.EventHandler(this.comboBoxEditLang_EditValueChanged);
            // 
            // buttonSaveLang
            // 
            this.buttonSaveLang.Location = new System.Drawing.Point(324, 699);
            this.buttonSaveLang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSaveLang.Name = "buttonSaveLang";
            this.buttonSaveLang.Size = new System.Drawing.Size(103, 38);
            this.buttonSaveLang.TabIndex = 18;
            this.buttonSaveLang.Text = "Save";
            this.buttonSaveLang.UseVisualStyleBackColor = true;
            this.buttonSaveLang.Visible = false;
            // 
            // checkEditDisableSync
            // 
            this.checkEditDisableSync.Location = new System.Drawing.Point(391, 655);
            this.checkEditDisableSync.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkEditDisableSync.Name = "checkEditDisableSync";
            this.checkEditDisableSync.Properties.Caption = "停止通信";
            this.checkEditDisableSync.Size = new System.Drawing.Size(207, 26);
            this.checkEditDisableSync.TabIndex = 19;
            this.checkEditDisableSync.EditValueChanged += new System.EventHandler(this.checkEditDisableSync_EditValueChanged);
            // 
            // FormDbServerSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 816);
            this.Controls.Add(this.checkEditDisableSync);
            this.Controls.Add(this.buttonSaveLang);
            this.Controls.Add(this.comboBoxEditLang);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.comboBoxEditServerName);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.progressBarNew);
            this.Controls.Add(this.buttonNew);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.groupBoxLoginMethod);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDbServerSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "System Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDbServerSet_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDbServerSet_FormClosed);
            this.Load += new System.EventHandler(this.FormDbServerSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditServerName.Properties)).EndInit();
            this.groupBoxLoginMethod.ResumeLayout(false);
            this.groupBoxLoginMethod.PerformLayout();
            this.groupBoxDBData.ResumeLayout(false);
            this.groupBoxDBData.PerformLayout();
            this.groupBoxExistDB.ResumeLayout(false);
            this.groupBoxExistDB.PerformLayout();
            this.groupBoxNewDB.ResumeLayout(false);
            this.groupBoxNewDB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewDb.Properties)).EndInit();
            this.groupBoxUserData.ResumeLayout(false);
            this.groupBoxUserData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditDisableSync.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditServerName;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.ProgressBar progressBarNew;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.GroupBox groupBoxLoginMethod;
        private System.Windows.Forms.GroupBox groupBoxDBData;
        private System.Windows.Forms.RadioButton radioRestoreDB;
        private System.Windows.Forms.GroupBox groupBoxExistDB;
        private System.Windows.Forms.ComboBox comboBoxDataBase;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.GroupBox groupBoxNewDB;
        private DevExpress.XtraEditors.TextEdit textEditNewDb;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.RadioButton radioButtonNewDb;
        private System.Windows.Forms.RadioButton radioButtonExistDb;
        private System.Windows.Forms.GroupBox groupBoxUserData;
        private DevExpress.XtraEditors.TextEdit textEditUserPwd;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEditUserName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RadioButton radioButtonSqlAuth;
        private System.Windows.Forms.RadioButton radioButtonWindowsAuth;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLang;
        private System.Windows.Forms.Button buttonSaveLang;
        private DevExpress.XtraEditors.CheckEdit checkEditDisableSync;
    }
}