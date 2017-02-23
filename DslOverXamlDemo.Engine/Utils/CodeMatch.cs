using System;
using System.Collections.Generic;
using System.Linq;

namespace DslOverXamlDemo.Engine.Utils
{
    public sealed class CodeMatch<T>
    {
        private readonly List<Tuple<T, T>> m_items;

        public CodeMatch(string codes, Func<string, T> selector)
        {
            m_items = (codes ?? string.Empty).Split(',').Select(x => GetRange(x, selector)).ToList();
        }

        private static Tuple<T, T> GetRange(string value, Func<string, T> selector)
        {
            if (!value.Contains(".."))
                return Tuple.Create(selector(value), selector(value));
            var items = value.Split(new[] { ".." }, StringSplitOptions.None);
            return Tuple.Create(selector(items[0]), selector(items[1]));
        }

        public bool Matches(T value)
        {
            return m_items.Any(x => value != null && Comparer<T>.Default.Compare(value, x.Item1) >= 0 && Comparer<T>.Default.Compare(value, x.Item2) <= 0);
        }
    }
}
