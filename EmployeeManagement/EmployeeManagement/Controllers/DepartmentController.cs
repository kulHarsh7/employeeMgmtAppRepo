using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using EmployeeManagement.Models.DTO.Response.Common;
using EmployeeManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DepartmentManagement.Web.Controllers
{
    [Route("EmployeeMgmtApp/api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentService departmentService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _departmentService = departmentService ?? throw new ArgumentNullException(nameof(departmentService));
        }

        [HttpGet(Name = "GetAllDepartment")]
        [ProducesResponseType(typeof(ApiResponse<List<DepartmentResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<List<DepartmentResponse>>> GetAllDepartmentAsync()
        {
            var DepartmentListResponse = await _departmentService.GetAllDepartments();
            return this.HandleResult(DepartmentListResponse);
        }

        [HttpGet("{departmentId}", Name = "GetDepartmentById")]
        [ProducesResponseType(typeof(ApiResponse<DepartmentResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<DepartmentResponse>> GetDepartmentByIdAsync([FromRoute] string departmentId)
        {
            var departmentResponse = await _departmentService.GetDepartmentById(departmentId);
            return this.HandleResult(departmentResponse);
        }

        [HttpPost(Name = "CreateDepartment")]
        [ProducesResponseType(typeof(ApiResponse<DepartmentResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<DepartmentResponse>> CreateDepartmentAsync(CreateDepartmentRequest createDepartmentRequest)
        {
            var createdDepartmentResponse = await _departmentService.CreateDepartment(createDepartmentRequest);
            return this.HandleResult(createdDepartmentResponse);
        }

        [HttpPut(Name = "UpdateDepartment")]
        [ProducesResponseType(typeof(ApiResponse<DepartmentResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<DepartmentResponse>> UpdateDepartmentAsync(UpdateDepartmentRequest updateDepartmentRequest)
        {
            var updatedDepartmentResponse = await _departmentService.UpdateDepartment(updateDepartmentRequest);
            return this.HandleResult(updatedDepartmentResponse);
        }

        [HttpDelete("{departmentId}", Name = "DeleteDepartment")]
        [ProducesResponseType(typeof(ApiResponse<DepartmentResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<bool>> DeleteDepartmentAsync([FromRoute] string departmentId)
        {
            var deletedDepartmentResponse = await _departmentService.DeleteDepartment(departmentId);
            return this.HandleResult(deletedDepartmentResponse);
        }
    }
}
