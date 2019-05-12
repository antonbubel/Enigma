using System;
using System.Collections.Generic;
using System.Text;

namespace Enigma.Infrastructure.Configuration.Properties
{
    using Common.ApplicationSettings;

    internal sealed class AppStartSettings : ApplicationSettingsBase
    {
        public static AppStartSettings Default
        {
            get
            {
                return new AppStartSettings("appstart.settings.json");
            }
        }

        private AppStartSettings(string jsonFile)
            : base(jsonFile)
        {
        }
        
        public string NLogConfigurationFile
        {
            get
            {
                return sections["nlog-configuration-file"].Value;
            }
        }

        public string MigrationsAssembly
        {
            get
            {
                return sections["migrations-assembly"].Value;
            }
        }
    }
}
