using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ApplyPercentDiscount), "Apply Percent Discount")]
    public sealed class ApplyPercentDiscountViewModel : ValueBasedRuleViewModel<ApplyPercentDiscount>
    {
        public ApplyPercentDiscountViewModel(ApplyPercentDiscount model) : base(model)
        {
        }
    }
}