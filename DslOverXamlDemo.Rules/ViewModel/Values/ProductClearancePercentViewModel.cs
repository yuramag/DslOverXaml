using System;
using System.Windows.Input;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ProductClearancePercent), "Product Clearance Percent")]
    public sealed class ProductClearancePercentViewModel : ValueBaseViewModel<ProductClearancePercent>
    {
        public ProductClearancePercentViewModel(ProductClearancePercent model) : base(model)
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
                    m_defaultValue = value;
                    NotifyOfPropertyChange(() => DefaultValue);
                    Changed();
                }
            }
        }

        public ICommand SetDefaultValueCommand { get; }
    }
}