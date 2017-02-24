using System.Collections.Generic;
using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.Engine.OrderProcessing
{
    public sealed class DiscountsContainerService
    {
        private readonly List<OrderDiscount> m_orderDiscounts = new List<OrderDiscount>();

        public void AddDiscount(int orderItemId, DiscountType discountType, decimal operand)
        {
            m_orderDiscounts.Add(new OrderDiscount
            {
                OrderItemId = orderItemId,
                DiscountType = discountType,
                Operand = operand
            });
        }

        public List<OrderDiscount> GetOrderDiscounts()
        {
            return m_orderDiscounts;
        }
    }
}