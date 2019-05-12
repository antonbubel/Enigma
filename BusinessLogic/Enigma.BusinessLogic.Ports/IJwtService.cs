namespace Enigma.BusinessLogic.Ports
{
    using System.Threading.Tasks;

    public interface IJwtService
    {
        Task<string> GetJwtForCredentials(object credentials);
    }
}
