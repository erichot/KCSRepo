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
using DevExpress.XtraGrid.Views.Tile;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;
using DevExpress.XtraEditors.Controls;
using KCS.Sync;
using System.Threading.Tasks;
using NetSockets;
using DevExpress.Mvvm;
using System.Threading;

namespace KCS.Views
{
    public partial class DeviceSettingManage : BaseViewControl, IRibbonModule
    {
        public delegate void UpdateTraceDelegate(string traceMessage);
        private delegate void OnAsyncCallbackPing();
        private OnAsyncCallbackPing onAsyncCallbackPing = null;
        /* For Refresh device status*/
        private Thread threadRefreshDevice;
        private CancellationTokenSource cts = new CancellationTokenSource();

        private int m_GridTileViewCurrentPosition = 0;
        private int m_GridTileViewPreviousPosition = 0;
        private int m_UpdateDeviceStatusInvokeTime = 0;
        private int m_OnLoadDeviceEventTime = 0;


        public DeviceSettingManage()
            : base(typeof(DeviceSettingManageViewModel))
        {
            InitializeComponent();
            if (!mvvmContext.IsDesignMode)
                InitializeBindings();
        }
        private void SetTraceDevice()
        {
            var selectDevice = tileView.GetRow(tileView.FocusedRowHandle) as Devices;
            foreach (Devices device in SyncManage.GetDeviceLists())
            {
                if (device != null && selectDevice != null)
                {
                    if (device.SlaveSID == selectDevice.SlaveSID)
                    {
                        if( device.DeviceTraceEvent == null)
                        device.DeviceTraceEvent += UpdateTraceMessage;
                    }
                    else
                    {
                        if (device.DeviceTraceEvent != null)
                        device.DeviceTraceEvent -= UpdateTraceMessage;
                    }
                }
            }
        }
        protected void ThreadedRefreshDevice()
        {
            int TickCount = 0;
            
            try
            {
                //m_GridTileViewPreviousPosition = ((TileView)gridControl.MainView).Position;

                while (!this.cts.Token.IsCancellationRequested)
                {
                    TickCount++;
                    if (TickCount >= 30)
                    {
                        UpdateDeviceStatus();
                        AddTransactions();
                        TickCount = 0;
                        lblDebugPrint1.Text = "DateTime.Now.Second=" + DateTime.Now.Second.ToString() + " /Mod=" + (DateTime.Now.Second % 5).ToString()  + " ：" + DateTime.Now.ToString("ss") + " ：" + (((TileView)gridControl.MainView).Position).ToString();
                    }
                    //((TileView)gridControl.MainView).Position = m_GridTileViewPreviousPosition;
                    //((TileView)gridControl.MainView).Position = ((TileView)gridControl.MainView).FocusedRowHandle * (((TileView)gridControl.MainView).OptionsTiles.ItemSize.Width + ((TileView)gridControl.MainView).OptionsTiles.IndentBetweenItems);

                    lblDebugPrint2.Text = "L85=" + DateTime.Now.ToString("ss") + " ：" + (((TileView)gridControl.MainView).Position).ToString();
                    Thread.Sleep(200);                                                           
                    
                }

                
            }
            catch (Exception ex)
            {
                //XtraMessageBox.Show(ex.Message, "Refresh Device");
            }

            threadRefreshDevice = null;
        }
         protected override void OnLoad(System.EventArgs e)
        {
            
            base.OnLoad(e);
           // gridControl.Load += gridControl_Load;
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();

            gridControl.Enter += gridControl_Enter;
            //erictest SyncManage.InitDataSync();
            foreach (Devices device in SyncManage.GetDeviceLists())
            {
                    device.DeviceStatusEvent += UpdateDeviceStatus;
                // Add: 2023/11/16
                // 同樣UpdateDeviceStatus在短時間內迅速執行多次（大約是S_Slave的RowCount)
                //break;
            //    device.DeviceGetFingerEvent += UpdateDeviceFingerStatus;
            //    device.AddTransactionEvent += AddTransactions;
            }
            if (SyncManage.GetDeviceLists() != null && SyncManage.GetDeviceLists().Count > 0)
            {
                var selectDevice = SyncManage.GetDeviceLists()[0];
                if (selectDevice != null)
                {
                    selectDevice.DeviceTraceEvent += UpdateTraceMessage;
                }
            }
            
            
            this.gridView1.BestFitColumns();
            onAsyncCallbackPing = new OnAsyncCallbackPing(PinDeviceTest);

            lblDebugPrint.Text = "Starting.. " + DateTime.Now.ToString("HH:mm:ss") + " ：" + (((TileView)gridControl.MainView).Position).ToString();


            threadRefreshDevice = new Thread(new ThreadStart(ThreadedRefreshDevice));
            threadRefreshDevice.Start();
            //SetTraceDevice();

            //            listBoxControl.Items.AddRange(new object[] {
            //    "Color <color=Red>Red</color>",
            //    "Color <color=Green>Green</color>",
            //    "Color <color=Blue>Blue</color>"
            //});
            
        }
        protected override void OnDisposing()
         {
             base.OnDisposing();
             cts.Cancel();
             Thread.Sleep(100);
             if (threadRefreshDevice != null)
             {
                 threadRefreshDevice.Abort();
             }
             foreach (Devices device in SyncManage.GetDeviceLists())
             {
                 if (device != null )
                 {
             //        device.DeviceTraceEvent -= UpdateTraceMessage;
             //        device.AddTransactionEvent -= AddTransactions;
                     device.DeviceStatusEvent -= UpdateDeviceStatus;
                     //        device.DeviceGetFingerEvent -= UpdateDeviceFingerStatus;
                 }
             }
         }
         void RebindDataSource()
         {
             try
             {
                 var fluentAPI = mvvmContext.OfType<DeviceSettingManageViewModel>();
                 fluentAPI.SetObjectDataSourceBinding(bindingSource,
                    x => x.DevicesDataSet);
             }
             catch { }
         }
         void InitBindings()
         {
             var fluentAPI = mvvmContext.OfType<DeviceSettingManageViewModel>();
             try
             {
                 fluentAPI.SetObjectDataSourceBinding(bindingSource,
                    x => x.DevicesDataSet);
                 fluentAPI.SetObjectDataSourceBinding(transactionsBindingSource,
                    x => x.TransactionssDataSet);
                 
             }
             catch (Exception ex)
             {
                 XtraMessageBox.Show(ex.Message, "KCS Error");
             }
             Messenger.Default.Register<RebindMessage<DeviceSettingManageViewModel>>(this, x => RebindDataSource());
             fluentAPI.WithEvent<TileView, FocusedRowObjectChangedEventArgs>(tileView, "FocusedRowObjectChanged")
                .SetBinding(
                    x => x.SelectedDevice, args => args.Row as Devices,
                    (tView, entity) => tView.FocusedRowHandle = tView.FindRow(entity));
             fluentAPI.WithEvent<TileViewItemClickEventArgs>(tileView, "ItemDoubleClick")
                 .EventToCommand(x => x.Edit(null), x => x.SelectedDevice);
             fluentAPI.BindCommand(bbiEdit, x => x.Edit(null), x => x.SelectedDevice);
             fluentAPI.BindCommand(biDeviceType, x => x.DeviceCategorySet());
             fluentAPI.BindCommand(biNewDevice, x => x.NewDevice());
             fluentAPI.BindCommand(bbiRebootDevice, x => x.RebootDevice(null), x => x.SelectedDevice); 
             fluentAPI.BindCommand(bbiDeleteDevice, x => x.DeleteDevice(null), x => x.SelectedDevice);
             fluentAPI.BindCommand(bbiEnableDevice, x => x.EnableDevice(null), x => x.SelectedDevice);
             fluentAPI.BindCommand(bbiDisableDevice, x => x.DisableDevice(null), x => x.SelectedDevice);
             fluentAPI.BindCommand(bbiResetDevice, x => x.ResetDevice(null), x => x.SelectedDevice);
             fluentAPI.BindCommand(bbiDeviceSyncSetting, x => x.DeviceSyncSetting(null), x => x.SelectedDevice);
             fluentAPI.BindCommand(biSearchDevice, x => x.SearchDevice());
             fluentAPI.BindCommand(bbiReReadTrans, x => x.ReReadTransactions());
             fluentAPI.BindCommand(bbiSetDevice, x => x.SetDevice());
             fluentAPI.BindCommand(bbiOpenDoor, x => x.OpenDoor(null), x => x.SelectedDevice);
             fluentAPI.BindCommand(bbiSetDoorPin, x => x.SetOpenDoorPin(null), x => x.SelectedDevice);
            fluentAPI.BindCommand(bbiRebootIDF211, x => x.RebootIDF211(null), x => x.SelectedDevice);
            fluentAPI.BindCommand(bbiResyncAcPara, x => x.ResyncAcParameters(null), x => x.SelectedDevice);
            





            tileView.ItemPress += (s, e) =>
            {
                listBoxControl.Items.Clear();
                SetTraceDevice();
            };
             bbiNetworktest.ItemClick += (s, e) =>
             {
                 listBoxControl.Items.Clear();
                 
                 Task.Run(() =>
                 {
                     onAsyncCallbackPing.Invoke();
                 });
             };


            fluentAPI.WithEvent<EventArgs>(timer1, "Tick")
               .EventToCommand(x => x.RebindDataSource());
        }
        public void PinDeviceTest()
        {
            var selectDevice = tileView.GetRow(tileView.FocusedRowHandle) as Devices;
            string PingResult = "";
            if (NetUtility.Ping(selectDevice.IP))
            {
                PingResult = "<color=Green>" + "Device is Ok" + "</color>";
            }
            else
            {
                PingResult ="<color=Red>" + "Cant't reach Device" + "</color>";
            }
            this.Invoke(new UpdateTraceDelegate(UpdateTraceMessage), PingResult);
        }
        public void UpdateTraceMessage(string message)
        {
            listBoxControl.Items.Insert(0,message);
           
        }
         public void UpdateTraceMessage(int deviceId,string message)
         {
             try
             {
                 this.Invoke(new UpdateTraceDelegate(UpdateTraceMessage), message);
             }
             catch { }
            
         }
         public void UpdateDeviceFingerStatus()
         {
             this.Invoke(new Action(() =>
             {
                 try
                 {
                     SyncManage.RefreshDeviceFingerStatus();
                 }
                 catch { }
             }));
         }
        public void UpdateDeviceStatus()
         {
            var vscroll = gridControl.Controls.OfType<DevExpress.XtraGrid.Scrolling.VCrkScrollBar>().First();

            this.Invoke(new Action(() =>
             {
                 try
                {
                     // Add:    2023/01/11
                     // By:     Eric
                     // Ver:    1.1.5.6
                     var selected = ((TileView)gridControl.MainView).GetSelectedRows();

                     //var vscroll = gridControl.Controls.OfType<DevExpress.XtraGrid.Scrolling.VCrkScrollBar>().First();
                     int previousFocusedRowHandle = ((TileView)gridControl.MainView).FocusedRowHandle;
                     m_GridTileViewPreviousPosition = ((TileView)gridControl.MainView).Position;
                     //lblDebugPrint.Text = "selected=" + selected.ToString() + " ：" + DateTime.Now.ToString("ss") + " " + (((TileView)gridControl.MainView).Position).ToString();
                     m_UpdateDeviceStatusInvokeTime++;
                     lblDebugPrint3.Text = "【" + m_UpdateDeviceStatusInvokeTime + "】L281 =" + DateTime.Now.ToString("ss") + " ：" + m_GridTileViewPreviousPosition.ToString() +  " " + vscroll.Value;

                     //var nnn = DateTime.Now;
                     //gridControl.RefreshDataSource();
                     for (var i = 0; i< tileView.TileRows.Count-1; i++)
                     {
                         tileView.RefreshRow(i);
                     }

                     //var ggg = DateTime.Now - nnn;
                     //lblDebugPrint1.Text = ggg.ToString();

                     //((TileView)gridControl.MainView).FocusedRowHandle = previousFocusedRowHandle;
                     //vscroll = gridControl.Controls.OfType<DevExpress.XtraGrid.Scrolling.VCrkScrollBar>().First();
                     //if (vscroll != null) vscroll.Value = m_GridTileViewPreviousPosition;
                     //((TileView)gridControl.MainView).Position = m_GridTileViewPreviousPosition;
                     //tileView.Position = m_GridTileViewCurrentPosition;
                     //if (vscroll != null)
                     //   vscroll.Value = previousPosition;



                     // Add:    2023/01/11
                     // By:     Eric
                     // Ver:    1.1.5.6
                     if (selected.Any())
                     {
                         var selectedIndex = selected.First();
                         //if (selectedIndex > 0) ((TileView)gridControl.MainView).FocusedRowHandle = selectedIndex;
                         if (selectedIndex > 0)
                         {
                             //((TileView)gridControl.MainView).FocusedRowHandle = selectedIndex;
                             

                             // gridControl.RefreshDataSource()會造成頁面回復到頂端，捲頁後focus會往上移
                             //var aaaa = ((TileView)gridControl.MainView).FocusedRowModified;
                             //((TileView)gridControl.MainView).Position = previousPosition;
                             //((TileView)gridControl.MainView).Position = selectedIndex * (((TileView)gridControl.MainView).OptionsTiles.ItemSize.Width + ((TileView)gridControl.MainView).OptionsTiles.IndentBetweenItems);
                             //((TileView)gridControl.MainView).Position = ((TileView)gridControl.MainView).FocusedRowHandle * (((TileView)gridControl.MainView).OptionsTiles.ItemSize.Width + ((TileView)gridControl.MainView).OptionsTiles.IndentBetweenItems);
                         }
                     }

                     //((TileView)gridControl.MainView).FocusedRowHandle = previousFocusedRowHandle;
                     //((TileView)gridControl.MainView).Position = previousFocusedRowHandle * (((TileView)gridControl.MainView).OptionsTiles.ItemSize.Width + ((TileView)gridControl.MainView).OptionsTiles.IndentBetweenItems);
                     //((TileView)gridControl.MainView).scro
                     //vscroll = gridControl.Controls.OfType<DevExpress.XtraGrid.Scrolling.VCrkScrollBar>().First();
                     //if (vscroll != null) vscroll.Value = m_GridTileViewPreviousPosition;
                     //((TileView)gridControl.MainView).Position = m_GridTileViewPreviousPosition;
                     //tileView.Position = m_GridTileViewPreviousPosition;
                     //((TileView)gridControl.MainView).Position = previousPosition;
                     lblDebugPrint4.Text = "【CurrentPosition=" + ((TileView)gridControl.MainView).Position + "】L314 =" + DateTime.Now.ToString("ss") + " ：" + m_GridTileViewPreviousPosition.ToString();

                     // gridView1.RefreshData();


                 }
                 catch { }
             }));

            //((TileView)gridControl.MainView).Position = ((TileView)gridControl.MainView).FocusedRowHandle * (((TileView)gridControl.MainView).OptionsTiles.ItemSize.Width + ((TileView)gridControl.MainView).OptionsTiles.IndentBetweenItems);
           
            
        }
        public void AddTransactions()
         {
             this.Invoke(new Action(() =>
                 {
                    try
                        {
                        
                         gridControlTrans.RefreshDataSource();
                        }
                    catch { }
                 }));

         }
        void InitViewDisplay()
        {
            ribbonPageGroupActions.Text = LanguageResource.GetDisplayString("ToolBarGroupAction");
            bbiEdit.Caption = LanguageResource.GetDisplayString("ToolBarEdit");
            biDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");
            biNewDevice.Caption = LanguageResource.GetDisplayString("ToolBarNewDevice");
            bbiDeleteDevice.Caption = LanguageResource.GetDisplayString("ToolBarDeleteDevice");
            bbiEnableDevice.Caption = LanguageResource.GetDisplayString("ToolBarEnableDevice");
            bbiDisableDevice.Caption = LanguageResource.GetDisplayString("ToolBarDisableDevice");
            biDeviceType.Caption = LanguageResource.GetDisplayString("DialogDeviceCategory");
            biSearchDevice.Caption = LanguageResource.GetDisplayString("DialogDeviceCategory");
            bbiResetDevice.Caption = LanguageResource.GetDisplayString("ToolBarResetDevice");
            bbiDeviceSyncSetting.Caption = LanguageResource.GetDisplayString("ToolBarDeviceSyncSetting");
            bbiReReadTrans.Caption = LanguageResource.GetDisplayString("ReReadTransactions");
            biSearchDevice.Caption = LanguageResource.GetDisplayString("ToolBarSearchDevice");
            bbiNetworktest.Caption = LanguageResource.GetDisplayString("ToolBarNetWorkTest");
            bbiRebootDevice.Caption = LanguageResource.GetDisplayString("ToolBarRebootDevice");
            bbiSetDoorPin.Caption = LanguageResource.GetDisplayString("ToolBarSetDoorPin");
            bbiOpenDoor.Caption = LanguageResource.GetDisplayString("ToolBarOpenDoor");
            bbiResyncAcPara.Caption = LanguageResource.GetDisplayString("ToolBarResyncAcParas");

            //bbiSetDoorPin.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ribbonPageGroupDevice.Text = LanguageResource.GetDisplayString("ToolBarGroupDevice");
            ribbonPageGroupSync.Text = LanguageResource.GetDisplayString("ToolBarGroupSync");

            colSlaveId.Caption = LanguageResource.GetDisplayString("DeviceID");
            colDeviceIP.Caption = LanguageResource.GetDisplayString("DeviceIP");
            colTransSIDInDevice.Caption = LanguageResource.GetDisplayString("TransactionID");
            colTransactionType.Caption = LanguageResource.GetDisplayString("TransactionType");
            colTransactionCardId.Caption = LanguageResource.GetDisplayString("TransctionCardID");
            colTransactionDateTime.Caption = LanguageResource.GetDisplayString("TransctionDateTime");
            colUserId.Caption = LanguageResource.GetDisplayString("EmployeeID");
            colUserName.Caption = LanguageResource.GetDisplayString("EmployeeName");

            //gridControl.RefreshDataSource();
            //((TileView)gridControl.MainView).Position = 500;
            //((TileView)gridControl.MainView).FocusedRowHandle = 33;
            //var vscroll = gridControl.Controls.OfType<DevExpress.XtraGrid.Scrolling.VCrkScrollBar>().First();
            //if (vscroll != null) vscroll.Value = 600;
            //tileView.Position = 600;
            //tileView.FocusedRowHandle = 33;
        }
         
        #region
        DevExpress.XtraBars.Ribbon.RibbonControl IRibbonModule.Ribbon { get { return ribbonControl; } }
        #endregion

        void InitializeBindings()
        {
            var fluent = mvvmContext.OfType<DeviceSettingManageViewModel>();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //bindingSource.DataSource = SyncManage.GetDeviceLists();

            //RebindDataSource();
            //bindingSource.ResetBindings(true);
            //m_GridTileViewPreviousPosition = tileView.Position;
            //var previousPosition = tileView.Position;
            //ThreadedRefreshDevice();
            //UpdateDeviceStatus();
            //gridControl.RefreshDataSource();
            //tileView.RefreshRow(1);
            //m_GridTileViewPreviousPosition = 800;
            //var vscroll = gridControl.Controls.OfType<DevExpress.XtraGrid.Scrolling.VCrkScrollBar>().First();
            //if (vscroll != null) vscroll.Value = m_GridTileViewPreviousPosition;
            //((TileView)gridControl.MainView).Position = m_GridTileViewPreviousPosition;
            //tileView.Position = previousPosition;
            //tileView.Position = m_GridTileViewCurrentPosition;
            //RebindDataSource();
        }





        private void gridControl_Enter(object sender, System.EventArgs e)
        {
            m_GridTileViewCurrentPosition = tileView.Position;
        }
        private void gridControl_MouseClick(Object sender, MouseEventArgs e)
        {
            m_GridTileViewCurrentPosition = tileView.Position;
        }


    }
}
