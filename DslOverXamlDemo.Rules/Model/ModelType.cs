using System;

namespace DslOverXamlDemo.Rules.Model
{
    public sealed class ModelType
    {
        public ModelType()
        {
        }

        public ModelType(string name)
            : this(name, null)
        {
        }

        public ModelType(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public Type Type { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}