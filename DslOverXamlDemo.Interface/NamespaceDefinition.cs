using System.Windows.Markup;

[assembly: XmlnsDefinition(DslOverXamlDemo.Interface.NamespaceDefinition.DefaultNamespace, "DslOverXamlDemo.Interface")]

namespace DslOverXamlDemo.Interface
{
    public static class NamespaceDefinition
    {
        public const string DefaultNamespace = "http://www.mycompany.com/2016/product";
    }
}