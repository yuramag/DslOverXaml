using System.Threading.Tasks;

namespace DslOverXamlDemo.Engine.Parts
{
    public abstract class RuleImp
    {
        public string Name { get; set; }
        public abstract Task ExecuteAsync(IContext context);

        public override string ToString()
        {
            return $"[{Name}]";
        }
    }
}