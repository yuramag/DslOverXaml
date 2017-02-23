using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(True), "True")]
    public sealed class TrueViewModel : ConditionBaseViewModel<True>
    {
        public TrueViewModel(True model) : base(model)
        {
        }
    }
}