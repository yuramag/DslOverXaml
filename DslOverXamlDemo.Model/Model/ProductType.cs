using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DslOverXamlDemo.Model
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductType : int
    {
        Unknown,
        Other,
        Clothing,
        Shoes,
        Jewelry,
        Sports,
        Toys,
        Electronics,
        Games
    }
}