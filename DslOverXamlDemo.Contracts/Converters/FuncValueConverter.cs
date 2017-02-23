using System;

namespace DslOverXamlDemo.Contracts.Converters
{
    public class FuncValueConverter<TSource, TTarget> : SimpleValueConverter<TSource, TTarget>
    {
        public FuncValueConverter(Func<TSource, TTarget> func)
        {
            m_func = func ?? (s => default(TTarget));
        }
        protected override TTarget ConvertBase(TSource input)
        {
            return m_func(input);
        }

        private readonly Func<TSource, TTarget> m_func;
    }
}