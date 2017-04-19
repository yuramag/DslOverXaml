using System.Windows.Data;

namespace DslOverXamlDemo.Contracts.Converters
{
    [ValueConversion(typeof(bool), typeof(object))]
    public class GenericEqulityConverter : SimpleValueConverter<object, object>
    {
        protected override object ConvertBase(object input)
        {
            return Equals(input, Value) ? TrueResult : FalseResult;
        }

        public object Value { get; set; }
        public object TrueResult { get; set; }
        public object FalseResult { get; set; }
    }
}