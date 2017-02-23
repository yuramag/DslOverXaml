using System.Threading.Tasks;
using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Engine.Parts
{
    public abstract class ValueImp
    {
        public abstract Task<Variable> GetValueAsync(IContext context);
    }
}
