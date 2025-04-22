using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;

namespace EmployeeManagement.Contacts.Application
{
    public interface IDepartmentService
    {
        Task<DepartmentResponse> GetDepartmentById(string departmentId);
        Task<List<DepartmentResponse>> GetAllDepartments();
        Task<DepartmentResponse> CreateDepartment(CreateDepartmentRequest createDepartmentRequest);
        Task<DepartmentResponse> UpdateDepartment(UpdateDepartmentRequest updateDepartmentRequest);
        Task<bool> DeleteDepartment(string departmentId);
    }
}
