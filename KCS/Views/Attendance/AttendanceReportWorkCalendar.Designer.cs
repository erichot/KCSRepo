namespace KCS.Views
{
    partial class AttendanceReportWorkCalendar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceReportWorkCalendar));
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.biEdit = new DevExpress.XtraBars.BarButtonItem();
            this.biDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExportToPDF = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            this.mvvmContext.ViewModelType = typeof(KCS.ViewModels.AttendanceReportWorkCalendarViewModel);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.biEdit,
            this.biDelete,
            this.bbiExportToXlsx,
            this.bbiExportToPDF});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl.MaxItemId = 5;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1229, 150);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // biEdit
            // 
            this.biEdit.Caption = "Edit";
            this.biEdit.Id = 1;
            this.biEdit.ImageOptions.Image = global::KCS.Properties.Resources.icon_edit_16;
            this.biEdit.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_edit_32;
            this.biEdit.Name = "biEdit";
            // 
            // biDelete
            // 
            this.biDelete.Caption = "Delete";
            this.biDelete.Id = 2;
            this.biDelete.ImageOptions.Image = global::KCS.Properties.Resources.icon_delete_16;
            this.biDelete.ImageOptions.LargeImage = global::KCS.Properties.Resources.icon_delete_32;
            this.biDelete.Name = "biDelete";
            // 
            // bbiExportToXlsx
            // 
            this.bbiExportToXlsx.Caption = "Export To XLSX";
            this.bbiExportToXlsx.Id = 3;
            this.bbiExportToXlsx.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportToXlsx.ImageOptions.Image")));
            this.bbiExportToXlsx.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportToXlsx.ImageOptions.LargeImage")));
            this.bbiExportToXlsx.Name = "bbiExportToXlsx";
            // 
            // bbiExportToPDF
            // 
            this.bbiExportToPDF.Caption = "Export To PDF";
            this.bbiExportToPDF.Id = 4;
            this.bbiExportToPDF.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiExportToPDF.ImageOptions.Image")));
            this.bbiExportToPDF.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiExportToPDF.ImageOptions.LargeImage")));
            this.bbiExportToPDF.Name = "bbiExportToPDF";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupActions});
            this.ribbonPage2.Name = "ribbonPage2";
            // 
            // ribbonPageGroupActions
            // 
            this.ribbonPageGroupActions.Name = "ribbonPageGroupActions";
            this.ribbonPageGroupActions.ShowCaptionButton = false;
            this.ribbonPageGroupActions.Text = "Actions";
            // 
            // AttendanceReportWorkCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ribbonControl);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AttendanceReportWorkCalendar";
            this.Size = new System.Drawing.Size(1229, 557);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.BarButtonItem biEdit;
        private DevExpress.XtraBars.BarButtonItem biDelete;
        private DevExpress.XtraBars.BarButtonItem bbiExportToXlsx;
        private DevExpress.XtraBars.BarButtonItem bbiExportToPDF;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupActions;
    }
}
