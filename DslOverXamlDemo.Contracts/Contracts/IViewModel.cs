using System;

namespace DslOverXamlDemo.Contracts
{
    public interface IViewModel
    {
        object Model { get; }
        string Description { get; }
        event EventHandler OnModified;
    }

    public interface IViewModel<out T> : IViewModel
    {
        new T Model { get; }
    }
}