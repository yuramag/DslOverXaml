using System.Collections.Generic;

namespace DslOverXamlDemo.Engine.Parts
{
    public abstract class ConditionSetImp : ConditionImp
    {
        protected ConditionSetImp()
        {
            Conditions = new List<ConditionImp>();
        }

        public IList<ConditionImp> Conditions { get; set; }

        public override string ToString()
        {
            if (Conditions == null)
                return "(<Null>)";

            if (Conditions.Count == 1)
                return Conditions[0].ToString();

            var result = string.Join(", ", Conditions);
            return $"({result})";
        }
    }
}