namespace Enigma.Presentation.API.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Models;
    using Adapters;

    using Infrastructure.Exceptions;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAdapter authAdapter;

        public AuthController(IAuthAdapter authAdapter)
        {
            this.authAdapter = authAdapter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CredentialsModel model)
        {
            string token;

            try
            {
                token = await authAdapter.Authenticate(model);
            }
            catch (ApplicationAuthenticationException exception)
            {
                return new BadRequestObjectResult(exception.Message);
            }

            return new OkObjectResult(token);
        }
    }
}
