using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using EmployeeManagement.Models.DTO.Response.Common;

namespace EmployeeManagement.Contacts.Application
{
    public interface IEmployeeService
    {
        Task<ApiResponse<EmployeeResponse>> GetEmployeeById(string employeeId);
        Task<ApiResponse<List<EmployeeResponse>>> GetAllEmployees();
        Task<ApiResponse<EmployeeResponse>> CreateEmployee(CreateEmployeeRequest createEmployeeRequest);
        Task<ApiResponse<EmployeeResponse>> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest);
        Task<ApiResponse<bool>> DeleteEmployee(string employeeId);
    }
}
