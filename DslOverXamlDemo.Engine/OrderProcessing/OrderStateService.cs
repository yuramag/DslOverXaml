using DslOverXamlDemo.Model;

namespace DslOverXamlDemo.Engine.OrderProcessing
{
    public sealed class OrderStateService
    {
        public OrderStateService(Order order)
        {
            Order = order;
        }

        public Order Order { get; }
        public OrderItem CurrentOrderItem { get; set; }
    }
}