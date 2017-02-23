using System;

namespace DslOverXamlDemo.Rules.Model
{
    public sealed class ModelMetadata
    {
        public ModelMetadata(Type modelType, Type viewModelType, string description)
        {
            ModelType = modelType;
            ViewModelType = viewModelType;
            Description = description;
        }

        public Type ModelType { get; }
        public Type ViewModelType { get; }
        public string Description { get; }
    }
}