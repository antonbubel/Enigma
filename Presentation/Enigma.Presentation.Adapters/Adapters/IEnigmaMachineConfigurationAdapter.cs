namespace Enigma.Presentation.Adapters
{
    using System.Threading.Tasks;

    using Models;

    public interface IEnigmaMachineConfigurationAdapter
    {
        Task<EnigmaMachineConfigurationModel> GetEnigmaMachineConfiguration(string userId);

        Task<EnigmaMachineRotorsConfigurationModel> GetEnigmaMachineRotorsConfiguration(string userId);

        Task SetEnigmaMachineConfiguration(string userId, EnigmaMachineConfigurationModel model);

        Task SetEnigmaMachineRotorsConfiguration(string userId, EnigmaMachineRotorsConfigurationModel model);
    }
}
