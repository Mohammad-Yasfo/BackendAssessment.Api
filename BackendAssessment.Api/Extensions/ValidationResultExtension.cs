using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BackendAssessment.Api.Extensions
{
    public static class ValidationResultExtension
    {
        public static ModelStateDictionary ToModelState(this ValidationResult validationResult, ModelStateDictionary modelState)
        {
            var uniqueErrors = validationResult.Errors
                .GroupBy(x => x.ErrorCode)
                .Select(x => x.First());

            foreach (var error in uniqueErrors)
            {
                modelState.AddModelError(error.ErrorCode, error.ErrorMessage);
            }

            return modelState;
        }
    }
}