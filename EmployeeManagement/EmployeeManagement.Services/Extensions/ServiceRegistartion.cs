using EmployeeManagement.Contacts.Application;
using EmployeeManagement.Contacts.Repository;
using EmployeeManagement.Services.Application;
using EmployeeManagement.Services.DBContext;
using EmployeeManagement.Services.Mapster;
using EmployeeManagement.Services.Repository;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Services.Extensions
{
    public static class ServiceRegistartion
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Add dbcontext
            services.AddDbContext<EmployeeDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EmployeeAppConnection"));
            });

            //Register Mapster
            services.AddMapster();

            //Configure Mapster
            MapsterConfig.Configure();

            //Register Validators
            services.AddValidatorsFromAssemblyContaining(typeof(ServiceRegistartion));

            //register services
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

         return services;
        }
    }
}
