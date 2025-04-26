using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Contacts.Repository;
using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using EmployeeManagement.Services.Application.Validators.Common;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Services.Application
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ILogger<DepartmentService> _logger;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IValidatorService _validatorService;

        public DepartmentService(ILogger<DepartmentService> logger, IDepartmentRepository departmentRepository, IValidatorService validatorService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _validatorService = validatorService ?? throw new ArgumentNullException(nameof(departmentRepository));
        }

        public Task<DepartmentResponse> CreateDepartment(CreateDepartmentRequest createDepartmentRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDepartment(string departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentResponse>> GetAllDepartments()
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentResponse> GetDepartmentById(string departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<DepartmentResponse> UpdateDepartment(UpdateDepartmentRequest updateDepartmentRequest)
        {
            throw new NotImplementedException();
        }
    }
}
