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

        public static class Identity
        {
            public static string JwtIssuer
            {
                get
                {
                    return IdentitySettings.Default.JwtIssuer;
                }
            }

            public static string JwtIssuerAudience
            {
                get
                {
                    return IdentitySettings.Default.JwtIssuerAudience;
                }
            }

            public static string SecretKey
            {
                get
                {
                    return IdentitySettings.Default.SecretKey;
                }
            }

            public static int PasswordRequiredLength
            {
                get
                {
                    return IdentitySettings.Default.PasswordRequiredLength;
                }
            }
        }
    }
}
