using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using EmployeeManagement.Models.Models;
using Mapster;

namespace EmployeeManagement.Services.Mapster
{
    public static class DepartmentMapper
    {
        public static void Configure()
        {
            TypeAdapterConfig<CreateDepartmentRequest, Department>.NewConfig()
           .Map(dest => dest.Name, src => src.DepartmentName);

            TypeAdapterConfig<UpdateDepartmentRequest, Department>.NewConfig()
           .Map(dest => dest.DepartmentId, src => ToGuidOrEmpty(src.DepartmentId))
           .Map(dest => dest.Name, src => src.DepartmentName);

            TypeAdapterConfig<Department, DepartmentResponse>.NewConfig()
           .Map(dest => dest.DepartmentId, src => src.DepartmentId.ToString())
           .Map(dest => dest.DepartmentName, src => src.Name);

        }

        #region Extended Methods
        private static Guid ToGuidOrEmpty(string value)
        {
            return Guid.TryParse(value, out var guid) ? guid : Guid.Empty;
        }

        #endregion
    }
}
