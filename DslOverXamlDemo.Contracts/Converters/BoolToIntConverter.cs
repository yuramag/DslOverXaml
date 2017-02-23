using System.Windows.Data;

namespace DslOverXamlDemo.Contracts.Converters
{
    [ValueConversion(typeof(bool), typeof(int))]
    public class BoolToIntConverter : SimpleValueConverter<bool, int>
    {
        protected override int ConvertBase(bool input)
        {
            return input ? 1 : 0;
        }

        protected override bool ConvertBackBase(int input)
        {
            return input != 0;
        }
    }
}