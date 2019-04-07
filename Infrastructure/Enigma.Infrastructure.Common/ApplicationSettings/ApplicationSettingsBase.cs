namespace Enigma.Infrastructure.Common.ApplicationSettings
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;

    public abstract class ApplicationSettingsBase
    {
        protected readonly IConfiguration configuration;
        protected readonly IReadOnlyDictionary<string, IConfigurationSection> sections;

        public ApplicationSettingsBase(string jsonFile)
        {
            configuration = BuildConfiguration(AppDomain.CurrentDomain.BaseDirectory, jsonFile);
            sections = GetSections();
        }

        public ApplicationSettingsBase(string path, string jsonFile)
        {
            configuration = BuildConfiguration(path, jsonFile);
            sections = GetSections();
        }

        public Dictionary<string, IConfigurationSection> GetSections()
        {
            return configuration.GetChildren()
                .ToDictionary(
                    section => section.Key,
                    section => section
                );
        }

        private IConfiguration BuildConfiguration(string path, string jsonFile)
        {
            return new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(jsonFile, optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
