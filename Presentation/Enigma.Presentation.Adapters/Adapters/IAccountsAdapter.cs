namespace Enigma.Presentation.Adapters
{
    using System.Threading.Tasks;

    using Models;

    public interface IAccountsAdapter
    {
        Task Create(CredentialsModel credentials);
    }
}
