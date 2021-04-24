using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using System.Xml.Linq;

namespace CustomConfigurationManager.AppConfig
{
    /// <summary>
    /// Секция кастомной конфигурации
    /// </summary>
    internal class AppConfigurationSection : ConfigurationSection
    {
        public readonly Dictionary<string, string> ConfigContainer = new Dictionary<string, string>();

        /// <summary>
        /// Получить секцию конфигурации
        /// </summary>
        /// <param name="configName">Имя секции конфигурации</param>
        /// <returns>Секция</returns>
        public static AppConfigurationSection GetConfiguration(string configName)
        {
            if (String.IsNullOrEmpty(configName))
                throw new ArgumentNullException(nameof(configName));

            return (AppConfigurationSection) ConfigurationManager.GetSection(configName);
        }

        protected override bool OnDeserializeUnrecognizedElement(string name, XmlReader reader)
        {
            ConfigContainer.Add(reader.Name, XDocument.Load(reader.ReadSubtree()).ToString());
            return true;
        }
    }
}