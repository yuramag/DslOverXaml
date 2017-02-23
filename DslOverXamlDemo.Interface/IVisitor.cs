namespace DslOverXamlDemo.Interface
{
    public interface IVisitor<in TInfo, out T>
    {
        T Visit(TInfo info);
    }
}