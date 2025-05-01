using EmployeeManagement.Models.Constants;

namespace EmployeeManagement.Services.Exceptions
{
    public abstract class ApiHandledException : Exception
    {
        public string Category { get; }

        public ApiHandledException(string errorCategory, string message) : base(message)
        {
            Category = errorCategory;
        }
    }

    public class DuplicateRecordException : ApiHandledException
    {
        public DuplicateRecordException(string message) : base(ErrorCategory.Api.ToString() ,message) { }
    }

    public class InvalidModelException : ApiHandledException
    {
        public InvalidModelException(string message) : base(ErrorCategory.Api.ToString(), message) { }
    }

    public class RecordIsInactiveException : ApiHandledException
    {
        public RecordIsInactiveException(string message) : base(ErrorCategory.Api.ToString(), message) { }
    }
}
