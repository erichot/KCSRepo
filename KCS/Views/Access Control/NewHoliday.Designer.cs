namespace KCS.Views
{
    partial class NewHoliday
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
            this.lblCtlHoliType = new DevExpress.XtraEditors.LabelControl();
            this.lblCtlDescription = new DevExpress.XtraEditors.LabelControl();
            this.sbOk = new DevExpress.XtraEditors.SimpleButton();
            this.sbCancel = new DevExpress.XtraEditors.SimpleButton();
            this.cmbEditHoliType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textEditHoliDescription = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEditHoliType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHoliDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCtlHoliType
            // 
            this.lblCtlHoliType.Location = new System.Drawing.Point(113, 96);
            this.lblCtlHoliType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlHoliType.Name = "lblCtlHoliType";
            this.lblCtlHoliType.Size = new System.Drawing.Size(103, 22);
            this.lblCtlHoliType.TabIndex = 0;
            this.lblCtlHoliType.Text = "Holiday Type";
            // 
            // lblCtlDescription
            // 
            this.lblCtlDescription.Location = new System.Drawing.Point(113, 168);
            this.lblCtlDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lblCtlDescription.Name = "lblCtlDescription";
            this.lblCtlDescription.Size = new System.Drawing.Size(87, 22);
            this.lblCtlDescription.TabIndex = 2;
            this.lblCtlDescription.Text = "Description";
            // 
            // sbOk
            // 
            this.sbOk.Location = new System.Drawing.Point(224, 248);
            this.sbOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbOk.Name = "sbOk";
            this.sbOk.Size = new System.Drawing.Size(123, 49);
            this.sbOk.TabIndex = 4;
            this.sbOk.Text = "OK";
            this.sbOk.Click += new System.EventHandler(this.sbOk_Click);
            // 
            // sbCancel
            // 
            this.sbCancel.Location = new System.Drawing.Point(374, 248);
            this.sbCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sbCancel.Name = "sbCancel";
            this.sbCancel.Size = new System.Drawing.Size(123, 49);
            this.sbCancel.TabIndex = 5;
            this.sbCancel.Text = "Cancel";
            this.sbCancel.Click += new System.EventHandler(this.sbCancel_Click);
            // 
            // cmbEditHoliType
            // 
            this.cmbEditHoliType.Location = new System.Drawing.Point(243, 91);
            this.cmbEditHoliType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbEditHoliType.Name = "cmbEditHoliType";
            this.cmbEditHoliType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEditHoliType.Properties.DropDownRows = 9;
            this.cmbEditHoliType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbEditHoliType.Size = new System.Drawing.Size(309, 28);
            this.cmbEditHoliType.TabIndex = 6;
            // 
            // textEditHoliDescription
            // 
            this.textEditHoliDescription.Location = new System.Drawing.Point(243, 168);
            this.textEditHoliDescription.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textEditHoliDescription.Name = "textEditHoliDescription";
            this.textEditHoliDescription.Size = new System.Drawing.Size(309, 28);
            this.textEditHoliDescription.TabIndex = 7;
            // 
            // NewHoliday
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 388);
            this.Controls.Add(this.textEditHoliDescription);
            this.Controls.Add(this.cmbEditHoliType);
            this.Controls.Add(this.sbCancel);
            this.Controls.Add(this.sbOk);
            this.Controls.Add(this.lblCtlDescription);
            this.Controls.Add(this.lblCtlHoliType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewHoliday";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Holiday";
            ((System.ComponentModel.ISupportInitialize)(this.cmbEditHoliType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditHoliDescription.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCtlHoliType;
        private DevExpress.XtraEditors.LabelControl lblCtlDescription;
        private DevExpress.XtraEditors.SimpleButton sbOk;
        private DevExpress.XtraEditors.SimpleButton sbCancel;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEditHoliType;
        private DevExpress.XtraEditors.TextEdit textEditHoliDescription;
    }
}