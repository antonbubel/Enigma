namespace Enigma.Machine.Integration
{
    using Enums;

    public class LetterMapper
    {
        public LetterMapper(string mapping)
        {
            Mapping = mapping;
        }

        protected string Mapping { get; set; }

        public virtual char GetMappedLetter(
            char letter, MappingDirection mappingDirection = MappingDirection.RightToLeft)
        {
            if (mappingDirection == MappingDirection.RightToLeft)
            {
                return Mapping[letter - 'A'];
            }
            
            return (char)(Mapping.IndexOf(letter) + 'A');
        }
    }
}
