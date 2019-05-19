namespace Enigma.BusinessLogic.Adapters
{
    using Machine;
    using System.Linq;

    public class EnigmaMachineAdapter : EnigmaMachine
    {
        public string Encrypt(string text)
        {
            var encryptedLetters = text
                .ToCharArray()
                .Select(EncryptLetter)
                .ToArray();

            return new string(encryptedLetters);
        }

        private char EncryptLetter(char letter)
        {
            if (!char.IsLetter(letter))
            {
                return letter;
            }

            var ecnryptedLetter =
                PressKey(char.ToUpperInvariant(letter));

            return char.IsLower(letter)
                ? char.ToLowerInvariant(ecnryptedLetter)
                : ecnryptedLetter;
        }
    }
}
