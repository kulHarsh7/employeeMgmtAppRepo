using EmployeeManagement.Models.Models;

namespace EmployeeManagement.Models.DTO.Response
{
    public class EmployeeResponse
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
}
