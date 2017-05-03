using System;

namespace DslOverXamlDemo.Engine.Context
{
    public interface IContext
    {
        void AddService(Type type, Func<object> factory);
        bool HasService(Type type);
        object GetService(Type type);
    }
}