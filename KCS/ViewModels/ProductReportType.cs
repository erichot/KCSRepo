using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace KCS.ViewModels
{
    public enum ProductReportType
    {
        None,
        [Display(Name = "Order Detail")]
        OrderDetail,
        [Display(Name = "Sales Summary Report")]
        SalesSummary,
        [Display(Name = "Specification Summary Report")]
        SpecificationSummary,
        [Display(Name = "Top Salesperson Report")]
        TopSalesperson
    }
}
