using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement.Web.Controllers
{
    [Route("api/[controller]")]
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
        [ProducesResponseType(typeof(List<EmployeeResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<List<EmployeeResponse>>> GetAllEmployeesAsync()
        {
            var employeeListResponse = await _employeeService.GetAllEmployees();
            return Ok(new EmployeeResponse { FirstName = "John" });
        }

        [HttpGet("{employeeId}", Name = "GetEmployeeById")]
        [ProducesResponseType(typeof(EmployeeResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeByIdAsync([FromRoute] string employeeId)
        {
            var employeeResponse = await _employeeService.GetEmployeeById(employeeId);
            return Ok(new EmployeeResponse { FirstName = "John" });
        }

        [HttpPost(Name = "CreateEmployee")]
        [ProducesResponseType(typeof(EmployeeResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployeeAsync(CreateEmployeeRequest createEmployeeRequest)
        {
            var createdEmployeeResponse = await _employeeService.CreateEmployee(createEmployeeRequest);
            return Ok(new EmployeeResponse { FirstName = "John" });
        }

        [HttpPut(Name = "UpdateEmployee")]
        [ProducesResponseType(typeof(EmployeeResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<EmployeeResponse>> UpdateEmployeeAsync(UpdateEmployeeRequest updateEmployeeRequest)
        {
            var updatedEmployeeResponse = await _employeeService.UpdateEmployee(updateEmployeeRequest);
            return Ok(new EmployeeResponse { FirstName = "John" });
        }

        [HttpDelete("{employeeId}", Name = "DeleteEmployee")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteEmployeeAsync([FromRoute] string employeeId)
        {
            var deletedEmployeeResponse = await _employeeService.DeleteEmployee(employeeId);
            return Ok("Deleted successfully");
        }
    }
}
