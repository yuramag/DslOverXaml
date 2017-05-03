using System;

namespace DslOverXamlDemo.Engine.Services
{
    public interface IExecutionControlService
    {
        IDisposable CreateExecutionScope();
        IExecutionScope CurrentScope { get; }
        void Stop();
        bool IsStopRequested { get; }
    }
}