using AutoMapper;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.UI.Models;

namespace Company.AdvertisementApp.UI.Mappings.AutoMapper;

public class UserCreateModelProfile : Profile
{
    public UserCreateModelProfile()
    {
        CreateMap<UserCreateModel, AppUserCreateDto>();
    }
}