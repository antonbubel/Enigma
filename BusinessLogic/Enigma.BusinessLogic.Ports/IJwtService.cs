namespace Enigma.BusinessLogic.Ports
{
    using System.Threading.Tasks;

    using Models;

    public interface IJwtService
    {
        Task<string> GetJwtForCredentials(CredentialsModelBL credentials);
    }
}
