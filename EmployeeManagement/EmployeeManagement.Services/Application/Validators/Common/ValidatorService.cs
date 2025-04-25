using EmployeeManagement.Services.Application.Validators.Common;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;

namespace CEmployeeManagement.Services.Application.Validators.Common
{
    public class ValidatorService : IValidatorService
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<ValidationResult> ValidateAsync<T>(T instance)
        {
            var validator = _serviceProvider.GetServices<IValidator<T>>().FirstOrDefault();
            if (validator == null)
            {
                throw new InvalidOperationException($"No validator found for type {typeof(T).Name}");
            }
            return await validator.ValidateAsync(instance);
        }

        public async Task<ValidationResult> ValidateAsync<T>(T instance, Action<ValidationStrategy<T>> options)
        {
            var validator = _serviceProvider.GetServices<IValidator<T>>().FirstOrDefault();
            if (validator == null)
            {
                throw new InvalidOperationException($"No validator found for type {typeof(T).Name}");
            }
            return await validator.ValidateAsync(instance, options);
        }
    }
}
