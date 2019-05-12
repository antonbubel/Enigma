namespace Enigma.BusinessLogic.Ports
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Models;

    public interface IAccountsPort
    {
        Task<IdentityResult> Create(CredentialsModelBL credentials);
    }
}
