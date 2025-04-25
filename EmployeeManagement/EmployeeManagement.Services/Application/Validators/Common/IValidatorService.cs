using FluentValidation.Internal;
using FluentValidation.Results;

namespace EmployeeManagement.Services.Application.Validators.Common
{
    public interface IValidatorService
    {
        Task<ValidationResult> ValidateAsync<T>(T instance);
        Task<ValidationResult> ValidateAsync<T>(T instance, Action<ValidationStrategy<T>> options);
    }
}
