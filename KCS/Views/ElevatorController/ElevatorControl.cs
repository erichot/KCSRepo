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
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;

namespace KCS.ViewModels
{
    public partial class ElevatorControl : DevExpress.XtraEditors.XtraUserControl
    {
        public ElevatorControl()
        {
            InitializeComponent();
        }
        void gridControl_Load(object sender, System.EventArgs e)
        {
            GridHelper.SetFindControlImages(gridControl);

        }

         protected override void OnLoad(System.EventArgs e)
        {
            
            base.OnLoad(e);
            gridControl.Load += gridControl_Load;
            
            if (!DesignMode)
                InitBindings();
            InitViewDisplay();
            
        }
         void InitViewDisplay()
         {
             colEleavatorID.Caption = LanguageResource.GetDisplayString("EleavatorID");
             colEleavatorName.Caption = LanguageResource.GetDisplayString("EleavatorName");
             colEleavatorDes.Caption = LanguageResource.GetDisplayString("EleavatorDes");
             colSlaveSID.Caption = LanguageResource.GetDisplayString("DeviceID");
             colIP.Caption = LanguageResource.GetDisplayString("DeviceIP");
             colSlaveName.Caption = LanguageResource.GetDisplayString("DeviceName");

            ribbonPageGroup1.Text = LanguageResource.GetDisplayString("LiftController");
            bbiNewElevator.Caption = LanguageResource.GetDisplayString("NewElevator");
            bbiElevatorAuthority.Caption = LanguageResource.GetDisplayString("ElevatorAuthority");

            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");
            bbiDelete.Caption = LanguageResource.GetDisplayString("ToolBarDelete");


        }
        void RebindDataSource()
        {
            try
            {
                var fluentAPI = mvvmContext.OfType<ElevatorControlViewModel>();
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                   x => x.ElevatorControllerDataSet);
            }
            catch { }
        }
        void InitBindings()
         {
             var fluentAPI = mvvmContext.OfType<ElevatorControlViewModel>();

             try
             {
                 fluentAPI.SetObjectDataSourceBinding(bindingSource,
                     x => x.ElevatorControllerDataSet);

                fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
                 .SetBinding(x => x.SelectedElevator,
                     args => args.Row as ElevatorController,
                     (gView, employee) => gView.FocusedRowHandle = gView.FindRow(employee));
                fluentAPI.WithEvent<RowClickEventArgs>(gridView, "RowClick")
                            .EventToCommand(
                                x => x.Edit(null), x => x.SelectedElevator,
                                args => (args.Clicks == 2) && (args.Button == System.Windows.Forms.MouseButtons.Left));


                
                fluentAPI.BindCommand(bbiShowAuthority, x => x.ShowAuthority(null), x => x.SelectedElevator);
                fluentAPI.BindCommand(bbiEdit, x => x.Edit(null), x => x.SelectedElevator);
                fluentAPI.BindCommand(bbiDelete, x => x.DeleteElevator(null), x => x.SelectedElevator);
                fluentAPI.BindCommand(bbiClose, x => x.Close());
                fluentAPI.BindCommand(bbiNewElevator, x => x.NewElevator());
                fluentAPI.BindCommand(bbiElevatorAuthority, x => x.ElevatorAuthority()); 

                Messenger.Default.Register<RebindMessage<ElevatorControlViewModel>>(this, x => RebindDataSource());

            }
            catch (Exception ex)
             {
                 XtraMessageBox.Show(ex.Message, "KCS Error");
             }

         }
    }
}
