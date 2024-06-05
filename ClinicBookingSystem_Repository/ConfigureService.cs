using ClinicBookingSystem_DataAccessObject;
using ClinicBookingSystem_Repository.BaseRepositories;
using ClinicBookingSystem_Repository.IBaseRepository;
using ClinicBookingSystem_Repository.IRepositories;
using ClinicBookingSystem_Repository.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicBookingSystem_Repository;

public static class ConfigureService
{
    public static IServiceCollection ConfigureRepositoryService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDentistRepository, DentistRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<DentistDAO>();
        services.AddScoped<UserDAO>();
        return services;
    }
}