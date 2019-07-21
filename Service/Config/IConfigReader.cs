namespace Service
{
    public interface IConfigReader
    {
        bool Initialise(string configPath);
        ConfigDto GetConfigData();
    }
}