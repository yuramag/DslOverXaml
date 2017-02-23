using System;
using System.Windows.Input;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ProductTodaysPrice), "Product Today's Price")]
    public sealed class ProductTodaysPriceViewModel : ValueBaseViewModel<ProductTodaysPrice>
    {
        public ProductTodaysPriceViewModel(ProductTodaysPrice model) : base(model)
        {
            var defaultValueBinding = CreatePropertyBinding(() => DefaultValue, () => Model.DefaultValue);
            SetDefaultValueCommand = new RelayCommand<Type>(type => defaultValueBinding.Set(type));
        }

        private IModel<Value> m_defaultValue;

        public IModel<Value> DefaultValue
        {
            get { return m_defaultValue ?? (m_defaultValue = RuleModelFactory.CreateModel(Model.DefaultValue, m => Changed())); }
            set
            {
                if (m_defaultValue != value)
                {
                    m_defaultValue = null;
                    NotifyOfPropertyChange(() => DefaultValue);
                    Changed();
                }
            }
        }

        public ICommand SetDefaultValueCommand { get; }
    }
}