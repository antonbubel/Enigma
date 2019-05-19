namespace Enigma.Domain.Model.Entities
{
    public class RotorsConfiguration
    {
        public long RotorsConfigurationId { get; set; }

        public char FirstLetter { get; set; }
        public char SecondLetter { get; set; }
        public char ThirdLetter { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
