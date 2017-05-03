using System.ComponentModel;
using DslOverXamlDemo.Engine.Context;
using DslOverXamlDemo.Engine.OrderProcessing;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("OrderItems.Count")]
    public sealed class OrderItemsCountImp : RangeConditionImp<int>
    {
        protected override int GetValue(IContext context)
        {
            return context.GetService<OrderStateService>().Order.Items.Count;
        }
    }
}