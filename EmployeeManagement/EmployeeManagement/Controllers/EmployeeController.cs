using EmployeeManagement.Models.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController()
        {
                
        }

        [HttpGet(Name = "GetAllEmployees")]
        [ProducesResponseType(typeof(List<EmployeeResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<List<EmployeeResponse>>> GetAllEmployeesAsync()
        {
            //var addressListResponse = await _addressService.GetAddressesAsync(profileId);
            return Ok(new EmployeeResponse { FirstName = "John" });
        }
    }
}
