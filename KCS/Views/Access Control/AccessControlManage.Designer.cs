namespace KCS.Views
{
    partial class AccessControlManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccessControlManage));
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiHolidaySet = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTimeSet = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTimeZone = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupUserGoup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bindingSourceUserGroup = new System.Windows.Forms.BindingSource(this.components);
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListcolNodeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListcolNodeValue = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bindingSourceTimeZone = new System.Windows.Forms.BindingSource(this.components);
            this.treeListcolStartTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListcolEndTime = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListcolDiscription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTimeZone)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(KCS.ViewModels.AccessControlManageViewModel);
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.bbiHolidaySet,
            this.bbiTimeSet,
            this.bbiTimeZone,
            this.bbiSave});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 7;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl.ShowToolbarCustomizeItem = false;
            this.ribbonControl.Size = new System.Drawing.Size(1159, 120);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // bbiHolidaySet
            // 
            this.bbiHolidaySet.Caption = "Holiday Set";
            this.bbiHolidaySet.Id = 3;
            this.bbiHolidaySet.ImageOptions.Image = global::KCS.Properties.Resources.Holiday_set_16;
            this.bbiHolidaySet.ImageOptions.LargeImage = global::KCS.Properties.Resources.Holiday_set_32;
            this.bbiHolidaySet.Name = "bbiHolidaySet";
            // 
            // bbiTimeSet
            // 
            this.bbiTimeSet.Caption = "Time Set";
            this.bbiTimeSet.Id = 4;
            this.bbiTimeSet.ImageOptions.Image = global::KCS.Properties.Resources.timeset_16;
            this.bbiTimeSet.ImageOptions.LargeImage = global::KCS.Properties.Resources.timeset_32;
            this.bbiTimeSet.Name = "bbiTimeSet";
            // 
            // bbiTimeZone
            // 
            this.bbiTimeZone.Caption = "Time Zone";
            this.bbiTimeZone.Id = 5;
            this.bbiTimeZone.ImageOptions.Image = global::KCS.Properties.Resources.timezone_16;
            this.bbiTimeZone.ImageOptions.LargeImage = global::KCS.Properties.Resources.timezone_32;
            this.bbiTimeZone.Name = "bbiTimeZone";
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save ";
            this.bbiSave.Id = 6;
            this.bbiSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.Image")));
            this.bbiSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.LargeImage")));
            this.bbiSave.Name = "bbiSave";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupActions,
            this.ribbonPageGroupUserGoup});
            this.ribbonPage2.Name = "ribbonPage2";
            // 
            // ribbonPageGroupActions
            // 
            this.ribbonPageGroupActions.ItemLinks.Add(this.bbiTimeSet);
            this.ribbonPageGroupActions.ItemLinks.Add(this.bbiTimeZone);
            this.ribbonPageGroupActions.ItemLinks.Add(this.bbiHolidaySet);
            this.ribbonPageGroupActions.Name = "ribbonPageGroupActions";
            this.ribbonPageGroupActions.ShowCaptionButton = false;
            this.ribbonPageGroupActions.Text = "Actions";
            // 
            // ribbonPageGroupUserGoup
            // 
            this.ribbonPageGroupUserGoup.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroupUserGoup.Name = "ribbonPageGroupUserGoup";
            this.ribbonPageGroupUserGoup.ShowCaptionButton = false;
            this.ribbonPageGroupUserGoup.Text = "User Group";
            // 
            // treeList
            // 
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListcolNodeName,
            this.treeListcolNodeValue,
            this.treeListcolStartTime,
            this.treeListcolEndTime,
            this.treeListcolDiscription});
            this.treeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList.DataSource = this.bindingSourceUserGroup;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.KeyFieldName = "KeyFieldName";
            this.treeList.Location = new System.Drawing.Point(0, 120);
            this.treeList.Name = "treeList";
            this.treeList.ParentFieldName = "ParentFieldName";
            this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.treeList.Size = new System.Drawing.Size(1159, 371);
            this.treeList.TabIndex = 1;
            // 
            // treeListcolNodeName
            // 
            this.treeListcolNodeName.Caption = "NodeName";
            this.treeListcolNodeName.FieldName = "NodeName";
            this.treeListcolNodeName.Name = "treeListcolNodeName";
            this.treeListcolNodeName.Visible = true;
            this.treeListcolNodeName.VisibleIndex = 0;
            // 
            // treeListcolNodeValue
            // 
            this.treeListcolNodeValue.Caption = "Node Value";
            this.treeListcolNodeValue.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.treeListcolNodeValue.FieldName = "NodeValue";
            this.treeListcolNodeValue.Name = "treeListcolNodeValue";
            this.treeListcolNodeValue.Visible = true;
            this.treeListcolNodeValue.VisibleIndex = 1;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DoorID", "Door ID", 65, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TimeZoneID", "Time Zone ID", 85, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Frame01", "Frame01", 57, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Frame02", "Frame02", 57, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Frame03", "Frame03", 57, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Frame04", "Frame04", 57, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description", 70, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.bindingSourceTimeZone;
            this.repositoryItemLookUpEdit1.DisplayMember = "TimeZoneID";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ShowHeader = false;
            this.repositoryItemLookUpEdit1.ValueMember = "TimeZoneID";
            // 
            // bindingSourceTimeZone
            // 
            this.bindingSourceTimeZone.DataSource = typeof(KCS.Models.AcTimeZone);
            // 
            // treeListcolStartTime
            // 
            this.treeListcolStartTime.Caption = "Start Time";
            this.treeListcolStartTime.FieldName = "StartTime";
            this.treeListcolStartTime.Name = "treeListcolStartTime";
            this.treeListcolStartTime.Visible = true;
            this.treeListcolStartTime.VisibleIndex = 2;
            // 
            // treeListcolEndTime
            // 
            this.treeListcolEndTime.Caption = "End Time";
            this.treeListcolEndTime.FieldName = "EndTime";
            this.treeListcolEndTime.Name = "treeListcolEndTime";
            this.treeListcolEndTime.Visible = true;
            this.treeListcolEndTime.VisibleIndex = 3;
            // 
            // treeListcolDiscription
            // 
            this.treeListcolDiscription.Caption = "Discription";
            this.treeListcolDiscription.FieldName = "Discription";
            this.treeListcolDiscription.Name = "treeListcolDiscription";
            this.treeListcolDiscription.Visible = true;
            this.treeListcolDiscription.VisibleIndex = 4;
            // 
            // AccessControlManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList);
            this.Controls.Add(this.ribbonControl);
            this.Name = "AccessControlManage";
            this.Size = new System.Drawing.Size(1159, 491);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTimeZone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupActions;
        private DevExpress.XtraBars.BarButtonItem bbiHolidaySet;
        private DevExpress.XtraBars.BarButtonItem bbiTimeSet;
        private DevExpress.XtraBars.BarButtonItem bbiTimeZone;
        private System.Windows.Forms.BindingSource bindingSourceUserGroup;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListcolNodeName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListcolNodeValue;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListcolStartTime;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListcolEndTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource bindingSourceTimeZone;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListcolDiscription;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupUserGoup;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
    }
}
