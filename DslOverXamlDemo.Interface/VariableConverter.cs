using System;
using System.ComponentModel;
using System.Globalization;

namespace DslOverXamlDemo.Interface
{
    internal static class VariableConverter
    {
        public static T ConvertFrom<T>(object value)
        {
            if (value == null || (value is string && value.Equals(string.Empty)))
                return default(T);

            object result;
            try
            {
                result = Convert.ChangeType(value, typeof(T));
            }
            catch (InvalidCastException)
            {
                var typeConverter = TypeDescriptor.GetConverter(typeof(T));
                if (typeConverter.CanConvertFrom(value.GetType()))
                    result = typeConverter.ConvertFrom(value);
                else
                    throw;
            }
            return (T)result;
        }

        public static bool TryConvertFrom<T>(object value, out T result)
        {
            result = default(T);

            if (value == null || (value is string && value.Equals(string.Empty)))
                return true;

            object res;

            try
            {
                try
                {
                    res = Convert.ChangeType(value, typeof(T));
                }
                catch (InvalidCastException)
                {
                    var typeConverter = TypeDescriptor.GetConverter(typeof(T));
                    if (typeConverter.CanConvertFrom(value.GetType()))
                        res = typeConverter.ConvertFrom(value);
                    else
                        return false;
                }
                result = (T)res;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private static readonly string[] Formats = { "MMddyyyy", "MMddyy", "MM/dd/yyyy", "MM-dd-yyyy", "MM/dd/yy", "MM-dd-yy" };

        public static DateTime ParseDateTime(string value)
        {
            DateTime result;
            if (!TryParseDateTime(value, out result))
                throw new FormatException(string.Format("{0} does not contain a valid string representation of a date and time", value));
            return result;
        }

        public static bool TryParseDateTime(string value, out DateTime result)
        {
            return DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out result) ||
                   DateTime.TryParse(value, out result) ||
                   DateTime.TryParseExact(value, Formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result);
        }

        public static DateTime? ParseDateTimeOrNull(string value)
        {
            DateTime result;
            return !TryParseDateTime(value, out result) ? default(DateTime?) : result;
        }

        public static int? ParseIntOrNull(string value)
        {
            int result;
            return !int.TryParse(value, out result) ? default(int?) : result;
        }

        public static decimal? ParseDecimalOrNull(string value)
        {
            decimal result;
            return !decimal.TryParse(value, out result) ? default(decimal?) : result;
        }

        public static bool? ParseBoolOrNull(string value)
        {
            bool result;
            if (bool.TryParse(value, out result))
                return result;

            switch ((value ?? string.Empty).ToUpperInvariant())
            {
                case "1":
                case "Y":
                case "YES":
                case "T":
                case "TRUE":
                    return true;
                case "0":
                case "N":
                case "NO":
                case "F":
                case "FALSE":
                    return false;
                default:
                    return default(bool?);
            }
        }
    }
}