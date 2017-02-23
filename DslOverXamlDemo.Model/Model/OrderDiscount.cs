namespace DslOverXamlDemo.Model
{
    public sealed class OrderDiscount
    {
        public int OrderItemId { get; set; }
        public DiscountType DiscountType { get; set; }
        public decimal Operand { get; set; }
    }
}