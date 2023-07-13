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
using DevExpress.Utils.MVVM.Services;
using KCS.ViewModels;

namespace KCS.Views
{
    public partial class ElevatorAdd : DevExpress.XtraEditors.XtraUserControl
    {
        //public virtual Employees NewEmployee { get; set; }

        public ElevatorAdd()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            InitViewDisplay();
            if (!DesignMode)
                InitBindings();
        }
        void RebindDataSource()
        {
            var fluentAPI = mvvmContext.OfType<ElevatorAddViewModel>();
            try
            {
                
            }
            catch (Exception ex)
            {
            }
        }

        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<ElevatorAddViewModel>();

            mvvmContext.RegisterService(NotificationService.Create(alertControl));
            fluentAPI.BindCommand(bbiSave, x => x.Save());
            fluentAPI.BindCommand(bbiClose, x => x.Close());
            fluentAPI.BindCommand(bbiSaveAndClose, x => x.SaveAndClose());
            fluentAPI.BindCommand(bbiSaveAndNew, x => x.SaveAndNew());

            try
            {
              fluentAPI.SetObjectDataSourceBinding(bindingSourceDevice,
              x => x.DeviceInfoDataSet);
               fluentAPI.SetObjectDataSourceBinding(bindingSource, x => x.NewElevator);
            }
            catch { }

            
        }
        void InitViewDisplay()
        {
            ribbonPageGroupSave.Text = LanguageResource.GetDisplayString("ToolBarGroupSave");
            ribbonPageGroupClose.Text = LanguageResource.GetDisplayString("ToolBarGroupClose");
            bbiSave.Caption = LanguageResource.GetDisplayString("ToolBarSave");
            bbiSaveAndClose.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndClose");
            bbiSaveAndNew.Caption = LanguageResource.GetDisplayString("ToolBarSaveAndNew");
           
            bbiClose.Caption = LanguageResource.GetDisplayString("ToolBarClose");

            ItemForEleavatorName.Text = LanguageResource.GetDisplayString("EleavatorName");
            ItemForEleavatorDes.Text = LanguageResource.GetDisplayString("EleavatorDes");
            ItemForSlaveSID.Text = LanguageResource.GetDisplayString("DeviceID");

        }

     }
}
