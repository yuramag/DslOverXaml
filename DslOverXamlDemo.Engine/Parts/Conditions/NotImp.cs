using System;
using System.Threading.Tasks;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class NotImp : ConditionImp
    {
        public ConditionImp Condition { get; set; }

        public override string ToString()
        {
            return Condition == null ? "(<Null>)" : $"(NOT {Condition})";
        }

        public override async Task<bool> EvaluateAsync(IContext context)
        {
            if (Condition == null)
                throw new InvalidOperationException("Condition property is not set.");
            return !await Condition.EvaluateAsync(context);
        }
    }
}