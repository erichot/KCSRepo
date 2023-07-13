namespace KCS.Views
{
    using DevExpress.XtraLayout;
    partial class OverviewControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonsPanel = new DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.logo = new DevExpress.XtraEditors.PictureEdit();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.descriptionLabel = new DevExpress.XtraEditors.LabelControl();
            this.ItemForDescription = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.ItemForDescription,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(24, 24, 24, 24);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1440, 983);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.logo;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 817);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem1.Size = new System.Drawing.Size(1392, 118);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.SupportHorzAlignment;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // logo
            // 
            this.logo.EditValue = global::KCS.Properties.Resources.KCS_logo;
            this.logo.Location = new System.Drawing.Point(24, 841);
            this.logo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logo.Name = "logo";
            this.logo.Properties.AllowFocused = false;
            this.logo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.logo.Properties.Appearance.Options.UseBackColor = true;
            this.logo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.logo.Properties.PictureAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.logo.Properties.ShowMenu = false;
            this.logo.Properties.ZoomAccelerationFactor = 1D;
            this.logo.Size = new System.Drawing.Size(1392, 118);
            this.logo.StyleController = this.layoutControl1;
            this.logo.TabIndex = 16;
            // 
            // layoutControl1
            // 
            this.layoutControl1.AllowCustomization = false;
            this.layoutControl1.Controls.Add(this.buttonsPanel);
            this.layoutControl1.Controls.Add(this.descriptionLabel);
            this.layoutControl1.Controls.Add(this.logo);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1440, 983);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AllowHtmlString = true;
            this.descriptionLabel.Appearance.Font = new System.Drawing.Font("Segoe UI Light", 18F);
           // this.descriptionLabel.Appearance.Image = global::DevExpress.DevAV.Properties.Resources.Jolt_Logo;
            this.descriptionLabel.Appearance.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.descriptionLabel.Appearance.Options.UseFont = true;
            this.descriptionLabel.Appearance.Options.UseImage = true;
            this.descriptionLabel.Appearance.Options.UseImageAlign = true;
            this.descriptionLabel.Appearance.Options.UseTextOptions = true;
            this.descriptionLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.descriptionLabel.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.descriptionLabel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.descriptionLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.descriptionLabel.Location = new System.Drawing.Point(24, 24);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(1392, 640);
            this.descriptionLabel.StyleController = this.layoutControl1;
            this.descriptionLabel.TabIndex = 16;
            this.descriptionLabel.Text = "UI SuperHero";
            // 
            // ItemForDescription
            // 
            this.ItemForDescription.Control = this.descriptionLabel;
            this.ItemForDescription.ControlAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.ItemForDescription.CustomizationFormText = "layoutControlItem2";
            this.ItemForDescription.Location = new System.Drawing.Point(0, 0);
            this.ItemForDescription.MinSize = new System.Drawing.Size(1, 1);
            this.ItemForDescription.Name = "layoutControlItem2";
            this.ItemForDescription.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.ItemForDescription.Size = new System.Drawing.Size(1392, 640);
            this.ItemForDescription.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.ItemForDescription.TextSize = new System.Drawing.Size(0, 0);
            this.ItemForDescription.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.buttonsPanel;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 640);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Size = new System.Drawing.Size(1392, 177);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // OverviewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "OverviewControl";
            this.Size = new System.Drawing.Size(1440, 983);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PictureEdit logo;
        private DevExpress.XtraEditors.LabelControl descriptionLabel;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDescription;
        private DevExpress.XtraBars.Docking2010.WindowsUIButtonPanel buttonsPanel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
