using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Contacts.Repository;
using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using EmployeeManagement.Models.DTO.Response.Common;
using EmployeeManagement.Models.Models;
using EmployeeManagement.Services.Application.Validators.Common;
using EmployeeManagement.Services.Constants;
using EmployeeManagement.Services.Exceptions;
using EmployeeManagement.Services.Extensions;
using EmployeeManagement.Services.Repository;
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Services.Application
{
    public class EmployeeService :IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IValidatorService _validatorService;
        private readonly IMapper _mapper;

        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository, IValidatorService validatorService, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _validatorService = validatorService ?? throw new ArgumentNullException(nameof(validatorService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ApiResponse<EmployeeResponse>> CreateEmployee(CreateEmployeeRequest createEmployeeRequest)
        {
            try
            {
                //validate request
                var validationResult = await _validatorService.ValidateAsync(createEmployeeRequest);
                if (!validationResult.IsValid)
                {
                    return ApiResponse<EmployeeResponse>.ValidationFailure(ErrorCategory.Validation.ToString(), validationResult.ToErrors());
                }

                var employeeModel = _mapper.Map<Employee>(createEmployeeRequest);
                var createdEmployee = await _employeeRepository.CreateEmployee(employeeModel);
                var EmployeeResponse = _mapper.Map<EmployeeResponse>(createdEmployee);

                return ApiResponse<EmployeeResponse>.Success(EmployeeResponse);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<EmployeeResponse>.ApiFailure(ex.Category, ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> DeleteEmployee(string employeeId)
        {
            try
            {
                //validate request
                if (!FluentExtensions.BeValidGuid(employeeId))
                {
                    return ApiResponse<bool>.ValidationFailure(ErrorCategory.Validation.ToString(),
                           [new Error(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(employeeId)))]);
                }
                var empId = FluentExtensions.ParseToGuid(employeeId);
                var response = await _employeeRepository.DeleteEmployee(empId);

                if (!response)
                {
                    return ApiResponse<bool>.NotFoundFailure(ErrorCategory.NotFound.ToString(),
                        string.Format(ServiceError.NotFoundWithIdError, nameof(Employee), employeeId));
                }

                return ApiResponse<bool>.Success(response);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<bool>.ApiFailure(ex.Category, ex.Message);
            }
        }

        public async Task<ApiResponse<List<EmployeeResponse>>> GetAllEmployees()
        {
            try
            {
                //validate request
                var employees = await _employeeRepository.GetAllEmployees();

                if (employees == null || employees.Count == 0)
                {
                    return ApiResponse<List<EmployeeResponse>>.NotFoundFailure(ErrorCategory.NotFound.ToString(),
                           string.Format(ServiceError.NotFoundError, nameof(Employee)));
                }

                var employeeResponse = _mapper.Map<List<EmployeeResponse>>(employees);
                return ApiResponse<List<EmployeeResponse>>.Success(employeeResponse);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<List<EmployeeResponse>>.ApiFailure(ex.Category, ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeResponse>> GetEmployeeById(string employeeId)
        {
            try
            {
                //validate request
                if (!FluentExtensions.BeValidGuid(employeeId))
                {
                    return ApiResponse<EmployeeResponse>.ValidationFailure(ErrorCategory.Validation.ToString(),
                           [new Error(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(employeeId)))]);
                }
                var empId = FluentExtensions.ParseToGuid(employeeId);

                var employeeModelResponse = await _employeeRepository.GetEmployeeById(empId);

                if (employeeModelResponse == null)
                {
                    return ApiResponse<EmployeeResponse>.NotFoundFailure(ErrorCategory.NotFound.ToString(),
                        string.Format(ServiceError.NotFoundWithIdError, nameof(Employee), employeeId));
                }

                var employeeResponse = _mapper.Map<EmployeeResponse>(employeeModelResponse);
                return ApiResponse<EmployeeResponse>.Success(employeeResponse);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<EmployeeResponse>.ApiFailure(ex.Category, ex.Message);
            }
        }

        public async Task<ApiResponse<EmployeeResponse>> UpdateEmployee(UpdateEmployeeRequest updateEmployeeRequest)
        {
            try
            {
                //validate request
                var validationResult = await _validatorService.ValidateAsync(updateEmployeeRequest);
                if (!validationResult.IsValid)
                {
                    return ApiResponse<EmployeeResponse>.ValidationFailure(ErrorCategory.Validation.ToString(), validationResult.ToErrors());
                }

                var employeeModel = _mapper.Map<Employee>(updateEmployeeRequest);
                var updatedEmployee= await _employeeRepository.UpdateEmployee(employeeModel);
                if (updatedEmployee == null)
                {
                    return ApiResponse<EmployeeResponse>.NotFoundFailure(ErrorCategory.NotFound.ToString(),
                        string.Format(ServiceError.NotFoundWithIdError, nameof(Employee), updateEmployeeRequest.EmployeeId));
                }

                var EmployeeResponse = _mapper.Map<EmployeeResponse>(updatedEmployee);

                return ApiResponse<EmployeeResponse>.Success(EmployeeResponse);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<EmployeeResponse>.ApiFailure(ex.Category, ex.Message);
            }
        }
    }
}
