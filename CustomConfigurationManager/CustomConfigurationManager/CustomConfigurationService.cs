using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CustomConfigurationManager
{
    /// <summary>
    /// Сервис получения объекта конфигурации из app.config
    /// </summary>
    public class CustomConfigurationService
    {
        private const string DefaultSectionName = "CustomConfiguration";

        private readonly string _configurationName;
        private readonly Lazy<Dictionary<string, XDocument>> _configContainer;
        private readonly ConcurrentDictionary<string, object> _configs = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// Конструктор с дефолтными параметрами
        /// </summary>
        public CustomConfigurationService() : this(DefaultSectionName)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="configurationName">Имя секции конфигурации</param>
        public CustomConfigurationService(string configurationName)
        {
            _configurationName = configurationName?? throw new ArgumentNullException(nameof(configurationName));
            _configContainer = new Lazy<Dictionary<string, XDocument>>(InitContainer);
        }

        /// <summary>
        /// Получить модель конфигурации по имени класса
        /// </summary>
        /// <typeparam name="T">Тип конфигурации</typeparam>
        /// <returns>Экземпляр конфигурации</returns>
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

        private Dictionary<string, XDocument> InitContainer()
        {
            return CustomConfigurationSection.GetConfiguration(_configurationName).ConfigContainer;
        }
    }
}