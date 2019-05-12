namespace Enigma.Machine.Integration
{
    using System;
    using System.Linq;
    
    using Enums;
    using Models;
    using Extensions;

    using Settings = Properties.EnigmaMachineConfigurationSettings;
    
    public class Rotor : LetterMapper
    {
        private readonly char[] _notches;
        private readonly int _offset;

        protected Rotor(RotorDefinition def, char offsetLetter)
            : base(def.Mappings)
        {
            _notches = def.Notches;
            _offset = offsetLetter - 'A';
        }

        public override char GetMappedLetter(char letter, MappingDirection dir = MappingDirection.RightToLeft)
        {
            if (dir == MappingDirection.RightToLeft)
            {
                char innerMapping = Mapping[letter.AddOffset(-_offset) - 'A'];
                return innerMapping.AddOffset(_offset);
            }

            char innerInput = letter.AddOffset(-_offset);
            return (char)(((Mapping.IndexOf(innerInput) + _offset) % Settings.Default.AlphabetLength) + 'A');
        }

        public static Rotor Create(RotorVariation type, char offset = 'A')
        {
            return new Rotor(Settings.Default.Rotors[type], offset);
        }

        public bool IsNotch(char letter)
        {
            return _notches.Contains(letter);
        }
    }
}
