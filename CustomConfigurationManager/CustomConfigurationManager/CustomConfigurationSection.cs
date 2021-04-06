using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace CustomConfigurationManager
{
    /// <summary>
    /// Секция кастомной конфигурации
    /// </summary>
    internal class CustomConfigurationSection : ConfigurationSection
    {
        public readonly Dictionary<string, XDocument> ConfigContainer = new Dictionary<string, XDocument>();

        /// <summary>
        /// Получить секцию конфигурации
        /// </summary>
        /// <param name="configName">Имя секции конфигурации</param>
        /// <returns>Секция</returns>
        public static CustomConfigurationSection GetConfiguration(string configName)
        {
            if (String.IsNullOrEmpty(configName))
                throw new ArgumentNullException(nameof(configName));
            
            return (CustomConfigurationSection) ConfigurationManager.GetSection(configName);
        }

        protected override bool OnDeserializeUnrecognizedElement(string name, XmlReader reader)
        {
            ConfigContainer.Add(reader.Name, XDocument.Load(reader.ReadSubtree()));
            return true;
        }
    }
}