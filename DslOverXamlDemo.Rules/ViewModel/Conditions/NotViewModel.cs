using System;
using System.Windows.Input;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(Not), "Not")]
    public sealed class NotViewModel : ConditionBaseViewModel<Not>
    {
        public NotViewModel(Not model) : base(model)
        {
            var conditionBinding = CreatePropertyBinding(() => Condition, () => Model.Condition);
            SetConditionCommand = new RelayCommand<Type>(type => conditionBinding.Set(type));
        }

        private IModel<Condition> m_condition;

        public IModel<Condition> Condition
        {
            get { return m_condition ?? (m_condition = RuleModelFactory.CreateModel(Model.Condition, m => Changed())); }
            set
            {
                if (m_condition != null)
                {
                    m_condition = null;
                    NotifyOfPropertyChange(() => Condition);
                    Changed();
                }
            }
        }

        public ICommand SetConditionCommand { get; }
    }
}