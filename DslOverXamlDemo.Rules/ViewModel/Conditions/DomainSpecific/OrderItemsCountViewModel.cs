using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(OrderItemsCount), "Order Items Count")]
    public sealed class OrderItemsCountViewModel : RangeConditionViewModel<OrderItemsCount, int>
    {
        public OrderItemsCountViewModel(OrderItemsCount model) : base(model)
        {
        }
    }
}