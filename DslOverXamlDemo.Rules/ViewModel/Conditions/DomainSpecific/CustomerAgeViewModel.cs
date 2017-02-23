using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(CustomerAge), "Customer Age")]
    public sealed class CustomerAgeViewModel : RangeConditionViewModel<CustomerAge, int>
    {
        public CustomerAgeViewModel(CustomerAge model) : base(model)
        {
        }
    }
}