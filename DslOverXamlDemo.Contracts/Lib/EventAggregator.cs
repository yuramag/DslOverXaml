using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DslOverXamlDemo.Contracts.Lib
{
    public interface IEventAggregator
    {
        IObservable<T> GetEventStream<T>();
        void Publish<T>(T payload);
    }

    public class EventAggregator : IEventAggregator
    {
        public static readonly EventAggregator Instance = new EventAggregator();

        private readonly IDictionary<Type, Tuple<object, object>> m_observables = new ConcurrentDictionary<Type, Tuple<object, object>>();

        public IObservable<T> GetEventStream<T>()
        {
            Tuple<object, object> tuple;

            if (m_observables.TryGetValue(typeof(T), out tuple))
                return (IObservable<T>)tuple.Item2;

            var subject = new Subject<T>();

            var stream = Observable
                .Create<T>(observer => new CompositeDisposable(subject.Subscribe(observer), Disposable.Create(() => m_observables.Remove(typeof(T)))))
                .Publish()
                .RefCount();

            tuple = new Tuple<object, object>(subject, stream);

            m_observables.Add(typeof(T), tuple);

            return stream;
        }

        public void Publish<T>(T payload)
        {
            Tuple<object, object> tuple;
            if (m_observables.TryGetValue(typeof(T), out tuple))
                ((ISubject<T>)tuple.Item1).OnNext(payload);
        }
    }
}