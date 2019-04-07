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
    }
}
