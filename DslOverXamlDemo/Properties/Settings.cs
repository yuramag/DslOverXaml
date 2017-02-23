using DslOverXamlDemo.Model;
using Newtonsoft.Json;

namespace DslOverXamlDemo.Properties
{
    internal partial class Settings
    {
        public DataStore SampleData
        {
            get { return string.IsNullOrEmpty(SampleDataJson) ? null : JsonConvert.DeserializeObject<DataStore>(SampleDataJson); }
            set { SampleDataJson = value == null ? null : JsonConvert.SerializeObject(value); }
        }
    }
}