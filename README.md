# CustomConfigurationManager

1. Объявить классы конфигурации

```csharp
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

public class Server
{
    [XmlElement("Name")] 
    public string Name { get; set; }
}

[XmlRoot("OtherName")]
public class RootedSection
{
    public int Param1 { get; set; }
    public string Param2 { get; set; }
}

```

2. Добавление секции CustomConfiguration в configSections

```xml
<configuration>
  <configSections>
    ...
    <section name="CustomConfiguration" type="CustomConfigurationManager.AppConfig.AppConfigurationSection, CustomConfigurationManager "/>
    ...
  </configSections>
</configuration>
```

3. Добавление xml для десериализации

```xml
<configuration>
  <CustomConfiguration>
   <ServersSection Parallelism="3" ParallelEnabled="true">
      <Servers>
        <Server>
          <Name>mskdmsbt269</Name>
        </Server>
        <Server>
          <Name>cf-calc3</Name>
        </Server>
      </Servers>
    </ServersSection>
      <OtherName>
          <Param1>1</Param1>
          <Param2>Param22</Param2>
      </OtherName>
  </CustomConfiguration>
</configuration>
```

4. Запросить экземпляр конфигурации

```csharp
//arrange
var target = new AppConfigurationService();

//act
var config = target.GetConfig<RootedSection>();

//assert
Assert.Equal(1, config.Param1);
Assert.Equal("Param22", config.Param2);
```
