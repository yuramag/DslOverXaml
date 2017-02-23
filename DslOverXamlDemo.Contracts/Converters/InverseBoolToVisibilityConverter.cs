using System.Windows;
using System.Windows.Data;

namespace DslOverXamlDemo.Contracts.Converters
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class InverseBoolToVisibilityConverter : SimpleValueConverter<bool, Visibility>
    {
        protected override Visibility ConvertBase(bool input)
        {
            return input ? Visibility.Collapsed : Visibility.Visible;
        }

        protected override bool ConvertBackBase(Visibility input)
        {
            return input != Visibility.Visible;
        }
    }
}