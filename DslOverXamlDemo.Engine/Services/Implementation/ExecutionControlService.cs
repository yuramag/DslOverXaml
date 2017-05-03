using System;
using System.Collections.Generic;

namespace DslOverXamlDemo.Engine.Services
{
    internal sealed class ExecutionControlService : IExecutionControlService
    {
        private sealed class ExecutionScope : IExecutionScope
        {
            private readonly Action<IExecutionScope> m_onDispose;
            private bool m_isDisposed;
            private bool m_isBreakRequested;
            
            public ExecutionScope(Action<IExecutionScope> onDispose)
            {
                m_onDispose = onDispose;
            }

            public void Dispose()
            {
                if (!m_isDisposed)
                {
                    m_onDispose?.Invoke(this);
                    m_isDisposed = true;
                }
            }

            public void Break()
            {
                m_isBreakRequested = true;
            }

            public bool IsBreakRequested => m_isBreakRequested;
        }

        private readonly Stack<IExecutionScope> m_scopes = new Stack<IExecutionScope>();
        private bool m_isStopRequested;

        public IDisposable CreateExecutionScope()
        {
            var scope = new ExecutionScope(x => m_scopes.Pop());
            m_scopes.Push(scope);
            return scope;
        }

        public IExecutionScope CurrentScope => m_scopes.Peek();

        public void Stop()
        {
            m_isStopRequested = true;
        }

        public bool IsStopRequested => m_isStopRequested;
    }
}