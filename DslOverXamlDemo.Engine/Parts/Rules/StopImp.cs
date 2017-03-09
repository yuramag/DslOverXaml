using System.Threading.Tasks;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class StopImp : RuleImp
    {
        public override Task ExecuteAsync(IContext context)
        {
            context.GetService<IExecutionControlService>().Stop();
            return Task.CompletedTask;
        }
    }
}