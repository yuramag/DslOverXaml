using System;
using System.Collections.Generic;
using System.Linq;
using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.Engine
{
    public static class DiscountLogic
    {
        public static decimal GetOrderTotalAmount(Order order, List<OrderDiscount> discounts)
        {
            var result = 0M;

            foreach (var item in order.Items)
            {
                var productPrice = item.Product.Price;

                foreach (var discount in discounts.Where(x => x.OrderItemId == item.Id))
                {
                    switch (discount.DiscountType)
                    {
                        case DiscountType.Absolute:
                            productPrice = Math.Min(productPrice, discount.Operand);
                            break;
                        case DiscountType.Additive:
                            productPrice = productPrice - discount.Operand;
                            break;
                        case DiscountType.Multiplicative:
                            productPrice = productPrice*discount.Operand;
                            break;
                        case DiscountType.Percent:
                            if (discount.Operand >= 100M || discount.Operand < 0M)
                                throw new InvalidOperationException("Percent operand must be non-negative number less than 100");
                            productPrice = productPrice - productPrice*discount.Operand/100M;
                            break;
                    }
                }

                result += Math.Max(0M, productPrice)*item.Quantity;
            }

            return result;
        }
    }
}