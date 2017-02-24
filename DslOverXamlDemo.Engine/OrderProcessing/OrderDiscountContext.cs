using System.Collections.Generic;
using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Parts;
using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.Engine.OrderProcessing
{
    public sealed class OrderDiscountContext : Context
    {
        public OrderDiscountContext(Order order)
        {
            Order = order;
            this.AddService(new OrderStateService(Order));
            this.AddService(new DiscountsContainerService());
        }

        public Order Order { get; }

        public async Task ExecuteAsync(RuleImp rule)
        {
            foreach (var item in Order.Items)
            {
                this.GetService<OrderStateService>().CurrentOrderItem = item;
                await rule.ExecuteAsync(this);
            }
        }

        public List<OrderDiscount> GetOrderDiscounts()
        {
            return this.GetService<DiscountsContainerService>().GetOrderDiscounts();
        }
    }
}