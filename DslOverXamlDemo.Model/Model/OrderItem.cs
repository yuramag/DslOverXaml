namespace DslOverXamlDemo.Model
{
    public sealed class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public decimal Total => (Product?.Price ?? 0M) * Quantity;
    }
}