using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace CustomConfigurationManager
{
    internal class CustomConfigurationSection : ConfigurationSection
    {
        public readonly Dictionary<string, XDocument> ConfigContainer = new Dictionary<string, XDocument>();

        public static CustomConfigurationSection GetConfiguration()
        {
            return (CustomConfigurationSection) ConfigurationManager.GetSection("CustomConfiguration");
        }

        protected override bool OnDeserializeUnrecognizedElement(string name, XmlReader reader)
        {
            ConfigContainer.Add(reader.Name, XDocument.Load(reader.ReadSubtree()));
            return true;
        }
    }
}