
using FIAP_APP.Domain.Repositories.CollegeClass;
using FIAP_APP.Domain.Repositories.ManagerRelationCollegeClass;
using FIAP_APP.Domain.Repositories.Student;
using FIAP_APP.Domain.Services;
using FIAP_APP.Domain.Services.ManagerRelationClassStudent;
using FIAP_APP.InfraData.SQL.Repositories.CollegeClass;
using FIAP_APP.InfraData.SQL.Repositories.ManagerRelationCollegeStudent;
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
            services.AddScoped<CollegeClassService>();
            services.AddScoped<StudentService>();
            services.AddScoped<CollegeClassService>();
            services.AddScoped<ManagerRelationClassStudentService>();
            services.AddScoped<IManagerRelationCollegeClassRepository, ManagerRelationClassStudentRepository>();

            return services;
        }
    }
}
