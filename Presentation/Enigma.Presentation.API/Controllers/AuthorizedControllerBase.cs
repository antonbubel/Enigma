namespace Enigma.Presentation.API.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using BusinessLogic.Identity.Helpers;

    public abstract class AuthorizedControllerBase : ControllerBase
    {
        public string UserId
        {
            get
            {
                return User.Claims
                    .FirstOrDefault(claim => claim.Type == Constants.JwtClaimIdentifiers.Id)
                    ?.Value;
            }
        }
    }
}
