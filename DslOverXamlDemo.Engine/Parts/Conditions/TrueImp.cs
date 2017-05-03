using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class TrueImp : ConditionImp
    {
        public override Task<bool> EvaluateAsync(IContext context)
        {
            return Task.FromResult(true);
        }

        public override string ToString()
        {
            return "(<True>)";
        }
    }
}