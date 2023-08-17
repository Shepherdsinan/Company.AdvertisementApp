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
    public static void ContainerDependencies(this IServiceCollection services)
    {
        var mapperConfiguration = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new ProvidedServiceProfile());
        });
        var mapper = mapperConfiguration.CreateMapper();
        services.AddSingleton(mapper);
        services.AddScoped<IUow, Uow>();
        services.AddScoped<IProvidedServiceManager, ProvidedServiceManager>();
    }

    public static void CustomerValidator(this IServiceCollection services)
    {
        services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
        services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
    }
}