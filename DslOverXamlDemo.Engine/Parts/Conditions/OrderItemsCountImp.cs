using System.ComponentModel;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("OrderItems.Count")]
    public sealed class OrderItemsCountImp : RangeConditionImp<int>
    {
        protected override int GetValue(IContext context)
        {
            return context.Order.Items.Count;
        }
    }
}