using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using CustomConfigurationManager.Exceptions;
using CustomConfigurationManager.Serializers;

namespace CustomConfigurationManager.Xml
{
    public class XmlConfigurationService : IConfigurationService
    {
        private readonly IConfigurationSerializer _configurationSerializer;
        private readonly Lazy<Dictionary<string, string>> _configContainer;
        private readonly ConcurrentDictionary<Type, object> _configs = new ConcurrentDictionary<Type, object>();

        public XmlConfigurationService(string configurationName)
        {
            if (String.IsNullOrEmpty(configurationName))
                throw new ArgumentNullException(nameof(configurationName));

            _configContainer = new Lazy<Dictionary<string, string>>(() => InitContainer(configurationName));
            _configurationSerializer = new XmlConfigurationSerializer();
        }

        public T GetConfig<T>()
        {
            return (T) _configs.GetOrAdd(typeof(T),
                (type) =>
                {
                    var rootAttribute = type.GetCustomAttributes().OfType<XmlRootAttribute>().SingleOrDefault();
                    var name = rootAttribute?.ElementName ?? type.Name;
                    if(_configContainer.Value.TryGetValue(name, out var result))
                        return _configurationSerializer.Deserialize<T>(_configContainer.Value[name]);

                    throw new CustomConfigurationException($"Не найдено XML представление для типа {name}");
                });
        }

        protected virtual Dictionary<string, string> InitContainer(string configurationName)
        {
            return XDocument.Load(configurationName).Root.Nodes()
                .ToDictionary(m => ((XElement) m).Name.LocalName, m => m.ToString());
        }
    }
}