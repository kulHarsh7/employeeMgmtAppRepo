using EmployeeManagement.Contacts.Repository;
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
    }
}
