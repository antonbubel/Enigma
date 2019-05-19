namespace Enigma.BusinessLogic.Ports
{
    using System.Threading.Tasks;

    using Models;

    public interface IEnigmaMachineConfigurationPort
    {
        Task<EnigmaMachineConfigurationModelBL> GetEnigmaMachineConfiguration(string userId);

        Task<EnigmaMachineRotorsConfigurationModelBL> GetEnigmaMachineRotorsConfiguration(string userId);

        Task SaveMachineConfiguration(string userId, EnigmaMachineConfigurationModelBL model);

        Task SaveRotorsConfiguration(string userId, EnigmaMachineRotorsConfigurationModelBL model);
    }
}
