using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ApplyAbsoluteDiscount), "Apply Absolute Discount")]
    public sealed class ApplyAbsoluteDiscountViewModel : ValueBasedRuleViewModel<ApplyAbsoluteDiscount>
    {
        public ApplyAbsoluteDiscountViewModel(ApplyAbsoluteDiscount model) : base(model)
        {
        }
    }
}