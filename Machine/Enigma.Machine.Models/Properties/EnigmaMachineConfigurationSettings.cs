namespace Enigma.Machine.Integration.Properties
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Microsoft.Extensions.Configuration;

    using Infrastructure.Common.Extensions;
    using Infrastructure.Common.ApplicationSettings;

    using Enums;
    using Models;
    
    internal sealed class EnigmaMachineConfigurationSettings : ApplicationSettingsBase
    {
        public static EnigmaMachineConfigurationSettings Default
        {
            get
            {
                return new EnigmaMachineConfigurationSettings("enigma-machine-configuration.settings.json");
            }
        }

        private EnigmaMachineConfigurationSettings(string jsonFile)
            : base(jsonFile)
        {
        }

        public int AlphabetLength
        {
            get
            {
                return Convert.ToInt32(sections["alphabet-length"].Value);
            }
        }

        public string PlugboardMappings
        {
            get
            {
                return sections["plugboard-mappings"].Value;
            }
        }

        public IDictionary<RotorVariation, RotorDefinition> Rotors
        {
            get
            {
                var rotors = sections["rotors"].GetChildren();
                return ReadRotorDefinitionsFromConfiguration<RotorVariation>(rotors);
            }
        }

        public IDictionary<ReflectorVariation, RotorDefinition> Reflectors
        {
            get
            {
                var reflectors = sections["reflectors"].GetChildren();
                return ReadRotorDefinitionsFromConfiguration<ReflectorVariation>(reflectors);
            }
        }

        private IDictionary<TEnum, RotorDefinition> ReadRotorDefinitionsFromConfiguration<TEnum>(
            IEnumerable<IConfigurationSection> configurationSections)
            where TEnum: struct, IConvertible
        {
            return configurationSections.ToDictionary(
                section => section["name"].DescriptionToEnum<TEnum>(),
                section => ReadRotorDefinitionFromConfiguration(section));
        }

        private RotorDefinition ReadRotorDefinitionFromConfiguration(
            IConfigurationSection configurationSection)
        {
            return new RotorDefinition
            {
                Mappings = configurationSection["mappings"],
                Notches = configurationSection
                    .GetSection("notches")
                    .AsEnumerable()
                    .Where(notch => !string.IsNullOrEmpty(notch.Value))
                    .Select(notch => notch.Value.First())
                    .ToArray()
            };
        }
    }
}
