using System;
using System.Collections.Generic;
using DslOverXamlDemo.Contracts;

namespace DslOverXamlDemo.Rules.Model
{
    public static class RuleModelFactory
    {
        private sealed class Model<T> : IModel<T>
        {
            public Model(T value, string description, IViewModel<T> viewModel, object tag = null)
            {
                Tag = tag;
                Value = value;
                Description = description;
                ViewModel = viewModel;
            }

            public T Value { get; }

            public bool HasValue => !EqualityComparer<T>.Default.Equals(Value, default(T));

            public object Tag { get; }

            public Type GetValueType()
            {
                return typeof(T);
            }

            public string Description { get; }

            public IViewModel<T> ViewModel { get; }

            public void Change()
            {
                OnModified?.Invoke(this, null);
            }

            public event EventHandler OnModified;
        }

        public static IModel<T> CreateModel<T>(Type type, Action<IModel<T>> onChange, object tag = null)
        {
            return CreateModel((T) Activator.CreateInstance(type), onChange, tag);
        }

        public static IModel<T> CreateModel<T>(T value, Action<IModel<T>> onChange, object tag = null)
        {
            if (EqualityComparer<T>.Default.Equals(value, default(T)))
                return new Model<T>(default(T), "<Null>", null);

            var type = value.GetType();

            var metadata = ModelMetadataManager.GetModelMetadata(type);
            if (metadata == null)
                throw new InvalidOperationException($"Type not supported: {type}");

            var viewModel = (IViewModel<T>) Activator.CreateInstance(metadata.ViewModelType, value);

            var result = new Model<T>(value, metadata.Description, viewModel, tag);

            viewModel.OnModified += (sender, args) => result.Change();

            if (onChange != null)
                result.OnModified += (sender, args) => onChange(result);

            return result;
        }
    }
}