using EmployeeManagement.Contacts.Repository;
using EmployeeManagement.Models.Models;
using EmployeeManagement.Services.DBContext;
using EmployeeManagement.Services.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Employee> CreateEmployee(Employee employeeModel)
        {
            if (employeeModel == null)
            {
                throw new InvalidModelException($"{nameof(employeeModel)} is not valid or null");
            }

            var isAlreadyExist = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Email == employeeModel.Email);

            if (isAlreadyExist != null)
            {
                throw new DuplicateRecordException("An employee with this email already exists.");
            }

            await _dbContext.Employees.AddAsync(employeeModel);
            await _dbContext.SaveChangesAsync();

            return employeeModel;
        }

        public async Task<bool> DeleteEmployee(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
            {
                throw new InvalidModelException($"{nameof(employeeId)} is not valid, null or empty");
            }

            var employee = await _dbContext.Employees.FindAsync(employeeId);

            if (employee == null)
            {
                return false;
            }

            if(employee.IsInactive)
            {
                throw new RecordIsInactiveException("Empployee is already inactive or deleted in system");
            }

            employee.IsInactive = true;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _dbContext.Employees.Where(x => !x.IsInactive).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
            {
                throw new InvalidModelException($"{nameof(employeeId)} is not valid, null or empty");
            }
            return await _dbContext.Employees.Where(x => x.EmployeeId == employeeId && !x.IsInactive).FirstOrDefaultAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employeeModel)
        {
            if (employeeModel == null)
            {
                throw new InvalidModelException($"{nameof(employeeModel)} is not valid or null");
            }

            if (employeeModel.EmployeeId == Guid.Empty)
            {
                throw new InvalidModelException($"{nameof(employeeModel.EmployeeId)} is not valid, null or empty");
            }

            var employee = await _dbContext.Employees.FindAsync(employeeModel.EmployeeId);

            if (employee == null)
            {
                return null;
            }

            if (employee.IsInactive)
            {
                throw new RecordIsInactiveException("Employee details can not be updated as employee is already inactive or deleted in system");
            }

            employee.FirstName = employeeModel.FirstName;
            employee.LastName = employeeModel.LastName;
            employee.Salary = employeeModel.Salary;
            employee.Email = employeeModel.Email;
            employee.DepartmentId = employeeModel.DepartmentId;

            await _dbContext.SaveChangesAsync();

            return employee;
        }
    }
}
