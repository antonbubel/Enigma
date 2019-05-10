namespace Enigma.Machine.Integration.Models
{
    using Enums;

    public class RotorInfo
    {
        public RotorInfo(RotorVariation type, char startingOffset = 'A', char ringSettingOffset = 'A')
        {
            Type = type;
            RingSettingOffset = ringSettingOffset;
            StartingOffset = startingOffset;
        }

        public RotorVariation Type { get; set; }

        public char RingSettingOffset { get; set; }

        public char StartingOffset { get; set; }
    }
}
