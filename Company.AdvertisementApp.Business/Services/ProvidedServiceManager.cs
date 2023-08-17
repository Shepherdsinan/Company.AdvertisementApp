using AutoMapper;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.DataAccess.UnitOfWork;
using Company.AdvertisementApp.Dto.Interfaces;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;
using FluentValidation;

namespace Company.AdvertisementApp.Business.Services;

public class ProvidedServiceManager : Service<ProvidedServiceCreateDto,ProvidedServiceUpdateDto,ProvidedServiceListDto,ProvidedService>,IProvidedServiceManager
{
    public ProvidedServiceManager(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator,IValidator<ProvidedServiceUpdateDto> updateDtoValidator,IUow uow) : base(mapper,createDtoValidator,updateDtoValidator,uow)
    {
        
    }
}