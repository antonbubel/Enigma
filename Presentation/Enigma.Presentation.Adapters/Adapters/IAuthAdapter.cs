namespace Enigma.Presentation.Adapters
{
    using System.Threading.Tasks;

    using Models;

    public interface IAuthAdapter
    {
        Task<string> Authenticate(CredentialsModel credentials);
    }
}
