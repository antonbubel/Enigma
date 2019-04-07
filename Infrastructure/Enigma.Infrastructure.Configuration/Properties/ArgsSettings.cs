namespace Enigma.Infrastructure.Configuration.Properties
{
    using Common.ApplicationSettings;

    internal sealed class ArgsSettings : ApplicationSettingsBase
    {
        public static ArgsSettings Default
        {
            get
            {
                return new ArgsSettings("args.settings.json");
            }
        }

        private ArgsSettings(string jsonFile)
            : base(jsonFile)
        {
        }

        public string RunAsConsoleArgument
        {
            get
            {
                return sections["run-as-console"].Value;
            }
        }
    }
}
