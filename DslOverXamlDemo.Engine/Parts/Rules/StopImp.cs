using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;
using DslOverXamlDemo.Engine.Services;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class StopImp : RuleImp
    {
        public override Task ExecuteAsync(IContext context)
        {
            context.GetService<IExecutionControlService>().Stop();
            return Task.CompletedTask;
        }

        public override string ToString()
        {
            return "[Stop]";
        }
    }
}