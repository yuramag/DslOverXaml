using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(RuleSet), "Set of Rules")]
    public sealed class RuleSetViewModel : RuleBaseViewModel<RuleSet>
    {
        public RuleSetViewModel(RuleSet model) : base(model)
        {
            var rulesBinding = CreateCollectionBinding(() => Rules, () => Model.Rules);

            AddRuleCommand = new RelayCommand<Type>(type => rulesBinding.Add(type), type => type != null);
            ClearRulesCommand = new RelayCommand(() => rulesBinding.Clear(), () => Rules.Count > 0);
            DeleteRuleCommand = new RelayCommand<Rule>(item => rulesBinding.Remove(item), item => item != null);
        }

        private ObservableCollection<IModel<Rule>> m_rules;

        public ObservableCollection<IModel<Rule>> Rules
        {
            get { return m_rules ?? (m_rules = new ObservableCollection<IModel<Rule>>(Model.Rules.Select(x => RuleModelFactory.CreateModel(x, m => Changed())))); }
            set
            {
                if (m_rules != value)
                {
                    m_rules = value;
                    NotifyOfPropertyChange(() => Rules);
                    Changed();
                }
            }
        }

        public ICommand AddRuleCommand { get; }

        public ICommand ClearRulesCommand { get; }

        public ICommand DeleteRuleCommand { get; }
    }
}