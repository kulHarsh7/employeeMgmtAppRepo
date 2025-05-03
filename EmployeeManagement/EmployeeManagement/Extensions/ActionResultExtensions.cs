using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTO.Response.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagement.Web.Extensions
{
    public static class ActionResultExtensions
    {
        public static ActionResult HandleResult<T>(this ControllerBase controller, ApiResponse<T> data) 
        {
            if (data.IsSuccess)
            {
                if (data.Data == null)
                {
                    return controller.NotFound(data);
                }
                else
                {
                    return controller.Ok(data);
                }
            }
            else
            {
                var statusCode = data.ErrorCategory switch
                {
                    string category when category == ErrorCategory.NotFound.ToString() => (int)HttpStatusCode.NotFound,
                    string category when category == ErrorCategory.Validation.ToString() => (int)HttpStatusCode.BadRequest,
                    string category when category == ErrorCategory.Forbidden.ToString() => (int)HttpStatusCode.Forbidden,
                    string category when category == ErrorCategory.Api.ToString() => (int)HttpStatusCode.InternalServerError,
                    string category when category == ErrorCategory.Technical.ToString() => (int)HttpStatusCode.InternalServerError,
                    _ => (int)HttpStatusCode.InternalServerError
                };
                return controller.StatusCode(statusCode, data);
            }
        }
    }
}
