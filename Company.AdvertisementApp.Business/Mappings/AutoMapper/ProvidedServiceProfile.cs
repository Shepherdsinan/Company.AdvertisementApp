using AutoMapper;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Mappings.AutoMapper;

public class ProvidedServiceProfile : Profile
{
    public ProvidedServiceProfile()
    {
        CreateMap<ProvidedServiceCreateDto, ProvidedService>().ReverseMap();
        CreateMap<ProvidedServiceUpdateDto, ProvidedService>().ReverseMap();
        CreateMap<ProvidedServiceListDto, ProvidedService>().ReverseMap();
    }
}