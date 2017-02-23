using System;
using System.Threading.Tasks;
using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class ApplyAbsoluteDiscountImp : RuleImp
    {
        public ValueImp Value { get; set; }

        public override async Task ExecuteAsync(IContext context)
        {
            if (Value == null)
                throw new InvalidOperationException("Value property is not set.");
            var value = await Value.GetValueAsync(context);
            context.AddDiscount(DiscountType.Absolute, value.AsDecimal);
        }

        public override string ToString()
        {
            return $"[<Absolute Discount> = {Value}]";
        }
    }
}