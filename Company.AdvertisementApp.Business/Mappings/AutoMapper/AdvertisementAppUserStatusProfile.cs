using AutoMapper;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Mappings.AutoMapper;

public class AdvertisementAppUserStatusProfile : Profile
{
    public AdvertisementAppUserStatusProfile()
    {
        CreateMap<AdvertisementAppUserStatus, AdvertisementAppUserStatusListDto>().ReverseMap();
    }
}