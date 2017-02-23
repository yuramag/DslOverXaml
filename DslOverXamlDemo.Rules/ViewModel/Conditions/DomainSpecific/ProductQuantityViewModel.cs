using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ProductQuantity), "Product Quantity")]
    public sealed class ProductQuantityViewModel : RangeConditionViewModel<ProductQuantity, int>
    {
        public ProductQuantityViewModel(ProductQuantity model) : base(model)
        {
        }
    }
}