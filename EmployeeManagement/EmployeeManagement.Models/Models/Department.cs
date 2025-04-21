namespace EmployeeManagement.Models.Models
{
    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
