using DslOverXamlDemo.Engine.Parts;
using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Engine.Utils
{
    public static class RuleBuilder
    {
        public static Rule CreateRule(string xaml)
        {
            return SimpleXamlSerializer.FromXaml<Rule>(xaml);
        }

        public static RuleImp CreateRuleImp(Rule rule)
        {
            return new RuleBuildingVisitor().Visit(rule);
        }

        public static RuleImp CreateRuleImp(string xaml)
        {
            return new RuleBuildingVisitor().Visit(CreateRule(xaml));
        }
    }
}