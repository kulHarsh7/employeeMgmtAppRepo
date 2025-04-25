using EmployeeManagement.Models.DTO.Response.Common;
using FluentValidation.Results;

namespace EmployeeManagement.Services.Extensions
{
    public static class FluentExtensions
    {
        public static List<Error> ToErrors(this ValidationResult validationResult)
        {
            var errors = new List<Error>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new Error(error.ErrorMessage));
            }
            return errors;
        }
    }
}
