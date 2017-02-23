using System.Threading.Tasks;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class EmptyRuleImp : RuleImp
    {
        public override Task ExecuteAsync(IContext context)
        {
            return Task.FromResult(true);
        }

        public override string ToString()
        {
            return "[Empty]";
        }
    }
}