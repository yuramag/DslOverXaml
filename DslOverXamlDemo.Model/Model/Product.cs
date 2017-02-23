namespace DslOverXamlDemo.Model
{
    public sealed class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductType Category { get; set; }
        public decimal Price { get; set; }
    }
}