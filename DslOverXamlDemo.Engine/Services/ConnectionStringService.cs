using System;
using System.Collections.Generic;

namespace DslOverXamlDemo.Engine.Services
{
    public sealed class ConnectionStringService : IConnectionStringService
    {
        private readonly IDictionary<string, string> m_connectionStrings = new Dictionary<string, string>();

        public ConnectionStringService(string defaultConnectionString)
        {
            m_connectionStrings[string.Empty] = defaultConnectionString;
        }

        public void AddConnectionString(string name, string value)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            m_connectionStrings[name] = value;
        }

        public string GetConnectionString()
        {
            return GetConnectionString(null);
        }

        public string GetConnectionString(string name)
        {
            return m_connectionStrings.TryGetValue(name ?? string.Empty, out var result) ? result : null;
        }
    }
}