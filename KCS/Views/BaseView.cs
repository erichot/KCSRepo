﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using DevExpress.Utils;
namespace KCS.Views
{
    public class BaseViewControl : XtraUserControl, ISupportViewModel
    {
        
        #region ViewModel injection
        protected BaseViewControl(Type viewModelType, object viewModel)
            : this() {
            this.mvvmContext.SetViewModel(viewModelType, viewModel);
            this.BindingContext = new System.Windows.Forms.BindingContext();
            OnInitServices();
        }
        protected BaseViewControl(Type viewModelType)
            : this() {
            this.mvvmContext.ViewModelType = viewModelType;
            this.BindingContext = new System.Windows.Forms.BindingContext();
            OnInitServices();
        }
        protected BaseViewControl(Type viewModelType, object[] viewModelConstructorParameters)
            : this() {
            this.mvvmContext.ViewModelType = viewModelType;
            this.mvvmContext.ViewModelConstructorParameters = viewModelConstructorParameters;
            this.BindingContext = new System.Windows.Forms.BindingContext();
            OnInitServices();
        }
        #endregion ViewModel injection
        protected void ReleaseModule() {
            var locator = GetService<Services.IModuleLocator>();
            if(locator != null)
                locator.ReleaseModule(this);
        }
        protected void ReleaseModuleReports<TEnum>() where TEnum : struct {
            var locator = GetService<Services.IReportLocator>();
            if(locator == null) return;
            foreach(TEnum key in Enum.GetValues(typeof(TEnum)))
                locator.ReleaseReport(key);
        }
        protected virtual void OnInitServices() { }
        protected virtual void OnDisposing() { }
        protected TViewModel GetViewModel<TViewModel>() {
            return mvvmContext.GetViewModel<TViewModel>();
        }
        protected TViewModel GetParentViewModel<TViewModel>() {
            return mvvmContext.GetParentViewModel<TViewModel>();
        }
        protected TService GetService<TService>() where TService : class {
            return mvvmContext.GetService<TService>();
        }
        object ISupportViewModel.ViewModel {
            get { return mvvmContext.GetViewModel<object>(); }
        }
        void ISupportViewModel.ParentViewModelAttached() {
            OnParentViewModelAttached();
        }
        protected virtual void OnParentViewModelAttached() { }
        protected virtual void OnDelayedUIUpdate() { }
        protected virtual int GetUIUpdateDelay() {
            return 250;
        }
        System.Windows.Forms.Timer updateTimer;
        protected void QueueUIUpdate() {
            EnsureUIUpdateTimer();
            updateTimer.Stop();
            updateTimer.Start();
        }
        void EnsureUIUpdateTimer() {
            if(updateTimer == null) {
                updateTimer = new System.Windows.Forms.Timer(components);
                updateTimer.Interval = GetUIUpdateDelay();
                updateTimer.Tick += OnUIUpdate;
            }
        }
        void DestroyUIUpdateTimer() {
            if(updateTimer != null) {
                updateTimer.Tick -= OnUIUpdate;
                updateTimer.Stop();
                updateTimer.Dispose();
            }
            updateTimer = null;
        }
        void OnUIUpdate(object sender, EventArgs e) {
            updateTimer.Stop();
            OnDelayedUIUpdate();
        }
        #region for DesignTime
        BaseViewControl()
        {
            InitializeComponent();
        }
        System.ComponentModel.IContainer components;
        void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.SuspendLayout();
            this.mvvmContext.ContainerControl = this;
            this.Name = "BaseViewControl";
            this.ResumeLayout(false);
        }
        protected override void Dispose(bool disposing) {
            if(disposing) {
                DestroyUIUpdateTimer();
                if(mvvmContext.IsViewModelCreated)
                    ReleaseModule();
                OnDisposing();
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        protected DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        #endregion
    }
}
