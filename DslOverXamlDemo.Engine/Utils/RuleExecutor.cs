using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;
using DslOverXamlDemo.Engine.Parts;
using DslOverXamlDemo.Engine.Services;

namespace DslOverXamlDemo.Engine.Utils
{
    public static class RuleExecutor
    {
        public static async Task ExecuteAsync(IContext context, RuleImp rule)
        {
            using (context.GetService<IExecutionControlService>().CreateExecutionScope())
                await rule.ExecuteAsync(context);
        }
    }
}