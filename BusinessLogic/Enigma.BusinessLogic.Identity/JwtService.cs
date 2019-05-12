namespace Enigma.BusinessLogic.Identity
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Models;
    using Ports;
    using Helpers;

    using Domain.Model.Entities;

    public class JwtService : IJwtService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtFactory jwtFactory;
        private readonly JwtIssuerOptions jwtOptions;

        public JwtService(UserManager<ApplicationUser> userManager, 
            IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            this.userManager = userManager;
            this.jwtFactory = jwtFactory;
            this.jwtOptions = jwtOptions.Value;
        }

        public async Task<string> GetJwtForCredentials(CredentialsModelBL credentials)
        {
            var identity = await GetClaimsIdentity(credentials.Username, credentials.Password);

            if (identity == null)
            {
                return null;
            }

            return await Tokens.GenerateJwt(
                identity, 
                jwtFactory, 
                credentials.Username, 
                jwtOptions, 
                new JsonSerializerSettings { Formatting = Formatting.Indented }
            );
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return await Task.FromResult<ClaimsIdentity>(null);
            }

            var userToVerify = await userManager.FindByNameAsync(username);

            if (userToVerify == null)
            {
                return await Task.FromResult<ClaimsIdentity>(null);
            }

            if (await userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(jwtFactory.GenerateClaimsIdentity(username, userToVerify.Id));
            }

            return await Task.FromResult<ClaimsIdentity>(null);
        }

    }
}
