using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Rules.ViewModel
{
    public abstract class ValueBaseViewModel<T> : BaseViewModel<T> where T : Value
    {
        public ValueBaseViewModel(T model) : base(model)
        {
        }
    }
}