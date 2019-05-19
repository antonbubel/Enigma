namespace Enigma.Presentation.Adapters
{
    using AutoMapper;

    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using Models;

    using BusinessLogic.Models;
    using BusinessLogic.Ports;

    using Infrastructure.Exceptions;

    public class AuthAdapter : IAuthAdapter
    {
        private readonly ILogger<IAuthAdapter> logger;
        private readonly IMapper mapper;
        private readonly IJwtService jwtService;

        public AuthAdapter(ILogger<IAuthAdapter> logger, IMapper mapper, IJwtService jwtService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.jwtService = jwtService;
        }

        public async Task<string> Authenticate(CredentialsModel credentials)
        {
            var credentialsBL = mapper.Map<CredentialsModelBL>(credentials);
            var token = await jwtService.GetJwtForCredentials(credentialsBL);

            if (string.IsNullOrEmpty(token))
            {
                logger.LogWarning($"Authentication failed for username: {credentials.Username}. Token not generated");
                throw new ApplicationAuthenticationException("Authentication failed");
            }

            return token;
        }
    }
}
