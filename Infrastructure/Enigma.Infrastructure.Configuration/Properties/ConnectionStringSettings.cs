namespace Enigma.Infrastructure.Configuration.Properties
{
    using Common.ApplicationSettings;

    internal sealed class ConnectionStringSettings : ApplicationSettingsBase
    {
        public static ConnectionStringSettings Default
        {
            get
            {
                return new ConnectionStringSettings("connectionstring.settings.json");
            }
        }

        private ConnectionStringSettings(string jsonFile)
            : base(jsonFile)
        {
        }

        public string DefaultContext
        {
            get
            {
                return sections["default"].Value;
            }
        }
    }
}
