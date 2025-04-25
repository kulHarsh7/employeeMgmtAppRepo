using EmployeeManagement.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Services.FluentConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(e => e.EmployeeId);

            builder.Property(e => e.EmployeeId)
                   .IsRequired();

            builder.Property(d => d.EmployeeId)
                  .ValueGeneratedOnAdd()
                  .HasDefaultValueSql("NEWID()");

            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);
                   
            builder.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasIndex(e => e.Email)
                   .IsUnique();

            builder.Property(e => e.Salary)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .HasForeignKey(e => e.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
