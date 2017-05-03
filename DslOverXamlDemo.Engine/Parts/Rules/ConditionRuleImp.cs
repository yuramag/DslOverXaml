using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Context;

namespace DslOverXamlDemo.Engine.Parts
{
    public sealed class ConditionRuleImp : RuleImp
    {
        private static readonly ConditionImp DefaultCondition = new TrueImp();
        private static readonly RuleImp DefaultBody = new EmptyRuleImp();

        private ConditionImp m_condition;

        public ConditionImp Condition
        {
            get { return m_condition ?? DefaultCondition; }
            set { m_condition = value; }
        }

        private RuleImp m_body;

        public RuleImp Rule
        {
            get { return m_body ?? DefaultBody; }
            set { m_body = value; }
        }

        public override async Task ExecuteAsync(IContext context)
        {
            if (await Condition.EvaluateAsync(context))
                await Rule.ExecuteAsync(context);
        }

        public override string ToString()
        {
            return $"{Condition}{Rule}";
        }
    }
}