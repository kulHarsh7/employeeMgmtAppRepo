using EmployeeManagement.Contacts.Application;
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
            //var employeeListResponse = await _employeeService.GetAllEmployeesAsync();
            return Ok(new EmployeeResponse { FirstName = "John" });
        }
    }
}
