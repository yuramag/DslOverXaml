using System.ComponentModel;
using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;
using DslOverXamlDemo.Engine.OrderProcessing;
using DslOverXamlDemo.Engine.Utils;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.Engine.Parts
{
    [Description("Product.Category")]
    public sealed class ProductCategoryImp : ConditionImp
    {
        public string Value { get; set; }

        public override async Task<bool> EvaluateAsync(IContext context)
        {
            var category = context.GetService<OrderStateService>().CurrentOrderItem?.Product?.Category;
            if (!category.HasValue)
                return false;
            return new CodeMatch<ProductType>(Value, EnumHelper.FromStringDef<ProductType>).Matches(category.Value);
        }

        public override string ToString()
        {
            return $"(<Product.Category> EQUALS <{Value}>)";
        }
    }
}