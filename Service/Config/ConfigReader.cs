using System;

namespace Service
{
    public class ConfigReader : IConfigReader
    {
        private bool _initialised;
        private string _configPath;

        public ConfigReader()
        {
            _initialised = false;
            _configPath = null;
        }

        public bool Initialise(string configPath)
        {
            _initialised = true;
            _configPath = configPath;
            return true;
        }

        public ConfigDto GetConfigData()
        {
            if (!_initialised)
            {
                throw new InvalidOperationException();
            }

            return new ConfigDto
            {
                ConfigData = Guid.NewGuid().ToString(),
                ConfigSource = _configPath
            };
        }
    }
}