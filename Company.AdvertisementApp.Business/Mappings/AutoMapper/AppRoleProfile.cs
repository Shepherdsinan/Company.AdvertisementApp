using AutoMapper;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Mappings.AutoMapper;

public class AppRoleProfile : Profile
{
    public AppRoleProfile()
    {
        CreateMap<AppRole, AppRoleListDto>().ReverseMap();
    }
}