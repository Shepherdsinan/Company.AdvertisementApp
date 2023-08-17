using AutoMapper;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Mappings.AutoMapper;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, AppUserCreateDto>().ReverseMap();
        CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
        CreateMap<AppUser, AppUserListDto>().ReverseMap();

    }
}