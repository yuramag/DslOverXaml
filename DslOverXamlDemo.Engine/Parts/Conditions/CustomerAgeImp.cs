using System.ComponentModel;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("Customer.Age")]
    public sealed class CustomerAgeImp : RangeConditionImp<int>
    {
        protected override int GetValue(IContext context)
        {
            return context.Order.Customer?.Age ?? 0;
        }
    }
}