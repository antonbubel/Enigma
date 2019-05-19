namespace Enigma.Presentation.Adapters
{
    using System.Threading.Tasks;

    using Models;

    public interface IEnigmaMachineAdapter
    {
        Task<ResponseMessageModel> Encrypt(string userId, string text);
    }
}
