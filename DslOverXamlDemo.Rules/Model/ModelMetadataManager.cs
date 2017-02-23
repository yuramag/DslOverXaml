using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using DslOverXamlDemo.Interface;

namespace DslOverXamlDemo.Rules.Model
{
    public static class ModelMetadataManager
    {
        private static readonly IDictionary<Type, ModelMetadata> s_modelBindings;

        static ModelMetadataManager()
        {
            s_modelBindings = typeof(RuleModelFactory).Assembly
                .GetTypes()
                .Where(x => x.IsDefined(typeof(ModelBindingAttribute), false))
                .Select(x => new {Type = x, Attribute = x.GetCustomAttribute<ModelBindingAttribute>()})
                .ToDictionary(x => x.Attribute.ModelType, x => new ModelMetadata(x.Attribute.ModelType, x.Type, x.Attribute.Description));

            AllRules = new ReadOnlyCollection<ModelMetadata>(GetItemsDerivedFrom<Rule>().ToList());
            AllConditions = new ReadOnlyCollection<ModelMetadata>(GetItemsDerivedFrom<Condition>().ToList());
            AllValues = new ReadOnlyCollection<ModelMetadata>(GetItemsDerivedFrom<Value>().ToList());
        }

        private static IEnumerable<ModelMetadata> GetItemsDerivedFrom<T>()
        {
            return s_modelBindings.Where(x => typeof(T).IsAssignableFrom(x.Key)).Select(x => x.Value);
        }

        public static IReadOnlyCollection<ModelMetadata> AllRules { get; }
        public static IReadOnlyCollection<ModelMetadata> AllConditions { get; }
        public static IReadOnlyCollection<ModelMetadata> AllValues { get; }

        public static ModelMetadata GetModelMetadata(Type type)
        {
            ModelMetadata result;
            return s_modelBindings.TryGetValue(type, out result) ? result : null;
        }

        public static ModelMetadata GetModelMetadata<T>()
        {
            return GetModelMetadata(typeof(T));
        }
    }
}