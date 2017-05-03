using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class AnyMatchImp : ConditionSetImp
    {
        public override async Task<bool> EvaluateAsync(IContext context)
        {
            foreach (var cond in Conditions)
                if (await cond.EvaluateAsync(context))
                    return true;
            return false;
        }

        public override string ToString()
        {
            var result = string.Join(" OR ", Conditions);
            return $"({result})";
        }
    }
}