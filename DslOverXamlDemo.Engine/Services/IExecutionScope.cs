using System;

namespace DslOverXamlDemo.Engine.Services
{
    public interface IExecutionScope : IDisposable
    {
        void Break();
        bool IsBreakRequested { get; }
    }
}