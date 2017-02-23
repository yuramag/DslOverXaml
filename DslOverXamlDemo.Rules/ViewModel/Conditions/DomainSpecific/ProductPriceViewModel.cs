using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(ProductPrice), "Product Price")]
    public sealed class ProductPriceViewModel : RangeConditionViewModel<ProductPrice, decimal>
    {
        public ProductPriceViewModel(ProductPrice model) : base(model)
        {
        }
    }
}