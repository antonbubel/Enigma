namespace Enigma.Presentation.Adapters
{
    using AutoMapper;

    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using Models;

    using BusinessLogic.Ports;
    
    public class EnigmaMachineAdapter : IEnigmaMachineAdapter
    {
        private readonly ILogger<IAccountsAdapter> logger;
        private readonly IMapper mapper;
        private readonly IEnigmaMachinePort enigmaMachinePort;

        public EnigmaMachineAdapter(ILogger<IAccountsAdapter> logger, IMapper mapper, IEnigmaMachinePort enigmaMachinePort)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.enigmaMachinePort = enigmaMachinePort;
        }

        public async Task<ResponseMessageModel> Encrypt(string userId, string text)
        {
            string encryptedText = string.Empty;

            try
            {
                encryptedText = await enigmaMachinePort.Encrypt(userId, text);
            }
            catch (Exception exception)
            {
                logger.LogError(exception,
                    $"An error has occured while trying to encrypt the message, user id: {userId}");
            }

            return new ResponseMessageModel { Message = encryptedText };
        }
    }
}
