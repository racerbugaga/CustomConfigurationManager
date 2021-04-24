namespace CustomConfigurationManager
{
    public interface IConfigurationSerializer
    {
        T Deserialize<T>(string data);
    }
}