namespace Enigma.Machine.Integration.Extensions
{
    using System;
    using Settings = Properties.EnigmaMachineConfigurationSettings;

    public static class LetterExtensions
    {
        public static char AddOffset(this char letter, int offset)
        {
            if (!char.IsLetter(letter))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(letter), "The input character must be a letter.");
            }
                
            if (!char.IsUpper(letter))
            {
                throw new ArgumentException(
                    "Letter must be uppercase.", nameof(letter));
            }
            
            return (char)(((letter - 'A' + offset + Settings.Default.AlphabetLength) % Settings.Default.AlphabetLength) + 'A');
        }

        public static char AddOffset(this char letter, char letterOffset)
        {
            if (!char.IsLetter(letter))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(letter), "The input character must be a letter.");
            }
                
            if (!char.IsUpper(letter))
            {
                throw new ArgumentException(
                    "Letter must be uppercase.", nameof(letter));
            }
                
            if (!char.IsLetter(letterOffset))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(letterOffset), "The input character must be a letter.");
            }
                
            if (!char.IsUpper(letterOffset))
            {
                throw new ArgumentException(
                    "Letter must be uppercase.", nameof(letterOffset));
            }
            
            return AddOffset(letter, (letterOffset - 'A'));
        }

        public static char RemoveOffset(this char letter, char letterOffset)
        {
            if (!char.IsLetter(letter))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(letter), "The input character must be a letter.");
            }
                
            if (!char.IsUpper(letter))
            {
                throw new ArgumentException(
                    "Letter must be uppercase.", nameof(letter));
            }
                
            if (!char.IsLetter(letterOffset))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(letterOffset), "The input character must be a letter.");
            }
                
            if (!char.IsUpper(letterOffset))
            {
                throw new ArgumentException(
                    "Letter must be uppercase.", nameof(letterOffset));
            }
            
            return AddOffset(letter, -(letterOffset - 'A'));
        }
    }
}
