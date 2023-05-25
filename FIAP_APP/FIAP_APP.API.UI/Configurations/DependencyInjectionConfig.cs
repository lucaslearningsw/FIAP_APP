using FIAP_APP.Domain.Repositories.CollegeClass;
using FIAP_APP.Domain.Repositories.Student;
using FIAP_APP.Domain.Services.Interfaces;
using FIAP_APP.Infra.Services;
using FIAP_APP.InfraData.SQL.Repositories.CollegeClass;
using FIAP_APP.InfraData.SQL.Repositories.Student;
using Microsoft.AspNetCore.Mvc.DataAnnotations;

namespace FIAP_APP.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICollegeClassRepository, CollegeClassRepository>();
            services.AddScoped<ICollegeClassService, CollegeClassService>();
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
