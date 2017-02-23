using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(AnyMatch), "Any Match")]
    public sealed class AnyMatchViewModel : ConditionSetViewModel<AnyMatch>
    {
        public AnyMatchViewModel(AnyMatch model) : base(model)
        {
        }
    }
}