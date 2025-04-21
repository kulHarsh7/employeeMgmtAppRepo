using EmployeeManagement.Contacts.Repository;
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
    }
}
