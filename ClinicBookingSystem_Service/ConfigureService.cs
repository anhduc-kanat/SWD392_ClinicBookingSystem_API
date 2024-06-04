// See https://aka.ms/new-console-template for more information

using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.Mapping;
using ClinicBookingSystem_Service.Models.Utils;
using ClinicBookingSystem_Service.Service;
using global::System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ConfigureService
{
    public static IServiceCollection ConfigureServiceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddAutoMapper(typeof(CustomerMapping));
        services.AddAutoMapper(typeof(AuthenMapping));

        services.AddScoped<HashPassword>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenService, AuthenService>();
        services.AddScoped<IRoleService, RoleService>();

        return services;
    }
}

