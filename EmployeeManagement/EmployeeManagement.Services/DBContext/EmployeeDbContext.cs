using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Services.DBContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
                
        }
    }
}
