using System;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Rules.Model;

namespace DslOverXamlDemo.Rules.ViewModel
{
    [ModelBinding(typeof(OrderDate), "Order Date")]
    public sealed class OrderDateViewModel : RangeConditionViewModel<OrderDate, DateTime>
    {
        public OrderDateViewModel(OrderDate model) : base(model)
        {
        }
    }
}