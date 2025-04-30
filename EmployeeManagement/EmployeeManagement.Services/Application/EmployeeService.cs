using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Contacts.Repository;
using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using EmployeeManagement.Services.Application.Validators.Common;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Services.Application
{
    public class EmployeeService :IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IValidatorService _validatorService;

        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository, IValidatorService validatorService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _validatorService = validatorService ?? throw new ArgumentNullException(nameof(validatorService));
        }

        public Task<EmployeeResponse> CreateEmployee(CreateEmployeeRequest createEmployeeRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEmployee(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeResponse>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeResponse> GetEmployeeById(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeResponse> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest)
        {
            throw new NotImplementedException();
        }
    }
}
