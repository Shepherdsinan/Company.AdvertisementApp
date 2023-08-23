using AutoMapper;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Business.Mappings.AutoMapper;
using Company.AdvertisementApp.Business.Services;
using Company.AdvertisementApp.Business.ValidationRules;
using Company.AdvertisementApp.DataAccess.UnitOfWork;
using Company.AdvertisementApp.Dto;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Company.AdvertisementApp.Business.Container;

public static class Extensions
{
    public static void DependencyExtension(this IServiceCollection services)
    {
        services.AddScoped<IUow, Uow>();
        services.AddScoped<IProvidedServiceManager, ProvidedServiceManager>();
        services.AddScoped<IAdvertisementManager, AdvertisementManager>();
        services.AddScoped<IAppUserManager, AppUserManager>();
        services.AddScoped<IGenderManager, GenderManager>();
        services.AddScoped<IAdvertisementAppUserManager, AdvertisementAppUserManager>();
    }

    public static void CustomerValidator(this IServiceCollection services)
    {
        services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
        services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
        services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
        services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
        services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
        services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
        services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
        services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
        services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
        services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();

    }

}