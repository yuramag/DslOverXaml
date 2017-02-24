using System.ComponentModel;
using DslOverXamlDemo.Engine.OrderProcessing;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("Product.Price")]
    public sealed class ProductPriceImp : RangeConditionImp<decimal>
    {
        protected override decimal GetValue(IContext context)
        {
            return context.GetService<OrderStateService>().CurrentOrderItem?.Product?.Price ?? 0M;
        }
    }
}