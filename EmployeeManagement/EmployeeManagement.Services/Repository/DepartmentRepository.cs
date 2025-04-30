using EmployeeManagement.Contacts.Repository;
using EmployeeManagement.Models.Models;
using EmployeeManagement.Services.DBContext;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public DepartmentRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Department> CreateDepartment(Department departmentModel)
        {
            if (departmentModel == null)
            {
                throw new ArgumentNullException(nameof(departmentModel));
            }

            var isAlreadyExist = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Name == departmentModel.Name);

            if (isAlreadyExist != null)
            {
                throw new InvalidOperationException("An department with this email already exists.");
            }

            await _dbContext.Departments.AddAsync(departmentModel);
            await _dbContext.SaveChangesAsync();

            return departmentModel;
        }

        public async Task<bool> DeleteDepartment(Guid departmentId)
        {
            var department = await _dbContext.Departments.FindAsync(departmentId);

            if (department == null)
            {
                return false;
            }

            if (department.IsInactive)
            {
                throw new InvalidOperationException("department is already inactive or deleted in system");
            }

            department.IsInactive = true;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _dbContext.Departments.Where(x => x.IsInactive).ToListAsync();
        }

        public async Task<Department> GetDepartmentById(Guid departmentId)
        {
            return await _dbContext.Departments.Where(x => x.DepartmentId == departmentId && x.IsInactive).FirstOrDefaultAsync();
        }

        public async Task<Department> UpdateDepartment(Department departmentModel)
        {
            if (departmentModel == null)
            {
                throw new ArgumentNullException(nameof(departmentModel));
            }

            var department = await _dbContext.Departments.FindAsync(departmentModel.DepartmentId);

            if (department == null)
            {
                return null;
            }

            if (department.IsInactive)
            {
                throw new InvalidOperationException("department details can not be updated as employee is already inactive or deleted in system");
            }

            department.Name = departmentModel.Name;

            await _dbContext.SaveChangesAsync();

            return department;
        }
    }
}
