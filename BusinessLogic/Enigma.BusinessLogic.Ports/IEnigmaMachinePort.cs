namespace Enigma.BusinessLogic.Ports
{
    using System.Threading.Tasks;

    public interface IEnigmaMachinePort
    {
        Task<string> Encrypt(string userId, string text);
    }
}
