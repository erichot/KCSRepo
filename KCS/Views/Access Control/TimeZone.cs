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
using KCS.ViewModels;
using DevExpress.Mvvm;
using DevExpress.XtraGrid.Views.Base;
using KCS.Models;

namespace KCS.Views
{
    public partial class TimeZone : DevExpress.XtraEditors.XtraUserControl
    {
        public TimeZone()
        {
            InitializeComponent();
        }
        protected override void OnLoad(System.EventArgs e)
        {

            base.OnLoad(e);

            if (!DesignMode)
                InitBindings();
            InitViewDisplay();

        }
        void InitViewDisplay()
        {
            colTimeZoneID.Caption = LanguageResource.GetDisplayString("SystemCode");
            colFrame01.Caption = LanguageResource.GetDisplayString("FirstFrame");
            colFrame02.Caption = LanguageResource.GetDisplayString("SecondFrame");
            colFrame03.Caption = LanguageResource.GetDisplayString("ThirdFrame");
            colFrame04.Caption = LanguageResource.GetDisplayString("FourthFrame");
            colDescription.Caption = LanguageResource.GetDisplayString("DescriptionText");
            gridView.BestFitColumns();
        }
        void InitBindings()
        {
            var fluentAPI = mvvmContext.OfType<TimeZoneViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.AcTimeZoneDataSet);
                fluentAPI.SetObjectDataSourceBinding(bindingSourceTimeFrame,
                x => x.TimeSetDataSet);
                
            }
            catch { }
            fluentAPI.WithEvent<RowObjectEventArgs>(gridView, "RowUpdated")
           .EventToCommand(x => x.Save(null), new Func<RowObjectEventArgs, object>(e => e.Row));
            Messenger.Default.Register<RebindMessage<TimeZoneViewModel>>(this, x => RebindDataSource());
            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView, "FocusedRowObjectChanged")
               .SetBinding(x => x.SelectedAcTimeZone,
                   args => args.Row as AcTimeZone,
                   (gView, slaveCategory) => gView.FocusedRowHandle = gView.FindRow(slaveCategory));
        }
        void RebindDataSource()
        {
            var fluentAPI = mvvmContext.OfType<TimeSetViewModel>();
            try
            {
                fluentAPI.SetObjectDataSourceBinding(bindingSource,
                x => x.TimeSetDataSet);
            }
            catch { }
        }
    }
}
