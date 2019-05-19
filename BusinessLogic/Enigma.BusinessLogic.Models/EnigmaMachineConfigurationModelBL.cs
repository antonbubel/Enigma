namespace Enigma.BusinessLogic.Models
{
    using Machine.Integration.Enums;

    public class EnigmaMachineConfigurationModelBL
    {
        public RotorVariation FirstRotor { get; set; }
        public RotorVariation SecondRotor { get; set; }
        public RotorVariation ThirdRotor { get; set; }
        public ReflectorVariation Reflector { get; set; }
        public string PlugboardMap { get; set; }
    }
}
