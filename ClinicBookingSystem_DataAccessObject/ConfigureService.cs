using ClinicBookingSystem_DataAccessObject.BaseDAO;
using ClinicBookingSystem_DataAccessObject.IBaseDAO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicBookingSystem_DataAccessObject;

public static class ConfigureService
{
    public static IServiceCollection ConfigureDataAccessObjectService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<UserDAO>();
        services.AddScoped<ApplicationDAO>();
        services.AddScoped<RoleDAO>();
        services.AddScoped<DentistDAO>();
        services.AddScoped<StaffDAO>();
        services.AddScoped(typeof(IBaseDAO<>), typeof(BaseDAO<>));
        return services;
    }
}