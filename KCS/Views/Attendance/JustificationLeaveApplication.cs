using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using KCS.ViewModels;
using KCS.Common.Utils;
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;
using DevExpress.XtraGrid.Views.Grid;

namespace KCS.Views
{
    public partial class JustificationLeaveApplication : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraGrid.Columns.GridColumn colNUM;
        private DevExpress.XtraGrid.Columns.GridColumn colUSE_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colEMP_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colEMP_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colSPHOLIDAY;
        private DevExpress.XtraGrid.Columns.GridColumn colOVERDAY;
        private DevExpress.XtraGrid.Columns.GridColumn colLEAVE_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colLEAVE_DATE1;
        private DevExpress.XtraGrid.Columns.GridColumn colLEAVE_DATE2;
        private DevExpress.XtraGrid.Columns.GridColumn colLEAVE_TIME1;
        private DevExpress.XtraGrid.Columns.GridColumn colLEAVE_TIME2;
        private DevExpress.XtraGrid.Columns.GridColumn colSUM_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colAGENT;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS;
        private DevExpress.XtraGrid.Columns.GridColumn colCFM_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCFM_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colBUILD_TIME;

        //Leave items
        private DevExpress.XtraGrid.Columns.GridColumn colItemsNUM;
        private DevExpress.XtraGrid.Columns.GridColumn colSN;
        private DevExpress.XtraGrid.Columns.GridColumn colLEAVE_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colTURN_HOUR;
        private DevExpress.XtraGrid.Columns.GridColumn colItemSUM_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colItemCREATE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colItemCREATE_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBUILD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colItemBUILD_TIME;

        public JustificationLeaveApplication()
        {
            InitializeComponent();
            InitGridControlDisplay();
        }
        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);

            gridControl.Load += gridControl_Load;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
            

        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }
        void RebindDataSource()
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtMain = TaDataSource.GetLeaveItems();
                dtMain.TableName = "LeaveItem";

                ds.Tables.Add(dtMain.Copy());
                DataTable dtDetails = TaDataSource.GetLeaveItemDetails();
                dtDetails.TableName = "ItemDetails";
                ds.Tables.Add(dtDetails.Copy());

                DataRelation relation = new DataRelation("Leaves",
                                         ds.Tables["LeaveItem"].Columns["NUM"],
                                         ds.Tables["ItemDetails"].Columns["NUM"]);


                ds.Relations.Add(relation);

                gridControl.DataSource = ds.Tables["LeaveItem"];
               
            }
            catch { }
        }
        void InitGridControlDisplay()
        {
            this.colNUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUSE_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMP_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMP_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPHOLIDAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOVERDAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLEAVE_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLEAVE_DATE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLEAVE_DATE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLEAVE_TIME1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLEAVE_TIME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSUM_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCFM_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCFM_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBUILD_TIME = new DevExpress.XtraGrid.Columns.GridColumn();

            

            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNUM,
            this.colUSE_DATE,
            this.colEMP_CODE,
            this.colEMP_NAME,
            this.colSPHOLIDAY,
            this.colOVERDAY,
            this.colLEAVE_CODE,
            this.colLEAVE_DATE1,
            this.colLEAVE_DATE2,
            this.colLEAVE_TIME1,
            this.colLEAVE_TIME2,
            this.colSUM_TIME,
            this.colAGENT,
            this.colSTATUS,
            this.colCFM_NAME,
            this.colCFM_TIME,
            this.colCREATE_NAME,
            this.colCREATE_TIME,
            this.colBUILD_NAME,
            this.colBUILD_TIME});
            
            this.colNUM.FieldName = "NUM";
            this.colNUM.VisibleIndex = 0;
            this.colUSE_DATE.FieldName = "USE_DATE";
            this.colUSE_DATE.VisibleIndex = 1;
            this.colEMP_CODE.FieldName = "EMP_CODE";
            this.colEMP_CODE.VisibleIndex = 2;
            this.colEMP_NAME.FieldName = "EMP_NAME";
            this.colEMP_NAME.VisibleIndex = 3;
            this.colSPHOLIDAY.FieldName = "SPHOLIDAY";
            this.colSPHOLIDAY.VisibleIndex = 4;
            this.colOVERDAY.FieldName = "OVERDAY";
            this.colOVERDAY.VisibleIndex = 5;
            this.colLEAVE_CODE.FieldName = "LEAVE_CODE";
            this.colLEAVE_CODE.VisibleIndex = 6;
            this.colLEAVE_DATE1.FieldName = "LEAVE_DATE1";
            this.colLEAVE_DATE1.VisibleIndex = 7;
            this.colLEAVE_DATE2.FieldName = "LEAVE_DATE2";
            this.colLEAVE_DATE2.VisibleIndex = 8;
            this.colLEAVE_TIME1.FieldName = "LEAVE_TIME1";
            this.colLEAVE_TIME1.VisibleIndex = 9;
            this.colLEAVE_TIME2.FieldName = "LEAVE_TIME2";
            this.colLEAVE_TIME2.VisibleIndex = 10;
            this.colSUM_TIME.FieldName = "SUM_TIME";
            this.colSUM_TIME.VisibleIndex = 11;
            this.colAGENT.FieldName = "AGENT";
            this.colAGENT.VisibleIndex = 12;
            this.colSTATUS.FieldName = "STATUS";
            this.colSTATUS.VisibleIndex = 13;
            this.colCFM_NAME.FieldName = "CFM_NAME";
            this.colCFM_NAME.VisibleIndex = 14;
            this.colCFM_TIME.FieldName = "CFM_TIME";
            this.colCFM_TIME.VisibleIndex = 15;
            this.colCREATE_NAME.FieldName = "CREATE_NAME";
            this.colCREATE_NAME.VisibleIndex = 16;
            this.colCREATE_TIME.FieldName = "CREATE_TIME";
            this.colCREATE_TIME.VisibleIndex = 17;
            this.colBUILD_NAME.FieldName = "BUILD_NAME";
            this.colBUILD_NAME.VisibleIndex = 18;
            this.colBUILD_TIME.FieldName = "BUILD_TIME";
            this.colBUILD_TIME.VisibleIndex = 19;

            this.colNUM.Caption = LanguageResource.GetDisplayString("LeaveNUM");
            this.colUSE_DATE.Caption = LanguageResource.GetDisplayString("ApplyDate");
            this.colEMP_CODE.Caption = LanguageResource.GetDisplayString("EmployeeID");
            this.colEMP_NAME.Caption = LanguageResource.GetDisplayString("EmployeeName");
            this.colSPHOLIDAY.Visible = false;
            this.colOVERDAY.Visible = false;
            this.colLEAVE_CODE.Caption = LanguageResource.GetDisplayString("LeaveTypeIdText");
            this.colLEAVE_DATE1.Caption = LanguageResource.GetDisplayString("LeaveDateStart");
            this.colLEAVE_DATE2.Caption = LanguageResource.GetDisplayString("LeaveDateEnd");
            this.colLEAVE_TIME1.Caption = LanguageResource.GetDisplayString("LeaveTimeStart");
            this.colLEAVE_TIME2.Caption = LanguageResource.GetDisplayString("LeaveTimeEnd");
            this.colSUM_TIME.Caption = LanguageResource.GetDisplayString("HourlyTotal");
            this.colSUM_TIME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colAGENT.Caption = LanguageResource.GetDisplayString("Agent");
            this.colSTATUS.Caption = LanguageResource.GetDisplayString("StatusText");

            this.colCFM_NAME.Caption = LanguageResource.GetDisplayString("Authorizer");
            this.colCFM_TIME.Caption = LanguageResource.GetDisplayString("ApprovalTime");
            this.colCREATE_NAME.Visible = false;
            this.colCREATE_TIME.Visible = false;
            this.colBUILD_NAME.Visible = false;
            this.colBUILD_TIME.Visible = false;

            //Leave Items
            this.colItemsNUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLEAVE_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTURN_HOUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemSUM_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemCREATE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemCREATE_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBUILD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemBUILD_TIME = new DevExpress.XtraGrid.Columns.GridColumn();

            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemsNUM,
            this.colSN,
            this.colLEAVE_DATE,
            this.colTURN_HOUR,
            this.colItemSUM_TIME,
            this.colItemCREATE_NAME,
            this.colItemCREATE_TIME,
            this.colItemBUILD_NAME,
            this.colItemBUILD_TIME});

            this.colItemsNUM.FieldName = "NUM";
            this.colItemsNUM.VisibleIndex = 0;

            this.colSN.FieldName = "SN";
            this.colSN.VisibleIndex = 1;

            this.colLEAVE_DATE.FieldName = "LEAVE_DATE";
            this.colLEAVE_DATE.VisibleIndex = 2;

            this.colTURN_HOUR.FieldName = "TURN_HOUR";
            this.colTURN_HOUR.VisibleIndex = 3;

            this.colItemSUM_TIME.FieldName = "SUM_TIME";
            this.colItemSUM_TIME.VisibleIndex = 4;

            this.colItemCREATE_NAME.FieldName = "CREATE_NAME";
            this.colItemCREATE_NAME.VisibleIndex = 5;

            this.colItemCREATE_TIME.FieldName = "CREATE_TIME";
            this.colItemCREATE_TIME.VisibleIndex = 6;

            this.colItemBUILD_NAME.FieldName = "BUILD_NAME";
            this.colItemBUILD_NAME.VisibleIndex = 7;

            this.colItemBUILD_TIME.FieldName = "BUILD_TIME";
            this.colItemBUILD_TIME.VisibleIndex = 8;

            this.colItemsNUM.Caption = LanguageResource.GetDisplayString("LeaveNUM");
            this.colSN.Caption = LanguageResource.GetDisplayString("IDText");
            this.colSN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colLEAVE_DATE.Caption = LanguageResource.GetDisplayString("LeaveDate");
            this.colTURN_HOUR.Caption = LanguageResource.GetDisplayString("AttendanceHours");
            this.colTURN_HOUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colItemSUM_TIME.Caption = LanguageResource.GetDisplayString("LeaveHours");
            this.colItemSUM_TIME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colItemCREATE_NAME.Caption = LanguageResource.GetDisplayString("BulidText");
            this.colItemCREATE_TIME.Caption = LanguageResource.GetDisplayString("BulidTimeText");
            this.colItemBUILD_NAME.Caption = LanguageResource.GetDisplayString("ModifyText");
            this.colItemBUILD_TIME.Caption = LanguageResource.GetDisplayString("ModifyTimeText");

            
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<JustificationLeaveApplicationViewModel>();

            Messenger.Default.Register<RebindMessage<JustificationLeaveApplicationViewModel>>(this, x => RebindDataSource());
            //fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
            //   .SetBinding(x => x.SelectedPerLeaveItem,
            //       args => args.Row as PerLeaveItem,
            //       (gView, LeaveItem) => gView.FocusedRowHandle = gView.FindRow(LeaveItem));

            try
            {
                DataSet ds = new DataSet();
                DataTable dtMain = TaDataSource.GetLeaveItems();
                dtMain.TableName = "LeaveItem";
              
                ds.Tables.Add(dtMain.Copy());
                DataTable dtDetails = TaDataSource.GetLeaveItemDetails();
                dtDetails.TableName = "ItemDetails";
                ds.Tables.Add(dtDetails.Copy());

                DataRelation relation = new DataRelation("Leaves",
                                         ds.Tables["LeaveItem"].Columns["NUM"],
                                         ds.Tables["ItemDetails"].Columns["NUM"]);
                

                ds.Relations.Add(relation);

                gridControl.DataSource = ds.Tables["LeaveItem"];
               
                //gridView.PopulateColumns();
               
            }
            catch  (Exception ex ){ }

            

            fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                        .EventToCommand(
                            x => x.Edit(null), x => x.SelectedPerLeaveItem,
                            args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));
            fluentAPI.BindCommand(bbiNew, x => x.NewVocation());
            fluentAPI.BindCommand(bbiEdit, x => x.Edit(null), x => x.SelectedPerLeaveItem);
            fluentAPI.BindCommand(bbiDelete, x => x.Delete(null), x => x.SelectedPerLeaveItem);
        }
        void InitViewDisplay()
        {
            

            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
           
            bbiDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            bbiNew.Caption = LanguageResource.GetDisplayString("ToolBarNew");
            bbiEdit.Caption = LanguageResource.GetDisplayString("ToolBarGroupEdit");

           

            gridView.BestFitColumns();
        }

        private void gridView_FocusedRowObjectChanged(object sender, FocusedRowObjectChangedEventArgs e)
        {
            
            var rowData = e.Row as DataRowView;
            var  leaveItem = rowData.Row as DataRow;
            if (rowData != null)
            {
                var fluentAPI = mvvmContext.OfType<JustificationLeaveApplicationViewModel>();
                try
                {
                    fluentAPI.ViewModel.SelectedPerLeaveItem.NUM = Convert.ToString(leaveItem.ItemArray[0]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.USE_DATE = Convert.ToDateTime(leaveItem.ItemArray[1]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.EMP_CODE = Convert.ToString(leaveItem.ItemArray[2]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.SPHOLIDAY = Convert.ToBoolean(leaveItem.ItemArray[3]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.OVERDAY = Convert.ToBoolean(leaveItem.ItemArray[4]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.LEAVE_CODE = Convert.ToString(leaveItem.ItemArray[5]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.LEAVE_DATE1 = Convert.ToDateTime(leaveItem.ItemArray[6]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.LEAVE_DATE2 = Convert.ToDateTime(leaveItem.ItemArray[7]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.LEAVE_TIME1 = Convert.ToString(leaveItem.ItemArray[8]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.LEAVE_TIME2 = Convert.ToString(leaveItem.ItemArray[9]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.SUM_TIME = Convert.ToDouble(leaveItem.ItemArray[10]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.AGENT = Convert.ToString(leaveItem.ItemArray[11]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.STATUS = Convert.ToString(leaveItem.ItemArray[12]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.CFM_NAME = Convert.ToString(leaveItem.ItemArray[13]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.CFM_TIME = Convert.ToDateTime(leaveItem.ItemArray[14]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.CREATE_NAME = Convert.ToString(leaveItem.ItemArray[15]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.CREATE_TIME = Convert.ToDateTime(leaveItem.ItemArray[16]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.BUILD_NAME = Convert.ToString(leaveItem.ItemArray[17]);
                    fluentAPI.ViewModel.SelectedPerLeaveItem.BUILD_TIME = Convert.ToDateTime(leaveItem.ItemArray[18]);
                }
                catch
                {
                }
                
            }
        }

        
       

    }
}
