using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(Stop), "Stop")]
    public sealed class StopViewModel : RuleBaseViewModel<Stop>
    {
        public StopViewModel(Stop model) : base(model)
        {
        }
    }
}