using System.Threading.Tasks;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class BreakImp : RuleImp
    {
        public override Task ExecuteAsync(IContext context)
        {
            context.GetService<IExecutionControlService>().CurrentScope.Break();
            return Task.CompletedTask;
        }

        public override string ToString()
        {
            return "[Break]";
        }
    }
}