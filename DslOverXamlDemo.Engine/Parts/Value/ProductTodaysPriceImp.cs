using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Data;
using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class ProductTodaysPriceImp : ValueImp
    {
        public ValueImp DefaultValue { get; set; }

        public override async Task<Variable> GetValueAsync(IContext context)
        {
            var productId = context.CurrentOrderItem.Product.Id;
            var result = await DataRepository.GetProductTodaysPriceAsync(productId);
            return result > 0 || DefaultValue == null ? Variable.Create(result) : await DefaultValue.GetValueAsync(context);
        }

        public override string ToString()
        {
            return DefaultValue == null ? "<Product Today's Price>" : $"<Product Today's Price (Default = {DefaultValue})>]";
        }
    }
}