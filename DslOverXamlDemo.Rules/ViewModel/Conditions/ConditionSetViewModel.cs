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
    public abstract class ConditionSetViewModel<T> : ConditionBaseViewModel<T> where T : ConditionSet
    {
        public ConditionSetViewModel(T model) : base(model)
        {
            var conditionsBinding = CreateCollectionBinding(() => Conditions, () => Model.Conditions);

            AddConditionCommand = new RelayCommand<Type>(type => conditionsBinding.Add(type), type => type != null);
            ClearConditionsCommand = new RelayCommand(() => conditionsBinding.Clear(), () => Conditions.Count > 0);
            DeleteConditionCommand = new RelayCommand<Condition>(item => conditionsBinding.Remove(item), item => item != null);
        }

        private ObservableCollection<IModel<Condition>> m_conditions;

        public ObservableCollection<IModel<Condition>> Conditions
        {
            get { return m_conditions ?? (m_conditions = new ObservableCollection<IModel<Condition>>(Model.Conditions.Select(x => RuleModelFactory.CreateModel(x, m => Changed())))); }
            set
            {
                if (m_conditions != value)
                {
                    m_conditions = value;
                    NotifyOfPropertyChange(() => Conditions);
                    Changed();
                }
            }
        }

        public ICommand AddConditionCommand { get; }

        public ICommand ClearConditionsCommand { get; }

        public ICommand DeleteConditionCommand { get; }
    }
}