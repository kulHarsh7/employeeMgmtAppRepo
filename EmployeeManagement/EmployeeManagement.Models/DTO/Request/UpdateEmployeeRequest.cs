﻿namespace EmployeeManagement.Models.DTO.Request
{
    public class UpdateEmployeeRequest
    {
        public string EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string DepartmentId { get; set; }
    }
}
