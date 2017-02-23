using System.Threading.Tasks;

namespace DslOverXamlDemo.Engine.Data
{
    public static class DataRepository
    {
        public static async Task<decimal> GetProductClearancePercentAsync(int productId)
        {
            await Task.Delay(500); // Simulate DB Query
            return 20M;
        }

        public static async Task<decimal> GetProductTodaysPriceAsync(int productId)
        {
            await Task.Delay(500); // Simulate DB Query
            return 10M;
        }
    }
}
