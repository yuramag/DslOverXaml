using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;
using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class ConstantImp : ValueImp
    {
        public Variable Value { get; set; }

        public override Task<Variable> GetValueAsync(IContext context)
        {
            return Task.FromResult(Value);
        }

        public override string ToString()
        {
            return $"<{Value.AsString}>";
        }
    }
}