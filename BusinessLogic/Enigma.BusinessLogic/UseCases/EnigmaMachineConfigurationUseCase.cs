namespace Enigma.BusinessLogic.UseCases
{
    using AutoMapper;

    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Models;
    using Ports;

    using Domain.Model;
    using Domain.Model.Entities;

    public class EnigmaMachineConfigurationUseCase : IEnigmaMachineConfigurationPort
    {
        private readonly IMapper mapper;
        private readonly ApplicationContext context;

        public EnigmaMachineConfigurationUseCase(IMapper mapper, ApplicationContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<EnigmaMachineConfigurationModelBL> 
            GetEnigmaMachineConfiguration(string userId)
        {
            var enigmaConfiguration = await context.Set<EnigmaConfiguration>()
                .FirstOrDefaultAsync(configuration => configuration.ApplicationUserId == userId);

            return mapper.Map<EnigmaMachineConfigurationModelBL>(enigmaConfiguration);
        }

        public async Task<EnigmaMachineRotorsConfigurationModelBL> 
            GetEnigmaMachineRotorsConfiguration(string userId)
        {
            var rotorsConfiguration = await context.Set<RotorsConfiguration>()
                .FirstOrDefaultAsync(configuration => configuration.ApplicationUserId == userId);

            return mapper.Map<EnigmaMachineRotorsConfigurationModelBL>(rotorsConfiguration);
        }

        public async Task SaveMachineConfiguration(string userId, EnigmaMachineConfigurationModelBL model)
        {
            await RemoveExisitngUserMachineConfigurations(userId);

            var configuration = mapper.Map<EnigmaConfiguration>(model);
            configuration.ApplicationUserId = userId;

            await context.AddAsync(configuration);
            await context.SaveChangesAsync();
        }

        public async Task SaveRotorsConfiguration(string userId, EnigmaMachineRotorsConfigurationModelBL model)
        {
            await RemoveExisitngUserRotorsConfigurations(userId);

            var configuration = mapper.Map<RotorsConfiguration>(model);
            configuration.ApplicationUserId = userId;

            await context.AddAsync(configuration);
            await context.SaveChangesAsync();
        }

        private async Task RemoveExisitngUserMachineConfigurations(string userId)
        {
            var configurations = context.Set<EnigmaConfiguration>()
                .Where(configuration => configuration.ApplicationUserId == userId);

            context.RemoveRange(configurations);

            await context.SaveChangesAsync();
        }

        private async Task RemoveExisitngUserRotorsConfigurations(string userId)
        {
            var configurations = context.Set<RotorsConfiguration>()
                .Where(configuration => configuration.ApplicationUserId == userId);

            context.RemoveRange(configurations);

            await context.SaveChangesAsync();
        }
    }
}
