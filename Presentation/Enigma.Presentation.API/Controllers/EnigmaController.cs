using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Enigma.Presentation.API.Controllers
{
    using Machine;

    [Route("api/[controller]")]
    [ApiController]
    public class EnigmaController : ControllerBase
    {
        private readonly IEnigmaMachine enigmaMachine;

        public EnigmaController(IEnigmaMachine enigmaMachine)
        {
            this.enigmaMachine = enigmaMachine;
        }

        [HttpGet("{value}")]
        public IActionResult Get(string value)
        {
            var response = new string(value.ToUpper().ToCharArray().Select(enigmaMachine.PressKey).ToArray());

            return Ok(new { YOUGOTMAIL = response });
        }
    }
}
