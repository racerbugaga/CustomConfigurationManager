using System.Xml.Serialization;

namespace CustomConfigurationManager.Tests.TestConfigs
{
    public class Server
    {
        [XmlElement("Name")] 
        public string Name { get; set; }
    }
}