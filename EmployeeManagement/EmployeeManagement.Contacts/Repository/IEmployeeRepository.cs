using EmployeeManagement.Models.Models;

namespace EmployeeManagement.Contacts.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeById(Guid employeeId);
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> CreateEmployee(Employee employeeModel);
        Task<Employee> UpdateEmployee(Employee employeeModel);
        Task<bool> DeleteEmployee(Guid employeeId);
    }
}
