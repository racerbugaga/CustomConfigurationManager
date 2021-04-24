using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using CustomConfigurationManager.Exceptions;
using CustomConfigurationManager.Xml;

namespace CustomConfigurationManager.AppConfig
{
    /// <summary>
    /// Сервис получения объекта конфигурации из app.config
    /// </summary>
    public class AppConfigurationService : XmlConfigurationService
    {
        private const string DefaultSectionName = "CustomConfiguration";
        private readonly string _configurationName;

        /// <summary>
        /// Конструктор с дефолтными параметрами
        /// </summary>
        public AppConfigurationService() : this(DefaultSectionName)
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="configurationName">Имя секции конфигурации</param>
        public AppConfigurationService(string configurationName) : base(configurationName)
        {
            _configurationName = configurationName;
        }

        protected override Dictionary<string, string> InitContainer(string _)
        {
            var section = AppConfigurationSection.GetConfiguration(_configurationName)
                          ?? throw new CustomConfigurationException($"Не найдена секция {_configurationName}");
            return section.ConfigContainer;
        }
    }
}