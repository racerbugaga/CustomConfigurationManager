using System.IO;
using System.Xml.Serialization;

namespace CustomConfigurationManager.Serializers
{
    class XmlConfigurationSerializer : IConfigurationSerializer
    {
        public T Deserialize<T>(string data)
        {
            var formatter = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(data))
            {
                return (T)formatter.Deserialize(reader);
            }
        }
    }
}