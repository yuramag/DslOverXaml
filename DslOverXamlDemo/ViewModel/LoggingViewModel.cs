using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;

namespace DslOverXamlDemo.ViewModel
{
    public sealed class LoggingViewModel : ChangeableEx
    {
        public LoggingViewModel()
        {
            Disposables.Add(EventAggregator.Instance.GetEventStream<CommandException>().ObserveOnDispatcher().Subscribe(e => EventAggregator.Instance.Publish(new MessageEvent(e.Exception))));
            Disposables.Add(EventAggregator.Instance.GetEventStream<MessageEvent>().ObserveOnDispatcher().Subscribe(e => LogItems.Insert(0, e)));
        }

        public ObservableCollection<MessageEvent> LogItems { get; } = new ObservableCollection<MessageEvent>();
    }
}