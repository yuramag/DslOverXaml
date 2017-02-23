using System;

namespace DslOverXamlDemo.Engine.Utils
{
    public static class Helper
    {
        public static string GenerateEqualityDescription<T>(string item, T? from, T? to) where T : struct
        {
            return GenerateEqualityDescription(item, from, to, x => x);
        }

        public static string GenerateEqualityDescription<T, TConvert>(string item, T? from, T? to, Func<T, TConvert> convert) where T : struct
        {
            if (!from.HasValue && !to.HasValue)
                return "(<True>)";
            if (!from.HasValue)
                return $"(<{item}> <= <{convert(to.Value)}>)";
            if (!to.HasValue)
                return $"(<{item}> >= <{convert(from.Value)}>)";
            return $"(<{item}> BETWEEN <{convert(from.Value)}> AND <{convert(to.Value)}>)";
        }
    }
}