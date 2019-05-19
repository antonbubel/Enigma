namespace Enigma.Presentation.API.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using Models;
    using Adapters;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiUser")]
    public class EnigmaConfigurationController : AuthorizedControllerBase
    {
        private readonly IEnigmaMachineConfigurationAdapter enigmaMachineConfigurationAdapter;

        public EnigmaConfigurationController(
            IEnigmaMachineConfigurationAdapter enigmaMachineConfigurationAdapter)
        {
            this.enigmaMachineConfigurationAdapter = enigmaMachineConfigurationAdapter;
        }

        [HttpGet("configuration")]
        public async Task<IActionResult> GetConfiguration()
        {
            var model = await enigmaMachineConfigurationAdapter
                .GetEnigmaMachineConfiguration(UserId);

            return Ok(model);
        }

        [HttpGet("rotors-configuration")]
        public async Task<IActionResult> GetRotorsConfiguration()
        {
            var model = await enigmaMachineConfigurationAdapter
                .GetEnigmaMachineRotorsConfiguration(UserId);

            return Ok(model);
        }

        [HttpPut("configuration")]
        public async Task<IActionResult> SaveConfiguration(
            [FromBody]EnigmaMachineConfigurationModel model)
        {
            await enigmaMachineConfigurationAdapter
                .SetEnigmaMachineConfiguration(UserId, model);

            return Ok();
        }

        [HttpPut("rotors-configuration")]
        public async Task<IActionResult> SaveRotorsConfiguration(
            [FromBody]EnigmaMachineRotorsConfigurationModel model)
        {
            await enigmaMachineConfigurationAdapter
                .SetEnigmaMachineRotorsConfiguration(UserId, model);

            return Ok();
        }
    }
}
