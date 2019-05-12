namespace Enigma.Infrastructure.Exceptions
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationIdentityException : ApplicationException
    {
        public IEnumerable<IdentityError> IdentityErrors { get; set; }

        public ApplicationIdentityException(IdentityResult identityResult)
            : base(identityResult.ToString())
        {
            IdentityErrors = identityResult.Errors;
        }
    }
}
