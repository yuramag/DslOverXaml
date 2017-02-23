using System;

namespace DslOverXamlDemo.Contracts
{
    public interface IModel
    {
        string Description { get; }

        object Tag { get; }

        Type GetValueType();

        event EventHandler OnModified;
    }

    public interface IModel<out T> : IModel
    {
        T Value { get; }

        bool HasValue { get; }

        IViewModel<T> ViewModel { get; }
    }
}
