using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Rules.ViewModel
{
    public abstract class RuleBaseViewModel<T> : BaseViewModel<T> where T : Rule
    {
        public RuleBaseViewModel(T model) : base(model)
        {
        }

        public string Name
        {
            get { return Model.Name; }
            set
            {
                if (Model.Name != value)
                {
                    Model.Name = value;
                    NotifyOfPropertyChange(() => Name);
                    Changed();
                }
            }
        }
    }
}