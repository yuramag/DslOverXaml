using System;
using System.Collections.Generic;
using DslOverXamlDemo.Engine.Services;

namespace DslOverXamlDemo.Engine.Context
{
    public class Context : IContext
    {
        private readonly Dictionary<Type, Func<object>> m_services = new Dictionary<Type, Func<object>>();
        private readonly IExecutionControlService m_executionControlService = new ExecutionControlService();

        public Context()
        {
            AddService(typeof(IExecutionControlService), () => m_executionControlService);
        }

        public void AddService(Type type, Func<object> factory)
        {
            m_services[type] = factory;
        }

        public bool HasService(Type type)
        {
            return m_services.ContainsKey(type);
        }

        public object GetService(Type type)
        {
            if (!m_services.TryGetValue(type, out Func<object> factory))
                throw new InvalidOperationException($"Service of type '{type.Name}' not found");
            return factory();
        }
    }
}