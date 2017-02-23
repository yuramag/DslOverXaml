using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ApplyMultiplicativeDiscount), "Apply Multiplicative Discount")]
    public sealed class ApplyMultiplicativeDiscountViewModel : ValueBasedRuleViewModel<ApplyMultiplicativeDiscount>
    {
        public ApplyMultiplicativeDiscountViewModel(ApplyMultiplicativeDiscount model) : base(model)
        {
        }
    }
}