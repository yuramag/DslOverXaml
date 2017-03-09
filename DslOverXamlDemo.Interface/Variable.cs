using System;

namespace DslOverXamlDemo.Interface
{
    public struct Variable : IEquatable<Variable>
    {
        public Variable(object value) : this()
        {
            Value = value is string && string.IsNullOrEmpty((string)value) ? null : value;
        }

        public static Variable Create(object value)
        {
            return value is string && string.IsNullOrEmpty((string)value) ? Empty : new Variable(value);
        }

        public static readonly Variable Empty = new Variable(null);

        public object Value { get; }

        public bool IsEmpty => Value == null;

        public bool Equals(Variable other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Variable && Equals((Variable)obj);
        }

        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 0;
        }

        public static bool operator ==(Variable left, Variable right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Variable left, Variable right)
        {
            return !left.Equals(right);
        }

        public T Cast<T>()
        {
            return (T)Value;
        }

        public decimal AsDecimal => VariableConverter.ConvertFrom<decimal>(Value);

        public decimal? AsNullableDecimal => IsEmpty ? default(decimal?) : AsDecimal;

        public decimal? TryAsDecimal
        {
            get
            {
                return !VariableConverter.TryConvertFrom(Value, out decimal result) ? default(decimal?) : result;
            }
        }

        public double AsDouble => VariableConverter.ConvertFrom<double>(Value);

        public double? AsNullableDouble => IsEmpty ? default(double?) : AsDouble;

        public double? TryAsDouble
        {
            get
            {
                return !VariableConverter.TryConvertFrom(Value, out double result) ? default(double?) : result;
            }
        }

        public int AsInteger => VariableConverter.ConvertFrom<int>(Value);

        public int? AsNullableInteger => IsEmpty ? default(int?) : AsInteger;

        public int? TryAsInteger
        {
            get
            {
                return !VariableConverter.TryConvertFrom(Value, out int result) ? default(int?) : result;
            }
        }

        public string AsString => VariableConverter.ConvertFrom<string>(Value) ?? string.Empty;

        public string AsNullableString => IsEmpty ? default(string) : AsString;

        public string TryAsString
        {
            get
            {
                return !VariableConverter.TryConvertFrom(Value, out string result) ? default(string) : result;
            }
        }

        public bool AsBoolean => VariableConverter.ParseBoolOrNull(AsString) ?? false;

        public bool? AsNullableBoolean => IsEmpty ? default(bool?) : AsBoolean;

        public bool? TryAsBoolean => VariableConverter.ParseBoolOrNull(AsString);

        public DateTime AsDateTime => VariableConverter.ParseDateTime(AsString);

        public DateTime? AsNullableDateTime => IsEmpty ? default(DateTime?) : AsDateTime;

        public DateTime? TryAsDateTime => VariableConverter.ParseDateTimeOrNull(AsString);

        public override string ToString()
        {
            return AsString;
        }

        public static implicit operator Variable(string value)
        {
            return Create(value);
        }

        public static implicit operator Variable(decimal value)
        {
            return Create(value);
        }

        public static implicit operator Variable(double value)
        {
            return Create(value);
        }

        public static implicit operator Variable(int value)
        {
            return Create(value);
        }

        public static implicit operator Variable(bool value)
        {
            return Create(value);
        }

        public static implicit operator Variable(DateTime value)
        {
            return Create(value);
        }

        public static implicit operator decimal(Variable value)
        {
            return value.AsDecimal;
        }

        public static implicit operator double(Variable value)
        {
            return value.AsDouble;
        }

        public static implicit operator int(Variable value)
        {
            return value.AsInteger;
        }

        public static implicit operator bool(Variable value)
        {
            return value.AsBoolean;
        }

        public static implicit operator DateTime(Variable value)
        {
            return value.AsDateTime;
        }

        public static implicit operator string(Variable value)
        {
            return value.AsString;
        }
    }
}