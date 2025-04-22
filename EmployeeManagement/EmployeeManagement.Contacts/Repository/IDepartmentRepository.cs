using EmployeeManagement.Models.Models;

namespace EmployeeManagement.Contacts.Repository
{
    public interface IDepartmentRepository
    {
        Task<Department> GetDepartmentById(Guid departmentId);
        Task<List<Department>> GetAllDepartments();
        Task<Department> CreateDepartment(Department departmentModel);
        Task<Department> UpdateDepartment(Department departmentModel);
        Task<bool> DeleteDepartment(Guid departmentId);
    }
}
