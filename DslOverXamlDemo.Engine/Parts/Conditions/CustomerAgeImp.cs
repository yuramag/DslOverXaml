using System.ComponentModel;
using DslOverXamlDemo.Engine.OrderProcessing;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("Customer.Age")]
    public sealed class CustomerAgeImp : RangeConditionImp<int>
    {
        protected override int GetValue(IContext context)
        {
            return context.GetService<OrderStateService>().Order.Customer?.Age ?? 0;
        }
    }
}