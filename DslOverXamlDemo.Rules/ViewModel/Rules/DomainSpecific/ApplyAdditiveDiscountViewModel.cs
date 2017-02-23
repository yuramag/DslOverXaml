using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ApplyAdditiveDiscount), "Apply Additive Discount")]
    public sealed class ApplyAdditiveDiscountViewModel : ValueBasedRuleViewModel<ApplyAdditiveDiscount>
    {
        public ApplyAdditiveDiscountViewModel(ApplyAdditiveDiscount model) : base(model)
        {
        }
    }
}