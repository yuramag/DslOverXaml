using System;
using System.Collections.Generic;

namespace DslOverXamlDemo.Engine
{
    public class Context : IContext
    {
        private readonly Dictionary<Type, Func<object>> m_services = new Dictionary<Type, Func<object>>();

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
            Func<object> factory;
            if (!m_services.TryGetValue(type, out factory))
                throw new InvalidOperationException($"Service of type '{type.Name}' not found");
            return factory();
        }
    }
}