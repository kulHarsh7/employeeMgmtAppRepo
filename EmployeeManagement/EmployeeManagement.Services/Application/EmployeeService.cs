using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Contacts.Repository;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Services.Application
{
    public class EmployeeService :IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }
    }
}
