using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;

namespace EmployeeManagement.Contacts.Application
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> GetEmployeeById(string employeeId);
        Task<List<EmployeeResponse>> GetAllEmployees();
        Task<EmployeeResponse> CreateEmployee(CreateEmployeeRequest createEmployeeRequest);
        Task<EmployeeResponse> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest);
        Task<bool> DeleteEmployee(string employeeId);
    }
}
