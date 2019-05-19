namespace Enigma.BusinessLogic.UseCases
{
        using AutoMapper;

        using System.Threading.Tasks;

        using Microsoft.AspNetCore.Identity;

        using Models;
        using Ports;

        using Domain.Model.Entities;

    public class AccountsUseCase : IAccountsPort
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountsUseCase(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<IdentityResult> Create(CredentialsModelBL credentials)
        {
            var userIdentity = mapper.Map<ApplicationUser>(credentials);
            var identityResult = await userManager.CreateAsync(userIdentity, credentials.Password);
            
            return identityResult;
        }
    }
}
