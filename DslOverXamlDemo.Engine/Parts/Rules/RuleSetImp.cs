using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;
using DslOverXamlDemo.Engine.Services;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class RuleSetImp : RuleImp
    {
        public RuleSetImp()
        {
            Rules = new List<RuleImp>();
        }

        public IList<RuleImp> Rules { get; set; }

        public override async Task ExecuteAsync(IContext context)
        {
            var executionControl = context.GetService<IExecutionControlService>();
            using (executionControl.CreateExecutionScope())
            {
                foreach (var rule in Rules ?? Enumerable.Empty<RuleImp>())
                {
                    if (executionControl.IsStopRequested || executionControl.CurrentScope.IsBreakRequested)
                        break;
                    await rule.ExecuteAsync(context);
                }
            }
        }

        public override string ToString()
        {
            if (Rules == null)
                return "[<Null>]";

            if (Rules.Count == 1)
                return Rules[0].ToString();

            var result = string.Join(", ", Rules);
            return $"[{result}]";
        }
    }
}