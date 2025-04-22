using EmployeeManagement.Models.Models;

namespace EmployeeManagement.Contacts.Repository
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentById(Guid DepartmentId);
        Task<List<Department>> GetAllDepartments();
        Task<Department> CreateDepartment(Department DepartmentModel);
        Task<Department> UpdateDepartment(Department DepartmentModel);
        Task<bool> DeleteDepartment(Guid DepartmentId);
    }
}
