using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class AllMatchImp : ConditionSetImp
    {
        public override async Task<bool> EvaluateAsync(IContext context)
        {
            foreach (var cond in Conditions)
                if (!await cond.EvaluateAsync(context))
                    return false;
            return true;
        }

        public override string ToString()
        {
            var result = string.Join(" AND ", Conditions);
            return $"({result})";
        }
    }
}