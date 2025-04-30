using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using EmployeeManagement.Models.Models;
using Mapster;

namespace EmployeeManagement.Services.Mapster
{
    public static class EmployeeMapper
    {
        public static void Configure()
        {
           TypeAdapterConfig<CreateEmployeeRequest, Employee>.NewConfig()
          .Map(dest => dest.FirstName, src => src.FirstName)
          .Map(dest => dest.LastName, src => src.LastName)
          .Map(dest => dest.Email, src => src.Email)
          .Map(dest => dest.Salary, src => src.Salary)
          .Map(dest => dest.DepartmentId, src => ToGuidOrEmpty(src.DepartmentId));

           TypeAdapterConfig<UpdateEmployeeRequest, Employee>.NewConfig()
          .Map(dest => dest.EmployeeId, src => ToGuidOrEmpty(src.EmployeeId))
          .Map(dest => dest.FirstName, src => src.FirstName)
          .Map(dest => dest.LastName, src => src.LastName)
          .Map(dest => dest.Email, src => src.Email)
          .Map(dest => dest.Salary, src => src.Salary)
          .Map(dest => dest.DepartmentId, src => ToGuidOrEmpty(src.DepartmentId));

           TypeAdapterConfig<Employee, EmployeeResponse>.NewConfig()
          .Map(dest => dest.FirstName, src => src.FirstName)
          .Map(dest => dest.LastName, src => src.LastName)
          .Map(dest => dest.Email, src => src.Email)
          .Map(dest => dest.Salary, src => src.Salary)
          .Map(dest => dest.DepartmentId, src => src.DepartmentId.ToString())
          .Map(dest => dest.DepartmentName, src => src.Department.Name);

        }

        #region Extended Methods
        private static Guid ToGuidOrEmpty(string value)
        {
            return Guid.TryParse(value, out var guid) ? guid : Guid.Empty;
        }

        #endregion
    }
}
