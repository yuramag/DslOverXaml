using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(False), "False")]
    public sealed class FalseViewModel : ConditionBaseViewModel<False>
    {
        public FalseViewModel(False model) : base(model)
        {
        }
    }
}