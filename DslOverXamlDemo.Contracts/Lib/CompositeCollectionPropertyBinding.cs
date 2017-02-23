using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DslOverXamlDemo.Contracts.Lib
{
    public sealed class CompositeCollectionPropertyBinding<TProp>
    {
        private readonly IViewModel m_viewModel;
        private readonly Action m_onChange;
        private readonly Expression<Func<ICollection<IModel<TProp>>>> m_property;
        private readonly Expression<Func<ICollection<TProp>>> m_modelProperty;
        
        public CompositeCollectionPropertyBinding(IViewModel viewModel, Action onChange, Expression<Func<ICollection<IModel<TProp>>>> property, Expression<Func<ICollection<TProp>>> modelProperty)
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

        private static void AddToCollection<TValue>(object instance, Expression<Func<ICollection<TValue>>> property, TValue value)
        {
            var expr = property.Body as MemberExpression;
            if (expr == null)
                throw new InvalidOperationException("Invalid property type");
            var collection = (ICollection<TValue>)instance.GetType().GetProperty(expr.Member.Name).GetValue(instance);
            collection.Add(value);
        }

        private static void RemoveFromCollection<TValue>(object instance, Expression<Func<ICollection<TValue>>> property, TValue value)
        {
            var expr = property.Body as MemberExpression;
            if (expr == null)
                throw new InvalidOperationException("Invalid property type");

            var collection = (ICollection<TValue>)instance.GetType().GetProperty(expr.Member.Name).GetValue(instance);
            collection.Remove(value);
        }

        private static void RemoveFromCollection<TValue>(object instance, Expression<Func<ICollection<IModel<TValue>>>> property, TValue value)
        {
            var expr = property.Body as MemberExpression;
            if (expr == null)
                throw new InvalidOperationException("Invalid property type");

            var collection = (ICollection<IModel<TValue>>) instance.GetType().GetProperty(expr.Member.Name).GetValue(instance);
            var item = collection.FirstOrDefault(x => EqualityComparer<TValue>.Default.Equals(x.ViewModel.Model, value));
            if (item != null)
                collection.Remove(item);
        }

        private static void ClearCollection<TValue>(object instance, Expression<Func<ICollection<TValue>>> property)
        {
            var expr = property.Body as MemberExpression;
            if (expr == null)
                throw new InvalidOperationException("Invalid property type");

            var collection = (ICollection<TValue>)instance.GetType().GetProperty(expr.Member.Name).GetValue(instance);
            collection.Clear();
        }

        public void Add(TProp value)
        {
            AddToCollection(m_viewModel.Model, m_modelProperty, value);
            SetPropertyValue(m_viewModel, m_property, null);
            m_onChange();
        }

        public void Add(Type type)
        {
            if (!typeof(TProp).IsAssignableFrom(type))
                throw new InvalidOperationException("Invalid property type");

            var value = (TProp)Activator.CreateInstance(type);
         
            AddToCollection(m_viewModel.Model, m_modelProperty, value);
            SetPropertyValue(m_viewModel, m_property, null);

            m_onChange();
        }

        public void Remove(TProp value)
        {
            RemoveFromCollection(m_viewModel.Model, m_modelProperty, value);
            RemoveFromCollection(m_viewModel, m_property, value);
            m_onChange();
        }

        public void Clear()
        {
            ClearCollection(m_viewModel.Model, m_modelProperty);
            ClearCollection(m_viewModel, m_property);
            m_onChange();
        }
    }
}