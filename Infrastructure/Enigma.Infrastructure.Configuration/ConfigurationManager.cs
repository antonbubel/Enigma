namespace Enigma.Infrastructure.Configuration
{
    using Properties;

    public static class ConfigurationManager
    {
        public static class AppStart
        {
            public static string NLogConfigurationFile
            {
                get
                {
                    return AppStartSettings.Default.NLogConfigurationFile;
                }
            }

            public static string MigrationsAssembly
            {
                get
                {
                    return AppStartSettings.Default.MigrationsAssembly;
                }
            }
        }

        public static class Args
        {
            public static string RunAsConsoleArgument
            {
                get
                {
                    return ArgsSettings.Default.RunAsConsoleArgument;
                }
            }
        }

        public static class ConnectionStrings
        {
            public static string DefaultContext
            {
                get
                {
                    return ConnectionStringSettings.Default.DefaultContext;
                }
            }
        }
    }
}
