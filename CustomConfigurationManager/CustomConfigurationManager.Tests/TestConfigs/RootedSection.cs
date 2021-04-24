using System.Xml.Serialization;

namespace CustomConfigurationManager.Tests.TestConfigs
{
    [XmlRoot("OtherName")]
    public class RootedSection
    {
        public int Param1 { get; set; }
        public string Param2 { get; set; }
    }
}