using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KCS.ViewModels
{
    public class NewFingerMessage
    {
    }
    public class RebindMessage<TEntity> where TEntity : class
    {
        public RebindMessage(TEntity entity)
        {
            Entity = entity;
        }
        public RebindMessage(TEntity entity,int type)
        {
            Entity = entity;
            BindType = type;
        }
        public TEntity Entity { get; private set; }
        public int BindType { get; private set; }
    }
    public class BindDataMessage<TEntity> where TEntity : class
    {
        public BindDataMessage(TEntity entity)
        {
            Entity = entity;
        }
        public TEntity Entity { get; private set; }
    }
    public class UpdateCountMessage<TEntity> where TEntity : class
    {
        public UpdateCountMessage(TEntity entity, int count)
        {
            Entity = entity;
            RecordCount = count;
        }
        public int RecordCount { get; private set; }
        public TEntity Entity { get; private set; }
    }
    public class WaitingMessage<TEntity> where TEntity : class
    {
        public WaitingMessage(TEntity entity, bool bShow)
        {
            Entity = entity;
            IsShow = bShow;
        }
        public bool IsShow { get; private set; }
        public TEntity Entity { get; private set; }
    }
}
