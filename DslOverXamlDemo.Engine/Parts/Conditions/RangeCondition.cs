using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using DslOverXamlDemo.Engine.Utils;

namespace DslOverXamlDemo.Engine.Parts
{
    public abstract class RangeConditionImp<T> : ConditionImp where T: struct
    {
        public T? From { get; set; }

        public T? To { get; set; }

        protected abstract T GetValue(IContext context);

        public override async Task<bool> EvaluateAsync(IContext context)
        {
            var value = GetValue(context);
            var comparer = Comparer<T>.Default;
            return (!From.HasValue || comparer.Compare(From.Value, value) <= 0) && (!To.HasValue || comparer.Compare(To.Value, value) >= 0);
        }

        public override string ToString()
        {
            var attribute = GetType().GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            var description = attribute?.Description ?? GetType().Name;
            return Helper.GenerateEqualityDescription(description, From, To);
        }
    }
}