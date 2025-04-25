using EmployeeManagement.Models.DTO.Request;
using FluentValidation;

namespace EmployeeManagement.Services.Application.Validators
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
    {
    }

    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
    {
    }
}
