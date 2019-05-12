namespace Enigma.Machine
{
    using Integration.Enums;
    using Integration.Models;

    public interface IEnigmaMachine
    {
        char PressKey(char letter);

        void SetupPlugboard(string mappings);

        void SetupRotors(RotorsConfigurationSetup configuration);

        void SetupReflector(ReflectorVariation type);

        char[] GetCurrentRotorRingLetters();

        void SetStartupRotorRingLetters(char[] letters);

        void ResetRotors();
    }
}
