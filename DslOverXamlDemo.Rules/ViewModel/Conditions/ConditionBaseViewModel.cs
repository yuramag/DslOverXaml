using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Rules.ViewModel
{
    public abstract class ConditionBaseViewModel<T> : BaseViewModel<T> where T : Condition
    {
        public ConditionBaseViewModel(T model) : base(model)
        {
        }
    }
}