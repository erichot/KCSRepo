using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using KCS.Models;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class ChangeCardIDViewModel
    {
        
        public virtual string NewCardId { get; set; }
        public static ChangeCardIDViewModel Create()
        {
            return ViewModelSource.Create(() => new ChangeCardIDViewModel());
        }
        public static ChangeCardIDViewModel Create(Employees employee)
        {

            return ViewModelSource.Create(() => new ChangeCardIDViewModel(employee));
        }
        public virtual Employees EditEmployee { get; set; }
        protected ChangeCardIDViewModel()
        {
            NewCardId = "";
            EditEmployee = new Employees();
        }
        protected ChangeCardIDViewModel(Employees employee)
        {
            NewCardId = "";
            EditEmployee = new Employees(employee);
            
        }
    }
}