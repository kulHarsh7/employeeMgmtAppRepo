using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Models.DTO.Request;
using EmployeeManagement.Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DepartmentManagement.Web.Controllers
{
    [Route("api/[controller]")]
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
        [ProducesResponseType(typeof(List<DepartmentResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<List<DepartmentResponse>>> GetAllDepartmentAsync()
        {
            var DepartmentListResponse = await _departmentService.GetAllDepartments();
            return Ok(new DepartmentResponse { DepartmentName = "John" });
        }

        [HttpGet("{departmentId}", Name = "GetDepartmentById")]
        [ProducesResponseType(typeof(DepartmentResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<DepartmentResponse>> GetDepartmentByIdAsync([FromRoute] string departmentId)
        {
            var departmentResponse = await _departmentService.GetDepartmentById(departmentId);
            return Ok(new DepartmentResponse { DepartmentName = "John" });
        }

        [HttpPost(Name = "CreateDepartment")]
        [ProducesResponseType(typeof(DepartmentResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<DepartmentResponse>> CreateDepartmentAsync(CreateDepartmentRequest createDepartmentRequest)
        {
            var createdDepartmentResponse = await _departmentService.CreateDepartment(createDepartmentRequest);
            return Ok(new DepartmentResponse { DepartmentName = "John" });
        }

        [HttpPut(Name = "UpdateDepartment")]
        [ProducesResponseType(typeof(DepartmentResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<DepartmentResponse>> UpdateDepartmentAsync(UpdateDepartmentRequest updateDepartmentRequest)
        {
            var updatedDepartmentResponse = await _departmentService.UpdateDepartment(updateDepartmentRequest);
            return Ok(new DepartmentResponse { DepartmentName = "John" });
        }

        [HttpDelete("{departmentId}", Name = "DeleteDepartment")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> DeleteDepartmentAsync([FromRoute] string departmentId)
        {
            var deletedDepartmentResponse = await _departmentService.DeleteDepartment(departmentId);
            return Ok("Deleted successfully");
        }
    }
}
