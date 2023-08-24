using AutoMapper;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Mappings.AutoMapper;

public class AdvertisementAppUserProfile : Profile
{
    public AdvertisementAppUserProfile()
    {
        CreateMap<AdvertisementAppUser, AdvertisementAppUserCreateDto>().ReverseMap();
        CreateMap<AdvertisementAppUser, AdvertisementAppUserListDto>().ReverseMap();
    }
}