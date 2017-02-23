using System;
using System.Windows.Input;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ConditionRule), "Rule with Condition")]
    public sealed class ConditionRuleViewModel : RuleBaseViewModel<ConditionRule>
    {
        public ConditionRuleViewModel(ConditionRule model) : base(model)
        {
            var conditionBinding = CreatePropertyBinding(() => Condition, () => Model.Condition);
            SetConditionCommand = new RelayCommand<Type>(type => conditionBinding.Set(type));

            var ruleBinding = CreatePropertyBinding(() => Rule, () => Model.Rule);
            SetRuleCommand = new RelayCommand<Type>(type => ruleBinding.Set(type));
        }

        private IModel<Condition> m_condition;

        public IModel<Condition> Condition
        {
            get { return m_condition ?? (m_condition = RuleModelFactory.CreateModel(Model.Condition, m => Changed())); }
            set
            {
                if (m_condition != value)
                {
                    m_condition = null;
                    NotifyOfPropertyChange(() => Condition);
                    Changed();
                }
            }
        }

        private IModel<Rule> m_rule;

        public IModel<Rule> Rule
        {
            get { return m_rule ?? (m_rule = RuleModelFactory.CreateModel(Model.Rule, m => Changed())); }
            set
            {
                if (m_rule != value)
                {
                    m_rule = null;
                    NotifyOfPropertyChange(() => Rule);
                    Changed();
                }
            }
        }

        public ICommand SetConditionCommand { get; }

        public ICommand SetRuleCommand { get; }
    }
}