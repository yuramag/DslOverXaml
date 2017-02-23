using System.ComponentModel;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("Product.Quantity")]
    public sealed class ProductQuantityImp : RangeConditionImp<int>
    {
        protected override int GetValue(IContext context)
        {
            return context.CurrentOrderItem?.Quantity ?? 0;
        }
    }
}