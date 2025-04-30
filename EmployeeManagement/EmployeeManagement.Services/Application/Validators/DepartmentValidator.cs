using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Services.Constants;
using EmployeeManagement.Services.Extensions;
using FluentValidation;

namespace EmployeeManagement.Services.Application.Validators
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartmentRequest>
    {
        public CreateDepartmentValidator()
        {

            RuleFor(x => x.DepartmentName)
           .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(CreateDepartmentRequest.DepartmentName)))
           .MaximumLength(100).WithMessage(string.Format(ValidationErrorConstants.MaximumLength, nameof(CreateDepartmentRequest.DepartmentName), 100));

        }
    }
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentRequest>
    {
        public UpdateDepartmentValidator()
        {

            RuleFor(x => x.DepartmentName)
           .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(UpdateDepartmentRequest.DepartmentName)))
           .MaximumLength(100).WithMessage(string.Format(ValidationErrorConstants.MaximumLength, nameof(UpdateDepartmentRequest.DepartmentName), 100));

            RuleFor(x => x.DepartmentId)
           .NotEmpty().WithMessage(string.Format(ValidationErrorConstants.Required, nameof(UpdateDepartmentRequest.DepartmentId)))
           .Must(FluentExtensions.BeValidGuid).WithMessage(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(UpdateDepartmentRequest.DepartmentId), 100));

        }
    }
}
