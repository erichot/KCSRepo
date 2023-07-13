using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KCS.ViewModels
{
    abstract public class KcsDocument : IDocumentContent
    {
        object title = " ";

        protected virtual bool TryClose()
        {

            return true;
        }
        public object Title { get { return title; } }
        protected IDocumentOwner DocumentOwner { get; private set; }

        protected virtual void OnDestroy()
        {
            Messenger.Default.Unregister(this);
        }
        
         public  void Close()
        {
            if (!TryClose())
                return;
            if (DocumentOwner != null)
                DocumentOwner.Close(this);
        }       

        #region IDocumentContent
        object IDocumentContent.Title { get { return Title; } }

        void IDocumentContent.OnClose(CancelEventArgs e)
        {
            e.Cancel = !TryClose();
        }

        void IDocumentContent.OnDestroy()
        {
            OnDestroy();
        }

        IDocumentOwner IDocumentContent.DocumentOwner
        {
            get { return DocumentOwner; }
            set { DocumentOwner = value; }
        }
        #endregion
    }
}
