using System;
using System.Linq.Expressions;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DslOverXamlDemo.Contracts.Lib
{
    public abstract class ChangeableEx : Changeable, IDisposable
    {
        private ISubject<string> m_propertyObserver;
        private ISubject<string> PropertyObserver => m_propertyObserver ?? (m_propertyObserver = new Subject<string>());

        private CompositeDisposable m_disposables;
        protected CompositeDisposable Disposables => m_disposables ?? (m_disposables = new CompositeDisposable());

        private bool m_disposed;

        public void Dispose()
        {
            if (!m_disposed)
            {
                m_disposed = true;
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_disposables != null)
                {
                    m_disposables.Dispose();
                    m_disposables = null;
                }
            }
        }

        public void SchedulePropertyChange(string property)
        {
            m_propertyObserver.OnNext(property);
        }

        public void SchedulePropertyChange<TProp>(Expression<Func<TProp>> property)
        {
            SchedulePropertyChange(property.Name);
        }

        public IObservable<string> ObservePropertyChange(string property)
        {
            return PropertyObserver.Where(p => p == property);
        }

        public IObservable<string> ObservePropertyChange<TProp>(Expression<Func<TProp>> property)
        {
            return ObservePropertyChange(property.Name);
        }
    }
}