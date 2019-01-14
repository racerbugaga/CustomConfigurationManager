using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CustomConfigurationManager
{
    public class CustomConfigurationService
    {
        private readonly Lazy<Dictionary<string, XDocument>> _configContainer = new Lazy<Dictionary<string, XDocument>>(InitContainer);
        private readonly ConcurrentDictionary<string, object> _configs = new ConcurrentDictionary<string, object>();

        public T GetConfig<T>()
        {
            return (T) _configs.GetOrAdd(typeof(T).Name,
                (name) => DeserializeConfiguration<T>(_configContainer.Value[name], name));
        }

        private static T DeserializeConfiguration<T>(XContainer doc, string name)
        {
            var query = doc.Descendants(name).Single().ToString();
            var formatter = new XmlSerializer(typeof(T));
            using (var reader = new StringReader(query))
            {
                return (T)formatter.Deserialize(reader);
            }
        }

        private static Dictionary<string, XDocument> InitContainer()
        {
            return CustomConfigurationSection.GetConfiguration().ConfigContainer;
        }
    }
}