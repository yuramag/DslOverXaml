using System.ComponentModel;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("Product.Price")]
    public sealed class ProductPriceImp : RangeConditionImp<decimal>
    {
        protected override decimal GetValue(IContext context)
        {
            return context.CurrentOrderItem?.Product?.Price ?? 0M;
        }
    }
}