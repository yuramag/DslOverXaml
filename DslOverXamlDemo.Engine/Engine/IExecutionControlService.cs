using System;

namespace DslOverXamlDemo.Engine
{
    public interface IExecutionControlService
    {
        IDisposable CreateExecutionScope();
        IExecutionScope CurrentScope { get; }
        void Stop();
        bool IsStopRequested { get; }
    }
}