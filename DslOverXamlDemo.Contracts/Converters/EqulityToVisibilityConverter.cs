using System.Windows;
using System.Windows.Data;

namespace DslOverXamlDemo.Contracts.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class EqulityToVisibilityConverter : SimpleValueConverter<object, Visibility>
    {
        protected override Visibility ConvertBase(object input)
        {
            return object.Equals(input, Value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object Value { get; set; }
    }
}