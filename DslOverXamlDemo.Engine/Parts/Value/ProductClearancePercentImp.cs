using System.Threading.Tasks;
using DslOverXamlDemo.Engine.OrderProcessing;
using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class ProductClearancePercentImp : ValueImp
    {
        public ValueImp DefaultValue { get; set; }

        public override async Task<Variable> GetValueAsync(IContext context)
        {
            var productId = context.GetService<OrderStateService>().CurrentOrderItem.Product.Id;
            var result = await DataRepository.GetProductClearancePercentAsync(productId);
            return result > 0 || DefaultValue == null ? Variable.Create(result) : await DefaultValue.GetValueAsync(context);
        }

        public override string ToString()
        {
            return DefaultValue == null ? "<Product Clearance Percent>" : $"<Product Clearance Percent (Default = {DefaultValue})>]";
        }
    }
}