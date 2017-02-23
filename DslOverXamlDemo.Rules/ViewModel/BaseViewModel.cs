using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    public abstract class BaseViewModel<T> : ChangeableEx, IViewModel<T>
    {
        public BaseViewModel(T model)
        {
            Model = model;
            Description = ModelMetadataManager.GetModelMetadata<T>()?.Description;
        }

        public T Model { get; }

        object IViewModel.Model => Model;

        public string Description { get; }

        protected CompositePropertyBinding<TProp> CreatePropertyBinding<TProp>(Expression<Func<IModel<TProp>>> property, Expression<Func<TProp>> modelProperty)
        {
            return new CompositePropertyBinding<TProp>(this, Changed, x => RuleModelFactory.CreateModel(x, m => Changed()), property, modelProperty);
        }

        protected CompositeCollectionPropertyBinding<TProp> CreateCollectionBinding<TProp>(Expression<Func<ICollection<IModel<TProp>>>> property, Expression<Func<ICollection<TProp>>> modelProperty)
        {
            return new CompositeCollectionPropertyBinding<TProp>(this, Changed, x => RuleModelFactory.CreateModel(x, m => Changed()), property, modelProperty);
        }
    }
}