using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.Views
{
    using DevExpress.XtraBars.Ribbon;

    public interface IRibbonModule
    {
        RibbonControl Ribbon { get; }
    }
    public interface ISupportViewModel
    {
        object ViewModel { get; }
        void ParentViewModelAttached();
    }
}
