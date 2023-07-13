using System;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace KCS.ViewModels
{
    [POCOViewModel]
    public class UserGroupSetViewModel
    {
        private int UserGroup;
        public static UserGroupSetViewModel Create()
        {
            return ViewModelSource.Create(() => new UserGroupSetViewModel());
        }
        public static UserGroupSetViewModel Create(int UserGroup)
        {
            return ViewModelSource.Create(() => new UserGroupSetViewModel(UserGroup));
        }
        public UserGroupSetViewModel()
        {
        }
        public UserGroupSetViewModel(int UserGroup)
        {
            this.UserGroup = UserGroup;
        }
    }
}