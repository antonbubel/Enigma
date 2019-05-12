namespace Enigma.Machine.Integration
{
    using Settings = Properties.EnigmaMachineConfigurationSettings;

    public sealed class Plugboard : LetterMapper
    {
        public Plugboard(string mappings = null) : base(mappings)
        {
            if (string.IsNullOrEmpty(mappings))
            {
                Mapping = Settings.Default.PlugboardMappings;
            }
        }
    }
}
