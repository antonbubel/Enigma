namespace Enigma.Presentation.API.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Models;
    using Adapters;

    using Infrastructure.Exceptions;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsAdapter accountsAdapter;

        public AccountsController(IAccountsAdapter accountsAdapter)
        {
            this.accountsAdapter = accountsAdapter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CredentialsModel model)
        {
            try
            {
                await accountsAdapter.Create(model);
            }
            catch (ApplicationIdentityException exception)
            {
                return new BadRequestObjectResult(exception.IdentityErrors);
            }
            
            return Ok();
        }
    }
}
