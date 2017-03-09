using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(Break), "Break")]
    public sealed class BreakViewModel : RuleBaseViewModel<Break>
    {
        public BreakViewModel(Break model) : base(model)
        {
        }
    }
}