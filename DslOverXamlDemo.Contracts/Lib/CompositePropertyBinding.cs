using System;
using System.Linq.Expressions;

namespace DslOverXamlDemo.Contracts.Lib
{
    public sealed class CompositePropertyBinding<TProp>
    {
        private readonly IViewModel m_viewModel;
        private readonly Action m_onChange;
        private readonly Expression<Func<IModel<TProp>>> m_property;
        private readonly Expression<Func<TProp>> m_modelProperty;

        public CompositePropertyBinding(IViewModel viewModel, Action onChange, Expression<Func<IModel<TProp>>> property, Expression<Func<TProp>> modelProperty)
        {
            m_viewModel = viewModel;
            m_onChange = onChange;
            m_property = property;
            m_modelProperty = modelProperty;
        }

        private static void SetPropertyValue<TValue>(object instance, Expression<Func<TValue>> property, TValue value)
        {
            var expr = property.Body as MemberExpression;
            if (expr == null)
                throw new InvalidOperationException("Invalid property type");
            instance.GetType().GetProperty(expr.Member.Name).SetValue(instance, value);
        }

        public void Set(TProp value)
        {
            SetPropertyValue(m_viewModel.Model, m_modelProperty, value);
            SetPropertyValue(m_viewModel, m_property, null);
            m_onChange();
        }

        public void Set(Type type)
        {
            if (type != null && !typeof(TProp).IsAssignableFrom(type))
                throw new InvalidOperationException("Invalid property type");

            var value = type == null ? default(TProp) : (TProp) Activator.CreateInstance(type);

            SetPropertyValue(m_viewModel.Model, m_modelProperty, value);
            SetPropertyValue(m_viewModel, m_property, null);

            m_onChange();
        }
    }
}