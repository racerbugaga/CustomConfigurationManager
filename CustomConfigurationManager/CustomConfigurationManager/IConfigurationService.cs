namespace CustomConfigurationManager
{
    public interface IConfigurationService
    {
        T GetConfig<T>();
    }
}