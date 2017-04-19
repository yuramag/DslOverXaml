using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Model;
using Newtonsoft.Json;

namespace DslOverXamlDemo.Properties
{
    internal partial class Settings
    {
        public Order OrderData
        {
            get { return string.IsNullOrEmpty(OrderDataJson) ? null : JsonConvert.DeserializeObject<Order>(OrderDataJson); }
            set { OrderDataJson = value == null ? null : JsonConvert.SerializeObject(value); }
        }

        public Rule SampleRule
        {
            get { return string.IsNullOrEmpty(SampleRuleXaml) ? null : SimpleXamlSerializer.FromXaml<Rule>(SampleRuleXaml); }
            set { SampleRuleXaml = value == null ? null : SimpleXamlSerializer.ToXaml(value); }
        }
    }
}