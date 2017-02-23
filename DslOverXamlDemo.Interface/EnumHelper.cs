using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DslOverXamlDemo.Interface
{
    public static class EnumHelper
    {
        public static T FromString<T>(string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            return GetValues<T>().Single(x => x.ToString() == value);
        }

        public static T? FromStringOrNull<T>(string value) where T : struct
        {
            if (value == null)
                return default(T?);
            foreach (var item in GetValues<T>().Where(x => x.ToString() == value))
                return item;
            return default(T?);
        }

        public static T FromStringDef<T>(string value, T defValue)
        {
            return value == null ? defValue : GetValues<T>().DefaultIfEmpty(defValue).FirstOrDefault(x => x.ToString() == value);
        }

        public static T FromStringDef<T>(string value)
        {
            if (value == null)
                return default(T);
            return GetValues<T>().DefaultIfEmpty(default(T)).FirstOrDefault(x => x.ToString() == value);
        }

        public static IEnumerable<T> GetValues<T>()
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("Type must be enumeration type.");

            return GetValuesImpl<T>();
        }

        private static IEnumerable<T> GetValuesImpl<T>()
        {
            return from field in typeof(T).GetFields()
                where field.IsLiteral && !string.IsNullOrEmpty(field.Name)
                select (T)field.GetValue(null);
        }

        public static string GetEnumDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));
            return attr?.Description ?? value.ToString();
        }
    }
}