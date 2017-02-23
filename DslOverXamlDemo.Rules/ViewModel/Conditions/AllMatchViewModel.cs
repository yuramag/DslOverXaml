using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(AllMatch), "All Match")]
    public sealed class AllMatchViewModel : ConditionSetViewModel<AllMatch>
    {
        public AllMatchViewModel(AllMatch model) : base(model)
        {
        }
    }
}