using System.Text.Json.Serialization;

namespace EmployeeManagement.Models.DTO.Response.Common
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorCategory { get; set; }
        public List<Error> Errors { get; set; }

        private ApiResponse(T data, bool isSuccess, string? errorCategory, List<Error> errors)
        {
            Data = data;
            IsSuccess = isSuccess;
            ErrorCategory = errorCategory;
            Errors = errors;
        }
        public ApiResponse() { }

        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T>(data, true, null, null);
        }

        public static ApiResponse<T> ValidationFailure(string errorCategory, List<Error> errors)
        {
            return new ApiResponse<T>(default, false, errorCategory, errors);
        }

        public static ApiResponse<T> NotFoundFailure(string errorCategory,string errorMessage)
        {
            var errors = new List<Error>
            {
                new Error(errorMessage)
            };
            return new ApiResponse<T>(default, false, errorCategory, errors);
        }

        public static ApiResponse<T> TechnicalFailure(string errorCategory, string errorMessage)
        {
            var errors = new List<Error>
            {
                new Error(errorMessage)
            };
            return new ApiResponse<T>(default, false, errorCategory, errors);
        }

        public static ApiResponse<T> ApiFailure(string errorCategory, string errorMessage)
        {
            var errors = new List<Error>
            {
                new Error(errorMessage)
            };
            return new ApiResponse<T>(default, false, errorCategory, errors);
        }
    }

}
