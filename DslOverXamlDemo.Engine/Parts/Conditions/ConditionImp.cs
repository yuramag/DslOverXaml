using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;

namespace DslOverXamlDemo.Engine.Parts
{
    public abstract class ConditionImp
    {
        public abstract Task<bool> EvaluateAsync(IContext context);
    }
}