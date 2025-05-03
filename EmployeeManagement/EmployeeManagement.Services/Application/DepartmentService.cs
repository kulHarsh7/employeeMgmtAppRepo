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
using MapsterMapper;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement.Services.Application
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ILogger<DepartmentService> _logger;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IValidatorService _validatorService;
        private readonly IMapper _mapper;

        public DepartmentService(ILogger<DepartmentService> logger, IDepartmentRepository departmentRepository, IValidatorService validatorService, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _departmentRepository = departmentRepository ?? throw new ArgumentNullException(nameof(departmentRepository));
            _validatorService = validatorService ?? throw new ArgumentNullException(nameof(departmentRepository));
            _mapper = mapper;
        }

        public async Task<ApiResponse<DepartmentResponse>> CreateDepartment(CreateDepartmentRequest createDepartmentRequest)
        {
            try
            {
                //validate request
                var validationResult = await _validatorService.ValidateAsync(createDepartmentRequest);
                if (!validationResult.IsValid)
                {
                    return ApiResponse<DepartmentResponse>.ValidationFailure(ErrorCategory.Validation.ToString(), validationResult.ToErrors());
                }

                var departmentModel = _mapper.Map<Department>(createDepartmentRequest);
                var createdDepartemt = await _departmentRepository.CreateDepartment(departmentModel);
                var departmentResponse = _mapper.Map<DepartmentResponse>(createdDepartemt);

                return ApiResponse<DepartmentResponse>.Success(departmentResponse);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<DepartmentResponse>.ApiFailure(ex.Category, ex.Message);
            }
        }

        public async Task<ApiResponse<bool>> DeleteDepartment(string departmentId)
        {
            try
            {
                //validate request
                if(!FluentExtensions.BeValidGuid(departmentId))
                {
                    return ApiResponse<bool>.ValidationFailure(ErrorCategory.Validation.ToString(),
                           [new Error(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(departmentId)))]);
                }
                var deptId = FluentExtensions.ParseToGuid(departmentId);
                var response = await _departmentRepository.DeleteDepartment(deptId);

                if (!response)
                {
                    return ApiResponse<bool>.NotFoundFailure(ErrorCategory.NotFound.ToString(),
                        string.Format(ServiceError.NotFoundWithIdError, nameof(Department), departmentId));
                }

                return ApiResponse<bool>.Success(response);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<bool>.ApiFailure(ex.Category, ex.Message);
            }
        }

        public async Task<ApiResponse<List<DepartmentResponse>>> GetAllDepartments()
        {
            try
            {
                //validate request
                var department = await _departmentRepository.GetAllDepartments();

                if (department == null || department.Count == 0)
                {
                    return ApiResponse<List<DepartmentResponse>>.NotFoundFailure(ErrorCategory.NotFound.ToString(),
                        string.Format(ServiceError.NotFoundError, nameof(Department)));
                }

                var departmentResponse = _mapper.Map<List<DepartmentResponse>>(department);
                return ApiResponse<List<DepartmentResponse>>.Success(departmentResponse);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<List<DepartmentResponse>>.ApiFailure(ex.Category, ex.Message);
            }
        }

        public async Task<ApiResponse<DepartmentResponse>> GetDepartmentById(string departmentId)
        {
            try
            {
                //validate request
                if (!FluentExtensions.BeValidGuid(departmentId))
                {
                    return ApiResponse<DepartmentResponse>.ValidationFailure(ErrorCategory.Validation.ToString(),
                           [new Error(string.Format(ValidationErrorConstants.ShouldBeAValid, nameof(departmentId)))]);
                }
                var deptId = FluentExtensions.ParseToGuid(departmentId);

                var department = await _departmentRepository.GetDepartmentById(deptId);

                if (department == null)
                {
                    return ApiResponse<DepartmentResponse>.NotFoundFailure(ErrorCategory.NotFound.ToString(),
                        string.Format(ServiceError.NotFoundWithIdError,nameof(Department),departmentId));
                }

                var departmentResponse = _mapper.Map<DepartmentResponse>(department);
                return ApiResponse<DepartmentResponse>.Success(departmentResponse);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<DepartmentResponse>.ApiFailure(ex.Category, ex.Message);
            }
        }

        public async Task<ApiResponse<DepartmentResponse>> UpdateDepartment(UpdateDepartmentRequest updateDepartmentRequest)
        {
            try
            {
                //validate request
                var validationResult = await _validatorService.ValidateAsync(updateDepartmentRequest);
                if (!validationResult.IsValid)
                {
                    return ApiResponse<DepartmentResponse>.ValidationFailure(ErrorCategory.Validation.ToString(), validationResult.ToErrors());
                }

                var departmentModel = _mapper.Map<Department>(updateDepartmentRequest);
                var updatedDepartemt = await _departmentRepository.UpdateDepartment(departmentModel);

                if (updatedDepartemt == null)
                {
                    return ApiResponse<DepartmentResponse>.NotFoundFailure(ErrorCategory.NotFound.ToString(),
                        string.Format(ServiceError.NotFoundWithIdError, nameof(Department), updateDepartmentRequest.DepartmentId));
                }

                var departmentResponse = _mapper.Map<DepartmentResponse>(updatedDepartemt);

                return ApiResponse<DepartmentResponse>.Success(departmentResponse);
            }
            catch (ApiHandledException ex)
            {
                return ApiResponse<DepartmentResponse>.ApiFailure(ex.Category, ex.Message);
            }
        }
    }
}
