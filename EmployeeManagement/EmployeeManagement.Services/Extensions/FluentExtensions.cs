using EmployeeManagement.Models.DTO.Response.Common;
using FluentValidation.Results;
using System.Text.RegularExpressions;

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

        public static bool IsValidEmail(string emailId)
        {
            if(string.IsNullOrEmpty(emailId)) return false;

            var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(emailId, emailRegex, RegexOptions.IgnoreCase);
        }

        public static bool BeValidGuid(string id)
        {
            return Guid.TryParse(id, out _);
        }
        public static Guid ParseToGuid(string id)
        {
            return Guid.TryParse(id, out var guid) ? guid : Guid.Empty;
        }
    }
}
