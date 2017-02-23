using System;
using System.Windows.Input;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    public sealed class RuleDesigner : ChangeableEx
    {
        private IModel<Rule> m_model;

        public RuleDesigner()
            : this(null)
        {
        }

        public RuleDesigner(string xaml)
        {
            var rule = string.IsNullOrEmpty(xaml) ? null : SimpleXamlSerializer.FromXaml<Rule>(xaml);
            m_model = RuleModelFactory.CreateModel(rule, m => Changed());
        }

        public IModel<Rule> Model => m_model;

        private ICommand m_setRuleCommand;

        public ICommand SetRuleCommand
        {
            get
            {
                return m_setRuleCommand ?? (m_setRuleCommand = new RelayCommand<Type>(type =>
                {
                    if (m_model?.Value?.GetType() != type)
                    {
                        var rule = type == null ? null : (Rule) Activator.CreateInstance(type);
                        m_model = RuleModelFactory.CreateModel(rule, m => Changed());
                        NotifyOfPropertyChange(() => Model);
                        Changed();
                    }
                }));
            }
        }
    }
}