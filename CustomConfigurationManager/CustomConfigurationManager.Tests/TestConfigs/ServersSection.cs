using System.Xml.Serialization;

namespace CustomConfigurationManager.Tests.TestConfigs
{
    public class ServersSection
    {
        [XmlAttribute("Parallelism")]
        public int Parallelism { get; set; }

        [XmlAttribute("ParallelEnabled")]
        public bool ParallelEnabled { get; set; }

        [XmlArray("Servers")]
        [XmlArrayItem("Server", typeof(Server))]
        public Server[] Servers { get; set; }
    }
}