using System;
using System.Windows.Input;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    public abstract class ValueBasedRuleViewModel<T> : RuleBaseViewModel<T> where T: ValueBasedRule
    {
        public ValueBasedRuleViewModel(T model) : base(model)
        {
            var conditionBinding = CreatePropertyBinding(() => Value, () => Model.Value);
            SetValueCommand = new RelayCommand<Type>(type => conditionBinding.Set(type));
        }

        private IModel<Value> m_value;

        public IModel<Value> Value
        {
            get { return m_value ?? (m_value = RuleModelFactory.CreateModel(Model.Value, m => Changed())); }
            set
            {
                if (m_value != value)
                {
                    m_value = value;
                    NotifyOfPropertyChange(() => Value);
                    Changed();
                }
            }
        }

        public ICommand SetValueCommand { get; }
    }
}