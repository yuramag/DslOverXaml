using System.Collections.Generic;
using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Parts;
using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.Engine
{
    public sealed class OrderDiscountContext : IContext
    {
        public OrderDiscountContext(Order order)
        {
            Order = order;
        }

        private readonly List<OrderDiscount> m_orderDiscounts = new List<OrderDiscount>();

        public Order Order { get; }
        public OrderItem CurrentOrderItem { get; private set; }

        public void AddDiscount(DiscountType discountType, decimal operand)
        {
            m_orderDiscounts.Add(new OrderDiscount
            {
                OrderItemId = CurrentOrderItem.Id,
                DiscountType = discountType,
                Operand = operand
            });
        }

        public void ClearDiscounts(int orderItemId = 0)
        {
            m_orderDiscounts.Clear();
        }

        public async Task<List<OrderDiscount>> ExecuteAsync(RuleImp rule)
        {
            foreach (var item in Order.Items)
            {
                CurrentOrderItem = item;
                await rule.ExecuteAsync(this);
            }

            return m_orderDiscounts;
        }
    }
}