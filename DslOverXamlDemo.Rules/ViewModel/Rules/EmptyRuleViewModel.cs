using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(EmptyRule), "Empty Rule")]
    public sealed class EmptyRuleViewModel : RuleBaseViewModel<EmptyRule>
    {
        public EmptyRuleViewModel(EmptyRule model) : base(model)
        {
        }
    }
}