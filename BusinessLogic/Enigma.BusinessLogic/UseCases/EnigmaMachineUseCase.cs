namespace Enigma.BusinessLogic.UseCases
{
    using AutoMapper;

    using System.Threading.Tasks;
    
    using Ports;
    using Adapters;

    using Domain.Model;

    using Machine.Integration.Models;

    public class EnigmaMachineUseCase : IEnigmaMachinePort
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext context;
        private readonly EnigmaMachineAdapter enigmaMachine;
        private readonly IEnigmaMachineConfigurationPort enigmaMachineConfigurationPort;

        public EnigmaMachineUseCase(IMapper mapper, ApplicationContext context, 
            EnigmaMachineAdapter enigmaMachine, IEnigmaMachineConfigurationPort enigmaMachineConfigurationPort)
        {
            this.mapper = mapper;
            this.context = context;
            this.enigmaMachine = enigmaMachine;
            this.enigmaMachineConfigurationPort = enigmaMachineConfigurationPort;
        }

        public async Task<string> Encrypt(string userId, string text)
        {
            await SetEnigmaMachineConfiguration(userId);
            await SetEnigmaMachineRotorsConfiguration(userId);

            return enigmaMachine.Encrypt(text);
        }

        private async Task SetEnigmaMachineConfiguration(string userId)
        {
            var configuration = await enigmaMachineConfigurationPort
                .GetEnigmaMachineConfiguration(userId);

            if (configuration != null)
            {
                enigmaMachine.SetupRotors(mapper.Map<RotorsConfigurationSetup>(configuration));
                enigmaMachine.SetupReflector(configuration.Reflector);
                enigmaMachine.SetupPlugboard(configuration.PlugboardMap);
            }
        }

        private async Task SetEnigmaMachineRotorsConfiguration(string userId)
        {
            var rotorsConfiguration = await enigmaMachineConfigurationPort
                .GetEnigmaMachineRotorsConfiguration(userId);

            if (rotorsConfiguration != null)
            {
                enigmaMachine.SetStartupRotorRingLetters(
                    new char[] {
                        rotorsConfiguration.FirstLetter,
                        rotorsConfiguration.SecondLetter,
                        rotorsConfiguration.ThirdLetter
                    }
                );
            }
        }
    }
}
