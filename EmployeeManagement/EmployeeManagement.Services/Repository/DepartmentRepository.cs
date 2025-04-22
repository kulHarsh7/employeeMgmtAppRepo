using EmployeeManagement.Contacts.Repository;
using EmployeeManagement.Models.Models;
using EmployeeManagement.Services.DBContext;

namespace EmployeeManagement.Services.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public DepartmentRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<Department> CreateDepartment(Department DepartmentModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartment(Guid DepartmentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartmentById(Guid DepartmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Department> UpdateDepartment(Department DepartmentModel)
        {
            throw new NotImplementedException();
        }
    }
}
