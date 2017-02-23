using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DslOverXamlDemo.Contracts.Converters
{
    public abstract class SimpleValueConverter<TSource, TTarget> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TSource || (!typeof(TSource).IsValueType && value == null))
            {
                try
                {
                    return ConvertBase((TSource) value);
                }
                catch (NotSupportedException)
                {
                }
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TTarget || (!typeof(TSource).IsValueType && value == null))
            {
                try
                {
                    return ConvertBackBase((TTarget) value);
                }
                catch (NotSupportedException)
                {
                }
            }
            return DependencyProperty.UnsetValue;
        }

        protected abstract TTarget ConvertBase(TSource input);

        protected virtual TSource ConvertBackBase(TTarget input)
        {
            throw new NotSupportedException();
        }
    }
}