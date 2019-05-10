namespace Enigma.Machine.Integration
{
    using Enums;
    using Models;

    using Settings = Properties.EnigmaMachineConfigurationSettings;

    public sealed class Reflector : Rotor
    {
        private Reflector(RotorDefinition def)
            : base(def, 'A')
        {
        }
        
        public static Reflector Create(ReflectorVariation type)
        {
            return new Reflector(Settings.Default.Reflectors[type]);
        }
    }
}
