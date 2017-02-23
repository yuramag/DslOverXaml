using System;

namespace DslOverXamlDemo.Rules.Model
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class ModelBindingAttribute : Attribute
    {
        public ModelBindingAttribute(Type type, string description)
        {
            ModelType = type;
            Description = description;
        }

        public Type ModelType { get; set; }
        public string Description { get; set; }
    }
}