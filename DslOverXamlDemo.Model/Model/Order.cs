using System;
using System.Collections.Generic;
using System.Linq;

namespace DslOverXamlDemo.Model
{
    public sealed class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public IList<OrderItem> Items { get; set; }
        public decimal Total => Items.Sum(x => x.Total);
    }
}
