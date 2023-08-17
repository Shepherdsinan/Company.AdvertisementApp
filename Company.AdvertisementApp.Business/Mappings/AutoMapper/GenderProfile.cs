using AutoMapper;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Mappings.AutoMapper;

public class GenderProfile : Profile
{
    public GenderProfile()
    {
        CreateMap<Gender, GenderCreateDto>().ReverseMap();
        CreateMap<Gender, GenderUpdateDto>().ReverseMap();
        CreateMap<Gender, GenderListDto>().ReverseMap();
    }
}