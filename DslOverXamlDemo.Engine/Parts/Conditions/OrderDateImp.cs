using System;
using System.ComponentModel;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("Order.Date")]
    public sealed class OrderDateImp : RangeConditionImp<DateTime>
    {
        protected override DateTime GetValue(IContext context)
        {
            return context.Order.Date;
        }
    }
}