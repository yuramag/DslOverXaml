using System.Windows.Data;

namespace DslOverXamlDemo.Contracts.Converters
{
    [ValueConversion(typeof(bool), typeof(int))]
    public class InverseBoolToIntConverter : SimpleValueConverter<bool, int>
    {
        protected override int ConvertBase(bool input)
        {
            return input ? 0 : 1;
        }

        protected override bool ConvertBackBase(int input)
        {
            return input == 0;
        }
    }
}