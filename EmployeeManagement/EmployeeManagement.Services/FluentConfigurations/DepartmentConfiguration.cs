using EmployeeManagement.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Services.FluentConfigurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(e => e.DepartmentId);

            builder.Property(e => e.DepartmentId)
                   .IsRequired();

            builder.Property(d => d.DepartmentId)
                  .ValueGeneratedOnAdd()
                  .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(e => e.Name)
                   .IsUnique();

            builder.HasMany(d => d.Employees)  // One department can have many employees
                   .WithOne(e => e.Department)  // Each employee belongs to one department
                   .HasForeignKey(e => e.DepartmentId)  // Foreign key in Employee table
                   .OnDelete(DeleteBehavior.Cascade);  // If department is deleted, employees are deleted
        }
    }
}
