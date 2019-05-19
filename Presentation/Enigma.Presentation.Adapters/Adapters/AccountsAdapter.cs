namespace Enigma.Presentation.Adapters
{
    using AutoMapper;
    
    using System.Threading.Tasks;

    using Models;

    using BusinessLogic.Models;
    using BusinessLogic.Ports;

    using Infrastructure.Exceptions;
    using Microsoft.Extensions.Logging;

    public class AccountsAdapter : IAccountsAdapter
    {
        private readonly ILogger<IAccountsAdapter> logger;
        private readonly IMapper mapper;
        private readonly IAccountsPort accountsPort;

        public AccountsAdapter(ILogger<IAccountsAdapter> logger, IMapper mapper, IAccountsPort accountsPort)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.accountsPort = accountsPort;
        }

        public async Task Create(CredentialsModel credentials)
        {
            var credentialsBL = mapper.Map<CredentialsModelBL>(credentials);
            var identityResult = await accountsPort.Create(credentialsBL);

            if (!identityResult.Succeeded)
            {
                logger.LogWarning($"Failed to create account with username: {credentials.Username}. Identity result: {identityResult.ToString()}");
                throw new ApplicationIdentityException(identityResult);
            }
        }
    }
}
