using System.Collections.Generic;
using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Parts;
using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.Engine
{
    public interface IContext
    {
        Order Order { get; }
        OrderItem CurrentOrderItem { get; }
        void AddDiscount(DiscountType discountType, decimal operand);
        void ClearDiscounts(int orderItemId = 0);
        Task<List<OrderDiscount>> ExecuteAsync(RuleImp rule);
    }
}