namespace Service.Impl
{
    public class ServiceAgent
    {
        private readonly IConfigReader _configReader;
        public ServiceAgent(IConfigReader configReader)
        {
            _configReader = configReader;
        }

        public string RetrieveReport()
        {
            _configReader.Initialise(@"C:\Temp\report.config");
            var configuredData = _configReader.GetConfigData();

            // retrieve report based on configuredData
            return configuredData.ConfigData;
        }
    }
}
