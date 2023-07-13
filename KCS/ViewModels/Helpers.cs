using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Mvvm;
using KCS.Views;

namespace KCS.ViewModels
{
    public static class ViewModelHelper
    {
        public static TViewModel GetParentViewModel<TViewModel>(object viewModel)
        {
            ISupportParentViewModel parentViewModelSupport = viewModel as ISupportParentViewModel;
            if (parentViewModelSupport != null)
                return (TViewModel)parentViewModelSupport.ParentViewModel;
            return default(TViewModel);
        }
        public static void EnsureModuleViewModel(object module, object parentViewModel, object parameter = null)
        {
            ISupportViewModel vm = module as ISupportViewModel;
            if (vm != null)
            {
                object oldParentViewModel = null;
                ISupportParentViewModel parentViewModelSupport = vm.ViewModel as ISupportParentViewModel;
                if (parentViewModelSupport != null)
                    oldParentViewModel = parentViewModelSupport.ParentViewModel;
                EnsureViewModel(vm.ViewModel, parentViewModel, parameter);
                if (oldParentViewModel != parentViewModel)
                    vm.ParentViewModelAttached();
            }
        }
        public static void EnsureViewModel(object viewModel, object parentViewModel, object parameter = null)
        {
            ISupportParentViewModel parentViewModelSupport = viewModel as ISupportParentViewModel;
            if (parentViewModelSupport != null)
                parentViewModelSupport.ParentViewModel = parentViewModel;
            ISupportParameter parameterSupport = viewModel as ISupportParameter;
            if (parameterSupport != null && parameter != null)
                parameterSupport.Parameter = parameter;
        }
    }
  
}
