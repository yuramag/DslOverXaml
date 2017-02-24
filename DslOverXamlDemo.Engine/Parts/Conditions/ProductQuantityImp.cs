using System.ComponentModel;
using DslOverXamlDemo.Engine.OrderProcessing;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("Product.Quantity")]
    public sealed class ProductQuantityImp : RangeConditionImp<int>
    {
        protected override int GetValue(IContext context)
        {
            return context.GetService<OrderStateService>().CurrentOrderItem?.Quantity ?? 0;
        }
    }
}