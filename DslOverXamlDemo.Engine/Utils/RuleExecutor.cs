using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Parts;

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