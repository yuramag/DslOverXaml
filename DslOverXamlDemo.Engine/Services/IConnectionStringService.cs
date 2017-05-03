namespace DslOverXamlDemo.Engine.Services
{
    public interface IConnectionStringService
    {
        string GetConnectionString();
        string GetConnectionString(string name);
    }
}