using System.Threading.Tasks;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class FalseImp : ConditionImp
    {
        public override Task<bool> EvaluateAsync(IContext context)
        {
            return Task.FromResult(false);
        }

        public override string ToString()
        {
            return "(<False>)";
        }
    }
}