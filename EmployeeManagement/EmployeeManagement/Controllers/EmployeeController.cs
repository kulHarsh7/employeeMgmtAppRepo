using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using EmployeeManagement.Models.DTO.Response.Common;
using EmployeeManagement.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement.Web.Controllers
{
    [Route("EmployeeMgmtApp/api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger,  IEmployeeService employeeService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpGet(Name = "GetAllEmployees")]
        [ProducesResponseType(typeof(ApiResponse<List<EmployeeResponse>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<List<EmployeeResponse>>> GetAllEmployeesAsync()
        {
            var employeeListResponse = await _employeeService.GetAllEmployees();
            return this.HandleResult(employeeListResponse);
        }

        [HttpGet("{employeeId}", Name = "GetEmployeeById")]
        [ProducesResponseType(typeof(ApiResponse<EmployeeResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeByIdAsync([FromRoute] string employeeId)
        {
            var employeeResponse = await _employeeService.GetEmployeeById(employeeId);
            return this.HandleResult(employeeResponse);
        }

        [HttpPost(Name = "CreateEmployee")]
        [ProducesResponseType(typeof(ApiResponse<EmployeeResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployeeAsync(CreateEmployeeRequest createEmployeeRequest)
        {
            var createdEmployeeResponse = await _employeeService.CreateEmployee(createEmployeeRequest);
            return this.HandleResult(createdEmployeeResponse);
        }

        [HttpPut(Name = "UpdateEmployee")]
        [ProducesResponseType(typeof(ApiResponse<EmployeeResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<EmployeeResponse>> UpdateEmployeeAsync(UpdateEmployeeRequest updateEmployeeRequest)
        {
            var updatedEmployeeResponse = await _employeeService.UpdateEmployee(updateEmployeeRequest);
            return this.HandleResult(updatedEmployeeResponse);
        }

        [HttpDelete("{employeeId}", Name = "DeleteEmployee")]
        [ProducesResponseType(typeof(ApiResponse<EmployeeResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ApiResponse<>), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<bool>> DeleteEmployeeAsync([FromRoute] string employeeId)
        {
            var deletedEmployeeResponse = await _employeeService.DeleteEmployee(employeeId);
            return this.HandleResult(deletedEmployeeResponse);
        }
    }
}
