using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Contacts.Repository;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Services.Application
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ILogger<DepartmentService> _logger;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(ILogger<DepartmentService> logger, IDepartmentRepository departmentRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
        }
    }
}
