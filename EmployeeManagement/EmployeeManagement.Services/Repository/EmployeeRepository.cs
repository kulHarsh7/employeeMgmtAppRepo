using EmployeeManagement.Contacts.Repository;
using EmployeeManagement.Models.Models;
using EmployeeManagement.Services.DBContext;

namespace EmployeeManagement.Services.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<Employee> CreateEmployee(Employee employeeModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployee(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetEmployeeById(Guid employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateEmployee(Employee employeeModel)
        {
            throw new NotImplementedException();
        }
    }
}
