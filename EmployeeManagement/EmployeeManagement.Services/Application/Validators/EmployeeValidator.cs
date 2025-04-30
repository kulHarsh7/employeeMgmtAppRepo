using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Services.Constants;
using EmployeeManagement.Services.Extensions;
using FluentValidation;

namespace EmployeeManagement.Services.Application.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(CreateEmployeeRequest.FirstName)))
                .MaximumLength(100).WithMessage(string.Format(ValidationErrorConstants.MaximumLength, nameof(CreateEmployeeRequest.FirstName),100));

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(CreateEmployeeRequest.LastName)))
                .MaximumLength(100).WithMessage(string.Format(ValidationErrorConstants.MaximumLength, nameof(CreateEmployeeRequest.FirstName),100));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(CreateEmployeeRequest.Email)))
                .Must(FluentExtensions.IsValidEmail).WithMessage(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(CreateEmployeeRequest.Email)));

            RuleFor(x => x.Salary)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(CreateEmployeeRequest.Salary)))
                .GreaterThan(0).WithMessage(string.Format(ValidationErrorConstants.GreaterThan, nameof(CreateEmployeeRequest.Salary),0));

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(CreateEmployeeRequest.DepartmentId)))
                .Must(FluentExtensions.BeValidGuid).WithMessage(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(CreateEmployeeRequest.DepartmentId)));
        }
    }

    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(UpdateEmployeeRequest.FirstName)))
                .MaximumLength(100).WithMessage(string.Format(ValidationErrorConstants.MaximumLength, nameof(UpdateEmployeeRequest.FirstName), 100));

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(UpdateEmployeeRequest.LastName)))
                .MaximumLength(100).WithMessage(string.Format(ValidationErrorConstants.MaximumLength, nameof(UpdateEmployeeRequest.FirstName), 100));

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(UpdateEmployeeRequest.Email)))
                .Must(FluentExtensions.IsValidEmail).WithMessage(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(UpdateEmployeeRequest.Email)));

            RuleFor(x => x.Salary)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(UpdateEmployeeRequest.Salary)))
                .GreaterThan(0).WithMessage(string.Format(ValidationErrorConstants.GreaterThan, nameof(UpdateEmployeeRequest.Salary), 0));

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(UpdateEmployeeRequest.DepartmentId)))
                .Must(FluentExtensions.BeValidGuid).WithMessage(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(UpdateEmployeeRequest.DepartmentId)));

            RuleFor(x => x.EmployeeId)
               .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(UpdateEmployeeRequest.EmployeeId)))
               .Must(FluentExtensions.BeValidGuid).WithMessage(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(UpdateEmployeeRequest.EmployeeId)));
        }
    }
}
