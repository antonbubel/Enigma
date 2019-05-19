namespace Enigma.Presentation.Adapters
{
    using AutoMapper;

    using System;
    using System.Threading.Tasks;

    using Models;

    using BusinessLogic.Models;
    using BusinessLogic.Ports;
    
    using Microsoft.Extensions.Logging;

    public class EnigmaMachineConfigurationAdapter : IEnigmaMachineConfigurationAdapter
    {
        private readonly ILogger<IAccountsAdapter> logger;
        private readonly IMapper mapper;
        private readonly IEnigmaMachineConfigurationPort enigmaMachineConfigurationPort;

        public EnigmaMachineConfigurationAdapter(ILogger<IAccountsAdapter> logger, IMapper mapper, 
            IEnigmaMachineConfigurationPort enigmaMachineConfigurationPort)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.enigmaMachineConfigurationPort = enigmaMachineConfigurationPort;
        }

        public async Task<EnigmaMachineConfigurationModel> GetEnigmaMachineConfiguration(string userId)
        {
            EnigmaMachineConfigurationModel model = null;

            try
            {
                var configuration = await enigmaMachineConfigurationPort
                    .GetEnigmaMachineConfiguration(userId);

                model = mapper.Map<EnigmaMachineConfigurationModel>(configuration);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, 
                    $"An error has occured while trying to get machine configuation for user id: {userId}");
            }

            return model;
        }

        public async Task<EnigmaMachineRotorsConfigurationModel> GetEnigmaMachineRotorsConfiguration(string userId)
        {
            EnigmaMachineRotorsConfigurationModel model = null;

            try
            {
                var configuration = await enigmaMachineConfigurationPort
                    .GetEnigmaMachineRotorsConfiguration(userId);

                model = mapper.Map<EnigmaMachineRotorsConfigurationModel>(configuration);
            }
            catch (Exception exception)
            {
                logger.LogError(exception,
                    $"An error has occured while trying to get machine rotors configuation for user id: {userId}");
            }

            return model;
        }

        public async Task SetEnigmaMachineConfiguration(string userId, EnigmaMachineConfigurationModel model)
        {
            try
            {
                var configuration = mapper.Map<EnigmaMachineConfigurationModelBL>(model);
                await enigmaMachineConfigurationPort.SaveMachineConfiguration(userId, configuration);
            }
            catch (Exception exception)
            {
                logger.LogError(exception,
                    $"An error has occured while trying to save machine configuration for user id: {userId}");
            }
        }

        public async Task SetEnigmaMachineRotorsConfiguration(string userId, EnigmaMachineRotorsConfigurationModel model)
        {
            try
            {
                var configuration = mapper.Map<EnigmaMachineRotorsConfigurationModelBL>(model);
                await enigmaMachineConfigurationPort.SaveRotorsConfiguration(userId, configuration);
            }
            catch (Exception exception)
            {
                logger.LogError(exception,
                    $"An error has occured while trying to save machine rotors configuration for user id: {userId}");
            }
        }
    }
}
