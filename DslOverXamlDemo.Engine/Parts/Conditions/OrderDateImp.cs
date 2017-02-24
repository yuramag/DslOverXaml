using System;
using System.ComponentModel;
using DslOverXamlDemo.Engine.OrderProcessing;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("Order.Date")]
    public sealed class OrderDateImp : RangeConditionImp<DateTime>
    {
        protected override DateTime GetValue(IContext context)
        {
            return context.GetService<OrderStateService>().Order.Date;
        }
    }
}