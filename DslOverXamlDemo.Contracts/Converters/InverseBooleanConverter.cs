using System.Windows.Data;

namespace DslOverXamlDemo.Contracts.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InverseBooleanConverter : SimpleValueConverter<bool, bool>
    {
        protected override bool ConvertBase(bool input)
        {
            return !input;
        }

        protected override bool ConvertBackBase(bool input)
        {
            return !input;
        }
    }
}