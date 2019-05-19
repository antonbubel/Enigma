namespace Enigma.Presentation.API.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Adapters;
    using Models;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiUser")]
    public class EnigmaController : AuthorizedControllerBase
    {
        private readonly IEnigmaMachineAdapter enigmaMachineAdapter;

        public EnigmaController(IEnigmaMachineAdapter enigmaMachineAdapter)
        {
            this.enigmaMachineAdapter = enigmaMachineAdapter;
        }

        [HttpPost("encrypt")]
        public async Task<IActionResult> Encrypt([FromBody]RequestMessageModel model)
        {
            var message = 
                await enigmaMachineAdapter.Encrypt(UserId, model.Message);

            return Ok(message);
        }
    }
}
