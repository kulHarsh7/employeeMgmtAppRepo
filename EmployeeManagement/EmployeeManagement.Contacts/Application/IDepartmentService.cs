using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using EmployeeManagement.Models.DTO.Response.Common;

namespace EmployeeManagement.Contacts.Application
{
    public interface IDepartmentService
    {
        Task<ApiResponse<DepartmentResponse>> GetDepartmentById(string departmentId);
        Task<ApiResponse<List<DepartmentResponse>>> GetAllDepartments();
        Task<ApiResponse<DepartmentResponse>> CreateDepartment(CreateDepartmentRequest createDepartmentRequest);
        Task<ApiResponse<DepartmentResponse>> UpdateDepartment(UpdateDepartmentRequest updateDepartmentRequest);
        Task<ApiResponse<bool>> DeleteDepartment(string departmentId);
    }
}
