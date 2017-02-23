using System.Threading.Tasks;

namespace DslOverXamlDemo.Engine.Parts
{
    public abstract class ConditionImp
    {
        public abstract Task<bool> EvaluateAsync(IContext context);
    }
}