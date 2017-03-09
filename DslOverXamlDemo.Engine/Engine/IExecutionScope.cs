using System;

namespace DslOverXamlDemo.Engine
{
    public interface IExecutionScope : IDisposable
    {
        void Break();
        bool IsBreakRequested { get; }
    }
}