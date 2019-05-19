namespace Enigma.Domain.Model.Entities
{
    public class EnigmaConfiguration
    {
        public long EnigmaConfigurationId { get; set; }
        
        public int FirstRotor { get; set; }
        public int SecondRotor { get; set; }
        public int ThirdRotor { get; set; }
        public int Reflector { get; set; }
        public string PlugboardMap { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
