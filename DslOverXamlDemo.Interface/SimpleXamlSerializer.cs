using System.Text;
using System.Xaml;
using System.Xml;
using System.Xml.Linq;

namespace DslOverXamlDemo.Interface
{
    public static class SimpleXamlSerializer
    {
        public static string ToXaml<T>(T instance, string defaultNamespace = null)
        {
            if (instance == null)
                return null;

            var settings = new XmlWriterSettings {OmitXmlDeclaration = true};

            var sb = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(sb, settings))
                XamlServices.Save(xmlWriter, instance);

            return sb.ToString().Replace($" xmlns=\"{defaultNamespace ?? NamespaceDefinition.DefaultNamespace}\"", null);
        }

        public static T FromXaml<T>(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return default(T);
            var node = XElement.Parse(xml);
            SetDefaultXmlNamespace(node, $"clr-namespace:{typeof(T).Namespace};assembly={typeof(T).Assembly.GetName()}");
            return (T) XamlServices.Load(node.CreateReader());
        }

        private static void SetDefaultXmlNamespace(XElement xelem, XNamespace xmlns)
        {
            if (xelem.Name.NamespaceName == string.Empty)
                xelem.Name = xmlns + xelem.Name.LocalName;
            foreach (var e in xelem.Elements())
                SetDefaultXmlNamespace(e, xmlns);
        }
    }
}