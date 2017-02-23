using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace DslOverXamlDemo.Contracts.Lib
{
    public abstract class Changeable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));
            PropertyChanged?.Invoke(this, args);
        }

        protected void NotifyOfPropertyChange(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentNullException(nameof(propertyName));
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public void NotifyOfPropertyChange<TProp>(Expression<Func<TProp>> property)
        {
            NotifyOfPropertyChange(GetPropertyName(property));
        }

        protected bool UpdateProperty<TProp>(string propertyName, ref TProp propertyValue, TProp value)
        {
            if (EqualityComparer<TProp>.Default.Equals(propertyValue, value))
                return false;
            propertyValue = value;
            NotifyOfPropertyChange(propertyName);
            return true;
        }

        public string GetPropertyName<TProp>(Expression<Func<TProp>> property)
        {
            var expr = property.Body as MemberExpression;
            if (expr == null)
                throw new InvalidOperationException("Invalid property type");
            return expr.Member.Name;
        }

        public event EventHandler OnModified;

        protected void Changed()
        {
            IsModified = true;
            OnModified?.Invoke(this, EventArgs.Empty);
        }

        private bool m_isModified;

        public bool IsModified
        {
            get { return m_isModified; }
            set
            {
                if (m_isModified != value)
                {
                    m_isModified = value;
                    NotifyOfPropertyChange(() => IsModified);
                }
            }
        }

        protected void LogError(Exception ex)
        {
            EventAggregator.Instance.Publish(new MessageEvent(ex));
        }

        protected void LogWarning(string message)
        {
            EventAggregator.Instance.Publish(new MessageEvent(MessageEventType.Warning, message));
        }

        protected void LogInfo(string message)
        {
            EventAggregator.Instance.Publish(new MessageEvent(MessageEventType.Info, message));
        }

        protected void LogOnError(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }
    }
}