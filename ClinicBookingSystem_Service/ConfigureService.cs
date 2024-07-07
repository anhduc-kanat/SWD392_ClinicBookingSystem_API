﻿// See https://aka.ms/new-console-template for more information

using System.Configuration;
using ClinicBookingSystem_Service;
using ClinicBookingSystem_Service.IService;
using ClinicBookingSystem_Service.IServices;
using ClinicBookingSystem_Service.Mapping;
using ClinicBookingSystem_Service.Models.DTOs.VNPAY;
using ClinicBookingSystem_Service.Models.Utils;
using ClinicBookingSystem_Service.RabbitMQ;
using ClinicBookingSystem_Service.RabbitMQ.Config;
using ClinicBookingSystem_Service.RabbitMQ.Consumers.Appointment;
using ClinicBookingSystem_Service.RabbitMQ.IService;
using ClinicBookingSystem_Service.RabbitMQ.Service;
using ClinicBookingSystem_Service.Scheduler;
using ClinicBookingSystem_Service.Service;
using ClinicBookingSystem_Service.Services;
using ClinicBookingSystem_Service.ThirdParties.VnPay;
using global::System;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Quartz;

public static class ConfigureService
{
    public static IServiceCollection ConfigureServiceService(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(MappingProfiles));

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IApplicationService, ApplicationService>();
        services.AddScoped<IDentistService, DentistService>();
        services.AddScoped<IStaffService, StaffService>();
        services.AddScoped<IUserProfileService, UserProfileService>();
        services.AddScoped<HashPassword>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthenService, AuthenService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ISlotService, SlotService>();
        services.AddScoped<IMedicalRecordService, MedicalRecordService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IMedicineService, MedicineService>();
        services.AddScoped<IResultService, ResultService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<ISalaryService, SalaryService>();
        services.AddScoped<ISpecificationService, SpecificationService>();
        services.AddScoped<IBillingService, BillingService>();
        services.AddScoped<IClinicOwnerService, ClinicOwnerService>();
        services.AddScoped<IVnPayService, VnPayService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<INoteService, NoteService>();

        //quartz
        services.AddQuartz(p =>
        {
            p.UseMicrosoftDependencyInjectionJobFactory();
            var jobKey = new JobKey("PaymentTimeOutJob");
            p.AddJob<PaymentTimeOutJob>(opt => opt.WithIdentity(jobKey).StoreDurably());
            services.AddQuartzHostedService(q =>
                q.WaitForJobsToComplete = true);
        });
        
        //RabbitMQ
        var rabbitMQConfigSection = configuration.GetSection("RabbitMQ");
        var rabbitMQConfig = new RabbitMQConfig
        {
            HostName = rabbitMQConfigSection["HostName"],
            UserName = rabbitMQConfigSection["UserName"],
            Password = rabbitMQConfigSection["Password"],
            Port = Convert.ToInt32(rabbitMQConfigSection["Port"])
        };
        services.AddScoped<IRabbitMQBus, RabbitMQBus>();
        services.AddSingleton(rabbitMQConfig);
        services.AddSingleton<RabbitMQConnection>();
        services.AddScoped<IRabbitMQService, RabbitMQService>();
        services.AddMassTransit(config =>
        {
            //consumers
            config.AddConsumer<GetAllConsumer>();
            
            //register rabbitmq
            config.UsingRabbitMq((ctx, cfg) =>
            {
                var rabbitMQConfig = ctx.GetService<RabbitMQConfig>();
                Console.WriteLine($"rabbitmq://${rabbitMQConfig.HostName}:${rabbitMQConfig.Port}");
                cfg.Host(new Uri($"rabbitmq://{rabbitMQConfig.HostName}:{rabbitMQConfig.Port}"), h =>
                {
                    h.Username(rabbitMQConfig.UserName);
                    h.Password(rabbitMQConfig.Password);
                });
                cfg.ConfigureEndpoints(ctx);
                cfg.UseRawJsonSerializer();
            });

            
        });
        services.AddMassTransitHostedService();

        return services;
    }
}