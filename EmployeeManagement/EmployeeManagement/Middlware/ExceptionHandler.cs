using EmployeeManagement.Models.Constants;
using EmployeeManagement.Models.DTO.Response.Common;
using EmployeeManagement.Services.Constants;
using System.Net;
using System.Text.Json;

namespace EmployeeManagement.Web.Middlware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // proceed down the pipeline
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await WriteErrorResponse(context, 500, ErrorCategory.Technical,string.Format(ServiceError.GeneralErrorMessage));
            }
        }

        private Task WriteErrorResponse(HttpContext context, int statusCode, ErrorCategory category, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = ApiResponse<string>.TechnicalFailure(category.ToString(), message);
            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return context.Response.WriteAsync(json);
        }
    }
}
