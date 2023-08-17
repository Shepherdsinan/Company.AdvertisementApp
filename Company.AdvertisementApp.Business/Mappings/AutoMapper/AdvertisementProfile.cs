using AutoMapper;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Company.AdvertisementApp.Business.Mappings.AutoMapper;

public class AdvertisementProfile : Profile
{
    public AdvertisementProfile()
    {
        CreateMap<Advertisement, AdvertisementListDto>().ReverseMap();
        CreateMap<Advertisement, AdvertisementCreateDto>().ReverseMap();
        CreateMap<Advertisement, AdvertisementUpdateDto>().ReverseMap();
    }
}