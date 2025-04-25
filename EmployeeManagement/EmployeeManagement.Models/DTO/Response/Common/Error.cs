namespace EmployeeManagement.Models.DTO.Response.Common
{
    public class Error
    {
        public string ErrorMessage { get; set; }

        public Error(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
