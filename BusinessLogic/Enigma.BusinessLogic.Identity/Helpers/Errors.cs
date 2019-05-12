﻿namespace Enigma.BusinessLogic.Identity.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public static class Errors
    {
        public static ModelStateDictionary AddErrorsToModelState(
            IdentityResult identityResult, ModelStateDictionary modelState)
        {
            foreach (var error in identityResult.Errors)
            {
                modelState.TryAddModelError(error.Code, error.Description);
            }

            return modelState;
        }

        public static ModelStateDictionary AddErrorToModelState(
            string code, string description, ModelStateDictionary modelState)
        {
            modelState.TryAddModelError(code, description);
            return modelState;
        }
    }
}
